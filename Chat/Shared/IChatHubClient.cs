namespace Chat.Shared
{
    public interface IChatHubClient
    {
        Task UserConnected(string userName);
        Task ConnectedUsersList(IEnumerable<string> userName);
    }
}
