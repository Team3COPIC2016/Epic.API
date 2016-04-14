using System.Collections.Generic;

namespace Epic.Domain.Model
{
    public interface ITimedWork : IWork
    {
        decimal? EstimatedTime { get; set; }
        decimal? RemainingTime { get; set; }
        decimal? ActualTime { get; set; }
        List<WorkTime> TimesWorking { get; set; }
    }
}