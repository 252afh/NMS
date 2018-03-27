// <copyright file="NmsdbContext.cs" company="252afh">
//   Copyright © 252afh 2018. All rights reserved.
// </copyright>

namespace NMS.Models
{
    using AnnouncementViewModels;
    using BarringViewModels;
    using BlockingViewModels;
    using CarrierCodeExceptionViewModels;
    using CarrierCodeViewModels;
    using CarrierNumberExceptionViewModels;
    using CarrierViewModels;
    using CodeViewModels;
    using ContactViewModels;
    using CustomerViewModels;
    using DayDetailsViewModels;
    using ExceptionLcrViewModels;
    using ExceptionNumberViewModels;
    using FeatureCustomerViewModels;
    using FeatureViewModels;
    using GroupTemplateViewModels;
    using IvrActionViewModels;
    using IvrViewModels;
    using LcrViewModels;
    using LogViewModels;
    using MailboxViewModels;
    using Microsoft.EntityFrameworkCore;
    using NumberFormatViewModels;
    using NumberGroupViewModels;
    using NumberTemplateViewModels;
    using NumberViewModels;
    using PeriodViewModels;
    using ReportConfigurationNumberViewModels;
    using ReportConfigurationViewModels;
    using ReportCustomerViewModels;
    using ReportViewModels;
    using RoutingGroupViewModels;
    using RoutingViewModels;
    using SiteViewModels;
    using TemplateViewModels;
    using UserProfilesViewModels;
    using VoiceMessagesViewModels;

