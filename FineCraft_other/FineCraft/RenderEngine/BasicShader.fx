uniform const texture BasicTexture;

uniform const sampler TextureSampler = sampler_state
{
	Texture = (BasicTexture);
	MipFilter = POINT;
	MinFilter = POINT;
	MagFilter = POINT;
	//AddressU = WRAP;
	//AddressV = WRAP;
};

uniform const float	FogEnd;
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

VSOut VSBasic(float4 Position : POSITION, float3 Normal : NORMAL, float2 TexCoord : TEXCOORD0, float4 Color : COLOR)
{
	VSOut vout;
	
	vout.PositionPS	= mul(Position, Projection);
	vout.Diffuse	= AmbientLightColor * (0.6 + 0.4 * dot(LightDirection, Normal)) * Color;
	vout.Diffuse.a = Color.a;
	vout.TexCoord	= TexCoord;
	vout.Fog = 1 - (vout.PositionPS.z * FogEnd * 1.5f - 0.5f);
	
	return vout;
}
float4 PSBasic(float4 Diffuse : COLOR0, float2 TexCoord : TEXCOORD0) : COLOR
{
	return tex2D(TextureSampler, TexCoord) * Diffuse;
}

VSOut VSPlain(float4 Position : POSITION, float3 Normal : NORMAL, float2 TexCoord : TEXCOORD0, float4 Color : COLOR)
{
	VSOut vout;
	
	vout.PositionPS	= mul(Position, Projection);
	vout.Diffuse	= Color;
	vout.TexCoord	= TexCoord;
	vout.Fog = 1;
	
	return vout;
}

Technique BasicEffect
{
	Pass
	{
		VertexShader = compile vs_1_1 VSBasic();
		PixelShader = compile ps_1_4 PSBasic();
	}
}
Technique PlainEffect
{
	Pass
	{
		VertexShader = compile vs_1_1 VSPlain();
		PixelShader = compile ps_1_4 PSBasic();
	}
}