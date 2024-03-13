using FDManagement.Repositories.Interface;
using FDManagement.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;
using FDManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicaionDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FdManConnectionString"));
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


//allowing only cors from the ui server
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader();
                          policy.WithOrigins("http://localhost:4200");
                          policy.AllowAnyMethod();

                      });
});

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
