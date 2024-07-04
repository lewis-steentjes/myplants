var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:3000") // Replace with your React app's URL
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Use the CORS policy
app.UseCors("AllowSpecificOrigin");

app.MapGet("/", () => "Hello World!");

app.MapGet("/red", () => "#FF0000");

app.MapGet("/green", () => "#00FF00");

app.MapGet("/blue", () => "#0000FF");

app.Run();
