using FacePlusPlus.Core;
using System.Collections.Generic;

namespace FacePlusPlus.CardPP
{
    public class OCRIdCardResponseContent : APIResponseContent
    {
        /// <summary>
        /// cards
        /// </summary>
        public Card[] Cards { get; set; }

        /// <summary>
        /// image id
        /// </summary>
        public string Image_Id { get; set; }
    }

    public struct Card
    {
        public string gender;
        public string name;
        public string id_card_number;
        public string birthday;
        public string race;
        public string address;
        public Legality legality;
        public int type;
        public string side;
        public string issued_by;
        public string valid_date;
    }

    public class Legality : Dictionary<string, float>
    {
        public float Edited => this["Edited"];
        public float Photocopy => this["Photocopy"];
        public float IDPhoto => this["ID Photo"];
        public float Screen => this["Screen"];
        public float TemporaryIdPhoto => this["Temporary ID Photo"];
    }
}
