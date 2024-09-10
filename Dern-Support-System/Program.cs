using Dern_Support_System.Data;
using Dern_Support_System.Models;
using Dern_Support_System.Repository.interfaces;
using Dern_Support_System.Repository.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Tunify_Platform.Repositories.Servises;

namespace Dern_Support_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Configure the database context.
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' is missing.");
            }

            builder.Services.AddDbContext<DernSupportDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Configure Identity
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<DernSupportDbContext>()
                .AddDefaultTokenProviders();

            // Register repositories.
            builder.Services.AddScoped<ICustomer, CustomerService>();
            builder.Services.AddScoped<ISupportRequest, SupportRequestService>();
            builder.Services.AddScoped<IRepairJob, RepairJobService>();
            builder.Services.AddScoped<IQuote, QuoteService>();
            builder.Services.AddScoped<ISparePart, SparePartService>();
            builder.Services.AddScoped<IKnowledgeBase, KnowledgeBaseService>();
            builder.Services.AddScoped<ITechnician, TechnicianService>();
            builder.Services.AddScoped<IFeedback, FeedbackService>();
            builder.Services.AddScoped<IUser, IdentityUserService>();
            builder.Services.AddScoped<JwtTokenServeses>();

            // Configure JWT Authentication
            var jwtSettings = builder.Configuration.GetSection("JWT");
            var secretKey = jwtSettings.GetValue<string>("SecretKey");

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("JWT Secret Key is missing.");
            }

            var key = Encoding.ASCII.GetBytes(secretKey);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

            // Configure Authorization Policies
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                options.AddPolicy("RequireUpdatePermission", policy =>
                    policy.RequireClaim("permission", "update"));
                options.AddPolicy("RequireDeleteAccess", policy =>
                    policy.RequireClaim("permission", "delete"));
                options.AddPolicy("OnlyThisEmail", policy =>
                    policy.RequireClaim("Email", "abedradwan84.5@gmail.com"));
            });

            // Configure Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Dern Support System API",
                    Version = "v1",
                    Description = "API for managing Dern Support System"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Please enter your token below."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
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

            app.UseAuthentication();
            app.UseAuthorization();

            // Enable Swagger Middleware
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Dern Support System API V1");
                options.RoutePrefix = string.Empty; // Sets Swagger UI at the app's root
            });

            // Validate database migration
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DernSupportDbContext>();
                try
                {
                    dbContext.Database.Migrate(); // Apply pending migrations
                }
                catch (Exception ex)
                {
                    // Log or handle migration errors
                    Console.WriteLine("Error applying migrations: " + ex.Message);
                }
            }

            app.MapControllers();
            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
