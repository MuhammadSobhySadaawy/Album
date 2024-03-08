using Album.Infrastructure.Helpers.IHelper.FileUpload;
using Album.Infrastructure.Helpers.Helper.FileUpload;
using Album.DataProviders;
using Album.DataAccess.Repository.DefualtRepository;
using Album.DataAccess.Repository_Interface;

namespace CityEye_Api.InjectProviders
{
    public static class ServiceBinding
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            #region Helper Provider

            services.AddScoped<IFileUploadHelper, FileUploadHelper>();

            #endregion

            #region Providers
            services.AddScoped<IDefaultDataProvider, DefaultDataProvider>();
            services.AddScoped<ISPProvider, SPProvider>();
            #endregion

            return services;
        }
    }
}
