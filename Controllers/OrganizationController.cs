using CertificateManagement.Dtos;
using CertificateManagement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CertificateManagement.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrganizationRequestModel model)
        {
            if (model != null)
            {
                var create = await _organizationService.Create(model);
                TempData["success"] = $"{model.OrganizationName} created succesfully";
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
            await _organizationService.Delete(id);
            ViewBag.Message = "Admin Deleted Successfully";
            return RedirectToAction();
        }
        public async Task<IActionResult> Detail(int id)
        {
            var organization = await _organizationService.Get(id);
            if (organization.Status == true)
            {
                return View(organization);
            }
            return View();
        }
        public async Task<IActionResult> GetAll()
        {
            var organizations = await _organizationService.GetAll();
            if (organizations.Status == true)
            {
                return View(organizations);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var organization = await _organizationService.Get(id);
            if(organization == null)
            {
                RedirectToAction("GetAll","Organization");
            }
            return View(organization);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateOrganizationRequestModel model)
        {
            if (model != null)
            {
                var update = await _organizationService.Update(model, id);
                TempData["success"] = $"updated succesfully";
                TempData.Keep();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = "Wrong input";
                return View();
            }
        }
        public IActionResult OrganizationBoard()
        {
            return View();
        }
    }
}