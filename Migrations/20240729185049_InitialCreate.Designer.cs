﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using webapi.Data;

#nullable disable

namespace webapi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240729185049_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("webapi.Models.Campain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Campain");
                });

            modelBuilder.Entity("webapi.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CampainId")
                        .HasColumnType("integer");

                    b.Property<int>("Charisma")
                        .HasColumnType("integer");

                    b.Property<int>("Constitution")
                        .HasColumnType("integer");

                    b.Property<int>("Dexterity")
                        .HasColumnType("integer");

                    b.Property<int>("Intelligence")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("RaceId")
                        .HasColumnType("integer");

                    b.Property<int>("Streangth")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("Wisdom")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CampainId");

                    b.HasIndex("RaceId");

                    b.HasIndex("UserId");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("webapi.Models.CharacterHasSpells", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("integer");

                    b.Property<bool>("Known")
                        .HasColumnType("boolean");

                    b.Property<bool>("Prepared")
                        .HasColumnType("boolean");

                    b.Property<int>("SpellId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("SpellId");

                    b.ToTable("CharacterHasSpells");
                });

            modelBuilder.Entity("webapi.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("SpellId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SpellId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("webapi.Models.ClassHasSpells", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("integer");

                    b.Property<int>("SpellId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("SpellId");

                    b.ToTable("ClassHasSpells");
                });

            modelBuilder.Entity("webapi.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Feature");
                });

            modelBuilder.Entity("webapi.Models.HasFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("ClassFeature")
                        .HasColumnType("boolean");

                    b.Property<int?>("ClassId")
                        .HasColumnType("integer");

                    b.Property<int>("FeatureId")
                        .HasColumnType("integer");

                    b.Property<bool>("RaceFeature")
                        .HasColumnType("boolean");

                    b.Property<int?>("RaceId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("FeatureId");

                    b.HasIndex("RaceId");

                    b.ToTable("HasFeature");
                });

            modelBuilder.Entity("webapi.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Race");
                });

            modelBuilder.Entity("webapi.Models.Spell", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Spell");
                });

            modelBuilder.Entity("webapi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("webapi.Models.Campain", b =>
                {
                    b.HasOne("webapi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("webapi.Models.Character", b =>
                {
                    b.HasOne("webapi.Models.Campain", "Campain")
                        .WithMany()
                        .HasForeignKey("CampainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campain");

                    b.Navigation("Race");

                    b.Navigation("User");
                });

            modelBuilder.Entity("webapi.Models.CharacterHasSpells", b =>
                {
                    b.HasOne("webapi.Models.Character", null)
                        .WithMany("CharacterHasSpells")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.Spell", null)
                        .WithMany("CharacterHasSpells")
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("webapi.Models.Class", b =>
                {
                    b.HasOne("webapi.Models.Spell", "Spell")
                        .WithMany()
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Spell");
                });

            modelBuilder.Entity("webapi.Models.ClassHasSpells", b =>
                {
                    b.HasOne("webapi.Models.Class", null)
                        .WithMany("ClassHasSpells")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.Spell", null)
                        .WithMany("ClassHasSpells")
                        .HasForeignKey("SpellId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("webapi.Models.HasFeature", b =>
                {
                    b.HasOne("webapi.Models.Class", null)
                        .WithMany("HasFeature")
                        .HasForeignKey("ClassId");

                    b.HasOne("webapi.Models.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webapi.Models.Race", null)
                        .WithMany("HasFeature")
                        .HasForeignKey("RaceId");

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("webapi.Models.Character", b =>
                {
                    b.Navigation("CharacterHasSpells");
                });

            modelBuilder.Entity("webapi.Models.Class", b =>
                {
                    b.Navigation("ClassHasSpells");

                    b.Navigation("HasFeature");
                });

            modelBuilder.Entity("webapi.Models.Race", b =>
                {
                    b.Navigation("HasFeature");
                });

            modelBuilder.Entity("webapi.Models.Spell", b =>
                {
                    b.Navigation("CharacterHasSpells");

                    b.Navigation("ClassHasSpells");
                });
#pragma warning restore 612, 618
        }
    }
}
