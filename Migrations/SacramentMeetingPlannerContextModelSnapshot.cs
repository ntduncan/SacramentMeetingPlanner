﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    [DbContext(typeof(SacramentMeetingPlannerContext))]
    partial class SacramentMeetingPlannerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Hymn", b =>
                {
                    b.Property<int>("HymnID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("HymnNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("HymnTitle")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HymnType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("HymnID");

                    b.ToTable("Hymn");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.SacramentMeetingProgram", b =>
                {
                    b.Property<int>("SacramentMeetingProgramID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClosingHymnID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClosingPrayer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("ConductingLeader")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int?>("IntermediateHymnID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OpeningHymnID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OpeningPrayer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("SacramentHymnID")
                        .HasColumnType("INTEGER");

                    b.HasKey("SacramentMeetingProgramID");

                    b.HasIndex("ClosingHymnID");

                    b.HasIndex("IntermediateHymnID");

                    b.HasIndex("OpeningHymnID");

                    b.HasIndex("SacramentHymnID");

                    b.ToTable("SacramentMeetingProgram");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speaker", b =>
                {
                    b.Property<int>("SpeakerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int?>("SacramentMeetingProgramID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("SpeakerID");

                    b.HasIndex("SacramentMeetingProgramID");

                    b.ToTable("Speaker");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.SacramentMeetingProgram", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "ClosingHymn")
                        .WithMany()
                        .HasForeignKey("ClosingHymnID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "IntermediateHymn")
                        .WithMany()
                        .HasForeignKey("IntermediateHymnID");

                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "OpeningHymn")
                        .WithMany()
                        .HasForeignKey("OpeningHymnID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "SacramentHymn")
                        .WithMany()
                        .HasForeignKey("SacramentHymnID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClosingHymn");

                    b.Navigation("IntermediateHymn");

                    b.Navigation("OpeningHymn");

                    b.Navigation("SacramentHymn");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speaker", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.SacramentMeetingProgram", null)
                        .WithMany("Speakers")
                        .HasForeignKey("SacramentMeetingProgramID");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.SacramentMeetingProgram", b =>
                {
                    b.Navigation("Speakers");
                });
#pragma warning restore 612, 618
        }
    }
}
