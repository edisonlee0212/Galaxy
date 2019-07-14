// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Shader created with Shader Forge v1.36 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.36;sub:START;pass:START;ps:flbk:,iptp:2,cusa:False,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:True,qofs:0,qpre:0,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:3554,x:32746,y:33181,varname:node_3554,prsc:2|emission-9564-OUT;n:type:ShaderForge.SFN_Tex2d,id:7491,x:32173,y:33218,varname:_node_7491,prsc:2,tex:0770f6d0883a835439e897cae1766b79,ntxv:0,isnm:False|UVIN-7935-UVOUT,TEX-688-TEX;n:type:ShaderForge.SFN_ComponentMask,id:7978,x:31395,y:33282,varname:node_7978,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-422-OUT;n:type:ShaderForge.SFN_Append,id:5502,x:31618,y:33218,varname:node_5502,prsc:2|A-7978-B,B-7978-G;n:type:ShaderForge.SFN_Append,id:1318,x:31618,y:33334,varname:node_1318,prsc:2|A-7978-B,B-7978-R;n:type:ShaderForge.SFN_Append,id:3398,x:31618,y:33449,varname:node_3398,prsc:2|A-7978-R,B-7978-G;n:type:ShaderForge.SFN_Tex2dAsset,id:688,x:31618,y:33665,ptovrint:False,ptlb:Skybox,ptin:_Skybox,varname:_Skybox,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0770f6d0883a835439e897cae1766b79,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5041,x:32173,y:33376,varname:_node_7491_copy,prsc:2,tex:0770f6d0883a835439e897cae1766b79,ntxv:0,isnm:False|UVIN-6173-UVOUT,TEX-688-TEX;n:type:ShaderForge.SFN_Tex2d,id:4465,x:32173,y:33546,varname:_node_7491_copy_copy,prsc:2,tex:0770f6d0883a835439e897cae1766b79,ntxv:0,isnm:False|UVIN-8720-UVOUT,TEX-688-TEX;n:type:ShaderForge.SFN_Multiply,id:1219,x:31853,y:32959,varname:node_1219,prsc:2|A-7978-OUT,B-7978-OUT;n:type:ShaderForge.SFN_ChannelBlend,id:3575,x:32412,y:33296,varname:node_3575,prsc:2,chbt:0|M-1219-OUT,R-7491-RGB,G-5041-RGB,B-4465-RGB;n:type:ShaderForge.SFN_FragmentPosition,id:9868,x:30905,y:33236,varname:node_9868,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:2074,x:31853,y:33141,varname:node_2074,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-5502-OUT;n:type:ShaderForge.SFN_RemapRange,id:2222,x:31853,y:33334,varname:node_2222,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-1318-OUT;n:type:ShaderForge.SFN_RemapRange,id:8614,x:31863,y:33537,varname:node_8614,prsc:2,frmn:-1,frmx:1,tomn:1,tomx:0|IN-3398-OUT;n:type:ShaderForge.SFN_ProjectionParameters,id:4383,x:30936,y:33525,varname:node_4383,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4770,x:31150,y:33265,varname:node_4770,prsc:2|A-9868-XYZ,B-9557-OUT;n:type:ShaderForge.SFN_Divide,id:9557,x:31219,y:33467,varname:node_9557,prsc:2|A-4383-RFAR,B-4548-OUT;n:type:ShaderForge.SFN_Vector1,id:4548,x:31108,y:33613,varname:node_4548,prsc:2,v1:6;n:type:ShaderForge.SFN_Multiply,id:9564,x:32503,y:33435,varname:node_9564,prsc:2|A-3575-OUT,B-874-OUT;n:type:ShaderForge.SFN_Slider,id:874,x:32326,y:33632,ptovrint:False,ptlb:exposure,ptin:_exposure,varname:_exposure,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:3;n:type:ShaderForge.SFN_Normalize,id:422,x:31266,y:33073,varname:node_422,prsc:2|IN-9868-XYZ;n:type:ShaderForge.SFN_Rotator,id:8720,x:32038,y:33664,varname:node_8720,prsc:2|UVIN-8614-OUT,ANG-279-OUT;n:type:ShaderForge.SFN_Vector1,id:279,x:31891,y:33793,varname:node_279,prsc:2,v1:2;n:type:ShaderForge.SFN_Rotator,id:6173,x:32015,y:33471,varname:node_6173,prsc:2|UVIN-2222-OUT,ANG-1397-OUT;n:type:ShaderForge.SFN_Vector1,id:1397,x:31863,y:33716,varname:node_1397,prsc:2,v1:3;n:type:ShaderForge.SFN_Vector1,id:1094,x:31820,y:33483,varname:node_1094,prsc:2,v1:4;n:type:ShaderForge.SFN_Rotator,id:7935,x:32002,y:33292,varname:node_7935,prsc:2|UVIN-2074-OUT,ANG-1094-OUT;proporder:688-874;pass:END;sub:END;*/

