using System;
using RulesBuilder;
namespace RulesBuilder
{
    public abstract class BaseRule { 

        public int priority { get; set; }

        public IUserDomain BusEntity { get; set; }
       
        public ILeaveData LeaveData { get; set; }

        public PolicyConfig PolicyConfig { get; set; }

        public BaseRule()
        {
        }


     
    }
}

