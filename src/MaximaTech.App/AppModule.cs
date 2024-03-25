using MediatR;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting.Server;

using RestSharp;

namespace MaximaTech.App
{
    public static class AppModule
    {
        public static void ConfigureCokkies(this IServiceCollection services)
        {
            // Configurações de autenticação
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Conta/Login";
                    options.AccessDeniedPath = "/Conta/AcessoNegado";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ativar HTTPS para cookies
                    options.Cookie.SameSite = SameSiteMode.Strict;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                });

            // Configurações de sessão
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(5); // Defina o tempo limite da sessão, se necessário
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
            });

            // Outras configurações e serviços
        }
    }
}
