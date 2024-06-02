using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomWebApp.Models.Models
{
    internal class Image
    {
        public int ImageId { get; set; }
        public string SOPInstanceUID { get; set; }
        public int SeriesId { get; set; }
        public Series Series { get; set; }
    }
}
