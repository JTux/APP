﻿using APollPoll.Services.Options.Models;
using APollPoll.Services.Resources;
using AutoMapper;
using PollPoll.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Options.Service
{
    public class OptionService 
        : BaseService<OptionEntity, OptionCreate, OptionListItem, OptionListItem, OptionUpdate>, IOptionService
    {
        public OptionService(IMapper mapper) : base(mapper) { }
    }
}
