using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Super_Heroes.Models
{
    public class SuperHeroModel
    {
        [Key]
        public int Id { get; set; }
        public string SuperHeroName { get; set; }

        public string primarysuperheroability { get; set; }
        public string secondarysuperheroability { get; set; }
        public string alterego { get; set; }
        public string catchPhrase { get; set; }
    }
}