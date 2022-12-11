using DomainLayer.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Task.Mohamed_eid.Models;

namespace Task.Mohamed_eid.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RepositoryLayer.IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment, RepositoryLayer.IUnitOfWork _unitOfWork)
        {
            _logger = logger;
            unitOfWork = _unitOfWork;
            _hostEnvironment = hostEnvironment;

        }

        public async Task<IActionResult> Index()
        {
            var data = (from person in unitOfWork.personData.GetAll().AsNoTracking()
                       .Select(m => new
                       {
                           Id = m.Id,
                           Name = m.Name,
                           Iqama = m.Iqama,
                           phone = m.PhoneNumber,
                           damageId = m.DamageTypeId,
                           DamageDate = m.DamageDate
                       })

                        join location in unitOfWork.locationData.GetAll().AsNoTracking()
                        .Select(l => new
                        {
                            RegionId = l.RegionsId,
                            City = l.City,
                            InsurranceId = l.InsurranceId,
                            DamageImage = l.DamageImage,
                            VehicleImage = l.VehicleImage,
                            PersonId = l.DataPersonsId
                        }) on person.Id equals location.PersonId

                        join damagetype in unitOfWork.damageTypes.GetAll().AsNoTracking() on person.damageId equals damagetype.Id

                        join region in unitOfWork.regions.GetAll().AsNoTracking() on location.RegionId equals region.Id

                        select new PersonDataModel
                        {
                            Id = person.Id,
                            Name = person.Name,
                            Iqama = person.Name,
                            PhoneNumber = person.phone,
                            str_Damage = damagetype.Name,
                            DamageDate = person.DamageDate,
                            str_Region = region.Name,
                            City = location.City,
                            InsurranceId = location.InsurranceId,
                            DamageImage = location.DamageImage,
                            VehicleImage = location.VehicleImage
                        }).AsEnumerable();
            //_logger.LogInformation("Every Thing is Fine");
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            DropDownList_Data(0, 0, 0);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonDataModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    DropDownList_Data(model.DamageTypeId, model.BankTypesId, model.RegionsId);
                    return View(model);
                }

                var PersonObj = unitOfWork.personData.Insert(new DomainLayer.Entities.Data.DataPersons
                {
                    BankTypesId = model.BankTypesId,
                    DamageDate = model.DamageDate,
                    DamageTypeId = model.DamageTypeId,
                    Iqama = model.Iqama,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber
                });
                unitOfWork.SaveData();

                if (model.DamageImageFile is not null)
                {
                    var uploaded = await Upload_Images(model.DamageImageFile, PersonObj.Id);
                    if (string.IsNullOrEmpty(uploaded))
                    {
                        TempData["MsgCreate"] = "4";
                    }
                    model.DamageImage = uploaded;
                }
                else
                {
                    model.DamageImage = string.Empty;
                }

                if (model.VehicleImageFile is not null)
                {
                    var uploaded = await Upload_Images(model.VehicleImageFile, PersonObj.Id);
                    if (string.IsNullOrEmpty(uploaded))
                    {
                        TempData["MsgCreate"] = "5";
                    }
                    model.VehicleImage = uploaded;
                }
                else
                {
                    model.VehicleImage = string.Empty;
                }

                unitOfWork.locationData.Insert(new DomainLayer.Entities.Data.LocationData
                {
                    AreaQuarter = model.AreaQuarter,
                    City = model.City,
                    DataPersonsId = PersonObj.Id,
                    InsurranceId = model.InsurranceId,
                    PostalCode = model.PostalCode,
                    RegionsId = model.RegionsId,
                    Street = model.Street,
                    DamageImage = model.DamageImage,
                    VehicleImage = model.VehicleImage

                });
                if (unitOfWork.SaveData())
                {
                    TempData["MsgCreate"] = "1";
                    return RedirectToAction(nameof(Create));
                }
                TempData["MsgCreate"] = "3";
                DropDownList_Data(model.DamageTypeId, model.BankTypesId, model.RegionsId);
                return View(model);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message.ToString());
                TempData["MsgCreate"] = "3";
                DropDownList_Data(model.DamageTypeId, model.BankTypesId, model.RegionsId);
                return View(model);
            }
            
           
        }

        private async Task<string> Upload_Images(IFormFile File,int PersonId)
        {
            string filename_Damage = string.Empty;
            try
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string Folder_Exsits = Path.Combine(wwwRootPath, "UploadedImages/"+PersonId);
                if (!Directory.Exists(Folder_Exsits))
                {
                    Directory.CreateDirectory(Folder_Exsits);
                }
                string completename_Damage = DateTime.Now.Ticks +"_"+ File.FileName;
                filename_Damage = Path.GetFileName(completename_Damage);
                string path = Path.Combine(wwwRootPath + "/UploadedImages/"+ PersonId + "/" + filename_Damage);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await File.CopyToAsync(fileStream);
                }
                return filename_Damage;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message.ToString());
                return string.Empty;
            }

        }
        private void DropDownList_Data(int DamageTypeId,int BankTypeId,int RegionId)
        {
            ViewBag.lst_DamageTypes = new SelectList( unitOfWork.damageTypes.GetAll().ToList(), "Id", "Name", DamageTypeId);
            ViewBag.lst_BankTypes = new SelectList( unitOfWork.bankType.GetAll().ToList(), "Id", "Name", BankTypeId);
            ViewBag.lst_regions = new SelectList( unitOfWork.regions.GetAll().ToList(), "Id", "Name", RegionId);
            ViewBag.insurrances = new SelectList(MapEnumToList(), "InsurranceId", "InsurranceName");
        }

        private IEnumerable<EnsurranceModel> MapEnumToList()
        {
            foreach (var item in (Ensurrance[])Enum.GetValues(typeof(Ensurrance)))
            {
                yield return new EnsurranceModel { 
                    InsurranceId = (int)item,
                    InsurranceName = item.ToString()
                };
            }
        }

        [HttpPost]
        public async Task<JsonResult> GetIBan(int BankId)
        {
            return Json(unitOfWork.bankType.Get(BankId).IBAN);
        }


    }
}
