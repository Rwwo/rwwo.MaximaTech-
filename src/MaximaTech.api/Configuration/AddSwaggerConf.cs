using Microsoft.OpenApi.Models;

namespace MaximaTech.api.Configuration
{
    public static class AddSwaggerConf
    {
        public static WebApplicationBuilder AddSwaggerConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Teste Técnico",
                    Description = "API para Teste Técnico",
                    Contact = new OpenApiContact
                    {
                        Name = "Rubens",
                        Email = "rubensfacco94@gmail.com",
                    }
                }
                );

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insira o token JWT desta maneira: Bearer {seu token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return builder;
        }
    }
}
