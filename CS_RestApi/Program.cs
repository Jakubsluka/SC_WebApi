using CS_RestApi.BL;
using CS_RestApi.DAL;
using CS_RestApi.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Logger
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.SetMinimumLevel(LogLevel.Information);
    logging.AddNLog("nlog.config");
});


//DB
builder.Services.AddDbContext<AzureContext>();

//Services
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
//builder.Services.AddSingleton<IPaymentQueueManager, PaymentQueueManager>();

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
