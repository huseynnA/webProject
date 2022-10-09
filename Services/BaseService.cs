using AutoMapper;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService:IBaseService
    {
    }
    public class BaseService<TReq, TEntity, TRes> : IBaseService<TReq, TEntity, TRes> where TEntity :class
    {

        protected readonly AppDbContext _db;
        protected readonly DbSet<TEntity> _dbWorker;
        protected readonly IMapper _mapper;
        public BaseService(AppDbContext db,IMapper mapper)
        {
            _db = db;
            _dbWorker=_db.Set<TEntity>();
            _mapper = mapper;
        }

        public  TRes Create(TReq req)
        {
            try
            {

                var dto = _mapper.Map<TReq, TEntity>(req);
                
                _dbWorker.Add(dto);
                _db.SaveChanges();

                var res = _mapper.Map<TEntity, TRes>(dto);
                return res;
            }

            catch (Exception e)
            {
                throw new Exception(e.Source); 
            }
        }

      

        public void Delete(int id)
        {
            try
            {
                var res = _dbWorker.Find(id);
                _dbWorker.Remove(res);
                _db.SaveChanges();
            }
            catch (Exception e) 
            {
                throw new Exception(e.Source);
            }
        }

        public TRes Get(int id)
        {
            try
            {
                var dto = _dbWorker.Find(id);
                var res = _mapper.Map<TEntity, TRes>(dto);
                return res;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Source);
            }
        }

        public IEnumerable<TRes> Get()
        {
            try
            {
                var dto = _dbWorker.ToList();
                var res = _mapper.Map<IEnumerable<TEntity>,IEnumerable<TRes>>(dto);
                return res;
            }
            catch (Exception e)
            {
                throw new Exception(e.Source);
            }
        }

        public TRes Update(TReq req)
        {
            try
            {
                var dto = _mapper.Map<TReq, TEntity>(req);
                _dbWorker.Update(dto);
                _db.SaveChanges();
                var res = _mapper.Map<TEntity, TRes>(dto);
                return res;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Source);
            }
        }
        public virtual IEnumerable<TRes> Get(int page, int pageSize)
        {
            var ents = _dbWorker.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var res = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TRes>>(ents);
            return res;
        }
    }
}
