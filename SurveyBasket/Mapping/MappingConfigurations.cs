namespace SurveyBasket.Mapping;

public class MappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Poll, PollResponse>()
            .Map(dest => dest.Description, src => src.Summary);
        config.NewConfig<CreatePollRequest, Poll>()
            .Map(dest => dest.Summary, src => src.Description);
    }
}
