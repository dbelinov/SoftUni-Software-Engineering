namespace CustomStack;

public class StackOfStrings : Stack<string>
{
    public bool IsEmpty()
    {
        return Count == 0;
    }

    public Stack<string> AddRange(Stack<string> range)
    {
        foreach (string s in range)
        {
            Push(s);
        }

        return this;
    }
}