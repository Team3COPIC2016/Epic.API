using System;
using System.Collections.Generic;

namespace Epic.Domain.Model
{
    public class Task : ITimedWork
    {
        public Task()
        {
            TimesWorking = new List<WorkTime>();
        }

        public string Id { get; set; }
        public string ParentId { get; set; }

        public string Title { get; set; }

        public string Type
        {
            get { return "Task"; }
            set { }
        }
        public string Description { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string AssignedToId { get; set; }
        public decimal? BusinessValue { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
        public decimal? EstimatedTime { get; set; }
        public decimal? RemainingTime { get; set; }
        public decimal? ActualTime { get; set; }

        public List<WorkTime> TimesWorking { get; set; } 

        public string CreatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}