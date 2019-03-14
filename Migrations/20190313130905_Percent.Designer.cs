﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Send_and_track.Data;

namespace Send_and_track.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190313130905_Percent")]
    partial class Percent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Send_and_track.models.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("BinaryFile");

                    b.Property<int>("EmailId");

                    b.Property<bool>("IsOpened");

                    b.Property<decimal>("Percent");

                    b.Property<int>("TotalPage");

                    b.HasKey("Id");

                    b.HasIndex("EmailId");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("Send_and_track.models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<string>("SendTo");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("Send_and_track.models.Attachment", b =>
                {
                    b.HasOne("Send_and_track.models.Email", "Email")
                        .WithMany()
                        .HasForeignKey("EmailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
