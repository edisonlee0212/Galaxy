// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:0,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:34619,y:31999,varname:node_9361,prsc:2|diff-3092-OUT,spec-1286-OUT,gloss-1286-OUT,emission-7833-OUT,difocc-4764-OUT,custl-5085-OUT,alpha-2154-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:8068,x:32734,y:33086,varname:node_8068,prsc:2;n:type:ShaderForge.SFN_LightColor,id:3406,x:32734,y:32952,varname:node_3406,prsc:2;n:type:ShaderForge.SFN_LightVector,id:6869,x:31858,y:32654,varname:node_6869,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9684,x:31858,y:32782,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:7782,x:32070,y:32697,cmnt:Lambert,varname:node_7782,prsc:2,dt:0|A-6869-OUT,B-9684-OUT;n:type:ShaderForge.SFN_Tex2d,id:851,x:31196,y:32558,varname:_finalMap,prsc:2,tex:40e068a0cd45b144394d433b5e58f39c,ntxv:0,isnm:False|UVIN-8564-UVOUT,TEX-3260-TEX;n:type:ShaderForge.SFN_Multiply,id:1941,x:32478,y:32437,cmnt:Diffuse Contribution,varname:node_1941,prsc:2|A-3092-OUT,B-7782-OUT;n:type:ShaderForge.SFN_Multiply,id:5085,x:32979,y:32952,cmnt:Attenuate and Color,varname:node_5085,prsc:2|A-1941-OUT,B-3406-RGB,C-8068-OUT;n:type:ShaderForge.SFN_NormalVector,id:5756,x:32734,y:33265,prsc:2,pt:False;n:type:ShaderForge.SFN_ViewVector,id:3629,x:32734,y:33420,varname:node_3629,prsc:2;n:type:ShaderForge.SFN_Dot,id:3246,x:32944,y:33314,varname:node_3246,prsc:2,dt:1|A-5756-OUT,B-2048-OUT;n:type:ShaderForge.SFN_TexCoord,id:8842,x:29763,y:31924,varname:node_8842,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Append,id:2466,x:30376,y:31903,varname:node_2466,prsc:2|A-5845-OUT,B-8842-V;n:type:ShaderForge.SFN_Vector1,id:5845,x:30171,y:31863,varname:node_5845,prsc:2,v1:0;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:7711,x:33492,y:33310,varname:node_7711,prsc:2|IN-3246-OUT,IMIN-9643-OUT,IMAX-8628-OUT,OMIN-9643-OUT,OMAX-6457-OUT;n:type:ShaderForge.SFN_Vector1,id:9643,x:33153,y:33358,varname:zero,prsc:0,v1:0;n:type:ShaderForge.SFN_Vector1,id:6457,x:33138,y:33490,varname:node_6457,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:8160,x:33051,y:33164,ptovrint:False,ptlb:Density,ptin:_Density,varname:_Density,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5810818,max:1;n:type:ShaderForge.SFN_Clamp01,id:2954,x:33660,y:33289,varname:opacity,prsc:2|IN-7711-OUT;n:type:ShaderForge.SFN_Multiply,id:2154,x:34103,y:33180,varname:node_2154,prsc:2|A-2954-OUT,B-2954-OUT;n:type:ShaderForge.SFN_Panner,id:754,x:31163,y:31729,varname:_pannedUV,prsc:2,spu:0.1,spv:0|UVIN-2987-UVOUT,DIST-8924-OUT;n:type:ShaderForge.SFN_Multiply,id:8924,x:30494,y:31705,varname:node_8924,prsc:2|A-3428-OUT,B-3921-TSL;n:type:ShaderForge.SFN_Slider,id:3428,x:30093,y:31602,ptovrint:False,ptlb:Flow,ptin:_Flow,varname:_Flow,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5459756,max:1;n:type:ShaderForge.SFN_Multiply,id:1960,x:30233,y:32193,varname:node_1960,prsc:2|A-7500-G,B-8414-OUT;n:type:ShaderForge.SFN_Vector1,id:8414,x:29680,y:32215,varname:node_8414,prsc:2,v1:2;n:type:ShaderForge.SFN_Tex2d,id:4629,x:30779,y:32227,varname:_noise,prsc:2,tex:40e068a0cd45b144394d433b5e58f39c,ntxv:0,isnm:False|UVIN-9869-OUT,TEX-3260-TEX;n:type:ShaderForge.SFN_Panner,id:8564,x:31155,y:32028,varname:_finalUV,prsc:2,spu:0.05,spv:0|UVIN-754-UVOUT,DIST-4942-OUT;n:type:ShaderForge.SFN_NormalVector,id:1851,x:29083,y:32396,prsc:2,pt:False;n:type:ShaderForge.SFN_ComponentMask,id:1731,x:29412,y:32396,varname:node_1731,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-2918-OUT;n:type:ShaderForge.SFN_Code,id:8136,x:29744,y:32396,varname:node_8136,prsc:2,code:ZgBsAG8AYQB0ACAAYQAsAGIALABvADsACgBhAD0AbABlAHIAcAAoADAALAAxACwAQQAvADIAKQA7AAoAYgA9AGwAZQByAHAAKAAxACwAMAAsACgAQQArADEAKQAvADIAKQA7AAoAbwA9AGwAZQByAHAAKABhACwAYgAsAEEAKQA7AAoAcgBlAHQAdQByAG4AIABvADsA,output:0,fname:Function_node_8136,width:247,height:132,input:0,input_1_label:A|A-6461-OUT;n:type:ShaderForge.SFN_Time,id:3921,x:29831,y:32621,varname:time,prsc:2;n:type:ShaderForge.SFN_Set,id:6161,x:30637,y:31613,varname:flow,prsc:2|IN-3428-OUT;n:type:ShaderForge.SFN_Get,id:7131,x:29925,y:32801,varname:node_7131,prsc:2|IN-6161-OUT;n:type:ShaderForge.SFN_Multiply,id:6890,x:30163,y:32666,varname:node_6890,prsc:2|A-3921-TSL,B-7131-OUT;n:type:ShaderForge.SFN_Normalize,id:2918,x:29246,y:32396,varname:node_2918,prsc:2|IN-1851-OUT;n:type:ShaderForge.SFN_RemapRange,id:6461,x:29571,y:32396,varname:node_6461,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-1731-OUT;n:type:ShaderForge.SFN_Add,id:489,x:30424,y:32368,varname:node_489,prsc:2|A-4437-OUT,B-2045-OUT;n:type:ShaderForge.SFN_ComponentMask,id:7500,x:29986,y:32059,varname:_uv,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-8842-UVOUT;n:type:ShaderForge.SFN_Append,id:9869,x:30580,y:32239,varname:_noiseUV,prsc:2|A-489-OUT,B-1960-OUT;n:type:ShaderForge.SFN_Multiply,id:2045,x:30178,y:32426,varname:node_2045,prsc:2|A-8136-OUT,B-6469-OUT;n:type:ShaderForge.SFN_Vector1,id:6469,x:30013,y:32520,varname:node_6469,prsc:2,v1:3;n:type:ShaderForge.SFN_Multiply,id:4437,x:30467,y:32130,varname:node_4437,prsc:2|A-7500-R,B-4536-OUT;n:type:ShaderForge.SFN_Vector1,id:4536,x:30047,y:32339,varname:node_4536,prsc:2,v1:1;n:type:ShaderForge.SFN_Code,id:3092,x:31687,y:31948,varname:_color,prsc:2,code:ZgBsAG8AYQB0ADMAIABhACwAYgAsAG8AOwAKAGEAPQBsAGUAcgBwACgAQgAsAEMALABBAC8AMgApADsACgBiAD0AbABlAHIAcAAoAEMALABEACwAKABBACsAMQApAC8AMgApADsACgBvAD0AbABlAHIAcAAoAGEALABiACwAQQApADsACgByAGUAdAB1AHIAbgAgAG8AOwA=,output:2,fname:TriLerp,width:247,height:132,input:0,input:2,input:2,input:2,input_1_label:A,input_2_label:B,input_3_label:C,input_4_label:D|A-851-R,B-2168-RGB,C-951-RGB,D-6160-RGB;n:type:ShaderForge.SFN_Color,id:2168,x:31423,y:31664,ptovrint:False,ptlb:Color1,ptin:_Color1,varname:_Color1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1764706,c2:0.1058824,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:951,x:31423,y:31874,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:_Color2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.75,c2:0.566075,c3:0.2371324,c4:1;n:type:ShaderForge.SFN_Color,id:6160,x:31423,y:32084,ptovrint:False,ptlb:Color3,ptin:_Color3,varname:_Color3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9779412,c2:0.9388505,c3:0.8547206,c4:1;n:type:ShaderForge.SFN_ComponentMask,id:3420,x:29246,y:32150,varname:_gNorm,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-2918-OUT;n:type:ShaderForge.SFN_Multiply,id:147,x:29421,y:32123,varname:_poles,prsc:2|A-3420-OUT,B-3420-OUT,C-3420-OUT,D-3420-OUT;n:type:ShaderForge.SFN_Multiply,id:1366,x:29580,y:32058,varname:node_1366,prsc:2|A-147-OUT,B-147-OUT,C-147-OUT,D-147-OUT;n:type:ShaderForge.SFN_OneMinus,id:2999,x:29778,y:32088,varname:node_2999,prsc:2|IN-1366-OUT;n:type:ShaderForge.SFN_Multiply,id:4942,x:31003,y:32072,varname:node_4942,prsc:2|A-2999-OUT,B-4629-R;n:type:ShaderForge.SFN_Rotator,id:2987,x:30978,y:31546,varname:_cyclonesUV,prsc:2|UVIN-2466-OUT,ANG-362-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:3260,x:30414,y:32691,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:_Noise,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:40e068a0cd45b144394d433b5e58f39c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6314,x:30889,y:32440,varname:_cyclone,prsc:2,tex:40e068a0cd45b144394d433b5e58f39c,ntxv:0,isnm:False|TEX-8764-TEX;n:type:ShaderForge.SFN_Multiply,id:362,x:30892,y:31917,varname:node_362,prsc:2|A-2901-OUT,B-6314-R,C-7599-OUT;n:type:ShaderForge.SFN_Slider,id:2901,x:30455,y:31479,ptovrint:False,ptlb:Cyclones,ptin:_Cyclones,varname:_Cyclones,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Vector1,id:7599,x:30717,y:32027,varname:node_7599,prsc:2,v1:0.6;n:type:ShaderForge.SFN_OneMinus,id:8628,x:33402,y:33096,varname:node_8628,prsc:2|IN-8160-OUT;n:type:ShaderForge.SFN_Panner,id:3579,x:31512,y:32366,varname:node_3579,prsc:2,spu:0,spv:0;n:type:ShaderForge.SFN_Panner,id:9510,x:31076,y:31309,varname:node_9510,prsc:2,spu:0,spv:1|UVIN-2466-OUT,DIST-362-OUT;n:type:ShaderForge.SFN_SceneColor,id:159,x:34116,y:33032,varname:node_159,prsc:2|UVIN-9262-UVOUT;n:type:ShaderForge.SFN_Lerp,id:7833,x:34389,y:32960,varname:node_7833,prsc:2|A-159-RGB,B-4168-OUT,T-2154-OUT;n:type:ShaderForge.SFN_Clamp01,id:4764,x:33194,y:32456,varname:node_4764,prsc:2|IN-8338-OUT;n:type:ShaderForge.SFN_Vector1,id:3386,x:32790,y:32701,varname:node_3386,prsc:2,v1:2;n:type:ShaderForge.SFN_Add,id:8338,x:32910,y:32443,varname:node_8338,prsc:2|A-7782-OUT,B-5335-OUT;n:type:ShaderForge.SFN_Slider,id:4913,x:32918,y:32330,ptovrint:False,ptlb:Ambient,ptin:_Ambient,varname:_Ambient,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:5335,x:33480,y:32242,varname:node_5335,prsc:2|A-4913-OUT,B-3386-OUT;n:type:ShaderForge.SFN_Vector1,id:4168,x:33921,y:32905,varname:node_4168,prsc:2,v1:0;n:type:ShaderForge.SFN_ScreenPos,id:9262,x:33843,y:33027,varname:node_9262,prsc:2,sctp:2;n:type:ShaderForge.SFN_Vector1,id:1286,x:33925,y:32024,varname:node_1286,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2dAsset,id:8764,x:30629,y:32833,ptovrint:False,ptlb:Cyclone,ptin:_Cyclone,varname:_Cyclone,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:40e068a0cd45b144394d433b5e58f39c,ntxv:0,isnm:False;n:type:ShaderForge.SFN_ObjectPosition,id:9161,x:32645,y:33592,varname:node_9161,prsc:2;n:type:ShaderForge.SFN_Subtract,id:2760,x:32873,y:33642,varname:node_2760,prsc:2|A-9245-XYZ,B-9161-XYZ;n:type:ShaderForge.SFN_ViewPosition,id:9245,x:32645,y:33771,varname:node_9245,prsc:2;n:type:ShaderForge.SFN_Normalize,id:8907,x:33036,y:33642,varname:node_8907,prsc:2|IN-2760-OUT;n:type:ShaderForge.SFN_Lerp,id:2048,x:33357,y:33574,varname:node_2048,prsc:2|A-3629-OUT,B-5469-OUT,T-4846-OUT;n:type:ShaderForge.SFN_Code,id:4846,x:33036,y:33836,varname:node_4846,prsc:2,code:cgBlAHQAdQByAG4AIABVAE4ASQBUAFkAXwBNAEEAVABSAEkAWABfAFAAWwAzAF0AWwAzAF0AOwA=,output:0,fname:Function_node_4846,width:247,height:132;n:type:ShaderForge.SFN_Code,id:5469,x:32249,y:33377,varname:node_5469,prsc:2,code:cgBlAHQAdQByAG4AIAAgAC0AbQB1AGwAKAAoAGYAbABvAGEAdAAzAHgAMwApAHUAbgBpAHQAeQBfAEMAYQBtAGUAcgBhAFQAbwBXAG8AcgBsAGQALAAgAGYAbABvAGEAdAAzACgAMAAsADAALAAxACkAKQA7ADsA,output:2,fname:Function_node_5469,width:374,height:168;proporder:8160-3428-2168-951-6160-3260-2901-4913-8764;pass:END;sub:END;*/

