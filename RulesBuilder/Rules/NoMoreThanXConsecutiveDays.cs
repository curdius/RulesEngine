using System;
namespace RulesBuilder.Rules
{
    public class NoMoreThanXConsecutiveDays:BaseRule,IRule
    {
        public NoMoreThanXConsecutiveDays()
        {
        }

        public  string ErrorMessage { get => "no-more-than-x-number-of-days-failure"; }

        public bool IsSatisfiedBy()
        {
            if (this.PolicyConfig == null)
                throw new ArgumentNullException("The Policy Config can't be null");
            if (this.PolicyConfig.MaxNumberOfConsecutiveDays == 0)
                throw new ArgumentNullException("MaxNumberOfConsecutiveDays in the Policy Config can't be 0");
            if (this.LeaveData == null)
                throw new ArgumentNullException("The leave data cannot be null");
            if (this.LeaveData.StartDate == null)
                throw new ArgumentNullException("The leave start date cannot be null");
            if (this.LeaveData.EndDate == null)
                throw new ArgumentNullException("The leave end date cannot be null");
            

            TimeSpan timeSpan =   this.LeaveData.EndDate- this.LeaveData.StartDate;

            if (timeSpan.Days == 0)
                throw new ArgumentNullException("A leave cannot have 0 days duration");

            return (timeSpan.Days <= this.PolicyConfig.MaxNumberOfConsecutiveDays);
        }
    }
}

