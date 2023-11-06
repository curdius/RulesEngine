using System;
namespace RulesBuilder
{
    public class LeaveData:ILeaveData
    {
        public LeaveData()
        {
        }

        public DateTime StartDate { get ;set ; }
        public DateTime EndDate { get ; set; }
        public string Reason { get; set ; }
        public int NumberOfDays { get ; set; }
    }
}

