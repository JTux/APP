using APollPoll.Services.Options.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Questions.Models
{
    public class QuestionDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsMultipleChoice { get; set; }
        public List<OptionListItem> Options { get; set; } = new List<OptionListItem>();
    }
}
