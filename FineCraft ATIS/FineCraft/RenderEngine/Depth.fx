//-----------------------------------------
//	DepthMap
//-----------------------------------------

//------------------
//--- Parameters ---
float4x4 World : WORLD;
float4x4 View : VIEW;
float4x4 Projection : PROJECTION;
float MaxDepth;

//------------------
//--- Structures ---
struct VertexShaderOutput
{
	float4 position : POSITION;
	float depth : TEXCOORD0;
};

//--------------------
//--- VertexShader ---
VertexShaderOutput DepthMapVS( float4 inPos : POSITION )
{
	VertexShaderOutput OUT = (VertexShaderOutput)0;
	
	OUT.position = mul(mul(mul(inPos, World), View), Projection);
	OUT.depth = OUT.position.z / MaxDepth;
	
	return  OUT;
}

//-------------------
//--- PixelShader ---
float4 DepthMapPS(VertexShaderOutput IN) : COLOR0
{
    return float4(IN.depth, IN.depth, IN.depth, 1.0f);
}

//------------------
//--- Techniques ---
technique DepthMap
{
    pass P0
    {
          VertexShader = compile vs_2_0 DepthMapVS();
          PixelShader = compile ps_2_0 DepthMapPS();
    }
}

