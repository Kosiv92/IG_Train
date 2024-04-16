
namespace IG_Train.Domain.Entities
{
    public class UserEntity : BaseEntity<int>
    {
        public UserEntity(int id, string name, string email, string passwordHash) : base(id)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;            
        }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public string PasswordHash { get; private set; }  
    }
}
