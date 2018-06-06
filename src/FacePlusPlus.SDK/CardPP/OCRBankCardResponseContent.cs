using FacePlusPlus.Core;
using System.Collections.Generic;

namespace FacePlusPlus.CardPP
{
    public class OCRBankCardResponseContent : APIResponseContent
    {
        /// <summary>
        /// bank cards
        /// </summary>
        public BankCard[] bank_cards { get; set; }

        /// <summary>
        /// image id
        /// </summary>
        public string Image_Id { get; set; }
    }

    public struct BankCard
    {
        public string number;
        public string bank;
        public Bound bound;
        public string[] organization;
    }

    public struct Bound
    {
        public BoundValue left_bottom;
        public BoundValue right_top;
        public BoundValue right_bottom;
        public BoundValue left_top;
    }

    public struct BoundValue
    {
        public int y;
        public int x;
    }
}
