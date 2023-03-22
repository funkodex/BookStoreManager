using System.Text;
using System.Text.Json.Serialization;

using Core;
using DataAccess;
using DataAccess.Mappers;
using DataAccess.Models.Entities;
using DataAccess.Repositories;
using InventoryManagerBackend.Services;
using InventoryManagerBackend.Utilities;
using Mapster;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

//TypeAdapterConfig<Product, long>.NewConfig()
//    .MapWith(product => product.Id.Value);

//TypeAdapterConfig<Category, CategoryDto>
//    .NewConfig()
//    .PreserveReference(true);
//TypeAdapterConfig<SalesOrder, SalesOrderDto>
//    .NewConfig()
//    .PreserveReference(true);
//TypeAdapterConfig<OrderItem, OrderItemDto>
//    .NewConfig()
//    .PreserveReference(true);



builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services.Configure<MailingOptions>(builder.Configuration.GetRequiredSection("Mailing"));

//Audit.Core.Configuration.Setup().UseEntityFramework(ef=>
//{

//});
// Add services to the container.
string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<BookStoreInventoryContext>();
builder.Services.AddControllers();

builder.Services.AddDbContext<BookStoreInventoryContext>();
//register repositories 
builder.Services.AddScoped<ICategoryRepository, CategoryRepository<BookStoreInventoryContext>>();
builder.Services.AddScoped<IProductRepository, ProductRepository<BookStoreInventoryContext>>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository<BookStoreInventoryContext>>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository<BookStoreInventoryContext>>();
builder.Services.AddScoped<IBundleRepository, BundleRepository<BookStoreInventoryContext>>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository<BookStoreInventoryContext>>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository<BookStoreInventoryContext>>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository<BookStoreInventoryContext>>();
// register mappers
builder.Services.AddSingleton<ICategoryMapper, CategoryMapper>();
builder.Services.AddSingleton<IProductMapper, ProductMapper>();
builder.Services.AddSingleton<IBookMapper, BookMapper>();
builder.Services.AddSingleton<IAuthorMapper, AuthorMapper>();
builder.Services.AddSingleton<IPublisherMapper, PublisherMapper>();
builder.Services.AddSingleton<ISalesOrderMapper, SalesOrderMapper>();
builder.Services.AddSingleton<IPurchaseOrderMapper, PurchaseOrderMapper>();
builder.Services.AddSingleton<IBundleMapper, BundleMapper>();
builder.Services.AddSingleton<IPaymentMapper, PaymentMapper>();
builder.Services.AddSingleton<ICustomerMapper, CustomerMapper>();
builder.Services.AddSingleton<ISupplierMapper, SupplierMapper>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMailService, MailService>();
var type = typeof(IRepository<,>);
var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => t.IsInterface && t.GetInterfaces().Contains(type)));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddCors(option =>
{
    option.AddPolicy("allowedOrigin",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
        );

});
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var jwt = builder.Configuration.GetRequiredSection(JwtOptions.SECTION).Get<JwtOptions>();
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new()
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = jwt.Issuer,
        ValidAudience = jwt.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
    };
    options.Events = new()
    {

    };


})
.AddGoogle(options =>
{
    options.ClientId = "307202960612-jv8lervm9sdhvepklb5u95ujvkm49q0d.apps.googleusercontent.com";
    options.ClientSecret = "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";
    options.CallbackPath = "/auth";
});
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("allowedOrigin");
app.MapControllers();
//app.UseEndpoints(options=>options.MapControllers().RequireAuthorization());
app.Run();
