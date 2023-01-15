using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Scrubs.DAL;
using Scrubs.DAL.Interfaces;
using Scrubs.DAL.Repositories;
using Scrubs.Service.Implementations;
using Scrubs.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connection));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
builder.Services.AddTransient<ISpecializationRepository, SpecializationRepository>();
builder.Services.AddTransient<ITimeTableRepository, TimeTableRepository>();
builder.Services.AddTransient<IAppointmentDoctorRepository, AppointmentDoctorRepository>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<ITimeTableService, TimeTableService>();
builder.Services.AddTransient<ISpecializationService, SpecializationService>();
builder.Services.AddTransient<IAppointmentDoctorService, AppointmentDoctorService>();
builder.Services.AddTransient<IAuthService, AuthService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Scrubs", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Scrubs v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
