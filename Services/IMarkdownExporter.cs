using RCALogBuilder.Models;

namespace RCALogBuilder.Services
{
    public interface IMarkdownExporter
    {
        string GenerateMarkdown(IncidentReport report);
    }
}
