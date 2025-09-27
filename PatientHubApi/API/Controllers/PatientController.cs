using Microsoft.AspNetCore.Mvc;

// Application
using MedicalPatients.Application.Interfaces;
using PatientHubApi.Application.DTOs;
using PatientHubApi.Application.Models;

namespace PatientHubApi.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {

        private readonly IPatientService _patientService;

        public PatientController(IPatientService patienService)
        {
            _patientService = patienService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<PatientDto>>> GetPatients([FromQuery] PatientQueryParameters queryParameters)
        {
            var patients = await _patientService.GetPatientsAsync(queryParameters);
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatient(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult<PatientDto>> CreatePatient([FromBody] CreatePatientDto createPatientDto)
        {
            var patient = await _patientService.CreatePatientAsync(createPatientDto);
            return CreatedAtAction(nameof(GetPatient), new { id = patient.PatientId }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] UpdatePatientDto updatePatientDto)
        {
            if (id != updatePatientDto.PatientId)
            {
                return BadRequest("Patient ID mismatch");
            }

            var result = await _patientService.UpdatePatientAsync(updatePatientDto);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var result = await _patientService.DeletePatientAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("created-after")]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatientsCreatedAfter([FromQuery] DateTime date)
        {
            var patients = await _patientService.GetPatientsCreatedAfterAsync(date);
            return Ok(patients);
        }

    }

}