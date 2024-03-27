using IG_Train.Domain.Entities;
using IG_Train.Domain.Repositories;

namespace IG_Train.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity, int> _userRepository;

        public UserService(IRepository<UserEntity, int> repository)
        {
            _userRepository = repository;
        }

        public async Task<int> CreateUser(UserEntity exerciseType, CancellationToken cancellationToken)
        {
            return await _userRepository.CreateAsync(exerciseType, cancellationToken);
        }

        public async Task DeleteUser(int id, CancellationToken cancellationToken)
        {
            await _userRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsers(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllAsync(cancellationToken);
        }

        public async Task<UserEntity?> GetUser(int id, CancellationToken cancellationToken)
        {
            return await _userRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<int> UpdateUser(UserEntity exerciseType, CancellationToken cancellationToken)
        {
            return await _userRepository.UpdateAsync(exerciseType, cancellationToken);
        }
    }
}
