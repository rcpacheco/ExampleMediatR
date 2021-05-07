using ExampleMediatR.Extensions;
using ExampleMediatR.Filters;
using ExampleMediatR.Mapping;
using ExampleMediatR.PipelineBehaviors;
using ExampleMediatR.Repositories;

using FluentValidation;
using FluentValidation.AspNetCore;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExampleMediatR
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(options =>
                {
                    options.Filters.Add<ValidationFilter>();
                })
                .AddFluentValidation(m => m.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

            services.AddSingleton<ICustomersRepository, CustomersRepository>();
            services.AddSingleton<IOrdersRepository, OrdersRepository>();
            services.AddSingleton<IMapper, Mapper>();

            services.AddMediatR(typeof(Startup));

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

            app.UseRouting();

            app.UseFluentValidationExceptionHandler();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
