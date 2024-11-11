using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Application.Interfaces
{
    public interface IUnitOfWork
    {
        // Define properties for each repository
        IPatientRepository Patients { get; }
        //IAppointmentRepository Appointments { get; }

        // Method to commit changes
        Task<int> CompleteAsync();
    }
}
