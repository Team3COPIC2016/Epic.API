using System;

namespace Epic.Domain.Model
{
    public interface IWork : IAuditable
    {
        string Id { get; set; }
        string ParentId { get; set; }
        string Title { get; set; }
        string Type { get; set; }
        string Description { get; set; }
        DateTimeOffset? StartDate { get; set; }
        DateTimeOffset? EndDate { get; set; }
        string AssignedToId { get; set; }
        decimal? BusinessValue { get; set; }
        int Priority { get; set; }
        string Status { get; set; }
    }
}