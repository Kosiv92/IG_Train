
namespace IG_Train.Domain.Entities
{
    public class UserEntity : BaseEntity<int>
    {
        public UserEntity(int id, string name, string passwordHash, string email) : base(id)
        {
            Name = name;
            PasswordHash = passwordHash;
            Email = email;
        }

        public string Name { get; private set; }

        public string PasswordHash { get; private set; }

        public string Email { get; private set; }

    }
}
