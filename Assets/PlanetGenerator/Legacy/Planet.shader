// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:2,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:2,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:47407,y:32038,varname:node_4013,prsc:2|diff-260-OUT,spec-4106-OUT,gloss-8689-OUT,normal-8678-OUT,emission-6453-OUT,lwrap-3138-OUT,amdfl-793-OUT,difocc-4684-OUT;n:type:ShaderForge.SFN_NormalVector,id:561,x:33964,y:32255,prsc:2,pt:False;n:type:ShaderForge.SFN_Subtract,id:4992,x:37096,y:32705,varname:node_4992,prsc:2|A-9755-OUT,B-2328-OUT;n:type:ShaderForge.SFN_Slider,id:3977,x:37986,y:32148,ptovrint:False,ptlb:WaterLevel,ptin:_WaterLevel,varname:_WaterLevel,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4951456,max:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:9431,x:39613,y:32520,varname:node_9431,prsc:2|IN-9755-OUT,IMIN-2328-OUT,IMAX-8849-OUT,OMIN-2919-OUT,OMAX-8849-OUT;n:type:ShaderForge.SFN_Vector1,id:8849,x:39074,y:32587,varname:node_8849,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:2919,x:39060,y:32719,varname:node_2919,prsc:2,v1:0;n:type:ShaderForge.SFN_OneMinus,id:7565,x:37500,y:32931,varname:node_7565,prsc:2|IN-5008-OUT;n:type:ShaderForge.SFN_Multiply,id:2461,x:37968,y:32852,varname:node_2461,prsc:2|A-6876-RGB,B-7565-OUT,C-6524-OUT;n:type:ShaderForge.SFN_Fresnel,id:7708,x:37879,y:33120,varname:node_7708,prsc:2|NRM-9063-OUT,EXP-3410-OUT;n:type:ShaderForge.SFN_Get,id:9063,x:37661,y:33141,varname:node_9063,prsc:2|IN-4833-OUT;n:type:ShaderForge.SFN_Set,id:4833,x:34126,y:32255,varname:normals,prsc:2|IN-4646-OUT;n:type:ShaderForge.SFN_RemapRange,id:6524,x:38105,y:33134,varname:node_6524,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:1|IN-7708-OUT;n:type:ShaderForge.SFN_Get,id:4851,x:35139,y:31262,varname:node_4851,prsc:2|IN-4833-OUT;n:type:ShaderForge.SFN_Multiply,id:7084,x:36550,y:31132,varname:Mask,prsc:2|A-2155-OUT,B-8818-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4530,x:35399,y:31761,varname:localPos,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-4605-XYZ;n:type:ShaderForge.SFN_Append,id:8454,x:35673,y:31676,varname:node_8454,prsc:2|A-4530-G,B-4530-B;n:type:ShaderForge.SFN_Append,id:8047,x:35673,y:31793,varname:node_8047,prsc:2|A-4530-B,B-4530-R;n:type:ShaderForge.SFN_Append,id:4859,x:35673,y:31914,varname:node_4859,prsc:2|A-4530-R,B-4530-G;n:type:ShaderForge.SFN_Tex2dAsset,id:9158,x:36925,y:32582,ptovrint:False,ptlb:HeightMap,ptin:_HeightMap,varname:_HeightMap,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:49adedbcd11ea474d82c51a5885fcbd6,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:9119,x:38765,y:32049,varname:_node_9119,prsc:2,tex:49adedbcd11ea474d82c51a5885fcbd6,ntxv:0,isnm:False|UVIN-6078-OUT,TEX-9158-TEX;n:type:ShaderForge.SFN_Tex2d,id:5838,x:38738,y:32017,varname:_node_4033,prsc:2,tex:49adedbcd11ea474d82c51a5885fcbd6,ntxv:0,isnm:False|UVIN-8168-OUT,TEX-9158-TEX;n:type:ShaderForge.SFN_Tex2d,id:5563,x:38718,y:31861,varname:_node_4032,prsc:2,tex:49adedbcd11ea474d82c51a5885fcbd6,ntxv:0,isnm:False|UVIN-3185-OUT,TEX-9158-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:5138,x:39102,y:32260,varname:node_5138,prsc:2,chbt:0|M-7084-OUT,R-5563-R,G-5838-R,B-9119-R;n:type:ShaderForge.SFN_Panner,id:6808,x:36736,y:31414,varname:node_6808,prsc:2,spu:1,spv:1|UVIN-2737-UVOUT,DIST-4526-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5056,x:36076,y:31477,ptovrint:False,ptlb:RandomSeed,ptin:_RandomSeed,varname:_RandomSeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:699;n:type:ShaderForge.SFN_Set,id:2977,x:36247,y:31442,varname:randomSeed,prsc:2|IN-5056-OUT;n:type:ShaderForge.SFN_Get,id:4526,x:36247,y:31661,varname:yzSeed,prsc:2|IN-2977-OUT;n:type:ShaderForge.SFN_Rotator,id:2737,x:36501,y:31528,varname:yz2,prsc:2|UVIN-9780-OUT,ANG-4526-OUT;n:type:ShaderForge.SFN_Panner,id:6621,x:36736,y:31572,varname:node_6621,prsc:2,spu:0,spv:1|UVIN-7128-UVOUT,DIST-7942-OUT;n:type:ShaderForge.SFN_Rotator,id:7128,x:36522,y:31732,varname:zx2,prsc:2|UVIN-3544-OUT,ANG-7942-OUT;n:type:ShaderForge.SFN_Get,id:3177,x:36199,y:31814,varname:node_3177,prsc:2|IN-2977-OUT;n:type:ShaderForge.SFN_Add,id:7942,x:36354,y:31869,varname:zxSeed,prsc:2|A-3177-OUT,B-5716-OUT;n:type:ShaderForge.SFN_Vector1,id:5716,x:36199,y:31885,varname:node_5716,prsc:2,v1:50;n:type:ShaderForge.SFN_Panner,id:7455,x:36900,y:31848,varname:node_7455,prsc:2,spu:0,spv:1|UVIN-9102-UVOUT,DIST-2723-OUT;n:type:ShaderForge.SFN_Rotator,id:9102,x:36691,y:31977,varname:xy2,prsc:2|UVIN-1534-OUT,ANG-2723-OUT;n:type:ShaderForge.SFN_Get,id:2563,x:36178,y:32018,varname:node_2563,prsc:2|IN-2977-OUT;n:type:ShaderForge.SFN_Add,id:2723,x:36354,y:32121,varname:xySeed,prsc:2|A-2563-OUT,B-5040-OUT;n:type:ShaderForge.SFN_Vector1,id:5040,x:36178,y:32100,varname:node_5040,prsc:2,v1:100;n:type:ShaderForge.SFN_Slider,id:239,x:36370,y:31412,ptovrint:False,ptlb:Size,ptin:_Size,varname:_Size,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.0679612,max:1;n:type:ShaderForge.SFN_Multiply,id:3185,x:37124,y:31035,varname:node_3185,prsc:2|A-1511-OUT,B-6808-UVOUT;n:type:ShaderForge.SFN_Multiply,id:8168,x:37083,y:31195,varname:node_8168,prsc:2|A-1511-OUT,B-6621-UVOUT;n:type:ShaderForge.SFN_Multiply,id:6078,x:37070,y:31379,varname:node_6078,prsc:2|A-1511-OUT,B-7455-UVOUT;n:type:ShaderForge.SFN_RemapRange,id:1511,x:36778,y:31203,varname:sizeRemap,prsc:2,frmn:0,frmx:1,tomn:0.2,tomx:6|IN-239-OUT;n:type:ShaderForge.SFN_Color,id:6876,x:37711,y:32724,ptovrint:False,ptlb:AtmosphereColor,ptin:_AtmosphereColor,varname:_AtmosphereColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.2965517,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:6115,x:38447,y:32938,varname:node_6115,prsc:2|A-6876-RGB,B-7708-OUT,C-9968-OUT,D-9473-OUT;n:type:ShaderForge.SFN_Vector1,id:9968,x:38371,y:33100,varname:node_9968,prsc:2,v1:3;n:type:ShaderForge.SFN_Dot,id:6091,x:37940,y:33523,varname:node_6091,prsc:2,dt:0|A-2186-OUT,B-7355-OUT;n:type:ShaderForge.SFN_Get,id:9828,x:37711,y:33663,varname:node_9828,prsc:2|IN-4833-OUT;n:type:ShaderForge.SFN_Multiply,id:1298,x:42506,y:32551,varname:node_1298,prsc:2|A-4452-OUT,B-1543-OUT;n:type:ShaderForge.SFN_Multiply,id:1543,x:38218,y:33574,varname:node_1543,prsc:2|A-3775-OUT,B-14-OUT;n:type:ShaderForge.SFN_Vector1,id:14,x:38046,y:33718,varname:node_14,prsc:2,v1:2;n:type:ShaderForge.SFN_FragmentPosition,id:7561,x:34911,y:31871,varname:node_7561,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:6572,x:34896,y:32132,varname:node_6572,prsc:2;n:type:ShaderForge.SFN_Subtract,id:1433,x:35144,y:31932,varname:node_1433,prsc:2|A-7561-XYZ,B-6572-XYZ;n:type:ShaderForge.SFN_Transform,id:4605,x:35315,y:31932,varname:node_4605,prsc:2,tffrom:0,tfto:1|IN-1433-OUT;n:type:ShaderForge.SFN_Transform,id:4778,x:35341,y:31240,varname:lNormals,prsc:2,tffrom:0,tfto:1|IN-4851-OUT;n:type:ShaderForge.SFN_Vector1,id:8514,x:38812,y:32621,varname:node_8514,prsc:2,v1:0;n:type:ShaderForge.SFN_Tex2dAsset,id:1004,x:38169,y:31026,ptovrint:False,ptlb:Clouds,ptin:_Clouds,varname:_Clouds,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:877a709325ffbb340a453962d119c2ca,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:5478,x:38410,y:31163,varname:node_5478,prsc:0,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False|UVIN-9685-OUT,TEX-1004-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:5602,x:38744,y:31586,varname:node_5602,prsc:2,chbt:0|M-8459-OUT,R-9000-R,G-3150-R,B-5478-R;n:type:ShaderForge.SFN_Panner,id:9503,x:37644,y:31374,varname:node_9503,prsc:2,spu:0.015,spv:0|UVIN-6078-OUT,DIST-618-OUT;n:type:ShaderForge.SFN_Panner,id:3813,x:37339,y:31237,varname:node_3813,prsc:0,spu:0.015,spv:0|UVIN-8168-OUT,DIST-618-OUT;n:type:ShaderForge.SFN_Panner,id:7169,x:37881,y:30767,varname:node_7169,prsc:2,spu:0.015,spv:0|UVIN-3185-OUT,DIST-618-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:6082,x:39247,y:31722,varname:node_6082,prsc:2|IN-5152-OUT,IMIN-3161-OUT,IMAX-3881-OUT,OMIN-4640-OUT,OMAX-8834-OUT;n:type:ShaderForge.SFN_Slider,id:6928,x:40139,y:32087,ptovrint:False,ptlb:Atmosphere,ptin:_Atmosphere,varname:_Atmosphere,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Vector1,id:3881,x:39040,y:31911,varname:node_3881,prsc:0,v1:1;n:type:ShaderForge.SFN_Vector1,id:4640,x:39007,y:31999,varname:node_4640,prsc:0,v1:-0.1;n:type:ShaderForge.SFN_Vector1,id:8834,x:39077,y:32123,varname:node_8834,prsc:0,v1:1;n:type:ShaderForge.SFN_OneMinus,id:3161,x:38995,y:31687,varname:node_3161,prsc:0|IN-3298-OUT;n:type:ShaderForge.SFN_Set,id:7712,x:40566,y:32048,varname:atmosphere,prsc:2|IN-6928-OUT;n:type:ShaderForge.SFN_Get,id:9473,x:38371,y:33204,varname:node_9473,prsc:2|IN-7712-OUT;n:type:ShaderForge.SFN_Color,id:5733,x:39402,y:31514,ptovrint:False,ptlb:CloudsColor,ptin:_CloudsColor,varname:_CloudsColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:5013,x:37846,y:33009,varname:node_5013,prsc:2|A-7565-OUT,B-6663-OUT;n:type:ShaderForge.SFN_RemapRange,id:9732,x:37279,y:33098,varname:node_9732,prsc:2,frmn:-0.2,frmx:1,tomn:0,tomx:1|IN-4992-OUT;n:type:ShaderForge.SFN_Clamp01,id:6663,x:37457,y:33074,varname:node_6663,prsc:2|IN-9732-OUT;n:type:ShaderForge.SFN_Add,id:993,x:38237,y:32828,varname:node_993,prsc:2|A-4109-OUT,B-2461-OUT;n:type:ShaderForge.SFN_Clamp01,id:4109,x:38094,y:32954,varname:node_4109,prsc:2|IN-5013-OUT;n:type:ShaderForge.SFN_Get,id:5973,x:38804,y:33246,varname:node_5973,prsc:2|IN-4833-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:6169,x:39787,y:33435,varname:node_6169,prsc:2|IN-1904-OUT,IMIN-5101-OUT,IMAX-5762-OUT,OMIN-4758-OUT,OMAX-3955-OUT;n:type:ShaderForge.SFN_ComponentMask,id:449,x:39213,y:33286,varname:node_449,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-9599-OUT;n:type:ShaderForge.SFN_Vector1,id:5762,x:39188,y:33425,varname:node_5762,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:5425,x:39255,y:34253,ptovrint:False,ptlb:Temperature,ptin:_Temperature,varname:_Temperature,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1262136,max:1;n:type:ShaderForge.SFN_Vector1,id:3955,x:39367,y:33702,varname:node_3955,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:4758,x:39354,y:33571,varname:node_4758,prsc:2,v1:0;n:type:ShaderForge.SFN_Negate,id:9292,x:39344,y:33130,varname:node_9292,prsc:2|IN-449-OUT;n:type:ShaderForge.SFN_Clamp01,id:2766,x:39561,y:33140,varname:node_2766,prsc:2|IN-9292-OUT;n:type:ShaderForge.SFN_Clamp01,id:1716,x:39410,y:33286,varname:node_1716,prsc:2|IN-449-OUT;n:type:ShaderForge.SFN_Add,id:1904,x:39664,y:33260,varname:node_1904,prsc:2|A-2766-OUT,B-1716-OUT;n:type:ShaderForge.SFN_Multiply,id:8283,x:39972,y:33671,varname:node_8283,prsc:2|A-1953-OUT,B-1595-OUT;n:type:ShaderForge.SFN_Set,id:8306,x:37644,y:32212,varname:height,prsc:2|IN-9755-OUT;n:type:ShaderForge.SFN_Get,id:1595,x:39730,y:33725,varname:node_1595,prsc:2|IN-8306-OUT;n:type:ShaderForge.SFN_Add,id:3001,x:40333,y:33532,varname:node_3001,prsc:2|A-6169-OUT,B-8283-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1953,x:39638,y:33571,varname:node_1953,prsc:2|IN-1904-OUT,IMIN-5271-OUT,IMAX-5101-OUT,OMIN-4758-OUT,OMAX-3955-OUT;n:type:ShaderForge.SFN_Subtract,id:5271,x:39216,y:33618,varname:node_5271,prsc:2|A-5101-OUT,B-2625-OUT;n:type:ShaderForge.SFN_Vector1,id:2625,x:38994,y:33687,varname:node_2625,prsc:2,v1:0.8;n:type:ShaderForge.SFN_Clamp01,id:6133,x:40846,y:33441,varname:node_6133,prsc:2|IN-9277-OUT;n:type:ShaderForge.SFN_RemapRange,id:5101,x:38964,y:33517,varname:node_5101,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-6585-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:9277,x:40586,y:33614,varname:node_9277,prsc:2|IN-3001-OUT,IMIN-6585-OUT,IMAX-2232-OUT,OMIN-1562-OUT,OMAX-5964-OUT;n:type:ShaderForge.SFN_Vector1,id:1562,x:40333,y:33813,varname:node_1562,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:5964,x:40333,y:33866,varname:node_5964,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:2232,x:40333,y:33747,varname:node_2232,prsc:2,v1:1;n:type:ShaderForge.SFN_Sqrt,id:6585,x:38720,y:33698,varname:node_6585,prsc:2|IN-6080-OUT;n:type:ShaderForge.SFN_Set,id:759,x:37772,y:33329,varname:Water,prsc:2|IN-7565-OUT;n:type:ShaderForge.SFN_Multiply,id:4281,x:40375,y:33212,varname:node_4281,prsc:2|A-4882-OUT,B-7108-OUT;n:type:ShaderForge.SFN_Vector1,id:4882,x:40146,y:33172,varname:node_4882,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Get,id:7920,x:40125,y:33006,varname:node_7920,prsc:2|IN-759-OUT;n:type:ShaderForge.SFN_Multiply,id:4822,x:40485,y:32990,varname:node_4822,prsc:2|A-7920-OUT,B-2806-OUT;n:type:ShaderForge.SFN_OneMinus,id:2806,x:40846,y:33128,varname:node_2806,prsc:2|IN-7108-OUT;n:type:ShaderForge.SFN_Max,id:9538,x:40769,y:32947,varname:node_9538,prsc:2|A-4281-OUT,B-4822-OUT;n:type:ShaderForge.SFN_Get,id:7590,x:40866,y:33621,varname:node_7590,prsc:2|IN-8306-OUT;n:type:ShaderForge.SFN_Multiply,id:3756,x:41363,y:33289,varname:node_3756,prsc:2|A-7108-OUT,B-8161-OUT;n:type:ShaderForge.SFN_Set,id:5745,x:37908,y:32662,varname:atmosphereColor,prsc:2|IN-6876-RGB;n:type:ShaderForge.SFN_RemapRange,id:2511,x:41032,y:33661,varname:node_2511,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:1|IN-7590-OUT;n:type:ShaderForge.SFN_Clamp01,id:8161,x:41139,y:33484,varname:node_8161,prsc:2|IN-2511-OUT;n:type:ShaderForge.SFN_OneMinus,id:3826,x:41484,y:33527,varname:node_3826,prsc:2|IN-676-OUT;n:type:ShaderForge.SFN_Get,id:1283,x:41505,y:33648,varname:node_1283,prsc:2|IN-5745-OUT;n:type:ShaderForge.SFN_Multiply,id:440,x:39949,y:33534,varname:node_440,prsc:2|A-3826-OUT,B-1283-OUT,C-6133-OUT,D-4967-OUT;n:type:ShaderForge.SFN_Add,id:718,x:41923,y:33438,varname:node_718,prsc:2|A-676-OUT,B-440-OUT;n:type:ShaderForge.SFN_Clamp01,id:5142,x:42070,y:33382,varname:node_5142,prsc:2|IN-718-OUT;n:type:ShaderForge.SFN_Set,id:833,x:38678,y:32739,varname:base,prsc:2|IN-3239-OUT;n:type:ShaderForge.SFN_Get,id:2212,x:41102,y:33021,varname:node_2212,prsc:2|IN-833-OUT;n:type:ShaderForge.SFN_Multiply,id:8639,x:39637,y:31636,varname:node_8639,prsc:2|A-5733-RGB,B-6746-OUT;n:type:ShaderForge.SFN_Multiply,id:4601,x:42016,y:33213,varname:node_4601,prsc:2|A-6133-OUT,B-5142-OUT;n:type:ShaderForge.SFN_Lerp,id:5369,x:45050,y:31840,varname:node_5369,prsc:2|A-5912-OUT,B-4601-OUT,T-7108-OUT;n:type:ShaderForge.SFN_Lerp,id:9235,x:42479,y:32951,varname:node_9235,prsc:2|A-5369-OUT,B-8639-OUT,T-6746-OUT;n:type:ShaderForge.SFN_Clamp01,id:6746,x:39445,y:31767,varname:node_6746,prsc:2|IN-6082-OUT;n:type:ShaderForge.SFN_Set,id:4309,x:39941,y:32497,varname:heightNorm,prsc:2|IN-9431-OUT;n:type:ShaderForge.SFN_Get,id:2551,x:41478,y:32392,varname:node_2551,prsc:2|IN-4309-OUT;n:type:ShaderForge.SFN_Color,id:5225,x:41567,y:32137,ptovrint:False,ptlb:Shores,ptin:_Shores,varname:_Shores,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7941176,c2:0.7388676,c3:0.5080017,c4:1;n:type:ShaderForge.SFN_Color,id:8863,x:41567,y:31995,ptovrint:False,ptlb:Planes,ptin:_Planes,varname:_Planes,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.4617483,c2:0.5367647,c3:0.118404,c4:1;n:type:ShaderForge.SFN_Color,id:5100,x:41577,y:31769,ptovrint:False,ptlb:Mountains,ptin:_Mountains,varname:_Mountains,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Set,id:2473,x:42562,y:31903,varname:heightColor,prsc:2|IN-9547-OUT;n:type:ShaderForge.SFN_Get,id:8335,x:38442,y:32522,varname:node_8335,prsc:2|IN-2473-OUT;n:type:ShaderForge.SFN_Clamp01,id:1940,x:38673,y:32320,varname:node_1940,prsc:2|IN-8335-OUT;n:type:ShaderForge.SFN_Lerp,id:8044,x:41900,y:32093,varname:node_8044,prsc:2|A-5225-RGB,B-8863-RGB,T-6247-OUT;n:type:ShaderForge.SFN_Lerp,id:7606,x:42045,y:31949,varname:node_7606,prsc:2|A-8863-RGB,B-5100-RGB,T-3016-OUT;n:type:ShaderForge.SFN_Lerp,id:9547,x:42304,y:32031,varname:node_9547,prsc:2|A-8044-OUT,B-7606-OUT,T-2551-OUT;n:type:ShaderForge.SFN_Lerp,id:4475,x:38851,y:32494,varname:node_4475,prsc:2|A-1940-OUT,B-993-OUT,T-7565-OUT;n:type:ShaderForge.SFN_RemapRange,id:2150,x:41810,y:32237,varname:node_2150,prsc:2,frmn:0,frmx:0.3,tomn:0,tomx:1|IN-2551-OUT;n:type:ShaderForge.SFN_Clamp01,id:6247,x:41988,y:32227,varname:node_6247,prsc:2|IN-2150-OUT;n:type:ShaderForge.SFN_Clamp01,id:3016,x:41988,y:32385,varname:node_3016,prsc:2|IN-6935-OUT;n:type:ShaderForge.SFN_RemapRange,id:6935,x:41810,y:32395,varname:node_6935,prsc:2,frmn:0.3,frmx:1,tomn:0,tomx:1|IN-2551-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:9018,x:35391,y:30585,ptovrint:False,ptlb:City,ptin:_City,varname:_City,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a7e1c9f4b6d143b41bc99d303d55d1dd,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4485,x:35699,y:29966,varname:node_4485,prsc:2,tex:a7e1c9f4b6d143b41bc99d303d55d1dd,ntxv:0,isnm:False|UVIN-3185-OUT,TEX-9018-TEX;n:type:ShaderForge.SFN_Tex2d,id:3302,x:35703,y:30171,varname:node_3302,prsc:2,tex:a7e1c9f4b6d143b41bc99d303d55d1dd,ntxv:0,isnm:False|UVIN-8168-OUT,TEX-9018-TEX;n:type:ShaderForge.SFN_Tex2d,id:1275,x:35755,y:30378,varname:node_1275,prsc:2,tex:a7e1c9f4b6d143b41bc99d303d55d1dd,ntxv:0,isnm:False|UVIN-6078-OUT,TEX-9018-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:9987,x:36073,y:30276,varname:node_9987,prsc:2,chbt:0|M-7084-OUT,R-4485-R,G-3302-R,B-1275-R;n:type:ShaderForge.SFN_Set,id:8967,x:38402,y:33830,varname:lightSide,prsc:2|IN-3775-OUT;n:type:ShaderForge.SFN_Get,id:9259,x:35933,y:30526,varname:node_9259,prsc:2|IN-8967-OUT;n:type:ShaderForge.SFN_OneMinus,id:3619,x:36272,y:30434,varname:node_3619,prsc:2|IN-9259-OUT;n:type:ShaderForge.SFN_Multiply,id:4862,x:36692,y:30366,varname:node_4862,prsc:2|A-841-OUT,B-2208-OUT;n:type:ShaderForge.SFN_Multiply,id:9536,x:37042,y:30370,varname:node_9536,prsc:2|A-4151-RGB,B-4862-OUT,C-1362-OUT,D-9327-OUT,E-5649-OUT;n:type:ShaderForge.SFN_Color,id:4151,x:36827,y:30139,ptovrint:False,ptlb:CityColor,ptin:_CityColor,varname:_CityColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.8600406,c3:0.4926471,c4:1;n:type:ShaderForge.SFN_Vector1,id:1362,x:36840,y:30435,varname:node_1362,prsc:2,v1:3;n:type:ShaderForge.SFN_Set,id:566,x:37327,y:30397,varname:ciyties,prsc:2|IN-9536-OUT;n:type:ShaderForge.SFN_Negate,id:6836,x:36110,y:30580,varname:node_6836,prsc:2|IN-9259-OUT;n:type:ShaderForge.SFN_Get,id:6562,x:42671,y:32587,varname:node_6562,prsc:2|IN-566-OUT;n:type:ShaderForge.SFN_Clamp01,id:2208,x:36369,y:30549,varname:node_2208,prsc:2|IN-6836-OUT;n:type:ShaderForge.SFN_Get,id:4247,x:36616,y:30569,varname:node_4247,prsc:2|IN-4309-OUT;n:type:ShaderForge.SFN_OneMinus,id:6741,x:36807,y:30589,varname:node_6741,prsc:2|IN-4247-OUT;n:type:ShaderForge.SFN_Get,id:9074,x:36639,y:30722,varname:node_9074,prsc:2|IN-759-OUT;n:type:ShaderForge.SFN_OneMinus,id:3058,x:36811,y:30708,varname:node_3058,prsc:2|IN-9074-OUT;n:type:ShaderForge.SFN_Multiply,id:8768,x:36964,y:30632,varname:node_8768,prsc:2|A-6741-OUT,B-3058-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:4727,x:37484,y:30638,varname:node_4727,prsc:2|IN-8768-OUT,IMIN-7772-OUT,IMAX-3030-OUT,OMIN-5184-OUT,OMAX-3030-OUT;n:type:ShaderForge.SFN_Slider,id:730,x:36885,y:30802,ptovrint:False,ptlb:Population,ptin:_Population,varname:_Population,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Vector1,id:3030,x:37229,y:30882,varname:node_3030,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:5184,x:37363,y:30874,varname:node_5184,prsc:2,v1:0;n:type:ShaderForge.SFN_Clamp01,id:9327,x:37639,y:30556,varname:node_9327,prsc:2|IN-4727-OUT;n:type:ShaderForge.SFN_OneMinus,id:7772,x:37197,y:30661,varname:node_7772,prsc:2|IN-5236-OUT;n:type:ShaderForge.SFN_Max,id:8939,x:42719,y:32823,varname:node_8939,prsc:2|A-6562-OUT,B-1298-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:7840,x:35408,y:29464,ptovrint:False,ptlb:Vegetation,ptin:_Vegetation,varname:_Vegetation,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:4e9fe0344fcb96048a8a4ff6e3100d71,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:8314,x:35709,y:29259,varname:node_8314,prsc:2,tex:4e9fe0344fcb96048a8a4ff6e3100d71,ntxv:0,isnm:False|UVIN-9932-UVOUT,TEX-7840-TEX;n:type:ShaderForge.SFN_Tex2d,id:7232,x:35731,y:28967,varname:node_7232,prsc:2,tex:4e9fe0344fcb96048a8a4ff6e3100d71,ntxv:0,isnm:False|UVIN-4679-UVOUT,TEX-7840-TEX;n:type:ShaderForge.SFN_Tex2d,id:1022,x:35740,y:28675,varname:node_1022,prsc:2,tex:4e9fe0344fcb96048a8a4ff6e3100d71,ntxv:0,isnm:False|UVIN-6131-UVOUT,TEX-7840-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:2583,x:36073,y:28986,varname:node_2583,prsc:2,chbt:0|M-7084-OUT,R-1022-R,G-7232-R,B-8314-R;n:type:ShaderForge.SFN_Panner,id:6131,x:37423,y:31537,varname:node_6131,prsc:2,spu:5,spv:0|UVIN-3185-OUT,DIST-1869-OUT;n:type:ShaderForge.SFN_Get,id:1869,x:34318,y:31354,varname:node_1869,prsc:2|IN-2977-OUT;n:type:ShaderForge.SFN_Panner,id:4679,x:37423,y:31726,varname:node_4679,prsc:2,spu:5,spv:0|UVIN-8168-OUT,DIST-1869-OUT;n:type:ShaderForge.SFN_Panner,id:9932,x:37465,y:31907,varname:node_9932,prsc:2,spu:5,spv:0|UVIN-6078-OUT,DIST-1869-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1343,x:36755,y:29157,varname:node_1343,prsc:2|IN-2583-OUT,IMIN-7583-OUT,IMAX-5296-OUT,OMIN-7807-OUT,OMAX-4043-OUT;n:type:ShaderForge.SFN_Slider,id:4462,x:35847,y:29517,ptovrint:False,ptlb:Fertility,ptin:_Fertility,varname:_Fertility,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6796116,max:1;n:type:ShaderForge.SFN_Vector1,id:7807,x:36412,y:29311,varname:node_7807,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:4043,x:36412,y:29439,varname:node_4043,prsc:2,v1:1;n:type:ShaderForge.SFN_Get,id:8476,x:36446,y:29555,varname:node_8476,prsc:2|IN-4309-OUT;n:type:ShaderForge.SFN_RemapRange,id:9061,x:36740,y:29427,varname:node_9061,prsc:2,frmn:0.2,frmx:1,tomn:0,tomx:1|IN-8476-OUT;n:type:ShaderForge.SFN_Subtract,id:2279,x:36768,y:29627,varname:node_2279,prsc:2|A-5723-OUT,B-7057-OUT;n:type:ShaderForge.SFN_Clamp01,id:7057,x:36928,y:29423,varname:node_7057,prsc:2|IN-9061-OUT;n:type:ShaderForge.SFN_Clamp01,id:5933,x:36972,y:29627,varname:node_5933,prsc:2|IN-2279-OUT;n:type:ShaderForge.SFN_RemapRange,id:9426,x:36547,y:29690,varname:node_9426,prsc:2,frmn:0,frmx:0.2,tomn:0,tomx:1|IN-8476-OUT;n:type:ShaderForge.SFN_Clamp01,id:5723,x:36692,y:29748,varname:node_5723,prsc:2|IN-9426-OUT;n:type:ShaderForge.SFN_Multiply,id:9444,x:37221,y:29288,varname:node_9444,prsc:2|A-711-OUT,B-5933-OUT;n:type:ShaderForge.SFN_Set,id:8881,x:37789,y:29294,varname:vegetation,prsc:2|IN-19-OUT;n:type:ShaderForge.SFN_Color,id:7392,x:42463,y:33148,ptovrint:False,ptlb:VegetationColor,ptin:_VegetationColor,varname:_VegetationColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.383,c3:0.03433783,c4:1;n:type:ShaderForge.SFN_Lerp,id:5912,x:42256,y:33264,varname:node_5912,prsc:2|A-2212-OUT,B-7392-RGB,T-9809-OUT;n:type:ShaderForge.SFN_Get,id:9809,x:42390,y:33507,varname:node_9809,prsc:2|IN-8881-OUT;n:type:ShaderForge.SFN_Clamp01,id:3077,x:37326,y:29362,varname:node_3077,prsc:2|IN-9444-OUT;n:type:ShaderForge.SFN_RemapRange,id:3299,x:36120,y:29193,varname:node_3299,prsc:2,frmn:0.4,frmx:0.6,tomn:0,tomx:1|IN-2583-OUT;n:type:ShaderForge.SFN_Clamp01,id:7362,x:36297,y:29155,varname:node_7362,prsc:2|IN-3299-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:388,x:36547,y:29963,varname:node_388,prsc:2|IN-6382-OUT,IMIN-7772-OUT,IMAX-726-OUT,OMIN-3159-OUT,OMAX-726-OUT;n:type:ShaderForge.SFN_Vector1,id:3159,x:36276,y:29850,varname:node_3159,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:726,x:36212,y:30145,varname:node_726,prsc:2,v1:1;n:type:ShaderForge.SFN_Get,id:6382,x:36085,y:30087,varname:node_6382,prsc:2|IN-8881-OUT;n:type:ShaderForge.SFN_Lerp,id:9736,x:36421,y:30179,varname:node_9736,prsc:2|A-6382-OUT,B-9987-OUT,T-5236-OUT;n:type:ShaderForge.SFN_Clamp01,id:2359,x:36642,y:30179,varname:node_2359,prsc:2|IN-9736-OUT;n:type:ShaderForge.SFN_Multiply,id:841,x:36523,y:30349,varname:node_841,prsc:2|A-2359-OUT,B-9987-OUT;n:type:ShaderForge.SFN_RemapRange,id:5236,x:37029,y:30846,varname:node_5236,prsc:2,frmn:0,frmx:1.25,tomn:0,tomx:1|IN-730-OUT;n:type:ShaderForge.SFN_Vector1,id:5296,x:36446,y:29189,varname:node_5296,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:711,x:37006,y:29086,varname:node_711,prsc:2|IN-2013-OUT;n:type:ShaderForge.SFN_OneMinus,id:7583,x:36263,y:29555,varname:node_7583,prsc:2|IN-7761-OUT;n:type:ShaderForge.SFN_RemapRange,id:2013,x:36933,y:29252,varname:node_2013,prsc:2,frmn:0,frmx:0.2,tomn:0,tomx:1|IN-1343-OUT;n:type:ShaderForge.SFN_RemapRange,id:6578,x:40533,y:33829,varname:node_6578,prsc:2,frmn:-1,frmx:2,tomn:0,tomx:1|IN-3001-OUT;n:type:ShaderForge.SFN_Set,id:2976,x:40806,y:33869,varname:tempGradient,prsc:2|IN-1610-OUT;n:type:ShaderForge.SFN_Get,id:21,x:37354,y:29570,varname:node_21,prsc:2|IN-2976-OUT;n:type:ShaderForge.SFN_Clamp01,id:1726,x:40700,y:34063,varname:node_1726,prsc:2|IN-6578-OUT;n:type:ShaderForge.SFN_OneMinus,id:5794,x:37580,y:29588,varname:node_5794,prsc:2|IN-21-OUT;n:type:ShaderForge.SFN_Multiply,id:19,x:37736,y:29440,varname:node_19,prsc:2|A-3077-OUT,B-6173-OUT,C-5376-OUT;n:type:ShaderForge.SFN_Multiply,id:84,x:38892,y:33952,varname:node_84,prsc:2|A-5425-OUT,B-3609-OUT;n:type:ShaderForge.SFN_Vector1,id:3609,x:38739,y:34217,varname:node_3609,prsc:2,v1:2;n:type:ShaderForge.SFN_Clamp01,id:6080,x:39183,y:33889,varname:node_6080,prsc:2|IN-84-OUT;n:type:ShaderForge.SFN_Clamp01,id:6173,x:37816,y:29613,varname:node_6173,prsc:2|IN-5794-OUT;n:type:ShaderForge.SFN_Clamp01,id:7608,x:39979,y:33300,varname:node_7608,prsc:2|IN-1904-OUT;n:type:ShaderForge.SFN_OneMinus,id:8254,x:40119,y:33355,varname:node_8254,prsc:2|IN-7608-OUT;n:type:ShaderForge.SFN_RemapRange,id:6425,x:39730,y:34293,varname:node_6425,prsc:2,frmn:0.3,frmx:1,tomn:1.1,tomx:-0.1|IN-5425-OUT;n:type:ShaderForge.SFN_Add,id:1610,x:40908,y:34202,varname:node_1610,prsc:2|A-1726-OUT,B-6273-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:3529,x:40398,y:34186,varname:node_3529,prsc:2|IN-9899-OUT,IMIN-6425-OUT,IMAX-6005-OUT,OMIN-6213-OUT,OMAX-896-OUT;n:type:ShaderForge.SFN_Vector1,id:896,x:40169,y:34639,varname:node_896,prsc:2,v1:1.3;n:type:ShaderForge.SFN_Get,id:3505,x:42979,y:32148,varname:node_3505,prsc:2|IN-8967-OUT;n:type:ShaderForge.SFN_Clamp01,id:8951,x:43338,y:32014,varname:node_8951,prsc:2|IN-3764-OUT;n:type:ShaderForge.SFN_Append,id:2101,x:44723,y:32546,varname:node_2101,prsc:2|A-9833-OUT,B-7866-OUT;n:type:ShaderForge.SFN_Vector1,id:7866,x:43868,y:32415,varname:node_7866,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:8330,x:44782,y:32739,varname:node_8330,prsc:2,v1:3;n:type:ShaderForge.SFN_RemapRange,id:3764,x:43175,y:32053,varname:node_3764,prsc:2,frmn:-0.5,frmx:0.5,tomn:0,tomx:1|IN-9003-OUT;n:type:ShaderForge.SFN_OneMinus,id:8538,x:43649,y:31939,varname:node_8538,prsc:2|IN-8951-OUT;n:type:ShaderForge.SFN_Multiply,id:9440,x:44073,y:32170,varname:node_9440,prsc:2|A-8951-OUT,B-2623-OUT,C-1993-OUT;n:type:ShaderForge.SFN_Multiply,id:9239,x:45142,y:32709,varname:node_9239,prsc:2|A-2101-OUT,B-8330-OUT,C-375-OUT;n:type:ShaderForge.SFN_Get,id:7707,x:37112,y:30532,varname:node_7707,prsc:2|IN-759-OUT;n:type:ShaderForge.SFN_OneMinus,id:5649,x:37309,y:30461,varname:node_5649,prsc:2|IN-7707-OUT;n:type:ShaderForge.SFN_Get,id:1993,x:43475,y:32336,varname:node_1993,prsc:2|IN-7712-OUT;n:type:ShaderForge.SFN_Vector1,id:3410,x:37700,y:33088,varname:node_3410,prsc:2,v1:5.5;n:type:ShaderForge.SFN_Get,id:1417,x:41258,y:33661,varname:node_1417,prsc:2|IN-8306-OUT;n:type:ShaderForge.SFN_OneMinus,id:9407,x:41405,y:33704,varname:node_9407,prsc:2|IN-8161-OUT;n:type:ShaderForge.SFN_Get,id:3492,x:41250,y:33891,varname:node_3492,prsc:2|IN-7712-OUT;n:type:ShaderForge.SFN_Clamp01,id:676,x:41567,y:33322,varname:node_676,prsc:2|IN-3756-OUT;n:type:ShaderForge.SFN_Subtract,id:3134,x:41822,y:33917,varname:node_3134,prsc:2|A-8296-OUT,B-8027-OUT;n:type:ShaderForge.SFN_Clamp01,id:10,x:42038,y:33896,varname:node_10,prsc:2|IN-3134-OUT;n:type:ShaderForge.SFN_Add,id:8296,x:41643,y:34022,varname:node_8296,prsc:2|A-9407-OUT,B-2091-OUT;n:type:ShaderForge.SFN_Vector1,id:2091,x:41394,y:34103,varname:node_2091,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:8027,x:41433,y:33919,varname:node_8027,prsc:2|A-3492-OUT,B-269-OUT;n:type:ShaderForge.SFN_Vector1,id:269,x:41344,y:34027,varname:node_269,prsc:2,v1:2;n:type:ShaderForge.SFN_OneMinus,id:4967,x:41980,y:33751,varname:node_4967,prsc:2|IN-10-OUT;n:type:ShaderForge.SFN_Multiply,id:7108,x:41180,y:33155,varname:node_7108,prsc:2|A-6133-OUT,B-4967-OUT;n:type:ShaderForge.SFN_Get,id:6811,x:38290,y:32443,varname:node_6811,prsc:2|IN-7712-OUT;n:type:ShaderForge.SFN_Multiply,id:5108,x:38518,y:32397,varname:node_5108,prsc:2|A-7925-OUT,B-6811-OUT;n:type:ShaderForge.SFN_Vector1,id:7925,x:38261,y:32355,varname:node_7925,prsc:2,v1:2;n:type:ShaderForge.SFN_Clamp01,id:6239,x:38694,y:32484,varname:node_6239,prsc:2|IN-5108-OUT;n:type:ShaderForge.SFN_Multiply,id:2328,x:38960,y:32402,varname:node_2328,prsc:2|A-6239-OUT,B-9361-OUT;n:type:ShaderForge.SFN_Clamp01,id:8677,x:35792,y:29689,varname:node_8677,prsc:2|IN-551-OUT;n:type:ShaderForge.SFN_Multiply,id:551,x:35612,y:29703,varname:node_551,prsc:2|A-6651-OUT,B-45-OUT;n:type:ShaderForge.SFN_Multiply,id:7761,x:35970,y:29720,varname:node_7761,prsc:2|A-8677-OUT,B-4462-OUT;n:type:ShaderForge.SFN_Get,id:45,x:35387,y:29751,varname:node_45,prsc:2|IN-7712-OUT;n:type:ShaderForge.SFN_Vector1,id:6651,x:35358,y:29663,varname:node_6651,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:6545,x:46588,y:32089,varname:node_6545,prsc:2|A-8939-OUT,B-9555-OUT;n:type:ShaderForge.SFN_Vector1,id:9555,x:42876,y:32947,varname:node_9555,prsc:2,v1:2;n:type:ShaderForge.SFN_Set,id:8971,x:36967,y:31329,varname:size,prsc:2|IN-1511-OUT;n:type:ShaderForge.SFN_Multiply,id:9003,x:43440,y:32264,varname:node_9003,prsc:2|A-3505-OUT,B-5674-OUT;n:type:ShaderForge.SFN_Get,id:4653,x:43175,y:32253,varname:node_4653,prsc:2|IN-8971-OUT;n:type:ShaderForge.SFN_RemapRange,id:5674,x:43323,y:32336,varname:node_5674,prsc:2,frmn:0,frmx:1,tomn:1,tomx:1.5|IN-4653-OUT;n:type:ShaderForge.SFN_RemapRange,id:5931,x:37262,y:32705,varname:node_5931,prsc:2,frmn:0,frmx:0.1,tomn:0,tomx:1|IN-4992-OUT;n:type:ShaderForge.SFN_Clamp01,id:5008,x:37500,y:32705,varname:node_5008,prsc:2|IN-5931-OUT;n:type:ShaderForge.SFN_Normalize,id:4646,x:34054,y:32028,varname:node_4646,prsc:2|IN-561-OUT;n:type:ShaderForge.SFN_Get,id:525,x:39717,y:33844,varname:node_525,prsc:2|IN-4309-OUT;n:type:ShaderForge.SFN_Vector1,id:6213,x:40202,y:34340,varname:node_6213,prsc:2,v1:0;n:type:ShaderForge.SFN_OneMinus,id:4747,x:39949,y:33808,varname:node_4747,prsc:2|IN-525-OUT;n:type:ShaderForge.SFN_Multiply,id:9017,x:40294,y:33995,varname:node_9017,prsc:2|A-9899-OUT,B-4747-OUT;n:type:ShaderForge.SFN_Vector1,id:5224,x:39730,y:34505,varname:node_5224,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Add,id:6005,x:39928,y:34417,varname:node_6005,prsc:2|A-6425-OUT,B-5224-OUT;n:type:ShaderForge.SFN_Subtract,id:5679,x:40582,y:34186,varname:node_5679,prsc:2|A-3529-OUT,B-525-OUT;n:type:ShaderForge.SFN_Clamp01,id:6152,x:40733,y:34304,varname:node_6152,prsc:2|IN-5679-OUT;n:type:ShaderForge.SFN_RemapRange,id:3876,x:40908,y:34430,varname:node_3876,prsc:2,frmn:0,frmx:0.5,tomn:0,tomx:1|IN-6152-OUT;n:type:ShaderForge.SFN_Clamp01,id:6273,x:41089,y:34401,varname:node_6273,prsc:2|IN-3876-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4734,x:33433,y:34537,ptovrint:False,ptlb:NormalMap,ptin:_NormalMap,varname:_NormalMap,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:c1ccaee83080bc74c8a9677bcd1ba90c,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:1291,x:33953,y:34682,varname:_node_1291,prsc:2,tex:c1ccaee83080bc74c8a9677bcd1ba90c,ntxv:0,isnm:False|UVIN-6078-OUT,TEX-4734-TEX;n:type:ShaderForge.SFN_Tex2d,id:3569,x:33848,y:34513,varname:_node_3569,prsc:2,tex:c1ccaee83080bc74c8a9677bcd1ba90c,ntxv:0,isnm:False|UVIN-8168-OUT,TEX-4734-TEX;n:type:ShaderForge.SFN_Tex2d,id:8302,x:33983,y:34264,varname:_node_8302,prsc:2,tex:c1ccaee83080bc74c8a9677bcd1ba90c,ntxv:0,isnm:False|UVIN-3185-OUT,TEX-4734-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:7131,x:37856,y:34419,varname:node_7131,prsc:2,chbt:0|M-7084-OUT,R-1974-OUT,G-9460-OUT,B-4321-OUT;n:type:ShaderForge.SFN_Get,id:6432,x:38116,y:35312,varname:node_6432,prsc:2|IN-759-OUT;n:type:ShaderForge.SFN_Lerp,id:5586,x:38642,y:34884,varname:node_5586,prsc:2|A-5990-OUT,B-2389-OUT,T-8978-OUT;n:type:ShaderForge.SFN_Lerp,id:8678,x:38968,y:34879,varname:node_8678,prsc:2|A-2389-OUT,B-5586-OUT,T-8260-OUT;n:type:ShaderForge.SFN_Slider,id:8260,x:38887,y:34637,ptovrint:False,ptlb:NormalIntencity,ptin:_NormalIntencity,varname:_NormalIntencity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Code,id:3401,x:31021,y:33614,varname:node_3401,prsc:2,code:CgBmAGwAbwBhAHQAIABuAHgAIAA9ACAATgBvAHIAbQBhAGwALgB4ADsADQAKAGYAbABvAGEAdAAgAG4AeQAgAD0AIABOAG8AcgBtAGEAbAAuAHkAOwANAAoAZgBsAG8AYQB0ACAAbgB6ACAAPQAgAE4AbwByAG0AYQBsAC4AegA7AAoAbgB4AD0AbgB4ACoAMgAtADEAOwAKAG4AeQA9AG4AeQAqADIALQAxADsACgBmAGwAbwBhAHQAIABjAGEAPQBjAG8AcwAoAEEAbgBnAGwAZQApADsACgBmAGwAbwBhAHQAIABzAGEAPQBzAGkAbgAoAEEAbgBnAGwAZQApADsACgBmAGwAbwBhAHQAMwAgAHIATgA9AGYAbABvAGEAdAAzACgAYwBhACoAbgB4AC0AcwBhACoAbgB5ACwAcwBhACoAbgB4ACsAYwBhACoAbgB5ACwAbgB6ACkAOwAKAHIATgAuAHgAPQAoAHIATgAuAHgAKwAxACkALwAyADsACgByAE4ALgB5AD0AKAByAE4ALgB5ACsAMQApAC8AMgA7AAoAcgBlAHQAdQByAG4AIAByAE4AOwAKAAoA,output:2,fname:Rotate,width:812,height:359,input:0,input:2,input_1_label:Angle,input_2_label:Normal;n:type:ShaderForge.SFN_Code,id:6141,x:35105,y:33716,varname:node_6141,prsc:2,code:DQAKAGYAbABvAGEAdAAgAG4AeAAgAD0AIABOAG8AcgBtAGEAbAAuAHgAOwANAAoAZgBsAG8AYQB0ACAAbgB5ACAAPQAgAE4AbwByAG0AYQBsAC4AeQA7AA0ACgBmAGwAbwBhAHQAIABuAHoAIAA9ACAATgBvAHIAbQBhAGwALgB6ADsADQAKAA0ACgBmAGwAbwBhAHQAIABhAD0AQQBuAGcAbABlADsADQAKAAoADQAKAGYAbABvAGEAdAAgAGMAYQA9AGMAbwBzACgAYQApADsADQAKAGYAbABvAGEAdAAgAHMAYQA9AHMAaQBuACgAYQApADsADQAKAGYAbABvAGEAdAAzACAAcgBOAD0AZgBsAG8AYQB0ADMAKABjAGEAKgBuAHgALQBzAGEAKgBuAHkALABzAGEAKgBuAHgAKwBjAGEAKgBuAHkALABuAHoAKQA7AA0ACgAKAGkAZgAoAEMAPAAwACkAewAKAHIATgA9AHIATgAuAHkAeAB6ADsACgByAE4ALgB4AD0AcgBOAC4AeAA7ACAACgByAE4ALgB5AD0AcgBOAC4AeQA7AH0ACgBpAGYAKABDAD4AMAApAHsACgByAE4APQByAE4ALgB5AHgAegA7AAoAcgBOAC4AeAA9AHIATgAuAHgAOwAgAAoAcgBOAC4AeQA9AHIATgAuAHkAOwB9AAoAcgBlAHQAdQByAG4AIAByAE4AOwA=,output:2,fname:Rotate,width:290,height:452,input:2,input:0,input:0,input:0,input_1_label:Normal,input_2_label:Angle,input_3_label:C,input_4_label:G|A-5846-OUT,B-4526-OUT,C-4465-R,D-4465-G;n:type:ShaderForge.SFN_Code,id:7686,x:35058,y:34226,varname:node_7686,prsc:2,code:ZgBsAG8AYQB0ACAAbgB4ACAAPQAgAE4AbwByAG0AYQBsAC4AeAA7AA0ACgBmAGwAbwBhAHQAIABuAHkAIAA9ACAATgBvAHIAbQBhAGwALgB5ADsADQAKAGYAbABvAGEAdAAgAG4AegAgAD0AIABOAG8AcgBtAGEAbAAuAHoAOwANAAoAZgBsAG8AYQB0ACAAYQA9AEEAbgBnAGwAZQA7AA0ACgANAAoAZgBsAG8AYQB0ACAAYwBhAD0AYwBvAHMAKABhACkAOwANAAoAZgBsAG8AYQB0ACAAcwBhAD0AcwBpAG4AKABhACkAOwANAAoAZgBsAG8AYQB0ADMAIAByAE4APQBmAGwAbwBhAHQAMwAoAGMAYQAqAG4AeAAtAHMAYQAqAG4AeQAsAHMAYQAqAG4AeAArAGMAYQAqAG4AeQAsAG4AegApADsADQAKAAoACgByAGUAdAB1AHIAbgAgAHIATgA7AA==,output:2,fname:Rotate2,width:326,height:550,input:2,input:0,input:0,input:0,input:0,input_1_label:Normal,input_2_label:Angle,input_3_label:G,input_4_label:B,input_5_label:R|A-7774-OUT,B-7942-OUT,C-4465-G,D-4465-B,E-4465-R;n:type:ShaderForge.SFN_Code,id:7104,x:35066,y:34891,varname:node_7104,prsc:2,code:ZgBsAG8AYQB0ACAAbgB4ACAAPQAgAE4AbwByAG0AYQBsAC4AeAA7AA0ACgBmAGwAbwBhAHQAIABuAHkAIAA9ACAATgBvAHIAbQBhAGwALgB5ADsADQAKAGYAbABvAGEAdAAgAG4AegAgAD0AIABOAG8AcgBtAGEAbAAuAHoAOwANAAoADQAKAGYAbABvAGEAdAAgAGEAPQBBAG4AZwBsAGUAOwANAAoACgBmAGwAbwBhAHQAIABjAGEAPQBjAG8AcwAoAGEAKQA7AA0ACgBmAGwAbwBhAHQAIABzAGEAPQBzAGkAbgAoAGEAKQA7AA0ACgBmAGwAbwBhAHQAMwAgAHIATgA9AGYAbABvAGEAdAAzACgAYwBhACoAbgB4AC0AcwBhACoAbgB5ACwAcwBhACoAbgB4ACsAYwBhACoAbgB5ACwAbgB6ACkAOwAKAAoACgANAAoAcgBlAHQAdQByAG4AIAByAE4AOwA=,output:2,fname:Rotate3,width:320,height:554,input:2,input:0,input:0,input:0,input_1_label:Normal,input_2_label:Angle,input_3_label:C,input_4_label:G|A-453-OUT,B-2723-OUT,C-4465-B,D-4465-G;n:type:ShaderForge.SFN_ComponentMask,id:5725,x:43591,y:32752,varname:node_5725,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-4778-XYZ;n:type:ShaderForge.SFN_Negate,id:3581,x:43676,y:32441,varname:node_3581,prsc:2|IN-5725-B;n:type:ShaderForge.SFN_ComponentMask,id:4465,x:34316,y:34997,varname:node_4465,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-5554-OUT;n:type:ShaderForge.SFN_Multiply,id:2952,x:35791,y:31235,varname:node_2952,prsc:2|A-9531-OUT,B-9531-OUT,C-9531-OUT,D-9531-OUT;n:type:ShaderForge.SFN_Abs,id:4275,x:43911,y:32735,varname:node_4275,prsc:2|IN-5725-OUT;n:type:ShaderForge.SFN_Min,id:2501,x:44026,y:32638,varname:node_2501,prsc:2|A-3581-OUT,B-5725-G;n:type:ShaderForge.SFN_TexCoord,id:9314,x:42573,y:32136,varname:node_9314,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_LightVector,id:2186,x:37756,y:33443,varname:node_2186,prsc:2;n:type:ShaderForge.SFN_Sign,id:6399,x:34174,y:33770,varname:node_6399,prsc:2|IN-4465-B;n:type:ShaderForge.SFN_Negate,id:6971,x:34418,y:33943,varname:node_6971,prsc:2|IN-6399-OUT;n:type:ShaderForge.SFN_Vector1,id:7400,x:34312,y:33475,varname:node_7400,prsc:2,v1:1;n:type:ShaderForge.SFN_Code,id:1974,x:35792,y:33786,varname:node_1974,prsc:2,code:ZgBsAG8AYQB0ADMAIAB4AE4AbwByAG0AIAA9AG4AbwByAG0AYQBsAGkAegBlACgAaABhAGwAZgAzACgAbgBvAHIAbQAuAHgAeQAgACAAKwAgAG4AbwByAG0ARABpAHIALgB6AHkALAAgAG4AbwByAG0ARABpAHIALgB4ACkAKQA7AA0ACgANAAoAeABOAG8AcgBtAD0AeABOAG8AcgBtAC4AegB5AHgAOwANAAoAcgBlAHQAdQByAG4AIAB4AE4AbwByAG0AOwA=,output:2,fname:normX,width:646,height:135,input:2,input:2,input_1_label:norm,input_2_label:normDir|A-6141-OUT,B-4465-OUT;n:type:ShaderForge.SFN_Code,id:9460,x:35870,y:34100,varname:node_9460,prsc:2,code:ZgBsAG8AYQB0ADMAIAB5AE4AbwByAG0AIAA9ACAAbgBvAHIAbQBhAGwAaQB6AGUAKABoAGEAbABmADMAKABuAG8AcgBtAC4AeAB5ACAAKwAgAG4AbwByAG0ARABpAHIALgB6AHgALAAgAG4AbwByAG0ARABpAHIALgB5ACkAKQA7AA0ACgANAAoAeQBOAG8AcgBtAD0AeQBOAG8AcgBtAC4AeQB6AHgAOwANAAoAcgBlAHQAdQByAG4AIAB5AE4AbwByAG0AOwA=,output:2,fname:normYX,width:646,height:112,input:2,input:2,input_1_label:norm,input_2_label:normDir|A-7686-OUT,B-4465-OUT;n:type:ShaderForge.SFN_Code,id:4321,x:35817,y:34311,varname:node_4321,prsc:2,code:ZgBsAG8AYQB0ADMAIAB6AE4AbwByAG0AIAA9ACAAbgBvAHIAbQBhAGwAaQB6AGUAKABoAGEAbABmADMAKABuAG8AcgBtAC4AeAB5ACAAIAArACAAbgBvAHIAbQBEAGkAcgAuAHgAeQAsACAAbgBvAHIAbQBEAGkAcgAuAHoAKQApADsADQAKAHIAZQB0AHUAcgBuACAAegBOAG8AcgBtADsA,output:2,fname:normXZ,width:646,height:135,input:2,input:0,input:2,input_1_label:norm,input_2_label:sign,input_3_label:normDir|A-7104-OUT,B-6399-OUT,C-4465-OUT;n:type:ShaderForge.SFN_NormalVector,id:2389,x:38315,y:34760,prsc:2,pt:False;n:type:ShaderForge.SFN_NormalVector,id:7132,x:42917,y:32480,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:9531,x:35567,y:31294,varname:normalsMul,prsc:2|A-4778-XYZ,B-3011-OUT;n:type:ShaderForge.SFN_Vector1,id:3011,x:35490,y:31467,varname:node_3011,prsc:2,v1:1.4;n:type:ShaderForge.SFN_Normalize,id:8769,x:35961,y:31223,varname:normalsNorm,prsc:2|IN-2952-OUT;n:type:ShaderForge.SFN_ComponentMask,id:2711,x:35694,y:31009,varname:normalsComp,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-8769-OUT;n:type:ShaderForge.SFN_Add,id:3644,x:36069,y:30985,varname:node_3644,prsc:2|A-2711-R,B-2711-G,C-2711-B;n:type:ShaderForge.SFN_Divide,id:2155,x:36374,y:31006,varname:node_2155,prsc:2|A-8769-OUT,B-3644-OUT;n:type:ShaderForge.SFN_RemapRange,id:9361,x:38499,y:32206,varname:node_9361,prsc:2,frmn:0,frmx:1,tomn:-0.2,tomx:1|IN-6008-OUT;n:type:ShaderForge.SFN_Set,id:6755,x:39869,y:31797,varname:Clouds,prsc:2|IN-6746-OUT;n:type:ShaderForge.SFN_Get,id:104,x:38751,y:35565,varname:node_104,prsc:2|IN-6755-OUT;n:type:ShaderForge.SFN_RemapRange,id:9780,x:35889,y:31583,varname:yz,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-8454-OUT;n:type:ShaderForge.SFN_RemapRange,id:3544,x:35859,y:31810,varname:node_3544,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-8047-OUT;n:type:ShaderForge.SFN_RemapRange,id:1534,x:35859,y:31980,varname:xy,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-4859-OUT;n:type:ShaderForge.SFN_Vector1,id:3327,x:37950,y:31669,varname:node_3327,prsc:2,v1:2E-05;n:type:ShaderForge.SFN_Tex2d,id:3150,x:38410,y:30999,varname:_node_5758,prsc:0,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False|UVIN-3813-UVOUT,TEX-1004-TEX;n:type:ShaderForge.SFN_Tex2d,id:9000,x:38410,y:30811,varname:_node_3403,prsc:0,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False|UVIN-8241-OUT,TEX-1004-TEX;n:type:ShaderForge.SFN_Abs,id:2727,x:38630,y:31253,varname:node_2727,prsc:2|IN-4778-XYZ;n:type:ShaderForge.SFN_Add,id:8688,x:39105,y:31175,varname:node_8688,prsc:2|A-9139-R,B-9139-G,C-9139-B;n:type:ShaderForge.SFN_ComponentMask,id:9139,x:38691,y:30898,varname:node_9139,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-6206-OUT;n:type:ShaderForge.SFN_Divide,id:8459,x:39253,y:31260,varname:node_8459,prsc:2|A-6206-OUT,B-8688-OUT;n:type:ShaderForge.SFN_Transform,id:4514,x:38988,y:33074,varname:node_4514,prsc:2,tffrom:0,tfto:1|IN-5973-OUT;n:type:ShaderForge.SFN_Multiply,id:6206,x:38839,y:31269,varname:node_6206,prsc:2|A-2727-OUT,B-2727-OUT;n:type:ShaderForge.SFN_Slider,id:3114,x:39227,y:32006,ptovrint:False,ptlb:CloudsAmount,ptin:_CloudsAmount,varname:_CloudsAmount,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6257835,max:1;n:type:ShaderForge.SFN_Min,id:3298,x:39658,y:32004,varname:node_3298,prsc:2|A-3114-OUT,B-6928-OUT;n:type:ShaderForge.SFN_Clamp01,id:5152,x:38995,y:31503,varname:node_5152,prsc:2|IN-5602-OUT;n:type:ShaderForge.SFN_Vector1,id:8818,x:36109,y:31360,varname:node_8818,prsc:2,v1:1;n:type:ShaderForge.SFN_Normalize,id:9599,x:39205,y:33074,varname:node_9599,prsc:2|IN-4514-XYZ;n:type:ShaderForge.SFN_Normalize,id:5554,x:33444,y:33739,varname:node_5554,prsc:2|IN-4778-XYZ;n:type:ShaderForge.SFN_Multiply,id:6443,x:44414,y:32766,varname:node_6443,prsc:2|A-9538-OUT,B-8328-OUT,C-3337-OUT,D-1587-OUT;n:type:ShaderForge.SFN_Slider,id:8328,x:42225,y:33862,ptovrint:False,ptlb:Specularity,ptin:_Specularity,varname:_Specularity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Transform,id:7792,x:38352,y:35095,varname:node_7792,prsc:2,tffrom:0,tfto:1|IN-2389-OUT;n:type:ShaderForge.SFN_Normalize,id:2800,x:38693,y:35077,varname:node_2800,prsc:2|IN-7792-XYZ;n:type:ShaderForge.SFN_Transform,id:5062,x:38347,y:34461,varname:node_5062,prsc:2,tffrom:1,tfto:0|IN-7131-OUT;n:type:ShaderForge.SFN_Normalize,id:5990,x:38534,y:34437,varname:node_5990,prsc:2|IN-5062-XYZ;n:type:ShaderForge.SFN_SwitchProperty,id:4452,x:41910,y:32710,ptovrint:False,ptlb:Emission,ptin:_Emission,varname:_Emission,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-1248-OUT,B-6115-OUT;n:type:ShaderForge.SFN_Vector1,id:1248,x:43184,y:33243,varname:node_1248,prsc:2,v1:0;n:type:ShaderForge.SFN_Get,id:5669,x:43395,y:33397,varname:node_5669,prsc:2|IN-6755-OUT;n:type:ShaderForge.SFN_OneMinus,id:3337,x:43568,y:33379,varname:node_3337,prsc:2|IN-5669-OUT;n:type:ShaderForge.SFN_Multiply,id:1112,x:43887,y:33189,varname:node_1112,prsc:2|B-3337-OUT;n:type:ShaderForge.SFN_Time,id:3788,x:36857,y:32132,varname:time,prsc:2;n:type:ShaderForge.SFN_Multiply,id:618,x:37164,y:32098,varname:node_618,prsc:2|A-3788-T,B-6350-OUT,C-6469-OUT;n:type:ShaderForge.SFN_Slider,id:3313,x:37597,y:31265,ptovrint:False,ptlb:CloudsBias,ptin:_CloudsBias,varname:_CloudsBias,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3162396,max:1;n:type:ShaderForge.SFN_Slider,id:6350,x:36825,y:32406,ptovrint:False,ptlb:CloudsSpeed,ptin:_CloudsSpeed,varname:_CloudsSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Rotator,id:5893,x:37478,y:32212,varname:node_5893,prsc:2|UVIN-6078-OUT,PIV-8024-OUT,SPD-170-OUT;n:type:ShaderForge.SFN_Vector2,id:8024,x:37279,y:32279,varname:node_8024,prsc:2,v1:0,v2:0;n:type:ShaderForge.SFN_Vector1,id:170,x:37302,y:32408,varname:node_170,prsc:2,v1:0.0001;n:type:ShaderForge.SFN_Get,id:7094,x:44203,y:33025,varname:node_7094,prsc:0|IN-5745-OUT;n:type:ShaderForge.SFN_Add,id:638,x:44457,y:32989,varname:node_638,prsc:2|A-9633-OUT,B-7094-OUT;n:type:ShaderForge.SFN_Vector1,id:9633,x:44224,y:32961,varname:node_9633,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Clamp01,id:1587,x:44654,y:32982,varname:node_1587,prsc:2|IN-638-OUT;n:type:ShaderForge.SFN_Sqrt,id:9899,x:40471,y:33368,varname:node_9899,prsc:2|IN-8254-OUT;n:type:ShaderForge.SFN_Multiply,id:3398,x:38130,y:30121,varname:node_3398,prsc:0|A-5211-OUT,B-3313-OUT,C-4076-OUT;n:type:ShaderForge.SFN_Get,id:839,x:38443,y:31527,varname:node_839,prsc:2|IN-4833-OUT;n:type:ShaderForge.SFN_Get,id:425,x:44329,y:32497,varname:node_425,prsc:2|IN-6755-OUT;n:type:ShaderForge.SFN_Get,id:8790,x:37468,y:30248,varname:node_8790,prsc:2|IN-4833-OUT;n:type:ShaderForge.SFN_Append,id:1076,x:38273,y:29813,varname:node_1076,prsc:0|A-2103-OUT,B-1985-OUT;n:type:ShaderForge.SFN_Vector1,id:2103,x:37914,y:29986,varname:node_2103,prsc:2,v1:0;n:type:ShaderForge.SFN_Add,id:8241,x:38687,y:30152,varname:node_8241,prsc:2|A-1793-UVOUT,B-7169-UVOUT;n:type:ShaderForge.SFN_Vector1,id:4076,x:37563,y:31132,varname:node_4076,prsc:2,v1:11;n:type:ShaderForge.SFN_Rotator,id:1793,x:38617,y:29931,varname:node_1793,prsc:0|UVIN-1076-OUT,ANG-5140-OUT;n:type:ShaderForge.SFN_Get,id:5140,x:37960,y:30530,varname:node_5140,prsc:2|IN-2977-OUT;n:type:ShaderForge.SFN_Vector1,id:1260,x:37979,y:30882,varname:node_1260,prsc:2,v1:100;n:type:ShaderForge.SFN_Append,id:2791,x:38449,y:30163,varname:node_2791,prsc:2|A-4025-OUT,B-2103-OUT;n:type:ShaderForge.SFN_Rotator,id:5889,x:38464,y:30341,varname:node_5889,prsc:2|UVIN-2791-OUT,ANG-650-OUT;n:type:ShaderForge.SFN_Add,id:9685,x:37846,y:30651,varname:node_9685,prsc:2|A-9503-UVOUT,B-5889-UVOUT;n:type:ShaderForge.SFN_Add,id:650,x:38095,y:30788,varname:node_650,prsc:2|A-5140-OUT,B-1260-OUT;n:type:ShaderForge.SFN_Transform,id:1522,x:37371,y:30344,varname:node_1522,prsc:2,tffrom:0,tfto:1|IN-8790-OUT;n:type:ShaderForge.SFN_ComponentMask,id:2630,x:37863,y:30355,varname:node_2630,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-7301-OUT;n:type:ShaderForge.SFN_Code,id:5211,x:38348,y:30609,varname:node_5211,prsc:2,code:ZgBsAG8AYQB0ADEAIABhACwAYgAsAG8AOwAKAGEAPQBsAGUAcgBwACgAMAAsADEALABBAC8AMgApADsACgBiAD0AbABlAHIAcAAoADEALAAwACwAKABBACsAMQApAC8AMgApADsACgBvAD0AbABlAHIAcAAoAGEALABiACwAQQApADsACgAKAHIAZQB0AHUAcgBuACAAbwA7AA==,output:0,fname:Function_node_5211,width:247,height:132,input:0,input:2,input_1_label:A,input_2_label:B|A-4717-OUT,B-7301-OUT;n:type:ShaderForge.SFN_RemapRange,id:4717,x:38039,y:30395,varname:node_4717,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-2630-OUT;n:type:ShaderForge.SFN_Normalize,id:7301,x:37770,y:30072,varname:node_7301,prsc:2|IN-1522-XYZ;n:type:ShaderForge.SFN_Multiply,id:304,x:45603,y:32446,varname:node_304,prsc:2|A-425-OUT,B-1134-OUT;n:type:ShaderForge.SFN_Vector1,id:1134,x:44318,y:32684,varname:node_1134,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Vector1,id:6469,x:37177,y:32461,varname:node_6469,prsc:2,v1:3;n:type:ShaderForge.SFN_Vector1,id:3365,x:34852,y:33842,varname:node_3365,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:9761,x:39664,y:31435,varname:node_9761,prsc:2|IN-5152-OUT,IMIN-1478-OUT,IMAX-3881-OUT,OMIN-4640-OUT,OMAX-8834-OUT;n:type:ShaderForge.SFN_Subtract,id:1478,x:40172,y:31191,varname:node_1478,prsc:2|A-3161-OUT,B-2712-OUT;n:type:ShaderForge.SFN_Vector1,id:2562,x:39592,y:31589,varname:node_2562,prsc:2,v1:0.06;n:type:ShaderForge.SFN_Get,id:3334,x:44495,y:32029,varname:node_3334,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4398,x:44714,y:31929,varname:node_4398,prsc:2|A-98-OUT,B-3334-OUT;n:type:ShaderForge.SFN_Vector1,id:98,x:44502,y:31927,varname:node_98,prsc:2,v1:0.4;n:type:ShaderForge.SFN_Get,id:5032,x:40058,y:31597,varname:node_5032,prsc:2|IN-8967-OUT;n:type:ShaderForge.SFN_Negate,id:8112,x:40396,y:31565,varname:node_8112,prsc:2|IN-3031-OUT;n:type:ShaderForge.SFN_Multiply,id:1959,x:40430,y:31380,varname:node_1959,prsc:2|A-2562-OUT,B-8112-OUT;n:type:ShaderForge.SFN_Clamp01,id:2712,x:40628,y:31398,varname:node_2712,prsc:2|IN-1959-OUT;n:type:ShaderForge.SFN_Clamp01,id:7379,x:39965,y:31355,varname:node_7379,prsc:2|IN-9761-OUT;n:type:ShaderForge.SFN_Multiply,id:3031,x:40772,y:31281,varname:node_3031,prsc:2|A-5032-OUT,B-7672-OUT;n:type:ShaderForge.SFN_Vector1,id:7672,x:40054,y:31754,varname:node_7672,prsc:2,v1:1;n:type:ShaderForge.SFN_Get,id:9086,x:38869,y:30814,varname:node_9086,prsc:2|IN-6755-OUT;n:type:ShaderForge.SFN_Set,id:2584,x:39516,y:30632,varname:ClR,prsc:2|IN-1333-RGB;n:type:ShaderForge.SFN_Set,id:9280,x:39509,y:30863,varname:ClG,prsc:2|IN-3101-RGB;n:type:ShaderForge.SFN_Set,id:2500,x:39505,y:31054,varname:ClB,prsc:2|IN-3063-RGB;n:type:ShaderForge.SFN_Get,id:2128,x:34022,y:34086,varname:node_2128,prsc:2|IN-2584-OUT;n:type:ShaderForge.SFN_Get,id:5453,x:34034,y:34450,varname:node_5453,prsc:2|IN-9280-OUT;n:type:ShaderForge.SFN_Vector1,id:6120,x:39046,y:30985,varname:node_6120,prsc:2,v1:1;n:type:ShaderForge.SFN_Get,id:4702,x:39732,y:35245,varname:node_4702,prsc:2|IN-9280-OUT;n:type:ShaderForge.SFN_Lerp,id:7511,x:39389,y:30479,varname:node_7511,prsc:2|A-717-XYZ,B-1333-RGB,T-9086-OUT;n:type:ShaderForge.SFN_NormalVector,id:447,x:39095,y:30364,prsc:2,pt:False;n:type:ShaderForge.SFN_Transform,id:717,x:39302,y:30299,varname:node_717,prsc:2,tffrom:0,tfto:2|IN-447-OUT;n:type:ShaderForge.SFN_Lerp,id:2777,x:39405,y:30647,varname:node_2777,prsc:2|A-717-XYZ,B-3101-RGB,T-9086-OUT;n:type:ShaderForge.SFN_Lerp,id:177,x:39371,y:30930,varname:node_177,prsc:2|A-5478-RGB,B-3063-RGB,T-9086-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:969,x:38654,y:30634,ptovrint:False,ptlb:CloudsNormal,ptin:_CloudsNormal,varname:_CloudsNormal,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:877a709325ffbb340a453962d119c2ca,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:3063,x:38890,y:30618,varname:_node_3063,prsc:2,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False|UVIN-9685-OUT,TEX-969-TEX;n:type:ShaderForge.SFN_Tex2d,id:3101,x:38921,y:30492,varname:_node_3101,prsc:2,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False|UVIN-3813-UVOUT,TEX-969-TEX;n:type:ShaderForge.SFN_Tex2d,id:1333,x:38890,y:30318,varname:_node_1333,prsc:2,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False|UVIN-8241-OUT,TEX-969-TEX;n:type:ShaderForge.SFN_Blend,id:260,x:46736,y:31788,varname:node_260,prsc:2,blmd:6,clmp:True|SRC-8508-OUT,DST-8639-OUT;n:type:ShaderForge.SFN_Get,id:9219,x:34119,y:34623,varname:node_9219,prsc:2|IN-2500-OUT;n:type:ShaderForge.SFN_Lerp,id:5846,x:34377,y:34089,varname:node_5846,prsc:2|A-3670-OUT,B-2128-OUT,T-4880-OUT;n:type:ShaderForge.SFN_Lerp,id:453,x:34411,y:34700,varname:node_453,prsc:2|A-8506-OUT,B-9219-OUT,T-4880-OUT;n:type:ShaderForge.SFN_Get,id:4880,x:34220,y:34352,varname:node_4880,prsc:2|IN-6755-OUT;n:type:ShaderForge.SFN_Get,id:8429,x:38280,y:35349,varname:node_8429,prsc:2|IN-6755-OUT;n:type:ShaderForge.SFN_OneMinus,id:8162,x:38460,y:35326,varname:node_8162,prsc:2|IN-8429-OUT;n:type:ShaderForge.SFN_Multiply,id:8978,x:38546,y:35164,varname:node_8978,prsc:2|A-6432-OUT,B-8162-OUT;n:type:ShaderForge.SFN_Multiply,id:4912,x:39253,y:30647,varname:node_4912,prsc:2|A-3101-RGB,B-4252-OUT;n:type:ShaderForge.SFN_Vector1,id:4252,x:39113,y:30720,varname:node_4252,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:7774,x:34611,y:34294,varname:node_7774,prsc:2|A-9295-OUT,B-5453-OUT,T-4880-OUT;n:type:ShaderForge.SFN_Set,id:5311,x:40133,y:31388,varname:cloudsSh,prsc:2|IN-3444-OUT;n:type:ShaderForge.SFN_Blend,id:1397,x:45265,y:32059,varname:node_1397,prsc:2,blmd:0,clmp:True|SRC-5369-OUT,DST-3069-OUT;n:type:ShaderForge.SFN_Get,id:4850,x:45005,y:32112,varname:node_4850,prsc:2|IN-5311-OUT;n:type:ShaderForge.SFN_OneMinus,id:3069,x:45115,y:32012,varname:node_3069,prsc:2|IN-4850-OUT;n:type:ShaderForge.SFN_Multiply,id:1893,x:45332,y:31910,varname:node_1893,prsc:2|A-8267-OUT,B-3069-OUT;n:type:ShaderForge.SFN_Vector1,id:8267,x:45684,y:31951,varname:node_8267,prsc:2,v1:0.4;n:type:ShaderForge.SFN_Subtract,id:3167,x:37887,y:31091,varname:node_3167,prsc:2|A-9503-UVOUT,B-5889-UVOUT;n:type:ShaderForge.SFN_Sign,id:7630,x:38117,y:29991,varname:node_7630,prsc:2|IN-7301-OUT;n:type:ShaderForge.SFN_ComponentMask,id:9281,x:38310,y:29947,varname:node_9281,prsc:2,cc1:2,cc2:0,cc3:-1,cc4:-1|IN-7630-OUT;n:type:ShaderForge.SFN_Multiply,id:4025,x:38476,y:30032,varname:node_4025,prsc:2|A-3398-OUT,B-9281-R;n:type:ShaderForge.SFN_Multiply,id:8136,x:38035,y:29821,varname:node_8136,prsc:2|A-9281-G,B-3398-OUT;n:type:ShaderForge.SFN_Negate,id:1985,x:38170,y:29717,varname:node_1985,prsc:2|IN-8136-OUT;n:type:ShaderForge.SFN_Vector1,id:4087,x:45081,y:32888,varname:node_4087,prsc:2,v1:0.5;n:type:ShaderForge.SFN_AmbientLight,id:3660,x:45113,y:33000,varname:node_3660,prsc:2;n:type:ShaderForge.SFN_Add,id:5288,x:45659,y:33058,varname:node_5288,prsc:2|A-9239-OUT,B-6940-OUT;n:type:ShaderForge.SFN_Multiply,id:6940,x:45341,y:33048,varname:node_6940,prsc:2|A-3660-RGB,B-8748-OUT,C-375-OUT;n:type:ShaderForge.SFN_Slider,id:8748,x:44782,y:32808,ptovrint:False,ptlb:Ambient,ptin:_Ambient,varname:_Ambient,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:7775,x:45204,y:32391,varname:node_7775,prsc:2|A-9003-OUT,B-5024-OUT,T-8748-OUT;n:type:ShaderForge.SFN_Blend,id:793,x:46511,y:32355,varname:node_793,prsc:2,blmd:5,clmp:True|SRC-9239-OUT,DST-6940-OUT;n:type:ShaderForge.SFN_Vector1,id:375,x:44881,y:33062,varname:node_375,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:3346,x:44074,y:31872,varname:node_3346,prsc:2|A-8538-OUT,B-4087-OUT;n:type:ShaderForge.SFN_Slider,id:3969,x:37986,y:33402,ptovrint:False,ptlb:Refraction,ptin:_Refraction,varname:_Refraction,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Subtract,id:5934,x:38415,y:33292,varname:node_5934,prsc:2|A-3969-OUT,B-5698-OUT;n:type:ShaderForge.SFN_Vector1,id:5698,x:38321,y:33421,varname:node_5698,prsc:2,v1:0.5;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:3775,x:38667,y:33353,varname:node_3775,prsc:2|IN-6091-OUT,IMIN-982-OUT,IMAX-2569-OUT,OMIN-5934-OUT,OMAX-2569-OUT;n:type:ShaderForge.SFN_Vector1,id:982,x:38615,y:33145,varname:node_982,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2569,x:38430,y:33498,varname:node_2569,prsc:2,v1:1;n:type:ShaderForge.SFN_Set,id:3799,x:38594,y:33259,varname:refract,prsc:2|IN-5934-OUT;n:type:ShaderForge.SFN_Add,id:3138,x:47133,y:32480,varname:node_3138,prsc:2|A-304-OUT,B-6922-OUT;n:type:ShaderForge.SFN_Get,id:8138,x:45547,y:32501,varname:node_8138,prsc:2|IN-3799-OUT;n:type:ShaderForge.SFN_Multiply,id:6922,x:45693,y:32222,varname:node_6922,prsc:2|A-3153-OUT,B-8138-OUT;n:type:ShaderForge.SFN_Vector1,id:3153,x:45518,y:32252,varname:node_3153,prsc:2,v1:2;n:type:ShaderForge.SFN_Multiply,id:9847,x:44405,y:32283,varname:node_9847,prsc:2|A-9440-OUT,B-3217-OUT;n:type:ShaderForge.SFN_Vector1,id:3217,x:44168,y:32373,varname:node_3217,prsc:2,v1:4;n:type:ShaderForge.SFN_Get,id:175,x:47137,y:32131,varname:node_175,prsc:2|IN-8306-OUT;n:type:ShaderForge.SFN_RemapRange,id:3570,x:43548,y:32088,varname:node_3570,prsc:2,frmn:0,frmx:1,tomn:1,tomx:-5|IN-9003-OUT;n:type:ShaderForge.SFN_Clamp01,id:2623,x:43759,y:32171,varname:node_2623,prsc:2|IN-3570-OUT;n:type:ShaderForge.SFN_Vector1,id:5024,x:44924,y:32517,varname:node_5024,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:6132,x:39700,y:31868,varname:node_6132,prsc:2,v1:0;n:type:ShaderForge.SFN_Get,id:3407,x:39944,y:31540,varname:node_3407,prsc:2|IN-6755-OUT;n:type:ShaderForge.SFN_Min,id:3444,x:40181,y:31458,varname:node_3444,prsc:2|A-7379-OUT,B-3407-OUT;n:type:ShaderForge.SFN_Max,id:6542,x:45793,y:32838,varname:node_6542,prsc:2|A-9239-OUT,B-6940-OUT;n:type:ShaderForge.SFN_Clamp01,id:4684,x:46662,y:32441,varname:node_4684,prsc:2|IN-7775-OUT;n:type:ShaderForge.SFN_Multiply,id:4106,x:45737,y:31755,varname:node_4106,prsc:2|A-4684-OUT,B-6443-OUT;n:type:ShaderForge.SFN_NormalVector,id:6791,x:37480,y:33724,prsc:2,pt:True;n:type:ShaderForge.SFN_Normalize,id:1072,x:37648,y:33713,varname:node_1072,prsc:2|IN-6791-OUT;n:type:ShaderForge.SFN_Lerp,id:7355,x:38093,y:33882,varname:node_7355,prsc:2|A-9828-OUT,B-1072-OUT,T-9126-OUT;n:type:ShaderForge.SFN_Vector1,id:2734,x:37905,y:33914,varname:node_2734,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Get,id:9126,x:37760,y:33979,varname:node_9126,prsc:2|IN-6755-OUT;n:type:ShaderForge.SFN_RemapRange,id:1962,x:41901,y:31797,varname:node_1962,prsc:2,frmn:0.3,frmx:1,tomn:0,tomx:1|IN-2551-OUT;n:type:ShaderForge.SFN_RemapRange,id:4738,x:41901,y:31639,varname:node_4738,prsc:2,frmn:0,frmx:0.3,tomn:0,tomx:1|IN-2551-OUT;n:type:ShaderForge.SFN_Clamp01,id:1177,x:42079,y:31629,varname:node_1177,prsc:2|IN-4738-OUT;n:type:ShaderForge.SFN_Clamp01,id:77,x:42079,y:31787,varname:node_77,prsc:2|IN-1962-OUT;n:type:ShaderForge.SFN_Lerp,id:9705,x:42322,y:31672,varname:node_9705,prsc:2|A-8389-OUT,B-9694-OUT,T-1177-OUT;n:type:ShaderForge.SFN_Vector1,id:8389,x:42082,y:31581,varname:node_8389,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:9694,x:42066,y:31517,varname:node_9694,prsc:2,v1:0;n:type:ShaderForge.SFN_Lerp,id:3324,x:42562,y:31506,varname:node_3324,prsc:2|A-9705-OUT,B-9694-OUT,T-2551-OUT;n:type:ShaderForge.SFN_Set,id:5875,x:42785,y:31503,varname:shores,prsc:2|IN-3324-OUT;n:type:ShaderForge.SFN_Get,id:1715,x:37499,y:29206,varname:node_1715,prsc:2|IN-5875-OUT;n:type:ShaderForge.SFN_OneMinus,id:5376,x:37685,y:29133,varname:node_5376,prsc:2|IN-1715-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:9833,x:44618,y:32282,ptovrint:False,ptlb:Sunset,ptin:_Sunset,varname:_Sunset,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-6920-OUT,B-9847-OUT;n:type:ShaderForge.SFN_Vector1,id:6920,x:44811,y:32293,varname:node_6920,prsc:2,v1:0;n:type:ShaderForge.SFN_Clamp01,id:3239,x:38838,y:32678,varname:node_3239,prsc:2|IN-4475-OUT;n:type:ShaderForge.SFN_Slider,id:3717,x:46095,y:32168,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Get,id:2188,x:46178,y:31728,varname:node_2188,prsc:2|IN-759-OUT;n:type:ShaderForge.SFN_Multiply,id:8689,x:46521,y:31901,varname:node_8689,prsc:2|A-2188-OUT,B-3717-OUT,C-8792-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:7725,x:32548,y:35770,ptovrint:False,ptlb:CracksNormal,ptin:_CracksNormal,varname:_CracksNormal,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b63e91988b1b61644813d760bb10a43d,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:2172,x:32909,y:35730,varname:_node_2172,prsc:2,tex:b63e91988b1b61644813d760bb10a43d,ntxv:0,isnm:False|UVIN-6078-OUT,TEX-7725-TEX;n:type:ShaderForge.SFN_Tex2d,id:4472,x:32909,y:35538,varname:_node_4472,prsc:2,tex:b63e91988b1b61644813d760bb10a43d,ntxv:0,isnm:False|UVIN-8168-OUT,TEX-7725-TEX;n:type:ShaderForge.SFN_Tex2d,id:4299,x:32909,y:35361,varname:_node_4299,prsc:2,tex:b63e91988b1b61644813d760bb10a43d,ntxv:0,isnm:False|UVIN-3185-OUT,TEX-7725-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:7041,x:34181,y:35828,varname:node_7041,prsc:2,chbt:0|M-7084-OUT,R-55-R,G-6624-R,B-6043-R;n:type:ShaderForge.SFN_Tex2dAsset,id:3651,x:33164,y:36151,ptovrint:False,ptlb:CracksMap,ptin:_CracksMap,varname:_CracksMap,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b63e91988b1b61644813d760bb10a43d,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6043,x:37978,y:31709,varname:_node_4711,prsc:2,tex:b63e91988b1b61644813d760bb10a43d,ntxv:0,isnm:False|UVIN-6078-OUT,TEX-3651-TEX;n:type:ShaderForge.SFN_Tex2d,id:6624,x:37978,y:31545,varname:_node_4104,prsc:2,tex:b63e91988b1b61644813d760bb10a43d,ntxv:0,isnm:False|UVIN-8168-OUT,TEX-3651-TEX;n:type:ShaderForge.SFN_Tex2d,id:55,x:37978,y:31367,varname:_node_5412,prsc:2,tex:b63e91988b1b61644813d760bb10a43d,ntxv:0,isnm:False|UVIN-3185-OUT,TEX-3651-TEX;n:type:ShaderForge.SFN_Lerp,id:8506,x:34637,y:35082,varname:node_8506,prsc:2|A-1291-RGB,B-3590-OUT,T-627-OUT;n:type:ShaderForge.SFN_Set,id:9226,x:34740,y:35856,varname:cracks,prsc:2|IN-6268-OUT;n:type:ShaderForge.SFN_Get,id:627,x:34370,y:35290,varname:node_627,prsc:2|IN-9226-OUT;n:type:ShaderForge.SFN_Lerp,id:9295,x:34815,y:34372,varname:node_9295,prsc:2|A-3569-RGB,B-9985-OUT,T-2217-OUT;n:type:ShaderForge.SFN_Get,id:2217,x:34576,y:34521,varname:node_2217,prsc:2|IN-9226-OUT;n:type:ShaderForge.SFN_Lerp,id:3670,x:34867,y:34047,varname:node_3670,prsc:2|A-8302-RGB,B-9458-OUT,T-8115-OUT;n:type:ShaderForge.SFN_Get,id:8115,x:34671,y:34171,varname:node_8115,prsc:2|IN-9226-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1033,x:34434,y:35669,varname:node_1033,prsc:2|IN-7041-OUT,IMIN-4899-OUT,IMAX-4937-OUT,OMIN-6503-OUT,OMAX-2856-OUT;n:type:ShaderForge.SFN_Vector1,id:4937,x:34144,y:35625,varname:node_4937,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:6503,x:34128,y:35738,varname:node_6503,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:2856,x:34122,y:35533,varname:node_2856,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:6242,x:34122,y:35432,ptovrint:False,ptlb:Cracks,ptin:_Cracks,varname:_Cracks,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Clamp01,id:6268,x:34670,y:35588,varname:node_6268,prsc:2|IN-1033-OUT;n:type:ShaderForge.SFN_OneMinus,id:4899,x:34486,y:35369,varname:node_4899,prsc:2|IN-6242-OUT;n:type:ShaderForge.SFN_Multiply,id:3590,x:33650,y:35505,varname:node_3590,prsc:2|A-8193-OUT,B-6794-OUT,C-5082-OUT,D-1691-OUT;n:type:ShaderForge.SFN_Multiply,id:9985,x:33650,y:35372,varname:node_9985,prsc:2|A-4387-OUT,B-6794-OUT,C-5082-OUT,D-1691-OUT;n:type:ShaderForge.SFN_Multiply,id:9458,x:33639,y:35238,varname:node_9458,prsc:2|A-8941-OUT,B-6794-OUT,C-5082-OUT,D-1691-OUT;n:type:ShaderForge.SFN_Slider,id:7167,x:32633,y:36062,ptovrint:False,ptlb:CracksDepth,ptin:_CracksDepth,varname:_CracksDepth,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0,max:1;n:type:ShaderForge.SFN_Min,id:9755,x:39449,y:32332,varname:node_9755,prsc:2|A-5561-OUT,B-5138-OUT;n:type:ShaderForge.SFN_Get,id:8489,x:39245,y:32184,varname:node_8489,prsc:2|IN-9226-OUT;n:type:ShaderForge.SFN_OneMinus,id:5561,x:39810,y:32194,varname:node_5561,prsc:2|IN-3936-OUT;n:type:ShaderForge.SFN_Multiply,id:3038,x:39430,y:32168,varname:node_3038,prsc:2|A-8489-OUT,B-7167-OUT,C-7338-OUT;n:type:ShaderForge.SFN_Get,id:8080,x:46027,y:31212,varname:node_8080,prsc:2|IN-759-OUT;n:type:ShaderForge.SFN_OneMinus,id:3893,x:46257,y:31212,varname:node_3893,prsc:2|IN-8080-OUT;n:type:ShaderForge.SFN_Multiply,id:2352,x:46521,y:31176,varname:node_2352,prsc:2|A-4343-OUT,B-3893-OUT,C-5120-A;n:type:ShaderForge.SFN_Get,id:4343,x:46205,y:31118,varname:node_4343,prsc:2|IN-9226-OUT;n:type:ShaderForge.SFN_Lerp,id:8508,x:45775,y:31542,varname:node_8508,prsc:2|A-1397-OUT,B-5120-RGB,T-2352-OUT;n:type:ShaderForge.SFN_Color,id:5120,x:46303,y:31365,ptovrint:False,ptlb:CracksColor,ptin:_CracksColor,varname:_CracksColor,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:6453,x:47354,y:31848,varname:node_6453,prsc:2|A-7329-OUT,B-6545-OUT;n:type:ShaderForge.SFN_Lerp,id:2839,x:46754,y:31164,varname:node_2839,prsc:2|A-9170-OUT,B-5120-RGB,T-2352-OUT;n:type:ShaderForge.SFN_Vector1,id:9170,x:46515,y:31108,varname:node_9170,prsc:2,v1:0;n:type:ShaderForge.SFN_SwitchProperty,id:7329,x:47501,y:31561,ptovrint:False,ptlb:EmissiveCracks,ptin:_EmissiveCracks,varname:_EmissiveCracks,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-4512-OUT,B-2839-OUT;n:type:ShaderForge.SFN_Vector1,id:4512,x:47369,y:31374,varname:node_4512,prsc:2,v1:0;n:type:ShaderForge.SFN_Get,id:5410,x:46111,y:31998,varname:node_5410,prsc:2|IN-6755-OUT;n:type:ShaderForge.SFN_OneMinus,id:8792,x:46302,y:31962,varname:node_8792,prsc:2|IN-5410-OUT;n:type:ShaderForge.SFN_Get,id:1154,x:33438,y:35030,varname:node_1154,prsc:2|IN-759-OUT;n:type:ShaderForge.SFN_OneMinus,id:5082,x:33715,y:34950,varname:node_5082,prsc:2|IN-1154-OUT;n:type:ShaderForge.SFN_Vector1,id:1691,x:33719,y:35692,varname:node_1691,prsc:2,v1:2;n:type:ShaderForge.SFN_Vector1,id:7338,x:39245,y:32291,varname:node_7338,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Clamp01,id:3936,x:39579,y:32194,varname:node_3936,prsc:2|IN-3038-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:6008,x:38290,y:32170,varname:node_6008,prsc:2,min:0,max:0.99|IN-3977-OUT;n:type:ShaderForge.SFN_ComponentMask,id:47,x:33102,y:35410,varname:node_47,prsc:2,cc1:1,cc2:0,cc3:2,cc4:-1|IN-4299-RGB;n:type:ShaderForge.SFN_ComponentMask,id:9870,x:33091,y:35618,varname:node_9870,prsc:2,cc1:1,cc2:0,cc3:2,cc4:-1|IN-4472-RGB;n:type:ShaderForge.SFN_ComponentMask,id:4302,x:33102,y:35785,varname:node_4302,prsc:2,cc1:1,cc2:0,cc3:2,cc4:-1|IN-2172-RGB;n:type:ShaderForge.SFN_Negate,id:6794,x:33481,y:35938,varname:node_6794,prsc:2|IN-7167-OUT;n:type:ShaderForge.SFN_Sign,id:2422,x:33002,y:35970,varname:node_2422,prsc:2|IN-7167-OUT;n:type:ShaderForge.SFN_RemapRange,id:8775,x:33201,y:35933,varname:node_8775,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-2422-OUT;n:type:ShaderForge.SFN_Lerp,id:8193,x:33380,y:35703,varname:node_8193,prsc:2|A-2172-RGB,B-4302-OUT,T-8775-OUT;n:type:ShaderForge.SFN_Lerp,id:4387,x:33330,y:35509,varname:node_4387,prsc:2|A-4472-RGB,B-9870-OUT,T-8775-OUT;n:type:ShaderForge.SFN_Lerp,id:8941,x:33318,y:35337,varname:node_8941,prsc:2|A-4299-RGB,B-47-OUT,T-8775-OUT;proporder:5056-3977-8328-3717-239-9158-4734-8260-6928-4452-3969-6876-9833-1004-969-3313-3114-5733-6350-5425-5225-8863-5100-9018-4151-730-7840-4462-7392-8748-7725-3651-6242-7167-5120-7329;pass:END;sub:END;*/

