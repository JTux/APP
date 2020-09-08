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
    public class QuestionService : BaseService<QuestionEntity, QuestionCreate, QuestionDetail, QuestionListItem, QuestionUpdate>, IQuestionService
    {
        protected override QuestionDetail GetDetail(QuestionEntity entity)
        {
            var detail = new QuestionDetail
            {
                Id = entity.Id,
                Title = entity.Title,
                IsMultipleChoice = entity.IsMultipleChoice
            };

            return detail;
        }

        protected override QuestionEntity GetEntity(QuestionCreate model)
        {
            var entity = new QuestionEntity
            {
                Title = model.Title,
                IsMultipleChoice = model.IsMultipleChoice
            };

            return entity;
        }

        protected override QuestionEntity GetEntity(QuestionUpdate model)
        {
            var entity = new QuestionEntity
            {
                Id = model.Id,
                Title = model.Title,
                IsMultipleChoice = model.IsMultipleChoice
            };

            return entity;
        }

        protected override QuestionListItem GetListItem(QuestionEntity entity)
        {
            var listItem = new QuestionListItem
            {
                Id = entity.Id,
                Title = entity.Title,
                IsMultipleChoice = entity.IsMultipleChoice,
                OptionCount = entity.Options.Count
            };

            return listItem;
        }
    }
}
