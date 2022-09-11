﻿using Application.Features.Frameworks.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Frameworks.Models
{
    public class FrameworkListModel : BasePageableModel
    {
        public IList<FrameworkListDto> Items { get; set; }
    }
}
