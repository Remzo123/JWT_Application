using JWT_Application.DTO.Request;
using JWT_Application.DTO.Response;
using JWT_Application.DTO;

namespace JWT_Application.Implementetion.Repository
{
    public interface IBookingService
    {
         Task<BaseResponseModel<Guid>> CreateBooking(CreateBooking request);
        Task<BaseResponseModel<Guid>> DeleteBookingAsync(Guid id);
        Task<BaseResponseModel<IList<BookingDto>>> UpdateBookingAsync(Guid Id, UpdateBooking request);
        Task<BaseResponseModel<BookingDto>> GetAllBookingById(Guid Id);
        Task<BaseResponseModel<IList<BookingDto>>> GetAllBookingAsync();
        Task<BookingDto> GetBookingByUserNAmeAsync(string username, string password);
    }
}
