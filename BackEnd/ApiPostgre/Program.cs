using Microsoft.EntityFrameworkCore;
using ApiPostgre.Data;
using ApiPostgre.Models;
using Microsoft.AspNetCore.Builder;
using ApiPostgre.Services; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthService, AuthService>();

//  AGREGAR SERVICIOS CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials(); // Importante para autenticación y cookies/tokens
        });
});
//-

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();


app.UseCors("AllowAngularApp");


#region CRUD Categoria
app.MapGet("/categorias", async (AppDbContext db) => await db.Categorias.ToListAsync());
app.MapGet("/categorias/{id}", async (int id, AppDbContext db) => await db.Categorias.FindAsync(id));
app.MapPost("/categorias", async (Categoria c, AppDbContext db) =>
{
    db.Categorias.Add(c);
    await db.SaveChangesAsync();
    return Results.Created($"/categorias/{c.Codigo}", c);
});
app.MapPut("/categorias/{id}", async (int id, Categoria input, AppDbContext db) =>
{
    var categoria = await db.Categorias.FindAsync(id);
    if (categoria is null) return Results.NotFound();
    db.Entry(categoria).CurrentValues.SetValues(input);
    await db.SaveChangesAsync();
    return Results.Ok(categoria);
});
app.MapDelete("/categorias/{id}", async (int id, AppDbContext db) =>
{
    var categoria = await db.Categorias.FindAsync(id);
    if (categoria is null) return Results.NotFound();
    db.Categorias.Remove(categoria);
    await db.SaveChangesAsync();
    return Results.Ok();
});
#endregion

#region CRUD Foro
app.MapGet("/foros", async (AppDbContext db) => await db.Foros.ToListAsync());
app.MapGet("/foros/{id}", async (int id, AppDbContext db) => await db.Foros.FindAsync(id));
app.MapPost("/foros", async (Foro f, AppDbContext db) =>
{
    db.Foros.Add(f);
    await db.SaveChangesAsync();
    return Results.Created($"/foros/{f.Codigo}", f);
});
app.MapPut("/foros/{id}", async (int id, Foro input, AppDbContext db) =>
{
    var foro = await db.Foros.FindAsync(id);
    if (foro is null) return Results.NotFound();
    db.Entry(foro).CurrentValues.SetValues(input);
    await db.SaveChangesAsync();
    return Results.Ok(foro);
});
app.MapDelete("/foros/{id}", async (int id, AppDbContext db) =>
{
    var foro = await db.Foros.FindAsync(id);
    if (foro is null) return Results.NotFound();
    db.Foros.Remove(foro);
    await db.SaveChangesAsync();
    return Results.Ok();
});
#endregion

#region CRUD Modulo
app.MapGet("/modulos", async (AppDbContext db) => await db.Modulos.ToListAsync());
app.MapGet("/modulos/{id}", async (int id, AppDbContext db) => await db.Modulos.FindAsync(id));
app.MapPost("/modulos", async (Modulo m, AppDbContext db) =>
{
    db.Modulos.Add(m);
    await db.SaveChangesAsync();
    return Results.Created($"/modulos/{m.Codigo}", m);
});
app.MapPut("/modulos/{id}", async (int id, Modulo input, AppDbContext db) =>
{
    var modulo = await db.Modulos.FindAsync(id);
    if (modulo is null) return Results.NotFound();
    db.Entry(modulo).CurrentValues.SetValues(input);
    await db.SaveChangesAsync();
    return Results.Ok(modulo);
});
app.MapDelete("/modulos/{id}", async (int id, AppDbContext db) =>
{
    var modulo = await db.Modulos.FindAsync(id);
    if (modulo is null) return Results.NotFound();
    db.Modulos.Remove(modulo);
    await db.SaveChangesAsync();
    return Results.Ok();
});
#endregion

