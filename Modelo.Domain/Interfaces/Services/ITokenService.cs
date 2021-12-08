namespace Modelo.Domain.Interfaces.Services
{
    public interface ITokenService<T> where T : class
    {
        public string GenerateToken(T entity);
    }
}