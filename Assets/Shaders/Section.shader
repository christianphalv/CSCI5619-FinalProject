Shader "Stencil/Section" {
    Properties {
        _Color("Tint", Color) = (0, 0, 0, 1)
        _MainTex("Texture", 2D) = "white" {}

        [IntRange] _StencilRef("Stencil Reference Value", Range(0,255)) = 0
        [Enum(CompareFunction)] _StencilComp("Stenci Comp", Int) = 3
    }
    SubShader {
        //Tags { "RenderType"="Opaque" "Queue" = "AlphaTest+52"}
        Tags { "RenderType" = "Opaque"}
        LOD 100

        Stencil {
            Ref [_StencilRef]
            Comp [_StencilComp]
        }

        HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

        CBUFFER_START(UnityPerMaterial)
            float4 _Color;
        CBUFFER_END

        TEXTURE2D(_MainTex);
        SAMPLER(sampler_MainTex);

        struct VertexInput {
            float4 position : POSITION;
            float2 uv : TEXCOORD0;
        };

        struct VertexOutput {
            float4 position : SV_POSITION;
            float2 uv : TEXCOORD0;
        };

        ENDHLSL

        Pass {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            VertexOutput vert(VertexInput i) {
                VertexOutput o;
                o.position = TransformObjectToHClip(i.position.xyz);
                o.uv = i.uv;
                return o;
            }

            float4 frag(VertexOutput i) : SV_Target {
                float4 baseTex = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
                return baseTex * _Color;
            }

            ENDHLSL
        }
    }
}
