using Healthcare.Application;
using Healthcare.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePatient([FromBody] PatientDto patientDto)
        {
            await _patientService.AddPatientAsync(patientDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePatient(int id, [FromBody] PatientDto patientDto)
        {
            await _patientService.UpdatePatientAsync(id, patientDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            await _patientService.DeletePatientAsync(id);
            return NoContent();
        }
    }
}