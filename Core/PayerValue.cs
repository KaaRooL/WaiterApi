namespace Core;

public class PayerValue: IEquatable<PayerValue>
{
    public string Email { get; private set;}

    private PayerValue(string email)
    {
        Email = email;
    }

    public static PayerValue Create(string email) => new PayerValue(email);
    
    public bool Equals(PayerValue? other) => string.Equals(Email, other?.Email);
}
