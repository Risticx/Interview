using Application.Currency.Commands;
using Application.Currency.Queries;
using Application.Transaction.Commands;
using Application.Transaction.Queries;
using Application.User.Commands;
using Application.User.Queries;
using Application.Validator;
using Domain.Repositories;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Interview"));
});

builder.Services.AddScoped<ITransactionRepository, EFTransactionRepository>();
builder.Services.AddScoped<IUserRepository, EFUserRepository>();
builder.Services.AddScoped<ICurrencyRepository, EFCurrencyRepository>();
builder.Services.AddScoped<GetUserQuery>();
builder.Services.AddScoped<CreateUserCommand>();
builder.Services.AddScoped<CreateTransactionCommand>();
builder.Services.AddScoped<AddTransactionToUserCommand>();
builder.Services.AddScoped<HashValidator>();
builder.Services.AddScoped<GetTransactionQuery>();
builder.Services.AddScoped<GetCurrencyQuery>();
builder.Services.AddScoped<CreateCurrencyCommand>();
builder.Services.AddScoped<UserExistsByIdQuery>();
builder.Services.AddScoped<CurrencyExistsByLabelQuery>();

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.RequestHeaders.Add("hash");
    logging.ResponseHeaders.Add("my-response-header");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var loggerFactory = app.Services.GetService<ILoggerFactory>();
loggerFactory.AddFile(builder.Configuration["Logging:LogFileSettings:LogFilePath"].ToString());    

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
