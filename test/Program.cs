// See https://aka.ms/new-console-template for more information
using System;
using RulesBuilder.Policys;

Console.WriteLine("Hello, World!");


try { 
RulesBuilder.Policys.PolicyExample policyExample = new RulesBuilder.Policys.PolicyExample();

IList<string> msgs = new List<string>();

bool result = policyExample.CheckPolicy(out msgs);
Console.WriteLine("Result of Policy: " + result);

if (!result)
{
    foreach(string s in msgs)
    {
        Console.WriteLine("Err:" + s);
    }
}

Console.ReadKey();


    RulesBuilder.Policys.DynamicPolicy dynamicPolicy = new RulesBuilder.Policys.DynamicPolicy();

    IList<string> msgs2 = new List<string>();
    
    dynamicPolicy.RulesConfig = "[{\"RuleClass\": \"RulesBuilder.Rules.NoMoreThanXConsecutiveDays\"},{\"RuleClass\": \"RulesBuilder.Rules.OnlyWomenTakeMaternityLeaves\"},{\"RuleClass\": \"RulesBuilder.Rules.AgeUnder23\"}]";
    bool result2 = dynamicPolicy.CheckPolicy(out msgs2);
    Console.WriteLine("Result of Dynamic Policy: " + result);

    if (!result)
    {
        foreach (string s in msgs2)
        {
            Console.WriteLine("Err:" + s);
        }
    }

    Console.ReadKey();

}
catch (Exception ex )
{
    Console.WriteLine("Exception:" + ex.Message);
    Console.ReadKey();

}