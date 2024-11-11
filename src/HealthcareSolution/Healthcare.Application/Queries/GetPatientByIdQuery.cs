using Healthcare.Application.Interfaces;
using Healthcare.Domain.Entities;

namespace Healthcare.API
{
    public interface IQuery<T>
    {
        Task<T> ExecuteAsync();
    }

    public class GetPatientByIdQuery : IQuery<Patient>
    {
        private readonly IPatientRepository _repository;
        private readonly int _patientId;

        public GetPatientByIdQuery(IPatientRepository repository, int patientId)
        {
            _repository = repository;
            _patientId = patientId;
        }

        public async Task<Patient> ExecuteAsync() { return await _repository.GetByIdAsync(_patientId); }
    }

}