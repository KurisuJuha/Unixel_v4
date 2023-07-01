using UnityEngine;

namespace JuhaKurisu.Unixels.V4
{
    public sealed class Unixel
    {
        public readonly int width;
        public readonly int height;
        public Color32[] colors;

        public Unixel(int width, int height)
        {
            this.width = width;
            this.height = height;
            colors = new Color32[width * height];
        }

        public void SetPixel(int x, int y, Color32 color)
        {
            // 範囲外はエラー
            if (x < 0 || y < 0 || x > width || y > height) throw new System.Exception();
            colors[y * width + x] = color;
        }

        public void Clear(Color color)
        {
            for (int i = 0; i < colors.Length; i++) colors[i] = color;
        }
    }
}