namespace Laavor
{
    /// <summary>
    /// DesignType
    /// </summary>
    public enum DesignType
    {
        /// <summary>
        /// Allonsy
        /// </summary>
        Allonsy,
        /// <summary>
        /// Cadre
        /// </summary>
        Cadre,
        /// <summary>
        /// Fit
        /// </summary>
        Fit,
        /// <summary>
        /// Filled
        /// </summary>
        Filled,
        /// <summary>
        /// Scratches
        /// </summary>
        Scratches,
        /// <summary>
        /// Shinning
        /// </summary>
        Shinning,
        /// <summary>
        /// Smoke
        /// </summary>
        Smoke
    }

    /// <summary>
    /// Vivacity
    /// </summary>
    public enum Vivacity
    {
        /// <summary>
        /// Increase
        /// </summary>
        Increase,
        /// <summary>
        /// Decrease
        /// </summary>
        Decrease,
        /// <summary>
        /// Jump
        /// </summary>
        Jump,
        /// <summary>
        /// Rotation
        /// </summary>
        Rotation,
        /// <summary>
        /// Down
        /// </summary>
        Down,
        /// <summary>
        /// Left
        /// </summary>
        Left,
        /// <summary>
        /// Right
        /// </summary>
        Right,
        /// <summary>
        /// None
        /// </summary>
        None
    }

    /// <summary>
    /// Depth
    /// </summary>
    public enum Depth
    {
        /// <summary>
        /// Small
        /// </summary>
        Small,
        /// <summary>
        /// LessMedium
        /// </summary>
        LessMedium,
        /// <summary>
        /// Medium
        /// </summary>
        Medium,
        /// <summary>
        /// Large
        /// </summary>
        Large
    }

    /// <summary>
    /// VivacitySpeed 
    /// </summary>
    public enum VivacitySpeed
    {
        /// <summary>
        /// Slow
        /// </summary>
        Slow = 197,
        /// <summary>
        /// Normal
        /// </summary>
        Normal = 100,
        /// <summary>
        /// Fast
        /// </summary>
        Fast = 54
    }

    /// <summary>
    /// Icon Type
    /// </summary>
    public enum IconType
    {
        /// <summary>
        /// Configuration
        /// </summary>
        Configuration = 0,
        /// <summary>
        /// Cut
        /// </summary>
        Cut = 1,
        /// <summary>
        /// Like
        /// </summary>
        Like = 2,
        /// <summary>
        /// Mail
        /// </summary>
        Mail = 3,
        /// <summary>
        /// Question
        /// </summary>
        Question = 4,
        /// <summary>
        /// Share
        /// </summary>
        Share = 5,
        /// <summary>
        /// Copy
        /// </summary>
        Copy = 6,
        /// <summary>
        /// Edit
        /// </summary>
        Edit = 7,
        /// <summary>
        /// Paste
        /// </summary>
        Paste = 8,
        /// <summary>
        /// Pencil
        /// </summary>
        Pencil = 9,
        /// <summary>
        /// Plus
        /// </summary>
        Plus = 10,
        /// <summary>
        /// Subtraction
        /// </summary>
        Subtraction = 11,
        /// <summary>
        /// Sphere
        /// </summary>
        Sphere = 12,
        /// <summary>
        /// Star
        /// </summary>
        Star = 13,
        /// <summary>
        /// Eye
        /// </summary>
        Eye = 14,
        /// <summary>
        /// Box
        /// </summary>
        Box = 15,
        /// <summary>
        /// SearchLeft
        /// </summary>
        SearchLeft = 16,
        /// <summary>
        /// Heart
        /// </summary>
        Heart = 17,
        /// <summary>
        /// Flag
        /// </summary>
        Flag = 18,
        /// <summary>
        /// ArrowLeft
        /// </summary>
        ArrowLeft = 19,
        /// <summary>
        /// ArrowRight
        /// </summary>
        ArrowRight = 20,
        /// <summary>
        /// ArrowDown
        /// </summary>
        ArrowDown = 21,
        /// <summary>
        /// ArrowUp
        /// </summary>
        ArrowUp = 22,
        /// <summary>
        /// Keyboard
        /// </summary>
        Keyboard = 23,
        /// <summary>
        /// Person
        /// </summary>
        Person = 24
    }

