using IG_Train.Application.Identity;

namespace IG_Train.Web.Models
{
    public record JWTTokenConfiguration : ITokenConfiguration
    {
        public string Key { get; init; } = null!;

        public string Issuer { get; init; } = null!;
    }        
}

