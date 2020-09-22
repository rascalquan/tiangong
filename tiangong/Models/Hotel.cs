using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TianGong.Models
{
    public class Hotel
    {
        [Key]
        public long id { get; set; }

        [Display(Name = "酒店名称")]
        public string name { get; set; }

        [Display(Name = "联系电话")]
        [StringLength(maximumLength:11)]
        public string telephone { get; set; }
        
        [Display(Name = "星级")]
        [DisplayFormat(ApplyFormatInEditMode = false,NullDisplayText = "未评级")]
        [Range(1,5)]
        public int star { get; set; }

        [Display(Name = "地址")]
        public string address { get; set; }

        public string createby { get; set; }
        public DateTime createtime { get; set; }
        public string lastupdateby { get; set; }
        public DateTime lastupdatetime { get; set; }
    }
}
