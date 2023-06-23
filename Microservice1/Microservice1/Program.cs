using Microservice1.Filters;
using Microservice1.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();


// Add services to the container.
builder.Services.AddScoped<IBookRepository, MockBookRepository>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizationFilter());
    options.Filters.Add(new ExceptionFilter());
    options.Filters.Add(new ExecutionTimeFilter());
});

builder.Services.AddSwaggerGen();
// Configure logging, if needed
builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
app.MapControllers();

app.Run();
