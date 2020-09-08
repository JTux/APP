using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PollPoll.Data.Entities
{
    [Table("Questions")]
    public class QuestionEntity
    {
        public QuestionEntity() { }
        public QuestionEntity(string title, bool isMultipleChoice)
        {
            Title = title;
            IsMultipleChoice = isMultipleChoice;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(7), MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsMultipleChoice { get; set; }

        public virtual List<OptionEntity> Options { get; set; }
    }
}