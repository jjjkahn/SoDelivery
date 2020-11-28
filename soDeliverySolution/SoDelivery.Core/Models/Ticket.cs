using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoDelivery.Core.Models
{
    public class CustomDateRangeAttribute : RangeAttribute
    {
        public CustomDateRangeAttribute(int startYear, int endYear) : base(typeof(DateTime), DateTime.Now.AddYears(startYear).ToString(), DateTime.Now.AddYears(endYear).ToString()) { }
    }
    public class Ticket:BaseEntity
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Expiration Date is required")]
        [DataType(DataType.Date)]
       
        [CustomDateRange(0, 20)]
        [DisplayName("Day")]
        public DateTime ?Day { get; set; }
        [Required(ErrorMessage = "Expiration Date is required")]
        [DataType(DataType.Time)]
// [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        [DisplayName("Start Time")]
        public TimeSpan ?StartTime { get; set; }
        [Required(ErrorMessage = "Expiration Date is required")]
        [DataType(DataType.Time)]
 //       [DisplayFormat(DataFormatString = "{HH:mm}", ApplyFormatInEditMode = true)]
        [DisplayName("End Time")]
        public TimeSpan ?EndTime { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public bool Vehicle { get; set; }

     
    }
}
