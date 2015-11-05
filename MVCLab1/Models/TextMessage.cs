using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCLab1.Models
{
    public class TextMessage
    {
        public int TextMessageId { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Phone Number must be 10 digits long"), MinLength(10, ErrorMessage = "Phone Number must be 10 digits long")]
        [DataType(DataType.PhoneNumber, ErrorMessage ="Must be a phone number")]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(140, ErrorMessage = "Max length of message is 140 characters")]
        public string Content { get; set; }
    }
}
