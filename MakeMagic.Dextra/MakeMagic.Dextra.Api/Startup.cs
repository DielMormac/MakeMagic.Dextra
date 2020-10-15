using MakeMagic.Dextra.Api.SwaggerUtils;
using MakeMagic.Dextra.Application;
using MakeMagic.Dextra.Application.Commands.Characters.AddCharacter;
using MakeMagic.Dextra.Application.Commands.Characters.DeleteCharacter;
using MakeMagic.Dextra.Application.Commands.Characters.GetAllCharacters;
using MakeMagic.Dextra.Application.Commands.Characters.GetCharacter;
using MakeMagic.Dextra.Application.Commands.Characters.UpdateCharacter;
using MakeMagic.Dextra.Infrastructure;
using MakeMagic.Dextra.Infrastructure.EntityFrameworkDataAccess;
using MakeMagic.Dextra.Infrastructure.Repositories;
using MakeMagic.Dextra.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace MakeMagic.Dextra.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Add DbContext
            services.AddDbContext<Context>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //Dependency Injection

            services.AddTransient<IContext, Context>()
                .AddTransient<IGetAllCharactersUseCase, GetAllCharactersUseCase>()
                .AddTransient<IGetCharacterUseCase, GetCharacterUseCase>()
                .AddTransient<IAddCharacterUseCase, AddCharacterUseCase>()
                .AddTransient<IDeleteCharacterUseCase, DeleteCharacterUseCase>()
                .AddTransient<IUpdateCharacterUseCase, UpdateCharacterUseCase>()
                .AddTransient<IApiRepository, ApiRepository>()
                .AddTransient<IPotterApiRepository, PotterApiRepository>()
                .AddTransient<ICharacterRepository, CharacterRepository>();

            // Adiciona serviço de documentação Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "MakeMagic Dextra",
                    Version = "v1",
                    Description = "API REST desenvolvida para o teste de backend, com base no exercício Make Magic",
                    Contact = new OpenApiContact
                    {
                        Name = "Dextra",
                        Email = "diel.mormac@gmail.com",
                        Url = new Uri("http://localhost:54658/swagger")
                    },
                });

                c.DocumentFilter<ReplaceVersionWithExactValueInPath>();
                c.OperationFilter<RemoveVersionFromParameter>();
            });

            services.AddApiVersioning();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(@"v1/swagger.json", "MakeMagic API v1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
