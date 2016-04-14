using System;

namespace Epic.Domain.Model
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }
        DateTimeOffset? CreatedOn { get; set; }
        string UpdatedBy { get; set; }
        DateTimeOffset? UpdatedOn { get; set; }
    }
}