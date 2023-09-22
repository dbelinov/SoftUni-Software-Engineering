using System;
using System.Collections.Generic;

/*
7IK9Yo0h
9NoBUajQ
Ce8vwPmE
SVQXQCbc
tSzE5t0p
PARTY
9NoBUajQ
Ce8vwPmE
SVQXQCbc
END

m8rfQBvl
fc1oZCE0
UgffRkOn
7ugX7bm0
9CQBGUeJ
2FQZT3uC
dziNz78I
mdSGyQCJ
LjcVpmDL
fPXNHpm1
HTTbwRmM
B5yTkMQi
8N0FThqG
xys2FYzn
MDzcM9ZK
PARTY
2FQZT3uC
dziNz78I
mdSGyQCJ
LjcVpmDL
fPXNHpm1
HTTbwRmM
B5yTkMQi
8N0FThqG
m8rfQBvl
fc1oZCE0
UgffRkOn
7ugX7bm0
9CQBGUeJ
END
*/

namespace _08.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> list = new HashSet<string>();
            HashSet<string> vipList = new HashSet<string>();
            
            string personInList;
            while ((personInList = Console.ReadLine()) != "PARTY")
            {
                char firstChar = personInList[0];
                if (Char.IsLetter(firstChar))
                {
                    list.Add(personInList);
                }
                else if (char.IsDigit(firstChar))
                {
                    vipList.Add(personInList);
                }
            }

            string person;
            while ((person = Console.ReadLine()) != "END")
            {
                bool isVip = char.IsDigit(person[0]);

                if (list.Contains(person) || vipList.Contains(person))
                {
                    if (isVip)
                    {
                        vipList.Remove(person);
                    }
                    else
                    {
                        list.Remove(person);
                    }
                }
            }

            Console.WriteLine(list.Count + vipList.Count);
            foreach (var vip in vipList)
            {
                Console.WriteLine(vip);
            }

            foreach (var nonVip in list)
            {
                Console.WriteLine(nonVip);
            }
        }
    }
}