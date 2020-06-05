using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Interfaces
{
    public interface ICategoryTopicRepository
        : IRepository<category_topic>
    {
    }
}
