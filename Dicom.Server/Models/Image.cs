using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomWebApp.Web.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SOPInstanceUID { get; set; }

        [Required]
        public int SeriesId { get; set; }

        [ForeignKey("SeriesId")]
        public Series Series { get; set; }

        public string FilePath { get; set; }
    }
}
 