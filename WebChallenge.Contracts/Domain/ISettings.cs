using WebAppChallenge.Model;

namespace WebChallenge.Contracts.Domain
{
    public interface ISettings
    {
        ApplicationSettings ApplicationSettings { get; set; }
    }
}