Shader "Human Unit/Gas giant" {
    Properties {
        _Density ("Density", Range(0, 1)) = 0.5810818
        _Flow ("Flow", Range(0, 1)) = 0.5459756
        _Color1 ("Color1", Color) = (0.1764706,0.1058824,0,1)
        _Color2 ("Color2", Color) = (0.75,0.566075,0.2371324,1)
        _Color3 ("Color3", Color) = (0.9779412,0.9388505,0.8547206,1)
        _Noise ("Noise", 2D) = "white" {}
        _Cyclones ("Cyclones", Range(0, 1)) = 1
        _Ambient ("Ambient", Range(0, 1)) = 0
        _Cyclone ("Cyclone", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        GrabPass{ "Refraction" }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles metal 
            #pragma target 3.0
            uniform sampler2D Refraction;
            uniform float _Density;
            uniform float _Flow;
            float Function_node_8136( float A ){
            float a,b,o;
            a=lerp(0,1,A/2);
            b=lerp(1,0,(A+1)/2);
            o=lerp(a,b,A);
            return o;
            }
            
            float3 TriLerp( float A , float3 B , float3 C , float3 D ){
            float3 a,b,o;
            a=lerp(B,C,A/2);
            b=lerp(C,D,(A+1)/2);
            o=lerp(a,b,A);
            return o;
            }
            
            uniform float4 _Color1;
            uniform float4 _Color2;
            uniform float4 _Color3;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _Cyclones;
            uniform float _Ambient;
            uniform sampler2D _Cyclone; uniform float4 _Cyclone_ST;
            float Function_node_4846(){
            return UNITY_MATRIX_P[3][3];
            }
            
            float3 Function_node_5469(){
            return  -mul((float3x3)unity_CameraToWorld, float3(0,0,1));;
            }
            
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 sceneColor = tex2D(Refraction, sceneUVs);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float node_1286 = 0.0;
                float gloss = node_1286;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(node_1286,node_1286,node_1286);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_7782 = dot(lightDirection,normalDirection); // Lambert
                indirectDiffuse *= saturate((node_7782+(_Ambient*2.0))); // Diffuse AO
                float3 node_2918 = normalize(i.normalDir);
                float _gNorm = node_2918.g;
                float _poles = (_gNorm*_gNorm*_gNorm*_gNorm);
                float2 _uv = i.uv0.rg;
                float2 _noiseUV = float2(((_uv.r*1.0)+(Function_node_8136( (node_2918.g*0.5+0.5) )*3.0)),(_uv.g*2.0));
                float4 _noise = tex2D(_Noise,TRANSFORM_TEX(_noiseUV, _Noise));
                float4 time = _Time;
                float4 _cyclone = tex2D(_Cyclone,TRANSFORM_TEX(i.uv0, _Cyclone));
                float node_362 = (_Cyclones*_cyclone.r*0.6);
                float _cyclonesUV_ang = node_362;
                float _cyclonesUV_spd = 1.0;
                float _cyclonesUV_cos = cos(_cyclonesUV_spd*_cyclonesUV_ang);
                float _cyclonesUV_sin = sin(_cyclonesUV_spd*_cyclonesUV_ang);
                float2 _cyclonesUV_piv = float2(0.5,0.5);
                float2 node_2466 = float2(0.0,i.uv0.g);
                float2 _cyclonesUV = (mul(node_2466-_cyclonesUV_piv,float2x2( _cyclonesUV_cos, -_cyclonesUV_sin, _cyclonesUV_sin, _cyclonesUV_cos))+_cyclonesUV_piv);
                float2 _finalUV = ((_cyclonesUV+(_Flow*time.r)*float2(0.1,0))+((1.0 - (_poles*_poles*_poles*_poles))*_noise.r)*float2(0.05,0));
                float4 _finalMap = tex2D(_Noise,TRANSFORM_TEX(_finalUV, _Noise));
                float3 _color = TriLerp( _finalMap.r , _Color1.rgb , _Color2.rgb , _Color3.rgb );
                float3 diffuseColor = _color;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_4168 = 0.0;
                fixed zero = 0.0;
                float opacity = saturate((zero + ( (max(0,dot(i.normalDir,lerp(viewDirection,Function_node_5469(),Function_node_4846()))) - zero) * (1.0 - zero) ) / ((1.0 - _Density) - zero)));
                float node_2154 = (opacity*opacity);
                float3 emissive = lerp(tex2D( Refraction, sceneUVs.rg).rgb,float3(node_4168,node_4168,node_4168),node_2154);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                return fixed4(finalColor,node_2154);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd
            #pragma only_renderers d3d9 d3d11 glcore gles metal 
            #pragma target 3.0
            uniform sampler2D Refraction;
            uniform float _Density;
            uniform float _Flow;
            float Function_node_8136( float A ){
            float a,b,o;
            a=lerp(0,1,A/2);
            b=lerp(1,0,(A+1)/2);
            o=lerp(a,b,A);
            return o;
            }
            
            float3 TriLerp( float A , float3 B , float3 C , float3 D ){
            float3 a,b,o;
            a=lerp(B,C,A/2);
            b=lerp(C,D,(A+1)/2);
            o=lerp(a,b,A);
            return o;
            }
            
            uniform float4 _Color1;
            uniform float4 _Color2;
            uniform float4 _Color3;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _Cyclones;
            uniform sampler2D _Cyclone; uniform float4 _Cyclone_ST;
            float Function_node_4846(){
            return UNITY_MATRIX_P[3][3];
            }
            
            float3 Function_node_5469(){
            return  -mul((float3x3)unity_CameraToWorld, float3(0,0,1));;
            }
            
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 projPos : TEXCOORD3;
                LIGHTING_COORDS(4,5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float2 sceneUVs = (i.projPos.xy / i.projPos.w);
                float4 sceneColor = tex2D(Refraction, sceneUVs);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float node_1286 = 0.0;
                float gloss = node_1286;
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float3 specularColor = float3(node_1286,node_1286,node_1286);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 node_2918 = normalize(i.normalDir);
                float _gNorm = node_2918.g;
                float _poles = (_gNorm*_gNorm*_gNorm*_gNorm);
                float2 _uv = i.uv0.rg;
                float2 _noiseUV = float2(((_uv.r*1.0)+(Function_node_8136( (node_2918.g*0.5+0.5) )*3.0)),(_uv.g*2.0));
                float4 _noise = tex2D(_Noise,TRANSFORM_TEX(_noiseUV, _Noise));
                float4 time = _Time;
                float4 _cyclone = tex2D(_Cyclone,TRANSFORM_TEX(i.uv0, _Cyclone));
                float node_362 = (_Cyclones*_cyclone.r*0.6);
                float _cyclonesUV_ang = node_362;
                float _cyclonesUV_spd = 1.0;
                float _cyclonesUV_cos = cos(_cyclonesUV_spd*_cyclonesUV_ang);
                float _cyclonesUV_sin = sin(_cyclonesUV_spd*_cyclonesUV_ang);
                float2 _cyclonesUV_piv = float2(0.5,0.5);
                float2 node_2466 = float2(0.0,i.uv0.g);
                float2 _cyclonesUV = (mul(node_2466-_cyclonesUV_piv,float2x2( _cyclonesUV_cos, -_cyclonesUV_sin, _cyclonesUV_sin, _cyclonesUV_cos))+_cyclonesUV_piv);
                float2 _finalUV = ((_cyclonesUV+(_Flow*time.r)*float2(0.1,0))+((1.0 - (_poles*_poles*_poles*_poles))*_noise.r)*float2(0.05,0));
                float4 _finalMap = tex2D(_Noise,TRANSFORM_TEX(_finalUV, _Noise));
                float3 _color = TriLerp( _finalMap.r , _Color1.rgb , _Color2.rgb , _Color3.rgb );
                float3 diffuseColor = _color;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed zero = 0.0;
                float opacity = saturate((zero + ( (max(0,dot(i.normalDir,lerp(viewDirection,Function_node_5469(),Function_node_4846()))) - zero) * (1.0 - zero) ) / ((1.0 - _Density) - zero)));
                float node_2154 = (opacity*opacity);
                return fixed4(finalColor * node_2154,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
