using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PitochokPlague.Extensions;
using PitochokPlague.Infrastructure;
using PitochokPlague.Infrastructure.Extensions;
using PitochokPlague.Infrastructure.Patients;
using PitochokPlague.Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureStaticSettings();
builder.Services.AddInfrastructure(builder.Configuration.GetSection("InfrastructureSettings")
    .Get<InfrastructureSettings>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pitochok Plague API",
        Description = "Make ISU Greate Again",
        Version = "v1"
    });
});


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pitochok Plague API V1"); });

var patientsApi = app.MapGroup("/patients");
var resistantsApi = app.MapGroup("/resistants");

patientsApi.MapPost("",
    async (IPatientRepository repository, IUnitOfWork unitOfWork, PatientRequest request,
        CancellationToken cancellationToken) =>
    {
        await repository.AddAsync(request, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);
        return Results.Ok();
    });
resistantsApi.MapGet("", async (PitochokPlagueContext context, CancellationToken cancellationToken) =>
{
    var resistantCollection = await context.Resistants.AsQueryable().ToArrayAsync(cancellationToken);
    return Results.Ok(resistantCollection);
});


await app.ApplyMigrationsAsync();
app.Run();

public sealed record PatientRequest(int СontagiousIsu, int InfectedIsu);