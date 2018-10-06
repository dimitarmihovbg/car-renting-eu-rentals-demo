using CarRentingEu.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentingEu.Web.ViewModels
{
    public class CarFormViewModel
    {
        public IEnumerable<ModelDto> Models { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Model")]
        [Required]
        public byte? ModelId { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Car" : "New Car";
            }
        }

        public CarFormViewModel()
        {
            Id = 0;
        }

        public CarFormViewModel(CarDto car)
        {
            Id = car.Id;
            Name = car.Name;
            ReleaseDate = car.ReleaseDate;
            NumberInStock = car.NumberInStock;
            ModelId = car.ModelId;
        }
    }
}
