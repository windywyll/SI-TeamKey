// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:0,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:13,ufog:True,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:True,fgod:False,fgor:False,fgmd:0,fgcr:0.3537391,fgcg:0.3897059,fgcb:0.189122,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32720,y:32712,varname:node_3138,prsc:2|emission-5708-RGB,custl-262-OUT,clip-5417-A;n:type:ShaderForge.SFN_Tex2d,id:5708,x:31746,y:32696,ptovrint:False,ptlb:node_5708,ptin:_node_5708,varname:node_5708,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c6b6a75a4ee40f6478055407c8d6070d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5417,x:32294,y:32975,ptovrint:False,ptlb:node_5417,ptin:_node_5417,varname:node_5417,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:29e95e97b1a690144abc3c22021eb108,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5587,x:32049,y:32538,ptovrint:False,ptlb:node_5587,ptin:_node_5587,varname:node_5587,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:939db1a270aece8469d79d5ceff3aa77,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:7472,x:31272,y:33209,varname:node_7472,prsc:2;n:type:ShaderForge.SFN_Time,id:9606,x:31678,y:33464,varname:node_9606,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2045,x:31643,y:33308,varname:node_2045,prsc:2|A-7189-OUT,B-5816-OUT;n:type:ShaderForge.SFN_Add,id:7693,x:31849,y:33308,varname:node_7693,prsc:2|A-2045-OUT,B-9606-T;n:type:ShaderForge.SFN_Sin,id:7844,x:32092,y:33329,varname:node_7844,prsc:2|IN-7693-OUT;n:type:ShaderForge.SFN_Vector1,id:2840,x:32038,y:33566,varname:node_2840,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:26,x:32340,y:33283,varname:node_26,prsc:2|A-2840-OUT,B-7844-OUT,C-7189-OUT;n:type:ShaderForge.SFN_Pi,id:5816,x:31386,y:33350,varname:node_5816,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:72,x:31140,y:33059,prsc:2,pt:True;n:type:ShaderForge.SFN_Vector3,id:7742,x:31394,y:32947,varname:node_7742,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Add,id:2672,x:31613,y:33051,varname:node_2672,prsc:2|A-7742-OUT,B-72-OUT;n:type:ShaderForge.SFN_Normalize,id:1035,x:31865,y:33059,varname:node_1035,prsc:2|IN-2672-OUT;n:type:ShaderForge.SFN_Noise,id:8521,x:32365,y:33524,varname:node_8521,prsc:2;n:type:ShaderForge.SFN_Multiply,id:7189,x:31473,y:33197,varname:node_7189,prsc:2|A-7472-R,B-6792-OUT;n:type:ShaderForge.SFN_Vector1,id:6792,x:31180,y:33403,varname:node_6792,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Vector1,id:6906,x:32085,y:32945,varname:node_6906,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:9131,x:32515,y:33204,varname:node_9131,prsc:2|A-1035-OUT,B-26-OUT,C-8521-OUT;n:type:ShaderForge.SFN_Multiply,id:262,x:32530,y:32876,varname:node_262,prsc:2|A-5708-RGB,B-6906-OUT;proporder:5587-5708-5417;pass:END;sub:END;*/

Shader "Shader Forge/SF_Grass" {
    Properties {
        _node_5587 ("node_5587", 2D) = "white" {}
        _node_5708 ("node_5708", 2D) = "white" {}
        _node_5417 ("node_5417", 2D) = "white" {}
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
            
            ColorMask RGA
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _node_5708; uniform float4 _node_5708_ST;
            uniform sampler2D _node_5417; uniform float4 _node_5417_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 _node_5417_var = tex2D(_node_5417,TRANSFORM_TEX(i.uv0, _node_5417));
                clip(_node_5417_var.a - 0.5);
////// Lighting:
////// Emissive:
                float4 _node_5708_var = tex2D(_node_5708,TRANSFORM_TEX(i.uv0, _node_5708));
                float3 emissive = _node_5708_var.rgb;
                float3 finalColor = emissive + (_node_5708_var.rgb*0.5);
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG_COLOR(i.fogCoord, finalRGBA, fixed4(0.3537391,0.3897059,0.189122,1));
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            ColorMask RGA
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform sampler2D _node_5417; uniform float4 _node_5417_ST;
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
                float4 _node_5417_var = tex2D(_node_5417,TRANSFORM_TEX(i.uv0, _node_5417));
                clip(_node_5417_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
