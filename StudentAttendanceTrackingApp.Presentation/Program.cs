using StudentAttendanceTrackingApp.Data;

var builder = WebApplication.CreateBuilder(args);

// api controller 1. ad�m
builder.Services.AddControllers();

// swagger 1. ad�m swashbuckle paketini y�kle
// swagger 2. ad�m
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
