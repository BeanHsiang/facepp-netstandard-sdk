using FacePlusPlus.Core;

namespace FacePlusPlus.CardPP
{
    public class OCRVehicleLicenseResponseContent : APIResponseContent
    {
        /// <summary>
        /// cards
        /// </summary>
        public VehicleLicense[] Cards { get; set; }

        /// <summary>
        /// image id
        /// </summary>
        public string Image_Id { get; set; }
    }

    public struct VehicleLicense
    {
        public string issue_date;
        public string vehicle_type;
        public string issued_by;
        public string vin;
        public string plate_no;
        public string side;
        public string use_character;
        public string address;
        public string owner;
        public string model;
        public string register_date;
        public int type;
        public string engine_no;
    }

}
