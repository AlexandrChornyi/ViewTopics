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
    public class categoryRepository
        : BaseRepository<category>, ICategoryRepository
    {
        internal categoryRepository(categoryContext context)
            : base(context)
        {

        }
    }
}
