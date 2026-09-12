using System;
using System.ComponentModel.DataAnnotations;

namespace RCALogBuilder.Models
{
    public class IncidentReport
    {
        [Required]
        [Display(Name = "Downtime Start")]
        public DateTime DowntimeStart { get; set; }

        [Required]
        [Display(Name = "Services Affected")]
        public string ServicesAffected { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Root Cause")]
        public string RootCause { get; set; } = string.Empty;

        [Display(Name = "Resolution")]
        public string Resolution { get; set; } = string.Empty;

        [Display(Name = "Timeline")]
        public string Timeline { get; set; } = string.Empty;

        [Display(Name = "Trigger")]
        public string Trigger { get; set; } = string.Empty;

        [Display(Name = "Detection")]
        public string Detection { get; set; } = string.Empty;

        [Display(Name = "Containment")]
        public string Containment { get; set; } = string.Empty;

        [Display(Name = "Prevention")]
        public string Prevention { get; set; } = string.Empty;
    }
}
