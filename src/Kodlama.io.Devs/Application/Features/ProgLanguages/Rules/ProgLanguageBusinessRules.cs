using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgLanguages.Rules
{
    public class ProgLanguageBusinessRules
    {
        private readonly IProgLanguageRepository _progLanguageRepository;

        public ProgLanguageBusinessRules(IProgLanguageRepository progLanguageRepository)
        {
            _progLanguageRepository = progLanguageRepository;
        }

        public async Task ProgLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgLanguage> result = await _progLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming Language name exists.");
        }
        //public async Task BrandShoulExistsWhenRequested(int id)
        //{
        //    Brand brand = await _brandRepository.GetAsync(b => b.Id == id);
        //    if (brand == null) throw new BusinessException("Requested brand does not exists.");
        //}
    }
}
