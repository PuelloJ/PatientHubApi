using Microsoft.EntityFrameworkCore;

// Core
using PatientHubApi.Core.Entities;
using MedicalPatients.Core.Interfaces;

// Application
using PatientHubApi.Application.Models;

// Infrastructure
using PatientHubApi.Infrastructure.Data;

namespace PatientHubApi.Infrastructure.Repositories

{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<PagedResult<Patient>> GetPagedAsync(PatientQueryParameters queryParameters)
        {
            var query = _context.Patients.AsQueryable();

            // Apply filters
            if (!string.IsNullOrEmpty(queryParameters.Name))
            {
                query = query.Where(p => p.FirstName.Contains(queryParameters.Name) || 
                                        p.LastName.Contains(queryParameters.Name));
            }

            if (!string.IsNullOrEmpty(queryParameters.DocumentNumber))
            {
                query = query.Where(p => p.DocumentNumber == queryParameters.DocumentNumber);
            }

            var totalCount = await query.CountAsync();

            var patients = await query
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName)
                .Skip((queryParameters.Page - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .ToListAsync();

            return new PagedResult<Patient>
            {
                Items = patients,
                TotalCount = totalCount,
                Page = queryParameters.Page,
                PageSize = queryParameters.PageSize
            };
        }

        public async Task<Patient> AddAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<bool> UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
                return false;

            _context.Patients.Remove(patient);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExistsAsync(string documentType, string documentNumber, int? excludePatientId = null)
        {
            var query = _context.Patients
                .Where(p => p.DocumentType == documentType && p.DocumentNumber == documentNumber);

            if (excludePatientId.HasValue)
            {
                query = query.Where(p => p.PatientId != excludePatientId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatientsCreatedAfterAsync(DateTime date)
        {
            return await _context.Patients
                .FromSqlRaw("EXEC GetPatientsCreatedAfter @DateCreated = {0}", date)
                .ToListAsync();
        }
    }
}