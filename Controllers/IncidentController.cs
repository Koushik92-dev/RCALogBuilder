using System.Text;
using Microsoft.AspNetCore.Mvc;
using RCALogBuilder.Models;
using RCALogBuilder.Services;

namespace RCALogBuilder.Controllers
{
    public class IncidentController : Controller
    {
        private readonly IMarkdownExporter _markdownExporter;

        public IncidentController(IMarkdownExporter markdownExporter)
        {
            _markdownExporter = markdownExporter;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new IncidentReport
            {
                DowntimeStart = System.DateTime.Now
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExportMarkdown(IncidentReport report)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", report);
            }

            var markdown = _markdownExporter.GenerateMarkdown(report);
            var bytes = Encoding.UTF8.GetBytes(markdown);
            return File(bytes, "text/markdown; charset=utf-8", "incident-report.md");
        }
    }
}
