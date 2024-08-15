using BuberBreakfast.Models;
using BuberBreakfast.ServiceErrors;
using ErrorOr;

namespace BuberBreakfast.Services
{
    public class BreakfastService : IBreakfastService
    {

        private readonly Dictionary<Guid, BreakfastModel> _breakfasts = new();

        public ErrorOr<Created> CreateBreakfast(BreakfastModel breakfast)
        {
            _breakfasts.Add(breakfast.Id, breakfast);
            return Result.Created;
        }

        public ErrorOr<Deleted> DeleteBreakfast(Guid id)
        {
            return Result.Deleted;
        }

        public ErrorOr<BreakfastModel> GetBreakfast(Guid id)
        {
            if (_breakfasts.TryGetValue(id, out var breakfast))
            {
                return breakfast;
            }

            return Errors.Breakfast.NotFound;
        }

        public ErrorOr<Updated> UpdateBreakfast(Guid id, BreakfastModel breakfast)
        {
            return Result.Updated;
        }
    }
}
