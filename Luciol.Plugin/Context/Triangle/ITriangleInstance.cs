﻿namespace Luciol.Plugin.Context.Triangle
{
    public interface ITriangleInstance
    {
        public int PixelSize { get; }
        public int CurrentZoom { get; }
        public void SetCurrentZoom(int zoom);
        public void Move(double x, double y);
    }
}
