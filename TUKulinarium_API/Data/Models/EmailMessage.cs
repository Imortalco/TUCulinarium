public class EmailMessage
{
    public string ToAddress { get; set; }
    public string Subject { get; set; }
    public string? Body { get; set; }
    public EmailMessage(string toAddress, string subject, string body)
    {
        ToAddress = toAddress;
        Subject = subject;
        Body = body;
    }
}