using APollPoll.Services.Options.MapProfile;
using APollPoll.Services.Questions.MapProfile;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APollPoll.Web.App_Start
{
    public class MapperConfig
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<QuestionMapProfile>();
                cfg.AddProfile<OptionMapProfile>();
            });

            return config.CreateMapper();
        }
    }
}