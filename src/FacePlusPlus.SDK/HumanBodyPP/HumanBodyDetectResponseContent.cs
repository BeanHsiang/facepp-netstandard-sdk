using FacePlusPlus.Core;
using System.Collections.Generic;

namespace FacePlusPlus.HumanBodyPP
{
    public class HumanBodyDetectResponseContent : APIResponseContent
    {
        /// <summary>
        /// Human Bodies
        /// </summary>
        public HumanBody[] HumanBodies { get; set; }

        /// <summary>
        /// image id
        /// </summary>
        public string Image_Id { get; set; }
    }

    public struct HumanBody
    {
        public string confidence;
        public HumanBodyRectangle humanbody_rectangle;
        public HumanBodyAttributes attributes;
    }

    public struct HumanBodyRectangle
    {
        public int top;

        public int left;

        public int width;

        public int height;
    }

    public struct HumanBodyAttributes
    {
        public Gender gender;
        public UpperBodyCloth upper_body_cloth;
        public LowerBodyCloth lower_body_cloth;
    }

    public struct Gender
    {
        public float male;
        public float female;
    }

    public struct UpperBodyCloth
    {
        public string upper_body_cloth_color;
        public ClothColor upper_body_cloth_color_rgb;
    }

    public struct LowerBodyCloth
    {
        public string lower_body_cloth_color;
        public ClothColor lower_body_cloth_color_rgb;
    }

    public struct ClothColor
    {
        public int r;
        public int g;
        public int b;
    }
}
