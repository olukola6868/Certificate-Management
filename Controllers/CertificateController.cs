using CertificateManagement.Dtos;
using CertificateManagement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CertificateManagement.Controllers
{
    public class CertificateController : Controller
    {
        private readonly ICertificateService _certificateService;
        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }
        public ActionResult Create(int id)
        {
            var cert = new CreateCertificateRequestModel
            {
                OrganizationId = id,
            };
            return View(cert);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCertificateRequestModel model)
        {
            if (model != null)
            {
                var create = await _certificateService.Create(model);
                TempData["success"] = $"{model.FirstName} {model.LastName} certificate created succesfully";
                TempData.Keep();
                return RedirectToAction("GetAll");
            }
            else
            {
                TempData["Error"] = "Wrong input";
                return View();
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _certificateService.Delete(id);
            ViewBag.Message = "Certificate deleted successfully";
            return RedirectToAction();
        }
        public async Task<IActionResult> Detail(int id)
        {
            var certificate = await _certificateService.Get(id);
            if (certificate.Status == true)
            {
                return View(certificate);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyCertificate(string CertificateCode)
        {
            var certificate = await _certificateService.GetByCode(CertificateCode);
            if (certificate.Status)
            {
                return View(certificate);
            }
            return View("Index" , "Home");
        }
        public IActionResult CertificateCheckPage()
        {
            return View();
        }
        public async Task<IActionResult> GetAll()
        {
            var certificate = await _certificateService.GetAll();
            if (certificate.Status == true)
            {
                return View(certificate);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCertificateRequestModel model, int id)
        {
            if (model != null)
            {
                var update = await _certificateService.Update(model, id);
                TempData["success"] = $"updated succesfully";
                TempData.Keep();
                return RedirectToAction("GetAll");
            }
            else
            {
                TempData["Error"] = "Wrong input";
                return View();
            }
        }
    }
}
