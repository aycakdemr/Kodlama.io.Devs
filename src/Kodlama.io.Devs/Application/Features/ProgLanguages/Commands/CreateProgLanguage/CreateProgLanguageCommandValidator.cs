using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgLanguages.Commands.CreateProgLanguage
{
    public class CreateProgLanguageCommandValidator : AbstractValidator<CreateProgLanguageCommand>
    {
        public CreateProgLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
