using System;
using System.Text;
using RCALogBuilder.Models;

namespace RCALogBuilder.Services
{
    public class MarkdownExporter : IMarkdownExporter
    {
        public string GenerateMarkdown(IncidentReport report)
        {
            if (report == null) throw new ArgumentNullException(nameof(report));

            var sb = new StringBuilder();

            sb.AppendLine("# Incident Post-Mortem & RCA");
            sb.AppendLine();
            sb.AppendLine("## Summary");
            sb.AppendLine();
            sb.AppendLine($"- **Downtime start:** {report.DowntimeStart:yyyy-MM-dd HH:mm:ss} (local)");
            sb.AppendLine($"- **Services affected:** {Escape(report.ServicesAffected)}");
            sb.AppendLine($"- **Trigger:** {Escape(report.Trigger)}");
            sb.AppendLine();
            sb.AppendLine("## Timeline");
            sb.AppendLine();
            sb.AppendLine(string.IsNullOrWhiteSpace(report.Timeline) ? "_No timeline provided._" : EscapeMultiline(report.Timeline));
            sb.AppendLine();
            sb.AppendLine("## Detection & Containment");
            sb.AppendLine();
            var detCon = CombineSections(report.Detection, report.Containment);
            sb.AppendLine(string.IsNullOrWhiteSpace(detCon) ? "_No detection/containment details provided._" : EscapeMultiline(detCon));
            sb.AppendLine();
            sb.AppendLine("## Root Cause Analysis");
            sb.AppendLine();
            sb.AppendLine(string.IsNullOrWhiteSpace(report.RootCause) ? "_No root cause provided._" : EscapeMultiline(report.RootCause));
            sb.AppendLine();
            sb.AppendLine("## Prevention & Action Items");
            sb.AppendLine();
            var preventionPlus = CombineSections(report.Prevention, report.Resolution);
            sb.AppendLine(string.IsNullOrWhiteSpace(preventionPlus) ? "_No prevention/action items provided._" : EscapeMultiline(preventionPlus));
            sb.AppendLine();

            return sb.ToString();
        }

        private static string Escape(string input)
        {
            return string.IsNullOrEmpty(input) ? string.Empty : input.Trim();
        }

        private static string EscapeMultiline(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            // Preserve paragraphs and simple Markdown-friendly formatting
            return input.Trim().Replace("\r\n", "\n").Replace("\n", "\n\n");
        }

        private static string CombineSections(params string[] parts)
        {
            var sb = new StringBuilder();
            foreach (var p in parts)
            {
                if (!string.IsNullOrWhiteSpace(p))
                {
                    if (sb.Length > 0) sb.AppendLine().AppendLine();
                    sb.Append(p.Trim());
                }
            }
            return sb.ToString();
        }
    }
}
