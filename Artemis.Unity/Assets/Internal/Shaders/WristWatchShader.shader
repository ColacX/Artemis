Shader "Custom/WristWatchShader"
{
	Properties
	{
		ElapsedTime("ElapsedTime", Float) = 0
		BaseTexture("BaseTexture", 2D) = "white" {}
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex VertexFunction
			#pragma fragment FragmentFunction

			float ElapsedTime;
			sampler2D BaseTexture;

			struct VertexInput {
				float4 Vertex : POSITION;
				float2 UV : TEXCOORD0;
			};

			struct VertexOutput {
				float4 Position : SV_POSITION;
				float2 UV : TEXCOORD0;
			};

			VertexOutput VertexFunction(VertexInput i)
			{
				VertexOutput o;
				o.Position = mul(UNITY_MATRIX_MVP, i.Vertex);
				o.UV = i.UV;
				return o;
			}

			float4 FragmentFunction(VertexOutput i) : COLOR
			{
				//discard;
				float4 baseColor = tex2D(BaseTexture, float2(i.UV.x, i.UV.y));
				return float4(
					baseColor.x * sin(ElapsedTime * 0.001) + 0.2,
					baseColor.y * sin(ElapsedTime * 0.002) + 0.2,
					baseColor.z * sin(ElapsedTime * 0.003) + 0.2,
					baseColor.w);
				//return baseColor * (ElapsedTime * 0.01 % 1);
				//return float4(ElapsedTime % 1,0,0,1);
			}

			ENDCG
		}
	}
	FallBack "Diffuse"
}
