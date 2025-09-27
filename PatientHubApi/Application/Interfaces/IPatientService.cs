

using PatientHubApi.Application.DTOs;
using PatientHubApi.Application.Models;

namespace MedicalPatients.Application.Interfaces;

public interface IPatientService
{
    Task<PatientDto> CreatePatientAsync(CreatePatientDto createPatientDto);
    Task<PagedResult<PatientDto>> GetPatientsAsync(PatientQueryParameters queryParameters);
    Task<PatientDto?> GetPatientByIdAsync(int id);
    Task<bool> UpdatePatientAsync(UpdatePatientDto updatePatientDto);
    Task<bool> DeletePatientAsync(int id);
    Task<IEnumerable<PatientDto>> GetPatientsCreatedAfterAsync(DateTime date);
}
