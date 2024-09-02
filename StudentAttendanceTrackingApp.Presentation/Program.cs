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

// token production i�in injection y�nlendirmesi (dependency injection �art�)
 builder.Services.AddScoped<TokenService>();

// repository injection y�nlendirmesi
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IApiUserRepository, ApiUserRepository>();
builder.Services.AddTransient<ILessonRepository, LessonRepository>();

builder.Services.AddDbContext<SATDbContext>(/*options => options.UseNpgsql(@"Host=localhost;Database=postgres;Username=tt;Password=tt2727;Search Path=satapp")*/);

// authorization dll projesinde tan�mlad���m�z bu bilgileri bu projede de configuration dan �ekmek i�in burada tan�ml�yoruz.
// dll projesinde configuration class �n� inject etmi�tik fakar buras� program.cs, burada class method yap�s� olmad��� i�in builder burada bunu sa�layacak. 
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"]; // bilgilerin �ifrelenmesi bu key yap�s�na g�re olur. minimum 16 karakter olmal�
var issuer = jwtSettings["Issuer"]; // token � olu�turan sunucu
var audience = jwtSettings["Audience"]; // token � kullanacak ki�i, uygulama, site. �rne�in bir sitenin kullan�m�na �zel bir api projemiz varsa buraya yazar�z.
var expireMinutes = int.Parse(jwtSettings["ExpireMinutes"]); // api yi t�ketme eri�im s�resi (dk)
// burada tan�mlamasak da di�er projede tan�mlad���m�z yerlerden �eker mi teste et...

// jwt authentication ekleme
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // kimlik do�rulamas� i�in bu �emay� eklememiz gerekiyor.
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // true false atamalar� ihtiya�lar�m�z� belirler.
        // bu k�s�mlar da core taraf�na ta��nabilir. de�erler verilmi�se true verilmemi�se false d�ner.
        ValidateIssuer = true, // token � olu�turan taraf, g�venlik a��s�ndan true yapar�z.
        ValidateAudience = false, // token �n hedef kitlesini ayarlar�z. (apilerimizi kim t�ketecek?)
        ValidateLifetime = true, // token s�resini kontrol eder. bunlar� yazmazsak default de�er atar.
        ValidateIssuerSigningKey = true, // token � imzalamak i�in kullan�lan anahtar�n do�rulu�unu kontrol eder. (secretkey) g�venli�i sa�lamak i�in zorunlu aland�r.
        ValidIssuer = issuer, // yukar�da tan�mlad�k, sonra validasyonunu yapt�k ve art�k ge�erli issuer olarak at�yoruz.
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), // token imzalanmas� i�in kullan�lan key i veriyoruz. token �n ge�erli olup olmad���n� kontrol eder.
        ClockSkew = TimeSpan.FromMinutes(5) // token �n s�resi doldu�unda bir miktar daha esneklik sa�lar 5 dk ayarland�.
    };
});

builder.Services.AddAuthentication(); // yukar�daki komut �zellik ekliyor burada authentication � entegre etmi� oluyoruz.

builder.Services.AddSwaggerConfiguration();

// ardalis specification
// i� kurallar�n� ve sorgulamalar� daha d�zenli ve yeniden kullan�labilir bir �ekilde yapmak i�in kullan�l�r.
// yaz�l�mda ayn� �eyi birden �ok kez kullan�yorsak bu i�i tek yerden y�netmenin yolunu bulmal�y�z.
// bu projede de �o�u crud i�leminde id ye g�re student bulma i�lemi yapt�k her defas�nda ayn� �ey i�in context i �a��rd�k.
// i�te bu i�lemi bir kez yaparak istedi�imiz yerde �a��rma olana��n� bize ardalis specification design pattern � sa�l�yor.
// ayr�ca ardalis in i�erisinde repository design pattern � da var. sadece ardalis i entegre ederek data layer � da business � da geli�tirmi� olaca��z.
// i�i par�alara ay�rm�� oldu�umuz i�in de test edilebilirli�i ve s�rd�r�lebilirli�i artt�rm�� oluyoruz.
// ardalis specification sorgulamalar�n ve i� kurallar�n�n nesne y�nelimli bir �ekilde ifade edilmesini sa�lar.
// �� kriteri var -> 1- specification (spesifikasyon) : belirli bir i� kural� yani sorgu kriterleri tan�mlan�r.
//                   2- criteria (kriter) : ne sonu�lar d�nd�rece�ini ifade eder.
//                   3- expression (ifade) : sorgu ve i� kurallar�n� dinamik olarak olu�turmak i�in kullan�l�r.


// code first y�nteminde db i�in yap�lan her de�i�iklik i�in update database e ihtiya� duyuyoruz. her defas�nda bu i�lemi tekrarlamadan de�i�ikli�i
// otomatik bir �ekilde sunucuya aktaran bir otomasyonu nas�l yapabiliriz? --> DbUp k�t�phanesi bunu yap�yor.
var app = builder.Build();

// api controller 2. ad�m
app.MapControllers();

// swagger 3. ad�m
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization(); // kimlik do�rulamas�n� yapar.

app.Run();
