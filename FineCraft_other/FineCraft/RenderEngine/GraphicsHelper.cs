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
        static readonly int singleSize = 16;
        static readonly int allSize = 256;
        public static Vector2 TextureCoord(uint index)
        {
            return new Vector2(
                (index % (allSize / singleSize)) * singleSize / (float)allSize,
                index / singleSize * singleSize / (float)allSize);
        }
        public static Vector2 TextureXUnit = new Vector2(singleSize / (float)allSize, 0);
        public static Vector2 TextureYUnit = new Vector2(0, singleSize / (float)allSize);

        #endregion

        #region CharMap

        public static Texture2D charMap;



        #endregion

        #region ScreenRender



        #endregion
    }
}
