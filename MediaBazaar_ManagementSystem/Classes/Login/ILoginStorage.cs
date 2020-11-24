namespace MediaBazaar_ManagementSystem
{
    public interface ILoginStorage
    {
        int Check(string username, string password);
    }
}
