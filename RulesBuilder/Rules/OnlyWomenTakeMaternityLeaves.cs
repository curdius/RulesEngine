using System;
namespace RulesBuilder.Rules
{
    public class OnlyWomenTakeMaternityLeaves:BaseRule,IRule
    {
        public OnlyWomenTakeMaternityLeaves()
        {
        }


        public  string ErrorMessage { get => "only-woman-take-maternity-leaves-failure"; }
   

        public bool IsSatisfiedBy()
        {
            if (this.BusEntity == null)
                throw new ArgumentNullException("User Business Object cannot be Null");
            if (this.BusEntity.Genre == null )
                throw new ArgumentNullException("User Genre cannot be Null");
            if (this.LeaveData == null)
                throw new ArgumentNullException("Leave Data cannot be Null");
            if (this.LeaveData.Reason == null)
                throw new ArgumentNullException("Leave Reason cannot be Null");

            if (this.LeaveData.Reason == "Maternity" && this.BusEntity.Genre == "M")
                return false;
            else
                return true;
        }
    }
}

