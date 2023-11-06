using System;
namespace RulesBuilder
{
    public class PolicyConfig : IPolicyConfig
    {
        public int MaxNumberOfConsecutiveDays {get;set;}

        public PolicyConfig()
        {
        }
    }
}

