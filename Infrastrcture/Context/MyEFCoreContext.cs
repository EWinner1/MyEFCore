using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyEFCore.Infrastrcture.Context.Mapping;
using MyEFCore.Infrastrcture.Models;

namespace MyEFCore.Infrastrcture.Context
{
    public class MyEFCoreContext : DbContext
    {
        private IHttpContextAccessor httpContextAccessor;
        private IWebHostEnvironment webHostEnvironment;
        public IHttpContextAccessor HttpContextAccessor
        {
            get
            {
                return httpContextAccessor ??= this.GetService<IHttpContextAccessor>();
            }
            set
            {
                httpContextAccessor = value;
            }
        }
        public IWebHostEnvironment Environment
        {
            get
            {
                return webHostEnvironment ??= this.GetService<IWebHostEnvironment>();
            }
            set
            {
                webHostEnvironment = value;
            }
        }

        public MyEFCoreContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<People> PeopleRepositories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PeopleConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
