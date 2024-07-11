using ATMApp.Contexts;
using ATMApp.Interfaces;
using ATMApp.Models;
using ATMApp.Repositories;
using ATMApp.Services;
using Microsoft.EntityFrameworkCore;

namespace ATMApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //builder.Services.AddDbContext<ATMContext>(options =>
            //{
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            //});

            #region contexts
            builder.Services.AddDbContext<ATMContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );
            #endregion

            #region repositories
            builder.Services.AddScoped<IRepository<int, Card>, CardRepository>();
            builder.Services.AddScoped<IRepository<int, Account>, AccountRepository>();
            #endregion

            #region services
            builder.Services.AddScoped<ICardServices, CardServices>();
            builder.Services.AddScoped<IDepositServices, DepositServices>();
            builder.Services.AddScoped<IWithdrawalService, WithdrawalServices>();
            #endregion

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