#region CRUD Multimedia
app.MapGet("/multimedia", async (AppDbContext db) => await db.Multimedia.ToListAsync());
app.MapGet("/multimedia/{id}", async (int id, AppDbContext db) => await db.Multimedia.FindAsync(id));
app.MapPost("/multimedia", async (Multimedia m, AppDbContext db) =>
{
    db.Multimedia.Add(m);
    await db.SaveChangesAsync();
    return Results.Created($"/multimedia/{m.Codigo}", m);
});
app.MapPut("/multimedia/{id}", async (int id, Multimedia input, AppDbContext db) =>
{
    var multimedia = await db.Multimedia.FindAsync(id);
    if (multimedia is null) return Results.NotFound();
    db.Entry(multimedia).CurrentValues.SetValues(input);
    await db.SaveChangesAsync();
    return Results.Ok(multimedia);
});
app.MapDelete("/multimedia/{id}", async (int id, AppDbContext db) =>
{
    var multimedia = await db.Multimedia.FindAsync(id);
    if (multimedia is null) return Results.NotFound();
    db.Multimedia.Remove(multimedia);
    await db.SaveChangesAsync();
    return Results.Ok();
});
#endregion

#region CRUD Persona
app.MapGet("/personas", async (AppDbContext db) => await db.Personas.ToListAsync());
app.MapGet("/personas/{id}", async (int id, AppDbContext db) => await db.Personas.FindAsync(id));
app.MapPost("/personas", async (Persona p, AppDbContext db) =>
{
    db.Personas.Add(p);
    await db.SaveChangesAsync();
    return Results.Created($"/personas/{p.Codigo}", p);
});
app.MapPut("/personas/{id}", async (int id, Persona input, AppDbContext db) =>
{
    var persona = await db.Personas.FindAsync(id);
    if (persona is null) return Results.NotFound();
    db.Entry(persona).CurrentValues.SetValues(input);
    await db.SaveChangesAsync();
    return Results.Ok(persona);
});
app.MapDelete("/personas/{id}", async (int id, AppDbContext db) =>
{
    var persona = await db.Personas.FindAsync(id);
    if (persona is null) return Results.NotFound();
    db.Personas.Remove(persona);
    await db.SaveChangesAsync();
    return Results.Ok();
});
#endregion

#region CRUD PersonaMultimedia
app.MapGet("/personaMultimedia", async (AppDbContext db) => await db.PersonaMultimedia.ToListAsync());
app.MapGet("/personaMultimedia/{codigoPersona}/{codigoMultimedia}", async (int codigoPersona, int codigoMultimedia, AppDbContext db) =>
{
    var pm = await db.PersonaMultimedia.FindAsync(codigoPersona, codigoMultimedia);
    return pm is null ? Results.NotFound() : Results.Ok(pm);
});
app.MapPost("/personaMultimedia", async (PersonaMultimedia pm, AppDbContext db) =>
{
    db.PersonaMultimedia.Add(pm);
    await db.SaveChangesAsync();
    return Results.Created($"/personaMultimedia/{pm.CodigoPersona}/{pm.CodigoMultimedia}", pm);
});
app.MapPut("/personaMultimedia/{codigoPersona}/{codigoMultimedia}", async (int codigoPersona, int codigoMultimedia, PersonaMultimedia input, AppDbContext db) =>
{
    var pm = await db.PersonaMultimedia.FindAsync(codigoPersona, codigoMultimedia);
    if (pm is null) return Results.NotFound();
    db.Entry(pm).CurrentValues.SetValues(input);
    await db.SaveChangesAsync();
    return Results.Ok(pm);
});
app.MapDelete("/personaMultimedia/{codigoPersona}/{codigoMultimedia}", async (int codigoPersona, int codigoMultimedia, AppDbContext db) =>
{
    var pm = await db.PersonaMultimedia.FindAsync(codigoPersona, codigoMultimedia);
    if (pm is null) return Results.NotFound();
    db.PersonaMultimedia.Remove(pm);
    await db.SaveChangesAsync();
    return Results.Ok();
});
#endregion

