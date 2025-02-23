using CorePatientlyService.Mappings;
using Microsoft.EntityFrameworkCore;
using CorePatientlyService.Repositories;
using CorePatientlyService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//We are injecting the connection string from the appsettings.json file to the DbContext
builder.Services.AddDbContext<CorePatientlyServiceDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CorePatientlyServiceConnectionString")));

builder.Services.AddScoped<IPatientUserRepository, SQLPatientUserRepository>();
builder.Services.AddScoped<IStaffUserRepository, SQLStaffUserRepository>();
builder.Services.AddScoped<ITenantRepository, SQLTenantRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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