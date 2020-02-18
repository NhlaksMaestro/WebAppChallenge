using Microsoft.Extensions.Options;
using WebAppChallenge.Model;
using WebChallenge.Contracts.Domain;

namespace WebAppChallenge.Domain
{
    public class Settings : ISettings
    {
        public ApplicationSettings ApplicationSettings { get; set; }

        public Settings(IOptions<ApplicationSettings> options)
        {
            ApplicationSettings = options.Value;
        }
    }
}
