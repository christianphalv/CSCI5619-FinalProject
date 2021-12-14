Shader "Stencil/Portal" {
    Properties {
        [IntRange] _StencilRef("Stencil Reference Value", Range(0,255)) = 0
    }
    SubShader {
        //Tags { "RenderType" = "Opaque" "Queue" = "AlphaTest+51"}
        Tags { "RenderType" = "Opaque" "Queue" = "Geometry-1"}
        LOD 100

        Stencil {
            Ref[_StencilRef]
            Comp Always
            Pass Replace
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

            Blend Zero One
            ZWrite Off

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
                return 0;
            }

            ENDHLSL
        }
    }
}
