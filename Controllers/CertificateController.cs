using CertificateManagement.Dtos;
using CertificateManagement.Service.Implementations;
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
        public ActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCertificateRequestModel model)
        {
            if (model != null)
            {
                var create = await _certificateService.Create(model);
                TempData["success"] = $"{model.FirstName} {model.LastName} certificate created succesfully";
                TempData.Keep();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = "Wrong input";
                return View();
            }
        }
    }
}
