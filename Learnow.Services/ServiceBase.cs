using Learnow.Domain;
using Learnow.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Services
{
    public abstract class ServiceBase
    {
        protected AppDbContext Context { get; set; }
        public ServiceBase(AppDbContext context)
        {
            Context = context;
        }
    }
}
