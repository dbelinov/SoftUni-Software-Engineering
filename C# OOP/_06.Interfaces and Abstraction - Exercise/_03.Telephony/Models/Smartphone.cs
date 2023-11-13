using Telephony.Models.Interfaces;

namespace Telephony.Models;

public class Smartphone : IBrowsable, ICallable
{
    public string Call(string phoneNumber)
    {
        if (phoneNumber.Any(c => !char.IsDigit(c)))
        {
            throw new ArgumentException("Invalid number!");
        }

        return $"Calling... {phoneNumber}";
    }
    
    public string Browse(string url)
    {
        if (url.Any(c => char.IsDigit(c)))
        {
            throw new ArgumentException("Invalid URL!");
        }

        return $"Browsing: {url}!";
    }
}