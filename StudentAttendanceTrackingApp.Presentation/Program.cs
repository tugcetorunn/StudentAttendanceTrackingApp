using MediatR;
using Microsoft.EntityFrameworkCore;
using StudentAttendanceTrackingApp.Data;
using StudentAttendanceTrackingApp.Presentation.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// api controller 1. adým
builder.Services.AddControllers();

// swagger 1. adým swashbuckle paketini yükle
// swagger 2. adým
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// extension ý çalýþtýrdýk
builder.Services.RegisterHandlers();

// mediator entegration
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); // versiyon 12 den çncesi farklý sonrasý farklý

// mediator için injection yönlendirmesi. (ne zaman ýmediator ý çaðýrýrsak bana mediator ý çalýþtýr.)
builder.Services.AddScoped<IMediator, Mediator>();

builder.Services.AddDbContext<SATDbContext>(/*options => options.UseNpgsql(@"Host=localhost;Database=postgres;Username=tt;Password=tt2727;Search Path=satapp")*/);

var app = builder.Build();

// api controller 2. adým
app.MapControllers();

// swagger 3. adým
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
