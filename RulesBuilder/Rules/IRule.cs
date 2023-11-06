using System;
namespace RulesBuilder.Rules
{
    public interface IRule
    {
        public string ErrorMessage { get;}
        public bool IsSatisfiedBy();
        IUserDomain BusEntity { get; set; }
        ILeaveData LeaveData { get; set; }
        PolicyConfig PolicyConfig { get; set; }
        int priority { get; set; }
    }
  
}

