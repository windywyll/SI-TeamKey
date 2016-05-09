// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32978,y:32434,varname:node_3138,prsc:2|emission-2019-OUT,clip-4987-A;n:type:ShaderForge.SFN_Tex2d,id:4987,x:32348,y:32420,ptovrint:False,ptlb:Arrow,ptin:_Arrow,varname:node_4987,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7d53ea06ed36c37458d769f7a3a87dcf,ntxv:0,isnm:False|UVIN-1963-UVOUT;n:type:ShaderForge.SFN_Color,id:9533,x:32462,y:32685,ptovrint:False,ptlb:ArrowColor,ptin:_ArrowColor,varname:node_9533,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:2019,x:32682,y:32477,varname:node_2019,prsc:2|A-4987-RGB,B-9533-RGB;n:type:ShaderForge.SFN_TexCoord,id:4942,x:31603,y:32627,varname:node_4942,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:1963,x:31923,y:32595,varname:node_1963,prsc:2,spu:0,spv:-1|UVIN-4942-UVOUT,DIST-3783-OUT;n:type:ShaderForge.SFN_Slider,id:4803,x:31670,y:32963,ptovrint:False,ptlb:SliderSpeed,ptin:_SliderSpeed,varname:node_4803,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:18.23183,max:100;n:type:ShaderForge.SFN_Time,id:386,x:31748,y:32766,varname:node_386,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3783,x:32059,y:32778,varname:node_3783,prsc:2|A-386-TSL,B-4803-OUT;proporder:4987-9533-4803;pass:END;sub:END;*/

Shader "Shader Forge/PanelPlayerChoice" {
    Properties {
        _Arrow ("Arrow", 2D) = "white" {}
        _ArrowColor ("ArrowColor", Color) = (1,1,1,1)
        _SliderSpeed ("SliderSpeed", Range(0, 100)) = 18.23183
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
            uniform sampler2D _Arrow; uniform float4 _Arrow_ST;
            uniform float4 _ArrowColor;
            uniform float _SliderSpeed;
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
                float4 node_386 = _Time + _TimeEditor;
                float2 node_1963 = (i.uv0+(node_386.r*_SliderSpeed)*float2(0,-1));
                float4 _Arrow_var = tex2D(_Arrow,TRANSFORM_TEX(node_1963, _Arrow));
                clip(_Arrow_var.a - 0.5);
////// Lighting:
////// Emissive:
                float3 node_2019 = (_Arrow_var.rgb*_ArrowColor.rgb);
                float3 emissive = node_2019;
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
            uniform float4 _TimeEditor;
            uniform sampler2D _Arrow; uniform float4 _Arrow_ST;
            uniform float _SliderSpeed;
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
                float4 node_386 = _Time + _TimeEditor;
                float2 node_1963 = (i.uv0+(node_386.r*_SliderSpeed)*float2(0,-1));
                float4 _Arrow_var = tex2D(_Arrow,TRANSFORM_TEX(node_1963, _Arrow));
                clip(_Arrow_var.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
