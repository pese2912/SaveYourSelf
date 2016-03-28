Shader "Custom/Water Reflective Simple" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
		_Cube ("Reflection Cubemap", Cube) = "_Skybox" { }
	}
	SubShader {
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		ZWrite on Cull Back
		Blend SrcAlpha OneMinusSrcAlpha
		
		CGPROGRAM
		#pragma surface surf Lambert approxview halfasview alpha:blend
		#pragma target 3.0
		
		samplerCUBE _Cube;
		
		fixed4 _Color;
		fixed4 _ReflectColor;
		
		struct Input {
			float3 worldRefl;
		};
		
		void surf (Input IN, inout SurfaceOutput o) {
			o.Albedo = _Color.rgb;
			
			half3 worldRefl = WorldReflectionVector (IN, o.Normal);
			fixed4 reflcol = texCUBE (_Cube, worldRefl);
			
			o.Emission = reflcol.rgb * (_ReflectColor.rgb * _ReflectColor.rgb);
			o.Alpha = length(reflcol.rgb) * _ReflectColor.a * _Color.a;
		}
		ENDCG
	}
	
	FallBack "Reflective/Bumped Specular"
}
