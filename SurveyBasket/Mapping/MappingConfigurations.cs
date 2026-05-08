using Mapster;
using SurveyBasket.Contracts.Responses;

namespace SurveyBasket.Mapping;

public class MappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Poll, PollResponse>()
            .Map(dest => dest.Desc, src => src.Description);
    }
}
