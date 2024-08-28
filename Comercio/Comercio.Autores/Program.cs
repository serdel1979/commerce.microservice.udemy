using Comercio.Autores.Aplicacion;
using Comercio.Autores.Mapeo;
using Comercio.Autores.Persistencia;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 builder.Services.AddControllers()
    .AddFluentValidation(conf => conf.RegisterValidatorsFromAssemblyContaining<Nuevo>());


builder.Services.AddAutoMapper(typeof(MapeoObjeto));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddMediatR(conf=> conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Connect"));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
