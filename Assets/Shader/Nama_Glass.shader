Shader "Nama/Glass" {
	Properties {
		_Color ("Color", Vector) = (1,1,1,1)
		_SpecularColor ("Specular Color", Vector) = (1,1,1,1)
		_Shininess ("Shininess", Range(0.01, 1)) = 0.1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
		LOD 200
		CGPROGRAM
#pragma surface surf Standard
#pragma target 3.0

		fixed4 _Color;
		struct Input
		{
			float2 uv_MainTex;
		};
		
		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			o.Albedo = _Color.rgb;
			o.Alpha = _Color.a;
		}
		ENDCG
	}
}