using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomWebApp.Models.Models
{
    internal class Series
    {
        public int SeriesId { get; set; }
        public string SeriesInstanceUID { get; set; }
        public int StudyId { get; set; }
        public Study Study { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
