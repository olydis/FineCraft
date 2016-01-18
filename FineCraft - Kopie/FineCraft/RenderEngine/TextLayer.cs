using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace FineCraft.RenderEngine
{
    public class TextLayer : Layer
    {
        public TextLayer(string statictext, float depth, LayerDock xDock, LayerDock yDock, Func<bool> visible)
            : base(GraphicsHelper.charMap, 1024, depth, xDock, yDock, visible)
        {
            baseLength = statictext.Length;
            for (int i = 0; i < baseLength; i++)
                Write(statictext[i]);
        }

        static readonly int maxwidth = 32;

        int baseLength;

        public void SetText(string text)
        {
            Reset();
            foreach(char c in text)
                Write(c);
        }
        public new void Reset()
        {
            while (base.CellCount > baseLength)
                base.Pop();
        }
        public void Write(char c)
        {
            int left = base.CellCount;
            int top = -left / maxwidth;
            left %= maxwidth;
            byte b = Encoding.GetEncoding(1252).GetBytes(new char[] { c })[0];
            b -= 0x20;
            base.Push(new LayerCell
            {
                SourceTexture = new Rectangle(7 * (b % 16), 15 * (b / 16), 7, 15),
                DestinationScreen = new Rectangle(14 * left, 30 * top, 14, 30)
            });
        }
        public void Back()
        {
            if (base.CellCount > baseLength)
                base.Pop();
        }

        public int Height
        {
            get
            {
                return 30 * ((base.CellCount + 24) / 25);
            }
        }
    }
}
