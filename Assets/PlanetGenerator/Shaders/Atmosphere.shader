// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:35201,y:32883,varname:node_9361,prsc:2|custl-5540-OUT,voffset-2130-OUT;n:type:ShaderForge.SFN_NormalVector,id:7821,x:32092,y:32627,prsc:2,pt:False;n:type:ShaderForge.SFN_LightVector,id:451,x:31846,y:32150,varname:node_451,prsc:2;n:type:ShaderForge.SFN_Dot,id:4583,x:32309,y:32460,varname:node_4583,prsc:2,dt:0|A-451-OUT,B-7821-OUT;n:type:ShaderForge.SFN_ViewVector,id:1155,x:32092,y:32804,cmnt:ViewDirBorder,varname:node_1155,prsc:2;n:type:ShaderForge.SFN_Dot,id:3371,x:32309,y:32759,varname:node_3371,prsc:2,dt:1|A-7821-OUT,B-1155-OUT;n:type:ShaderForge.SFN_Blend,id:1208,x:33437,y:32623,varname:node_1208,prsc:2,blmd:6,clmp:True|SRC-1506-OUT,DST-500-OUT;n:type:ShaderForge.SFN_Multiply,id:500,x:33184,y:32803,varname:node_500,prsc:2|A-1597-OUT,B-6991-OUT;n:type:ShaderForge.SFN_Slider,id:6991,x:32792,y:32617,ptovrint:False,ptlb:Rim,ptin:_Rim,varname:_Rim,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Clamp01,id:6096,x:32663,y:33041,varname:node_6096,prsc:2|IN-121-OUT;n:type:ShaderForge.SFN_Multiply,id:9474,x:33671,y:32689,varname:node_9474,prsc:2|A-1208-OUT,B-1597-OUT,C-3513-OUT;n:type:ShaderForge.SFN_Fresnel,id:3513,x:33523,y:32838,varname:node_3513,prsc:2|NRM-7821-OUT,EXP-9295-OUT;n:type:ShaderForge.SFN_Vector1,id:7266,x:33218,y:32994,varname:node_7266,prsc:2,v1:5;n:type:ShaderForge.SFN_Color,id:1346,x:33868,y:32840,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.06812268,c3:0.9264706,c4:1;n:type:ShaderForge.SFN_Multiply,id:5540,x:34171,y:32647,varname:node_5540,prsc:2|A-6608-OUT,B-1346-RGB;n:type:ShaderForge.SFN_Multiply,id:6608,x:33949,y:32545,varname:node_6608,prsc:2|A-6501-OUT,B-9474-OUT;n:type:ShaderForge.SFN_RemapRange,id:6501,x:33671,y:32451,varname:node_6501,prsc:2,frmn:0,frmx:1,tomn:0,tomx:30|IN-9770-OUT;n:type:ShaderForge.SFN_Slider,id:8196,x:34518,y:32577,ptovrint:False,ptlb:Size,ptin:_Size,varname:_Size,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_NormalVector,id:4646,x:34760,y:32655,prsc:2,pt:False;n:type:ShaderForge.SFN_Normalize,id:1732,x:34929,y:32750,varname:node_1732,prsc:2|IN-4646-OUT;n:type:ShaderForge.SFN_Multiply,id:2130,x:35107,y:32587,varname:node_2130,prsc:2|A-9559-OUT,B-1732-OUT;n:type:ShaderForge.SFN_Divide,id:9559,x:34947,y:32487,varname:node_9559,prsc:2|A-8196-OUT,B-4035-OUT;n:type:ShaderForge.SFN_Vector1,id:4035,x:34811,y:32408,varname:node_4035,prsc:2,v1:20;n:type:ShaderForge.SFN_Slider,id:7918,x:33061,y:33173,ptovrint:False,ptlb:Density,ptin:_Density,varname:_Density,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:4;n:type:ShaderForge.SFN_Subtract,id:9295,x:33523,y:33017,varname:node_9295,prsc:2|A-7266-OUT,B-7918-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:121,x:32409,y:33086,varname:node_121,prsc:2|IN-3371-OUT,IMIN-5685-OUT,IMAX-6996-OUT,OMIN-1294-OUT,OMAX-9286-OUT;n:type:ShaderForge.SFN_Vector1,id:5685,x:32034,y:33063,varname:node_5685,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1294,x:32179,y:33236,varname:node_1294,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:9286,x:32490,y:33234,varname:node_9286,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:6996,x:31877,y:33183,ptovrint:False,ptlb:Border,ptin:_Border,varname:_Border,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2312771,max:1;n:type:ShaderForge.SFN_Slider,id:9770,x:33271,y:32330,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:_Brightness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1506,x:32828,y:32318,varname:node_1506,prsc:2|IN-4583-OUT,IMIN-9644-OUT,IMAX-4271-OUT,OMIN-596-OUT,OMAX-5825-OUT;n:type:ShaderForge.SFN_Slider,id:2140,x:32167,y:32227,ptovrint:False,ptlb:Refraction,ptin:_Refraction,varname:_Refraction,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_RemapRange,id:596,x:32532,y:32174,varname:node_596,prsc:2,frmn:0,frmx:1,tomn:-0.5,tomx:0.5|IN-2140-OUT;n:type:ShaderForge.SFN_Vector1,id:4271,x:32489,y:32460,varname:node_4271,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:9644,x:32489,y:32360,varname:node_9644,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:5825,x:32489,y:32518,varname:node_5825,prsc:2,v1:1;n:type:ShaderForge.SFN_Sqrt,id:4902,x:32877,y:32943,varname:node_4902,prsc:2|IN-6096-OUT;n:type:ShaderForge.SFN_Multiply,id:1597,x:32806,y:33186,varname:node_1597,prsc:2|A-6096-OUT,B-6096-OUT,C-6096-OUT;n:type:ShaderForge.SFN_Fresnel,id:7757,x:34325,y:33246,varname:node_7757,prsc:2|EXP-2599-OUT;n:type:ShaderForge.SFN_LightVector,id:4180,x:34009,y:33371,varname:node_4180,prsc:2;n:type:ShaderForge.SFN_Dot,id:2499,x:34199,y:33453,varname:node_2499,prsc:2,dt:1|A-4180-OUT,B-9023-OUT;n:type:ShaderForge.SFN_NormalVector,id:9023,x:34052,y:33618,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:9246,x:34463,y:33424,varname:node_9246,prsc:2|A-7757-OUT,B-2499-OUT;n:type:ShaderForge.SFN_Vector1,id:2599,x:34107,y:32970,varname:node_2599,prsc:2,v1:5;proporder:1346-6991-2140-7918-9770-6996-8196;pass:END;sub:END;*/

