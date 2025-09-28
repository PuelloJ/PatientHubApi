using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientHubApi.Infrastructure.Data;

namespace PatientHubApi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeedController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<SeedController> _logger;

    public SeedController(ApplicationDbContext context, ILogger<SeedController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpPost("patients")]
    public async Task<IActionResult> SeedPatients()
    {
        try
        {
            // Verificar si ya existen pacientes en la base de datos
            var existingPatientsCount = await _context.Patients.CountAsync();
            
            if (existingPatientsCount > 0)
            {
                return BadRequest(new
                {
                    message = "La base de datos ya contiene pacientes. Use el endpoint de limpieza primero si desea reemplazar los datos.",
                    existingRecords = existingPatientsCount
                });
            }

            // Obtener los datos de seed
            var seedPatients = PatientSeed.GetSeedData();

            // Verificar duplicados por documento antes de insertar
            var documentNumbers = seedPatients.Select(p => p.DocumentNumber).ToList();
            var existingDocuments = await _context.Patients
                .Where(p => documentNumbers.Contains(p.DocumentNumber))
                .Select(p => new { p.DocumentType, p.DocumentNumber })
                .ToListAsync();

            if (existingDocuments.Any())
            {
                return BadRequest(new
                {
                    message = "Algunos documentos ya existen en la base de datos",
                    duplicateDocuments = existingDocuments
                });
            }

            // Insertar los datos
            await _context.Patients.AddRangeAsync(seedPatients);
            var recordsInserted = await _context.SaveChangesAsync();

            _logger.LogInformation("Se insertaron {RecordsCount} pacientes de prueba", recordsInserted);

            return Ok(new
            {
                message = "Datos de prueba insertados exitosamente",
                recordsInserted = recordsInserted,
                summary = new
                {
                    RC = seedPatients.Count(p => p.DocumentType == "RC"),
                    TI = seedPatients.Count(p => p.DocumentType == "TI"),
                    CC = seedPatients.Count(p => p.DocumentType == "CC"),
                    CE = seedPatients.Count(p => p.DocumentType == "CE"),
                    PA = seedPatients.Count(p => p.DocumentType == "PA")
                }
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al insertar datos de prueba");
            return StatusCode(500, new
            {
                message = "Error interno del servidor al insertar datos de prueba",
                error = ex.Message
            });
        }
    }

    [HttpDelete("patients/clear")]
    public async Task<IActionResult> ClearPatients()
    {
        try
        {
            var patientsCount = await _context.Patients.CountAsync();
            
            if (patientsCount == 0)
            {
                return Ok(new
                {
                    message = "La base de datos ya está vacía",
                    recordsDeleted = 0
                });
            }

            // Eliminar todos los pacientes
            var allPatients = await _context.Patients.ToListAsync();
            _context.Patients.RemoveRange(allPatients);
            var recordsDeleted = await _context.SaveChangesAsync();

            _logger.LogInformation("Se eliminaron {RecordsCount} pacientes", recordsDeleted);

            return Ok(new
            {
                message = "Todos los pacientes han sido eliminados exitosamente",
                recordsDeleted = recordsDeleted
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al eliminar pacientes");
            return StatusCode(500, new
            {
                message = "Error interno del servidor al eliminar pacientes",
                error = ex.Message
            });
        }
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetDatabaseStats()
    {
        try
        {
            var stats = await _context.Patients
                .GroupBy(p => p.DocumentType)
                .Select(g => new
                {
                    DocumentType = g.Key,
                    Count = g.Count(),
                    AverageAge = g.Average(p => DateTime.Now.Year - p.BirthDate.Year)
                })
                .ToListAsync();

            var totalPatients = await _context.Patients.CountAsync();

            return Ok(new
            {
                totalPatients = totalPatients,
                byDocumentType = stats,
                lastUpdate = DateTime.UtcNow
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error al obtener estadísticas");
            return StatusCode(500, new
            {
                message = "Error interno del servidor al obtener estadísticas",
                error = ex.Message
            });
        }
    }
}