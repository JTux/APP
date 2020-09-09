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
        public string Title { get; set; }

        [Required]
        [DisplayName("Multiple Choice")]
        public bool IsMultipleChoice { get; set; }
    }
}
