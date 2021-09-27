using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ToDoList.WEB.Models
{
    public class PurposeIndexView
    {
        [HiddenInput(DisplayValue = false)]
        public int PurposeId { get; set; }
        [Required]
        [Display(Name = "Название цели")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }

    public class PurposeEditView
    {
        [HiddenInput(DisplayValue = false)]
        public int PurposeId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Название должно содержать хотя бы один символ!")]
        [Display(Name = "Название цели")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Описание должно содержать хотя бы один символ!")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }

    public class PurposeCreateView
    {
        [HiddenInput(DisplayValue = false)]
        public int PurposeId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Название должно содержать хотя бы один символ!")]
        [Display(Name = "Название цели")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Описание должно содержать хотя бы один символ!")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}