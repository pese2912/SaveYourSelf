Shader "Custom/Water Reflective Simple (Obstruction Alpha)" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_ReflectColor ("Reflection Color", Color) = (1,1,1,0.5)
		_Cube ("Reflection Cubemap", Cube) = "_Skybox" { }
		_ObstructionMaskOpacity ("Obstruction mask alpha influence", Range (0.0, 1.0)) = 0
	}
	SubShader {
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		ZWrite on Cull back
		Blend SrcAlpha OneMinusSrcAlpha
		
		CGPROGRAM
		#pragma surface surf Lambert alpha:blend
		#pragma target 3.0
		
		sampler2D _BumpMap;
		samplerCUBE _Cube;
		
		fixed4 _Color;
		fixed4 _ReflectColor;
		fixed _ObstructionMaskOpacity;
		
		struct Input {
			float2 uv_BumpMap;
			float3 worldRefl; 
			fixed4 color : COLOR;
			INTERNAL_DATA
		};
		
		void surf (Input IN, inout SurfaceOutput o) {
			// In the vertex color, red channel corresponds to the additinal dampening in that point,
			// where value of 255 means zero dampening and value of 1 means maximum dampening.
			// 0 is a special value that corresponds to the situation when the vertex 
			// is fully obstructed by obstruction geometry. In this case, a value of 255
			// is additionaly written to the blue channel.

			// Clip the fully obstructed fragments
			clip(IN.color.b > 0.5f ? -1 : 1);

			// Calculating the opacity depending on the dampening in that vertex
			fixed maskOpacity = clamp(_ObstructionMaskOpacity + IN.color.r, 0, 1);
			o.Albedo = _Color.rgb * maskOpacity;

			// Calculating reflection vector
			half3 worldRefl = WorldReflectionVector (IN, o.Normal);
			fixed4 reflcol = texCUBE (_Cube, worldRefl);
			
			o.Emission = reflcol.rgb * (_ReflectColor.rgb * _ReflectColor.rgb);
			o.Alpha = length(reflcol.rgb) * _ReflectColor.a * _Color.a * maskOpacity;
		}
		ENDCG
	}

	FallBack "Reflective/Bumped Specular"
}
