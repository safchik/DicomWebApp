using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomWebApp.Models.Models
{
    internal class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set;}
        public DateTime DateOfBirth { get; set; }
        public ICollection<Study> Studies { get; set; }
    }
}
