using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeCheker_3.Models
{
    public class RegisterToCompany
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime Data { get; set; }
        public string Comment { get; set; }
    }
}