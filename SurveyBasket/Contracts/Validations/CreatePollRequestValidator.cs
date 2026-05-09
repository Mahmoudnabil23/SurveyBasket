using FluentValidation;

namespace SurveyBasket.Contracts.Validations;

public class CreatePollRequestValidator : AbstractValidator<CreatePollRequest>
{
    public CreatePollRequestValidator()
    {
        RuleFor(poll => poll.Title)
            .NotEmpty();
    }
}
