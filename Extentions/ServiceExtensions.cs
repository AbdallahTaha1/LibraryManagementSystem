using LibraryManagementSystem.Data;
using LibraryManagementSystem.Repositories.BaseRepository;
using LibraryManagementSystem.Repositories.BookRepository;
using LibraryManagementSystem.Repositories.TrasactionRepository;
using LibraryManagementSystem.Repositories.UnitOfWork;
using LibraryManagementSystem.Repositories.UserRepository;
using LibraryManagementSystem.Services.BookService;
using LibraryManagementSystem.Services.TransactionService;
using LibraryManagementSystem.Services.UserService;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Extentions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            return services;
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ??
                    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(connectionString)
            );

            return services;
        }
    }
}
