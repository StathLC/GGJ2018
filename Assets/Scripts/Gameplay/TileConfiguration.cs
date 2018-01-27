using System;

[Serializable]
public class TileConfiguration
{
    public bool Top;
    public bool Bottom;
    public bool Right;
    public bool Left;
    public bool Entrance;
    public bool Exit;

    public TileConfiguration(bool top, bool bottom, bool right, bool left, bool entrance, bool exit)
    {
        this.Top = top;
        this.Bottom = bottom;
        this.Right = right;
        this.Left = left;
        this.Entrance = entrance;
        this.Exit = exit;
    }
}