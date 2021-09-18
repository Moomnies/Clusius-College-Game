Shader "Roystan/Toon/Water"
{
    Properties
    {

        _DepthGradientShallow("Depth Gradient Shallow", Color) = (0.325, 0.807, 0.971, 0.725)
        _DepthGradientDeep("Depth Gradient Deep", Color) = (0.0086, 0.407, 1, 0.749)
        _DepthMaxDistance("Depth Max Distance", Float) = 1
        _SurfaceNoise("Surface Noise", 2D) = "White" {}
        _SurfaceNoiseCutoff("Surface Noise Cutoff", Range(0, 1)) = 0.777
        _FoamDistance("Foam Distance", Float) = 0.4
        _SurfaceNoiceScroll("Surface Noise Scroll Amount", Vector) = (0.03, 0.03, 0, 0)
        _SurfaceDistortion("Surface Distortion", 2D) = "white" {}
        _SurfaceDistortionAmount("Surface Distortion Amount", Range(0, 1)) = 0.27
        _FoamMaxDistance("Foam Maximum Distance", Float) = 0.4
        _FoamMinDistance("Foam Minimum Distance", Float) = 0.04
        [Toggle] _ContrastMode("Contrast Mode", Float) = 0
    }
    
    SubShader
    {
        Tags{"Queue" = "AlphaTest"}        

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off

			CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            #define SMOOTHSTEP_AA 0.01 

            float4 _DepthGradientShallow;
            float4 _DepthGradientDeep;
            float4 _SurfaceDistortion_ST;

            float2 _SurfaceNoiceScroll;

            float _DepthMaxDistance;
            float _SurfaceNoiseCutoff;
            float _FoamDistance;
            float _SurfaceDistortionAmount;
            float _FoamMaxDistance;
            float _FoamMinDistance;
            float _ContrastMode;

            sampler2D _CameraDepthTexture;
            sampler2D _SurfaceDistortion;


            struct appdata
            {
                float4 vertex : POSITION;
                float4 uv : TEXCOORD0;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 screenPosition : TEXCOORD2;
                float2 noiseUV : TEXCOORD0;
                float2 distortUV : TEXCOORD1;
                float3 viewNormal : NORMAL;
            };

            sampler2D _SurfaceNoise;
            float4 _SurfaceNoise_ST;

            v2f vert (appdata v)
            {
                v2f o;

                o.noiseUV = TRANSFORM_TEX(v.uv, _SurfaceNoise);
                o.vertex = UnityObjectToClipPos(v.vertex); 
                o.screenPosition = ComputeScreenPos(o.vertex);
                o.distortUV = TRANSFORM_TEX(v.uv, _SurfaceDistortion);
                o.viewNormal = COMPUTE_VIEW_NORMAL;
                

                return o;
            }

            sampler2D _CameraNormalTexture;

            float4 frag(v2f i) : SV_Target
            {
                if (_ContrastMode == 1) 
                {

                }

                float existingDepth01 = tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.screenPosition)).r;
                float existingDepthLinear = LinearEyeDepth(existingDepth01);

                float depthDifference = existingDepthLinear - i.screenPosition.w;

                float waterDepthDifference01 = saturate(depthDifference / _DepthMaxDistance);
                float4 waterColor = lerp(_DepthGradientShallow, _DepthGradientDeep, waterDepthDifference01);

                float3 existingNormal = tex2Dproj(_CameraNormalTexture, UNITY_PROJ_COORD(i.screenPosition));
                float3 normalDot = saturate(dot(existingNormal, i.viewNormal));

                float foamDistance = lerp(_FoamMaxDistance, _FoamMinDistance, normalDot);

                float foamDepthDifference01 = saturate(depthDifference / foamDistance);
                float surfaceNoiseCutoff = foamDepthDifference01 * _SurfaceNoiseCutoff;

                float2 distortSample = (tex2D(_SurfaceDistortion, i.distortUV).xy * 2 - 1) * _SurfaceDistortionAmount;
                float2 noiseUV = float2((i.noiseUV.x + _Time.y * _SurfaceNoiceScroll.x) + distortSample.x, (i.noiseUV.y + _Time.y * _SurfaceNoiceScroll.y) + distortSample.y);  

                float surfaceNoiseSample = tex2D(_SurfaceNoise, noiseUV).r;
                float SurfaceNoise = smoothstep(surfaceNoiseCutoff - SMOOTHSTEP_AA, surfaceNoiseCutoff + SMOOTHSTEP_AA, surfaceNoiseSample);

                return waterColor + SurfaceNoise;
            }
            ENDCG
        }
    }
}