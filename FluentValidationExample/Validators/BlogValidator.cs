using FluentValidation;
using FluentValidationExample.Models;

namespace FluentValidationExample.Validators
{
    public class BlogValidator : AbstractValidator<BlogDataModel>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Title cannot be empty.");
            RuleFor(x => x.BlogAuthor).NotEmpty().WithMessage("Blog Author cannot be empty.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog Content cannot be empty.");
        }
    }
}