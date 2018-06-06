using FacePlusPlus.Core;
using System.Collections.Generic;

namespace FacePlusPlus.HumanBodyPP
{
    public class HumanBodyGestureResponseContent : APIResponseContent
    {
        /// <summary>
        /// hands
        /// </summary>
        public Hand[] hands { get; set; }

        /// <summary>
        /// image id
        /// </summary>
        public string Image_Id { get; set; }
    }

    public struct Hand
    {
        public HandRectangle hand_rectangle;
        public Gesture gesture;
    }

    public struct HandRectangle
    {
        public int top;

        public int left;

        public int width;

        public int height;
    }

    public struct Gesture
    {
        public float unknown;
        public float heart_a;
        public float heart_b;
        public float heart_c;
        public float heart_d;
        public float ok;
        public float hand_open;
        public float thumb_up;
        public float thumb_down;
        public float rock;
        public float namaste;
        public float palm_up;
        public float fist;
        public float index_finger_up;
        public float double_finger_up;
        public float victory;
        public float big_v;
        public float phonecall;
        public float beg;
        public float thanks;
    }
}
