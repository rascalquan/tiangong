using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace tiangong.Models
{
    public class Hotel
    {
        public long id { get; set; }
        public string name { get; set; }
        public string telephone { get; set; }
        public int star { get; set; }
        public string address { get; set; }
        public string createby { get; set; }
        public DateTime createtime { get; set; }
        public string lastupdateby { get; set; }
        public DateTime lastupdatetime { get; set; }
    }
}
