namespace DefiningClasses;

public class Family
{
    public List<Person> People { get; set; }

    public void AddMember(Person member)
    {
        People.Add(member);
    }

    public Person GetOldestMember()
    {
        Person oldest = People.OrderByDescending(p => p.Age).First();
        return oldest;
    }

    public Family()
    {
        People = new List<Person>();
    }
}