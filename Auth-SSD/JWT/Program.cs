using JWT.Services;

var builder = WebApplication.CreateBuilder(args);

// Register the JwtTokenService as a singleton
builder.Services.AddSingleton<JwtTokenService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();




    app.UseSwagger();
    app.UseSwaggerUI();


// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
