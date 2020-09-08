using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PollPoll.Data.Entities
{
    [Table("Options")]
    public class OptionEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(50)]
        public string Text { get; set; }

        [ForeignKey(nameof(Question))]
        public int QuestionId { get; set; }
        public virtual QuestionEntity Question { get; set; }
    }
}