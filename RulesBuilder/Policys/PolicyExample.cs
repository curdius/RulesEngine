using System;
using System.Collections.Generic;
using RulesBuilder.Rules;

namespace RulesBuilder.Policys
{
    public class PolicyExample
    {
        List<Rules.IRule> _rules = new List<Rules.IRule>();
        PolicyConfig _policyConfig = new PolicyConfig();
        public ILeaveData LeaveData { get; set; }
        public IUserDomain UserDomain { get; set; }


        private void initializePolicyConfig()
        {
        }

        private void prepareRules()
        {     
            _rules.Add(new Rules.AgeUnder23 { priority=1} );
            _rules.Add(new Rules.NoMoreThanXConsecutiveDays() { priority = 2 });
            _rules.Add(new Rules.OnlyWomenTakeMaternityLeaves() { priority = 3 });
            _rules.Sort((r1, r2) => r1.priority.CompareTo(r2.priority));

            foreach (Rules.IRule r in _rules)
            {
                r.BusEntity = this.UserDomain;
                r.LeaveData = this.LeaveData;
                r.PolicyConfig = _policyConfig;

            }
            
        }

        private bool checkRules(out IList<string> outErrors)
        {
            bool result = true;
            outErrors = new List<string>();

             foreach (Rules.IRule r in _rules)
            {
                result &= r.IsSatisfiedBy();
                if (!r.IsSatisfiedBy())
                {
                    outErrors.Add(r.ErrorMessage);
                }
            }
            return result;
        }


        public bool CheckPolicy(out IList<string> outErrors)
        {
          

            initializePolicyConfig();
            _policyConfig.MaxNumberOfConsecutiveDays = 3;


            this.prepareRules();



            return checkRules(out outErrors);


        }
       
    }
}

