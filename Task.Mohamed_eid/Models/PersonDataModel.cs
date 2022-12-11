using DomainLayer.BankTypes;
using DomainLayer.DamageTypes;
using DomainLayer.Region;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Mohamed_eid.Models
{
    public class PersonDataModel : BaseModel
    {
        public int DataPersonsId { get; set; }

        [Display(Name ="رقم الهوية")]
        [Required(ErrorMessage ="رقم الهويه مطلوب")]
        [StringLength(10,ErrorMessage ="اقصي عدد 10 حروف")]
        public string Iqama { get; set; }

        [Display(Name = "رقم الجوال")]
        [Required(ErrorMessage = "رقم الجوال مطلوب")]
        [StringLength(10, ErrorMessage = "اقصي عدد 12 حروف")]
        public string PhoneNumber { get; set; }

        [Display(Name = "تاريخ الضر")]
        [Required(ErrorMessage = "تاريخ الضرر مطلوب")]
        [DataType(DataType.DateTime,ErrorMessage ="ادخل التاريخ بشكل صحيح")]
        public DateTime? DamageDate { get; set; }

        [Display(Name ="اختار اسم البنك")]
        [Required(ErrorMessage = "اسم البنك مطلوب")]
        public int BankTypesId { get; set; }
        public  BankType BankTypes { get; set; }


        [Display(Name = "اختار نوع الضرر")]
        [Required(ErrorMessage = " نوع الضرر مطلوب")]
        public int DamageTypeId { get; set; }
        public  DamageType DamageType { get; set; }

        /*----------------------------------------------------- */
        [Display(Name = "اختار المنطقه")]
        [Required(ErrorMessage = "  المنطقة مطلوب")]
        public int RegionsId { get; set; }
        public  RegionsEntity Regions { get; set; }

        [Display(Name = "المدينة")]
        [StringLength(50, ErrorMessage = "اقصي عدد 50 حروف")]
        public string City { get; set; }

        [Display(Name = "الحي")]
        [StringLength(50, ErrorMessage = "اقصي عدد 50 حروف")]
        public string AreaQuarter { get; set; }

        [Display(Name = "الشارع")]
        [StringLength(50, ErrorMessage = "اقصي عدد 50 حروف")]
        public string Street { get; set; }

        [Display(Name = "الرقم البريدي")]
        [StringLength(5, ErrorMessage = "اقصي عدد 5 حروف")]
        public string PostalCode { get; set; }

        [Display(Name = "صورة الضرر")]
        public string DamageImage { get; set; }

        [Display(Name = "صورة المركبة")]
        public string VehicleImage { get; set; }

        [Display(Name = "التأمين")]
        [Required(ErrorMessage = "التامين مطلوب")]
        public int InsurranceId { get; set; }

        /*----------------------------------*/

        [Display(Name = "الايبان")]
        [StringLength(24, ErrorMessage = "اقصي عدد 24 حروف")]
        [Required(ErrorMessage ="الايبان مطلوب")]
        public string IBAN { get; set; }


        public IFormFile DamageImageFile { get; set; }
        public IFormFile VehicleImageFile { get; set; }

        /*-------------------- For display ------------------*/
        public string str_Damage { get; set; }
        public string str_Region { get; set; }
        public string str_Insurrance { get; set; }

    }
}
