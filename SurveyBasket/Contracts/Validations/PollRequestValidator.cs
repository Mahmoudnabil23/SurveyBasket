namespace SurveyBasket.Contracts.Validations;

public class PollRequestValidator : AbstractValidator<PollRequest>
{
    public PollRequestValidator()
    {
        RuleFor(poll => poll.Title)
            .NotEmpty()
            .Length(3, 100);
        RuleFor(poll => poll.Description)
            .NotEmpty()
            .Length(3, 1500);
        RuleFor(poll => poll.StartsAt)
            .NotEmpty()
            .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today));
        RuleFor(poll => poll.EndsAt)
            .NotEmpty();
        RuleFor(poll => poll)
            .Must(BeValidEndDate)
            .WithName(nameof(PollRequest.EndsAt))
            .WithMessage("{PropertyName} must be greater than or equal to starts at");

    }

    private bool BeValidEndDate(PollRequest pollRequest)
    {
        return pollRequest.StartsAt <= pollRequest.EndsAt;
    }
}
