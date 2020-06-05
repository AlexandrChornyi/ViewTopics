using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories.Impl
{
    public class category_topicRepository
        : BaseRepository<category_topic>, ICategoryTopicRepository
    {
        internal category_topicRepository(categoryContext context)
            : base(context)
        {

        }
    }
}
