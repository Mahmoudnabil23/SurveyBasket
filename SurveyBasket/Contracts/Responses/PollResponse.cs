namespace SurveyBasket.Contracts.Responses;

public class PollResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Desc { get; set; } = string.Empty;
}
