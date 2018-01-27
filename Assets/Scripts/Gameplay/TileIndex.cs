public enum TileIndex
{
    VisibleTopLeft,
    VisibleTopRight,
    VisibleBottomLeft,
    VisibleBottomRight,

    InvisibleTopLeft,
    InvisibleTopRight,

    InvisibleLeftTop,
    InvisibleLeftBottom,

    InvisibleRightTop,
    InvisibleRightBottom,

    InvisibleBottomLeft,
    InvisibleBottomRight

    /*
     *       ITL   ITR
     * ILT   VTL   VTR   IRT
     * ILB   VBL   VBR   IRB
     *       IBL   IBR
     */
}