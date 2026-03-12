using ContactApp.API.Storage;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//var stringConnection = builder.Configuration.GetConnectionString("SqliteStringConnection");
builder.Services.AddSingleton<IStorage>(new SqliteStorage("Data Source = API/contacts.db"));
builder.Services.AddCors(opt =>
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:3000"/*builder.Configuration["client"]*/);
    }));
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();
app.UseCors("CorsPolicy");
app.Run();
