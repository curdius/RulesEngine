using System;
namespace RulesBuilder
{
    public interface ILeaveData
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Reason { get; set; }
        int NumberOfDays { get; set; }
    }
}

