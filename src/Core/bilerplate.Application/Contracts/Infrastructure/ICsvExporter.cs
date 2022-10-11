using bilerplate.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace bilerplate.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos);
    }
}
