using System;

namespace Epic.Domain.Model
{
    public class WorkTime
    {
        public DateTimeOffset? StartDateTime { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
    }
}