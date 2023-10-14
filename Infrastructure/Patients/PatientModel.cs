namespace PitochokPlague.Infrastructure.Patients;

public sealed class PatientModel
{
    public int Isu { get; set; }
    public int CarrierIsu { get; set; }
    public DateTime IncubationTime { get; set; }
}