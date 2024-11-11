// Healthcare.Application/Services/PatientService.cs
using Healthcare.Application.Interfaces;
using Healthcare.API;
using Healthcare.Domain.Entities;

namespace Healthcare.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeletePatientAsync(int id)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            if (patient == null) throw new Exception("Patient not found");

            _unitOfWork.Patients.DeleteAsync(patient.Id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientsAsync()
        {
            var patients = await _unitOfWork.Patients.GetAllAsync();
            return patients.Select(patient => new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth
            });
        }

        public async Task<PatientDto> GetPatientByIdAsync(int id)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            if (patient == null) throw new Exception("Patient not found");

            return new PatientDto
            {
                Id = patient.Id,
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth
            };
        }

        // Adds a new patient and commits the transaction
        public async Task AddPatientAsync(PatientDto patientModel)
        {
            // Convert model to domain entity
            var patient = new Patient
            {
                Name = patientModel.Name,
                Age = patientModel.Age,
                // Other properties...
            };

            // Use the repository through the UnitOfWork to add the patient
            await _unitOfWork.Patients.AddAsync(patient);

            // Commit changes in a single transaction
            await _unitOfWork.CompleteAsync();
        }

        // Updates an existing patient and commits the transaction
        public async Task UpdatePatientAsync(int patientId, PatientDto patientModel)
        {
            // Fetch existing patient
            var patient = await _unitOfWork.Patients.GetByIdAsync(patientId);

            // Update properties
            patient.Name = patientModel.Name;
            patient.Age = patientModel.Age;

            // Save changes and commit transaction
            await _unitOfWork.CompleteAsync();
        }



        // Other service methods (AddPatientAsync, UpdatePatientAsync, DeletePatientAsync) follow
    }
}