Shader "Human Unit/Legacy/Planet" {
    Properties {
        _RandomSeed ("RandomSeed", Float ) = 699
        _WaterLevel ("WaterLevel", Range(0, 1)) = 0.4951456
        _Specularity ("Specularity", Range(0, 1)) = 1
        _Gloss ("Gloss", Range(0, 1)) = 0
        _Size ("Size", Range(0, 1)) = 0.0679612
        _HeightMap ("HeightMap", 2D) = "white" {}
        _NormalMap ("NormalMap", 2D) = "bump" {}
        _NormalIntencity ("NormalIntencity", Range(0, 1)) = 1
        _Atmosphere ("Atmosphere", Range(0, 1)) = 1
        [MaterialToggle] _Emission ("Emission", Float ) = 0
        _Refraction ("Refraction", Range(0, 1)) = 0
        _AtmosphereColor ("AtmosphereColor", Color) = (0,0.2965517,1,1)
        [MaterialToggle] _Sunset ("Sunset", Float ) = 0
        _Clouds ("Clouds", 2D) = "black" {}
        _CloudsNormal ("CloudsNormal", 2D) = "bump" {}
        _CloudsBias ("CloudsBias", Range(0, 1)) = 0.3162396
        _CloudsAmount ("CloudsAmount", Range(0, 1)) = 0.6257835
        _CloudsColor ("CloudsColor", Color) = (1,1,1,1)
        _CloudsSpeed ("CloudsSpeed", Range(0, 1)) = 0
        _Temperature ("Temperature", Range(0, 1)) = 0.1262136
        _Shores ("Shores", Color) = (0.7941176,0.7388676,0.5080017,1)
        _Planes ("Planes", Color) = (0.4617483,0.5367647,0.118404,1)
        _Mountains ("Mountains", Color) = (1,1,1,1)
        _City ("City", 2D) = "black" {}
        _CityColor ("CityColor", Color) = (1,0.8600406,0.4926471,1)
        _Population ("Population", Range(0, 1)) = 1
        _Vegetation ("Vegetation", 2D) = "white" {}
        _Fertility ("Fertility", Range(0, 1)) = 0.6796116
        _VegetationColor ("VegetationColor", Color) = (0,0.383,0.03433783,1)
        _Ambient ("Ambient", Range(0, 1)) = 0
        _CracksNormal ("CracksNormal", 2D) = "bump" {}
        _CracksMap ("CracksMap", 2D) = "black" {}
        _Cracks ("Cracks", Range(0, 1)) = 0
        _CracksDepth ("CracksDepth", Range(-1, 1)) = 0
        [HDR]_CracksColor ("CracksColor", Color) = (0.5,0.5,0.5,1)
        [MaterialToggle] _EmissiveCracks ("EmissiveCracks", Float ) = 0
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _WaterLevel;
            uniform sampler2D _HeightMap; uniform float4 _HeightMap_ST;
            uniform float _RandomSeed;
            uniform float _Size;
            uniform float4 _AtmosphereColor;
            uniform sampler2D _Clouds; uniform float4 _Clouds_ST;
            uniform float _Atmosphere;
            uniform float4 _CloudsColor;
            uniform float _Temperature;
            uniform float4 _Shores;
            uniform float4 _Planes;
            uniform float4 _Mountains;
            uniform sampler2D _City; uniform float4 _City_ST;
            uniform float4 _CityColor;
            uniform float _Population;
            uniform sampler2D _Vegetation; uniform float4 _Vegetation_ST;
            uniform float _Fertility;
            uniform float4 _VegetationColor;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _NormalIntencity;
            float3 Rotate( float3 Normal , float Angle , float C , float G ){
            
            float nx = Normal.x;
            float ny = Normal.y;
            float nz = Normal.z;
            
            float a=Angle;
            
            
            float ca=cos(a);
            float sa=sin(a);
            float3 rN=float3(ca*nx-sa*ny,sa*nx+ca*ny,nz);
            
            if(C<0){
            rN=rN.yxz;
            rN.x=rN.x; 
            rN.y=rN.y;}
            if(C>0){
            rN=rN.yxz;
            rN.x=rN.x; 
            rN.y=rN.y;}
            return rN;
            }
            
            float3 Rotate2( float3 Normal , float Angle , float G , float B , float R ){
            float nx = Normal.x;
            float ny = Normal.y;
            float nz = Normal.z;
            float a=Angle;
            
            float ca=cos(a);
            float sa=sin(a);
            float3 rN=float3(ca*nx-sa*ny,sa*nx+ca*ny,nz);
            
            
            return rN;
            }
            
            float3 Rotate3( float3 Normal , float Angle , float C , float G ){
            float nx = Normal.x;
            float ny = Normal.y;
            float nz = Normal.z;
            
            float a=Angle;
            
            float ca=cos(a);
            float sa=sin(a);
            float3 rN=float3(ca*nx-sa*ny,sa*nx+ca*ny,nz);
            
            
            
            return rN;
            }
            
            float3 normX( float3 norm , float3 normDir ){
            float3 xNorm =normalize(half3(norm.xy  + normDir.zy, normDir.x));
            
            xNorm=xNorm.zyx;
            return xNorm;
            }
            
            float3 normYX( float3 norm , float3 normDir ){
            float3 yNorm = normalize(half3(norm.xy + normDir.zx, normDir.y));
            
            yNorm=yNorm.yzx;
            return yNorm;
            }
            
            float3 normXZ( float3 norm , float sign , float3 normDir ){
            float3 zNorm = normalize(half3(norm.xy  + normDir.xy, normDir.z));
            return zNorm;
            }
            
            uniform float _CloudsAmount;
            uniform float _Specularity;
            uniform fixed _Emission;
            uniform float _CloudsBias;
            uniform float _CloudsSpeed;
            float Function_node_5211( float A , float3 B ){
            float1 a,b,o;
            a=lerp(0,1,A/2);
            b=lerp(1,0,(A+1)/2);
            o=lerp(a,b,A);
            
            return o;
            }
            
            uniform sampler2D _CloudsNormal; uniform float4 _CloudsNormal_ST;
            uniform float _Ambient;
            uniform float _Refraction;
            uniform fixed _Sunset;
            uniform float _Gloss;
            uniform sampler2D _CracksNormal; uniform float4 _CracksNormal_ST;
            uniform sampler2D _CracksMap; uniform float4 _CracksMap_ST;
            uniform float _Cracks;
            uniform float _CracksDepth;
            uniform float4 _CracksColor;
            uniform fixed _EmissiveCracks;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normals = normalize(i.normalDir);
                float3 lNormals = mul( unity_WorldToObject, float4(normals,0) ).xyz;
                float3 normalsMul = (lNormals.rgb*1.4);
                float3 normalsNorm = normalize((normalsMul*normalsMul*normalsMul*normalsMul));
                float3 normalsComp = normalsNorm.rgb;
                float3 Mask = ((normalsNorm/(normalsComp.r+normalsComp.g+normalsComp.b))*1.0);
                float sizeRemap = (_Size*5.8+0.2);
                float randomSeed = _RandomSeed;
                float yzSeed = randomSeed;
                float yz2_ang = yzSeed;
                float yz2_spd = 1.0;
                float yz2_cos = cos(yz2_spd*yz2_ang);
                float yz2_sin = sin(yz2_spd*yz2_ang);
                float2 yz2_piv = float2(0.5,0.5);
                float3 localPos = mul( unity_WorldToObject, float4((i.posWorld.rgb-objPos.rgb),0) ).xyz.rgb.rgb;
                float2 yz2 = (mul((float2(localPos.g,localPos.b)*0.5+0.5)-yz2_piv,float2x2( yz2_cos, -yz2_sin, yz2_sin, yz2_cos))+yz2_piv);
                float2 node_3185 = (sizeRemap*(yz2+yzSeed*float2(1,1)));
                float3 _node_8302 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_3185, _NormalMap)));
                float3 _node_4299 = UnpackNormal(tex2D(_CracksNormal,TRANSFORM_TEX(node_3185, _CracksNormal)));
                float node_8775 = (sign(_CracksDepth)*0.5+0.5);
                float node_6794 = (-1*_CracksDepth);
                float4 _node_5412 = tex2D(_CracksMap,TRANSFORM_TEX(node_3185, _CracksMap));
                float zxSeed = (randomSeed+50.0);
                float zx2_ang = zxSeed;
                float zx2_spd = 1.0;
                float zx2_cos = cos(zx2_spd*zx2_ang);
                float zx2_sin = sin(zx2_spd*zx2_ang);
                float2 zx2_piv = float2(0.5,0.5);
                float2 zx2 = (mul((float2(localPos.b,localPos.r)*0.5+0.5)-zx2_piv,float2x2( zx2_cos, -zx2_sin, zx2_sin, zx2_cos))+zx2_piv);
                float2 node_8168 = (sizeRemap*(zx2+zxSeed*float2(0,1)));
                float4 _node_4104 = tex2D(_CracksMap,TRANSFORM_TEX(node_8168, _CracksMap));
                float xySeed = (randomSeed+100.0);
                float xy2_ang = xySeed;
                float xy2_spd = 1.0;
                float xy2_cos = cos(xy2_spd*xy2_ang);
                float xy2_sin = sin(xy2_spd*xy2_ang);
                float2 xy2_piv = float2(0.5,0.5);
                float2 xy2 = (mul((float2(localPos.r,localPos.g)*0.5+0.5)-xy2_piv,float2x2( xy2_cos, -xy2_sin, xy2_sin, xy2_cos))+xy2_piv);
                float2 node_6078 = (sizeRemap*(xy2+xySeed*float2(0,1)));
                float4 _node_4711 = tex2D(_CracksMap,TRANSFORM_TEX(node_6078, _CracksMap));
                float node_4899 = (1.0 - _Cracks);
                float node_6503 = 0.0;
                float cracks = saturate((node_6503 + ( ((Mask.r*_node_5412.r + Mask.g*_node_4104.r + Mask.b*_node_4711.r) - node_4899) * (1.0 - node_6503) ) / (1.0 - node_4899)));
                float4 _node_4032 = tex2D(_HeightMap,TRANSFORM_TEX(node_3185, _HeightMap));
                float4 _node_4033 = tex2D(_HeightMap,TRANSFORM_TEX(node_8168, _HeightMap));
                float4 _node_9119 = tex2D(_HeightMap,TRANSFORM_TEX(node_6078, _HeightMap));
                float node_9755 = min((1.0 - saturate((cracks*_CracksDepth*1.5))),(Mask.r*_node_4032.r + Mask.g*_node_4033.r + Mask.b*_node_9119.r));
                float atmosphere = _Atmosphere;
                float node_2328 = (saturate((2.0*atmosphere))*(clamp(_WaterLevel,0,0.99)*1.2+-0.2));
                float node_4992 = (node_9755-node_2328);
                float node_7565 = (1.0 - saturate((node_4992*10.0+0.0)));
                float Water = node_7565;
                float node_5082 = (1.0 - Water);
                float node_1691 = 2.0;
                float node_5140 = randomSeed;
                float node_1793_ang = node_5140;
                float node_1793_spd = 1.0;
                float node_1793_cos = cos(node_1793_spd*node_1793_ang);
                float node_1793_sin = sin(node_1793_spd*node_1793_ang);
                float2 node_1793_piv = float2(0.5,0.5);
                float node_2103 = 0.0;
                float3 node_7301 = normalize(mul( unity_WorldToObject, float4(normals,0) ).xyz.rgb);
                float2 node_9281 = sign(node_7301).br;
                fixed node_3398 = (Function_node_5211( (node_7301.g*0.5+0.5) , node_7301 )*_CloudsBias*11.0);
                fixed2 node_1793 = (mul(float2(node_2103,(-1*(node_9281.g*node_3398)))-node_1793_piv,float2x2( node_1793_cos, -node_1793_sin, node_1793_sin, node_1793_cos))+node_1793_piv);
                float4 time = _Time + _TimeEditor;
                float node_618 = (time.g*_CloudsSpeed*3.0);
                float2 node_8241 = (node_1793+(node_3185+node_618*float2(0.015,0)));
                float3 _node_1333 = UnpackNormal(tex2D(_CloudsNormal,TRANSFORM_TEX(node_8241, _CloudsNormal)));
                float3 ClR = _node_1333.rgb;
                float3 node_2727 = abs(lNormals.rgb);
                float3 node_6206 = (node_2727*node_2727);
                float3 node_9139 = node_6206.rgb;
                float3 node_8459 = (node_6206/(node_9139.r+node_9139.g+node_9139.b));
                fixed4 _node_3403 = tex2D(_Clouds,TRANSFORM_TEX(node_8241, _Clouds));
                fixed2 node_3813 = (node_8168+node_618*float2(0.015,0));
                fixed4 _node_5758 = tex2D(_Clouds,TRANSFORM_TEX(node_3813, _Clouds));
                float2 node_9503 = (node_6078+node_618*float2(0.015,0));
                float node_5889_ang = (node_5140+100.0);
                float node_5889_spd = 1.0;
                float node_5889_cos = cos(node_5889_spd*node_5889_ang);
                float node_5889_sin = sin(node_5889_spd*node_5889_ang);
                float2 node_5889_piv = float2(0.5,0.5);
                float2 node_5889 = (mul(float2((node_3398*node_9281.r),node_2103)-node_5889_piv,float2x2( node_5889_cos, -node_5889_sin, node_5889_sin, node_5889_cos))+node_5889_piv);
                float2 node_9685 = (node_9503+node_5889);
                fixed4 node_5478 = tex2D(_Clouds,TRANSFORM_TEX(node_9685, _Clouds));
                float node_5152 = saturate((node_8459.r*_node_3403.r + node_8459.g*_node_5758.r + node_8459.b*node_5478.r));
                fixed node_3161 = (1.0 - min(_CloudsAmount,_Atmosphere));
                fixed node_3881 = 1.0;
                fixed node_4640 = (-0.1);
                fixed node_8834 = 1.0;
                float node_6746 = saturate((node_4640 + ( (node_5152 - node_3161) * (node_8834 - node_4640) ) / (node_3881 - node_3161)));
                float Clouds = node_6746;
                float node_4880 = Clouds;
                float3 node_4465 = normalize(lNormals.rgb).rgb;
                float3 _node_3569 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_8168, _NormalMap)));
                float3 _node_4472 = UnpackNormal(tex2D(_CracksNormal,TRANSFORM_TEX(node_8168, _CracksNormal)));
                float3 _node_3101 = UnpackNormal(tex2D(_CloudsNormal,TRANSFORM_TEX(node_3813, _CloudsNormal)));
                float3 ClG = _node_3101.rgb;
                float3 _node_1291 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_6078, _NormalMap)));
                float3 _node_2172 = UnpackNormal(tex2D(_CracksNormal,TRANSFORM_TEX(node_6078, _CracksNormal)));
                float3 _node_3063 = UnpackNormal(tex2D(_CloudsNormal,TRANSFORM_TEX(node_9685, _CloudsNormal)));
                float3 ClB = _node_3063.rgb;
                float node_6399 = sign(node_4465.b);
                float3 normalDirection = lerp(i.normalDir,lerp(normalize(mul( unity_ObjectToWorld, float4((Mask.r*normX( Rotate( lerp(lerp(_node_8302.rgb,(lerp(_node_4299.rgb,_node_4299.rgb.grb,node_8775)*node_6794*node_5082*node_1691),cracks),ClR,node_4880) , yzSeed , node_4465.r , node_4465.g ) , node_4465 ) + Mask.g*normYX( Rotate2( lerp(lerp(_node_3569.rgb,(lerp(_node_4472.rgb,_node_4472.rgb.grb,node_8775)*node_6794*node_5082*node_1691),cracks),ClG,node_4880) , zxSeed , node_4465.g , node_4465.b , node_4465.r ) , node_4465 ) + Mask.b*normXZ( Rotate3( lerp(lerp(_node_1291.rgb,(lerp(_node_2172.rgb,_node_2172.rgb.grb,node_8775)*node_6794*node_5082*node_1691),cracks),ClB,node_4880) , xySeed , node_4465.b , node_4465.g ) , node_6399 , node_4465 )),0) ).xyz.rgb),i.normalDir,(Water*(1.0 - Clouds))),_NormalIntencity);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = (Water*_Gloss*(1.0 - Clouds));
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float node_982 = 0.0;
                float node_2569 = 1.0;
                float node_5934 = (_Refraction-0.5);
                float node_3775 = (node_5934 + ( (dot(lightDirection,lerp(normals,normalize(normalDirection),Clouds)) - node_982) * (node_2569 - node_5934) ) / (node_2569 - node_982));
                float lightSide = node_3775;
                float size = sizeRemap;
                float node_9003 = (lightSide*(size*0.5+1.0));
                float node_449 = normalize(mul( unity_WorldToObject, float4(normals,0) ).xyz.rgb).g;
                float node_1904 = (saturate((-1*node_449))+saturate(node_449));
                float node_6585 = sqrt(saturate((_Temperature*2.0)));
                float node_5101 = (node_6585*2.0+-1.0);
                float node_4758 = 0.0;
                float node_3955 = 1.0;
                float node_5271 = (node_5101-0.8);
                float height = node_9755;
                float node_3001 = ((node_4758 + ( (node_1904 - node_5101) * (node_3955 - node_4758) ) / (1.0 - node_5101))+((node_4758 + ( (node_1904 - node_5271) * (node_3955 - node_4758) ) / (node_5101 - node_5271))*height));
                float node_1562 = 0.0;
                float node_6133 = saturate((node_1562 + ( (node_3001 - node_6585) * (1.0 - node_1562) ) / (1.0 - node_6585)));
                float node_8161 = saturate((height*0.5+0.5));
                float node_4967 = (1.0 - saturate((((1.0 - node_8161)+1.0)-(atmosphere*2.0))));
                float node_7108 = (node_6133*node_4967);
                float node_3337 = (1.0 - Clouds);
                float3 atmosphereColor = _AtmosphereColor.rgb;
                float3 specularColor = (saturate(lerp(node_9003,0.5,_Ambient))*(max((0.3*node_7108),(Water*(1.0 - node_7108)))*_Specularity*node_3337*saturate((0.5+atmosphereColor))));
                float3 directSpecular = attenColor * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float refract = node_5934;
                float node_3138 = ((Clouds*0.3)+(2.0*refract));
                float3 w = float3(node_3138,node_3138,node_3138)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = forwardLight * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float node_8951 = saturate((node_9003*1.0+0.5));
                float node_375 = 0.5;
                float2 node_9239 = (float2(lerp( 0.0, ((node_8951*saturate((node_9003*-6.0+1.0))*atmosphere)*4.0), _Sunset ),0.0)*3.0*node_375);
                float3 node_6940 = (UNITY_LIGHTMODEL_AMBIENT.rgb*_Ambient*node_375);
                indirectDiffuse += saturate(max(float3(node_9239,0.0),node_6940)); // Diffuse Ambient Light
                indirectDiffuse *= saturate(lerp(node_9003,0.5,_Ambient)); // Diffuse AO
                float node_8849 = 1.0;
                float node_2919 = 0.0;
                float heightNorm = (node_2919 + ( (node_9755 - node_2328) * (node_8849 - node_2919) ) / (node_8849 - node_2328));
                float node_2551 = heightNorm;
                float3 heightColor = lerp(lerp(_Shores.rgb,_Planes.rgb,saturate((node_2551*3.333333+0.0))),lerp(_Planes.rgb,_Mountains.rgb,saturate((node_2551*1.428571+-0.4285715))),node_2551);
                float node_7708 = pow(1.0-max(0,dot(normals, viewDirection)),5.5);
                float3 base = saturate(lerp(saturate(heightColor),(saturate((node_7565*saturate((node_4992*0.8333333+0.1666667))))+(_AtmosphereColor.rgb*node_7565*(node_7708*0.5+0.5))),node_7565));
                float node_1869 = randomSeed;
                float2 node_6131 = (node_3185+node_1869*float2(5,0));
                float4 node_1022 = tex2D(_Vegetation,TRANSFORM_TEX(node_6131, _Vegetation));
                float2 node_4679 = (node_8168+node_1869*float2(5,0));
                float4 node_7232 = tex2D(_Vegetation,TRANSFORM_TEX(node_4679, _Vegetation));
                float2 node_9932 = (node_6078+node_1869*float2(5,0));
                float4 node_8314 = tex2D(_Vegetation,TRANSFORM_TEX(node_9932, _Vegetation));
                float node_2583 = (Mask.r*node_1022.r + Mask.g*node_7232.r + Mask.b*node_8314.r);
                float node_7583 = (1.0 - (saturate((2.0*atmosphere))*_Fertility));
                float node_7807 = 0.0;
                float node_8476 = heightNorm;
                float node_9899 = sqrt((1.0 - saturate(node_1904)));
                float node_6425 = (_Temperature*-1.714286+1.614286);
                float node_6213 = 0.0;
                float node_525 = heightNorm;
                float tempGradient = (saturate((node_3001*0.3333333+0.3333333))+saturate((saturate(((node_6213 + ( (node_9899 - node_6425) * (1.3 - node_6213) ) / ((node_6425+0.3) - node_6425))-node_525))*2.0+0.0)));
                float node_9694 = 0.0;
                float shores = lerp(lerp(1.0,node_9694,saturate((node_2551*3.333333+0.0))),node_9694,node_2551);
                float vegetation = (saturate((saturate(((node_7807 + ( (node_2583 - node_7583) * (1.0 - node_7807) ) / (1.0 - node_7583))*5.0+0.0))*saturate((saturate((node_8476*5.0+0.0))-saturate((node_8476*1.25+-0.25))))))*saturate((1.0 - tempGradient))*(1.0 - shores));
                float node_676 = saturate((node_7108*node_8161));
                float3 node_5369 = lerp(lerp(base,_VegetationColor.rgb,vegetation),(node_6133*saturate((node_676+((1.0 - node_676)*atmosphereColor*node_6133*node_4967)))),node_7108);
                float node_1478 = (node_3161-saturate((0.06*(-1*(lightSide*1.0)))));
                float cloudsSh = min(saturate((node_4640 + ( (node_5152 - node_1478) * (node_8834 - node_4640) ) / (node_3881 - node_1478))),Clouds);
                float node_3069 = (1.0 - cloudsSh);
                float node_2352 = (cracks*(1.0 - Water)*_CracksColor.a);
                float3 node_8639 = (_CloudsColor.rgb*node_6746);
                float3 diffuseColor = saturate((1.0-(1.0-lerp(saturate(min(node_5369,node_3069)),_CracksColor.rgb,node_2352))*(1.0-node_8639)));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float node_9170 = 0.0;
                float node_6382 = vegetation;
                float4 node_4485 = tex2D(_City,TRANSFORM_TEX(node_3185, _City));
                float4 node_3302 = tex2D(_City,TRANSFORM_TEX(node_8168, _City));
                float4 node_1275 = tex2D(_City,TRANSFORM_TEX(node_6078, _City));
                float node_9987 = (Mask.r*node_4485.r + Mask.g*node_3302.r + Mask.b*node_1275.r);
                float node_5236 = (_Population*0.8+0.0);
                float node_9259 = lightSide;
                float node_7772 = (1.0 - node_5236);
                float node_3030 = 1.0;
                float node_5184 = 0.0;
                float3 ciyties = (_CityColor.rgb*((saturate(lerp(node_6382,node_9987,node_5236))*node_9987)*saturate((-1*node_9259)))*3.0*saturate((node_5184 + ( (((1.0 - heightNorm)*(1.0 - Water)) - node_7772) * (node_3030 - node_5184) ) / (node_3030 - node_7772)))*(1.0 - Water));
                float3 emissive = (lerp( 0.0, lerp(float3(node_9170,node_9170,node_9170),_CracksColor.rgb,node_2352), _EmissiveCracks )+(max(ciyties,(lerp( 0.0, (_AtmosphereColor.rgb*node_7708*3.0*atmosphere), _Emission )*(node_3775*2.0)))*2.0));
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
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
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _WaterLevel;
            uniform sampler2D _HeightMap; uniform float4 _HeightMap_ST;
            uniform float _RandomSeed;
            uniform float _Size;
            uniform float4 _AtmosphereColor;
            uniform sampler2D _Clouds; uniform float4 _Clouds_ST;
            uniform float _Atmosphere;
            uniform float4 _CloudsColor;
            uniform float _Temperature;
            uniform float4 _Shores;
            uniform float4 _Planes;
            uniform float4 _Mountains;
            uniform sampler2D _City; uniform float4 _City_ST;
            uniform float4 _CityColor;
            uniform float _Population;
            uniform sampler2D _Vegetation; uniform float4 _Vegetation_ST;
            uniform float _Fertility;
            uniform float4 _VegetationColor;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform float _NormalIntencity;
            float3 Rotate( float3 Normal , float Angle , float C , float G ){
            
            float nx = Normal.x;
            float ny = Normal.y;
            float nz = Normal.z;
            
            float a=Angle;
            
            
            float ca=cos(a);
            float sa=sin(a);
            float3 rN=float3(ca*nx-sa*ny,sa*nx+ca*ny,nz);
            
            if(C<0){
            rN=rN.yxz;
            rN.x=rN.x; 
            rN.y=rN.y;}
            if(C>0){
            rN=rN.yxz;
            rN.x=rN.x; 
            rN.y=rN.y;}
            return rN;
            }
            
            float3 Rotate2( float3 Normal , float Angle , float G , float B , float R ){
            float nx = Normal.x;
            float ny = Normal.y;
            float nz = Normal.z;
            float a=Angle;
            
            float ca=cos(a);
            float sa=sin(a);
            float3 rN=float3(ca*nx-sa*ny,sa*nx+ca*ny,nz);
            
            
            return rN;
            }
            
            float3 Rotate3( float3 Normal , float Angle , float C , float G ){
            float nx = Normal.x;
            float ny = Normal.y;
            float nz = Normal.z;
            
            float a=Angle;
            
            float ca=cos(a);
            float sa=sin(a);
            float3 rN=float3(ca*nx-sa*ny,sa*nx+ca*ny,nz);
            
            
            
            return rN;
            }
            
            float3 normX( float3 norm , float3 normDir ){
            float3 xNorm =normalize(half3(norm.xy  + normDir.zy, normDir.x));
            
            xNorm=xNorm.zyx;
            return xNorm;
            }
            
            float3 normYX( float3 norm , float3 normDir ){
            float3 yNorm = normalize(half3(norm.xy + normDir.zx, normDir.y));
            
            yNorm=yNorm.yzx;
            return yNorm;
            }
            
            float3 normXZ( float3 norm , float sign , float3 normDir ){
            float3 zNorm = normalize(half3(norm.xy  + normDir.xy, normDir.z));
            return zNorm;
            }
            
            uniform float _CloudsAmount;
            uniform float _Specularity;
            uniform fixed _Emission;
            uniform float _CloudsBias;
            uniform float _CloudsSpeed;
            float Function_node_5211( float A , float3 B ){
            float1 a,b,o;
            a=lerp(0,1,A/2);
            b=lerp(1,0,(A+1)/2);
            o=lerp(a,b,A);
            
            return o;
            }
            
            uniform sampler2D _CloudsNormal; uniform float4 _CloudsNormal_ST;
            uniform float _Ambient;
            uniform float _Refraction;
            uniform float _Gloss;
            uniform sampler2D _CracksNormal; uniform float4 _CracksNormal_ST;
            uniform sampler2D _CracksMap; uniform float4 _CracksMap_ST;
            uniform float _Cracks;
            uniform float _CracksDepth;
            uniform float4 _CracksColor;
            uniform fixed _EmissiveCracks;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normals = normalize(i.normalDir);
                float3 lNormals = mul( unity_WorldToObject, float4(normals,0) ).xyz;
                float3 normalsMul = (lNormals.rgb*1.4);
                float3 normalsNorm = normalize((normalsMul*normalsMul*normalsMul*normalsMul));
                float3 normalsComp = normalsNorm.rgb;
                float3 Mask = ((normalsNorm/(normalsComp.r+normalsComp.g+normalsComp.b))*1.0);
                float sizeRemap = (_Size*5.8+0.2);
                float randomSeed = _RandomSeed;
                float yzSeed = randomSeed;
                float yz2_ang = yzSeed;
                float yz2_spd = 1.0;
                float yz2_cos = cos(yz2_spd*yz2_ang);
                float yz2_sin = sin(yz2_spd*yz2_ang);
                float2 yz2_piv = float2(0.5,0.5);
                float3 localPos = mul( unity_WorldToObject, float4((i.posWorld.rgb-objPos.rgb),0) ).xyz.rgb.rgb;
                float2 yz2 = (mul((float2(localPos.g,localPos.b)*0.5+0.5)-yz2_piv,float2x2( yz2_cos, -yz2_sin, yz2_sin, yz2_cos))+yz2_piv);
                float2 node_3185 = (sizeRemap*(yz2+yzSeed*float2(1,1)));
                float3 _node_8302 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_3185, _NormalMap)));
                float3 _node_4299 = UnpackNormal(tex2D(_CracksNormal,TRANSFORM_TEX(node_3185, _CracksNormal)));
                float node_8775 = (sign(_CracksDepth)*0.5+0.5);
                float node_6794 = (-1*_CracksDepth);
                float4 _node_5412 = tex2D(_CracksMap,TRANSFORM_TEX(node_3185, _CracksMap));
                float zxSeed = (randomSeed+50.0);
                float zx2_ang = zxSeed;
                float zx2_spd = 1.0;
                float zx2_cos = cos(zx2_spd*zx2_ang);
                float zx2_sin = sin(zx2_spd*zx2_ang);
                float2 zx2_piv = float2(0.5,0.5);
                float2 zx2 = (mul((float2(localPos.b,localPos.r)*0.5+0.5)-zx2_piv,float2x2( zx2_cos, -zx2_sin, zx2_sin, zx2_cos))+zx2_piv);
                float2 node_8168 = (sizeRemap*(zx2+zxSeed*float2(0,1)));
                float4 _node_4104 = tex2D(_CracksMap,TRANSFORM_TEX(node_8168, _CracksMap));
                float xySeed = (randomSeed+100.0);
                float xy2_ang = xySeed;
                float xy2_spd = 1.0;
                float xy2_cos = cos(xy2_spd*xy2_ang);
                float xy2_sin = sin(xy2_spd*xy2_ang);
                float2 xy2_piv = float2(0.5,0.5);
                float2 xy2 = (mul((float2(localPos.r,localPos.g)*0.5+0.5)-xy2_piv,float2x2( xy2_cos, -xy2_sin, xy2_sin, xy2_cos))+xy2_piv);
                float2 node_6078 = (sizeRemap*(xy2+xySeed*float2(0,1)));
                float4 _node_4711 = tex2D(_CracksMap,TRANSFORM_TEX(node_6078, _CracksMap));
                float node_4899 = (1.0 - _Cracks);
                float node_6503 = 0.0;
                float cracks = saturate((node_6503 + ( ((Mask.r*_node_5412.r + Mask.g*_node_4104.r + Mask.b*_node_4711.r) - node_4899) * (1.0 - node_6503) ) / (1.0 - node_4899)));
                float4 _node_4032 = tex2D(_HeightMap,TRANSFORM_TEX(node_3185, _HeightMap));
                float4 _node_4033 = tex2D(_HeightMap,TRANSFORM_TEX(node_8168, _HeightMap));
                float4 _node_9119 = tex2D(_HeightMap,TRANSFORM_TEX(node_6078, _HeightMap));
                float node_9755 = min((1.0 - saturate((cracks*_CracksDepth*1.5))),(Mask.r*_node_4032.r + Mask.g*_node_4033.r + Mask.b*_node_9119.r));
                float atmosphere = _Atmosphere;
                float node_2328 = (saturate((2.0*atmosphere))*(clamp(_WaterLevel,0,0.99)*1.2+-0.2));
                float node_4992 = (node_9755-node_2328);
                float node_7565 = (1.0 - saturate((node_4992*10.0+0.0)));
                float Water = node_7565;
                float node_5082 = (1.0 - Water);
                float node_1691 = 2.0;
                float node_5140 = randomSeed;
                float node_1793_ang = node_5140;
                float node_1793_spd = 1.0;
                float node_1793_cos = cos(node_1793_spd*node_1793_ang);
                float node_1793_sin = sin(node_1793_spd*node_1793_ang);
                float2 node_1793_piv = float2(0.5,0.5);
                float node_2103 = 0.0;
                float3 node_7301 = normalize(mul( unity_WorldToObject, float4(normals,0) ).xyz.rgb);
                float2 node_9281 = sign(node_7301).br;
                fixed node_3398 = (Function_node_5211( (node_7301.g*0.5+0.5) , node_7301 )*_CloudsBias*11.0);
                fixed2 node_1793 = (mul(float2(node_2103,(-1*(node_9281.g*node_3398)))-node_1793_piv,float2x2( node_1793_cos, -node_1793_sin, node_1793_sin, node_1793_cos))+node_1793_piv);
                float4 time = _Time + _TimeEditor;
                float node_618 = (time.g*_CloudsSpeed*3.0);
                float2 node_8241 = (node_1793+(node_3185+node_618*float2(0.015,0)));
                float3 _node_1333 = UnpackNormal(tex2D(_CloudsNormal,TRANSFORM_TEX(node_8241, _CloudsNormal)));
                float3 ClR = _node_1333.rgb;
                float3 node_2727 = abs(lNormals.rgb);
                float3 node_6206 = (node_2727*node_2727);
                float3 node_9139 = node_6206.rgb;
                float3 node_8459 = (node_6206/(node_9139.r+node_9139.g+node_9139.b));
                fixed4 _node_3403 = tex2D(_Clouds,TRANSFORM_TEX(node_8241, _Clouds));
                fixed2 node_3813 = (node_8168+node_618*float2(0.015,0));
                fixed4 _node_5758 = tex2D(_Clouds,TRANSFORM_TEX(node_3813, _Clouds));
                float2 node_9503 = (node_6078+node_618*float2(0.015,0));
                float node_5889_ang = (node_5140+100.0);
                float node_5889_spd = 1.0;
                float node_5889_cos = cos(node_5889_spd*node_5889_ang);
                float node_5889_sin = sin(node_5889_spd*node_5889_ang);
                float2 node_5889_piv = float2(0.5,0.5);
                float2 node_5889 = (mul(float2((node_3398*node_9281.r),node_2103)-node_5889_piv,float2x2( node_5889_cos, -node_5889_sin, node_5889_sin, node_5889_cos))+node_5889_piv);
                float2 node_9685 = (node_9503+node_5889);
                fixed4 node_5478 = tex2D(_Clouds,TRANSFORM_TEX(node_9685, _Clouds));
                float node_5152 = saturate((node_8459.r*_node_3403.r + node_8459.g*_node_5758.r + node_8459.b*node_5478.r));
                fixed node_3161 = (1.0 - min(_CloudsAmount,_Atmosphere));
                fixed node_3881 = 1.0;
                fixed node_4640 = (-0.1);
                fixed node_8834 = 1.0;
                float node_6746 = saturate((node_4640 + ( (node_5152 - node_3161) * (node_8834 - node_4640) ) / (node_3881 - node_3161)));
                float Clouds = node_6746;
                float node_4880 = Clouds;
                float3 node_4465 = normalize(lNormals.rgb).rgb;
                float3 _node_3569 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_8168, _NormalMap)));
                float3 _node_4472 = UnpackNormal(tex2D(_CracksNormal,TRANSFORM_TEX(node_8168, _CracksNormal)));
                float3 _node_3101 = UnpackNormal(tex2D(_CloudsNormal,TRANSFORM_TEX(node_3813, _CloudsNormal)));
                float3 ClG = _node_3101.rgb;
                float3 _node_1291 = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(node_6078, _NormalMap)));
                float3 _node_2172 = UnpackNormal(tex2D(_CracksNormal,TRANSFORM_TEX(node_6078, _CracksNormal)));
                float3 _node_3063 = UnpackNormal(tex2D(_CloudsNormal,TRANSFORM_TEX(node_9685, _CloudsNormal)));
                float3 ClB = _node_3063.rgb;
                float node_6399 = sign(node_4465.b);
                float3 normalDirection = lerp(i.normalDir,lerp(normalize(mul( unity_ObjectToWorld, float4((Mask.r*normX( Rotate( lerp(lerp(_node_8302.rgb,(lerp(_node_4299.rgb,_node_4299.rgb.grb,node_8775)*node_6794*node_5082*node_1691),cracks),ClR,node_4880) , yzSeed , node_4465.r , node_4465.g ) , node_4465 ) + Mask.g*normYX( Rotate2( lerp(lerp(_node_3569.rgb,(lerp(_node_4472.rgb,_node_4472.rgb.grb,node_8775)*node_6794*node_5082*node_1691),cracks),ClG,node_4880) , zxSeed , node_4465.g , node_4465.b , node_4465.r ) , node_4465 ) + Mask.b*normXZ( Rotate3( lerp(lerp(_node_1291.rgb,(lerp(_node_2172.rgb,_node_2172.rgb.grb,node_8775)*node_6794*node_5082*node_1691),cracks),ClB,node_4880) , xySeed , node_4465.b , node_4465.g ) , node_6399 , node_4465 )),0) ).xyz.rgb),i.normalDir,(Water*(1.0 - Clouds))),_NormalIntencity);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = (Water*_Gloss*(1.0 - Clouds));
                float specPow = exp2( gloss * 10.0 + 1.0 );
