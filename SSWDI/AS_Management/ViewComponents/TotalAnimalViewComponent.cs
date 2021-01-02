using AS_Core.DomainModel;
using AS_DomainServices.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AS_Management.ViewComponents
{
    public class TotalAnimalViewComponent : ViewComponent
    {
        private readonly IAnimalService _animalService;

        public TotalAnimalViewComponent(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Animal> animals = (List<Animal>)_animalService.GetAllAvailableAnimals();
            return await Task.FromResult((IViewComponentResult)View("TotalAnimal", animals));
        }
    }
}
