using System;
namespace RulesBuilder.Rules
{
    public class AgeUnder23 : BaseRule,IRule
    {
        public AgeUnder23()
        {
        }
        
         public string ErrorMessage { get =>  "Age-Under-23-failure"; }
       

        public bool IsSatisfiedBy()
        {
            if (this.BusEntity == null)
                throw new ArgumentNullException("User Business Object cannot be Null");
            if (this.BusEntity.Age == 0 || this.BusEntity.Age <18) 
                throw new ArgumentNullException("User age cannot be 0 or under 18");
            return (this.BusEntity.Age > 23);
                
        }
    }
}