////// Specular:
                float NdotL = saturate(dot( normalDirection, lightDirection ));
                float node_982 = 0.0;
                float node_2569 = 1.0;
                float node_5934 = (_Refraction-0.5);
                float node_3775 = (node_5934 + ( (dot(lightDirection,lerp(normals,normalize(normalDirection),Clouds)) - node_982) * (node_2569 - node_5934) ) / (node_2569 - node_982));
                float lightSide = node_3775;
                float size = sizeRemap;
                float node_9003 = (lightSide*(size*0.5+1.0));
                float node_449 = normalize(mul( unity_WorldToObject, float4(normals,0) ).xyz.rgb).g;
                float node_1904 = (saturate((-1*node_449))+saturate(node_449));
                float node_6585 = sqrt(saturate((_Temperature*2.0)));
                float node_5101 = (node_6585*2.0+-1.0);
                float node_4758 = 0.0;
                float node_3955 = 1.0;
                float node_5271 = (node_5101-0.8);
                float height = node_9755;
                float node_3001 = ((node_4758 + ( (node_1904 - node_5101) * (node_3955 - node_4758) ) / (1.0 - node_5101))+((node_4758 + ( (node_1904 - node_5271) * (node_3955 - node_4758) ) / (node_5101 - node_5271))*height));
                float node_1562 = 0.0;
                float node_6133 = saturate((node_1562 + ( (node_3001 - node_6585) * (1.0 - node_1562) ) / (1.0 - node_6585)));
                float node_8161 = saturate((height*0.5+0.5));
                float node_4967 = (1.0 - saturate((((1.0 - node_8161)+1.0)-(atmosphere*2.0))));
                float node_7108 = (node_6133*node_4967);
                float node_3337 = (1.0 - Clouds);
                float3 atmosphereColor = _AtmosphereColor.rgb;
                float3 specularColor = (saturate(lerp(node_9003,0.5,_Ambient))*(max((0.3*node_7108),(Water*(1.0 - node_7108)))*_Specularity*node_3337*saturate((0.5+atmosphereColor))));
                float3 directSpecular = attenColor * pow(max(0,dot(reflect(-lightDirection, normalDirection),viewDirection)),specPow)*specularColor;
                float3 specular = directSpecular;
