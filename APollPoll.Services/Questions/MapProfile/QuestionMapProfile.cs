using APollPoll.Services.Questions.Models;
using AutoMapper;
using PollPoll.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Questions.MapProfile
{
    public class QuestionMapProfile : Profile
    {
        public QuestionMapProfile()
        {
            CreateMap<QuestionEntity, QuestionDetail>();
            CreateMap<QuestionEntity, QuestionListItem>();
            CreateMap<QuestionCreate, QuestionEntity>();
            CreateMap<QuestionUpdate, QuestionEntity>();
        }
    }
}
