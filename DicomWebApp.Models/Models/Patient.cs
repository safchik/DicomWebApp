using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomWebApp.Models.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PatientID { get; set; }

        public string Name { get; set; }

        public DateTime? BirthDate { get; set; }

        public ICollection<Study> Studies { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
