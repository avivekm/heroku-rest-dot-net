using bilerplate.Application.Features.Events.Queries.GetEventsExport;
using bilerplate.Infrastructure.FileExport;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace bilerplate.Infrastructure.UnitTests.FileExport
{
    public class CsvExporterTests
    {
        [Fact]
        public void ExportEventsToCsv()
        {
            var exporter = new CsvExporter();

            var result = exporter.ExportEventsToCsv(new List<EventExportDto>());

            result.ShouldNotBeNull();
            result.ShouldBeOfType<byte[]>();
        }
    }
}
