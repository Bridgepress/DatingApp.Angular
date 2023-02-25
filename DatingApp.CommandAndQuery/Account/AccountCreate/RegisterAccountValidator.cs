using FluentValidation;

namespace DatingApp.CommandAndQuery.Account.AccountCreate
{
	public class RegisterAccountValidator : AbstractValidator<RegisterAccountCommand>
	{
		public RegisterAccountValidator()
		{
			RuleFor(s => s.UserName)
				.NotEmpty()
				.MinimumLength(2)
				.MaximumLength(20);
			RuleFor(s => s.Password)
				.NotEmpty()
				.MinimumLength(4);
		}
	}
}
