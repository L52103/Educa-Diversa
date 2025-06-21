using Microsoft.EntityFrameworkCore;
using ApiPostgre.Data;
using ApiPostgre.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.MapGet("/personas", async (AppDbContext db) =>
    await db.Personas.ToListAsync()
);

app.MapGet("/personas/{id}", async (int id, AppDbContext db) =>
    await db.Personas.FindAsync(id)
        is Persona persona
            ? Results.Ok(persona)
            : Results.NotFound()
);

app.MapPost("/personas", async (Persona persona, AppDbContext db) =>
{
    db.Personas.Add(persona);
    await db.SaveChangesAsync();
    return Results.Created($"/personas/{persona.Codigo}", persona);
});

app.MapPut("/personas/{id}", async (int id, Persona input, AppDbContext db) =>
{
    var persona = await db.Personas.FindAsync(id);
    if (persona is null) return Results.NotFound();

    persona.Nombre = input.Nombre;
    persona.ApellidoPaterno = input.ApellidoPaterno;
    persona.ApellidoMaterno = input.ApellidoMaterno;
    persona.FechaNacimiento = input.FechaNacimiento;
    persona.Sexo = input.Sexo;
    persona.Rut = input.Rut;
    persona.Vigencia = input.Vigencia;

    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/personas/{id}", async (int id, AppDbContext db) =>
{
    var persona = await db.Personas.FindAsync(id);
    if (persona is null) return Results.NotFound();

    db.Personas.Remove(persona);
    await db.SaveChangesAsync();
    return Results.Ok(persona);
});

app.Run();
