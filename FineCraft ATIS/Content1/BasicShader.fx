uniform const texture BasicTexture;

uniform const sampler TextureSampler = sampler_state
{
	Texture = (BasicTexture);
	MipFilter = POINT;
	MinFilter = POINT;//LINEAR;
	MagFilter = POINT;
	//AddressU = WRAP;
	//AddressV = WRAP;
};

uniform const float		FogEnd;
uniform const float4	AmbientLightColor;
uniform const float3	LightDirection;
uniform const float4x4	Projection;

struct VSOut
{
	float4	PositionPS	: POSITION;
	float4	Diffuse		: COLOR0;
	float2	TexCoord	: TEXCOORD0;
	float	Fog		: FOG;
};
VSOut VSBasic(float4 Position : POSITION, float4 Normal : NORMAL, float2 TexCoord : TEXCOORD0, float4 Color : COLOR)
{
	VSOut vout;
	
	vout.PositionPS	= mul(Position, Projection);
	vout.Diffuse	= AmbientLightColor * (0.6 + 0.6 * dot(LightDirection, Normal)) * Color;
	vout.Diffuse.a = Color.a;
	vout.TexCoord	= TexCoord;
	vout.Fog = pow(1 - (vout.PositionPS.z * FogEnd * 1.5f - 0.5f), 0.65);
	
	return vout;
}
float4 PSBasic(float4 Diffuse : COLOR0, float2 TexCoord : TEXCOORD0, float3 Normal : TEXCOORD1, float3 View : TEXCOORD2) : COLOR
{
	//float4  fVector = { Projection._m20, Projection._m21, Projection._m22, Projection._m23 };
	//float3 Half = normalize(LightDirection + normalize(fVector));   
    //float specular = pow(saturate(dot(Normal,Half)),25);
    
	return tex2D(TextureSampler, TexCoord) * Diffuse;  
}

VSOut VSPlain(float4 Position : POSITION, float4 Normal : NORMAL, float2 TexCoord : TEXCOORD0, float4 Color : COLOR)
{
	VSOut vout;
	
	vout.PositionPS	= mul(Position, Projection);
	vout.Diffuse	= Color;
	vout.TexCoord	= TexCoord;
	vout.Fog = 1;
	
	
	
	return vout;
}
float4 PSPlain(float4 Diffuse : COLOR0, float2 TexCoord : TEXCOORD0, float4 Normal : TEXCOORD1, float3 View : TEXCOORD2) : COLOR
{
	float4 col = tex2D(TextureSampler, TexCoord) * Diffuse;  
	return col;
}

Technique BasicEffect
{
	Pass
	{
		VertexShader = compile vs_2_0 VSBasic();
		PixelShader = compile ps_2_0 PSBasic();
	}
}
Technique PlainEffect
{
	Pass
	{
		VertexShader = compile vs_2_0 VSPlain();
		PixelShader = compile ps_2_0 PSPlain();
	}
}