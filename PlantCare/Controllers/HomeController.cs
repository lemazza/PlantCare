using Microsoft.AspNetCore.Mvc;
using PlantCare.Models;
using PlantCare.Service;
using QRCoder;
using System.Diagnostics;
using static QRCoder.PayloadGenerator;
using System.Drawing;

namespace PlantCare.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPlantInfoService _plantInfoService;

        public HomeController(ILogger<HomeController> logger, IPlantInfoService plantInfoService)
        {
            _logger = logger;
            _plantInfoService = plantInfoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> QrCode([FromQuery] int id)
        {
            var plantInfo = await _plantInfoService.Get(id);
            

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(new Url(plantInfo.WikiURL));
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            var qrCodeAsBitmap = qrCode.GetGraphic(20);
            string imreBase64Data = Convert.ToBase64String(qrCodeAsBitmap);
            string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
            //Passing image data in viewbag to view
            ViewBag.ImageData = imgDataURL;
            // use this when you want to show your logo in middle of QR Code and change color of qr code
            //Bitmap logoImage = new Bitmap(@"wwwroot/img/Virat-Kohli.jpg");
            //var qrCodeAsBitmap = qrCode.GetGraphic(20, Color.Black, Color.Red, logoImage);
            
            return View();
        }

        [HttpPost]
        public string Create(PlantInfo plantInfo)
        {
            _plantInfoService.Add(plantInfo);


            return "hit create endpoint";
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
