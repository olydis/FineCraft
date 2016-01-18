using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace FineCraft.RenderEngine
{
    class MyLogger : ContentBuildLogger
    {
        public override void LogMessage(string message, params object[] messageArgs) { }
        public override void LogImportantMessage(string message, params object[] messageArgs) { }
        public override void LogWarning(string helpLink, ContentIdentity contentIdentity, string message, params object[] messageArgs) { }
    }
    class MyProcessorContext : ContentProcessorContext
    {
        public override TargetPlatform TargetPlatform { get { return TargetPlatform.Windows; } }
        public override GraphicsProfile TargetProfile { get { return GraphicsProfile.Reach; } }
        public override string BuildConfiguration { get { return string.Empty; } }
        public override string IntermediateDirectory { get { return string.Empty; } }
        public override string OutputDirectory { get { return string.Empty; } }
        public override string OutputFilename { get { return string.Empty; } }

        public override OpaqueDataDictionary Parameters { get { return parameters; } }
        OpaqueDataDictionary parameters = new OpaqueDataDictionary();

        public override ContentBuildLogger Logger { get { return new MyLogger(); } }

        public override void AddDependency(string filename) { }
        public override void AddOutputFile(string filename) { }

        public override TOutput Convert<TInput, TOutput>(TInput input, string processorName, OpaqueDataDictionary processorParameters) { throw new NotImplementedException(); }
        public override TOutput BuildAndLoadAsset<TInput, TOutput>(ExternalReference<TInput> sourceAsset, string processorName, OpaqueDataDictionary processorParameters, string importerName) { throw new NotImplementedException(); }
        public override ExternalReference<TOutput> BuildAsset<TInput, TOutput>(ExternalReference<TInput> sourceAsset, string processorName, OpaqueDataDictionary processorParameters, string importerName, string assetName) { throw new NotImplementedException(); }
    }
    public class AwesomeEffect
    {
        public AwesomeEffect()
        {
            Assembly _Assembly = Assembly.GetExecutingAssembly();
            string s = new StreamReader(_Assembly.GetManifestResourceStream("FineCraft.RenderEngine.BasicShader.fx")).ReadToEnd();
        
            EffectProcessor ep = new EffectProcessor();
            var ec = new EffectContent();
            ec.EffectCode = s;
            var cec = ep.Process(ec, new MyProcessorContext());
            effect = new Effect(Static.Device, cec.GetEffectCode());
        }

        Effect effect;

        public Color FogColor
        {
            get
            {
                return Color.CornflowerBlue;//Static.Device.RenderState.FogColor;
            }
            set
            {
                //Static.Device.RenderState.FogColor = value;
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

        public void Apply3D()
        {
            effect.Techniques[0].Passes[0].Apply();
        }
        public void Apply2D()
        {
            effect.Techniques[1].Passes[0].Apply();
        }
    }
}
