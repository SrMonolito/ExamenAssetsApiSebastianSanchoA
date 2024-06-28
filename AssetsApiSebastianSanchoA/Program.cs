using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using AssetsApiSebastianSanchoA.Models;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        //se inserta el codigo para poder inyectar la cadena de conexion contenida en appsettings

        //se obtiene el valor de la cadena de conexion 
        var CnnStrBuilder = new SqlConnectionStringBuilder(
            builder.Configuration.GetConnectionString("CnnStr"));

        //se incluye la contraseña debido a que se borro en la cadena de conexion
        CnnStrBuilder.Password = "PWEx1P6";

        //se crea un string con la info de la cadena de conexion
        string cnnStr = CnnStrBuilder.ConnectionString;

        //se asigna el valor de la cadena de conexion al DB Context de Models
        builder.Services.AddDbContext<Ex1p6assets20243Context>(options => options.UseSqlServer(cnnStr));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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