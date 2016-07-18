Shader "Custom/NewSurfaceShader"
{
	Properties
	{
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM

			#pragma vertex VertexFunction
			#pragma fragment FragmentFunction

			struct VertexInput {
				float4 Vertex : POSITION;
			};

			struct VertexOutput {
				float4 Position : SV_POSITION;
			};

			VertexOutput VertexFunction(VertexInput i)
			{
				VertexOutput o;
				o.Position = mul(UNITY_MATRIX_MVP, i.Vertex);
				return o;
			}

			float4 FragmentFunction(VertexOutput i) : COLOR
			{
				return float4(1,1,0,1);
			}

			ENDCG
		}
	}

	FallBack "Diffuse"
}
