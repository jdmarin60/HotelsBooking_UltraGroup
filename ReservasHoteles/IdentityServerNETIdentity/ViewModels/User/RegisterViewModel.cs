namespace IdentityServerNETIdentity.ViewModels.User
{
    public class RegisterViewModel
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumberConfirmed { get; set; } = string.Empty;
        public string EmailConfirmed { get; set; } = string.Empty;
    }
}
