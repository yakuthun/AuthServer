﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace MiniApp2.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetInvoices()
        {
            var userName = HttpContext.User.Identity.Name;//bu name üzerinden veri tabanında istediğimiz kullanıcıya ait bilgi alabiliriz.
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            //veritabanında userId veya userName alanları üzerinden gerekli dataları çek.

            //stockId stockQuantity Category UserId/UserName ile ilişkilendirilir.
            return Ok($"Invoice işlemleri => UserName:{userName}-UserId: {userIdClaim.Value}");
            //id de alabiliriz.
        }
    }
}
