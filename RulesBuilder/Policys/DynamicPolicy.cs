using System;
using Newtonsoft.Json;
namespace RulesBuilder.Policys
{
    public class DynamicPolicy
    {
        IList<Rules.IRule> _rules = new List<Rules.IRule>();
        PolicyConfig _policyConfig = new PolicyConfig();



        private void initializePolicyConfig()
        {
        }

        public string RulesConfig { get; set; }

        private bool runRules(IUserDomain user, ILeaveData leave,out IList<string> outErrors)
        {
           
            dynamic[] rules = JsonConvert.DeserializeObject<dynamic[]>(RulesConfig);

            List<Rules.IRule> ruleList = new List<Rules.IRule>();
            
            Type type;
            Rules.IRule rule;


            outErrors = new List<string>();

            bool result = false;

            foreach (dynamic r in rules)
            {
                type = Type.GetType((string)r.RuleClass);
                rule = (Rules.IRule)Activator.CreateInstance(type);

                rule.BusEntity = user;
                rule.LeaveData = leave;
                rule.PolicyConfig = _policyConfig;


                bool isSatisfied = rule.IsSatisfiedBy();
                result &= isSatisfied;
                if (!isSatisfied)
                {
                    outErrors.Add(rule.ErrorMessage);
                }       
            }

            return result;


        }

        


        public bool CheckPolicy(out IList<string> outErrors)
        {
            IUserDomain User = new UserDomain();
            User.Age = 21;
            User.Genre = "M";

            ILeaveData Leave = new LeaveData();
            Leave.StartDate = new DateTime(2023, 10, 10);
            Leave.EndDate = new DateTime(2023, 10, 15);
            Leave.Reason = "Maternity";

            initializePolicyConfig();
            _policyConfig.MaxNumberOfConsecutiveDays = 3;


  

            return runRules(User,Leave,out outErrors);


        }
    }
}

