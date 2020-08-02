using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace PrizeDraw.Data.Models
{
    public class Person
    {
        public int Id { set; get; }

        [Required(ErrorMessage ="لطفاً اسمتون رو وارد کنید")]
        [StringLength(250,ErrorMessage ="حد اکثر طول اسم، 250 حرف میتواند باشد")]
        public string Name { set; get; }

        [Required(ErrorMessage = "لطفاً فامیلیتون رو وارد کنید")]
        [StringLength(250, ErrorMessage = "حد اکثر طول فامیلی، 250 حرف میتواند باشد")]

        public string Family { set; get; }

        [Required(ErrorMessage = "لطفاً شماره تلفنتون رو وارد کنید")]
        [Phone(ErrorMessage ="شماره تلفنتون ره به شکل صحیح وارد کنید")]
        public string Phone { set; get; }

        [Required(ErrorMessage = "لطفاً آیدی اینستاگرامتون رو وارد کنید")]
        [RegularExpression(@"^([A-Za-z0-9_](?:(?:[A-Za-z0-9_]|(?:\.(?!\.))){0,28}(?:[A-Za-z0-9_]))?)$",ErrorMessage ="آیدی اینستاگرام خود را به شکل صحیح وارد کنید")]
        public string InstaId { get; set; }

        public string PrizeCode { set; get; }
    }
}
