<Serializable>
<Flags>
Public Enum BorderOption
    None = 0

    Top = 1 << 0
    Left = 1 << 1
    Right = 1 << 2
    Bottom = 1 << 3

    TopLeft = Top Or Left
    TopRight = Top Or Right
    TopLeftRight = Top Or Left Or Right
    TopLeftBottom = Top Or Left Or Bottom
    TopRightBottom = Top Or Right Or Bottom
    LeftBottom = Left Or Bottom
    RightBottom = Right Or Bottom
    LeftRightBottom = Left Or Right Or Bottom

    Horizontal = Top Or Bottom
    Vertical = Left Or Right
    Rectangle = Top Or Left Or Right Or Bottom

End Enum
