using NetflixLibrosRazor.Repositories;
using NetflixLibrosRazor.Services;
using NetflixLibrosRazor.DTOs;
using FluentValidation;
using NetflixLibrosRazor.Repository.Factories;
using NetflixLibrosRazor.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// ============================
// Servicios Razor y BD
// ============================
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IDbConnectionFactory, RoleBasedDbConnectionFactory>();

// Repos y Services
builder.Services.AddScoped<ILibroRepository, LibroRepository>();
builder.Services.AddScoped<ILibroService, LibroService>();
// === Usuario ===
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IValidator<LibroCreateDto>, LibroValidator>();
builder.Services.AddScoped<IValidator<LibroUpdateDto>, LibroUpdateValidator>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();


// =========================================================
// ===============   ENDPOINTS MINIMAL API   ===============
// =========================================================

// -------------------- Crear libro --------------------
app.MapPost("/api/libros", (ILibroService service, LibroCreateDto dto,IValidator<LibroCreateDto> validator) =>
{
    var result = validator.Validate(dto);

    if (!result.IsValid)
    {
        var errores = result.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.ErrorMessage).ToArray()
            );

        return Results.ValidationProblem(errores);
    }

    var id = service.AgregarLibro(dto);

    return Results.Created($"/api/libros/{id}", new
    {
        IdLibro = id,
        Libro = dto
    });
});


// -------------------- Obtener todos --------------------
app.MapGet("/api/libros", (ILibroService service) =>
{
    return Results.Ok(service.ObtenerTodo());
});


// -------------------- Obtener por id --------------------
app.MapGet("/api/libros/{id}", (ILibroService service, int id) =>
{
    var libro = service.ObtenerPorId(id);

    return libro is null ? Results.NotFound() : Results.Ok(libro);
});


// -------------------- Actualizar libro --------------------
app.MapPut("/api/libros/{id}", (ILibroService service, LibroUpdateDto dto, int id, IValidator<LibroUpdateDto> validator) =>
{
    var result = validator.Validate(dto);

    if (!result.IsValid)
    {
        var errores = result.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.ErrorMessage).ToArray()
            );

        return Results.ValidationProblem(errores);
    }

    var actualizado = service.ActualizarLibro(id, dto);

    return actualizado == 0 ? Results.NotFound() : Results.NoContent();
});


// -------------------- Eliminar libro --------------------
app.MapDelete("/api/libros/{id}", (ILibroService service, int id) =>
{
    var eliminado = service.EliminarLibro(id);

    return eliminado == 0 ? Results.NotFound() : Results.NoContent();
});


// =========================================================
// ====================== RUN ==============================
// =========================================================
app.Run();
