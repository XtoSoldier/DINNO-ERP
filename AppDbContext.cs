using System.Collections.Generic;
using DINNO_ERP.Entities;
using Microsoft.EntityFrameworkCore;

namespace DINNO_ERP
{
    public class AppDbContext: DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }  
        public DbSet<Auth> Auths { get; set; }
        public DbSet <Token> Tokens { get; set; }

        public DbSet <Client> Clients { get; set; }
        public DbSet <Product> Products { get; set; }
        public DbSet <Module> Modules { get; set; }

        public DbSet<ClientProduct> ClientProducts { get; set; }
        public DbSet<ClientModule> ClientModules { get; set; }
        public DbSet<ClientProductConnection> ClientProductConnections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureUserAuthToken(modelBuilder);
            ConfigureClientProduct(modelBuilder);
        }
        
        public static void ConfigureUserAuthToken(ModelBuilder modelBuilder)
        {
            //            ✔ Esto crea:
            //Auth.Id → PK + FK → User.Id
            //Token.Id → PK + FK → Auth.Id
            
            modelBuilder.Entity<User>()
                .HasOne(u => u.Auth)
                .WithOne(a => a.User)
                .HasForeignKey<Auth>(a =>a.Id)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Auth>()
                .HasOne(a => a.Token)
                .WithOne(t => t.Auth)
                .HasForeignKey<Token>(t=>t.Id)
                .OnDelete(DeleteBehavior.Cascade);

        }

        private static void ConfigureClientProduct(ModelBuilder modelBuilder)
        {
            ///Product ↔ Module (1–N)
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Modules)
                .WithOne(m => m.Product)
                .HasForeignKey(m => m.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            ///Client ↔ Product (N–N con tabla intermedia)
            modelBuilder.Entity<ClientProduct>()
            .HasOne(cp => cp.Client)
            .WithMany(c => c.ClientProducts)
            .HasForeignKey(cp => cp.ClientId);

            modelBuilder.Entity<ClientProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.ClientProducts)
                .HasForeignKey(cp => cp.ProductId);
            ///ClientProduct ↔ Module (N–N)
            modelBuilder.Entity<ClientModule>()
                .HasOne(cm => cm.ClientProduct)
                .WithMany(cp => cp.ClientModules)
                .HasForeignKey(cm => cm.ClientProductId);
            modelBuilder.Entity<ClientModule>()
                .HasOne(cm => cm.Module)
                .WithMany(m => m.ClientModules)
                .HasForeignKey(cm => cm.ModuleId);
            ///ClientProductConnection (Client + Product)
            modelBuilder.Entity<ClientProductConnection>()
                     .HasOne(cpc => cpc.Client)
                     .WithMany(c => c.Connections)
                     .HasForeignKey(cpc => cpc.ClientId);

            modelBuilder.Entity<ClientProductConnection>()
                .HasOne(cpc => cpc.Product)
                .WithMany()
                .HasForeignKey(cpc => cpc.ProductId);

            modelBuilder.Entity<ClientProductConnection>()
                .HasIndex(cpc => new { cpc.ClientId, cpc.ProductId })
                .IsUnique();

            ///UUID automático en PostgreSQL
            modelBuilder.HasPostgresExtension("pgcrypto");
            modelBuilder.Entity<User>()
                        .Property(u => u.Id)
                        .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<Auth>()
                        .Property(a => a.Id)
                        .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<Token>()
                        .Property(t => t.Id)
                        .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<Client>()
                        .Property(c => c.Id)
                        .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<Product>()
                        .Property(p => p.Id)
                        .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<Module>()
                        .Property(m => m.Id)
                        .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<ClientProduct>()
                        .Property(cp => cp.Id)
                        .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<ClientModule>()
                        .Property(cm => cm.Id)
                        .HasDefaultValueSql("gen_random_uuid()");
            modelBuilder.Entity<ClientProductConnection>()
                        .Property(cpc => cpc.Id)
                        .HasDefaultValueSql("gen_random_uuid()");   




        }


    }
}
