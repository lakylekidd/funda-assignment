using System;
using System.Net.Http;
using FundaWebApplication.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

namespace FundaWebApplication
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Add funda service as transient
            services.AddTransient<IFundaService, FundaService>();

            // Configure the client with polly's retry policy
            services.AddHttpClient<IFundaService, FundaService>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5)) // Set the lifetime to 5 minutes
                .AddPolicyHandler(GetRetryPolicy());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }

        /// <summary>
        /// It adds policies to the HttpClient objects we will be using.
        /// This function adds polly's policy for Http Retries with exponential backoff.
        /// </summary>
        /// <returns></returns>
        static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
            #region Status Codes for Retrying
                // Handle 500 status codes
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                // Handle 502 status codes
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.BadGateway)
                // Handle 504 status codes
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.GatewayTimeout)
            #endregion
                // Will retry a maximum of 6 times
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
