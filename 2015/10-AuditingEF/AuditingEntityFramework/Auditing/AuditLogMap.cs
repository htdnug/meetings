using System.Data.Entity.ModelConfiguration;

namespace AuditingEntityFramework.Auditing
{
    public class AuditLogMap : EntityTypeConfiguration<AuditLog>
    {
        public AuditLogMap()
            : this("dbo", "AuditLog")
        {
        }

        public AuditLogMap(string databaseSchema)
            : this(databaseSchema, "AuditLog")
        {
        }

        public AuditLogMap(string databaseSchema, string tableName)
        {
            this.ToTable(tableName, databaseSchema);
            this.HasKey(x => x.Id);
            this.Property(x => x.Operation).IsRequired();
            this.Property(x => x.UserToken).IsRequired();
            this.Property(x => x.TableName).IsRequired();
            this.Property(x => x.RecordId).IsRequired();
            this.Ignore(x => x.GetRecordIdAction);
        }
    }
}
