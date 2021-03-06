﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YS.CMS.Domain.Base.Interfaces
{
    public interface IRepositorioBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> All { get; }
        Task<TEntity> FindAsync(Guid id);
        IQueryable<TEntity> AsNoTracking();
        Task CreateAsync(params TEntity[] obj);
        Task UpdateAsync(params TEntity[] obj);
        Task DeleteAsync(params TEntity[] obj);
        Task<IList<TEntity>> FindAllAsync(params Guid[] ids);
    }
}
