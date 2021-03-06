﻿// <auto-generated />
using System;
using ExcelTeamplate.TeamplateDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExcelTeamplate.TeamplateDbContext.Migrations
{
    [DbContext(typeof(TeamplateContext))]
    [Migration("20190618134733_addcolforlog")]
    partial class addcolforlog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExcelTeamplate.Model.Attach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<int>("BId");

                    b.Property<string>("ClientIP");

                    b.Property<string>("FileName");

                    b.Property<string>("FilePath");

                    b.Property<double>("FileSize");

                    b.Property<int>("FileState");

                    b.HasKey("Id");

                    b.ToTable("Attaches");
                });

            modelBuilder.Entity("ExcelTeamplate.Model.Data", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<int>("DataType");

                    b.HasKey("Id");

                    b.ToTable("Datas");
                });

            modelBuilder.Entity("ExcelTeamplate.Model.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<int>("FieldLength");

                    b.Property<string>("FieldName");

                    b.Property<bool>("FieldRequired");

                    b.Property<bool>("FieldState");

                    b.Property<string>("FieldText");

                    b.Property<int>("FieldType");

                    b.HasKey("Id");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("ExcelTeamplate.Model.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionType");

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("ClientIp");

                    b.Property<string>("LogType");

                    b.Property<string>("Remark");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("ExcelTeamplate.Model.Main", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddTime");

                    b.Property<int>("AttachId");

                    b.Property<string>("ClientIP");

                    b.Property<int>("DataId");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.HasIndex("AttachId");

                    b.HasIndex("DataId");

                    b.ToTable("Mains");
                });

            modelBuilder.Entity("ExcelTeamplate.Model.Main", b =>
                {
                    b.HasOne("ExcelTeamplate.Model.Attach", "Attach")
                        .WithMany()
                        .HasForeignKey("AttachId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ExcelTeamplate.Model.Data", "Data")
                        .WithMany()
                        .HasForeignKey("DataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
