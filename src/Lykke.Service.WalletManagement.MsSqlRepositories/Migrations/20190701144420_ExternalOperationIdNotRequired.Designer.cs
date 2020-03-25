﻿// <auto-generated />
using System;
using Lykke.Service.WalletManagement.MsSqlRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lykke.Service.WalletManagement.MsSqlRepositories.Migrations
{
    [DbContext(typeof(WalletManagementContext))]
    [Migration("20190701144420_ExternalOperationIdNotRequired")]
    partial class ExternalOperationIdNotRequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("wallet_management")
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lykke.Service.WalletManagement.MsSqlRepositories.Entities.BonusIssuedEventDataEntity", b =>
                {
                    b.Property<Guid>("OperationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("operation_id");

                    b.Property<long>("Amount")
                        .HasColumnName("amount");

                    b.Property<string>("BonusType")
                        .HasColumnName("bonus_type");

                    b.Property<Guid>("CampaignId")
                        .HasColumnName("campaign_id");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnName("customer_id");

                    b.Property<string>("PartnerId")
                        .HasColumnName("partner_id");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnName("timestamp");

                    b.HasKey("OperationId");

                    b.ToTable("bonus_event_data");
                });

            modelBuilder.Entity("Lykke.Service.WalletManagement.MsSqlRepositories.Entities.TransferEventDataEntity", b =>
                {
                    b.Property<string>("TransactionHash")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("transaction_hash");

                    b.Property<long>("Amount")
                        .HasColumnName("amount");

                    b.Property<string>("AssetSymbol")
                        .IsRequired()
                        .HasColumnName("asset_symbol");

                    b.Property<string>("ExternalOperationId")
                        .HasColumnName("external_operation_id");

                    b.Property<string>("RecipientCustomerId")
                        .IsRequired()
                        .HasColumnName("recipient_customer_id");

                    b.Property<string>("SenderCustomerId")
                        .IsRequired()
                        .HasColumnName("sender_customer_id");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnName("timestamp");

                    b.HasKey("TransactionHash");

                    b.ToTable("transfer_event_data");
                });
#pragma warning restore 612, 618
        }
    }
}
