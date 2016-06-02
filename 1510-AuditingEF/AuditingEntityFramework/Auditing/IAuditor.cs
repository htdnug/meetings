using System.Data.Entity.Infrastructure;

namespace AuditingEntityFramework.Auditing
{
    public interface IAuditor
    {
        AuditLog AuditChange(DbEntityEntry entry, string userToken);
    }
}