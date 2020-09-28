using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSigma.Models
{
    public class State
    {
        public string Name { get; set; }
        public IList<string> Cities { get; set; }
    }
}