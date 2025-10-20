using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data; // <-- asegúrate que tu namespace esté correcto

var builder = WebApplication.CreateBuilder(args);

// Configura la conexión con la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agrega Identity con roles y cookies
builder.Services.AddDefaultIdentity<IdentityUser>(options => 
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 👇 Estas dos líneas son las que faltaban
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

