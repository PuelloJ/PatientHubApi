using Microsoft.EntityFrameworkCore;
using PatientHubApi.Infrastructure.Data;
using PatientHubApi.Infrastructure.Repositories;
using PatientHubApi.Application.Services;
using PatientHubApi.Application.DTOs;
using PatientHubApi.Application.Models;

namespace PatientHubApi.Test
{
    public class PatientServiceTests
    {
        private readonly ApplicationDbContext _context;
        private readonly PatientService _patientService;

        public PatientServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationDbContext(options);
            var repository = new PatientRepository(_context);
            _patientService = new PatientService(repository);
        }

        [Fact]
        public async Task CreatePatient_ShouldCreatePatient_WhenValidData()
        {
            // Arrange
            var createPatientDto = new CreatePatientDto
            {
                DocumentType = "DNI",
                DocumentNumber = "12345678",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1990, 1, 1)
            };

            // Act
            var result = await _patientService.CreatePatientAsync(createPatientDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Doe", result.LastName);
        }

        [Fact]
        public async Task CreatePatient_ShouldThrowException_WhenDuplicateDocument()
        {
            // Arrange
            var createPatientDto1 = new CreatePatientDto
            {
                DocumentType = "DNI",
                DocumentNumber = "12345678",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1990, 1, 1)
            };

            var createPatientDto2 = new CreatePatientDto
            {
                DocumentType = "DNI",
                DocumentNumber = "12345678",
                FirstName = "Jane",
                LastName = "Smith",
                BirthDate = new DateTime(1991, 1, 1)
            };

            // Act & Assert
            await _patientService.CreatePatientAsync(createPatientDto1);
            await Assert.ThrowsAsync<ArgumentException>(
                () => _patientService.CreatePatientAsync(createPatientDto2));
        }

        [Fact]
        public async Task GetPatientById_ShouldReturnPatient_WhenExists()
        {
            // Arrange
            var createPatientDto = new CreatePatientDto
            {
                DocumentType = "DNI",
                DocumentNumber = "12345678",
                FirstName = "John",
                LastName = "Doe",
                BirthDate = new DateTime(1990, 1, 1)
            };

            var createdPatient = await _patientService.CreatePatientAsync(createPatientDto);

            // Act
            var result = await _patientService.GetPatientByIdAsync(createdPatient.PatientId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdPatient.PatientId, result.PatientId);
        }

        [Fact]
        public async Task GetPatients_ShouldReturnPagedResults()
        {
            // Arrange
            for (int i = 1; i <= 15; i++)
            {
                var createPatientDto = new CreatePatientDto
                {
                    DocumentType = "DNI",
                    DocumentNumber = $"1234567{i}",
                    FirstName = $"Patient{i}",
                    LastName = "Test",
                    BirthDate = new DateTime(1990, 1, 1)
                };
                await _patientService.CreatePatientAsync(createPatientDto);
            }

            var queryParameters = new PatientQueryParameters { Page = 1, PageSize = 10 };

            // Act
            var result = await _patientService.GetPatientsAsync(queryParameters);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(10, result.Items.Count());
            Assert.Equal(15, result.TotalCount);
            Assert.Equal(2, result.TotalPages);
        }
    }
}