using System;

namespace LaavorRatingSwap
{
    /// <summary>
    /// AnimationDesign 
    /// </summary>
    [Obsolete("[This property will be discontinued in future releases] - Use now VivacityMode.")]
    public enum AnimationDesign
    {
        /// <summary>
        /// SingleItem
        /// </summary>
        SingleItem,
        /// <summary>
        /// AllSelected
        /// </summary>
        AllSelected,
        /// <summary>
        /// None
        /// </summary>
        None
    }

    /// <summary>
    /// AnimationSpeed 
    /// </summary>
    [Obsolete("[This property will be discontinued in future releases] - Use now VivacitySpeed.")]
    public enum AnimationSpeed
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
    /// AnimationEffect
    /// </summary>
    [Obsolete("[This property will be discontinued in future releases] - Use now Vivacity.")]
    public enum AnimationEffect
    {
        /// <summary>
        /// Standard
        /// </summary>
        Standard,
        /// <summary>
        /// Rotation
        /// </summary>
        Rotation,
        /// <summary>
        /// Jump
        /// </summary>
        Jump,
        /// <summary>
        /// Increase
        /// </summary>
        Increase
    }

    /// <summary>
    /// SwapAnimation 
    /// </summary>
    public enum SwapAnimation
    {
        /// <summary>
        /// Default
        /// </summary>
        Default,
        /// <summary>
        /// None
        /// </summary>
        None
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
        /// None
        /// </summary>
        None,
        /// <summary>
        /// Right
        /// </summary>
        Right,
        /// <summary>
        /// Left
        /// </summary>
        Left
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

    /// <summary>
    /// Letters
    /// </summary>
    public enum Letters
    {
        /// <summary>
        /// A
        /// </summary>
        A = 0,
        /// <summary>
        /// B
        /// </summary>
        B = 1,
        /// <summary>
        /// C
        /// </summary>
        C = 2,
        /// <summary>
        /// D
        /// </summary>
        D = 3,
        /// <summary>
        /// E
        /// </summary>
        E = 4,
        /// <summary>
        /// F
        /// </summary>
        F = 5,
        /// <summary>
        /// G
        /// </summary>
        G = 6,
        /// <summary>
        /// H
        /// </summary>
        H = 7,
        /// <summary>
        /// I
        /// </summary>
        I = 8,
        /// <summary>
        /// J
        /// </summary>
        J = 9,
        /// <summary>
        /// K
        /// </summary>
        K = 10,
        /// <summary>
        /// L
        /// </summary>
        L = 11,
        /// <summary>
        /// M
        /// </summary>
        M = 12,
        /// <summary>
        /// N
        /// </summary>
        N = 13,
        /// <summary>
        /// O
        /// </summary>
        O = 14,
        /// <summary>
        /// P
        /// </summary>
        P = 15,
        /// <summary>
        /// Q
        /// </summary>
        Q = 16,
        /// <summary>
        /// R
        /// </summary>
        R = 17,
        /// <summary>
        /// S
        /// </summary>
        S = 18,
        /// <summary>
        /// T
        /// </summary>
        T = 19,
        /// <summary>
        /// U
        /// </summary>
        U = 20,
        /// <summary>
        /// V
        /// </summary>
        V = 21,
        /// <summary>
        /// W
        /// </summary>
        W = 22,
        /// <summary>
        /// X
        /// </summary>
        X = 23,
        /// <summary>
        /// Y
        /// </summary>
        Y = 24,
        /// <summary>
        /// Z
        /// </summary>
        Z = 25

    }

}