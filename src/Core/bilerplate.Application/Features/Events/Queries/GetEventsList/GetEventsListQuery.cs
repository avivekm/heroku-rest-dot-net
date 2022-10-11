using bilerplate.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace bilerplate.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery: IRequest<Response<IEnumerable<EventListVm>>>
    {

    }
}
