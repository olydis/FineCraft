uniform const texture BasicTexture;
uniform const texture TDepth;
uniform const texture THigh;
uniform const texture TLow;

uniform const sampler TextureSampler = sampler_state
{
	Texture = (BasicTexture);
	addressU = Clamp;
	addressV = Clamp;
	MipFilter = POINT;
	MinFilter = POINT;
	MagFilter = POINT;
};
uniform const sampler SDepth = sampler_state
{
	Texture = (TDepth);
	addressU = Clamp;
	addressV = Clamp;
	MipFilter = LINEAR;
	MinFilter = LINEAR;
	MagFilter = LINEAR;
};
uniform const sampler SHigh = sampler_state
{
	Texture = (THigh);
	addressU = Clamp;
	addressV = Clamp;
	MipFilter = POINT;
	MinFilter = POINT;
	MagFilter = POINT;
};
uniform const sampler SLow = sampler_state
{
	Texture = (TLow);
	addressU = Clamp;
	addressV = Clamp;
	MipFilter = LINEAR;
	MinFilter = LINEAR;
	MagFilter = LINEAR;
};

uniform const float		FogEnd;
uniform const float4	FogColor;
uniform const float4	AmbientLightColor;
uniform const float3	LightDirection;
uniform const float4x4	Projection;

struct VSOut
{
	float4	PositionPS	: POSITION;
	float4	Diffuse		: COLOR0;
	float2	TexCoord	: TEXCOORD0;
	float	Fog			: TEXCOORD1;
};
struct VSDOut
{
	float4	PositionPS	: POSITION;
	float2	TexCoord	: TEXCOORD0;
	float2	Depth    	: TEXCOORD1;
};
VSOut VSBasic(float4 Position : POSITION, float4 Normal : NORMAL, float2 TexCoord : TEXCOORD0, float4 Color : COLOR)
{
	VSOut vout;
	
	vout.PositionPS	= mul(Position, Projection);
	vout.Diffuse	= AmbientLightColor * (0.6 + 0.6 * dot(LightDirection, Normal)) * Color;
	vout.Diffuse.a  = Color.a;
	vout.TexCoord	= TexCoord;
	vout.Fog = pow(1 - (vout.PositionPS.z * FogEnd * 1.5f - 0.5f), 0.65);
	
	return vout;
}
float4 PSBasic(float4 Diffuse : COLOR0, float2 TexCoord : TEXCOORD0, float3 View : TEXCOORD2, float Fog : TEXCOORD1) : COLOR
{
	Diffuse = tex2D(TextureSampler, TexCoord) * Diffuse;

	clip( Diffuse.a < 0.1f ? -1 : 1 );

	Diffuse = lerp(FogColor, Diffuse, Fog);

	return Diffuse;  
}

VSDOut VSDepth(float4 Position : POSITION, float4 Normal : NORMAL, float2 TexCoord : TEXCOORD0, float4 Color : COLOR)
{
	VSDOut vout;
	
	vout.PositionPS	= mul(Position, Projection);
	vout.TexCoord	= TexCoord;
	vout.Depth		= vout.PositionPS.w * FogEnd;
	
	return vout;
}
float4 PSDepth(float2 TexCoord : TEXCOORD0, float depth : TEXCOORD1) : COLOR
{
	clip( tex2D(TextureSampler, TexCoord).a < 0.1f ? -1 : 1 );

	float4 color;
	color.r = depth;
	color.g = color.b = 1.0;
	color.a = 1.0;
	return color;
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

VSDOut VSCompose(float4 Position : POSITION, float2 TexCoord : TEXCOORD0)
{
	VSDOut vout;
	
	vout.PositionPS	= mul(Position, Projection);
	vout.TexCoord	= TexCoord;
	vout.Depth		= TexCoord;
	
	return vout;
}
float4 PSCompose(float2 TexCoord : TEXCOORD0) : COLOR
{
	float4 pixel = tex2D(SHigh, TexCoord);
	float4 depthCode = tex2D(SDepth, TexCoord);

	float depth = depthCode.r;

	if(depth < 0.05)
	{
		depth *= 20;
		depth = 1 - depth;
		depth *= depth;
	}
	else if(depth > 0.25)
	{
		depth -= 0.25;
		depth /= 0.75;
		depth = min(depth, 0.25f);
		depth = pow(depth, 0.8);
	}

	depth = depth * 0.8 + 0.2;	

	float away = depth * 0.005;

	float4 blurred = pixel;

	blurred += tex2D(SHigh, TexCoord + float2(away, 0));
	blurred += tex2D(SHigh, TexCoord + float2(0, away));
	blurred += tex2D(SHigh, TexCoord + float2(-away, 0));
	blurred += tex2D(SHigh, TexCoord + float2(0, -away));
	blurred += tex2D(SHigh, TexCoord + float2(-away, -away));
	blurred += tex2D(SHigh, TexCoord + float2(away, away));
	blurred += tex2D(SHigh, TexCoord + float2(-away, away));
	blurred += tex2D(SHigh, TexCoord + float2(away, -away));
	away *= 2;

	blurred += tex2D(SHigh, TexCoord + float2(away, 0));
	blurred += tex2D(SHigh, TexCoord + float2(0, away));
	blurred += tex2D(SHigh, TexCoord + float2(-away, 0));
	blurred += tex2D(SHigh, TexCoord + float2(0, -away));
	blurred += tex2D(SHigh, TexCoord + float2(-away, -away));
	blurred += tex2D(SHigh, TexCoord + float2(away, away));
	blurred += tex2D(SHigh, TexCoord + float2(-away, away));
	blurred += tex2D(SHigh, TexCoord + float2(away, -away));
	away *= 2;

	blurred /= 17;

	float4 col = lerp(
		pixel, 
		blurred,
		depth * depthCode.g);  
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
Technique DepthEffect
{
	Pass
	{
		VertexShader = compile vs_2_0 VSDepth();
		PixelShader = compile ps_2_0 PSDepth();
	}
}
Technique  ComposeEffect
{
	Pass
	{
		VertexShader = compile vs_2_0 VSCompose();
		PixelShader = compile ps_2_0 PSCompose();
	}
}