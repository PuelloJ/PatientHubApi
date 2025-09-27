
// Application
using MedicalPatients.Application.Interfaces;
using PatientHubApi.Application.DTOs;

// Core
using MedicalPatients.Core.Interfaces;
using PatientHubApi.Core.Entities;
using PatientHubApi.Application.Models;


namespace PatientHubApi.Application.Services;

public class PatientService : IPatientService
{

    private readonly IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<PatientDto> CreatePatientAsync(CreatePatientDto createPatientDto)
    {
        if (await _patientRepository.ExistsAsync(createPatientDto.DocumentType, createPatientDto.DocumentNumber))
        {
            throw new ArgumentException("A patient with the same document type and number already exists.");
        }
        var patient = new Patient()
        {
            DocumentType = createPatientDto.DocumentType,
            DocumentNumber = createPatientDto.DocumentNumber,
            FirstName = createPatientDto.FirstName,
            LastName = createPatientDto.LastName,
            BirthDate = createPatientDto.BirthDate,
            PhoneNumber = createPatientDto.PhoneNumber,
            Email = createPatientDto.Email
        };

        var createPatient = await _patientRepository.AddAsync(patient);

        return MapToDto(createPatient);
    }

    public async Task<PagedResult<PatientDto>> GetPatientsAsync(PatientQueryParameters queryParameters)
    {
        var pagedResult = await _patientRepository.GetPagedAsync(queryParameters);

        return new PagedResult<PatientDto>
        {
            Items = pagedResult.Items.Select(MapToDto),
            TotalCount = pagedResult.TotalCount,
            Page = pagedResult.Page,
            PageSize = pagedResult.PageSize
        };
    }

    public async Task<PatientDto?> GetPatientByIdAsync(int id)
    {
        var patient = await _patientRepository.GetByIdAsync(id);
        return patient == null ? null : MapToDto(patient);
    }

    public async Task<bool> UpdatePatientAsync(UpdatePatientDto updatePatientDto)
    {
        if (await _patientRepository.ExistsAsync(
            updatePatientDto.DocumentType,
            updatePatientDto.DocumentNumber,
            updatePatientDto.PatientId))
        {
            throw new InvalidOperationException("Another patient with the same document type and number already exists.");
        }

        var existingPatient = await _patientRepository.GetByIdAsync(updatePatientDto.PatientId);
        if (existingPatient == null)
        {
            return false;
        }

        existingPatient.DocumentType = updatePatientDto.DocumentType;
        existingPatient.DocumentNumber = updatePatientDto.DocumentNumber;
        existingPatient.FirstName = updatePatientDto.FirstName;
        existingPatient.LastName = updatePatientDto.LastName;
        existingPatient.BirthDate = updatePatientDto.BirthDate;
        existingPatient.PhoneNumber = updatePatientDto.PhoneNumber;
        existingPatient.Email = updatePatientDto.Email;

        return await _patientRepository.UpdateAsync(existingPatient);
    }

    public async Task<bool> DeletePatientAsync(int id)
    {
        return await _patientRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<PatientDto>> GetPatientsCreatedAfterAsync(DateTime date)
    {
        var patients = await _patientRepository.GetPatientsCreatedAfterAsync(date);
        return patients.Select(MapToDto);
    }

    private static PatientDto MapToDto(Patient patient)
    {
        return new PatientDto
        {
            PatientId = patient.PatientId,
            DocumentType = patient.DocumentType,
            DocumentNumber = patient.DocumentNumber,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            BirthDate = patient.BirthDate,
            PhoneNumber = patient.PhoneNumber,
            Email = patient.Email,
            CreatedAt = patient.CreatedAt
        };
    }

}
