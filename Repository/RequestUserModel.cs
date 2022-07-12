using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfullAPI.Repository
{
    public class RequestUserModel
    {
       
        public int user_id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string Gender { get; set; }
        public string address { get; set; }
    }
}