/////// Diffuse:
                NdotL = dot( normalDirection, lightDirection );
                float refract = node_5934;
                float node_3138 = ((Clouds*0.3)+(2.0*refract));
                float3 w = float3(node_3138,node_3138,node_3138)*0.5; // Light wrapping
                float3 NdotLWrap = NdotL * ( 1.0 - w );
                float3 forwardLight = max(float3(0.0,0.0,0.0), NdotLWrap + w );
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = forwardLight * attenColor;
                float node_8849 = 1.0;
                float node_2919 = 0.0;
                float heightNorm = (node_2919 + ( (node_9755 - node_2328) * (node_8849 - node_2919) ) / (node_8849 - node_2328));
                float node_2551 = heightNorm;
                float3 heightColor = lerp(lerp(_Shores.rgb,_Planes.rgb,saturate((node_2551*3.333333+0.0))),lerp(_Planes.rgb,_Mountains.rgb,saturate((node_2551*1.428571+-0.4285715))),node_2551);
                float node_7708 = pow(1.0-max(0,dot(normals, viewDirection)),5.5);
                float3 base = saturate(lerp(saturate(heightColor),(saturate((node_7565*saturate((node_4992*0.8333333+0.1666667))))+(_AtmosphereColor.rgb*node_7565*(node_7708*0.5+0.5))),node_7565));
                float node_1869 = randomSeed;
                float2 node_6131 = (node_3185+node_1869*float2(5,0));
                float4 node_1022 = tex2D(_Vegetation,TRANSFORM_TEX(node_6131, _Vegetation));
                float2 node_4679 = (node_8168+node_1869*float2(5,0));
                float4 node_7232 = tex2D(_Vegetation,TRANSFORM_TEX(node_4679, _Vegetation));
                float2 node_9932 = (node_6078+node_1869*float2(5,0));
                float4 node_8314 = tex2D(_Vegetation,TRANSFORM_TEX(node_9932, _Vegetation));
                float node_2583 = (Mask.r*node_1022.r + Mask.g*node_7232.r + Mask.b*node_8314.r);
                float node_7583 = (1.0 - (saturate((2.0*atmosphere))*_Fertility));
                float node_7807 = 0.0;
                float node_8476 = heightNorm;
                float node_9899 = sqrt((1.0 - saturate(node_1904)));
                float node_6425 = (_Temperature*-1.714286+1.614286);
                float node_6213 = 0.0;
                float node_525 = heightNorm;
                float tempGradient = (saturate((node_3001*0.3333333+0.3333333))+saturate((saturate(((node_6213 + ( (node_9899 - node_6425) * (1.3 - node_6213) ) / ((node_6425+0.3) - node_6425))-node_525))*2.0+0.0)));
                float node_9694 = 0.0;
                float shores = lerp(lerp(1.0,node_9694,saturate((node_2551*3.333333+0.0))),node_9694,node_2551);
                float vegetation = (saturate((saturate(((node_7807 + ( (node_2583 - node_7583) * (1.0 - node_7807) ) / (1.0 - node_7583))*5.0+0.0))*saturate((saturate((node_8476*5.0+0.0))-saturate((node_8476*1.25+-0.25))))))*saturate((1.0 - tempGradient))*(1.0 - shores));
                float node_676 = saturate((node_7108*node_8161));
                float3 node_5369 = lerp(lerp(base,_VegetationColor.rgb,vegetation),(node_6133*saturate((node_676+((1.0 - node_676)*atmosphereColor*node_6133*node_4967)))),node_7108);
                float node_1478 = (node_3161-saturate((0.06*(-1*(lightSide*1.0)))));
                float cloudsSh = min(saturate((node_4640 + ( (node_5152 - node_1478) * (node_8834 - node_4640) ) / (node_3881 - node_1478))),Clouds);
                float node_3069 = (1.0 - cloudsSh);
                float node_2352 = (cracks*(1.0 - Water)*_CracksColor.a);
                float3 node_8639 = (_CloudsColor.rgb*node_6746);
                float3 diffuseColor = saturate((1.0-(1.0-lerp(saturate(min(node_5369,node_3069)),_CracksColor.rgb,node_2352))*(1.0-node_8639)));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse + specular;
                fixed4 finalRGBA = fixed4(finalColor * 1,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
