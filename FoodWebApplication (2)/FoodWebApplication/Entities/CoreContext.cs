using Entities.Category;
using Entities.Customer;
using Entities.Order;
using Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entities.Food;
using Entities.Modifier;
using Entities.Restaurant;
using Microsoft.EntityFrameworkCore;
using Entities.React;

namespace Entities
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                    .Where(t => t.GetInterfaces()
                                    .Any(gi => gi.IsGenericType
                                    && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
            modelBuilder.Entity<UserEntities>()
                .HasData(
                   new UserEntities
                   {
                       CreatedAt = DateTime.Now,
                       Email = "admin@gmail.com",
                       FullName = "Admin",
                       Id = -1,
                       Password = "123",
                       Phone = "0987654321",
                       UserName = "admin",
                       IsActive = true
                   }
            );
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<UserEntities> Users { get; set; }
        public virtual DbSet<CategoryEntities> Categories { get; set; }
        public virtual DbSet<CustomerEntities> Customer { get; set; }
        public virtual DbSet<CustomerContactEntities> CustomerContact { get; set; }
        public virtual DbSet<OrderEntities> Orders { get; set; }
        public virtual DbSet<OrderDetailEntities> OrderDetails { get; set; }
        public virtual DbSet<FoodEntities> Foods { get; set; }
        public virtual DbSet<ModifierEntities> Modifiers { get; set; }
        public virtual DbSet<ModifierFoodEntities> ModifierFood { get; set; }
        public virtual DbSet<RestaurantEntities> Restaurant { get; set; }
        public virtual DbSet<ReactEntities> React { get; set; }
        public virtual DbSet<OutOfSaleEntities> OutOfSale { get; set; }

    }
}
