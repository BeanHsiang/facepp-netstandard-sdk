using FacePlusPlus.Core;

namespace FacePlusPlus.ImagePP
{
    public class ImageLicensePlateResponseContent : APIResponseContent
    {
        /// <summary>
        /// result
        /// </summary>
        public LicensePlateResult[] result { get; set; }

        /// <summary>
        /// image id
        /// </summary>
        public string Image_Id { get; set; }
    }

    public struct LicensePlateResult
    {
        public Bound[] bound;
        public int color;
        public string license_plate_number;
    }

    public struct Bound
    {
        public Position right_top;
        public Position left_top;
        public Position right_bottom;
        public Position left_bottom;
    }
}
