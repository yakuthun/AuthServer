using AuthServer.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Data
{

    // Identity üyelik tablolar
    // primary key'leri string olarak tutar

    public class AppDbContext:IdentityDbContext<UserApp, IdentityRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)//options ekliyeceğim ama appdbcontext tarafından ekleyeceğim.
        {//base'deki identity db model olan base'e yani base constructor'a gönderiyorum options'ı

        }
        //üyelik sistemi ile alakası olmayan verileri de ekliyoruz.
        public DbSet<Product> Products { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        //product ve refreshtoken nesnelerimizi configure ettiğimiz yer required olacak mı gibi.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //interfaceleri arayıp configuration'ları ekleyecek
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(builder);
        }
    }
}
