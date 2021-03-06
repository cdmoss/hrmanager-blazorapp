﻿// <auto-generated />
using System;
using HRManager.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRManager.Api.Migrations
{
    [DbContext(typeof(MainContext))]
    [Migration("20210225013131_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("HRManager.Common.Alert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AlertType")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Read")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Alerts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Alert");
                });

            modelBuilder.Entity("HRManager.Common.Availability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AvailableDay")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Availabilities");
                });

            modelBuilder.Entity("HRManager.Common.MemberPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Association")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PositionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("PositionId");

                    b.ToTable("MemberPositions");
                });

            modelBuilder.Entity("HRManager.Common.MemberProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("AlternatePhone1")
                        .HasColumnType("TEXT");

                    b.Property<string>("AlternatePhone2")
                        .HasColumnType("TEXT");

                    b.Property<int>("ApprovalStatus")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ChildWelfareCheck")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("ConfirmationOfProfessionalDesignation")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CriminalRecordCheck")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DrivingAbstract")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EducationTraining")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmergencyFullName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmergencyPhone1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("EmergencyPhone2")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmergencyRelationship")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Experience")
                        .HasColumnType("TEXT");

                    b.Property<bool>("FirstAidCpr")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("FirstAidCprExpiry")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstAidCprLevel")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("FoodSafe")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("FoodSafeExpiry")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsStaff")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MainPhone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherBoards")
                        .HasColumnType("TEXT");

                    b.Property<string>("OtherCertificates")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SkillsInterestsHobbies")
                        .HasColumnType("TEXT");

                    b.Property<bool>("VolunteerConfidentiality")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("VolunteerEthics")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("HRManager.Common.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("HRManager.Common.Reference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Occupation")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Relationship")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("References");
                });

            modelBuilder.Entity("HRManager.Common.Reminder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("HangfireJobId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ShiftDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ShiftId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("HRManager.Common.Shift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAllDay")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBlock")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsRecurrence")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MemberProfileId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PositionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RecurrenceException")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RecurrenceID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RecurrenceRule")
                        .HasColumnType("TEXT");

                    b.Property<string>("Resource")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Subject")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MemberProfileId");

                    b.HasIndex("PositionId");

                    b.ToTable("Shifts");
                });

            modelBuilder.Entity("HRManager.Common.TimeEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PositionId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("PositionId");

                    b.ToTable("TimeEntries");
                });

            modelBuilder.Entity("HRManager.Common.WorkExperience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContactPerson")
                        .HasColumnType("TEXT");

                    b.Property<bool>("CurrentJob")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmployerAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmployerPhone")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MemberId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PositionWorked")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("WorkExperiences");
                });

            modelBuilder.Entity("HRManager.Common.ApplicationAlert", b =>
                {
                    b.HasBaseType("HRManager.Common.Alert");

                    b.HasDiscriminator().HasValue("ApplicationAlert");
                });

            modelBuilder.Entity("HRManager.Common.ShiftRequestAlert", b =>
                {
                    b.HasBaseType("HRManager.Common.Alert");

                    b.Property<string>("AddressedBy")
                        .HasColumnType("TEXT");

                    b.Property<bool>("DismissedByAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("DismissedByMember")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OriginalShiftId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Reason")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RequestedShiftId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasIndex("OriginalShiftId");

                    b.HasIndex("RequestedShiftId");

                    b.HasDiscriminator().HasValue("ShiftRequestAlert");
                });

            modelBuilder.Entity("HRManager.Common.Alert", b =>
                {
                    b.HasOne("HRManager.Common.MemberProfile", "Member")
                        .WithMany("Alerts")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Member");
                });

            modelBuilder.Entity("HRManager.Common.Availability", b =>
                {
                    b.HasOne("HRManager.Common.MemberProfile", "Member")
                        .WithMany("Availabilities")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Member");
                });

            modelBuilder.Entity("HRManager.Common.MemberPosition", b =>
                {
                    b.HasOne("HRManager.Common.MemberProfile", "Member")
                        .WithMany("Positions")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HRManager.Common.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Member");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("HRManager.Common.Reference", b =>
                {
                    b.HasOne("HRManager.Common.MemberProfile", "Member")
                        .WithMany("References")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Member");
                });

            modelBuilder.Entity("HRManager.Common.Shift", b =>
                {
                    b.HasOne("HRManager.Common.MemberProfile", "Member")
                        .WithMany("Shifts")
                        .HasForeignKey("MemberProfileId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("HRManager.Common.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.Navigation("Member");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("HRManager.Common.TimeEntry", b =>
                {
                    b.HasOne("HRManager.Common.MemberProfile", "Member")
                        .WithMany("TimeEntries")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRManager.Common.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("HRManager.Common.WorkExperience", b =>
                {
                    b.HasOne("HRManager.Common.MemberProfile", "Member")
                        .WithMany("WorkExperiences")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Member");
                });

            modelBuilder.Entity("HRManager.Common.ShiftRequestAlert", b =>
                {
                    b.HasOne("HRManager.Common.Shift", "OriginalShift")
                        .WithMany()
                        .HasForeignKey("OriginalShiftId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("HRManager.Common.Shift", "RequestedShift")
                        .WithMany()
                        .HasForeignKey("RequestedShiftId");

                    b.Navigation("OriginalShift");

                    b.Navigation("RequestedShift");
                });

            modelBuilder.Entity("HRManager.Common.MemberProfile", b =>
                {
                    b.Navigation("Alerts");

                    b.Navigation("Availabilities");

                    b.Navigation("Positions");

                    b.Navigation("References");

                    b.Navigation("Shifts");

                    b.Navigation("TimeEntries");

                    b.Navigation("WorkExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}
