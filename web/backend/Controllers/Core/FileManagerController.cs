using elFinder.NetCore;
using elFinder.NetCore.Drivers.FileSystem;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace A2F.Controllers
{
    [Route("/file-manager")]
    public class FileManagerController : Controller
    {
        public IActionResult Index()
        {
            string UserIDSession = HttpContext.Session.GetString("UserID");
            if (UserIDSession != null && UserIDSession.Length > 0)
            {
                return View();
            }
            return Forbid();
        }
        IWebHostEnvironment _env;
        public FileManagerController(IWebHostEnvironment env) => _env = env;

        // Url để client-side kết nối đến backend
        // /el-finder-file-system/connector
        [Route("file-manager-connector")]
        public async Task<IActionResult> Connector()
        {
            var connector = GetConnector();
            var result = await connector.ProcessAsync(Request);
            if (result is JsonResult)
            {
                var json = result as JsonResult;
                return Content(JsonSerializer.Serialize(json.Value), json.ContentType);
            }
            else
            {
                return result;
            }
        }

        // Địa chỉ để truy vấn thumbnail
        // /el-finder-file-system/thumb
        [Route("file-manager-thumb/{hash}")]
        public async Task<IActionResult> Thumbs(string hash)
        {
            var connector = GetConnector();
            return await connector.GetThumbnailAsync(HttpContext.Request, HttpContext.Response, hash);
        }

        private Connector GetConnector()
        {
            string absoluteUrl = UriHelper.BuildAbsolute(Request.Scheme, Request.Host);
            var uri = new Uri(absoluteUrl);

            string UserIDSession = HttpContext.Session.GetString("UserID");
            // Thư mục gốc lưu trữ là wwwwroot/files (đảm bảo có tạo thư mục này)
            string pathroot = "upload\\" + UserIDSession;

            // .. ... wwww/files
            string rootDirectory = Path.Combine(_env.WebRootPath, pathroot);



            //Tạo thư mục upload cho user nếu chưa tồn tại
            // Specify the directory you want to manipulate.
            //string path = @"c:\MyDir";
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(rootDirectory))
                {
                    Console.WriteLine("That path exists already.");
                }
                else
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(rootDirectory);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(rootDirectory));

                    // Delete the directory.
                    //di.Delete();
                    //Console.WriteLine("The directory was deleted successfully.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally
            {

            }

            var driver = new FileSystemDriver();
            // https://localhost:5001/files/
            string url = $"{uri.Scheme}://{uri.Authority}/{pathroot}/";
            string urlthumb = $"{uri.Scheme}://{uri.Authority}/file-manager/file-manager-thumb/";

            var root = new RootVolume(rootDirectory, url, urlthumb)
            {
                //IsReadOnly = !User.IsInRole("Administrators")
                IsReadOnly = false, // Can be readonly according to user's membership permission
                IsLocked = false, // If locked, files and directories cannot be deleted, renamed or moved
                Alias = "Files", // Beautiful name given to the root/home folder
                //MaxUploadSizeInKb = 2048, // Limit imposed to user uploaded file <= 2048 KB
                //LockedFolders = new List<string>(new string[] { "Folder1" }
                ThumbnailSize = 100,
                StartDirectory = "100001",
            };

            driver.AddRoot(root);

            return new Connector(driver)
            {
                // This allows support for the "onlyMimes" option on the client.
                MimeDetect = MimeDetectOption.Internal
            };
        }
    }

}
