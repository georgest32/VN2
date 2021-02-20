Shader "BaseUnlitShader"{
	//show values to edit in inspector
  Properties{
    _Color ("Tint", Color) = (0, 0, 0, 1)
    _MainTex ("Texture", 2D) = "white" {}
  }

  SubShader{
    //the material is completely non-transparent and is rendered at the same time as the other opaque geometry
    Tags{ "RenderType"="Opaque" "Queue"="Geometry" }

    Pass{
      CGPROGRAM

      //texture and transforms of the texture
      sampler2D _MainTex;
      float4 _MainTex_ST;

      //tint of the texture
      fixed4 _Color;

      //the mesh data thats read by the vertex shader
      struct appdata{
        float4 vertex : POSITION;
        float2 uv : TEXCOORD0;
      };

      //the data thats passed from the vertex to the fragment shader and interpolated by the rasterizer
      struct v2f{
        float4 position : SV_POSITION;
        float2 uv : TEXCOORD0;
      };

      ENDCG
    }
  }
  Fallback "VertexLit"
}