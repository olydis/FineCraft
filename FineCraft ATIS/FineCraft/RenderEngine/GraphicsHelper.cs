using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FineCraft.Properties;
using Microsoft.Xna.Framework;

namespace FineCraft.RenderEngine
{
    public static class GraphicsHelper
    {
        public static void Init()
        {
            BasicTexture = Convert(Resources.Textures, Static.Device);
            charMap = Convert(Resources.charMap, Static.Device);
        }

        #region converters

        //Bitmap -> Texture2D
        public static Texture2D Convert(Bitmap b, GraphicsDevice gd)
        {
            Texture2D t = new Texture2D(gd, b.Width, b.Height);

            int[] arr = new int[b.Width * b.Height];
            var bd = b.LockBits(new System.Drawing.Rectangle(0,0,b.Width, b.Height),System.Drawing.Imaging.ImageLockMode.ReadOnly,System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Marshal.Copy(bd.Scan0, arr, 0, arr.Length);
            b.UnlockBits(bd);
            for(int i = 0; i < arr.Length; i++)
                arr[i] =(int)
                            ((arr[i] & 0x000000FFU) << 16 | (arr[i] & 0x0000FF00U) << 0 |
                            (arr[i] & 0x00FF0000U) >> 16 | (arr[i] & 0xFF000000U) >> 0);

            t.SetData<int>(arr);

            return t;
        }

        //Bitmap -> Cursor
        public struct IconInfo
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);
        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);
        public static Cursor Convert(Bitmap b, int centerX, int centerY)
        {
            IntPtr ptr = b.GetHicon();
            IconInfo tmp = new IconInfo();
            GetIconInfo(ptr, ref tmp);
            tmp.xHotspot = centerX;
            tmp.yHotspot = centerY;
            tmp.fIcon = false;
            ptr = CreateIconIndirect(ref tmp);
            return new Cursor(ptr);
        }

        #endregion

        #region std-texturemap

        public static Texture2D BasicTexture;

        //texture index -> texture coordinate
        static readonly int parts = 16;
        public static Vector2 TextureCoord(uint index)
        {
            return new Vector2(
                (float)(index % parts) / parts,
                (float)(index / parts) / parts);
        }
        public static Vector2 TextureXUnit = new Vector2(1f / parts, 0);
        public static Vector2 TextureYUnit = new Vector2(0, 1f / parts);

        #endregion

        #region CharMap

        public static Texture2D charMap;



        #endregion

        #region ScreenRender



        #endregion
    }
}
