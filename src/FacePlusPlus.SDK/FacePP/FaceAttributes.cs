namespace FacePlusPlus.FacePP
{
    public struct FaceAttributes
    {
        public Emotion emotion;
        public Beauty beauty;
        public Gender gender;
        public Age age;
        public MouthStatus mouthstatus;
        public SkinStatus skinstatus;
        public HeadPose headpose;
        public Blur blur;
        public Smile smile;
        public EyeStatus eyestatus;
        public FaceQuality facequality;
        public Ethnicity ethnicity;
        public EyeStatus eyegaze;
    }

    public struct Emotion
    {
        public float sadness;
        public float neutral;
        public float disgust;
        public float anger;
        public float surprise;
        public float fear;
        public float happiness;
    }

    public struct Beauty
    {
        public float female_score;
        public float male_score;
    }

    public struct Gender
    {
        public string value;
    }

    public struct Age
    {
        public int value;
    }

    public struct MouthStatus
    {
        public float close;
        public float surgical_mask_or_respirator;
        public float open;
        public float other_occlusion;
    }

    public struct SkinStatus
    {
        public float dark_circle;
        public float stain;
        public float acne;
        public float health;
    }

    public struct HeadPose
    {
        public float yaw_angle;
        public float pitch_angle;
        public float roll_angle;
    }

    public struct Blur
    {
        public BlurValue blurness;
        public BlurValue motionblur;
        public BlurValue gaussianblur;
    }

    public struct BlurValue
    {
        public float threshold;
        public float value;
    }

    public struct Smile
    {
        public float threshold;
        public float value;
    }

    public struct FaceQuality
    {
        public float threshold;
        public float value;
    }

    public struct Ethnicity
    {
        public string value;
    }

    public struct Eyegaze
    {
        public Eye_Gaze left_eye_gaze;
        public Eye_Gaze right_eye_gaze;
    }

    public struct Eye_Gaze
    {
        public float position_x_coordinate;
        public float vector_z_component;
        public float vector_x_component;
        public float vector_y_component;
        public float position_y_coordinate;
    }

    public struct EyeStatus
    {
        public Eye_Status left_eye_status;
        public Eye_Status right_eye_status;
    }

    public struct Eye_Status
    {
        public float normal_glass_eye_open;
        public float no_glass_eye_close;
        public float occlusion;
        public float no_glass_eye_open;
        public float normal_glass_eye_close;
        public float dark_glasses;
    }
}
