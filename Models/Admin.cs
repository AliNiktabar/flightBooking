using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace flightbooking_project.Models
{
    [Table("tblAdminLogin")]
    public class AdminLogin
    {
        [Key]
        public int AdminId { get; set; }
        [Required(ErrorMessage = "نام کاربری را وارد کنید")]
        [Display(Name = "نام کاربری")]
        [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر وارد کنید"), MaxLength(10, ErrorMessage = "حداکثر 10 کاراکتر وارد کنید")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "حداقل 5 کاراکتر وارد کنید"), MaxLength(10, ErrorMessage = "حداکثر 10 کاراکتر وارد کنید")]
        public string AdminPassword { get; set; }

    }
    [Table("tblUserAccount")]
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "نام خود را وارد کنید")]
        [Display(Name = "نام ")]
        [MinLength(5, ErrorMessage = "حداقل 5 کاراکتر وارد کنید"), MaxLength(20, ErrorMessage = "حداکثر 20 کاراکتر وارد کنید")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی خود را وارد کنید")]
        [Display(Name = "نام خانوادگی ")]
        [MinLength(5, ErrorMessage = "حداقل 5 کاراکتر وارد کنید"), MaxLength(20, ErrorMessage = "حداکثر 20 کاراکتر وارد کنید")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "ایمیل را وارد کنید")]
        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress)]
        [MinLength(5, ErrorMessage = "حداقل 5 کاراکتر وارد کنید"), MaxLength(30, ErrorMessage = "حداکثر 30 کاراکتر وارد کنید")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمز عبور را وارد کنید")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "حداقل 5 کاراکتر وارد کنید"), MaxLength(10, ErrorMessage = "حداکثر 10 کاراکتر وارد کنید")]
        public string Password { get; set; }

        [Display(Name = " تایید رمز عبور")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور با رمز عبور وارد شده تطابق ندارد")]
        [MinLength(5, ErrorMessage = "حداقل 5 کاراکتر وارد کنید"), MaxLength(10, ErrorMessage = "حداکثر 10 کاراکتر وارد کنید")]
        public string CPassword { get; set; }

        [Required(ErrorMessage = "سن خود را وارد کنید")]
        [Range(18, 120, ErrorMessage = "حداقل سن رزرو بلیط 18 سال می باشد")]
        public int Age { get; set; }

        [Required(ErrorMessage = "شماره موبایل را وارد کنید"), RegularExpression("@^[0-9]{11}$", ErrorMessage = "شماره وارد شده نامعتبر است")]
        [Display(Name = "شماره موبایل")]
        [StringLength(11)]
        public string PhoneNumber { get; set; }
    }
    [Table("tblAirplanPlane")]
    public class AirplaneInfo
    {
        [Key]
        public int PlaneId { get; set; }

        [Required(ErrorMessage = "نام هواپیما را وارد کنید")]
        [Display(Name = " نام هواپیما ")]
        [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر وارد کنید"), MaxLength(30, ErrorMessage = "حداکثر 30 کاراکتر وارد کنید")]
        public string AirplaneName { get; set; }

        [Required(ErrorMessage = "ظرفیت را وارد کنید")]
        [Display(Name = " ظرفیت ")]
        public int SeatingCapacity { get; set; }

        [Required(ErrorMessage = " قیمت را وارد کنید")]
        [Display(Name = " قیمت ")]
        public float Price { get; set; }
        public virtual ICollection<TicketReservation> TicketReservation_tbls { get; set; }

    }
    [Table("tblFlightBooking")]
    public class FlightBooking
    {
        [Key]
        public int bId { get; set; }

        [Required, Display(Name = "نام")]
        public string bCusName { get; set; }

        [Required, Display(Name = "آدرس")]
        public string bCusAddress { get; set; }

        [Required, Display(Name = "ایمیل")]
        public string bCusEmail { get; set; }

        [Required, Display(Name = "شماره صندلی")]
        public int bCusSeats { get; set; }

        [Required, Display(Name = "شماره همراه")]
        public string bCusPhoneNum { get; set; }

        public int ResId { get; set; }
        public virtual TicketReservation TicketReservation_tbls { get; set; }
    }

    [Table("tblTicketReservation")]
    public class TicketReservation
    {
        [Key]
        public int ResId { get; set; }

        [Required, Display(Name = "شهر مبدا")]
        public string ResFrom { get; set; }

        [Required, Display(Name = "شهر مقصد")]
        public string ResTo { get; set; }

        [Required, Display(Name = "روز حرکت")]
        public string ResDepDate { get; set; }

        [Required, Display(Name = "شماره هواپیما")]
        public int PlaneId { get; set; }
        public virtual AirplaneInfo plane_tbls { get; set; }

        [Required, Display(Name = "ظرفیت موجود")]
        public int planeSeat { get; set; }

        [Required, Display(Name = "قیمت")]
        public float ResTicketPrice { get; set; }

        [Required, Display(Name = "نوع هواپیما")]
        public string ResPlaneType { get; set; }

        public virtual ICollection<FlightBooking> tblFlightBooking { get; set; }

    }
}