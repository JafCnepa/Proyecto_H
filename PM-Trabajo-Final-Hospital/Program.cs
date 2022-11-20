using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PM_Trabajo_Final_Hospital.Datos;

var builder = WebApplication.CreateBuilder(args);

//Configuración con la base de Datos SQLServer
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
//Agregar el servicio Identity a la aplicación
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
//Esta línea es para la url de retorno al acceder
builder.Services.ConfigureApplicationCookie(options =>
{
  

    options.LoginPath = new PathString("/Usuarios/SignIN");
    options.AccessDeniedPath = new PathString("/Usuarios/Error");
});

// Estas son opciones de configuración del identity
builder.Services.Configure<IdentityOptions>(options =>
{
   
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    options.Lockout.MaxFailedAccessAttempts = 3;
});



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//Se agrega la autenticación
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
