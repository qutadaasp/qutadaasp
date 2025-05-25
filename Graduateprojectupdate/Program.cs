using Microsoft.EntityFrameworkCore;
using tasks.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();

var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDBcontext>(options =>
    options.UseSqlServer(connectionstring));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDBcontext>();

    if (!context.Blogs.Any())
    {
        var blogs = new List<Blog>
        {
            new Blog { Name = "B1", Description = "task11" },
            new Blog { Name = "B2", Description = "Task12" },
            new Blog { Name = "B3", Description = "Task13" },
            new Blog { Name = "B4", Description = "Task14" },
            new Blog { Name = "B5", Description = "Task15" }
        };

        context.Blogs.AddRange(blogs);
        context.SaveChanges();
    }
}

app.Run();
