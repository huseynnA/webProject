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

    public interface IBaseService<TReq,TEntity,TRes> :IBaseService where TEntity:class
    {
        public abstract TRes Create(TReq req);
        public TRes Update(TReq req);
        public TRes Get(int id);
        public IEnumerable<TRes> Get();

        public void Delete(int id);


    }
}
