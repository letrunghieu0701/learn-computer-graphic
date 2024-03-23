Shader "Graph/Point Surface" {
	Properties {
		_Smootheness ("Smoothness", Range(0,1)) = 0.5
	}

	SubShader {
		CGPROGRAM
		#pragma surface ConfigureSurface Standard fullforwardshadows
		#pragma target 3.0

		float _Smootheness;

		struct Input {
			float3 worldPos;
		};

		void ConfigureSurface (Input input, inout SurfaceOutputStandard surface) {
			surface.Albedo = saturate(input.worldPos * 0.5 + 0.5);
			surface.Smoothness = _Smootheness;
		}

		ENDCG
	}

	FallBack "Diffuse"
}