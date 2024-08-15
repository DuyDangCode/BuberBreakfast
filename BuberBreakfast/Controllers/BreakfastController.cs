using BuberBreakfast.Contract.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers
{
    public class BreakfastController : ApiController
    {

        private readonly IBreakfastService _breakfastService;

        public BreakfastController(IBreakfastService breakfastService)
        {
            _breakfastService = breakfastService;
        }

        [HttpPost("/")]
        public IActionResult CreateBreakfast(CreateBreakfastRequest request)
        {
            BreakfastModel breakfast = new(new Guid(), request.Name, request.Description, request.StartDateTime, request.EndDateTime, DateTime.Now, request.Savory, request.Sweet);

            ErrorOr<Created> result = _breakfastService.CreateBreakfast(breakfast);


            return result.Match(value => Ok(breakfast), error => Problem(error));
        }

        [HttpGet("/{id:Guid}")]
        public IActionResult GetBreakfast(Guid id)
        {
            ErrorOr<BreakfastModel> result = _breakfastService.GetBreakfast(id);
            return result.Match(value => Ok(value), error => Problem(error));
        }

        [HttpPut("/{id:Guid}")]
        public IActionResult UpdateBreakfast(Guid id, UpsertBreakfastRequest request)
        {
            ErrorOr<Updated> result = _breakfastService.UpdateBreakfast(id, new BreakfastModel(id, request.Name, request.Description, request.StartDateTime, request.EndDateTime, DateTime.Now, request.Savory, request.Sweet));
            return result.Match(value => Ok(value), error => Problem(error));
        }

        [HttpDelete("/{id:Guid}")]
        public IActionResult DeleteBreakfast(Guid id)
        {
            ErrorOr<Deleted> result = _breakfastService.DeleteBreakfast(id);
            return result.Match(value => Ok(value), error => Problem(error));
        }


    }
}
