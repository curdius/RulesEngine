using System;
namespace RulesBuilder
{
    public interface IUserDomain
    {
        string Genre { get; set; }
        string Relegion { get; set; }
        int Age { get; set; }
        string WorkType { get; set; }
    }
}

