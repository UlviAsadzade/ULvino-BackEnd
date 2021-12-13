using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ulvino.Models;

namespace Ulvino.ViewModels
{
    public class AboutViewModel
    {
        public About Abouts { get; set; }
        public List<Feature> Features { get; set; }
        public List<Process> Processes { get; set; }
        public List<Team> Teams { get; set; }
        public Setting Settings { get; set; }
    }
}
