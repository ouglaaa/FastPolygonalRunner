Shader "Custom/UnlitColor" {
	Properties {
		_MainColor ("MeshColor", 4D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;

		struct Input {
			float4 _MainColor;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			half4 c = _MainCOlor			
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
