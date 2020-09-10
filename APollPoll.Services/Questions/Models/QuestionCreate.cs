using APollPoll.Services.Options.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Questions.Models
{
    public class QuestionCreate
    {
        [Required]
        [DisplayName("Question")]
        [MinLength(7), MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [DisplayName("Allow Multiple Selections")]
        public bool IsMultipleChoice { get; set; }

        public List<OptionCreate> Options { get; set; } = new List<OptionCreate>();
    }
}