#region CRUD Publicacion
app.MapGet("/publicaciones", async (AppDbContext db) => await db.Publicaciones.ToListAsync());
app.MapGet("/publicaciones/{id}", async (int id, AppDbContext db) => await db.Publicaciones.FindAsync(id));
app.MapPost("/publicaciones", async (Publicacion p, AppDbContext db) =>
{
    db.Publicaciones.Add(p);
    await db.SaveChangesAsync();
    return Results.Created($"/publicaciones/{p.Codigo}", p);
});
app.MapPut("/publicaciones/{id}", async (int id, Publicacion input, AppDbContext db) =>
{
    var pub = await db.Publicaciones.FindAsync(id);
    if (pub is null) return Results.NotFound();
    db.Entry(pub).CurrentValues.SetValues(input);
    await db.SaveChangesAsync();
    return Results.Ok(pub);
});
app.MapDelete("/publicaciones/{id}", async (int id, AppDbContext db) =>
{
    var pub = await db.Publicaciones.FindAsync(id);
    if (pub is null) return Results.NotFound();
    db.Publicaciones.Remove(pub);
    await db.SaveChangesAsync();
    return Results.Ok();
});
#endregion

#region CRUD Usuario
app.MapGet("/usuarios", async (AppDbContext db) => await db.Usuarios.ToListAsync());
app.MapGet("/usuarios/{id}", async (string id, AppDbContext db) => await db.Usuarios.FindAsync(id));
app.MapPost("/usuarios", async (Usuario u, AppDbContext db) =>
{
    db.Usuarios.Add(u);
    await db.SaveChangesAsync();
    return Results.Created($"/usuarios/{u.UsuarioId}", u);
});
app.MapPut("/usuarios/{id}", async (string id, Usuario input, AppDbContext db) =>
{
    var usuario = await db.Usuarios.FindAsync(id);
    if (usuario is null) return Results.NotFound();
    db.Entry(usuario).CurrentValues.SetValues(input);
    await db.SaveChangesAsync();
    return Results.Ok(usuario);
});
app.MapDelete("/usuarios/{id}", async (string id, AppDbContext db) =>
{
    var usuario = await db.Usuarios.FindAsync(id);
    if (usuario is null) return Results.NotFound();
    db.Usuarios.Remove(usuario);
    await db.SaveChangesAsync();
    return Results.Ok();
});
#endregion

#region Endpoint para obtener los valores de TipoUsuarioEnum
app.MapGet("/tipousuarioenum", () =>
{
    var values = Enum.GetNames(typeof(TipoUsuarioEnum));
    return Results.Ok(values);
});
#endregion

#region CRUD Valoracion
app.MapGet("/valoraciones", async (AppDbContext db) => await db.Valoraciones.ToListAsync());
app.MapGet("/valoraciones/{id}", async (int id, AppDbContext db) => await db.Valoraciones.FindAsync(id));
app.MapPost("/valoraciones", async (Valoracion v, AppDbContext db) =>
{
    db.Valoraciones.Add(v);
    await db.SaveChangesAsync();
    return Results.Created($"/valoraciones/{v.CodigoValoracion}", v);
});
app.MapPut("/valoraciones/{id}", async (int id, Valoracion input, AppDbContext db) =>
{
    var valoracion = await db.Valoraciones.FindAsync(id);
    if (valoracion is null) return Results.NotFound();
    db.Entry(valoracion).CurrentValues.SetValues(input);
    await db.SaveChangesAsync();
    return Results.Ok(valoracion);
});
app.MapDelete("/valoraciones/{id}", async (int id, AppDbContext db) =>
{
    var valoracion = await db.Valoraciones.FindAsync(id);
    if (valoracion is null) return Results.NotFound();
    db.Valoraciones.Remove(valoracion);
    await db.SaveChangesAsync();
    return Results.Ok();
});
#endregion



#region Login
app.MapPost("/login", async (LoginRequest request, IAuthService authService) =>
{
    var authResult = await authService.Authenticate(request.UsuarioId, request.Password);

    if (authResult == null) // Si la autenticacion fallo
    {
        return Results.Unauthorized(); // HTTP 401
    }

    // Si la autenticacion es exitosa, devuelve el token y el tipo de usuario
    return Results.Ok(authResult); // Devuelve el objeto AuthResult directamente
});
#endregion


app.Run();