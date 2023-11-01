using System;
using System.Text;

namespace Person;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    
    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append($"Name: {Name}, Age: {Age}");

        return stringBuilder.ToString();
    }

}