using System.ComponentModel.DataAnnotations;

namespace BelinAI.Data
{
    public class UserApp
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; }

        public string AppUserId { get; set; }
        public ApplicationUser AppUser { get; set; }
    }
}
