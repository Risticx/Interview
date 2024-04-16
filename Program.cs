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


builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
