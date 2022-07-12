using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IBaseService
    {
        
    }

    public interface IBaseService<TModel> : IBaseService where TModel : class
    {
        public TModel Get(int id);
        public IEnumerable<TModel> Get();
        public TModel Create(TModel user);
        public TModel Update(TModel user);
        public void Delete(int id);
    }
}
