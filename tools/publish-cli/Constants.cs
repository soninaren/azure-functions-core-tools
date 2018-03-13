namespace PublishCli
{
    public static class Constants
    {
        public const string AADAuthorityBase = "https://login.microsoftonline.com";
        public const string CommonAADAuthority = "https://login.microsoftonline.com/common";
        public const string ArmAudience = "https://management.core.windows.net/";
        public const string ArmDomain = "https://management.azure.com/";
        public const string AADClientId = "1950a258-227b-4e31-a9cf-717495945fc2";
        public const string TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
        public const string SubscriptionId = "";
        public static readonly string[] Regions = new[] { "bay", "blu", "db3", "hk1" };
        public const string BuildStorageName = "functionsclibuilds";
    }
}