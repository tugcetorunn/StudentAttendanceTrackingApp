using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceTrackingApp.Data;
using StudentAttendanceTrackingApp.Presentation.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// api controller 1. ad�m
builder.Services.AddControllers();

// swagger 1. ad�m swashbuckle paketini y�kle
// swagger 2. ad�m
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// extension � �al��t�rd�k
builder.Services.RegisterHandlers();

// mediator entegration
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); // versiyon 12 den �ncesi farkl� sonras� farkl�

// mediator i�in injection y�nlendirmesi. (ne zaman �mediator � �a��r�rsak bana mediator � �al��t�r.)
builder.Services.AddScoped<IMediator, Mediator>();

builder.Services.AddDbContext<SATDbContext>(/*options => options.UseNpgsql(@"Host=localhost;Database=postgres;Username=tt;Password=tt2727;Search Path=satapp")*/);

var app = builder.Build();

// api controller 2. ad�m
app.MapControllers();

// swagger 3. ad�m
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
