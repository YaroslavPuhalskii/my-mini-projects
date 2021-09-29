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
    public class ProjectController : Controller
    {
        private readonly IProjectRepo projectRepo;

        public ProjectController(IProjectRepo repo)
        {
            projectRepo = repo;
        }
        public ViewResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> Load()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectIndexView>());
            var map = new Mapper(config);
            var projects = map.Map<List<ProjectIndexView>>(await projectRepo.GetItems());

            return PartialView(projects);
        }
        [HttpGet]
        public async Task<PartialViewResult> Details(int id)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectIndexView>());
                var map = new Mapper(config);
                var project = map.Map<Project, ProjectIndexView>(await projectRepo.GetById(id));

                return PartialView(project);
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
        public async Task<JsonResult> Create(ProjectCreateView item)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProjectCreateView, Project>());
                var map = new Mapper(config);
                var project = map.Map<ProjectCreateView, Project>(item);

                await projectRepo.Insert(project);

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
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectEditView>());
                var map = new Mapper(config);
                var project = map.Map<Project, ProjectEditView>(await projectRepo.GetById(id));

                return PartialView(project);
            }
            catch
            {
                return PartialView("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpPost]
        public async Task<JsonResult> Edit(ProjectEditView item)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProjectEditView, Project>());
                var map = new Mapper(config);
                var project = map.Map<ProjectEditView, Project>(item);

                await projectRepo.Update(project);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                await projectRepo.Remove(id);

                return Json(new { result = true });
            }
            catch (Exception ex)
            {
                return Json(new { result = false, message = ex.Message });
            }
        }
    }
}