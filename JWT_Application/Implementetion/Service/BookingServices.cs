using JWT_Application.DbContext;
using JWT_Application.DTO.Request;
using JWT_Application.DTO;
using JWT_Application.Implementetion.Repository;
using JWT_Application.DTO.Response;
using Microsoft.EntityFrameworkCore;
using JWT_Application.Entities.Models;

namespace JWT_Application.Implementetion.Service
{
    public class BookingServices : IBookingService
    {
        private readonly ApplicationDbContext _dbContext;
        public BookingServices(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BaseResponseModel<Guid>> CreateBooking(CreateBooking request)
        {

            var booking = new Booking
            {
                UserName = request.UserName,
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                 Password = request.Password,
                BookingDate = request.BookingDate,
                BookingTime = request.BookingTime,
            };
            await _dbContext.Bookings.AddAsync(booking);

            if(await _dbContext.SaveChangesAsync() > 0 )
            {
                return new BaseResponseModel<Guid>
                {
                    Message = "User created successfully",
                    Success = true
                };
            }
            return new BaseResponseModel<Guid>
            {
                Message = "Failed to create",
                Success = false,
            };
            
        }

        public async Task<BaseResponseModel<Guid>> DeleteBookingAsync(Guid id)
        {
            var booking = _dbContext.Bookings.FirstOrDefault();

            if (booking != null)
            {
                _dbContext.Bookings.Remove(booking);
            }
            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponseModel<Guid>
                {
                    Message = "Delete Successfully",
                    Success = true
                };
            }
            return new BaseResponseModel<Guid>
            {
                Message = "Failed to Delete",
                Success = false,

            };


        }
        public async Task<BaseResponseModel<IList<BookingDto>>> UpdateBookingAsync(Guid Id, UpdateBooking request)
        {
            var booking = await _dbContext.Bookings.FirstOrDefaultAsync();


            if (booking == null)
            {
                return new BaseResponseModel<IList<BookingDto>>
                {
                    Message = "",
                    Success = false
                };

            }
            booking.Name = request.Name;
            booking.UserName = request.UserName;
            booking.Email = request.Email;
            booking.Password = request.Password;
            booking.BookingDate = request.BookingDate;
            booking.BookingTime = request.BookingTime;
            booking.PhoneNumber = request.PhoneNumber;



            _dbContext.Bookings.Update(booking);

            if (await _dbContext.SaveChangesAsync() > 0)
            {
                return new BaseResponseModel<IList<BookingDto>>
                {
                    Message = "Update Successfully",
                    Success = true,

                };
            }
            return new BaseResponseModel<IList<BookingDto>>
            {
                Message = "Update Failed",
                Success = false
            };

        }
        public async Task<BaseResponseModel<IList<BookingDto>>> GetAllBookingAsync()
        {
            var booking = await _dbContext.Bookings.Select(f => new BookingDto
            {

                Name = f.Name,
                UserName = f.UserName,
                BookingDate = f.BookingDate,
                BookingTime = f.BookingTime,
                Email = f.Email,
                Password = f.Password,
                PhoneNumber = f.PhoneNumber,

            }).ToListAsync();
            if (booking != null)
            {
                return new BaseResponseModel<IList<BookingDto>>
                {
                    Message = "Booking Details Found Successfully",
                    Success = true,
                    Data = booking,
                };
            }
            else
            {
                return new BaseResponseModel<IList<BookingDto>>
                {
                    Message = "Booking Details Not Found",
                    Success = false,
                };
            }



        }

        public async Task<BaseResponseModel<BookingDto>> GetAllBookingById(Guid Id)
        {
            var booking = await _dbContext.Bookings
                .Where(f => f.Id == f.Id)
                .Select(f => new BookingDto
                {
                    Name = f.Name,
                    UserName = f.UserName,
                    Password = f.Password,
                    BookingDate = f.BookingDate,
                    BookingTime = f.BookingTime,
                    Email = f.Email,
                    PhoneNumber = f.PhoneNumber,

                }).FirstOrDefaultAsync();
            if (booking != null)
            {
                return new BaseResponseModel<BookingDto>
                {
                    Message = " Details Found Successfully",
                    Success = true,
                    Data = booking,
                };

            }
            else
            {
                return new BaseResponseModel<BookingDto>
                {
                    Message = "Details Not Found Successfully",
                    Success = false,


                };
            }
        }

        public async Task<BookingDto> GetBookingByUserNAmeAsync(string username, string password)
        {

            var users = await _dbContext.Bookings
             .Where(x => x.UserName == username)
             .Select(x => new BookingDto()
             {
                 Id = x.Id,
                 Name = x.Name,
                 UserName = username,
                 Password = password

             }).FirstOrDefaultAsync();
            if (users != null)
            {
                return new BookingDto()
                {
                    Id = users.Id,
                    Name = users.Name,
                    UserName = username,
                    Password = password

                };
            }
            return null;
        }



    }
}
