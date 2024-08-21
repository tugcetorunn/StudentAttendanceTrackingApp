using StudentAttendanceTrackingApp.Data;

var builder = WebApplication.CreateBuilder(args);

// api controller 1. adým
builder.Services.AddControllers();

// swagger 1. adým swashbuckle paketini yükle
// swagger 2. adým
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
