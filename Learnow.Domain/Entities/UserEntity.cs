using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Learnow.Domain.Entities
{
    [Table("Users")]
    public class UserEntity : IEntity
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
