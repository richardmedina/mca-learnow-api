using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Domain.Entities
{
    public interface IEntity
    {
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
