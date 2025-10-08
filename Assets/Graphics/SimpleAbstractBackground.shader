Shader "Custom/SimpleAbstractBackground3Color"
{
    Properties
    {
        _Color1("Color 1", Color) = (0.2, 0.3, 0.5, 1)
        _Color2("Color 2", Color) = (0.6, 0.4, 0.8, 1)
        _Color3("Color 3", Color) = (0.8, 0.6, 0.3, 1)
        _Speed1("Speed 1", Float) = 0.2
        _Speed2("Speed 2", Float) = 0.1
        _Speed3("Speed 3", Float) = 0.15
        _Scale1("Scale 1", Float) = 3
        _Scale2("Scale 2", Float) = 5
        _Scale3("Scale 3", Float) = 7
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Background" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float4 _Color1;
            float4 _Color2;
            float4 _Color3;
            float _Speed1;
            float _Speed2;
            float _Speed3;
            float _Scale1;
            float _Scale2;
            float _Scale3;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv;

                // Layered waves with different scales and speeds for randomness
                float wave1 = sin(uv.x * _Scale1 + _Time.y * _Speed1) * cos(uv.y * _Scale1 - _Time.y * _Speed1);
                float wave2 = sin(uv.y * _Scale2 + _Time.y * _Speed2) * cos(uv.x * _Scale2 + _Time.y * _Speed2);
                float wave3 = sin((uv.x + uv.y) * _Scale3 + _Time.y * _Speed3);

                // Combine waves and normalize to 0-1
                float pattern = (wave1 + wave2 + wave3) / 3.0;
                pattern = pattern * 0.5 + 0.5;

                // Use three colors: blend based on pattern
                fixed4 col;
                if(pattern < 0.33)
                    col = lerp(_Color1, _Color2, pattern / 0.33);
                else if(pattern < 0.66)
                    col = lerp(_Color2, _Color3, (pattern - 0.33) / 0.33);
                else
                    col = lerp(_Color3, _Color1, (pattern - 0.66) / 0.34);

                return col;
            }
            ENDCG
        }
    }
}
