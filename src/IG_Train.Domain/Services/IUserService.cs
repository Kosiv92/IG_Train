using IG_Train.Domain.Entities;
using IG_Train.Domain.Services.Common;

namespace IG_Train.Domain.Services
{    public interface IUserService : ITransientService
    {
        Task<int> CreateUser(UserEntity userEntity, CancellationToken cancellationToken);

        Task DeleteUser(int id, CancellationToken cancellationToken);

        Task<IEnumerable<UserEntity>> GetAllUsers(CancellationToken cancellationToken);

        Task<UserEntity?> GetUser(int id, CancellationToken cancellationToken);

        Task<UserEntity?> GetUserByEmail(string email, CancellationToken cancellationToken);

        Task<int> UpdateUser(UserEntity userEntity, CancellationToken cancellationToken);
    }
}
