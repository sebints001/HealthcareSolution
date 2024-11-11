// Healthcare.Infrastructure/UnitOfWork/UnitOfWork.cs
using Healthcare.Application.Interfaces;
using Healthcare.DataAccess.Repositories;
using Healthcare.DataAccess.Data;
using System;
using System.Threading.Tasks;

namespace Healthcare.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HealthcareDbContext _context;

        public UnitOfWork(HealthcareDbContext context)
        {
            _context = context;
            Patients = new PatientRepository(_context); // Here we create the actual repository
        }

        public IPatientRepository Patients { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
