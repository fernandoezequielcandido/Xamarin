using System;
using System.Collections.Generic;
using System.Text;

namespace LaavorChoiceImage
{
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
    /// Vivacity
    /// </summary>
    public enum Vivacity
    {
        /// <summary>
        /// Increase
        /// </summary>
        Increase,
        /// <summary>
        /// Down
        /// </summary>
        Down,
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
        /// LessSlow
        /// </summary>
        LessSlow = 297,
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
}
