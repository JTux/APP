using APollPoll.Services.Options.Models;
using APollPoll.Services.Resources;
using PollPoll.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Options.Service
{
    public interface IOptionService
        : IService<OptionEntity, OptionCreate, OptionListItem, OptionListItem, OptionUpdate>
    {
    }
}
