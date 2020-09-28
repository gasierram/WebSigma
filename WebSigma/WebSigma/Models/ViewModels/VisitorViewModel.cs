using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSigma.Models.ViewModels
{
    public class VisitorViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre*")]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        [EmailAddress]
        [Display(Name = "Correo*")]
        public string Email { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Departamento*")]
        public string State { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Ciudad*")]
        public string City { get; set; }

        public List<State> States { get; set; }
    }
}