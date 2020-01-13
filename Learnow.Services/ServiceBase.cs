using Learnow.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Services
{
    public abstract class ServiceBase
    {
        protected LearnowDbContext Context { get; set; }
        public ServiceBase(LearnowDbContext context)
        {
            Context = context;
        }
    }
}