Shader "Human Unit/SpaceSky" {
    Properties {
        _Skybox ("Skybox", 2D) = "white" {}
        _exposure ("exposure", Range(0, 3)) = 2
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Background"
            "RenderType"="Opaque"
            "PreviewType"="Skybox"
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
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone ps4 
            #pragma target 3.0
            uniform sampler2D _Skybox; uniform float4 _Skybox_ST;
            uniform float _exposure;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float3 node_7978 = normalize(i.posWorld.rgb).rgb;
                float3 node_1219 = (node_7978*node_7978);
                float node_7935_ang = 4.0;
                float node_7935_spd = 1.0;
                float node_7935_cos = cos(node_7935_spd*node_7935_ang);
                float node_7935_sin = sin(node_7935_spd*node_7935_ang);
                float2 node_7935_piv = float2(0.5,0.5);
                float2 node_7935 = (mul((float2(node_7978.b,node_7978.g)*0.5+0.5)-node_7935_piv,float2x2( node_7935_cos, -node_7935_sin, node_7935_sin, node_7935_cos))+node_7935_piv);
                float4 _node_7491 = tex2D(_Skybox,TRANSFORM_TEX(node_7935, _Skybox));
                float node_6173_ang = 3.0;
                float node_6173_spd = 1.0;
                float node_6173_cos = cos(node_6173_spd*node_6173_ang);
                float node_6173_sin = sin(node_6173_spd*node_6173_ang);
                float2 node_6173_piv = float2(0.5,0.5);
                float2 node_6173 = (mul((float2(node_7978.b,node_7978.r)*0.5+0.5)-node_6173_piv,float2x2( node_6173_cos, -node_6173_sin, node_6173_sin, node_6173_cos))+node_6173_piv);
                float4 _node_7491_copy = tex2D(_Skybox,TRANSFORM_TEX(node_6173, _Skybox));
                float node_8720_ang = 2.0;
                float node_8720_spd = 1.0;
                float node_8720_cos = cos(node_8720_spd*node_8720_ang);
                float node_8720_sin = sin(node_8720_spd*node_8720_ang);
                float2 node_8720_piv = float2(0.5,0.5);
                float2 node_8720 = (mul((float2(node_7978.r,node_7978.g)*-0.5+0.5)-node_8720_piv,float2x2( node_8720_cos, -node_8720_sin, node_8720_sin, node_8720_cos))+node_8720_piv);
                float4 _node_7491_copy_copy = tex2D(_Skybox,TRANSFORM_TEX(node_8720, _Skybox));
                float3 emissive = ((node_1219.r*_node_7491.rgb + node_1219.g*_node_7491_copy.rgb + node_1219.b*_node_7491_copy_copy.rgb)*_exposure);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    //CustomEditor "ShaderForgeMaterialInspector"
}
