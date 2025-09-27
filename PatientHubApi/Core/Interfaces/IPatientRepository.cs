
// Application
using PatientHubApi.Application.Models;

// Core
using PatientHubApi.Core.Entities;

namespace MedicalPatients.Core.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient> GetByIdAsync(int id);
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<PagedResult<Patient>> GetPagedAsync(PatientQueryParameters queryParameters);
        Task<Patient> AddAsync(Patient patient);
        Task<bool> UpdateAsync(Patient patient);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(string documentType, string documentNumber, int? excludePatientId = null);
        Task<IEnumerable<Patient>> GetPatientsCreatedAfterAsync(DateTime date);
    }
}