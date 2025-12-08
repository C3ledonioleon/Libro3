using NetflixLibrosRazor.Repositories;
using NetflixLibrosRazor.Services;
using sveDapper.Factories;

var builder = WebApplication.CreateBuilder(args);

// ======================
// Servicios
// ======================

// Razor Pages
builder.Services.AddRazorPages();

// Para acceder al usuario autenticado dentro de la factory
builder.Services.AddHttpContextAccessor();

// Registrar la factory de conexión a BD
builder.Services.AddScoped<IDbConnectionFactory, RoleBasedDbConnectionFactory>();

// Registrar repositorios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Registrar servicios
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

// ======================
// Construcción de la app
// ======================
var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Mapear Razor Pages
app.MapRazorPages();

app.Run();
