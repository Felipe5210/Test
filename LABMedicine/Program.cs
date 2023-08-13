using LABMedicine.Data.Repositories;
using LABMedicine.Domain.Interfaces;
using LABMedicine.Domain.Services;
using LABMedicine.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<labmedicineDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LabClothingCollectionString")));

builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();

builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();

builder.Services.AddScoped<IEnfermeiroService, EnfermeiroService>();
builder.Services.AddScoped<IEnfermeiroRepository, ModeloRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
