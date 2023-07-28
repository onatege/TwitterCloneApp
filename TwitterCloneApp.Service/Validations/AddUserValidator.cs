using FluentValidation;
using TwitterCloneApp.DTO.Request.User;

namespace TwitterCloneApp.Service.Validations
{
    public class AddUserValidator : AbstractValidator<AddUserDto>
	{
        public AddUserValidator()
        {
            RuleFor(x => x.UserName).NotNull()
                .WithMessage("{PropertyName} must not null!")
                .NotEmpty().WithMessage("{PropertyName} must not empty!")
                .MaximumLength(20);
            RuleFor(x => x.DisplayName).NotNull()
                .WithMessage("{PropertyName} must not null!")
                .NotEmpty().WithMessage("{PropertyName} must not empty!");
            RuleFor(x => x.Email).EmailAddress()
                .WithMessage("Invalid {PropertyName}, Please try again.")
                .NotNull()
                .WithMessage("{PropertyName} must not null.");
            RuleFor(x => x.Password).MinimumLength(8)
                .WithMessage("{PropertyName} too short.")
                .MaximumLength(25)
                .WithMessage("{PropertyName} too long.")
                .NotNull().NotEmpty();
            RuleFor(x => x.Biography).MaximumLength(20);
		}
    }
}
