using FluentValidation;
using TwitterCloneApp.DTO.Tweet;

namespace TwitterCloneApp.Service.Validations
{
	public class AddTweetValidator : AbstractValidator<AddTweetDto>
	{
		public AddTweetValidator()
		{
			RuleFor(x => x.Content).NotNull().WithMessage("{propertyName} must not null!").NotEmpty().WithMessage("{propertyName} must not empty!").MaximumLength(240);
		}
	}
}
