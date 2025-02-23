using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.SignalR;
using EnglishLearning.Data;
using EnglishLearning.Models.Identity.Services;
using EnglishLearning.Models.Identity;
using EnglishLearning.Models.Identity.Repositery;
using EnglishLearning.Repository;
using EnglishLearning.Hubs;
using EnglishLearning.Models.Identity.USerr;

namespace EnglishLearning
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Settings to send email 
          
            // services.AddSignalR();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddRazorPages().AddRazorRuntimeCompilation();


            //services.AddIdentity<IdentityUser, IdentityRole>()
            //  .AddDefaultTokenProviders().AddDefaultUI()
            //  .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>(
             option =>
             {
                 option.Password.RequireUppercase = false;
                 option.Password.RequiredLength = 4;
                 option.Password.RequireDigit = false;
                 option.SignIn.RequireConfirmedAccount = false;
             })
            .AddDefaultTokenProviders().AddDefaultUI()
            .AddEntityFrameworkStores<ApplicationDbContext>();

          
            services.AddControllersWithViews();
           // services.AddSingleton<IEmailSender, EmailSender>();
           //  services.AdHttpContextAccessor();
            services.AddSession(
              options => {
                  options.Cookie.IsEssential = true;
                  options.IdleTimeout = TimeSpan.FromMinutes(10);
                  options.Cookie.HttpOnly = true;
              });
 
            services.AddScoped<IRepositery, RepositeryUser>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IVideoRepository, VideoRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<IAudioRepository, AudioRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IBAox,basketRepo>();
            services.AddScoped<Iadmainstrator, admainstrator>();

            services.AddScoped<IQuestionRepoistory, QuestionRepoistory>();
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<ITrueAndFalseRepository, TrueAndFalseRepository>();
            services.AddScoped<IMCQRepository, MCQRepository>();
            services.AddScoped<IRateRepository, RateRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

            //services.AddTransient<IEmailSender, EmailSender>();
            services.AddAuthentication();
            services.AddAuthentication()
             .AddGoogle(options =>
            {
                 options.ClientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID");
              options.ClientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID");
            });
            services.AddSignalR();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Iadmainstrator dbInt)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            // StripeConfiguration.ApiKey=Configuration.GetSection("Stripe")["Secretkey"];
            dbInt.Inilations();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapHub("/NotificationHub");
                endpoints.MapHub<Like_Artical_Hub>("/Like_Artical_Hub"); 
                endpoints.MapHub<CommentHub>("/CommentHub"); 
                endpoints.MapHub<ProductHub>("ProductHub");
                endpoints.MapHub<ChatHub>("Chat");
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
