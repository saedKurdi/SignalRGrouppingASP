using WebSignalRAppLesson15.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adding signalR for will be able to work with it : 
builder.Services.AddSignalR();

// adding CORS policy : 
builder.Services.AddCors(p =>
{
    p.AddPolicy("corsapp", builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500/")
            .AllowAnyMethod().AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials();
    });
});

// creating app :
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// using CORS policy before authorization and autentication : 
app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

// adding hub endpoint : 
app.MapHub<MessageHub>("/offers"); // https://localhost:7182/offers (from launchsettings https) is hub endpoint and when it requested hub starts to work 

app.Run();
