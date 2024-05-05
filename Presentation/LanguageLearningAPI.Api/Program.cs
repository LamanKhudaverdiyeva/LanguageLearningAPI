using LanguageLearningAPI.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o=>
{
    var Key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]);
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});
builder.Services.AddAuthorization(x => x.AddPolicy("Admin", p => p.RequireClaim("Admin")));

builder.Services.AddPersistenceServices();
//Logger log = new LoggerConfiguration()
//    .WriteTo.Console(Serilog.Events.LogEventLevel.Debug)
//    .WriteTo.File("Logs/mylogs.txt")
//  .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"), sinkOptions: new MSSqlServerSinkOptions
//  {
//      TableName = "Logs",
//      AutoCreateSqlTable = true
//  },
//columnOptions: new ColumnOptions
//{
//    AdditionalColumns = new Collection<SqlColumn>
//    {
//            new SqlColumn(columnName:"User_Id", SqlDbType.NVarChar)
//    }
//},
// restrictedToMinimumLevel: LogEventLevel.Warning
// )
//.Enrich.FromLogContext()
//.MinimumLevel.Information()
//.CreateLogger();

//builder.Host.UseSerilog(log);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
