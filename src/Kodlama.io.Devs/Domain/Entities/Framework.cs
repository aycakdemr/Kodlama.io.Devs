using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Framework : Entity
    {
        public string Name { get; set; }
        public int ProgLanguageId { get; set; }

        public virtual ProgLanguage? ProgLanguage { get; set; }
        public Framework()
        {

        }

        public Framework(int id,string name, int progLanguageId)
        {
            Id = id;
            Name = name;
            ProgLanguageId = progLanguageId;
        }
    }
}
