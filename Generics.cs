using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IJSON
    {
        string ToJSON();
    }

    class Voter
    {
        public static bool IsEligibleToVote(int age)
        {
            return age > 18 ? true : false;
        }
    }
    
    class Generics<T> where T : Voter
    {
        T Person { get; set; }
        int Age { get; set; }

        public Generics(T person, int age)
        {
            Person = person;
            Age = age;
        }

        public bool isPersonEligibleToVote(T person)
        {
            return Voter.IsEligibleToVote(Age);
            //return Person.ToJSON();
        }

    }
}
