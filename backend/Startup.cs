using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using A2F.Util;
using Novatic.Models;
using Novatic.Repository;
using Novatic.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin.Security.Google;
using Novatic.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Novatic
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
            //services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });


            services.AddMvc(options =>
            {
                options.Filters.Add<ViewBagActionFilter>();
                options.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<NovaticDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddScoped<IAccountTypeRepository, AccountTypeRepository>();

            services.AddScoped<IAccountMetaRepository, AccountMetaRepository>();

            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

            services.AddScoped<INotificationStatusRepository, NotificationStatusRepository>();

            services.AddScoped<INotificationRepository, NotificationRepository>();

            services.AddScoped<IMessageRepository, MessageRepository>();

            services.AddScoped<IProvinceRepository, ProvinceRepository>();

            services.AddScoped<ISystemConfigRepository, SystemConfigRepository>();

            services.AddScoped<IPostTypeRepository, PostTypeRepository>();

            services.AddScoped<IPostCategoryRepository, PostCategoryRepository>();

            services.AddScoped<IPostLayoutRepository, PostLayoutRepository>();

            services.AddScoped<IPostMetaRepository, PostMetaRepository>();

            services.AddScoped<IPostRepository, PostRepository>();

            services.AddScoped<IMenuRepository, MenuRepository>();

            services.AddScoped<ILanguageConfigRepository, LanguageConfigRepository>();

            services.AddScoped<ITagRepository, TagRepository>();

            services.AddScoped<IFavouritePostRepository, FavouritePostRepository>();

            services.AddScoped<IActivityLogRepository, ActivityLogRepository>();

            services.AddScoped<IViewStatusRepository, ViewStatusRepository>();

            services.AddScoped<ISubscribeRepository, SubscribeRepository>();

            services.AddSingleton<ICacheHelper, CacheHelper>();

            //services.AddSession(options => {
            //    options.IdleTimeout = TimeSpan.FromSeconds(3600);
            //});


            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(72000);
            });
            services.AddDistributedMemoryCache();                   // Đăng ký dịch vụ lưu cache trong bộ nhớ (Session sẽ sử dụng nó)
            services.AddSession(cfg =>
            {                            // Đăng ký dịch vụ Session
                cfg.Cookie.Name = SystemConstant.SECURITY_KEY_NAME; // "novaticSecurityToken";             // Đặt tên Session - tên này sử dụng ở Browser (Cookie)
                cfg.IdleTimeout = new TimeSpan(0, 120, 0);           // Thời gian tồn tại của Session
            });

            services.AddScoped<ICommentRepository, CommentRepository>();

            services.AddScoped<IPostTagRepository, PostTagRepository>();

            services.AddScoped<IReadedPostRepository, ReadedPostRepository>();


            services.AddScoped<ITopicRepository, TopicRepository>();

            services.AddScoped<IPostTopicRepository, PostTopicRepository>();

            services.AddScoped<IFeaturedPostRepository, FeaturedPostRepository>();


            services.AddScoped<ISurveyTypeRepository, SurveyTypeRepository>();

            services.AddScoped<ISurveyRepository, SurveyRepository>();

            services.AddScoped<ISurveyMetaRepository, SurveyMetaRepository>();

            services.AddScoped<ISurveySectionRepository, SurveySectionRepository>();

            services.AddScoped<IQuestionTypeRepository, QuestionTypeRepository>();

            services.AddScoped<IQuestionRepository, QuestionRepository>();

            services.AddScoped<IAnswerRepository, AnswerRepository>();

            services.AddScoped<ISurveySectionQuestionRepository, SurveySectionQuestionRepository>();

            services.AddScoped<ISurveyAccountRepository, SurveyAccountRepository>();

            services.AddScoped<ISurveySectionAccountRepository, SurveySectionAccountRepository>();

            services.AddScoped<ISurveySectionAccountDetailRepository, SurveySectionAccountDetailRepository>();

            services.AddScoped<IRecommentRepository, RecommentRepository>();


            services.AddScoped<IContactRepository, ContactRepository>();


            services.AddScoped<ITokenService, TokenService>();


            //CRM starts

            services.AddScoped<IShopTypeRepository, ShopTypeRepository>();

            services.AddScoped<IShopStatusRepository, ShopStatusRepository>();

            services.AddScoped<IShopRepository, ShopRepository>();

            services.AddScoped<IShopMetaRepository, ShopMetaRepository>();

            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

            services.AddScoped<IProductStatusRepository, ProductStatusRepository>();

            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddScoped<IProductBrandRepository, ProductBrandRepository>();

            services.AddScoped<IProductDiscountTypeRepository, ProductDiscountTypeRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductMetaRepository, ProductMetaRepository>();

            services.AddScoped<IWarehouseTypeRepository, WarehouseTypeRepository>();

            services.AddScoped<IWarehouseStatusRepository, WarehouseStatusRepository>();

            services.AddScoped<IWarehouseRepository, WarehouseRepository>();

            services.AddScoped<IWarehouseMetaRepository, WarehouseMetaRepository>();

            services.AddScoped<IProductItemRepository, ProductItemRepository>();

            services.AddScoped<IOrderTypeRepository, OrderTypeRepository>();

            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();

            services.AddScoped<IOrderPaymentStatusRepository, OrderPaymentStatusRepository>();

            services.AddScoped<IOrdersRepository, OrdersRepository>();

            services.AddScoped<IOrderMetaRepository, OrderMetaRepository>();

            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            services.AddScoped<IOrderItemMetaRepository, OrderItemMetaRepository>();

            services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();

            services.AddScoped<ITransactionStatusRepository, TransactionStatusRepository>();

            services.AddScoped<ITransactionsRepository, TransactionsRepository>();

            services.AddScoped<ITransactionMetaRepository, TransactionMetaRepository>();

            services.AddScoped<IPromotionRepository, PromotionRepository>();

            services.AddScoped<IPromotionMetaRepository, PromotionMetaRepository>();

            services.AddScoped<IVoucherTypeRepository, VoucherTypeRepository>();

            services.AddScoped<IVoucherStatusRepository, VoucherStatusRepository>();

            services.AddScoped<IVoucherRepository, VoucherRepository>();

            services.AddScoped<IVoucherMetaRepository, VoucherMetaRepository>();

            services.AddScoped<IOrderVoucherRepository, OrderVoucherRepository>();

            services.AddScoped<IOrderTransactionRepository, OrderTransactionRepository>();

            services.AddScoped<IShopTypeRepository, ShopTypeRepository>();

            services.AddScoped<IShopStatusRepository, ShopStatusRepository>();

            services.AddScoped<IShopRepository, ShopRepository>();

            services.AddScoped<IShopMetaRepository, ShopMetaRepository>();

            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

            services.AddScoped<IProductStatusRepository, ProductStatusRepository>();

            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddScoped<IProductBrandRepository, ProductBrandRepository>();

            services.AddScoped<IProductDiscountTypeRepository, ProductDiscountTypeRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductMetaRepository, ProductMetaRepository>();

            services.AddScoped<IWarehouseTypeRepository, WarehouseTypeRepository>();

            services.AddScoped<IWarehouseStatusRepository, WarehouseStatusRepository>();

            services.AddScoped<IWarehouseRepository, WarehouseRepository>();

            services.AddScoped<IWarehouseMetaRepository, WarehouseMetaRepository>();

            services.AddScoped<IProductItemRepository, ProductItemRepository>();

            services.AddScoped<IOrderTypeRepository, OrderTypeRepository>();

            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();

            services.AddScoped<IOrderPaymentStatusRepository, OrderPaymentStatusRepository>();

            services.AddScoped<IOrdersRepository, OrdersRepository>();

            services.AddScoped<IOrderMetaRepository, OrderMetaRepository>();

            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            services.AddScoped<IOrderItemMetaRepository, OrderItemMetaRepository>();

            services.AddScoped<ITransactionTypeRepository, TransactionTypeRepository>();

            services.AddScoped<ITransactionStatusRepository, TransactionStatusRepository>();

            services.AddScoped<ITransactionsRepository, TransactionsRepository>();

            services.AddScoped<ITransactionMetaRepository, TransactionMetaRepository>();

            services.AddScoped<IPromotionRepository, PromotionRepository>();

            services.AddScoped<IPromotionMetaRepository, PromotionMetaRepository>();

            services.AddScoped<IVoucherTypeRepository, VoucherTypeRepository>();

            services.AddScoped<IVoucherStatusRepository, VoucherStatusRepository>();

            services.AddScoped<IVoucherRepository, VoucherRepository>();

            services.AddScoped<IVoucherMetaRepository, VoucherMetaRepository>();

            services.AddScoped<IOrderVoucherRepository, OrderVoucherRepository>();

            services.AddScoped<IOrderTransactionRepository, OrderTransactionRepository>();

            services.AddScoped<ICartRepository, CartRepository>();

            //CRM ends

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            services.AddControllers().AddNewtonsoftJson();
            //Custom view engine folder
            services.Configure<RazorViewEngineOptions>(o =>
            {
                // {2} is area, {1} is controller,{0} is the action    
                //  Layout = "/Views/Shared/Auction/FrontEnd/_About.cshtml";
                //o.ViewLocationFormats.Clear();
                o.ViewLocationFormats.Add("/Views/Shared/NovaticAdmin" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("/Views/Core/{2}/{1}/{0}" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("/Views/CRM/{2}/{1}/{0}" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("/Views/News/{2}/{1}/{0}" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("/Views/Office/{2}/{1}/{0}" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("/Views/Auction/{2}/{1}/{0}" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("/Views/ECommerce/{2}/{1}/{0}" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("/Views/A2FHome/{2}/{1}/{0}" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("/Views/FileManager/{2}/{1}/{0}" + RazorViewEngine.ViewExtension);
                o.ViewLocationFormats.Add("/Views/GW/{2}/{1}/{0}" + RazorViewEngine.ViewExtension);

                // Untested. You could remove this if you don't care about areas.
                //o.AreaViewLocationFormats.Clear();
                //o.AreaViewLocationFormats.Add("/Areas/{2}/Controllers/{1}/Views/{0}" + RazorViewEngine.ViewExtension);
                //o.AreaViewLocationFormats.Add("/Areas/{2}/Controllers/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
                //o.AreaViewLocationFormats.Add("/Areas/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
            });


            services.AddAuthentication(o =>
            {
                o.DefaultScheme = "Application";
                o.DefaultSignInScheme = "External";
            })
            .AddCookie("Application")
            .AddCookie("External")
            .AddGoogle(o =>
            {
                o.ClientId = "682840274195-m6j8e2vt9gsmvv5ofbc70plqomvlg6mf.apps.googleusercontent.com";
                o.ClientSecret = "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";
            });
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = "988035435083398";
                facebookOptions.AppSecret = "8379fd142424a0d8ea8134f9d1416907";
            });


            // Add jwt authen
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new
                        SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes
                            (Configuration["Jwt:Key"]))
                };
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //HTTPS ENFORCE
            //services.AddHttpsRedirection(options =>
            //{
            //    options.HttpsPort = 443;
            //});
            services.AddRazorPages().AddRazorRuntimeCompilation();

     
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            app.UseCors("CorsPolicy");

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=NovaticHome}/{action=Index}");
            });



            //HTTPS ENFORCE
            app.UseHttpsRedirection();    // ===== Add this =====
            app.UseHsts();            // ===== Add this =====
            app.UseAuthentication();
            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "317791643993-mq5oungb5v50i51c2ku2gljp2m1n52uc.apps.googleusercontent.com",
            //    ClientSecret = "WRXeCaQ3Makjp33ebBUDx8zT"
            //});

            //app.UseCors(options => options.WithOrigins("http://localhost:3003").AllowAnyHeader().AllowAnyMethod());
            // global cors policy
            //app.UseCors(x => x
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .SetIsOriginAllowed(origin => true) // allow any origin
            //    .AllowCredentials()); // allow credentials


        }
    }
}
