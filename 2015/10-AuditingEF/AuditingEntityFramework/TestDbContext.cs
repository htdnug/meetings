using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AuditingEntityFramework.Auditing;

namespace AuditingEntityFramework
{
    public class TestDbContext : DbContext
    {
        public TestDbContext()
            : base("Test")
        {
            var initializer = new NullDatabaseInitializer<TestDbContext>();
            Database.SetInitializer(initializer);
        }

        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Widget> Widgets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuditLogMap());
            modelBuilder.Entity<Widget>().ToTable("Widget").HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return this.SaveChanges("SYSTEM_USER");
        }

        public virtual int SaveChanges(string userId)
        {
            return this.ProcessChanges(userId);
        }

        protected virtual AuditorFactoryBase GetAuditorFactory()
        {
            return new AuditorFactoryBase(this);
        }

        protected int ProcessChanges(string userToken)
        {
            var auditList = new List<AuditLog>();
            var list = new List<DbEntityEntry>();
            var auditorFactory = this.GetAuditorFactory();
            IEnumerable<DbEntityEntry> changedEntities = this.GetAuditableChanges();

            foreach (var entity in changedEntities)
            {
                IAuditor auditor = auditorFactory.MakeAuditor(entity.Entity.GetType());
                AuditLog audit = auditor.AuditChange(entity, userToken);
                auditList.Add(audit);
                list.Add(entity);
            }

            var retVal = base.SaveChanges();

            if (auditList.Any())
            {
                int i = 0;
                foreach (var audit in auditList)
                {
                    if (audit.Operation == AuditOperation.C.ToString())
                    {
                        audit.RecordId = audit.GetRecordIdAction(list[i]);
                    }

                    this.AuditLogs.Add(audit);
                    i++;
                }
                base.SaveChanges();
            }

            return retVal;
        }

        private IEnumerable<DbEntityEntry> GetAuditableChanges()
        {
            return this.ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Added
                    || p.State == EntityState.Deleted
                    || p.State == EntityState.Modified);
        }
    }
}
