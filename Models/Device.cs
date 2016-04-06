using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DMS.Models
{
    public class Device
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int DeviceId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Name")]
        public string DeviceName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Owner")]
        public string DeviceOwner { get; set; }

        public virtual ICollection<DeviceSpecsContent> Specifications { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeviceDateCreated { get; set; }
        [Display(Name = "Created By")]
        public string DeviceCreatedBy { get; set; }
        [Display(Name = "Date Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeviceDateModified { get; set; }
        [Display(Name = "Modified By")]
        public string DeviceModifiedBy { get; set; }
    }

    public class DeviceSpecsContent
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int DeviceSpecsContentId { get; set; }

        [Display(Name = "Specs Category")]
        public int DeviceSpecsCatId { get; set; }
        public virtual DeviceSpecsCat DeviceSpecsCat { get; set; }

        [Display(Name = "Devices")]
        public int DeviceId { get; set; }
        public virtual Device Devices { get; set; }

        [Display(Name = "Specs Content")]
        public string DeviceSpecsContentVal { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeviceSpecsContentDateCreated { get; set; }
        [Display(Name = "Created By")]
        public string DeviceSpecsContentCreatedBy { get; set; }
        [Display(Name = "Date Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeviceSpecsContentDateModified { get; set; }
        [Display(Name = "Modified By")]
        public string DeviceSpecsContentModifiedBy { get; set; }
    }

    public class DeviceSpecsCat
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int DeviceSpecsCatId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Specs Category")]
        public string DeviceSpecsCatName { get; set; }

        public virtual ICollection<DeviceSpecsContent> Specifications { get; set; }
       
        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeviceSpecsCatDateCreated { get; set; }
        [Display(Name = "Created By")]
        public string DeviceSpecsCatCreatedBy { get; set; }
        [Display(Name = "Date Modified")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeviceSpecsCatDateModified { get; set; }
        [Display(Name = "Modified By")]
        public string DeviceSpecsCatModifiedBy { get; set; }

    }
    /*
    public class DeviceLog
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int DeviceLogId { get; set; }

        public int DeviceId { get; set; }

        //Foreign Key
        //[Display(Name = "Device")]
        //public int DeviceId { get; set; }
        //[ForeignKey("DeviceID")]

        //public ICollection<Device> Devices { get; set; }


        public string DeviceLogOldOwner { get; set; }
        public string DeviceLogNewOwner { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeviceLogDateCreated { get; set; }
        public string DeviceLogCreatedBy { get; set; }
    }*/
}