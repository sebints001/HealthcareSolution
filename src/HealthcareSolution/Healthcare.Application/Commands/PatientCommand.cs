using Healthcare.Application;
using Healthcare.Application.Services;
using Healthcare.Domain;

namespace Healthcare.API
{
    public interface ICommand
    {
        Task ExecuteAsync();
    }

    public class UpdatePatientCommand : ICommand
    {
        private readonly PatientService _service;
        private readonly PatientDto _patient;

        public UpdatePatientCommand(PatientService service, PatientDto patient)
        {
            _service = service;
            _patient = patient;
        }

        public async Task ExecuteAsync() { await _service.UpdatePatientAsync(_patient.Id, _patient); }
    }

}