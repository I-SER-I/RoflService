namespace PitochokPlague.Infrastructure.Patients;

public interface IPatientRepository
{
    Task AddAsync(PatientRequest patient, CancellationToken cancellationToken);
}