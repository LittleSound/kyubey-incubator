using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Andoromeda.Kyubey.Incubator.Middlewares
{
    public static class DexStaticFilesMiddlewareExtensions
    {
        public static IApplicationBuilder UseIncubatorStaticFiles(this IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration)
        {
            app.UseStaticFiles();

            var assetsBaseFolder = Path.Combine(env.ContentRootPath, configuration["RepositoryStore"]);

            //token
            {
                var filesFolder = Path.Combine(assetsBaseFolder, "token-list");
                if (!Directory.Exists(filesFolder))
                {
                    Directory.CreateDirectory(filesFolder);
                }
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(filesFolder),
                    RequestPath = new PathString("/token_assets")
                });
            }

            //slides
            {
                var filesFolder = Path.Combine(assetsBaseFolder, "dex-slides");
                if (!Directory.Exists(filesFolder))
                {
                    Directory.CreateDirectory(filesFolder);
                }
                app.UseStaticFiles(new StaticFileOptions()
                {
                    FileProvider = new PhysicalFileProvider(filesFolder),
                    RequestPath = new PathString("/slides_assets")
                });
            }

            return app;
        }
    }
}
