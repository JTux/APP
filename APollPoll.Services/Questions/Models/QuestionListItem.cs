using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Questions.Models
{
    public class QuestionListItem
    {
        public int Id { get; set; }

        [DisplayName("Question")]
        public string Title { get; set; }

        [DisplayName("Multiple Choice")]
        public bool IsMultipleChoice { get; set; }

        [DisplayName("Total Options")]
        public int OptionCount { get; set; }
    }
}
