using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using School.DataAccess.Repository;
using School.DataAccess.Services;
using School.DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()    // Allows all origins (use with caution)
              .AllowAnyMethod()    // Allows all HTTP methods (GET, POST, PUT, DELETE)
              .AllowAnyHeader();   // Allows all headers
    });
});
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure database context (replace 'YourDbContext' and connection string accordingly)
builder.Services.AddDbContext<SchoolDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDbConnection")));

// Register repositories and services for dependency injection
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ImarkService, MarkService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
// Use CORS before any endpoint mapping
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
