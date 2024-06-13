namespace Bank_exception;

class LowBalance : Exception
{
    public LowBalance(string message) : base(message)
    {
    }
}
