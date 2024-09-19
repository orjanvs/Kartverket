using System.ComponentModel.DataAnnotations;

namespace Kartverket.Models
{
    public class FaultReportModel
    {

        [Key]
        public int ReportId { get; set; }

        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
