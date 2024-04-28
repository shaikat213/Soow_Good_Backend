using Microsoft.EntityFrameworkCore;
using SignalRTieredDemo.Users;
using SoowGoodWeb.Models;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace SoowGoodWeb.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class SoowGoodWebDbContext :
    AbpDbContext<SoowGoodWebDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    public DbSet<AppUser> SgUsers { get; set; }
    //SoowGood Database Models
    #region Entities from SoowGood Modules

    public DbSet<Otp> SgOtps { get; set; }
    public DbSet<Degree> SgDegrees { get; set; }
    public DbSet<Speciality> SgSpecialities { get; set; }
    public DbSet<Specialization> SgSpecializations { get; set; }
    public DbSet<DoctorProfile> SgDoctorProfiles { get; set; }
    public DbSet<DoctorDegree> SgDoctorDegrees { get; set; }    
    public DbSet<DoctorSpecialization> SgDoctorSpecializations { get; set; }    
    public DbSet<DoctorChamber> SgDoctorChambers { get; set; }
    public DbSet<DoctorSchedule> SgDoctorSchedules { get; set; }
    public DbSet<DoctorScheduledDayOff> SgDoctorScheduledDayOffs { get; set; }
    public DbSet<DoctorScheduleDaySession> SgDoctorScheduleDaySessions { get; set; }
    public DbSet<DoctorFeesSetup> SgDoctorFees { get; set; }
    public DbSet<DocumentsAttachment> SgDocumentsAttachments { get; set; }
    public DbSet<AgentProfile> SgAgentProfiles { get; set; }
    public DbSet<PatientProfile> SgPatientProfiles { get; set; }
    public DbSet<Appointment> SgAppointments { get; set; }
    public DbSet<PaymentHistory> SgPaymentHistory { get; set; }
    public DbSet<DrugRx> SgDrugRx { get; set; }
    public DbSet<CommonDisease> SgCommonDiseases { get; set; }
    public DbSet<PrescriptionMaster> SgPrescriptionMaster { get; set; }
    public DbSet<PrescriptionMainComplaint> SgPrescriptionMainComplaints { get; set; }
    public DbSet<PrescriptionFindingsObservations> SgPrescriptionFindingsObservations { get; set; }
    public DbSet<PrescriptionMedicalCheckups> SgPrescriptionMedicalCheckups { get; set; }
    public DbSet<PrescriptionPatientDiseaseHistory> SgPrescriptionPatientDiseaseHistory { get; set; }
    public DbSet<PrescriptionDrugDetails> SgPrescriptionDrugDetails { get; set; }
    public DbSet<AgentMaster> SgAgentMasters { get; set; }
    public DbSet<AgentSupervisor> SgAgentSupervisors { get; set; }
    public DbSet<PlatformFacility> SgPlatformFacilities { get; set; }
    public DbSet<FinancialSetup> SgFinancialSetups { get; set; }
    public DbSet<UserDataDeleteRequest> SgUserDataDeleteRequests { get; set; }
    public DbSet<ServiceProvider> SgServiceProviders { get; set; }
    public DbSet<DiagonsticTest> SgDiagonsticTests { get; set; }
    public DbSet<DiagonsticPackage> SgDiagonsticPackages { get; set; }
    public DbSet<DiagonsticPackageTest> SgDiagonsticPackageTests { get; set; }
    public DbSet<DiagonsticPathologyServiceManagement> SgDiagonsticPathologyServiceManagements { get; set; }
    public DbSet<PathologyCategory> SgPathologyCategory { get; set; }
    public DbSet<PathologyTest> SgPathologyTests { get; set; }
    public DbSet<DiagonsticTestRequested> SgDiagonsticTestRequested { get; set; }
    public DbSet<Notification> SgNotification { get; set; }

    #endregion

    public SoowGoodWebDbContext(DbContextOptions<SoowGoodWebDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(SoowGoodWebConsts.DbTablePrefix + "YourEntities", SoowGoodWebConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
