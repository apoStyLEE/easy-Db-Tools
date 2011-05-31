using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyDbTools
{
    // Poco Class
    public class testTable
    {
        public string name { get; set; }
        public string email { get; set; }
        public DateTime? createDate { get; set; }
        public int? age { get; set; }
    }
}