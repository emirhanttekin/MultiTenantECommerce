namespace LuvCeramicArt.Shop.Helpers
{
    public static class AppSettingsHelper
    {
        public static string GetTenantId()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return config["Tenant:TenantId"];
        }
    }
}
