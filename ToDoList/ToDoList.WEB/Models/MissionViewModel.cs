using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ToDoList.WEB.Models
{
    public class MissionIndexView
    {
        [HiddenInput(DisplayValue = false)]
        public int MissionId { get; set; }
        [Required]
        [Display(Name = "Название задачи")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Дата старта")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime MissionStart { get; set; }
        [Display(Name = "Дата окончания")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime MissionFinish { get; set; }
    }

    public class MissionEditView
    {
        [HiddenInput(DisplayValue = false)]
        public int MissionId { get; set; }
        [Required]
        [Display(Name = "Название задачи")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки от 2 букв до 50!")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки от 2 букв до 50!")]
        public string Description { get; set; }
        [Display(Name = "Дата начала")]
        [Required(ErrorMessage = "Введите дату начала")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime MissionStart { get; set; }
        [Display(Name = "Дата окончания")]
        [Required(ErrorMessage = "Введите дату окончания")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime MissionFinish { get; set; }
    }

    public class MissionCreateView
    {
        [HiddenInput(DisplayValue = false)]
        public int MissionId { get; set; }
        [Required]
        [Display(Name = "Название задачи")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки от 2 букв до 50!")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Длина строки от 2 букв до 50!")]
        public string Description { get; set; }
        [Display(Name = "Дата начала")]
        [Required(ErrorMessage = "Введите дату начала")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime MissionStart { get; set; }
        [Display(Name = "Дата окончания")]
        [Required(ErrorMessage = "Введите дату окончания")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime MissionFinish { get; set; }
    }
}