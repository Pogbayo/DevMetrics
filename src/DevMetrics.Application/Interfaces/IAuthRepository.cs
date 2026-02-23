namespace DevMetrics.Application.Interfaces
{
    public interface IAuthRepository
    {
        Task<string?> LoginAsync(string email, string password);
        Task RegisterAsync(string email, string password, string username);

    }
}
