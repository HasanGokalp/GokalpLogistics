using FluentValidation;
using GokalpLogistics.Application.Abstract.Services;
using GokalpLogistics.Application.Concrete.AutoMapper;
using GokalpLogistics.Application.Concrete.Services;
using GokalpLogistics.Application.Concrete.Validators.Drivers;
using GokalpLogistics.Application.Concrete.Validators.Trucks;
using GokalpLogistics.Persistence;
using GokalpLogistics.Persistence.Abstract.Repository;
using GokalpLogistics.Persistence.Abstract.UnitWork;
using GokalpLogistics.Persistence.Concrete.Repositories;
using GokalpLogistics.Persistence.Concrete.UnitWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Db baðlantýsý
#region DataBase

builder.Services.AddDbContext<GokalpLogisticsContext>(s =>
{
    //appsetting.json dan alýndý baðlantý stringi
    s.UseSqlServer(builder.Configuration.GetConnectionString("GokalpLogistics"));
});

#endregion

//Depency injection
#region DI

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitWork, UnitWork>();
builder.Services.AddScoped<ITruckService, TruckService>();
builder.Services.AddScoped<IDriverService, DriverService>();

#endregion

//Model doðrulama
#region FluentValidation

builder.Services.AddValidatorsFromAssemblyContaining(typeof(DriverRegisterValidation));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(DriverUpdateValidation));

builder.Services.AddValidatorsFromAssemblyContaining(typeof(TruckRegisterValidation));
builder.Services.AddValidatorsFromAssemblyContaining(typeof(TruckUpdateValidation));

#endregion

//Map
#region AutoMapper

builder.Services.AddAutoMapper(typeof(DriverMapper), typeof(TruckMapper));

#endregion

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
