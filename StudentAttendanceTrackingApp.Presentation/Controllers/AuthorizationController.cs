using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAttendanceTrackingApp.Business.Commands;
using StudentAttendanceTrackingApp.Business.Queries;
using StudentAttendanceTrackingApp.Data.Entities;
using StudentAttendanceTrackingApp.Presentation.Common;
using TT.Core.Authorization;

namespace StudentAttendanceTrackingApp.Presentation.Controllers
{
    [Route($"{Constant.RouteAuth}")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly TokenService tokenService; // dependency injection ın şartlarından biri inject ettiğimiz service i program.cs içine entegre etmek.
        public AuthorizationController(IMediator _mediator, TokenService _tokenService)
        {
            mediator = _mediator;
            tokenService = _tokenService;
        }

        // endpointleri yönetmek çok önemli. web te güvenlik açıklarıyla uğraşanlar tarafından apimiz patlayabilir bu nedenle authorize önemli bunun yanında,
        // endpointlerimize 1 saniyede gelen istek sayısını ayarlayarak da kısıtlama koyabiliriz.
        [AllowAnonymous] // herkesin erişimine açık (public) olduğunu belirtir. yazmasak da burası bu şekilde çalışır. controller a yazılırsa tüm action ların erişimini açar.
        [HttpPost("sign-in")]
        public async Task<ActionResult> SignIn([FromQuery] string userName,[FromQuery] string password) // kullanıcı yetkili mi değil mi db de kaydı var mı diye kontrol eder.
                                                                                            // ve ona göre token üretir. token üreten bu solution dışında bir service imiz var.
                                                                                            // onu burada çağırıyoruz. (build ettiğimiz autorize projesini bu katmana
                                                                                            // add reference diyerek browse kısmında dll dosyasını çekiyoruz. ve assemblies
                                                                                            // kısmına proje yüklenmiş oluyor.)
        {
            var sendValue = new SignInCommand() { UserName = userName, Password = password };

            var res = await mediator.Send(sendValue);
            var info = await mediator.Send(new GetUserByUsernameQuery() { UserName = userName }); // request ten gelen username ile db de eşleşen user
                                                                                                  // instance ını getiriyor. bununla da token a bilgi gönderiyoruz.
            if (res)
            {
                var token = tokenService.GenerateToken((info.Id).ToString(), info.Email); // db den eşleşen kullanıcının bilgilerini getirecek.
                return Ok(new { Token = token}); 
            }
            return Unauthorized(res);
        }

        // System.IdentityModel.Tokens.Jwt package ını yüklememiz gerekiyor. tokenService bunu gerektiriyor.
    }
}
