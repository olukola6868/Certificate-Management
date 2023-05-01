using CertificateManagement.Dtos;
using CertificateManagement.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CertificateManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAdminRequestModel model)
        {
            if (model != null)
            {
                var create = await _adminService.Create(model);
                TempData["success"] = $"{model.FirstName} {model.LastName} created succesfully";
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
            await _adminService.Delete(id);
            ViewBag.Message = "Admin Deleted Successfully";
            return RedirectToAction();
        }
        public async Task<IActionResult> Detail(int id)
        {
            var admin = await _adminService.Get(id);
            if (admin.Status == true)
            {
                return View(admin);
            }
            return View();
        }
        public async Task<IActionResult> GetAll()
        {
            var admin = await _adminService.GetAll();
            if (admin.Status == true)
            {
                return View(admin);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateAdminRequestModel model)
        {
            if (model != null)
            {
                var update = await _adminService.Update(model, id);
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
        public IActionResult AdminBoard()
        {
            return View();
        }
    }
}
