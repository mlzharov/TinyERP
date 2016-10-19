using App.Entity.Registration;
using System.Data.Entity;
using App.Common;
using App.Entity.Security;
using App.Entity.ProductManagement;
using App.Entity.Common;
using App.Entity.Store;
using App.Entity.Setting;

namespace App.Context
{
    public class AppDbContext : App.Common.Data.MSSQL.MSSQLDbContext
    {
        public AppDbContext(IOMode mode = IOMode.Read) : base(new App.Common.Data.MSSQL.MSSQLConnectionString(), mode)
        {
            Database.SetInitializer<AppDbContext>(new DropCreateDatabaseIfModelChanges<AppDbContext>());
        }
        public System.Data.Entity.DbSet<FileUpload> FileUploads { get; set; }
        public System.Data.Entity.DbSet<Product> Products { get; set; }
        public System.Data.Entity.DbSet<ProductCategory> ProductCategories { get; set; }
        public System.Data.Entity.DbSet<User> Users { get; set; }
        public System.Data.Entity.DbSet<ContentType> ContentTypes { get; set; }
        public System.Data.Entity.DbSet<Permission> Permissions { get; set; }
        public System.Data.Entity.DbSet<Role> Roles { get; set; }
        public System.Data.Entity.DbSet<UserGroup> UserGroups { get; set; }

        public System.Data.Entity.DbSet<StoreAccount> Accounts { get; set; }
        public System.Data.Entity.DbSet<Store> Stores { get; set; }
        public System.Data.Entity.DbSet<Order> Orders { get; set; }
        public System.Data.Entity.DbSet<OrderContact> OrderContacts { get; set; }
        public System.Data.Entity.DbSet<OrderItem> OrderItems { get; set; }
        public System.Data.Entity.DbSet<Parameter> Parameters { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasMany(order => order.Items);
            

            modelBuilder.Entity<Role>().ToTable("Roles");
            modelBuilder.Entity<Permission>().ToTable("Permissions");
            modelBuilder.Entity<Role>()
                .HasMany(role => role.Permissions)
                .WithMany(per => per.Roles)
                .Map(m =>
                {
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("PermissionId");
                    m.ToTable("PermissionInRoles");
                });

            modelBuilder.Entity<UserGroup>()
                .HasMany(ug => ug.Permissions)
                .WithMany(per => per.UserGroups)
                .Map(m =>
                {
                    m.MapLeftKey("UserGroupId");
                    m.MapRightKey("PermissionId");
                    m.ToTable("PermissionInUserGroups");
                });
        }
    }
}
