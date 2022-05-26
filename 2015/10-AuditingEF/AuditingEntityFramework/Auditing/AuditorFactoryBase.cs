using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AuditingEntityFramework.Auditing
{
    public class AuditorFactoryBase
    {
        private readonly Dictionary<Type, Type> auditors;
        private readonly DbContext context;

        public AuditorFactoryBase(DbContext contextToUse)
        {
            this.auditors = new Dictionary<Type, Type>();
            this.context = contextToUse;
        }

        public IAuditor MakeAuditor(Type type)
        {
            if (!this.auditors.ContainsKey(type))
            {
                return new AuditorBase(this.context);
            }

            Type objectType = this.auditors[type];
            return (IAuditor)Activator.CreateInstance(objectType);
        }

        protected void AddAuditor(Type type, Type auditor)
        {
            if (auditor.GetInterfaces().All(x => x.FullName != typeof(IAuditor).FullName))
            {
                throw new ArgumentException("'auditor' must implement IAuditor.", "auditor");
            }

            if (!this.auditors.ContainsKey(type))
            {
                this.auditors.Add(type, auditor);
            }
        }

        protected void RemoveAuditor(Type type)
        {
            if (!this.auditors.ContainsKey(type))
            {
                throw new ArgumentOutOfRangeException("type", "Auditor not found.");
            }

            this.auditors.Remove(type);
        }
    }
}
