namespace Bank_exception;
class BlockedAccountException : Exception
{
    public BlockedAccountException(string message) : base(message)
    {
    }
}
