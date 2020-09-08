using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Questions.Models
{
    public class QuestionCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public bool IsMultipleChoice { get; set; }
    }
}
