using DicomWebApp.Models.Data;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DicomWebApp.Web.Controllers
{
    public class PatientsController : Controller
    {
        private readonly MyDicomContext _context;
        public PatientsController(MyDicomContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View();
        }


    }
}
