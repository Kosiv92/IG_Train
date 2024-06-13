namespace IG_Train.Application.Identity
{
    public interface ITokenConfiguration
    {
        string Key { get; }

        string Issuer { get; }
    }
}
