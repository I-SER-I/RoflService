using Microsoft.EntityFrameworkCore;

namespace PitochokPlague.Infrastructure.Patients;


public sealed class PatientRepository : IPatientRepository
{
    private readonly DbSet<PatientModel> _patientsDbSet;
    private readonly IQueryable<ResistantModel> _resistantsQueriable;
    private readonly IQueryable<PatientModel> _patientsQueriable;

    public PatientRepository(PitochokPlagueContext context)
    {
        _patientsDbSet = context.Patients;
        _resistantsQueriable = context.Resistants.AsQueryable();
        _patientsQueriable = context.Patients.AsQueryable();
    }

    public async Task AddAsync(PatientRequest request, CancellationToken cancellationToken)
    {
        var resistant = await _resistantsQueriable
            .FirstOrDefaultAsync(resistant => resistant.Isu == request.InfectedIsu, cancellationToken);
        var patient = await _patientsQueriable
            .FirstOrDefaultAsync(patient => patient.Isu == request.InfectedIsu, cancellationToken);
        
        if (resistant is null && patient is null)
        {
            await _patientsDbSet.AddAsync(new PatientModel
            {
                Isu = request.InfectedIsu,
                CarrierIsu = request.СontagiousIsu,
                IncubationTime = DateTime.UtcNow
            }, cancellationToken);
        }
    }
}