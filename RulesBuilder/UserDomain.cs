using System;
namespace RulesBuilder
{
    public class UserDomain:IUserDomain
    {
        public UserDomain()
        {
        }

        public string Genre { get; set; }
        public string Relegion { get; set; }
        public int Age { get; set; }
        public string WorkType { get; set; }
    }
}

