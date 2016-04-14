using System;
using Epic.Domain.Model;

namespace Epic.Domain.Extensions
{
    public static class IAuditableExtensions
    {
        public static void SetCreatedBy(this IAuditable auditable, string username)
        {
            auditable.CreatedBy = username;
            auditable.CreatedOn = DateTimeOffset.UtcNow;
        }

        public static void SetUpdatedBy(this IAuditable auditable, string username)
        {
            auditable.UpdatedBy = username;
            auditable.UpdatedOn = DateTimeOffset.UtcNow;
        }
    }
}
