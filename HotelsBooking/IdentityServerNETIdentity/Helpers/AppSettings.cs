namespace IdentityServerNETIdentity.Helpers
{
    public class AppSettings
    {
        public string ClientId { get; set; }
        public string Secret { get; set; }
        public string ApiResource { get; set; }
        public string Scope { get; set; }
        public string IdentityUrl { get; set; }
        public string IdentityUrlExternal { get; set; }
    }
}
