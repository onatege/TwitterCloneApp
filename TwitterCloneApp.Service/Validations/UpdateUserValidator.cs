using FluentValidation;
using TwitterCloneApp.DTO.User;

namespace TwitterCloneApp.Service.Validations
{
	public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
	{
        public UpdateUserValidator()
        {
			RuleFor(x => x.UserName).NotNull()
				.WithMessage("{propertyName} must not null!")
				.NotEmpty()
				.WithMessage("{propertyName} must not empty!")
				.MaximumLength(20);
			RuleFor(x => x.DisplayName)
				.NotNull()
				.WithMessage("{propertyName} must not null!")
				.NotEmpty()
				.WithMessage("{propertyName} must not empty!");
			RuleFor(x => x.Email).EmailAddress()
				.NotNull();
			RuleFor(x => x.Biography).MaximumLength(20);
		}
    }
}
