
using DicomWebApp.Web.Models;
using DicomWebApp.Web.Interfaces;
using Microsoft.EntityFrameworkCore;
using DicomWebApp.Web.Data;

namespace DicomWebApp.Web.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MyDicomContext _context;
        public PatientRepository(MyDicomContext context)
        {
            _context = context;
        }
        public bool Add(Patient patient)
        {
            _context.Add(patient);
            return Save();
        }

        public bool Delete(Patient patient)
        {
            _context.Remove(patient);
            return Save();
        }

        public async Task<IEnumerable<Patient>> GetAllPatients()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Patient patient)
        {
            _context.Update(patient);
            return Save();
        }
    }
}
