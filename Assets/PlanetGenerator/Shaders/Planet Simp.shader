// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge

Shader "Human Unit/Planet Simple" {
    Properties {
        _Height ("Height", 2D) = "black" {}
        _AdditionalDetails ("AdditionalDetails", 2D) = "black" {}
        _RandomSeed ("RandomSeed", Range(0, 1000)) = 106.7961
        _Size ("Size", Range(0, 1)) = 0.1359223
        _AtmosphereColor ("AtmosphereColor", Color) = (0.1196755,0.2736696,0.8676471,1)
        _WaterLevel ("WaterLevel", Range(-1, 1)) = 0.1262136
        _ShoresContrast ("ShoresContrast", Range(0, 1)) = 0.2427184
        _OceanOpacity ("OceanOpacity", Range(0, 1)) = 1
        _Gloss ("Gloss", Range(0, 1)) = 0
        _Specularity ("Specularity", Range(0, 1)) = 0.1650485
        _Frost ("Frost", Range(-0.51, 3)) = -0.407767
        _FrostContrast ("FrostContrast", Range(0, 1)) = 0.5436893
        _Heat ("Heat", Range(0, 1)) = 0.06796116
        _CloudsColor ("CloudsColor", Color) = (1,1,1,1)
        _HeightGradient ("HeightGradient", 2D) = "white" {}
        _DetailsGradient ("DetailsGradient", 2D) = "black" {}
        _Clouds ("Clouds", 2D) = "gray" {}
        _CloudsPole ("CloudsPole", 2D) = "black" {}
        [MaterialToggle] _CloudsAvgBlend ("CloudsAvgBlend", float ) = 0
        _CloudsSpeed ("CloudsSpeed", Range(0, 1)) = 0.4368932
        _CloudsAmount ("CloudsAmount", Range(0, 1)) = 1
        _CloudsHeight ("CloudsHeight", Range(0, 1)) = 0.2055926
        _CloudsSpread ("CloudsSpread", Range(0, 1)) = 1
        _Normal ("Normal", 2D) = "bump" {}
        _Relief ("Relief", Range(0, 1)) = 0.3980583
        _FertilityMap ("FertilityMap", 2D) = "gray" {}
        _Vegetation ("Vegetation", Color) = (0,0.097,0.004462,1)
        _Fertility ("Fertility", Range(0, 1)) = 0.6116505
        _VegetationContrast ("VegetationContrast", Range(0, 0.5)) = 0.1279525
        _Ambient ("Ambient", Range(0, 1)) = 0
        _VegetationFrostResistance ("VegetationFrostResistance", Range(0, 1)) = 0.4563107
        _Cities ("Cities", 2D) = "gray" {}
        _PopulationFrostModifier ("PopulationFrostModifier", float ) = 0
        [HDR]_CitiesColor ("CitiesColor", Color) = (0.5,0.5,0.5,1)
        _Population ("Population", Range(0, 1)) = 0
        _PopulationShoresMountains ("PopulationShoresMountains", Range(0, 1)) = 0
        _HeatMultiplier ("HeatMultiplier", float ) = 0
        _VegetationMultiplier ("VegetationMultiplier", float ) = 1
        _NoVegetationMultiplier ("NoVegetationMultiplier", float ) = 1
        _PopulationLandOcean ("PopulationLandOcean", Range(0, 1)) = 0
		[MaterialToggle] _EmissiveLiquid ("EmissiveLiquid", Float ) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
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
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
			#pragma shader_feature _CLOUDS
			#pragma shader_feature _COMPLEXCLOUDS
            #pragma multi_compile_fwdbase_fullshadows
            //#pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Height; uniform half4 _Height_ST;
            uniform half _RandomSeed;
            uniform half _Size;
            uniform half _WaterLevel;
            uniform half4 _AtmosphereColor;
            uniform half _Gloss;
            uniform sampler2D _HeightGradient; uniform half4 _HeightGradient_ST;
            uniform sampler2D _Clouds; uniform half4 _Clouds_ST;
            uniform half4 _CloudsColor;
			uniform fixed _EmissiveLiquid;
            half Clouds( float2 UV , float time , sampler2D tex , half speed , fixed E ){

            speed=speed*0.3;
            float sinTime = frac(sin(time.x*speed)*0.05);
            float sinTime2 = frac(sin(time.x*speed+0.78)*0.05);
            float sinTime3 = frac(sin(time.x*speed+1.57)*0.05);
            float sinTime4 = frac(sin(time.x*speed+2.35)*0.05);
            half1 clouds1 = tex2D(tex, float2(-UV.r+frac(speed*time.x*0.035+0.3), -UV.g+sinTime2)).r;
            half1 clouds2 = tex2D(tex, float2(UV.r+frac(speed*time.x*0.03),UV.g+sinTime)).r;
            half1 clouds3 = tex2D(tex, float2(-UV.r-frac(speed*time.x*0.035-0.35),-UV.g+sinTime3)).r;
            half1 clouds4 = tex2D(tex, float2(UV.r-frac(speed*time.x*0.03),UV.g+sinTime4)).r;
			return saturate(lerp(clouds1*clouds2+2*clouds3*clouds2*1.1,(2*clouds1+clouds2+2*clouds3+clouds2)*0.3,E));
            }
			half CloudsSimple( float2 UV , float time , sampler2D tex , half speed , fixed E ){
			#if _COMPLEXCLOUDS
			return(Clouds(UV,time,tex,speed,E));
			#endif
            speed=speed*0.3;
            float sinTime = frac(sin(time.x*speed)*0.05);
            float sinTime2 = frac(sin(time.x*speed+1.57)*0.05);
            half1 clouds1 = tex2D(tex, float2(-UV.r+frac(speed*time.x*0.035+0.3), -UV.g+sinTime2)).r;
            half1 clouds2 = tex2D(tex, float2(UV.r+frac(speed*time.x*0.03),UV.g+sinTime)).r;
			return saturate(lerp(clouds1*clouds2*1.6,(2*clouds1+clouds2)*0.5,E));
            }
            
            uniform half _CloudsSpeed;
            uniform half _CloudsAmount;

            half CloudsShadows( float2 UV , float time , sampler2D tex , half speed , fixed E ){
            speed=speed*0.3;
            float sinTime = frac(sin(time.x*speed)*0.05);
            float sinTime2 = frac(sin(time.x*speed+0.78)*0.05);
            float sinTime3 = frac(sin(time.x*speed+1.57)*0.05);
            float sinTime4 = frac(sin(time.x*speed+2.35)*0.05);
            half1 clouds1 = tex2Dbias(tex, float4(-UV.r+frac(speed*time.x*0.035+0.3), -UV.g+sinTime2,0,3)).r;
            half1 clouds2 = tex2Dbias(tex, float4(UV.r+frac(speed*time.x*0.03),UV.g+sinTime,0,3)).r;
            half1 clouds3 = tex2Dbias(tex, float4(-UV.r-frac(speed*time.x*0.035-0.35),-UV.g+sinTime3,0,3)).r;
            half1 clouds4 = tex2Dbias(tex, float4(UV.r-frac(speed*time.x*0.03),UV.g+sinTime4,0,3)).r;
            return saturate(lerp(clouds1*clouds2+2*clouds3*clouds2*1.1,(2*clouds1+clouds2+2*clouds3+clouds2)*0.3,E));
            }
			half CloudsShadowsSimple( float2 UV , float time , sampler2D tex , half speed , fixed E ){
			#if _COMPLEXCLOUDS
			return(CloudsShadows(UV,time,tex,speed,E));
			#endif
            speed=speed*0.3;
            float sinTime = frac(sin(time.x*speed)*0.05);
            float sinTime2 = frac(sin(time.x*speed+1.57)*0.05);
            half1 clouds1 = tex2Dbias(tex, float4(-UV.r+frac(speed*time.x*0.035+0.3), -UV.g+sinTime2,0,3)).r;
            half1 clouds2 = tex2Dbias(tex, float4(UV.r+frac(speed*time.x*0.03),UV.g+sinTime,0,3)).r;
            return saturate(lerp(clouds1*clouds2*1.6,(2*clouds1+clouds2)*0.5,E));
            }
            
            uniform half _CloudsHeight;
            uniform half _CloudsSpread;
            uniform sampler2D _Normal; uniform half4 _Normal_ST;
            half3 Rotate( half3 Normal , half Angle ){
            
            half nx = Normal.x;
            half ny = Normal.y;
            half nz = Normal.z;
            
            half a=Angle;
            
            
            half ca=cos(a);
            half sa=sin(a);
            half3 rN=half3(ca*nx-sa*ny,sa*nx+ca*ny,nz);
            
            rN=rN.yxz;
            
            return rN;
            }
            
            half3 normYZ( half3 norm , half3 normDir ){
            half3 xNorm =normalize(half3(norm.xy  + normDir.zy, normDir.x));
            
            xNorm=xNorm.zyx;
            return xNorm;
            }
            
            half3 normYX( half3 norm , half3 normDir ){
            half3 yNorm = normalize(half3(norm.xy + normDir.zx, normDir.y));
            
            yNorm=yNorm.yzx;
            return yNorm;
            }
            
            half3 normXZ( half3 norm , half3 normDir ){
            half3 zNorm = normalize(half3(norm.yx  + normDir.xy, normDir.z));
            return zNorm;
            }
            
            uniform half _Relief;
            uniform sampler2D _FertilityMap; uniform half4 _FertilityMap_ST;
            uniform half4 _Vegetation;
            uniform half _Fertility;
            uniform half _VegetationContrast;
            uniform half _Frost;
            uniform half _Specularity;
            uniform half _Ambient;
            uniform half _VegetationFrostResistance;
            uniform sampler2D _Cities; uniform half4 _Cities_ST;
            uniform half _Population;
            uniform half _PopulationFrostModifier;
            uniform half4 _CitiesColor;
            uniform half _OceanOpacity;
            uniform sampler2D _AdditionalDetails; uniform half4 _AdditionalDetails_ST;
            uniform sampler2D _DetailsGradient; uniform half4 _DetailsGradient_ST;
            uniform half _FrostContrast;
            uniform half _ShoresContrast;
            uniform half _Heat;
            uniform half _PopulationShoresMountains;
            uniform half _HeatMultiplier;
            uniform half _VegetationMultiplier;
            uniform half _NoVegetationMultiplier;
            uniform half _PopulationLandOcean;
            uniform sampler2D _CloudsPole; uniform half4 _CloudsPole_ST;
            half CloudsPoleShadowsUnpack( sampler2D tex , half2 UV ){
            return(tex2Dbias(tex,half4(UV,0,5)).r);
            }
            
            uniform fixed _CloudsAvgBlend;
            struct VertexInput {
                half4 vertex : POSITION;
                half3 normal : NORMAL;
                half4 tangent : TANGENT;
                half2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                half3 normalDir : TEXCOORD2;
                half3 tangentDir : TEXCOORD3;
                half3 bitangentDir : TEXCOORD4;
				half3 mask : TEXCOORD5;
				float4 uvxy : TEXCOORD6;
				float4 uvz : TEXCOORD7;
                //LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, half4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                half3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
				half3 mask=3.8416*v.normal*v.normal*v.normal*v.normal;
				mask=mask/(dot(mask,half3(1,1,1)));
				o.mask = mask;

				float3 PosScaled = ((_Size*4.9+0.1)*mul( unity_WorldToObject, float4((o.posWorld.rgb-objPos.rgb),0) ).xyz);

				float UVRotX_ang = _RandomSeed;
                float UVRotX_cos = cos(UVRotX_ang);
                float UVRotX_sin = sin(UVRotX_ang);
                float2 UVRotX_piv = float2(0.5,0.5);
                float2 UVRotX = (mul((PosScaled.gb*0.5+0.5)-UVRotX_piv,float2x2( UVRotX_cos, -UVRotX_sin, UVRotX_sin, UVRotX_cos))+UVRotX_piv);
                float2 UVPanX = (UVRotX+_RandomSeed*float2(0.7,0));
                float2 UVX = lerp(UVPanX,(float2(0.3,0)+UVPanX),(sign(v.normal.r)*0.5+0.5));

				float UVRotY_ang = (_RandomSeed*4.0);
                float UVRotY_cos = cos(UVRotY_ang);
                float UVRotY_sin = sin(UVRotY_ang);
                float2 UVRotY_piv = float2(0.5,0.5);
                float2 UVRotY = (mul((PosScaled.rb*0.5+0.5)-UVRotY_piv,float2x2( UVRotY_cos, -UVRotY_sin, UVRotY_sin, UVRotY_cos))+UVRotY_piv);
                float2 UVPanY = (UVRotY+_RandomSeed*float2(0,0.7));
                float2 UVY = lerp(UVPanY,(float2(0.3,0.3)+UVPanY),(sign(v.normal.g)*0.5+0.5));

				o.uvxy=float4(UVX,UVY);

				float UVRotZ_ang = (_RandomSeed*8.0);
                float UVRotZ_cos = cos(UVRotZ_ang);
                float UVRotZ_sin = sin(UVRotZ_ang);
                float2 UVRotZ_piv = float2(0.5,0.5);
                float2 UVRotZ = (mul((PosScaled.rg*0.5+0.5)-UVRotZ_piv,float2x2( UVRotZ_cos, -UVRotZ_sin, UVRotZ_sin, UVRotZ_cos))+UVRotZ_piv);
                float2 UVPanZ = (UVRotZ+_RandomSeed*float2(-0.7,0.7));
                float2 UVZ = lerp(UVPanZ,(float2(0,0.3)+UVPanZ),(sign(v.normal.b)*0.5+0.5));

				o.uvz=float4(UVZ,(PosScaled.rb*0.5+0.5));
                //TRANSFER_VERTEX_TO_FRAGMENT(o);
                return o;
            }
            half4 frag(VertexOutput i) : COLOR {
                //float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                half3 NormalsLocalNormalized = normalize(mul( unity_WorldToObject, half4((i.normalDir),0) ).xyz.rgb);
                fixed3 _Mask = i.mask;


				float2 _UVX = i.uvxy.xy;
				float2 _UVY = i.uvxy.zw;
				float2 _UVZ = i.uvz.xy;
				float2 _PolesPos1 = i.uvz.zw;



				
                half4 HeightX = tex2D(_Height,_UVX);
				half4 HeightY = tex2D(_Height,_UVY);
                half4 HeightZ = tex2D(_Height,_UVZ);
                half Height = (1.0*(_Mask.r*HeightX.r + _Mask.g*HeightY.r + _Mask.b*HeightZ.r));
                half heightNormalized = saturate((( (Height - _WaterLevel)) / (1.0 - _WaterLevel)));
                half ShoresContrastRemaped = (_ShoresContrast*0.09000003+0.9);
                half _water = saturate((( ((1.0 - heightNormalized) - ShoresContrastRemaped)) / (1.0 - ShoresContrastRemaped)));
                half WaterRelief = (1.0 - (0.7*_water));
				half3 NormalX = UnpackNormal(tex2D(_Normal,_UVX));
                half3 NormalY = UnpackNormal(tex2D(_Normal,_UVY));
                half3 NormalZ = UnpackNormal(tex2D(_Normal,_UVZ));

                half oceanDepth = (( (Height + 0.001)) / (_WaterLevel + 0.001));
                half poles = abs(NormalsLocalNormalized.g);
                half polesContrast = (_Frost*-1.58+0.16);
                half IminFrostContrast = (0.5-((1.0 - polesContrast)*0.5));
                half PolesReachMao = ( saturate((( ((clamp(lerp(_Frost,(_Frost-0.3),_water),-0.51,3)+poles) - IminFrostContrast)) / ((0.5+((1.0 - polesContrast)*0.5)) - IminFrostContrast))) > 0.5 ? (1.0-(1.0-2.0*(saturate((( ((clamp(lerp(_Frost,(_Frost-0.3),_water),-0.51,3)+poles) - IminFrostContrast) ) / ((0.5+((1.0 - polesContrast)*0.5)) - IminFrostContrast)))-0.5))*(1.0-lerp((Height),(oceanDepth),_water))) : (2.0*saturate((( ((clamp(lerp(_Frost,(_Frost-0.3),_water),-0.51,3)+poles) - IminFrostContrast) ) / ((0.5+((1.0 - polesContrast)*0.5)) - IminFrostContrast)))*lerp((Height),(oceanDepth),_water)) );
                half PolesContrastIMin = (0.5-((1.0 - _FrostContrast)*0.5));
                half Freezing = saturate(( ( (PolesReachMao - PolesContrastIMin) ) / ((0.5+((1.0 - _FrostContrast)*0.5)) - PolesContrastIMin))); // Frezing
				#if _CLOUDS
                half CloudsAmounbtNeg = (-1*(1.0 - _CloudsAmount));
                float timeClouds = (_Time + _TimeEditor).g;
                fixed PolesCaps = saturate((poles*-5.0+4.5));
                float CloudsPoleUV_ang = timeClouds;
                float CloudsPoleUV_spd = (_CloudsSpeed*(-0.1));
                float CloudsPoleUV_cos = cos(CloudsPoleUV_spd*CloudsPoleUV_ang);
                float CloudsPoleUV_sin = sin(CloudsPoleUV_spd*CloudsPoleUV_ang);
                float2 CloudsPoleUV_piv = float2(0.5,0.5);
                float2 CloudsPoleUV = (mul((_PolesPos1*0.6+0.21)-CloudsPoleUV_piv,float2x2( CloudsPoleUV_cos, -CloudsPoleUV_sin, CloudsPoleUV_sin, CloudsPoleUV_cos))+CloudsPoleUV_piv);
				
                float4 _CloudsPoleDif = tex2D(_CloudsPole,TRANSFORM_TEX(CloudsPoleUV, _CloudsPole)).r;
                float _clouds = pow(saturate((((CloudsAmounbtNeg+CloudsSimple( i.uv0 , timeClouds , _Clouds , _CloudsSpeed , _CloudsAvgBlend ))*PolesCaps)+(CloudsAmounbtNeg+saturate((_CloudsPoleDif-PolesCaps))))),(_CloudsSpread*-0.5+1.0));
                #else
				float _clouds=0;
				#endif
				half3 normalDirection = lerp(normalize(mul( unity_ObjectToWorld, half4((_Mask.r*normYZ( Rotate( (_Relief*NormalX.rgb*WaterRelief) , _RandomSeed ) , NormalsLocalNormalized ) + _Mask.g*normYX( Rotate( (_Relief*NormalY.rgb*WaterRelief) , (_RandomSeed*4.0) ) , NormalsLocalNormalized ) + _Mask.b*normXZ( Rotate( (_Relief*NormalZ.rgb*WaterRelief) , (_RandomSeed*8.0) ) , NormalsLocalNormalized )),0) ).xyz.rgb),i.normalDir,max(((1.0 - Freezing)*_water),_clouds));
                half3 lightDirection = lerp(normalize(_WorldSpaceLightPos0.xyz),normalize(_WorldSpaceLightPos0.xyz-i.posWorld),_WorldSpaceLightPos0.a);
                half3 lightColor = _LightColor0.rgb;
                half3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                //half attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                half2 heightGradientUV = half2(heightNormalized,0.0);
                half4 _HeightGradient_var = tex2D(_HeightGradient,TRANSFORM_TEX(heightGradientUV, _HeightGradient));
                half4 DetailsX = tex2D(_AdditionalDetails,TRANSFORM_TEX(_UVX, _AdditionalDetails));
                half4 DetailsY = tex2D(_AdditionalDetails,TRANSFORM_TEX(_UVY, _AdditionalDetails));
                half4 DetailsZ = tex2D(_AdditionalDetails,TRANSFORM_TEX(_UVZ, _AdditionalDetails));
                half DetailsAlpha = (_Mask.r*DetailsX.r + _Mask.g*DetailsY.r + _Mask.b*DetailsZ.r);
                half2 aDetailsGradUV = half2(DetailsAlpha,1.0);
                half4 _DetailsGradient_var = tex2D(_DetailsGradient,TRANSFORM_TEX(aDetailsGradUV, _DetailsGradient));
                half3 Ground = lerp(_HeightGradient_var.rgb,(_HeightGradient_var.rgb+_DetailsGradient_var.rgb),_DetailsGradient_var.a);
                half3 VegetationColor = saturate(((0.3*heightNormalized)+_Vegetation.rgb));
                half4 VegetationHSV_k = half4(0.0, -0.33, 0.66, -1.0);
                half4 VegetationHSV_p = lerp(half4(half4(VegetationColor,0.0).zy, VegetationHSV_k.wz), half4(half4(VegetationColor,0.0).yz, VegetationHSV_k.xy), step(half4(VegetationColor,0.0).z, half4(VegetationColor,0.0).y));
                half4 VegetationHSV_q = lerp(half4(VegetationHSV_p.xyw, half4(VegetationColor,0.0).x), half4(half4(VegetationColor,0.0).x, VegetationHSV_p.yzx), step(VegetationHSV_p.x, half4(VegetationColor,0.0).x));
                half VegetationHSV_d = VegetationHSV_q.x - min(VegetationHSV_q.w, VegetationHSV_q.y);
                half3 VegetationHSV = half3(abs(VegetationHSV_q.z + (VegetationHSV_q.w - VegetationHSV_q.y) / (6.0 * VegetationHSV_d)), VegetationHSV_d / (VegetationHSV_q.x), VegetationHSV_q.x);;
                half Heat = saturate(((1.0 - poles)+(((-0.5)*heightNormalized)+(_Heat*2.5+-1.0)))); // Heat
                half4 VegetationX = tex2D(_FertilityMap,TRANSFORM_TEX(_UVX, _FertilityMap));
                half4 VegetationY = tex2D(_FertilityMap,TRANSFORM_TEX(_UVY, _FertilityMap));
                half4 VegetationZ = tex2D(_FertilityMap,TRANSFORM_TEX(_UVZ, _FertilityMap));
                half PlantsMask = saturate(((1.0 - saturate((((saturate((PolesReachMao-(-1*(1.0 - (_VegetationFrostResistance*0.5+0.5)))))*1.3+-1.0)+poles+(0.35*heightNormalized))*2.857143+-0.857143)))*(0 + ( (((1.0 - saturate((0 + ( (Heat - _VegetationContrast) * (1.0 - 0) ) / ((1.0 - _VegetationContrast) - _VegetationContrast))))*((_Fertility*1.6+-1.0)+((_Mask.r*VegetationX.r + _Mask.g*VegetationY.r + _Mask.b*VegetationZ.r)+(heightNormalized*(-0.3))))) - _VegetationContrast) * (1.0 - 0) ) / ((1.0 - _VegetationContrast) - _VegetationContrast))));
                half OpacityRemaped = (_OceanOpacity*2.0+-2.0);
				half OceanDepth = saturate((OpacityRemaped + ( (oceanDepth ) * (1.0 - OpacityRemaped) )));
                half OceanDepthRemapped = (lerp(OceanDepth,(1.0 - OceanDepth),_EmissiveLiquid)*2.5);
                half3 Oceans = (_AtmosphereColor.rgb*(OceanDepthRemapped+1.0));
                half4 OceansHSV_k = half4(0.0, -0.33, 0.66, -1.0);
                half4 OceansHSV_p = lerp(half4(half4(Oceans,0.0).zy, OceansHSV_k.wz), half4(half4(Oceans,0.0).yz, OceansHSV_k.xy), step(half4(Oceans,0.0).z, half4(Oceans,0.0).y));
                half4 OceansHSV_q = lerp(half4(OceansHSV_p.xyw, half4(Oceans,0.0).x), half4(half4(Oceans,0.0).x, OceansHSV_p.yzx), step(OceansHSV_p.x, half4(Oceans,0.0).x));
                half OceansHSV_d = OceansHSV_q.x - min(OceansHSV_q.w, OceansHSV_q.y);

                half3 OceansHSV = half3(abs(OceansHSV_q.z + (OceansHSV_q.w - OceansHSV_q.y) / (6.0 * OceansHSV_d)), OceansHSV_d / (OceansHSV_q.x ), OceansHSV_q.x);
				#if _CLOUDS
                half _cloudsShadows = pow(saturate(((CloudsAmounbtNeg+saturate((CloudsPoleShadowsUnpack( _CloudsPole , CloudsPoleUV )-PolesCaps)))+(PolesCaps*(CloudsShadowsSimple( (((0.02*_CloudsHeight)*half2(dot(lightDirection,i.tangentDir),dot(lightDirection,i.bitangentDir)))+i.uv0) , timeClouds , _Clouds , _CloudsSpeed , _CloudsAvgBlend )+(-1*(1.0 - _CloudsAmount)))))),(_CloudsSpread*-0.5+1.0));
                #else
				half _cloudsShadows=0;
				#endif
				half3 Water = saturate(((pow(1.0-max(0,dot(normalDirection, viewDirection)),6.0)*0.5+0.5)*(lerp(half3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((OceansHSV.r-(OceanDepthRemapped*0.025))+half3(0.0,-1.0/3.0,1.0/3.0)))-1),OceansHSV.g)*OceansHSV.b)));
				half3 Diffuze = 
				lerp
				(
					(lerp
						(lerp
							(
								lerp
								(
									Ground,
									saturate
									(( 
										lerp
										(
											(
												lerp
												(
													half3(1,1,1),
													saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+half3(0.0,-0.33,0.33)))-1),VegetationHSV.g
												)
												*
												clamp( (VegetationHSV.b-saturate((heightNormalized*-1.0+0.1)) ),0.1,1)
											),
											(
												lerp
												(
													half3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+half3(0.0,-1.0/3.0,1.0/3.0)))-1),clamp((VegetationHSV.g-0.5),0.2,1)
												)
												*
												VegetationHSV.b
											),Heat
										) 
										> 0.5 ? 
										(1.0-(1.0-2.0*
										(lerp(
											(lerp(half3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+half3(0.0,-0.33,0.33)))-1),VegetationHSV.g)*clamp((VegetationHSV.b-saturate((heightNormalized*-1.0+0.1))),0.1,1))
											,(lerp(half3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+half3(0.0,-1.0/3.0,1.0/3.0)))-1),clamp((VegetationHSV.g-0.5),0.2,1))*VegetationHSV.b),Heat)-0.5))*(1.0-Ground))
										: 
										(2.0*lerp((lerp(half3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+half3(0.0,-0.33,0.33)))-1),VegetationHSV.g)*clamp((VegetationHSV.b-saturate((heightNormalized*-1.0+0.1))),0.1,1)),(lerp(half3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+half3(0.0,-1.0/3.0,1.0/3.0)))-1),clamp((VegetationHSV.g-0.5),0.2,1))*VegetationHSV.b),Heat)*Ground) 
									)),PlantsMask
								),Water,_water
							),
							saturate((1.0-(1.0-(lerp(lerp(_AtmosphereColor.rgb,half3(1,1,1),0.1),half3(1,1,1),Height)*Freezing))*(1.0-(DetailsAlpha*0.4)))),Freezing
					)*(1.0 - (_cloudsShadows*0.7))),_CloudsColor.rgb,_clouds
				); // Diffuse
                //half3 emissive = (saturate((Diffuze-1.0))+((Diffuze*UNITY_LIGHTMODEL_AMBIENT.rgb)*_Ambient));
				float3 emissive = (saturate((Diffuze-1.0))+((Diffuze*UNITY_LIGHTMODEL_AMBIENT.rgb)*_Ambient)+lerp(float3(0,0,0),(Water*_water),_EmissiveLiquid));
                half Lightside = max(0,dot(lightDirection,normalDirection)); // Lambert
                float2 _CityUVX = (_UVX*3.0);
                half4 CityX = tex2D(_Cities,TRANSFORM_TEX(_CityUVX, _Cities));
                float2 _CityUVY = (_UVY*3.0);
                half4 CityY = tex2D(_Cities,TRANSFORM_TEX(_CityUVY, _Cities));
                float2 _CityUVZ = (_UVZ*3.0);
                half4 CityZ = tex2D(_Cities,TRANSFORM_TEX(_CityUVZ, _Cities));
                half popFrost = lerp((_Population*_PopulationFrostModifier),_Population,(1.0 - Freezing)); // PopFrost
                half popHeat = lerp(popFrost,(popFrost*_HeatMultiplier),Heat); // PopHeat
                half popVeg = lerp(popHeat,(popHeat*_VegetationMultiplier),PlantsMask);
                half LightSide = min(0,dot(lightDirection,i.normalDir)); // Lambert
                half3 finalColor = emissive + 
				(
					(
						(
							(Diffuze*((_CloudsHeight*_clouds*0.1)+Lightside))
							+
							(Lightside*pow(max(0,dot(normalDirection,halfDirection)),exp(lerp(1,11,_Gloss)))*lerp((lerp(_water,((0.1*Freezing)+(_water*0.1)),Freezing)*saturate((0.6+_AtmosphereColor.rgb))*_Specularity),half3(0,0,0),_clouds)*2.0)
						)*_LightColor0.rgb
						//*attenuation
					)
					+
					(
						(clamp((((_Mask.r*CityX.r + _Mask.g*CityY.r + _Mask.b*CityZ.r)*lerp((1.0 - _water),_water,_PopulationLandOcean))-(1.0 - saturate((((lerp(popVeg,(popVeg*_NoVegetationMultiplier),(1.0 - PlantsMask))*2.0+-1.0)+lerp(lerp((1.0 - heightNormalized),heightNormalized,_PopulationShoresMountains),oceanDepth,_PopulationLandOcean))*5.0+-0.5)))),0,1)*abs(LightSide))*_CitiesColor.rgb
					)
				);
                return fixed4(finalColor,1);
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
			#pragma shader_feature _CLOUDS
			#pragma shader_feature _COMPLEXCLOUDS
            //#pragma multi_compile_fwdbase_fullshadows
            //#pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Height; uniform half4 _Height_ST;
            uniform half _RandomSeed;
            uniform half _Size;
            uniform half _WaterLevel;
            uniform half4 _AtmosphereColor;
            uniform half _Gloss;
            uniform sampler2D _HeightGradient; uniform half4 _HeightGradient_ST;
            uniform sampler2D _Clouds; uniform half4 _Clouds_ST;
            uniform half4 _CloudsColor;

            half Clouds( float2 UV , float time , sampler2D tex , half speed , fixed E ){

            speed=speed*0.3;
            float1 sinTime = frac(sin(time.x*speed)*0.05);
            float1 sinTime2 = frac(sin(time.x*speed+0.78)*0.05);
            float1 sinTime3 = frac(sin(time.x*speed+1.57)*0.05);
            float1 sinTime4 = frac(sin(time.x*speed+2.35)*0.05);
            half1 clouds1 = tex2D(tex, float2(-UV.r+frac(speed*time.x*0.035+0.3), -UV.g+sinTime2)).r;
            half1 clouds2 = tex2D(tex, float2(UV.r+frac(speed*time.x*0.03),UV.g+sinTime)).r;
            half1 clouds3 = tex2D(tex, float2(-UV.r-frac(speed*time.x*0.035-0.35),-UV.g+sinTime3)).r;
            half1 clouds4 = tex2D(tex, float2(UV.r-frac(speed*time.x*0.03),UV.g+sinTime4)).r;
			return saturate(lerp(clouds1*clouds2+2*clouds3*clouds2*1.1,(2*clouds1+clouds2+2*clouds3+clouds2)*0.3,E));
            }
			half CloudsSimple( float2 UV , float time , sampler2D tex , half speed , fixed E ){
			#if _COMPLEXCLOUDS
			return(Clouds(UV,time,tex,speed,E));
			#endif
            speed=speed*0.3;
            float1 sinTime = frac(sin(time.x*speed)*0.05);
            float1 sinTime2 = frac(sin(time.x*speed+1.57)*0.05);
            half1 clouds1 = tex2D(tex, float2(-UV.r+frac(speed*time.x*0.035+0.3), -UV.g+sinTime2)).r;
            half1 clouds2 = tex2D(tex, float2(UV.r+frac(speed*time.x*0.03),UV.g+sinTime)).r;
			return saturate(lerp(clouds1*clouds2*1.6,(2*clouds1+clouds2)*0.5,E));
            }
            
            uniform half _CloudsSpeed;
            uniform half _CloudsAmount;

            half CloudsShadows( float2 UV , float time , sampler2D tex , half speed , fixed E ){
            speed=speed*0.3;
            float1 sinTime = frac(sin(time.x*speed)*0.05);
            float1 sinTime2 = frac(sin(time.x*speed+0.78)*0.05);
            float1 sinTime3 = frac(sin(time.x*speed+1.57)*0.05);
            float1 sinTime4 = frac(sin(time.x*speed+2.35)*0.05);
            half1 clouds1 = tex2Dbias(tex, float4(-UV.r+frac(speed*time.x*0.035+0.3), -UV.g+sinTime2,0,3)).r;
            half1 clouds2 = tex2Dbias(tex, float4(UV.r+frac(speed*time.x*0.03),UV.g+sinTime,0,3)).r;
            half1 clouds3 = tex2Dbias(tex, float4(-UV.r-frac(speed*time.x*0.035-0.35),-UV.g+sinTime3,0,3)).r;
            half1 clouds4 = tex2Dbias(tex, float4(UV.r-frac(speed*time.x*0.03),UV.g+sinTime4,0,3)).r;
            return saturate(lerp(clouds1*clouds2+2*clouds3*clouds2*1.1,(2*clouds1+clouds2+2*clouds3+clouds2)*0.3,E));
            }
			half CloudsShadowsSimple( float2 UV , float time , sampler2D tex , half speed , fixed E ){
			#if _COMPLEXCLOUDS
			return(CloudsShadows(UV,time,tex,speed,E));
			#endif
            speed=speed*0.3;
            float1 sinTime = frac(sin(time.x*speed)*0.05);
            float1 sinTime2 = frac(sin(time.x*speed+0.78)*0.05);
            half1 clouds1 = tex2Dbias(tex, float4(-UV.r+frac(speed*time.x*0.035+0.3), -UV.g+sinTime2,0,3)).r;
            half1 clouds2 = tex2Dbias(tex, float4(UV.r+frac(speed*time.x*0.03),UV.g+sinTime,0,3)).r;
            return saturate(lerp(clouds1*clouds2*1.6,(2*clouds1+clouds2)*0.6,E));
            }
            
            uniform half _CloudsHeight;
            uniform half _CloudsSpread;
            uniform sampler2D _Normal; uniform half4 _Normal_ST;
            half3 Rotate( half3 Normal , half Angle ){
            
            half nx = Normal.x;
            half ny = Normal.y;
            half nz = Normal.z;
            
            half a=Angle;
            
            
            half ca=cos(a);
            half sa=sin(a);
            half3 rN=half3(ca*nx-sa*ny,sa*nx+ca*ny,nz);
            
            rN=rN.yxz;
            
            return rN;
            }
            
            half3 normYZ( half3 norm , half3 normDir ){
            half3 xNorm =normalize(half3(norm.xy  + normDir.zy, normDir.x));
            
            xNorm=xNorm.zyx;
            return xNorm;
            }
            
            half3 normYX( half3 norm , half3 normDir ){
            half3 yNorm = normalize(half3(norm.xy + normDir.zx, normDir.y));
            
            yNorm=yNorm.yzx;
            return yNorm;
            }
            
            half3 normXZ( half3 norm , half3 normDir ){
            half3 zNorm = normalize(half3(norm.yx  + normDir.xy, normDir.z));
            return zNorm;
            }
            
            uniform half _Relief;
            uniform sampler2D _FertilityMap; uniform half4 _FertilityMap_ST;
            uniform half4 _Vegetation;
            uniform half _Fertility;
            uniform half _VegetationContrast;
            uniform half _Frost;
            uniform half _Specularity;
            uniform half _Ambient;
            uniform half _VegetationFrostResistance;
            uniform sampler2D _Cities; uniform half4 _Cities_ST;
            uniform half _Population;
            uniform half _PopulationFrostModifier;
            uniform half4 _CitiesColor;
            uniform half _OceanOpacity;
            uniform sampler2D _AdditionalDetails; uniform half4 _AdditionalDetails_ST;
            uniform sampler2D _DetailsGradient; uniform half4 _DetailsGradient_ST;
            uniform half _FrostContrast;
            uniform half _ShoresContrast;
            uniform half _Heat;
            uniform half _PopulationShoresMountains;
            uniform half _HeatMultiplier;
            uniform half _VegetationMultiplier;
            uniform half _NoVegetationMultiplier;
            uniform half _PopulationLandOcean;
            uniform sampler2D _CloudsPole; uniform half4 _CloudsPole_ST;
            half CloudsPoleShadowsUnpack( sampler2D tex , float2 UV ){
            return(tex2Dbias(tex,float4(UV,0,5)).r);
            }
            
            uniform fixed _CloudsAvgBlend;
            struct VertexInput {
                float4 vertex : POSITION;
                half3 normal : NORMAL;
                half4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                half3 normalDir : TEXCOORD2;
                half3 tangentDir : TEXCOORD3;
                half3 bitangentDir : TEXCOORD4;
				half3 mask : TEXCOORD5;
				float4 uvxy : TEXCOORD6;
				float4 uvz : TEXCOORD7;
                //LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, half4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                half3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
				half3 mask=3.8416*v.normal*v.normal*v.normal*v.normal;
				mask=mask/(dot(mask,half3(1,1,1)));
				o.mask = mask;

				float3 PosScaled = ((_Size*4.9+0.1)*mul( unity_WorldToObject, float4((o.posWorld.rgb-objPos.rgb),0) ).xyz);

				float UVRotX_ang = _RandomSeed;
                float UVRotX_cos = cos(UVRotX_ang);
                float UVRotX_sin = sin(UVRotX_ang);
                float2 UVRotX_piv = float2(0.5,0.5);
                float2 UVRotX = (mul((PosScaled.gb*0.5+0.5)-UVRotX_piv,float2x2( UVRotX_cos, -UVRotX_sin, UVRotX_sin, UVRotX_cos))+UVRotX_piv);
                float2 UVPanX = (UVRotX+_RandomSeed*float2(0.7,0));
                float2 UVX = lerp(UVPanX,(float2(0.3,0)+UVPanX),(sign(v.normal.r)*0.5+0.5));

				float UVRotY_ang = (_RandomSeed*4.0);
                float UVRotY_cos = cos(UVRotY_ang);
                float UVRotY_sin = sin(UVRotY_ang);
                float2 UVRotY_piv = float2(0.5,0.5);
                float2 UVRotY = (mul((PosScaled.rb*0.5+0.5)-UVRotY_piv,float2x2( UVRotY_cos, -UVRotY_sin, UVRotY_sin, UVRotY_cos))+UVRotY_piv);
                float2 UVPanY = (UVRotY+_RandomSeed*float2(0,0.7));
                float2 UVY = lerp(UVPanY,(float2(0.3,0.3)+UVPanY),(sign(v.normal.g)*0.5+0.5));

				o.uvxy=float4(UVX,UVY);

				float UVRotZ_ang = (_RandomSeed*8.0);
                float UVRotZ_cos = cos(UVRotZ_ang);
                float UVRotZ_sin = sin(UVRotZ_ang);
                float2 UVRotZ_piv = float2(0.5,0.5);
                float2 UVRotZ = (mul((PosScaled.rg*0.5+0.5)-UVRotZ_piv,float2x2( UVRotZ_cos, -UVRotZ_sin, UVRotZ_sin, UVRotZ_cos))+UVRotZ_piv);
                float2 UVPanZ = (UVRotZ+_RandomSeed*float2(-0.7,0.7));
                float2 UVZ = lerp(UVPanZ,(float2(0,0.3)+UVPanZ),(sign(v.normal.b)*0.5+0.5));

				o.uvz=float4(UVZ,(PosScaled.rb*0.5+0.5));
                //TRANSFER_VERTEX_TO_FRAGMENT(o);
                return o;
            }
            half4 frag(VertexOutput i) : COLOR {
                //float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                half3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                half3 NormalsLocalNormalized = normalize(mul( unity_WorldToObject, half4((i.normalDir),0) ).xyz.rgb);
                fixed3 _Mask = i.mask;


				float2 _UVX = i.uvxy.xy;
				float2 _UVY = i.uvxy.zw;
				float2 _UVZ = i.uvz.xy;
				float2 _PolesPos1 = i.uvz.zw;



				
                half4 HeightX = tex2D(_Height,_UVX);
				half4 HeightY = tex2D(_Height,_UVY);
                half4 HeightZ = tex2D(_Height,_UVZ);
                half Height = (1.0*(_Mask.r*HeightX.r + _Mask.g*HeightY.r + _Mask.b*HeightZ.r));
                half heightNormalized = saturate((( (Height - _WaterLevel)) / (1.0 - _WaterLevel)));
                half ShoresContrastRemaped = (_ShoresContrast*0.09000003+0.9);
                half _water = saturate((( ((1.0 - heightNormalized) - ShoresContrastRemaped)) / (1.0 - ShoresContrastRemaped)));
                half WaterRelief = (1.0 - (0.7*_water));
				half3 NormalX = UnpackNormal(tex2D(_Normal,_UVX));
                half3 NormalY = UnpackNormal(tex2D(_Normal,_UVY));
                half3 NormalZ = UnpackNormal(tex2D(_Normal,_UVZ));

                half oceanDepth = (( (Height + 0.001)) / (_WaterLevel + 0.001));
                half poles = abs(NormalsLocalNormalized.g);
                half polesContrast = (_Frost*-1.58+0.16);
                half IminFrostContrast = (0.5-((1.0 - polesContrast)*0.5));
                half PolesReachMao = ( saturate((( ((clamp(lerp(_Frost,(_Frost-0.3),_water),-0.51,3)+poles) - IminFrostContrast)) / ((0.5+((1.0 - polesContrast)*0.5)) - IminFrostContrast))) > 0.5 ? (1.0-(1.0-2.0*(saturate((( ((clamp(lerp(_Frost,(_Frost-0.3),_water),-0.51,3)+poles) - IminFrostContrast) ) / ((0.5+((1.0 - polesContrast)*0.5)) - IminFrostContrast)))-0.5))*(1.0-lerp((Height),(oceanDepth),_water))) : (2.0*saturate((( ((clamp(lerp(_Frost,(_Frost-0.3),_water),-0.51,3)+poles) - IminFrostContrast) ) / ((0.5+((1.0 - polesContrast)*0.5)) - IminFrostContrast)))*lerp((Height),(oceanDepth),_water)) );
                half PolesContrastIMin = (0.5-((1.0 - _FrostContrast)*0.5));
                half Freezing = saturate(( ( (PolesReachMao - PolesContrastIMin) ) / ((0.5+((1.0 - _FrostContrast)*0.5)) - PolesContrastIMin))); // Frezing
				#if _CLOUDS
                half CloudsAmounbtNeg = (-1*(1.0 - _CloudsAmount));
                float timeClouds = (_Time + _TimeEditor).g;
                fixed PolesCaps = saturate((poles*-5.0+4.5));
                float CloudsPoleUV_ang = timeClouds;
                float CloudsPoleUV_spd = (_CloudsSpeed*(-0.1));
                float CloudsPoleUV_cos = cos(CloudsPoleUV_spd*CloudsPoleUV_ang);
                float CloudsPoleUV_sin = sin(CloudsPoleUV_spd*CloudsPoleUV_ang);
                float2 CloudsPoleUV_piv = float2(0.5,0.5);
                float2 CloudsPoleUV = (mul((_PolesPos1*0.6+0.21)-CloudsPoleUV_piv,float2x2( CloudsPoleUV_cos, -CloudsPoleUV_sin, CloudsPoleUV_sin, CloudsPoleUV_cos))+CloudsPoleUV_piv);
				
                half4 _CloudsPoleDif = tex2D(_CloudsPole,TRANSFORM_TEX(CloudsPoleUV, _CloudsPole)).r;
                half _clouds = pow(saturate((((CloudsAmounbtNeg+CloudsSimple( i.uv0 , timeClouds , _Clouds , _CloudsSpeed , _CloudsAvgBlend ))*PolesCaps)+(CloudsAmounbtNeg+saturate((_CloudsPoleDif-PolesCaps))))),(_CloudsSpread*-0.5+1.0));
                #else
				half _clouds=0;
				#endif
				half3 normalDirection = lerp(normalize(mul( unity_ObjectToWorld, half4((_Mask.r*normYZ( Rotate( (_Relief*NormalX.rgb*WaterRelief) , _RandomSeed ) , NormalsLocalNormalized ) + _Mask.g*normYX( Rotate( (_Relief*NormalY.rgb*WaterRelief) , (_RandomSeed*4.0) ) , NormalsLocalNormalized ) + _Mask.b*normXZ( Rotate( (_Relief*NormalZ.rgb*WaterRelief) , (_RandomSeed*8.0) ) , NormalsLocalNormalized )),0) ).xyz.rgb),i.normalDir,max(((1.0 - Freezing)*_water),_clouds));
                half3 lightDirection = lerp(normalize(_WorldSpaceLightPos0.xyz),normalize(_WorldSpaceLightPos0.xyz-i.posWorld),_WorldSpaceLightPos0.a);
                half3 lightColor = _LightColor0.rgb;
                half3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                //half attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                half2 heightGradientUV = half2(heightNormalized,0.0);
                half4 _HeightGradient_var = tex2D(_HeightGradient,TRANSFORM_TEX(heightGradientUV, _HeightGradient));
                half4 DetailsX = tex2D(_AdditionalDetails,TRANSFORM_TEX(_UVX, _AdditionalDetails));
                half4 DetailsY = tex2D(_AdditionalDetails,TRANSFORM_TEX(_UVY, _AdditionalDetails));
                half4 DetailsZ = tex2D(_AdditionalDetails,TRANSFORM_TEX(_UVZ, _AdditionalDetails));
                half DetailsAlpha = (_Mask.r*DetailsX.r + _Mask.g*DetailsY.r + _Mask.b*DetailsZ.r);
                half2 aDetailsGradUV = half2(DetailsAlpha,1.0);
                half4 _DetailsGradient_var = tex2D(_DetailsGradient,TRANSFORM_TEX(aDetailsGradUV, _DetailsGradient));
                half3 Ground = lerp(_HeightGradient_var.rgb,(_HeightGradient_var.rgb+_DetailsGradient_var.rgb),_DetailsGradient_var.a);
                half3 VegetationColor = saturate(((0.3*heightNormalized)+_Vegetation.rgb));
                half4 VegetationHSV_k = half4(0.0, -0.33, 0.66, -1.0);
                half4 VegetationHSV_p = lerp(half4(half4(VegetationColor,0.0).zy, VegetationHSV_k.wz), half4(half4(VegetationColor,0.0).yz, VegetationHSV_k.xy), step(half4(VegetationColor,0.0).z, half4(VegetationColor,0.0).y));
                half4 VegetationHSV_q = lerp(half4(VegetationHSV_p.xyw, half4(VegetationColor,0.0).x), half4(half4(VegetationColor,0.0).x, VegetationHSV_p.yzx), step(VegetationHSV_p.x, half4(VegetationColor,0.0).x));
                half VegetationHSV_d = VegetationHSV_q.x - min(VegetationHSV_q.w, VegetationHSV_q.y);
                half3 VegetationHSV = half3(abs(VegetationHSV_q.z + (VegetationHSV_q.w - VegetationHSV_q.y) / (6.0 * VegetationHSV_d)), VegetationHSV_d / (VegetationHSV_q.x), VegetationHSV_q.x);;
                half Heat = saturate(((1.0 - poles)+(((-0.5)*heightNormalized)+(_Heat*2.5+-1.0)))); // Heat
                half4 VegetationX = tex2D(_FertilityMap,TRANSFORM_TEX(_UVX, _FertilityMap));
                half4 VegetationY = tex2D(_FertilityMap,TRANSFORM_TEX(_UVY, _FertilityMap));
                half4 VegetationZ = tex2D(_FertilityMap,TRANSFORM_TEX(_UVZ, _FertilityMap));
                half PlantsMask = saturate(((1.0 - saturate((((saturate((PolesReachMao-(-1*(1.0 - (_VegetationFrostResistance*0.5+0.5)))))*1.3+-1.0)+poles+(0.35*heightNormalized))*2.857143+-0.857143)))*(0 + ( (((1.0 - saturate((0 + ( (Heat - _VegetationContrast) * (1.0 - 0) ) / ((1.0 - _VegetationContrast) - _VegetationContrast))))*((_Fertility*1.6+-1.0)+((_Mask.r*VegetationX.r + _Mask.g*VegetationY.r + _Mask.b*VegetationZ.r)+(heightNormalized*(-0.3))))) - _VegetationContrast) * (1.0 - 0) ) / ((1.0 - _VegetationContrast) - _VegetationContrast))));
                half OpacityRemaped = (_OceanOpacity*2.0+-2.0);
                half OceanDepthRemapped = (saturate((OpacityRemaped + ( (oceanDepth) * (1.0 - OpacityRemaped) )))*2.5);
                half3 Oceans = (_AtmosphereColor.rgb*(OceanDepthRemapped+1.0));
                half4 OceansHSV_k = half4(0.0, -0.33, 0.66, -1.0);
                half4 OceansHSV_p = lerp(half4(half4(Oceans,0.0).zy, OceansHSV_k.wz), half4(half4(Oceans,0.0).yz, OceansHSV_k.xy), step(half4(Oceans,0.0).z, half4(Oceans,0.0).y));
                half4 OceansHSV_q = lerp(half4(OceansHSV_p.xyw, half4(Oceans,0.0).x), half4(half4(Oceans,0.0).x, OceansHSV_p.yzx), step(OceansHSV_p.x, half4(Oceans,0.0).x));
                half OceansHSV_d = OceansHSV_q.x - min(OceansHSV_q.w, OceansHSV_q.y);

                half3 OceansHSV = half3(abs(OceansHSV_q.z + (OceansHSV_q.w - OceansHSV_q.y) / (6.0 * OceansHSV_d)), OceansHSV_d / (OceansHSV_q.x ), OceansHSV_q.x);
				#if _CLOUDS
                half _cloudsShadows = pow(saturate(((CloudsAmounbtNeg+saturate((CloudsPoleShadowsUnpack( _CloudsPole , CloudsPoleUV )-PolesCaps)))+(PolesCaps*(CloudsShadowsSimple( (((0.02*_CloudsHeight)*half2(dot(lightDirection,i.tangentDir),dot(lightDirection,i.bitangentDir)))+i.uv0) , timeClouds , _Clouds , _CloudsSpeed , _CloudsAvgBlend )+(-1*(1.0 - _CloudsAmount)))))),(_CloudsSpread*-0.5+1.0));
                #else
				half _cloudsShadows=0;
				#endif
				half3 Diffuze = 
				lerp
				(
					(lerp
						(lerp
							(
								lerp
								(
									Ground,
									saturate
									(( 
										lerp
										(
											(
												lerp
												(
													half3(1,1,1),
													saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+half3(0.0,-0.33,0.33)))-1),VegetationHSV.g
												)
												*
												clamp( (VegetationHSV.b-saturate((heightNormalized*-1.0+0.1)) ),0.1,1)
											),
											(
												lerp
												(
													half3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+half3(0.0,-1.0/3.0,1.0/3.0)))-1),clamp((VegetationHSV.g-0.5),0.2,1)
												)
												*
												VegetationHSV.b
											),Heat
										) 
										> 0.5 ? 
										(1.0-(1.0-2.0*
										(lerp(
											(lerp(half3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+half3(0.0,-0.33,0.33)))-1),VegetationHSV.g)*clamp((VegetationHSV.b-saturate((heightNormalized*-1.0+0.1))),0.1,1))
											,(lerp(half3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+half3(0.0,-1.0/3.0,1.0/3.0)))-1),clamp((VegetationHSV.g-0.5),0.2,1))*VegetationHSV.b),Heat)-0.5))*(1.0-Ground))
										: 
										(2.0*lerp((lerp(half3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+half3(0.0,-0.33,0.33)))-1),VegetationHSV.g)*clamp((VegetationHSV.b-saturate((heightNormalized*-1.0+0.1))),0.1,1)),(lerp(half3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+half3(0.0,-1.0/3.0,1.0/3.0)))-1),clamp((VegetationHSV.g-0.5),0.2,1))*VegetationHSV.b),Heat)*Ground) 
									)),PlantsMask
								),saturate(((pow(1.0-max(0,dot(normalDirection, viewDirection)),6.0)*0.5+0.5)*(lerp(half3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((OceansHSV.r-(OceanDepthRemapped*0.025))+half3(0.0,-1.0/3.0,1.0/3.0)))-1),OceansHSV.g)*OceansHSV.b))),_water
							),
							saturate((1.0-(1.0-(lerp(lerp(_AtmosphereColor.rgb,half3(1,1,1),0.1),half3(1,1,1),Height)*Freezing))*(1.0-(DetailsAlpha*0.4)))),Freezing
					)*(1.0 - (_cloudsShadows*0.7))),_CloudsColor.rgb,_clouds
				); // Diffuse
                half3 emissive = (saturate((Diffuze-1.0))+((Diffuze*UNITY_LIGHTMODEL_AMBIENT.rgb)*_Ambient));
                half Lightside = max(0,dot(lightDirection,normalDirection)); // Lambert
                float2 _CityUVX = (_UVX*3.0);
                half4 CityX = tex2D(_Cities,TRANSFORM_TEX(_CityUVX, _Cities));
                float2 _CityUVY = (_UVY*3.0);
                half4 CityY = tex2D(_Cities,TRANSFORM_TEX(_CityUVY, _Cities));
                float2 _CityUVZ = (_UVZ*3.0);
                half4 CityZ = tex2D(_Cities,TRANSFORM_TEX(_CityUVZ, _Cities));
                half popFrost = lerp((_Population*_PopulationFrostModifier),_Population,(1.0 - Freezing)); // PopFrost
                half popHeat = lerp(popFrost,(popFrost*_HeatMultiplier),Heat); // PopHeat
                half popVeg = lerp(popHeat,(popHeat*_VegetationMultiplier),PlantsMask);
                half LightSide = min(0,dot(lightDirection,i.normalDir)); // Lambert
                half3 finalColor = emissive + 
				(
					(
						(
							(Diffuze*((_CloudsHeight*_clouds*0.1)+Lightside))
							+
							(Lightside*pow(max(0,dot(normalDirection,halfDirection)),exp(lerp(1,11,_Gloss)))*lerp((lerp(_water,((0.1*Freezing)+(_water*0.1)),Freezing)*saturate((0.6+_AtmosphereColor.rgb))*_Specularity),half3(0,0,0),_clouds)*2.0)
						)*_LightColor0.rgb
						//*attenuation
					)
					+
					(
						(clamp((((_Mask.r*CityX.r + _Mask.g*CityY.r + _Mask.b*CityZ.r)*lerp((1.0 - _water),_water,_PopulationLandOcean))-(1.0 - saturate((((lerp(popVeg,(popVeg*_NoVegetationMultiplier),(1.0 - PlantsMask))*2.0+-1.0)+lerp(lerp((1.0 - heightNormalized),heightNormalized,_PopulationShoresMountains),oceanDepth,_PopulationLandOcean))*5.0+-0.5)))),0,1)*abs(LightSide))*_CitiesColor.rgb
					)
				);
                return fixed4(finalColor,1);
            }
            ENDCG
        }
		
    }
}
