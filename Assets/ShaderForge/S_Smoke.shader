// Shader created with Shader Forge v1.25 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.25;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:6989,x:32719,y:32712,varname:node_6989,prsc:2|diff-8283-OUT,lwrap-8283-OUT,amdfl-8283-OUT,alpha-9581-OUT;n:type:ShaderForge.SFN_VertexColor,id:6679,x:32051,y:33213,varname:node_6679,prsc:2;n:type:ShaderForge.SFN_Color,id:3036,x:32051,y:33372,ptovrint:False,ptlb:node_3036,ptin:_node_3036,varname:node_3036,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:9581,x:32334,y:33285,varname:node_9581,prsc:2|A-6679-A,B-3036-A;n:type:ShaderForge.SFN_NormalVector,id:9696,x:31268,y:32715,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:585,x:31268,y:32866,varname:node_585,prsc:2;n:type:ShaderForge.SFN_LightColor,id:9948,x:31960,y:32347,varname:node_9948,prsc:2;n:type:ShaderForge.SFN_LightAttenuation,id:1306,x:31960,y:32515,varname:node_1306,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6684,x:32202,y:32569,varname:node_6684,prsc:2|A-9948-RGB,B-1306-OUT,C-3423-OUT;n:type:ShaderForge.SFN_Slider,id:6167,x:31155,y:33219,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_6167,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:1,cur:3.03079,max:11;n:type:ShaderForge.SFN_Exp,id:3,x:31521,y:33218,varname:node_3,prsc:2,et:1|IN-6167-OUT;n:type:ShaderForge.SFN_Power,id:6967,x:31692,y:32947,varname:node_6967,prsc:2|VAL-8958-OUT,EXP-3-OUT;n:type:ShaderForge.SFN_Dot,id:8958,x:31476,y:32947,varname:node_8958,prsc:2,dt:1|A-585-OUT,B-1736-OUT;n:type:ShaderForge.SFN_Dot,id:7250,x:31476,y:32756,varname:node_7250,prsc:2,dt:1|A-9696-OUT,B-585-OUT;n:type:ShaderForge.SFN_ViewReflectionVector,id:1736,x:31268,y:33012,varname:node_1736,prsc:2;n:type:ShaderForge.SFN_Color,id:1780,x:31358,y:32518,ptovrint:False,ptlb:DiffuseCOlor,ptin:_DiffuseCOlor,varname:node_1780,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5073529,c2:0.5073529,c3:0.5073529,c4:1;n:type:ShaderForge.SFN_Multiply,id:2227,x:31709,y:32711,varname:node_2227,prsc:2|A-1780-RGB,B-7250-OUT;n:type:ShaderForge.SFN_Add,id:3715,x:31874,y:32740,varname:node_3715,prsc:2|A-2227-OUT,B-6967-OUT;n:type:ShaderForge.SFN_Posterize,id:3423,x:32310,y:32777,varname:node_3423,prsc:2|IN-3715-OUT,STPS-7706-OUT;n:type:ShaderForge.SFN_Vector1,id:7706,x:32147,y:32902,varname:node_7706,prsc:2,v1:2;n:type:ShaderForge.SFN_ConstantClamp,id:8283,x:32492,y:32648,varname:node_8283,prsc:2,min:0.2,max:0.3|IN-6684-OUT;proporder:3036-1780-6167;pass:END;sub:END;*/

Shader "Unlit/S_Smoke" {
    Properties {
        _node_3036 ("node_3036", Color) = (0.5,0.5,0.5,1)
        _DiffuseCOlor ("DiffuseCOlor", Color) = (0.5073529,0.5073529,0.5073529,1)
        _Gloss ("Gloss", Range(1, 11)) = 3.03079
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 100
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _node_3036;
            uniform float _Gloss;
            uniform float4 _DiffuseCOlor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float node_7706 = 2.0;
                float3 node_8283 = clamp((_LightColor0.rgb*attenuation*floor(((_DiffuseCOlor.rgb*max(0,dot(i.normalDir,lightDirection)))+pow(max(0,dot(lightDirection,viewReflectDirection)),exp2(_Gloss))) * node_7706) / (node_7706 - 1)),0.2,0.3);
                float3 w = node_8283*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = forwardLight * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                indirectDiffuse += node_8283; // Diffuse Ambient Light
                float3 diffuseColor = node_8283;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,(i.vertexColor.a*_node_3036.a));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _node_3036;
            uniform float _Gloss;
            uniform float4 _DiffuseCOlor;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float node_7706 = 2.0;
                float3 node_8283 = clamp((_LightColor0.rgb*attenuation*floor(((_DiffuseCOlor.rgb*max(0,dot(i.normalDir,lightDirection)))+pow(max(0,dot(lightDirection,viewReflectDirection)),exp2(_Gloss))) * node_7706) / (node_7706 - 1)),0.2,0.3);
                float3 w = node_8283*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = forwardLight * attenColor;
                float3 diffuseColor = node_8283;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * (i.vertexColor.a*_node_3036.a),0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
