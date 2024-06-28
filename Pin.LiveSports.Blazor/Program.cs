
using Blazored.Toast;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Pin.LiveSports.Blazor.Hubs;
using Pin.LiveSports.Blazor.Services;
using Pin.LiveSports.Core.Data;
using Pin.LiveSports.Core.Entities;
using Pin.LiveSports.Core.Services;
using Pin.LiveSports.Core.Services.Interfaces;


namespace Pin.LiveSports.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddBlazoredToast();
            builder.Services.AddScoped<ICrudService<Fencer>, PlayerService>();
          builder.Services.AddScoped<ICrudService<Team>, TeamService>();
          builder.Services.AddScoped<ITournamentService, TournamentService>();
          builder.Services.AddScoped<ICrudService<Duel>, DuelService>();
              builder.Services.AddScoped<IDuelEventManager, DuelEventManager>();
              builder.Services.AddScoped<IAvatarService, AvatarService>();

            builder.Services.AddDbContext<FencingDbContext>(options =>
                options
                    .UseSqlServer(builder.Configuration.GetConnectionString("FencingDb")));
            builder.Services.AddSignalR();
            builder.Services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseResponseCompression();
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<TournamentHub>("/tournamentHub");
            });

            app.Run();
        }
    }
}