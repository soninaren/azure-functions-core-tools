using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PublishCli
{
    public static class ArmHelpers
    {
        public static async Task<HttpClient> GetClient()
        {
            var token = await AuthHelpers.GetToken();
            var client = new HttpClient() { BaseAddress = new Uri(Constants.ArmDomain) };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return client;
        }

        public static async Task<bool> CheckAccess()
        {
            using (var client = await GetClient())
            {
                var response = await client.PostAsync($"/subscriptions/{Constants.SubscriptionId}", new StringContent(string.Empty));
            }
        }
    }
}