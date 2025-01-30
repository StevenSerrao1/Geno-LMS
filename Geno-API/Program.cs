using DotNetEnv;
using Microsoft.Data.SqlClient;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Load Environment Variables from '.env' file
Env.Load();
string? connection_string = Environment.GetEnvironmentVariable("CONNECTION_STR");
Console.WriteLine("PRE CONNECTION STRING; " + connection_string);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
if (!string.IsNullOrEmpty(connection_string))
{
    try
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connection_string);
        });
    }
    catch (Exception ex)
    {

        Console.WriteLine(ex.Message);
    }
    
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
