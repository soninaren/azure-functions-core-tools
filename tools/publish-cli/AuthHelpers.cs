using System.Threading.Tasks;
using Colors.Net;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace PublishCli
{
    public static class AuthHelpers
    {
        private static AsyncLock _lock = new AsyncLock();
        private static string _token;
        public static async Task<string> GetToken()
        {
            if (string.IsNullOrEmpty(_token))
            {
                using (await _lock.LockAsync())
                {
                    if (string.IsNullOrEmpty(_token))
                    {
                        var authContext = new AuthenticationContext($"{Constants.AADAuthorityBase}/{Constants.TenantId}");
                        var code = await authContext.AcquireDeviceCodeAsync(Constants.ArmAudience, Constants.AADClientId);

                        ColoredConsole
                            .WriteLine($"To sign in, use a web browser to open the page {code.VerificationUrl} and enter the code {code.UserCode} to authenticate.");

                        var token = await authContext.AcquireTokenByDeviceCodeAsync(code);
                        _token = token.CreateAuthorizationHeader();
                    }
                }
            }
            return _token;
        }
    }
}