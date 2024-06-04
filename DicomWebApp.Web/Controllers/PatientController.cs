﻿using DicomWebApp.Models.Data;
using DicomWebApp.Models.Models;
using DicomWebApp.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DicomWebApp.Web.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientRepository _patientRepository;
        public PatientsController(MyDicomContext context, IPatientRepository patientRepository)
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
