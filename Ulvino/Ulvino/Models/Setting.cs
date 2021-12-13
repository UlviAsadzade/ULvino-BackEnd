using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ulvino.Models
{
    public class Setting
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 100)]
        public string HeaderLogo { get; set; }

        [StringLength(maximumLength: 100)]
        public string FooterLogo { get; set; }

        [StringLength(maximumLength: 100)]
        public string CustomerSubtitle { get; set; }

        [StringLength(maximumLength: 100)]
        public string CustomerTitle { get; set; }

        [StringLength(maximumLength: 100)]
        public string CustomerDesc { get; set; }

        [StringLength(maximumLength: 300)]
        public string FooterDesc { get; set; }

        [StringLength(maximumLength: 100)]
        public string ContactEmail { get; set; }

        [StringLength(maximumLength: 100)]
        public string EmailIcon { get; set; }

        [StringLength(maximumLength: 250)]
        public string Address { get; set; }

        [StringLength(maximumLength: 100)]
        public string LocationIcon { get; set; }

        [StringLength(maximumLength: 100)]
        public string HomeIcon { get; set; }

        [StringLength(maximumLength: 100)]
        public string Phone { get; set; }

        [StringLength(maximumLength: 100)]
        public string PhoneIcon { get; set; }

        [StringLength(maximumLength: 100)]
        public string WorkTime { get; set; }

        [StringLength(maximumLength: 100)]
        public string WorkTimeIcon { get; set; }

        [StringLength(maximumLength: 100)]
        public string Hotline { get; set; }

        [StringLength(maximumLength: 100)]
        public string HotlineImage { get; set; }

        [StringLength(maximumLength: 100)]
        public string SupportEmail { get; set; }

        [StringLength(maximumLength: 300)]
        public string Adress2 { get; set; }

        [StringLength(maximumLength: 100)]
        public string TwitterIcon { get; set; }

        [StringLength(maximumLength: 100)]
        public string TwitterUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string FacebookIcon { get; set; }

        [StringLength(maximumLength: 100)]
        public string FacebookUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string YoutubeIcon { get; set; }

        [StringLength(maximumLength: 100)]
        public string YoutubeUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string GooglePlusIcon { get; set; }

        [StringLength(maximumLength: 100)]
        public string GooglePlusUrl { get; set; }

        [StringLength(maximumLength: 100)]
        public string PinterestIcon { get; set; }

        [StringLength(maximumLength: 100)]
        public string PinterestUrl { get; set; }

        [StringLength(maximumLength: 300)]
        public string ProcessDesc { get; set; }

        [StringLength(maximumLength: 300)]
        public string MapUrl { get; set; }
        


        [NotMapped]
        public IFormFile HeaderLogoFile { get; set; }

        [NotMapped]
        public IFormFile FooterLogoFile { get; set; }

        [NotMapped]
        public IFormFile HotlineFile { get; set; }

    }
}
