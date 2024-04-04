
namespace IG_Train.Domain.Entities
{
    public class UserEntity : BaseEntity<int>
    {
        public UserEntity(int id, string name, string passwordHash) : base(id)
        {
            Name = name;
            PasswordHash = passwordHash;            
        }

        public string Name { get; private set; }

        public string PasswordHash { get; private set; }  
    }
}
