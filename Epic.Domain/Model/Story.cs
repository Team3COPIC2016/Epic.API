using System;

namespace Epic.Domain.Model
{
    public class Story : IWork
    {
        public string Id { get; set; }
        public string ParentId { get; set; }

        public string Title { get; set; }

        public string Type
        {
            get { return "Story"; }
            set { }
        }
        public string Description { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public string AssignedToId { get; set; }
        public decimal? BusinessValue { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }

        public string CreatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}