using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToiecTest.BaseSecurity
{
    public class CustomPrincipalSerializeModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        
    }
}