    /// <summary>
    /// A context for dependency injection of the nms database
    /// </summary>
    public partial class NmsdbContext : DbContext
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="NmsdbContext"/> class
        /// </summary>
        /// <param name="options">Database context options</param>
        public NmsdbContext(DbContextOptions<NmsdbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets an <see cref="Announcement"/>
        /// </summary>
        public virtual DbSet<Announcement> Announcement { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Barring"/>
        /// </summary>
        public virtual DbSet<Barring> Barring { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Blocking"/>
        /// </summary>
        public virtual DbSet<Blocking> Blocking { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Carrier"/>
        /// </summary>
        public virtual DbSet<Carrier> Carrier { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="CarrierCode"/>
        /// </summary>
        public virtual DbSet<CarrierCode> CarrierCode { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="CarrierCodeException"/>
        /// </summary>
        public virtual DbSet<CarrierCodeException> CarrierCodeException { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="CarrierNumberException"/>
        /// </summary>
        public virtual DbSet<CarrierNumberException> CarrierNumberException { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Code"/>
        /// </summary>
        public virtual DbSet<Code> Code { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Contact"/>
        /// </summary>
        public virtual DbSet<Contact> Contact { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Customer"/>
        /// </summary>
        public virtual DbSet<Customer> Customer { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="Daydetails"/>
        /// </summary>
        public virtual DbSet<Daydetails> Daydetails { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Exceptionlcr> Exceptionlcr { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Exceptionnumber> Exceptionnumber { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Feature> Feature { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<FeatureCustomer> FeatureCustomer { get; set; }
        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<GroupTemplate> GroupTemplate { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Ivr> Ivr { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Ivraction> Ivraction { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Lcr> Lcr { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Log> Log { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Mailbox> Mailbox { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Number> Number { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Numberformat> Numberformat { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Numbergroup> Numbergroup { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<NumberTemplate> NumberTemplate { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Period> Period { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Report> Report { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Reportconfiguration> Reportconfiguration { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<ReportconfigurationNumber> ReportconfigurationNumber { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<ReportCustomer> ReportCustomer { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Routing> Routing { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Routinggroup> Routinggroup { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Site> Site { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Template> Template { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<UserProfiles> UserProfiles { get; set; }

        /// <summary>
        /// Gets or sets 
        /// </summary>
        public virtual DbSet<Voicemessages> Voicemessages { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.HasKey(e => e.Idannouncement);

                entity.ToTable("announcement");

                entity.HasIndex(e => e.FkContact)
                    .HasName("Announcement_ContactFK");

                entity.HasIndex(e => e.FkCustomer)
                    .HasName("Announcement_CustomerFK");

                entity.Property(e => e.Idannouncement)
                    .HasColumnName("idannouncement")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Audiomessage)
                    .IsRequired()
                    .HasColumnName("audiomessage");

                entity.Property(e => e.Audioname)
                    .IsRequired()
                    .HasColumnName("audioname")
                    .HasMaxLength(45);

                entity.Property(e => e.Audiosize)
                    .HasColumnName("audiosize")
                    .HasColumnType("mediumint(9)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.FkContact)
                    .HasColumnName("fkContact")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkCustomer)
                    .HasColumnName("fkCustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.InProgress)
                    .HasColumnName("inProgress")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Repeattimes)
                    .HasColumnName("repeattimes")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Barring>(entity =>
            {
                entity.HasKey(e => e.Idbarring);

                entity.ToTable("barring");

                entity.Property(e => e.Idbarring)
                    .HasColumnName("idbarring")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(20);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100);

                entity.Property(e => e.FkCustomer)
                    .HasColumnName("fkCustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NormalisedCode)
                    .IsRequired()
                    .HasColumnName("normalisedCode")
                    .HasMaxLength(20);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Blocking>(entity =>
            {
                entity.HasKey(e => e.Idblocking);

                entity.ToTable("blocking");

                entity.Property(e => e.Idblocking)
                    .HasColumnName("idblocking")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(20);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100);

                entity.Property(e => e.FkCustomer)
                    .HasColumnName("fkCustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NormalisedCode)
                    .IsRequired()
                    .HasColumnName("normalisedCode")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Carrier>(entity =>
            {
                entity.HasKey(e => e.Idcarrier);

                entity.ToTable("carrier");

                entity.Property(e => e.Idcarrier)
                    .HasColumnName("idcarrier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BillingNumber)
                    .IsRequired()
                    .HasColumnName("billingNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasColumnName("domain")
                    .HasMaxLength(45);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Preference)
                    .HasColumnName("preference")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.RoutingNumber)
                    .IsRequired()
                    .HasColumnName("routingNumber")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<CarrierCode>(entity =>
            {
                entity.HasKey(e => e.IdcarrierCode);

                entity.ToTable("carrier_code");

                entity.HasIndex(e => e.FkCarrier)
                    .HasName("Carrier_LcrCarrier");

                entity.HasIndex(e => e.FkCode)
                    .HasName("Carrier_LcrLcr");

                entity.HasIndex(e => e.FkLcr)
                    .HasName("Carrier_CodeLcr");

                entity.Property(e => e.IdcarrierCode)
                    .HasColumnName("idcarrier_code")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkCarrier)
                    .HasColumnName("fkCarrier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkCode)
                    .HasColumnName("fkCode")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkLcr)
                    .HasColumnName("fkLcr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<CarrierCodeException>(entity =>
            {
                entity.HasKey(e => e.IdcarrierCodeException);

                entity.ToTable("carrier_code_exception");

                entity.HasIndex(e => e.FkCarrier)
                    .HasName("CCE_Carrier");

                entity.HasIndex(e => e.FkCode)
                    .HasName("CCE_Code");

                entity.HasIndex(e => e.FkExceptionLcr)
                    .HasName("CCE_ExceptionLcr");

                entity.Property(e => e.IdcarrierCodeException)
                    .HasColumnName("idcarrier_code_exception")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkCarrier)
                    .HasColumnName("fkCarrier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkCode)
                    .HasColumnName("fkCode")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkExceptionLcr)
                    .HasColumnName("fkExceptionLcr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<CarrierNumberException>(entity =>
            {
                entity.HasKey(e => e.IdcarrierNumberException);

                entity.ToTable("carrier_number_exception");

                entity.HasIndex(e => e.FkCarrier)
                    .HasName("Carrier_CNE");

                entity.HasIndex(e => e.FkExceptionLcr)
                    .HasName("ExceptionLcr_CNE");

                entity.HasIndex(e => e.FkExceptionNumber)
                    .HasName("ExceptionNumber_CNE");

                entity.Property(e => e.IdcarrierNumberException)
                    .HasColumnName("idcarrier_number_exception")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkCarrier)
                    .HasColumnName("fkCarrier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkExceptionLcr)
                    .HasColumnName("fkExceptionLcr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkExceptionNumber)
                    .HasColumnName("fkExceptionNumber")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Code>(entity =>
            {
                entity.HasKey(e => e.Idcode);

                entity.ToTable("code");

                entity.Property(e => e.Idcode)
                    .HasColumnName("idcode")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.DialledNumber)
                    .IsRequired()
                    .HasColumnName("dialledNumber")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Idcontact);

                entity.ToTable("contact");

                entity.HasIndex(e => e.FkCustomer)
                    .HasName("fkCustomer");

                entity.HasIndex(e => e.FkSite)
                    .HasName("ContactSite");

                entity.Property(e => e.Idcontact)
                    .HasColumnName("idcontact")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.FkCustomer)
                    .HasColumnName("fkCustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkSite)
                    .HasColumnName("fkSite")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phoneNumber")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Idcustomer);

                entity.ToTable("customer");

                entity.HasIndex(e => e.FkExceptionLcr)
                    .HasName("Customer_ExceptionLcr");

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idcustomer)
                    .HasColumnName("idcustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BlockAnonymous)
                    .HasColumnName("blockAnonymous")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Customercol)
                    .HasColumnName("customercol")
                    .HasMaxLength(45);

                entity.Property(e => e.DefaultBillingNumber)
                    .HasColumnName("defaultBillingNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.FkExceptionLcr)
                    .HasColumnName("fkExceptionLcr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);

                entity.Property(e => e.NonGeo)
                    .HasColumnName("nonGeo")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.RoutingNumber)
                    .HasColumnName("routingNumber")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Daydetails>(entity =>
            {
                entity.HasKey(e => e.IddayDetails);

                entity.ToTable("daydetails");

                entity.HasIndex(e => e.FkPeriod)
                    .HasName("period_dayDetails");

                entity.Property(e => e.IddayDetails)
                    .HasColumnName("iddayDetails")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Day)
                    .HasColumnName("day")
                    .HasMaxLength(10);

                entity.Property(e => e.FkPeriod)
                    .HasColumnName("fkPeriod")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TimeFrom)
                    .HasColumnName("timeFrom")
                    .HasColumnType("time");

                entity.Property(e => e.TimeTo)
                    .HasColumnName("timeTo")
                    .HasColumnType("time");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId);

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(95);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Exceptionlcr>(entity =>
            {
                entity.HasKey(e => e.IdexceptionLcr);

                entity.ToTable("exceptionlcr");

                entity.Property(e => e.IdexceptionLcr)
                    .HasColumnName("idexceptionLcr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(45);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Exceptionnumber>(entity =>
            {
                entity.HasKey(e => e.IdexceptionNumber);

                entity.ToTable("exceptionnumber");

                entity.Property(e => e.IdexceptionNumber)
                    .HasColumnName("idexceptionNumber")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.HasKey(e => e.Idfeature);

                entity.ToTable("feature");

                entity.HasIndex(e => e.Code)
                    .HasName("code_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idfeature)
                    .HasColumnName("idfeature")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(45);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<FeatureCustomer>(entity =>
            {
                entity.HasKey(e => e.IdfeatureCustomer);

                entity.ToTable("feature_customer");

                entity.HasIndex(e => e.FkCustomer)
                    .HasName("featureCustomer_Customer");

                entity.HasIndex(e => e.FkFeature)
                    .HasName("featureCustomer_FeatureFK");

                entity.Property(e => e.IdfeatureCustomer)
                    .HasColumnName("idfeature_customer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("dateFrom")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateTo)
                    .HasColumnName("dateTo")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkCustomer)
                    .HasColumnName("fkCustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkFeature)
                    .HasColumnName("fkFeature")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<GroupTemplate>(entity =>
            {
                entity.HasKey(e => e.IdgroupTemplate);

                entity.ToTable("group_template");

                entity.HasIndex(e => e.FkGroup)
                    .HasName("Group_GroupTemplate");

                entity.HasIndex(e => e.FkRoutingGroup)
                    .HasName("RoutingGroup_GroupTemplate");

                entity.HasIndex(e => e.FkTemplate)
                    .HasName("Template_GroupTemplate");

                entity.Property(e => e.IdgroupTemplate)
                    .HasColumnName("idgroupTemplate")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkGroup)
                    .HasColumnName("fkGroup")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkRoutingGroup)
                    .HasColumnName("fkRoutingGroup")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkTemplate)
                    .HasColumnName("fkTemplate")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Ivr>(entity =>
            {
                entity.HasKey(e => e.Idivr);

                entity.ToTable("ivr");

                entity.HasIndex(e => e.FkCustomer)
                    .HasName("Ivr_CustomerFK");

                entity.Property(e => e.Idivr)
                    .HasColumnName("idivr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Audiomessage).HasColumnName("audiomessage");

                entity.Property(e => e.Audioname)
                    .HasColumnName("audioname")
                    .HasMaxLength(45);

                entity.Property(e => e.Audiosize)
                    .HasColumnName("audiosize")
                    .HasColumnType("mediumint(9)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.FkCustomer)
                    .HasColumnName("fkCustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Repeattimes)
                    .HasColumnName("repeattimes")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Timeout)
                    .HasColumnName("timeout")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'2'");
            });

            modelBuilder.Entity<Ivraction>(entity =>
            {
                entity.HasKey(e => new { e.Idivraction, e.Digit });

                entity.ToTable("ivraction");

                entity.HasIndex(e => e.FkAnnouncementDest)
                    .HasName("fk_announcementDest_ivraction");

                entity.HasIndex(e => e.FkContactDest)
                    .HasName("fk_contactDest_ivraction");

                entity.HasIndex(e => e.FkIvr)
                    .HasName("fk_ivr_ivraction");

                entity.HasIndex(e => e.FkIvrDest)
                    .HasName("fk_ivrDest_ivraction");

                entity.HasIndex(e => e.FkMailboxDest)
                    .HasName("fk_mailboxDest_ivraction");

                entity.Property(e => e.Idivraction)
                    .HasColumnName("idivraction")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Digit)
                    .HasColumnName("digit")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkAnnouncementDest)
                    .HasColumnName("fkAnnouncementDest")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkContactDest)
                    .HasColumnName("fkContactDest")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkIvr)
                    .HasColumnName("fkIvr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkIvrDest)
                    .HasColumnName("fkIvrDest")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkMailboxDest)
                    .HasColumnName("fkMailboxDest")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VoicemailMain)
                    .HasColumnName("voicemailMain")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Lcr>(entity =>
            {
                entity.HasKey(e => e.Idlcr);

                entity.ToTable("lcr");

                entity.Property(e => e.Idlcr)
                    .HasColumnName("idlcr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.Idlog);

                entity.ToTable("log");

                entity.HasIndex(e => e.FkUser)
                    .HasName("Log_Users");

                entity.Property(e => e.Idlog)
                    .HasColumnName("idlog")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasColumnName("action")
                    .HasMaxLength(45);

                entity.Property(e => e.Attribute)
                    .HasColumnName("attribute")
                    .HasMaxLength(45);

                entity.Property(e => e.FkUser)
                    .HasColumnName("fkUser")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdModified)
                    .HasColumnName("idModified")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NewValue)
                    .HasColumnName("newValue")
                    .HasMaxLength(100);

                entity.Property(e => e.Table)
                    .IsRequired()
                    .HasColumnName("table")
                    .HasMaxLength(45);

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.Entity<Mailbox>(entity =>
            {
                entity.HasKey(e => e.Idmailbox);

                entity.ToTable("mailbox");

                entity.HasIndex(e => e.FkCustomer)
                    .HasName("Mailbox_CustomerFK");

                entity.HasIndex(e => e.FkNumber)
                    .HasName("Mailbox_NumberFK");

                entity.Property(e => e.Idmailbox)
                    .HasColumnName("idmailbox")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Attachment)
                    .HasColumnName("attachment")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Audiomessage).HasColumnName("audiomessage");

                entity.Property(e => e.Audioname)
                    .HasColumnName("audioname")
                    .HasMaxLength(45);

                entity.Property(e => e.Audiosize)
                    .HasColumnName("audiosize")
                    .HasColumnType("mediumint(9)");

                entity.Property(e => e.DeleteOpt)
                    .HasColumnName("deleteOpt")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FkCustomer)
                    .HasColumnName("fkCustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkNumber)
                    .HasColumnName("fkNumber")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);

                entity.Property(e => e.Pin)
                    .HasColumnName("pin")
                    .HasColumnType("int(4)");

                entity.Property(e => e.SendEmail)
                    .HasColumnName("sendEmail")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<Number>(entity =>
            {
                entity.HasKey(e => e.Idnumber);

                entity.ToTable("number");

                entity.HasIndex(e => e.FkCustomer)
                    .HasName("NumberCustomer");

                entity.HasIndex(e => e.FkGroup)
                    .HasName("NumberGroup");

                entity.HasIndex(e => e.Number1)
                    .HasName("number_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idnumber)
                    .HasColumnName("idnumber")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ActiveDate)
                    .HasColumnName("activeDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CeaseDate)
                    .HasColumnName("ceaseDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerDescription)
                    .HasColumnName("customerDescription")
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.FkCustomer)
                    .HasColumnName("fkCustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkGroup)
                    .HasColumnName("fkGroup")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Number1)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Numberformat>(entity =>
            {
                entity.HasKey(e => e.IdnumberFormat);

                entity.ToTable("numberformat");

                entity.Property(e => e.IdnumberFormat)
                    .HasColumnName("idnumberFormat")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.NumberFormat)
                    .IsRequired()
                    .HasColumnName("numberFormat")
                    .HasMaxLength(3);
            });

            modelBuilder.Entity<Numbergroup>(entity =>
            {
                entity.HasKey(e => e.Idgroup);

                entity.ToTable("numbergroup");

                entity.HasIndex(e => e.FkCustomer)
                    .HasName("GroupCustomer");

                entity.Property(e => e.Idgroup)
                    .HasColumnName("idgroup")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.FkCustomer)
                    .HasColumnName("fkCustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<NumberTemplate>(entity =>
            {
                entity.HasKey(e => e.IdnumberTemplate);

                entity.ToTable("number_template");

                entity.HasIndex(e => e.FkNumber)
                    .HasName("RoutingNumber");

                entity.HasIndex(e => e.FkRoutingGroup)
                    .HasName("NumberTemplateRoutingGroup");

                entity.HasIndex(e => e.FkTemplate)
                    .HasName("RoutingTemplate");

                entity.Property(e => e.IdnumberTemplate)
                    .HasColumnName("idnumberTemplate")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkNumber)
                    .HasColumnName("fkNumber")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkRoutingGroup)
                    .HasColumnName("fkRoutingGroup")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkTemplate)
                    .HasColumnName("fkTemplate")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Period>(entity =>
            {
                entity.HasKey(e => e.Idperiod);

                entity.ToTable("period");

                entity.HasIndex(e => e.FkTemplate)
                    .HasName("PeriodTemplate");

                entity.Property(e => e.Idperiod)
                    .HasColumnName("idperiod")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Day)
                    .HasColumnName("day")
                    .HasMaxLength(45);

                entity.Property(e => e.FkTemplate)
                    .HasColumnName("fkTemplate")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Frequency)
                    .HasColumnName("frequency")
                    .HasMaxLength(45);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TimeFrom)
                    .HasColumnName("timeFrom")
                    .HasColumnType("time");

                entity.Property(e => e.TimeTo)
                    .HasColumnName("timeTo")
                    .HasColumnType("time");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => e.Idreport);

                entity.ToTable("report");

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idreport)
                    .HasColumnName("idreport")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Reportconfiguration>(entity =>
            {
                entity.HasKey(e => e.IdreportConfiguration);

                entity.ToTable("reportconfiguration");

                entity.HasIndex(e => e.FkCustomer)
                    .HasName("fk_customer_reportconfiguration");

                entity.HasIndex(e => e.FkUserProfile)
                    .HasName("fk_userprofiles_reportconfiguration");

                entity.Property(e => e.IdreportConfiguration)
                    .HasColumnName("idreportConfiguration")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.FkCustomer)
                    .HasColumnName("fkCustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkUserProfile)
                    .HasColumnName("fkUserProfile")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<ReportconfigurationNumber>(entity =>
            {
                entity.HasKey(e => e.IdreportconfigurationNumber);

                entity.ToTable("reportconfiguration_number");

                entity.HasIndex(e => e.FkNumber)
                    .HasName("fk_number_rcn");

                entity.HasIndex(e => e.FkReportConfiguration)
                    .HasName("fk_reportconfiguration_rcn");

                entity.Property(e => e.IdreportconfigurationNumber)
                    .HasColumnName("idreportconfiguration_number")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkNumber)
                    .HasColumnName("fkNumber")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkReportConfiguration)
                    .HasColumnName("fkReportConfiguration")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<ReportCustomer>(entity =>
            {
                entity.HasKey(e => e.IdreportCustomer);

                entity.ToTable("report_customer");

                entity.Property(e => e.IdreportCustomer)
                    .HasColumnName("idreport_customer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.FkCustomer)
                    .HasColumnName("fkCustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkReport)
                    .HasColumnName("fkReport")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkReportConfiguration)
                    .HasColumnName("fkReportConfiguration")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Frequency)
                    .IsRequired()
                    .HasColumnName("frequency")
                    .HasMaxLength(45);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Routing>(entity =>
            {
                entity.HasKey(e => e.Idrouting);

                entity.ToTable("routing");

                entity.HasIndex(e => e.FkContact)
                    .HasName("ContactRouting");

                entity.HasIndex(e => e.FkRoutingGroup)
                    .HasName("RoutingGroupRouting");

                entity.HasIndex(e => e.FkSite)
                    .HasName("SiteRouting");

                entity.Property(e => e.Idrouting)
                    .HasColumnName("idrouting")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkAnnouncement)
                    .HasColumnName("fkAnnouncement")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkContact)
                    .HasColumnName("fkContact")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkIvr)
                    .HasColumnName("fkIvr")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkMailbox)
                    .HasColumnName("fkMailbox")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkRoutingGroup)
                    .HasColumnName("fkRoutingGroup")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkSite)
                    .HasColumnName("fkSite")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HuntBusy)
                    .HasColumnName("huntBusy")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RingingTime)
                    .HasColumnName("ringingTime")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VoicemailMain)
                    .HasColumnName("voicemailMain")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Routinggroup>(entity =>
            {
                entity.HasKey(e => e.IdroutingGroup);

                entity.ToTable("routinggroup");

                entity.HasIndex(e => e.FkCustomer)
                    .HasName("RoutingGroupCustomer");

                entity.Property(e => e.IdroutingGroup)
                    .HasColumnName("idroutingGroup")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.FkCustomer)
                    .HasColumnName("fkCustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Forking)
                    .HasColumnName("forking")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsUserGenerated)
                    .HasColumnName("isUserGenerated")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.HasKey(e => e.Idsite);

                entity.ToTable("site");

                entity.HasIndex(e => e.FkCustomer)
                    .HasName("SiteCustomer");

                entity.HasIndex(e => e.FkNumberFormat)
                    .HasName("SiteNumberFormat");

                entity.Property(e => e.Idsite)
                    .HasColumnName("idsite")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.Domain)
                    .IsRequired()
                    .HasColumnName("domain")
                    .HasMaxLength(45);

                entity.Property(e => e.FkCustomer)
                    .HasColumnName("fkCustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkNumberFormat)
                    .HasColumnName("fkNumberFormat")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.HasKey(e => e.Idtemplate);

                entity.ToTable("template");

                entity.HasIndex(e => e.FkCustomer)
                    .HasName("templateCustomer");

                entity.Property(e => e.Idtemplate)
                    .HasColumnName("idtemplate")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200);

                entity.Property(e => e.FkCustomer)
                    .HasColumnName("fkCustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<UserProfiles>(entity =>
            {
                entity.HasKey(e => e.Iduser);

                entity.ToTable("user_profiles");

                entity.HasIndex(e => e.Idcustomer)
                    .HasName("UserProfiles_Customer");

                entity.HasIndex(e => e.Iduser)
                    .HasName("UserProfiles_User");

                entity.Property(e => e.Iduser)
                    .HasColumnName("iduser")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idcustomer)
                    .HasColumnName("idcustomer")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(45);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Voicemessages>(entity =>
            {
                entity.ToTable("voicemessages");

                entity.HasIndex(e => e.Dir)
                    .HasName("dir");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Callerid)
                    .HasColumnName("callerid")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Context)
                    .HasColumnName("context")
                    .HasMaxLength(80)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Dir)
                    .HasColumnName("dir")
                    .HasMaxLength(80)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasMaxLength(20)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Flag)
                    .HasColumnName("flag")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Macrocontext)
                    .HasColumnName("macrocontext")
                    .HasMaxLength(80)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Mailboxcontext)
                    .HasColumnName("mailboxcontext")
                    .HasMaxLength(80)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Mailboxuser)
                    .HasColumnName("mailboxuser")
                    .HasMaxLength(80)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MsgId)
                    .HasColumnName("msg_id")
                    .HasMaxLength(80)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Msgnum)
                    .HasColumnName("msgnum")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Origtime)
                    .HasColumnName("origtime")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Recording).HasColumnName("recording");
            });
        }
    }
}
