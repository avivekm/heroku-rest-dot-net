using MediatR;

namespace bilerplate.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQuery: IRequest<EventExportFileVm>
    {
    }
}
