﻿using Polux.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Polux.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        Task<int> Complete();
    }
}
