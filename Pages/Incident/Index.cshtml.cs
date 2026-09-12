using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RCALogBuilder.Models;
using RCALogBuilder.Services;
using System.Text;

namespace RCALogBuilder.Pages.Incident
{
    public class IndexModel : PageModel
    {
        private readonly IMarkdownExporter _markdownExporter;

        public IndexModel(IMarkdownExporter markdownExporter)
        {
            _markdownExporter = markdownExporter;
            Incident = new IncidentReport { DowntimeStart = System.DateTime.Now };
        }

        [BindProperty]
        public IncidentReport Incident { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostExportMarkdown()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var md = _markdownExporter.GenerateMarkdown(Incident);
            var bytes = Encoding.UTF8.GetBytes(md);
            return File(bytes, "text/markdown; charset=utf-8", "incident-report.md");
        }
    }
}
