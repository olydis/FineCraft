using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using System.IO;

namespace FineCraft.RenderEngine
{
    public class AwesomeEffect
    {
        public AwesomeEffect()
        {
            Assembly _Assembly = Assembly.GetExecutingAssembly();
            string s = new StreamReader(_Assembly.GetManifestResourceStream("FineCraft.RenderEngine.BasicShader.fx")).ReadToEnd();
            var ce = Effect.CompileEffectFromSource(s, null, null, CompilerOptions.None, TargetPlatform.Windows);
            if (!ce.Success)
            {
                MessageBox.Show(ce.ErrorsAndWarnings, "Effect compilation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            effect = new Effect(Static.Device, ce.GetEffectCode(), CompilerOptions.None, null);
        }

        Effect effect;

        public Color FogColor
        {
            get
            {
                return Static.Device.RenderState.FogColor;
            }
            set
            {
                Static.Device.RenderState.FogColor = value;
            }
        }
        public Vector3 LightDirection
        {
            set
            {
                value.Normalize();
                effect.Parameters["LightDirection"].SetValue(value);
            }
        }
        public Vector4 AmbientLightColor
        {
            set
            {
                effect.Parameters["AmbientLightColor"].SetValue(value);
            }
        }
        Matrix vp;
        Matrix w;
        void setWVP()
        {
            effect.Parameters["Projection"].SetValue(w * vp);
        }
        public Matrix WMatrix
        {
            set
            {
                w = value;
                setWVP();
            }
        }
        public Matrix VPMatrix
        {
            set
            {
                vp = value;
                setWVP();
            }
        }
        public Texture2D Texture
        {
            set
            {
                effect.Parameters["BasicTexture"].SetValue(value);
            }
        }
        float fogEnd = 0;
        public float FogEnd
        {
            get
            {
                return fogEnd;
            }
            set
            {
                effect.Parameters["FogEnd"].SetValue(1 / (fogEnd = value));
            }
        }

        public void Begin()
        {
            effect.Begin();
        }
        public void End()
        {
            effect.End();
        }
        public void BeginPass3D()
        {
            effect.Techniques[0].Passes[0].Begin();
        }
        public void EndPass3D()
        {
            effect.Techniques[0].Passes[0].End();
        }
        public void BeginPass2D()
        {
            effect.Techniques[1].Passes[0].Begin();
        }
        public void EndPass2D()
        {
            effect.Techniques[1].Passes[0].End();
        }
    }
}
