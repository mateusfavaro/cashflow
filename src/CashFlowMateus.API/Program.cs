using CashFlowMateus.API.Filters;
using CashFlowMateus.API.Middleware;
using CashFlowMateus.Application;
using CashFlowMateus.Infrastructure;
using CashFlowMateus.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await MigrateDataBase();

app.Run();

async Task MigrateDataBase()
{
    await using var scope = app.Services.CreateAsyncScope();

    await DataBaseMigration.MigrateDataBase(scope.ServiceProvider);

    
}
