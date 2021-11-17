using System;
using FluentValidation;
using SocialMedia.Core.DTOs.Command;

namespace SocialMedia.Infrastructure.Validators.Command
{
    public class AddPostValidator : AbstractValidator<AddPostDTO>
    {
        public AddPostValidator()
        {
            RuleFor(post => post.UserId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(post => post.Description)
                .NotNull()
                .Length(20, 500);

            RuleFor(post => post.Date)
                .NotEmpty()
                .LessThan(DateTime.Now);
        }
    }
}