Shader "Human Unit/Atmosphere" {
    Properties {
        [HDR]_Color ("Color", Color) = (0,0.06812268,0.9264706,1)
        _Rim ("Rim", Range(0, 1)) = 1
        _Refraction ("Refraction", Range(0, 1)) = 0
        _Density ("Density", Range(0, 4)) = 1
        _Brightness ("Brightness", Range(0, 1)) = 1
        _Border ("Border", Range(0, 1)) = 0.2312771
        _Size ("Size", Range(0, 1)) = 1
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone ps4 
            #pragma target 3.0
            uniform float _Rim;
            uniform float4 _Color;
            uniform float _Size;
            uniform float _Density;
            uniform float _Border;
            uniform float _Brightness;
            uniform float _Refraction;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
				float3 viewPos : TEXCOORD2;
//                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                v.vertex.xyz += ((_Size/20.0)*normalize(v.normal));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
				o.viewPos = UNITY_MATRIX_V[2].xyz; //normalize(mul(UNITY_MATRIX_MV, v.vertex).xyz);

                //UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = lerp(normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz), i.viewPos,unity_OrthoParams.w);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
                float node_9644 = 0.0;
                float node_596 = (_Refraction*1.0+-0.5);
                float node_5685 = 0.0;
                float node_1294 = 0.0;
                float node_6096 = saturate((node_1294 + ( (max(0,dot(i.normalDir,viewDirection)) - node_5685) * (1.0 - node_1294) ) / (_Border - node_5685)));
                float node_1597 = (node_6096*node_6096*node_6096);
                float3 finalColor = (((_Brightness*30.0+0.0)*(saturate((1.0-(1.0-(node_596 + ( (dot(lightDirection,i.normalDir) - node_9644) * (1.0 - node_596) ) / (1.0 - node_9644)))*(1.0-(node_1597*_Rim))))*node_1597*pow(1.0-max(0,dot(i.normalDir, viewDirection)),(5.0-_Density))))*_Color.rgb);
                fixed4 finalRGBA = fixed4(finalColor,1);
                //UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
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
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone ps4 
            #pragma target 3.0
            uniform float _Rim;
            uniform float4 _Color;
            uniform float _Size;
            uniform float _Density;
            uniform float _Border;
            uniform float _Brightness;
            uniform float _Refraction;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                LIGHTING_COORDS(2,3)
                UNITY_FOG_COORDS(4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                v.vertex.xyz += ((_Size/20.0)*normalize(v.normal));
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
				//o.viewPos = normalize(mul(UNITY_MATRIX_MV, v.vertex).xyz);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float node_596 = (_Refraction*1.0+-0.5);
                float node_6096 = saturate(( ( (max(0,dot(i.normalDir,viewDirection))) ) / (_Border )));
                float node_1597 = (node_6096*node_6096*node_6096);
                float3 finalColor = (((_Brightness*30.0+0.0)*(saturate((1.0-(1.0-(node_596 + ( (dot(lightDirection,i.normalDir) ) * (1.0 - node_596) ) ))*(1.0-(node_1597*_Rim))))*node_1597*pow(1.0-max(0,dot(i.normalDir, viewDirection)),(5.0-_Density))))*_Color.rgb);
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                //UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
		/*
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone ps4 
            #pragma target 3.0
            uniform float _Size;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float3 normalDir : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                v.vertex.xyz += ((_Size/20.0)*normalize(v.normal));
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
		*/
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
