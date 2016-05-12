// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-7693-OUT,clip-8497-OUT;n:type:ShaderForge.SFN_TexCoord,id:8909,x:31746,y:33041,varname:node_8909,prsc:2,uv:0;n:type:ShaderForge.SFN_Slider,id:5415,x:31635,y:32951,ptovrint:False,ptlb:Life,ptin:_Life,varname:node_5415,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Color,id:6499,x:31724,y:32576,ptovrint:False,ptlb:ColorLife,ptin:_ColorLife,varname:node_6499,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.07017732,c2:0.4338235,c3:0.132875,c4:1;n:type:ShaderForge.SFN_Color,id:9113,x:31698,y:32759,ptovrint:False,ptlb:ColorDead,ptin:_ColorDead,varname:node_9113,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9632353,c2:0.09207394,c3:0.09207394,c4:1;n:type:ShaderForge.SFN_Lerp,id:3640,x:32044,y:32737,varname:node_3640,prsc:2|A-9113-RGB,B-6499-RGB,T-5415-OUT;n:type:ShaderForge.SFN_Subtract,id:5965,x:32230,y:33017,varname:node_5965,prsc:2|A-5415-OUT,B-8909-U;n:type:ShaderForge.SFN_Clamp01,id:8497,x:32489,y:33049,varname:node_8497,prsc:2|IN-8770-OUT;n:type:ShaderForge.SFN_Ceil,id:8770,x:32433,y:33211,varname:node_8770,prsc:2|IN-5965-OUT;n:type:ShaderForge.SFN_Tex2d,id:1220,x:32089,y:32459,ptovrint:False,ptlb:Texture,ptin:_Texture,varname:node_1220,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5fb7986dd6d0a8e4093ba82369dd6a4d,ntxv:0,isnm:False|UVIN-4826-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7693,x:32373,y:32601,varname:node_7693,prsc:2|A-1220-RGB,B-3640-OUT;n:type:ShaderForge.SFN_Panner,id:4826,x:32319,y:32811,varname:node_4826,prsc:2,spu:1,spv:0|UVIN-8909-UVOUT,DIST-865-OUT;n:type:ShaderForge.SFN_Slider,id:439,x:31589,y:33260,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:node_439,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:10,max:10;n:type:ShaderForge.SFN_Time,id:9064,x:31837,y:33366,varname:node_9064,prsc:2;n:type:ShaderForge.SFN_Multiply,id:865,x:32209,y:33194,varname:node_865,prsc:2|A-439-OUT,B-9064-TSL;proporder:5415-6499-9113-1220-439;pass:END;sub:END;*/

Shader "Shader Forge/S_PlayersLife" {
    Properties {
        _Life ("Life", Range(0, 1)) = 1
        _ColorLife ("ColorLife", Color) = (0.07017732,0.4338235,0.132875,1)
        _ColorDead ("ColorDead", Color) = (0.9632353,0.09207394,0.09207394,1)
        _Texture ("Texture", 2D) = "white" {}
        _Speed ("Speed", Range(1, 10)) = 10
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Life;
            uniform float4 _ColorLife;
            uniform float4 _ColorDead;
            uniform sampler2D _Texture; uniform float4 _Texture_ST;
            uniform float _Speed;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                clip(saturate(ceil((_Life-i.uv0.r))) - 0.5);
////// Lighting:
////// Emissive:
                float4 node_9064 = _Time + _TimeEditor;
                float2 node_4826 = (i.uv0+(_Speed*node_9064.r)*float2(1,0));
                float4 _Texture_var = tex2D(_Texture,TRANSFORM_TEX(node_4826, _Texture));
                float3 emissive = (_Texture_var.rgb*lerp(_ColorDead.rgb,_ColorLife.rgb,_Life));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float _Life;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                clip(saturate(ceil((_Life-i.uv0.r))) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
