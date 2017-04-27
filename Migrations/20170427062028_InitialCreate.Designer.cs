using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ASPNETCore.SPADemo.Models;

namespace ASPNETCore.SPADemo.Migrations
{
    [DbContext(typeof(ItemContext))]
    [Migration("20170427062028_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASPNETCore.SPADemo.Models.Item", b =>
                {
                    b.Property<int>("ItemId");

                    b.Property<bool>("Completed");

                    b.Property<DateTime>("Deadline");

                    b.Property<string>("Description");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });
        }
    }
}
