using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ToDoList.WEB.Models
{
    public class ProjectIndexView
    {
        [HiddenInput(DisplayValue = false)]
        public int ProjectId { get; set; }
        [Display(Name = "Название задачи")]
        public string Name { get; set; }
        [Display(Name = "Название задачи")]
        public string Description { get; set; }
        [Display(Name = "Дата старта")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ProjectStart { get; set; }
        [Display(Name = "Дата окончания")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ProjectFinish { get; set; }
    }

    public class ProjectEditView
    {
        [HiddenInput(DisplayValue = false)]
        public int ProjectId { get; set; }
        [Display(Name = "Название проекта")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки от 2 букв до 50!")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки от 2 букв до 50!")]
        public string Description { get; set; }
        [Display(Name = "Дата начала")]
        [Required(ErrorMessage = "Введите дату начала")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ProjectStart { get; set; }
        [Display(Name = "Дата окончания")]
        [Required(ErrorMessage = "Введите дату начала")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ProjectFinish { get; set; }
    }

    public class ProjectCreateView
    {
        [HiddenInput(DisplayValue = false)]
        public int ProjectId { get; set; }
        [Display(Name = "Название проекта")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки от 2 букв до 50!")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки от 2 букв до 50!")]
        public string Description { get; set; }
        [Display(Name = "Дата начала")]
        [Required(ErrorMessage = "Введите дату начала")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ProjectStart { get; set; }
        [Display(Name = "Дата окончания")]
        [Required(ErrorMessage = "Введите дату начала")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ProjectFinish { get; set; }
    }
}