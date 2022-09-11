using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;

namespace Domain.Entities
{
    public class Social : Entity
    {
        public int UserId { get; set; }
        public string Url { get; set; }
        public virtual User? User { get; set; }

        public Social()
        {

        }

        public Social(int id,int userId, string url)
        {
            Id = id;
            UserId = userId;
            Url = url;
        }
    }
}
