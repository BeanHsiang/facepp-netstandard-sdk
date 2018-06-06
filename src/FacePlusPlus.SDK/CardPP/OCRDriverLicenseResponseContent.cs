using FacePlusPlus.Core;
using System.Collections.Generic;

namespace FacePlusPlus.CardPP
{
    public class OCRDriverLicenseResponseContent : APIResponseContent
    {
        /// <summary>
        /// cards
        /// </summary>
        public Main[] Main { get; set; }

        /// <summary>
        /// second
        /// </summary>
        public Second[] Second { get; set; }
    }

    public struct Second
    {
        public DriverLicenseValue license_number;
        public float confidence;
        public DriverLicenseValue name;
        public DriverLicenseValue file_number;
    }

    public struct DriverLicenseValue
    {
        public string content;
        public float confidence;
    }

    public struct Main
    {
        public float confidence;
        public DriverLicenseValue valid_from;
        public DriverLicenseValue name;
        public DriverLicenseValue gender;
        public DriverLicenseValue address;
        public DriverLicenseValue issued_by;
        public DriverLicenseValue issue_date;
        public DriverLicenseValue birthday;
        public DriverLicenseValue valid_for;
        public DriverLicenseValue version;
        public DriverLicenseValue license_number;
        public DriverLicenseValue nationality;
        public DriverLicenseValue valid_date;
        [Newtonsoft.Json.JsonProperty("class")]
        public DriverLicenseValue _class;
    }
}
