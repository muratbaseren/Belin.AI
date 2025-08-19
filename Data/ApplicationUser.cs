using Microsoft.AspNetCore.Identity;

namespace BelinAI.Data
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<UserApp> UserApps { get; set; } = new List<UserApp>();

        public string? YzApiUrl { get; set; }
        public string? YzApiKey { get; set; }
        public int AIUseCount { get; set; } = 0;
        public bool UseAppAI { get; set; } = false;
    }

}
