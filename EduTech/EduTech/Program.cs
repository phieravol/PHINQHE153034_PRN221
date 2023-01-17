using EduTech.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EduTech.Data;
using EduTech.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<EduTechContext>(options => options.UseSqlServer(
	builder.Configuration.GetConnectionString("EdTechDb")
	));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<EduTechContext>();

builder.Services.AddTransient<IDataService, DataService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
