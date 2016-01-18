uniform const texture BasicTexture;
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
	
	Color.a = 1.0;
	float4 theColor = max(AmbientLightColor, Color);

	vout.PositionPS	= mul(Position, Projection);
	vout.Diffuse	= theColor * (0.8 + 0.5 * dot(LightDirection, Normal)) + Color * 0.2;
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
	Diffuse.a = Fog;

	return Diffuse;  
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
	Diffuse = tex2D(TextureSampler, TexCoord) * Diffuse;  
	clip( Diffuse.a < 0.1f ? -1 : 1 );
	return Diffuse;
}

VSDOut VSCompose(float4 Position : POSITION, float2 TexCoord : TEXCOORD0)
{
	VSDOut vout;
	
	vout.PositionPS	= mul(Position, Projection);
	vout.TexCoord	= TexCoord;
	vout.Depth		= TexCoord;
	
	return vout;
} 
float4 AdjustSaturation(float4 color, float saturation)   
{   
    float grey = dot(color, float3(0.3, 0.59, 0.11));   
    return lerp(grey, color, saturation);   
}  

float FindMedian(float a, float b, float c)
{
	if( a < b )
	{
		if( b < c)
			return b;
		else
			return max(a,c);
	}
	else
	{
		if( a < c)
			return a;
		else
			return max(b,c);
	}
}
float FindMedian(float a, float b, float c, float d, float e)
{
	return FindMedian(FindMedian(a,b,c), e, d);
}
float4 FindMedian(float4 a, float4 b, float4 c, float4 d, float4 e)
{
	return float4(
		FindMedian(a.r, b.r, c.r, d.r, e.r),
		FindMedian(a.g, b.g, c.g, d.g, e.g),
		c.b,	//FindMedian(a.b, b.b, c.b, d.b, e.b),
		c.a); //FindMedian(a.a, b.a, c.a, d.a, e.a));
}


float4 PSCompose(float2 TexCoord : TEXCOORD0) : COLOR
{ 
	float BloomSaturation = 0.3;
	float BloomIntensity = 0.5;
	float BaseSaturation = 1;
	float BaseIntensity = 1;
	float BloomThreshold = 0.7;

	float4 bloom = tex2D(SLow, TexCoord);   
	bloom = saturate((bloom - BloomThreshold) / (1 - BloomThreshold));


    float4 base = tex2D(SHigh, TexCoord);

	//// crazy median
	/*float4 result;
	
	float d0 = -0.001;
	float d1 = 0;
	float d2 = +0.001;
	
	result = FindMedian(
		tex2D(SHigh, float2(TexCoord.x + d1, TexCoord.y + d0)),
		tex2D(SHigh, float2(TexCoord.x + d0, TexCoord.y + d1)),
		tex2D(SHigh, float2(TexCoord.x + d1, TexCoord.y + d1)),
		tex2D(SHigh, float2(TexCoord.x + d2, TexCoord.y + d1)),
		tex2D(SHigh, float2(TexCoord.x + d1, TexCoord.y + d2))
	); 
	float4 base = result;*/
	
	//// end median
 
    bloom = AdjustSaturation(bloom, BloomSaturation) * BloomIntensity;   
    base = AdjustSaturation(base, BaseSaturation) * BaseIntensity;   

    base *= (1 - saturate(bloom));   

    float4 ret = base + bloom;

	float sharp = ret.a;
	sharp = pow(sharp, 4);
	sharp -= 0.3f;
	sharp = saturate(sharp);
	ret = ret * sharp + tex2D(SLow, TexCoord) * (1 - sharp);
	//ret = tex2D(SLow, TexCoord);

	ret.a = 1;
	return ret;   
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
Technique  ComposeEffect
{
	Pass
	{
		VertexShader = compile vs_2_0 VSCompose();
		PixelShader = compile ps_2_0 PSCompose();
	}
}