    /// <summary>
    /// Position Content
    /// </summary>
    public enum PositionContent
    {
        /// <summary>
        /// LeftTop
        /// </summary>
        LeftTop,
        /// <summary>
        /// LeftMidle
        /// </summary>
        LeftMidle,
        /// <summary>
        /// LeftBottom
        /// </summary>
        LeftBottom,
        /// <summary>
        /// CenterTop
        /// </summary>
        CenterTop,
        /// <summary>
        /// CenterMidle
        /// </summary>
        CenterMidle,
        /// <summary>
        /// CenterBottom
        /// </summary>
        CenterBottom,
        /// <summary>
        /// RightTop
        /// </summary>
        RightTop,
        /// <summary>
        /// RightMidle
        /// </summary>
        RightMidle,
        /// <summary>
        /// RightBottom
        /// </summary>
        RightBottom
    }

    /// <summary>
    /// Class ChoiceOrientation
    /// </summary>
    public enum ChoiceOrientation
    {
        /// <summary>
        /// Choice should be vertically oriented.
        /// </summary>
        Vertical = 0,
        /// <summary>
        /// Choice should be horizontally oriented.
        /// </summary>
        Horizontal = 1
    }

    /// <summary>
    /// TouchType
    /// </summary>
    public enum TouchType
    {
        /// <summary>
        /// Unique
        /// </summary>
        Unique,
        /// <summary>
        /// WithText
        /// </summary>
        WithText
    }

    /// <summary>
    /// VivacityMode
    /// </summary>
    public enum VivacityMode
    {
        /// <summary>
        /// Single
        /// </summary>
        Single,
        /// <summary>
        /// All
        /// </summary>
        All
    }

    /// <summary>
    /// State
    /// </summary>
    public enum State
    {
        /// <summary>
        /// On
        /// </summary>
        On,
        /// <summary>
        /// Off
        /// </summary>
        Off
    }

    /// <summary>
    /// DrawType
    /// </summary>
    public enum DrawType
    {
        /// <summary>
        /// Star 
        /// </summary>
        Star,
        /// <summary>
        /// Heart
        /// </summary>
        Heart
    }

    /// <summary>
    /// State Expander
    /// </summary>
    public enum StateExpander
    {
        /// <summary>
        /// Open
        /// </summary>
        Open,
        /// <summary>
        /// Close
        /// </summary>
        Close
    }

    /// <summary>
    /// ValidationType
    /// </summary>
    public enum ValidationType
    {
        /// <summary>
        /// CharacterToCharacter
        /// </summary>
        CharacterToCharacter,
        /// <summary>
        /// WhenLoseFocus
        /// </summary>
        WhenLoseFocus
    }

    /// <summary>
    /// NumericType
    /// </summary>
    public enum NumericType
    {
        /// <summary>
        /// Integer
        /// </summary>
        Integer,
        /// <summary>
        /// Double
        /// </summary>
        Double
    }

    /// <summary>
    /// LineSize
    /// </summary>
    public enum LineSize
    {
        /// <summary>
        /// One 
        /// </summary>
        One,
        /// <summary>
        /// Two
        /// </summary>
        Two,
        /// <summary>
        /// Three
        /// </summary>
        Three,
        /// <summary>
        /// Four
        /// </summary>
        Four
    }

    /// <summary>
    /// LineType
    /// </summary>
    public enum LineType
    {
        /// <summary>
        /// Single
        /// </summary>
        Single,
        /// <summary>
        /// Double
        /// </summary>
        Double
    }

    /// <summary>
    /// ImagePosition
    /// </summary>
    public enum ImagePosition
    {
        /// <summary>
        /// Left 
        /// </summary>
        Left,
        /// <summary>
        /// Right
        /// </summary>
        Right
    }

    /// <summary>
    /// Side
    /// </summary>
    public enum Side
    {
        /// <summary>
        /// Left
        /// </summary>
        Left,
        /// <summary>
        /// Right
        /// </summary>
        Right
    }

    /// <summary>
    /// Answer
    /// </summary>
    public enum Answer
    {
        /// <summary>
        /// Confirmed
        /// </summary>
        Confirmed,
        /// <summary>
        /// Canceled
        /// </summary>
        Canceled
    }

    /// <summary>
    /// Sequence
    /// </summary>
    public enum Sequence
    {
        /// <summary>
        /// First
        /// </summary>
        First,
        /// <summary>
        /// Second
        /// </summary>
        Second
    }
}
