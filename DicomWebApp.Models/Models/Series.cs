using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomWebApp.Models.Models
{
    public class Series
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SeriesInstanceUID { get; set; }

        [Required]
        public int StudyId { get; set; }

        [ForeignKey("StudyId")]
        public Study Study { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
