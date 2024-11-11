namespace Healthcare.Application.Services
{
    public interface IPatientService
    {
        Task<PatientDto> GetPatientByIdAsync(int id);
        Task<IEnumerable<PatientDto>> GetAllPatientsAsync();
        Task AddPatientAsync(PatientDto patientDto);
        Task UpdatePatientAsync(int id, PatientDto patientDto);
        Task DeletePatientAsync(int id);
    }
}