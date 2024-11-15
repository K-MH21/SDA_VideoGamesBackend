var options = new WebApplicationOptions { WebRootPath = "wwwroot" };

var builder = WebApplication.CreateBuilder(options);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//connect the database
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("local"),
        npgsqlOptions =>
        {
            npgsqlOptions.CommandTimeout(120);
            npgsqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorCodesToAdd: null
            );
        }
    );
});

builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

// add DI services
builder
    .Services.AddScoped<IPersonService, PersonService>()
    .AddScoped<PersonRepository, PersonRepository>();

builder
    .Services.AddScoped<ICustomerService, CustomerService>()
    .AddScoped<CustomerRepository, CustomerRepository>();

builder
    .Services.AddScoped<IStoreEmployeeService, StoreEmployeeService>()
    .AddScoped<StoreEmployeeRepository, StoreEmployeeRepository>();

builder
    .Services.AddScoped<ISystemAdminService, SystemAdminService>()
    .AddScoped<SystemAdminRepository, SystemAdminRepository>();

builder
    .Services.AddScoped<ICategoryService, CategoryService>()
    .AddScoped<CategoryRepository, CategoryRepository>();
builder
    .Services.AddScoped<IPaymentService, PaymentService>()
    .AddScoped<PaymentRepository, PaymentRepository>();
builder
    .Services.AddScoped<IOrderService, OrderService>()
    .AddScoped<OrderRepository, OrderRepository>();

builder
    .Services.AddScoped<IInventoryService, InventoryService>()
    .AddScoped<InventoryRepository, InventoryRepository>();

builder
    .Services.AddScoped<IStoreService, StoreService>()
    .AddScoped<StoreRepository, StoreRepository>();
builder
    .Services.AddScoped<IVideoGameInfoService, VideoGameInfoService>()
    .AddScoped<VideoGameInfoRepository, VideoGameInfoRepository>();

//Video Game Version mapper
builder
    .Services.AddScoped<IVideoGameVersionService, VideoGameVersionService>()
    .AddScoped<VideoGameVersionRepository, VideoGameVersionRepository>();

//add auto mapper
// builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
builder
    .Services.AddScoped<IConsoleService, ConsoleService>()
    .AddScoped<ConsoleRepository, ConsoleRepository>();

// builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
builder
    .Services.AddScoped<IStudioService, StudioService>()
    .AddScoped<StudioRepository, StudioRepository>();

// builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
builder
    .Services.AddScoped<ISupplierService, SupplierService>()
    .AddScoped<SupplierRepository, SupplierRepository>();

// builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
builder
    .Services.AddScoped<ISupplyService, SupplyService>()
    .AddScoped<SupplyRepository, SupplyRepository>();

// builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
builder
    .Services.AddScoped<IPublisherService, PublisherService>()
    .AddScoped<PublisherRepository, PublisherRepository>();

builder
    .Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value!)
            ),
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole(PersonType.SystemAdmin.ToString()));
    options.AddPolicy("Employee", policy => policy.RequireRole(PersonType.SystemAdmin.ToString()));
    options.AddPolicy("Customer", policy => policy.RequireRole(PersonType.Customer.ToString()));
    options.AddPolicy(
        "EmployeeOrAdmin",
        policy =>
            policy.RequireRole(
                PersonType.SystemAdmin.ToString(),
                PersonType.StoreEmployee.ToString()
            )
    );
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// // Cors
// var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy(
//         name: MyAllowSpecificOrigins,
//         policy =>
//         {
//             policy
//                 .WithOrigins(
//                     "http://localhost:3000",
//                     "https://k-mh21-frontend.onrender.com"
//                 )
//                 .AllowAnyHeader()
//                 .AllowAnyMethod()
//                 .AllowCredentials();
//         }
//     );
// });

var app = builder.Build();

// app.UseCors(MyAllowSpecificOrigins);
app.UseMiddleware<LoggingMiddleware>();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseStaticFiles();

app.UseRouting();
app.MapGet(
    "/",
    async (DatabaseContext dbContext) =>
    {
        try
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                return Results.Ok("Database connection successful.");
            }
            else
            {
                return Results.Problem("Unable to connect to the database.");
            }
        }
        catch (Exception ex)
        {
            return Results.Problem($"Database error: {ex.Message}");
        }
    }
);

//test if the database is conncted
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    try
    {
        if (dbContext.Database.CanConnect())
        {
            Console.WriteLine("Database is connected.");
        }
        else
        {
            Console.WriteLine("Unable to connect to the database.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Databse connection failed:{ex.Message}");
    }
}

// Enable Swagger for API documentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Map the controllers
app.MapControllers();

app.Run();
