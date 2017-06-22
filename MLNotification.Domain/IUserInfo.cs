namespace MLNotification.Domain
{
    public interface IUserInfo
    {
        string Group { get; set; }
        string User { get; set; }
        string Server { get; set; }
    }
}