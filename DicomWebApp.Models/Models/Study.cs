using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomWebApp.Models.Models
{
    internal class Study
    {
        public int StudyId { get; set; }
        public string StudyInstanceUID { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public ICollection<Series> Series { get; set; }

    }
}
