using System.ComponentModel.DataAnnotations;

namespace APollPoll.Services.Options.Models
{
    public class OptionUpdate
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(50)]
        public string Text { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int QuestionId { get; set; }
    }
}
