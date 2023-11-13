using Telephony.Models.Interfaces;

namespace Telephony.Models;

public class StationaryPhone : ICallable
{
    public string Call(string phoneNumber)
    {
        if (phoneNumber.Any(c => !char.IsDigit(c)))
        {
            throw new ArgumentException("Invalid number!");
        }

        return $"Dialing... {phoneNumber}";
    }
}