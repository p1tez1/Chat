namespace Chat.Shared
{

    public interface IChatHubServer
    {
        Task ConnectUser(string userName);
    }
}
