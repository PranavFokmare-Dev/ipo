// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ipo.Data;

namespace ipo.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210528110611_ipo v2 db 1.1")]
    partial class ipov2db11
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ipo.Models.Exchange", b =>
                {
                    b.Property<Guid>("ExchangeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ExchangeName")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ExchangeId");

                    b.ToTable("Exchanges");
                });

            modelBuilder.Entity("ipo.Models.FilterSubscription", b =>
                {
                    b.Property<Guid>("FilterSubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("MinEmployee")
                        .HasColumnType("real");

                    b.Property<float>("MinNonInstitutional")
                        .HasColumnType("real");

                    b.Property<float>("MinOthers")
                        .HasColumnType("real");

                    b.Property<float>("MinQualifiedInstitutional")
                        .HasColumnType("real");

                    b.Property<float>("MinRetailIndividual")
                        .HasColumnType("real");

                    b.Property<float>("MinTotal")
                        .HasColumnType("real");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FilterSubscriptionId");

                    b.ToTable("FilterSubscriptions");
                });

            modelBuilder.Entity("ipo.Models.IPO", b =>
                {
                    b.Property<Guid>("IPOId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Close")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("IssuePriceRs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("IssueSizeRsCr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("LotSize")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Open")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IPOId");

                    b.ToTable("IPOs");
                });

            modelBuilder.Entity("ipo.Models.IPOExchange", b =>
                {
                    b.Property<Guid>("IPOId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ExchangeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IPOId", "ExchangeId");

                    b.HasIndex("ExchangeId");

                    b.ToTable("IPOExchanges");
                });

            modelBuilder.Entity("ipo.Models.Subscription", b =>
                {
                    b.Property<Guid>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Employee")
                        .HasColumnType("real");

                    b.Property<Guid>("IPOId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("NonInstitutional")
                        .HasColumnType("real");

                    b.Property<float>("Others")
                        .HasColumnType("real");

                    b.Property<float>("QualifiedInstitutional")
                        .HasColumnType("real");

                    b.Property<float>("RetailIndividual")
                        .HasColumnType("real");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("IPOId")
                        .IsUnique();

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("ipo.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("FilterSubscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ipo.Models.FilterSubscription", b =>
                {
                    b.HasOne("ipo.Models.User", "User")
                        .WithOne("FilterSubscription")
                        .HasForeignKey("ipo.Models.FilterSubscription", "FilterSubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ipo.Models.IPOExchange", b =>
                {
                    b.HasOne("ipo.Models.Exchange", "Exchange")
                        .WithMany("IPOExchanges")
                        .HasForeignKey("ExchangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ipo.Models.IPO", "IPO")
                        .WithMany("IPOExchanges")
                        .HasForeignKey("IPOId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exchange");

                    b.Navigation("IPO");
                });

            modelBuilder.Entity("ipo.Models.Subscription", b =>
                {
                    b.HasOne("ipo.Models.IPO", "IPO")
                        .WithOne("Subscription")
                        .HasForeignKey("ipo.Models.Subscription", "IPOId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IPO");
                });

            modelBuilder.Entity("ipo.Models.Exchange", b =>
                {
                    b.Navigation("IPOExchanges");
                });

            modelBuilder.Entity("ipo.Models.IPO", b =>
                {
                    b.Navigation("IPOExchanges");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("ipo.Models.User", b =>
                {
                    b.Navigation("FilterSubscription");
                });
#pragma warning restore 612, 618
        }
    }
}
