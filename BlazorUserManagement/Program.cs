using BlazorUserManagement;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks; 

namespace BlazorUserManagement
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Налаштування служб
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // Реєстрація служби UserService
            builder.Services.AddScoped<UserService>();
            var app = builder.Build();

            // Налаштування конвеєра запитів
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            await app.RunAsync();
        }
    }
}