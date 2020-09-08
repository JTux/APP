using APollPoll.Services.Questions.Models;
using APollPoll.Services.Resources;
using PollPoll.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Questions.Service
{
    public interface IQuestionService 
        : IService<QuestionEntity, QuestionCreate, QuestionDetail, QuestionListItem, QuestionUpdate>
    {
    }
}
