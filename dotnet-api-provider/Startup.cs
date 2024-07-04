// using Microsoft.AspNetCore.Builder;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Hosting;

// public class Startup
// {
//     public Startup(IConfiguration configuration)
//     {
//         Configuration = configuration;
//     }

//     public IConfiguration Configuration { get; }

//     public void ConfigureServices(IServiceCollection services)
//     {
//         // Add CORS policy
//         services.AddCors(options =>
//         {
//             options.AddPolicy("AllowSpecificOrigin",
//                 builder => builder
//                     .WithOrigins("http://localhost:3000") // Replace with your React app's URL
//                     .AllowAnyHeader()
//                     .AllowAnyMethod());
//         });

//         services.AddControllers();
//     }

//     public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//     {
//         if (env.IsDevelopment())
//         {
//             app.UseDeveloperExceptionPage();
//         }
//         else
//         {
//             app.UseExceptionHandler("/Home/Error");
//             app.UseHsts();
//         }

//         app.UseHttpsRedirection();
//         app.UseStaticFiles();

//         app.UseRouting();

//         app.UseCors("AllowSpecificOrigin");

//         app.UseAuthorization();

//         app.UseEndpoints(endpoints =>
//         {
//             endpoints.MapControllers();
//         });
//     }
// }
