﻿using AutoMapper;
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
    public class BaseService
    {

    }

    public class BaseService<TReq, TEntity, TRes> : BaseService, IBaseService<TReq, TEntity, TRes> where TEntity : class
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;
        protected readonly AppDbContext _db;
        public BaseService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();

            _mapper = mapper;
        }

        public TRes Create(TReq model)
        {
            var ent = _mapper.Map<TReq, TEntity>(model);

            _dbSet.Add(ent);
            _db.SaveChanges();
            var res = _mapper.Map<TEntity, TRes>(ent);
            return  res;
        }

        public void Delete(int id)
        {

            var ent = _dbSet.Find(id);
            
            _dbSet.Remove(ent);
            _db.SaveChanges();

        }

        public TRes Get(int id)
        {
            var ent =_dbSet.Find(id);
            var res = _mapper.Map<TEntity, TRes>(ent);
            return res;
        }

        public IEnumerable<TRes> Get()
        {
            var ents = _dbSet.ToList();

            var res = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TRes> >(ents);
            return res;
        }

        public TRes Update(TReq model)
        {
            var ent = _mapper.Map<TReq, TEntity>(model);
            _dbSet.Update(ent);
            _db.SaveChanges();
            var res = _mapper.Map<TEntity, TRes>(ent);
            return res;
        }
    }
}
