
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DicomWebApp.Web.Models
{
    public class Study
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StudyInstanceUID { get; set; }

        [Required]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        public ICollection<Series> Series { get; set; }

    }
}
