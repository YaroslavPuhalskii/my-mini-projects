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
    public class MissionController : Controller
    {
        private readonly IMissionRepo missionRepo;

        public MissionController(IMissionRepo repo)
        {
            missionRepo = repo;
        }
        public ViewResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> Load()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Mission, MissionIndexView>());
            var map = new Mapper(config);
            var missions = map.Map<List<MissionIndexView>>(await missionRepo.GetItems());

            return PartialView(missions);
        }
        [HttpGet]
        public async Task<PartialViewResult> Details(int id)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Mission, MissionIndexView>());
                var map = new Mapper(config);
                var mission = map.Map<Mission, MissionIndexView>(await missionRepo.GetById(id));

                return PartialView(mission);
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
        public async Task<JsonResult> Create(MissionCreateView item)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<MissionCreateView, Mission>());
                var map = new Mapper(config);
                var mission = map.Map<MissionCreateView, Mission>(item);

                await missionRepo.Insert(mission);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<PartialViewResult> Edit(int id)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Mission, MissionEditView>());
                var map = new Mapper(config);
                var mission = map.Map<Mission, MissionEditView>(await missionRepo.GetById(id));

                return PartialView(mission);
            }
            catch
            {
                return PartialView("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpPost]
        public async Task<JsonResult> Edit(MissionEditView item)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<MissionEditView, Mission>());
                var map = new Mapper(config);
                var mission = map.Map<MissionEditView, Mission>(item);

                await missionRepo.Update(mission);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                await missionRepo.Remove(id);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }
    }
}