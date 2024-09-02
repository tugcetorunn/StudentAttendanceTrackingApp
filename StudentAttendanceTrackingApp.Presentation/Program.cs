using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StudentAttendanceTrackingApp.Business.Repositories.Abstracts;
using StudentAttendanceTrackingApp.Business.Repositories.Concrete;
using StudentAttendanceTrackingApp.Data;
using StudentAttendanceTrackingApp.Presentation.Extensions;
using System.Reflection;
using System.Text;
using TT.Core.Authorization;

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
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())); // versiyon 12 den öncesi farklý sonrasý farklý

// mediator için injection yönlendirmesi. (ne zaman ýmediator ý çaðýrýrsak bana mediator ý çalýþtýr.)
builder.Services.AddScoped<IMediator, Mediator>();

// token production için injection yönlendirmesi (dependency injection þartý)
 builder.Services.AddScoped<TokenService>();

// repository injection yönlendirmesi
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IApiUserRepository, ApiUserRepository>();
builder.Services.AddTransient<ILessonRepository, LessonRepository>();

builder.Services.AddDbContext<SATDbContext>(/*options => options.UseNpgsql(@"Host=localhost;Database=postgres;Username=tt;Password=tt2727;Search Path=satapp")*/);

// authorization dll projesinde tanýmladýðýmýz bu bilgileri bu projede de configuration dan çekmek için burada tanýmlýyoruz.
// dll projesinde configuration class ýný inject etmiþtik fakar burasý program.cs, burada class method yapýsý olmadýðý için builder burada bunu saðlayacak. 
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"]; // bilgilerin þifrelenmesi bu key yapýsýna göre olur. minimum 16 karakter olmalý
var issuer = jwtSettings["Issuer"]; // token ý oluþturan sunucu
var audience = jwtSettings["Audience"]; // token ý kullanacak kiþi, uygulama, site. örneðin bir sitenin kullanýmýna özel bir api projemiz varsa buraya yazarýz.
var expireMinutes = int.Parse(jwtSettings["ExpireMinutes"]); // api yi tüketme eriþim süresi (dk)
// burada tanýmlamasak da diðer projede tanýmladýðýmýz yerlerden çeker mi teste et...

// jwt authentication ekleme
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // kimlik doðrulamasý için bu þemayý eklememiz gerekiyor.
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // true false atamalarý ihtiyaçlarýmýzý belirler.
        // bu kýsýmlar da core tarafýna taþýnabilir. deðerler verilmiþse true verilmemiþse false döner.
        ValidateIssuer = true, // token ý oluþturan taraf, güvenlik açýsýndan true yaparýz.
        ValidateAudience = false, // token ýn hedef kitlesini ayarlarýz. (apilerimizi kim tüketecek?)
        ValidateLifetime = true, // token süresini kontrol eder. bunlarý yazmazsak default deðer atar.
        ValidateIssuerSigningKey = true, // token ý imzalamak için kullanýlan anahtarýn doðruluðunu kontrol eder. (secretkey) güvenliði saðlamak için zorunlu alandýr.
        ValidIssuer = issuer, // yukarýda tanýmladýk, sonra validasyonunu yaptýk ve artýk geçerli issuer olarak atýyoruz.
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), // token imzalanmasý için kullanýlan key i veriyoruz. token ýn geçerli olup olmadýðýný kontrol eder.
        ClockSkew = TimeSpan.FromMinutes(5) // token ýn süresi dolduðunda bir miktar daha esneklik saðlar 5 dk ayarlandý.
    };
});

builder.Services.AddAuthentication(); // yukarýdaki komut özellik ekliyor burada authentication ý entegre etmiþ oluyoruz.

builder.Services.AddSwaggerConfiguration();

// ardalis specification
// iþ kurallarýný ve sorgulamalarý daha düzenli ve yeniden kullanýlabilir bir þekilde yapmak için kullanýlýr.
// yazýlýmda ayný þeyi birden çok kez kullanýyorsak bu iþi tek yerden yönetmenin yolunu bulmalýyýz.
// bu projede de çoðu crud iþleminde id ye göre student bulma iþlemi yaptýk her defasýnda ayný þey için context i çaðýrdýk.
// iþte bu iþlemi bir kez yaparak istediðimiz yerde çaðýrma olanaðýný bize ardalis specification design pattern ý saðlýyor.
// ayrýca ardalis in içerisinde repository design pattern ý da var. sadece ardalis i entegre ederek data layer ý da business ý da geliþtirmiþ olacaðýz.
// iþi parçalara ayýrmýþ olduðumuz için de test edilebilirliði ve sürdürülebilirliði arttýrmýþ oluyoruz.
// ardalis specification sorgulamalarýn ve iþ kurallarýnýn nesne yönelimli bir þekilde ifade edilmesini saðlar.
// üç kriteri var -> 1- specification (spesifikasyon) : belirli bir iþ kuralý yani sorgu kriterleri tanýmlanýr.
//                   2- criteria (kriter) : ne sonuçlar döndüreceðini ifade eder.
//                   3- expression (ifade) : sorgu ve iþ kurallarýný dinamik olarak oluþturmak için kullanýlýr.


// code first yönteminde db için yapýlan her deðiþiklik için update database e ihtiyaç duyuyoruz. her defasýnda bu iþlemi tekrarlamadan deðiþikliði
// otomatik bir þekilde sunucuya aktaran bir otomasyonu nasýl yapabiliriz? --> DbUp kütüphanesi bunu yapýyor.
var app = builder.Build();

// api controller 2. adým
app.MapControllers();

// swagger 3. adým
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization(); // kimlik doðrulamasýný yapar.

app.Run();
