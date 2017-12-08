Shader "Custom/UVOffset" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Offset ("UV_Offset", Vector) = (0, 0, 0, 0)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert

		sampler2D _MainTex;
		float4 _Offset;

		struct Input {
			float2 uv_MainTex;
		};

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex - _Offset.xy);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
