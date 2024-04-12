using FDManagement.Repositories.Interface;
using FDManagement.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using FDManagement;

var builder = WebApplication.CreateBuilder(args);

//allowing only cors from the ui server
builder.Services.AddCors(options =>
{
    var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins")
        .Get<string[]>();

    options.AddPolicy(name: "AllowSpecificOrigins",
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.WithOrigins(allowedOrigins);
                          policy.AllowAnyMethod();

                      });
});

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicaionDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FdManConnectionString"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IApparatusRepository, ApparatusRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
