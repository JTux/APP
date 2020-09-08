using APollPoll.Services.Options.Models;
using AutoMapper;
using PollPoll.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Options.MapProfile
{
    public class OptionMapProfile : Profile
    {
        public OptionMapProfile()
        {
            CreateMap<OptionEntity, OptionListItem>();
            CreateMap<OptionCreate, OptionEntity>();
            CreateMap<OptionUpdate, OptionEntity>();
        }
    }
}
