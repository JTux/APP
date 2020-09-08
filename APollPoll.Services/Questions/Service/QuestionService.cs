using APollPoll.Services.Options.Models;
using APollPoll.Services.Questions.Models;
using APollPoll.Services.Resources;
using AutoMapper;
using PollPoll.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Questions.Service
{
    public class QuestionService
        : BaseService<QuestionEntity, QuestionCreate, QuestionDetail, QuestionListItem, QuestionUpdate>, IQuestionService
    {
        public QuestionService(IMapper mapper) : base(mapper) { }

        protected override QuestionDetail GetDetail(QuestionEntity entity)
        {
            var detail = base.GetDetail(entity);
            detail.Options =
                entity.Options.Select(o =>
                    new OptionListItem
                    {
                        Id = o.Id,
                        QuestionId = o.QuestionId,
                        Text = o.Text
                    }).ToList();
            return detail;
        }

        protected override QuestionListItem GetListItem(QuestionEntity entity)
        {
            var listItem = base.GetListItem(entity);
            listItem.OptionCount = entity.Options.Count;
            return listItem;
        }
    }
}
