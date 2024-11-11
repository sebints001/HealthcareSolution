namespace Healthcare.Application
{
    public class PatientNotFoundException : Exception
    {
        public PatientNotFoundException(int patientId)
            : base($"Patient with ID {patientId} was not found.")
        {
        }
    }
}