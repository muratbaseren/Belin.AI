using System.ComponentModel.DataAnnotations;

namespace BelinAI.Data
{
    public class Option
    {
        [Key]
        public string OptId { get; set; }
        public string ApiKey { get; set; }
        public string Endpoint { get; set; }
        public string PrePrompt { get; set; }
    }
}
