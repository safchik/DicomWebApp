
using DicomWebApp.Web.Models;
using DicomWebApp.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace DicomWebApp.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Patient> patients = await _patientRepository.GetAllPatients();
            return View(patients);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Patient patient = await _patientRepository.GetPatientById(id);
            return View(patient);
        }
    }
}
