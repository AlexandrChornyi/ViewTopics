using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.UnitOfWork;
using DAL.Repositories.Impl;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private categoryContext db;
        private usersRepository UsersRepository;
        private categoryRepository CategoriesRepository;
        private category_topicRepository Category_TopicsRepository;
        private topicRepository TopicsRepository;

        public EFUnitOfWork(categoryContext context)
        {
            db = context;
        }
        public IUserRepository users
        {
            get
            {
                if (UsersRepository == null)
                    UsersRepository = new usersRepository(db);
                return UsersRepository;
            }
        }
        public ICategoryRepository categories
        {
            get
            {
                if (CategoriesRepository == null)
                    CategoriesRepository = new categoryRepository(db);
                return CategoriesRepository;
            }
        }

        public ICategoryTopicRepository categoryTopics
        {
            get
            {
                if (Category_TopicsRepository == null)
                    Category_TopicsRepository = new category_topicRepository(db);
                return Category_TopicsRepository;
            }
        }

        public ITopicRepository topics
        {
            get
            {
                if (TopicsRepository == null)
                    TopicsRepository = new topicRepository(db);
                return TopicsRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
