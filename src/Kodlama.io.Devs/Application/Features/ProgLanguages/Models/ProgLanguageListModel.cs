using Application.Features.ProgLanguages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgLanguages.Models
{
    public class ProgLanguageListModel : BasePageableModel
    {
        public IList<ProgLanguageListDto> Items { get; set; }
    }
}
