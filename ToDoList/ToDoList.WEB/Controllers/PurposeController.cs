using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ToDoList.Core;
using ToDoList.Entities.Models;
using ToDoList.WEB.Models;

namespace ToDoList.WEB.Controllers
{
    public class PurposeController : Controller
    {
        private readonly IPurposeRepo purposeRepo;

        public PurposeController(IPurposeRepo repo)
        {
            purposeRepo = repo;
        }

        public ViewResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> Load()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Purpose, PurposeIndexView>());
            var map = new Mapper(config);
            var purposes = map.Map<List<PurposeIndexView>>(await purposeRepo.GetItems());

            return PartialView(purposes);
        }
        [HttpGet]
        public async Task<PartialViewResult> Details(int id)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Purpose, PurposeIndexView>());
                var map = new Mapper(config);
                var purpose = map.Map<Purpose, PurposeIndexView>(await purposeRepo.GetById(id));

                return PartialView(purpose);
            }
            catch
            {
                return PartialView("~/Views/Shared/Error.cshtml");
            }
        }

        public PartialViewResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<JsonResult> Create(PurposeCreateView item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<PurposeCreateView, Purpose>());
                    var map = new Mapper(config);
                    var purpose = map.Map<PurposeCreateView, Purpose>(item);

                    await purposeRepo.Insert(purpose);

                    return Json(new { result = true });
                }
                catch (Exception ex)
                {
                    return Json(new { result = false, message = ex.Message });
                }
            }

            return Json(new { result = false, message = "Model is invalid!" });
        }

        [HttpGet]
        public async Task<PartialViewResult> Edit(int id)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Purpose, PurposeEditView>());
                var map = new Mapper(config);
                var purpose = map.Map<Purpose, PurposeEditView>(await purposeRepo.GetById(id));

                return PartialView(purpose);
            }
            catch
            {
                return PartialView("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpPost]
        public async Task<JsonResult> Edit(PurposeEditView item)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<PurposeEditView, Purpose>());
                var map = new Mapper(config);
                var purpose = map.Map<PurposeEditView, Purpose>(item);

                await purposeRepo.Update(purpose);

                return Json(new { result = true});
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message});
            }
        }

        [HttpGet]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                await purposeRepo.Remove(id);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        // POST: Purpose/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
