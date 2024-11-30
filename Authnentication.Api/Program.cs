using Auth.Models.DataBaseSetup.DataBaseConnection;
using Auth.Models.DbSetup.MigratorSetup;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddFluentMigrator(builder.Configuration);

// Add services to the container.


#region Setup Connection String

ConnectionString.InitializeSettings(builder.Configuration);

#endregion


builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


#region Fluent Migrator Config

FluentMigratorSetup.RunMigrations(app.Services);

#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
