using MeetingApp.Application.Utilities.AppSettings;
using Microsoft.Extensions.Options;

namespace MeetingApp.Application.Utilities.Authorization.Helper
{
    public class TokenHelper
    {
        private readonly IOptions<MeetingAppSettings> _settings;

        public TokenHelper(IOptions<MeetingAppSettings> settings)
        {
            _settings = settings;
        }
    }
}
