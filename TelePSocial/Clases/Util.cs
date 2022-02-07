using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TelePSocial.Clases
{
    public class Util
    {

        internal static async Task<string> Upload(IWebHostEnvironment hostingEnvironment, IFormFile dOC_ADJUN, string ruta)
        {
            var guid = Guid.NewGuid().ToString(); //Obtiene un texo aleatorio
            var fileName = guid + Path.GetExtension(dOC_ADJUN.FileName); //Obtengo extension del documento
            var carga = Path.Combine(hostingEnvironment.WebRootPath, string.Format("images\\{0}", ruta));
            using (var fileStream = new FileStream(Path.Combine(carga, fileName), FileMode.Create))
            {
                await dOC_ADJUN.CopyToAsync(fileStream);
            }
            return string.Format("~/images/{0}/{1}", ruta, fileName);
        }

        internal static string Upload(string StringBas64, IWebHostEnvironment _hostingEnvironment, string ruta)
        {
            var imageDataByteArray = Convert.FromBase64String(StringBas64);
            //var imageDataStream = new MemoryStream(imageDataByteArray)
            //{
            //    Position = 0
            //};
            var guid = Guid.NewGuid().ToString();
            var fileName = string.Format("{0}." + "png" + "", guid);
            //string path = _hostingEnvironment.WebRootPath + "/images/" + fileName;
            var path = Path.Combine(_hostingEnvironment.WebRootPath, string.Format("documents\\{0}", ruta), fileName);
            File.WriteAllBytes(path, imageDataByteArray);
            return fileName;
        }
        internal static async Task<string> UploadImg(IWebHostEnvironment hostingEnvironment, IFormFile dOC_ADJUN, string ruta)
        {
            var guid = Guid.NewGuid().ToString();
            var fileName = guid + Path.GetExtension(dOC_ADJUN.FileName);
            var carga = Path.Combine(hostingEnvironment.WebRootPath, string.Format("images\\{0}", ruta));
            using (var fileStream = new FileStream(Path.Combine(carga, fileName), FileMode.Create))
            {
                await dOC_ADJUN.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }
}
