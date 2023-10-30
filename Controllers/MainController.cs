using Microsoft.AspNetCore.Mvc;
using SinWebAPI.Models;
using System.Drawing;

namespace SinWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        [HttpPost]
        public IActionResult GeneratePointSignal(SinSignalParameters parameters)
        {
            int width = (int)(parameters.Fd / parameters.Fs) * parameters.N;
            int height = (int)parameters.A * 2 + 3;
            Bitmap image = new(width, height);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);
            }  
            double Ts = 1 / parameters.Fd;  // Интервал дискретизации сигнала в секундах

            for (int x = 0; x < width; x++)
            {
                double t = x * Ts;  // Время в секундах
                double sample = parameters.A * Math.Sin(2 * Math.PI * parameters.Fs * t);  // Генерация отсчета синусоиды

                int y = (int)(sample + parameters.A + 1);  // Координата y на изображении

                image.SetPixel(x, y, Color.Black);
            }

            var image_bytes = ImageToByteArray(image);
            return File(image_bytes, "image/png", "SinSignal.png");
        }

        [NonAction]
        private byte[] ImageToByteArray(Bitmap image)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}