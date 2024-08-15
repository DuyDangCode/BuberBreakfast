using BuberBreakfast.Models;
using ErrorOr;

namespace BuberBreakfast.Services
{
    public interface IBreakfastService
    {
        ErrorOr<Created> CreateBreakfast(BreakfastModel breakfast);
        ErrorOr<BreakfastModel> GetBreakfast(Guid id);
        ErrorOr<Updated> UpdateBreakfast(Guid id, BreakfastModel breakfast);

        ErrorOr<Deleted> DeleteBreakfast(Guid id);

    }
}
