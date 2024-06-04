using DicomWebApp.Web.Models;

namespace DicomWebApp.Web.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> GetPatientById(int id);

        bool Add(Patient patient);
        bool Update(Patient patient);
        bool Delete(Patient patient);
        bool Save();
    }
}
