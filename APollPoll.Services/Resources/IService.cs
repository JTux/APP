using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APollPoll.Services.Resources
{
    public interface IService<TEntity, TCreate, TDetail, TListItem, TUpdate>
    {
        Task<int> CreateAsync(TCreate createModel);
        Task<TDetail> GetByIdAsync(int id);
        Task<List<TListItem>> GetAllAsync();
        Task<bool> UpdateAsync(TUpdate model);
        Task<bool> DeleteAsync(int id);
    }
}
