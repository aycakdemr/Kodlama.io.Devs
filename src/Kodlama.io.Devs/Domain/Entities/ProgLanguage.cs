
using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProgLanguage : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Framework> Frameworks { get; set; }
        public ProgLanguage()
        {
        }

        public ProgLanguage(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
        
    }
}
