using ContactsApp.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(
        policy => {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();
app.UseStatusCodePages();
app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();