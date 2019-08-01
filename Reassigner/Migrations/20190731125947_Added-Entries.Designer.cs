﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reassigner;

namespace Reassigner.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190731125947_Added-Entries")]
    partial class AddedEntries
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview7.19362.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Reassigner.Infrastructure.Entities.Agent", b =>
                {
                    b.Property<string>("ID");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("Reassigner.Infrastructure.Entities.ReassignmentEntry", b =>
                {
                    b.Property<string>("ID");

                    b.Property<string>("AgentID");

                    b.Property<string>("RuleID");

                    b.Property<string>("TicketID");

                    b.HasKey("ID");

                    b.HasIndex("AgentID");

                    b.HasIndex("RuleID");

                    b.HasIndex("TicketID");

                    b.ToTable("ReassignmentEntries");
                });

            modelBuilder.Entity("Reassigner.Infrastructure.Entities.Rule", b =>
                {
                    b.Property<string>("ID");

                    b.HasKey("ID");

                    b.ToTable("Rules");
                });

            modelBuilder.Entity("Reassigner.Infrastructure.Entities.Ticket", b =>
                {
                    b.Property<string>("ID");

                    b.Property<int>("State");

                    b.HasKey("ID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Reassigner.Infrastructure.Entities.ReassignmentEntry", b =>
                {
                    b.HasOne("Reassigner.Infrastructure.Entities.Agent", "Agent")
                        .WithMany()
                        .HasForeignKey("AgentID");

                    b.HasOne("Reassigner.Infrastructure.Entities.Rule", "Rule")
                        .WithMany()
                        .HasForeignKey("RuleID");

                    b.HasOne("Reassigner.Infrastructure.Entities.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("TicketID");
                });
#pragma warning restore 612, 618
        }
    }
}