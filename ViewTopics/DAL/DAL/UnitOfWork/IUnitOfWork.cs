using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository users { get; }
        ICategoryRepository categories { get; }
        ICategoryTopicRepository categoryTopics { get; }
        ITopicRepository topics { get; }
        void Save();
    }
}