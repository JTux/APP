using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Options.Models
{
    public class OptionCreate
    {
        [Required]
        [MinLength(1), MaxLength(50)]
        public string Text { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int QuestionId { get; set; }
    }
}
