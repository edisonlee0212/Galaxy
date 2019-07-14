// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:False,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:2,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:38444,y:32785,varname:node_4013,prsc:2|spec-9816-OUT,gloss-1711-OUT,normal-9000-OUT,emission-5206-OUT,custl-6175-OUT;n:type:ShaderForge.SFN_NormalVector,id:9920,x:26023,y:31500,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:9399,x:27344,y:31245,varname:NormalMult1,prsc:0|A-5609-OUT,B-3304-OUT,C-5609-OUT,D-5609-OUT,E-5609-OUT;n:type:ShaderForge.SFN_Vector1,id:3304,x:27071,y:31261,varname:node_3304,prsc:2,v1:3.8416;n:type:ShaderForge.SFN_ComponentMask,id:4450,x:27511,y:31383,varname:NormalComp,prsc:0,cc1:0,cc2:1,cc3:2,cc4:-1|IN-9399-OUT;n:type:ShaderForge.SFN_Add,id:9808,x:27683,y:31393,varname:node_9808,prsc:2|A-4450-R,B-4450-G,C-4450-B;n:type:ShaderForge.SFN_Divide,id:5492,x:27870,y:31308,varname:node_5492,prsc:2|A-9399-OUT,B-9808-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:3787,x:29990,y:32561,ptovrint:False,ptlb:Height,ptin:_Height,varname:_Height,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:877a709325ffbb340a453962d119c2ca,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4507,x:30300,y:32678,varname:HeightZ,prsc:2,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False|UVIN-1781-OUT,TEX-3787-TEX;n:type:ShaderForge.SFN_Tex2d,id:6464,x:30300,y:32497,varname:HeightY,prsc:2,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False|UVIN-2437-OUT,TEX-3787-TEX;n:type:ShaderForge.SFN_Tex2d,id:9488,x:30300,y:32322,varname:HeightX,prsc:2,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False|UVIN-2026-OUT,TEX-3787-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:7343,x:30653,y:32384,cmnt:Height,varname:Height1,prsc:0,chbt:0|M-49-OUT,R-9488-A,G-6464-A,B-4507-A;n:type:ShaderForge.SFN_Rotator,id:8189,x:26936,y:32439,varname:UVRotY,prsc:2|UVIN-1164-OUT,ANG-2729-OUT;n:type:ShaderForge.SFN_Rotator,id:6439,x:26936,y:32269,varname:UVRotX,prsc:2|UVIN-7562-OUT,ANG-2564-OUT;n:type:ShaderForge.SFN_Rotator,id:1547,x:26883,y:32660,varname:UVRotZ,prsc:2|UVIN-4143-OUT,ANG-2090-OUT;n:type:ShaderForge.SFN_Multiply,id:2729,x:26745,y:32482,varname:node_2729,prsc:2|A-2564-OUT,B-1940-OUT;n:type:ShaderForge.SFN_Vector1,id:1940,x:26524,y:32594,varname:node_1940,prsc:2,v1:4;n:type:ShaderForge.SFN_Multiply,id:2090,x:26692,y:32732,varname:node_2090,prsc:2|A-2564-OUT,B-5087-OUT;n:type:ShaderForge.SFN_Vector1,id:5087,x:26471,y:32844,varname:node_5087,prsc:2,v1:8;n:type:ShaderForge.SFN_Panner,id:7180,x:27157,y:32199,varname:UVPanX,prsc:2,spu:0.7,spv:0|UVIN-6439-UVOUT,DIST-2564-OUT;n:type:ShaderForge.SFN_Panner,id:6591,x:27157,y:32375,varname:UVPanY,prsc:2,spu:0,spv:0.7|UVIN-8189-UVOUT,DIST-2564-OUT;n:type:ShaderForge.SFN_Panner,id:3685,x:27091,y:32614,varname:UVPanZ,prsc:2,spu:-0.7,spv:0.7|UVIN-1547-UVOUT,DIST-2564-OUT;n:type:ShaderForge.SFN_Set,id:2171,x:28243,y:31305,varname:Mask,prsc:2|IN-5492-OUT;n:type:ShaderForge.SFN_Get,id:49,x:30792,y:36547,varname:_Mask,prsc:0|IN-2171-OUT;n:type:ShaderForge.SFN_Set,id:9669,x:28019,y:32161,varname:UVX,prsc:2|IN-8181-OUT;n:type:ShaderForge.SFN_Set,id:4583,x:27993,y:32374,varname:UVY,prsc:2|IN-4538-OUT;n:type:ShaderForge.SFN_Set,id:268,x:28051,y:32595,varname:UVZ,prsc:2|IN-1979-OUT;n:type:ShaderForge.SFN_Get,id:2026,x:29042,y:33218,varname:_UVX,prsc:2|IN-9669-OUT;n:type:ShaderForge.SFN_Get,id:2437,x:29042,y:33311,varname:_UVY,prsc:2|IN-4583-OUT;n:type:ShaderForge.SFN_Get,id:1781,x:29042,y:33415,varname:_UVZ,prsc:2|IN-268-OUT;n:type:ShaderForge.SFN_Slider,id:2564,x:26282,y:32110,ptovrint:False,ptlb:RandomSeed,ptin:_RandomSeed,varname:_RandomSeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:106.7961,max:1000;n:type:ShaderForge.SFN_FragmentPosition,id:2254,x:25126,y:32594,varname:node_2254,prsc:2;n:type:ShaderForge.SFN_Transform,id:9950,x:25457,y:32594,varname:node_9950,prsc:2,tffrom:0,tfto:1|IN-6365-OUT;n:type:ShaderForge.SFN_Transform,id:57,x:26416,y:31490,varname:LocalNorm,prsc:0,tffrom:0,tfto:1|IN-4198-OUT;n:type:ShaderForge.SFN_Subtract,id:6365,x:25306,y:32594,varname:node_6365,prsc:2|A-2254-XYZ,B-9313-XYZ;n:type:ShaderForge.SFN_ObjectPosition,id:9313,x:25126,y:32727,varname:node_9313,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:5559,x:26000,y:32303,varname:node_5559,prsc:2,cc1:1,cc2:2,cc3:-1,cc4:-1|IN-1709-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8892,x:26000,y:32457,varname:_PolesPos,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-1709-OUT;n:type:ShaderForge.SFN_ComponentMask,id:6736,x:25947,y:32630,varname:node_6736,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1709-OUT;n:type:ShaderForge.SFN_Slider,id:568,x:25106,y:32403,ptovrint:False,ptlb:Size,ptin:_Size,varname:_Size,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1359223,max:1;n:type:ShaderForge.SFN_RemapRange,id:4104,x:25457,y:32405,varname:node_4104,prsc:2,frmn:0,frmx:1,tomn:0.1,tomx:5|IN-568-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1882,x:32311,y:32414,varname:HeightNormalized,prsc:2|IN-6714-OUT,IMIN-8617-OUT,IMAX-599-OUT,OMIN-6746-OUT,OMAX-2893-OUT;n:type:ShaderForge.SFN_Slider,id:8617,x:31793,y:32484,ptovrint:False,ptlb:WaterLevel,ptin:_WaterLevel,varname:_WaterLevel,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1,cur:0.1262136,max:1;n:type:ShaderForge.SFN_Vector1,id:599,x:32106,y:32540,varname:node_599,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:6746,x:32061,y:32793,varname:zero,prsc:1,v1:0;n:type:ShaderForge.SFN_Vector1,id:2893,x:32106,y:32566,varname:node_2893,prsc:2,v1:1;n:type:ShaderForge.SFN_OneMinus,id:786,x:32388,y:33816,varname:node_786,prsc:2|IN-6955-OUT;n:type:ShaderForge.SFN_Lerp,id:9607,x:34683,y:32383,cmnt:Add water,varname:node_9607,prsc:2|A-3523-OUT,B-3150-OUT,T-4363-OUT;n:type:ShaderForge.SFN_Color,id:201,x:32944,y:31986,ptovrint:False,ptlb:AtmosphereColor,ptin:_AtmosphereColor,varname:_AtmosphereColor,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1196755,c2:0.2736696,c3:0.8676471,c4:1;n:type:ShaderForge.SFN_Clamp01,id:89,x:32904,y:34140,varname:node_89,prsc:2|IN-6134-OUT;n:type:ShaderForge.SFN_Set,id:7925,x:33171,y:34140,varname:_water,prsc:2|IN-89-OUT;n:type:ShaderForge.SFN_Get,id:4363,x:34414,y:32446,varname:node_4363,prsc:2|IN-7925-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:3854,x:32489,y:32522,varname:oceanDepth,prsc:1|IN-6714-OUT,IMIN-2286-OUT,IMAX-8617-OUT,OMIN-6746-OUT,OMAX-9504-OUT;n:type:ShaderForge.SFN_Vector1,id:9504,x:32073,y:32900,varname:node_9504,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:2286,x:32332,y:32683,varname:minuszero,prsc:0,v1:-0.001;n:type:ShaderForge.SFN_Clamp01,id:3462,x:33102,y:32573,varname:node_3462,prsc:2|IN-9062-OUT;n:type:ShaderForge.SFN_Slider,id:1711,x:35124,y:34456,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:4285,x:34675,y:31415,varname:node_4285,prsc:2|A-1231-OUT,B-8812-OUT,C-8967-OUT;n:type:ShaderForge.SFN_Add,id:7112,x:34299,y:31567,varname:node_7112,prsc:2|A-4059-OUT,B-201-RGB;n:type:ShaderForge.SFN_Vector1,id:4059,x:34057,y:31666,varname:node_4059,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Clamp01,id:8812,x:34477,y:31567,varname:node_8812,prsc:2|IN-7112-OUT;n:type:ShaderForge.SFN_Tex2d,id:4221,x:33152,y:32968,ptovrint:False,ptlb:HeightGradient,ptin:_HeightGradient,varname:_HeightGradient,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False|UVIN-2400-OUT;n:type:ShaderForge.SFN_Append,id:2400,x:32965,y:32968,varname:heightGradientUV,prsc:2|A-6955-OUT,B-6825-OUT;n:type:ShaderForge.SFN_Vector1,id:6825,x:32751,y:33052,varname:node_6825,prsc:2,v1:0;n:type:ShaderForge.SFN_Clamp01,id:6955,x:30726,y:31778,varname:heightNormalized,prsc:2|IN-1882-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:9428,x:31447,y:37842,ptovrint:False,ptlb:Clouds,ptin:_Clouds,varname:_Clouds,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Lerp,id:8712,x:35440,y:32326,cmnt:Diffuse,varname:Diffuze,prsc:2|A-8635-OUT,B-7447-RGB,T-8619-OUT;n:type:ShaderForge.SFN_Get,id:8619,x:34925,y:32797,varname:node_8619,prsc:2|IN-9127-OUT;n:type:ShaderForge.SFN_Color,id:7447,x:34906,y:32576,ptovrint:False,ptlb:CloudsColor,ptin:_CloudsColor,varname:_CloudsColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Time,id:9728,x:30952,y:37913,varname:timeClouds,prsc:2;n:type:ShaderForge.SFN_Code,id:7712,x:31907,y:37357,varname:cloudsBlended,prsc:2,code:cwBwAGUAZQBkAD0AcwBwAGUAZQBkACoAMAAuADMAOwAKAGYAbABvAGEAdAAxACAAcwBpAG4AVABpAG0AZQAgAD0AIABmAHIAYQBjACgAcwBpAG4AKAB0AGkAbQBlAC4AeAAqAHMAcABlAGUAZAApACoAMAAuADAANQApADsACgBmAGwAbwBhAHQAMQAgAHMAaQBuAFQAaQBtAGUAMgAgAD0AIABmAHIAYQBjACgAcwBpAG4AKAB0AGkAbQBlAC4AeAAqAHMAcABlAGUAZAArADAALgA3ADgAKQAqADAALgAwADUAKQA7AAoAZgBsAG8AYQB0ADEAIABzAGkAbgBUAGkAbQBlADMAIAA9ACAAZgByAGEAYwAoAHMAaQBuACgAdABpAG0AZQAuAHgAKgBzAHAAZQBlAGQAKwAxAC4ANQA3ACkAKgAwAC4AMAA1ACkAOwAKAGYAbABvAGEAdAAxACAAcwBpAG4AVABpAG0AZQA0ACAAPQAgAGYAcgBhAGMAKABzAGkAbgAoAHQAaQBtAGUALgB4ACoAcwBwAGUAZQBkACsAMgAuADMANQApACoAMAAuADAANQApADsACgBmAGwAbwBhAHQAMQAgAGMAbABvAHUAZABzADEAIAA9ACAAdABlAHgAMgBEACgAdABlAHgALAAgAGYAbABvAGEAdAAyACgALQBVAFYALgByACsAZgByAGEAYwAoAHMAcABlAGUAZAAqAHQAaQBtAGUALgB4ACoAMAAuADAAMwA1ACsAMAAuADMAKQAsACAALQBVAFYALgBnACsAcwBpAG4AVABpAG0AZQAyACkAKQAuAHIAOwAKAGYAbABvAGEAdAAxACAAYwBsAG8AdQBkAHMAMgAgAD0AIAB0AGUAeAAyAEQAKAB0AGUAeAAsACAAZgBsAG8AYQB0ADIAKABVAFYALgByACsAZgByAGEAYwAoAHMAcABlAGUAZAAqAHQAaQBtAGUALgB4ACoAMAAuADAAMwApACwAVQBWAC4AZwArAHMAaQBuAFQAaQBtAGUAKQApAC4AcgA7AAoAZgBsAG8AYQB0ADEAIABjAGwAbwB1AGQAcwAzACAAPQAgAHQAZQB4ADIARAAoAHQAZQB4ACwAIABmAGwAbwBhAHQAMgAoAC0AVQBWAC4AcgAtAGYAcgBhAGMAKABzAHAAZQBlAGQAKgB0AGkAbQBlAC4AeAAqADAALgAwADMANQAtADAALgAzADUAKQAsAC0AVQBWAC4AZwArAHMAaQBuAFQAaQBtAGUAMwApACkALgByADsACgBmAGwAbwBhAHQAMQAgAGMAbABvAHUAZABzADQAIAA9ACAAdABlAHgAMgBEACgAdABlAHgALAAgAGYAbABvAGEAdAAyACgAVQBWAC4AcgAtAGYAcgBhAGMAKABzAHAAZQBlAGQAKgB0AGkAbQBlAC4AeAAqADAALgAwADMAKQAsAFUAVgAuAGcAKwBzAGkAbgBUAGkAbQBlADQAKQApAC4AcgA7AAoAaQBmACgAIABFACAAPQA9ACAAMQAuADAAKQANAAoAIAAgACAAIAByAGUAdAB1AHIAbgAoAHMAYQB0AHUAcgBhAHQAZQAoACgAMgAqAGMAbABvAHUAZABzADEAKwBjAGwAbwB1AGQAcwAyACsAMgAqAGMAbABvAHUAZABzADMAKwBjAGwAbwB1AGQAcwAyACkAKgAwAC4AMgA1ACkAKQA7AA0ACgBlAGwAcwBlAA0ACgAgACAAIAAgAHIAZQB0AHUAcgBuACgAcwBhAHQAdQByAGEAdABlACgAKAAyACoAYwBsAG8AdQBkAHMAMQAqAGMAbABvAHUAZABzADIAKwAyACoAYwBsAG8AdQBkAHMAMwAqAGMAbABvAHUAZABzADIAKQAqADAALgA1ACkAKQA7AAoA,output:0,fname:Clouds,width:720,height:244,input:1,input:0,input:12,input:0,input:8,input_1_label:UV,input_2_label:time,input_3_label:tex,input_4_label:speed,input_5_label:E|A-2828-UVOUT,B-9728-T,C-9428-TEX,D-5913-OUT,E-1528-OUT;n:type:ShaderForge.SFN_TexCoord,id:2828,x:31136,y:37343,varname:node_2828,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:5913,x:31290,y:38048,ptovrint:False,ptlb:CloudsSpeed,ptin:_CloudsSpeed,varname:_CloudsSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4368932,max:1;n:type:ShaderForge.SFN_Slider,id:8615,x:31833,y:37090,ptovrint:False,ptlb:CloudsAmount,ptin:_CloudsAmount,varname:_CloudsAmount,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Set,id:9127,x:33945,y:37510,varname:_clouds,prsc:2|IN-9660-OUT;n:type:ShaderForge.SFN_Clamp01,id:9432,x:33449,y:37306,varname:node_9432,prsc:2|IN-1523-OUT;n:type:ShaderForge.SFN_Code,id:4175,x:32010,y:38866,varname:cloudsShadowsBlended,prsc:2,code:cwBwAGUAZQBkAD0AcwBwAGUAZQBkACoAMAAuADMAOwAKAGYAbABvAGEAdAAxACAAcwBpAG4AVABpAG0AZQAgAD0AIABmAHIAYQBjACgAcwBpAG4AKAB0AGkAbQBlAC4AeAAqAHMAcABlAGUAZAApACoAMAAuADAANQApADsACgBmAGwAbwBhAHQAMQAgAHMAaQBuAFQAaQBtAGUAMgAgAD0AIABmAHIAYQBjACgAcwBpAG4AKAB0AGkAbQBlAC4AeAAqAHMAcABlAGUAZAArADAALgA3ADgAKQAqADAALgAwADUAKQA7AAoAZgBsAG8AYQB0ADEAIABzAGkAbgBUAGkAbQBlADMAIAA9ACAAZgByAGEAYwAoAHMAaQBuACgAdABpAG0AZQAuAHgAKgBzAHAAZQBlAGQAKwAxAC4ANQA3ACkAKgAwAC4AMAA1ACkAOwAKAGYAbABvAGEAdAAxACAAcwBpAG4AVABpAG0AZQA0ACAAPQAgAGYAcgBhAGMAKABzAGkAbgAoAHQAaQBtAGUALgB4ACoAcwBwAGUAZQBkACsAMgAuADMANQApACoAMAAuADAANQApADsACgBmAGwAbwBhAHQAMQAgAGMAbABvAHUAZABzADEAIAA9ACAAdABlAHgAMgBEAGIAaQBhAHMAKAB0AGUAeAAsACAAZgBsAG8AYQB0ADQAKAAtAFUAVgAuAHIAKwBmAHIAYQBjACgAcwBwAGUAZQBkACoAdABpAG0AZQAuAHgAKgAwAC4AMAAzADUAKwAwAC4AMwApACwAIAAtAFUAVgAuAGcAKwBzAGkAbgBUAGkAbQBlADIALAAwACwAMwApACkALgByADsACgBmAGwAbwBhAHQAMQAgAGMAbABvAHUAZABzADIAIAA9ACAAdABlAHgAMgBEAGIAaQBhAHMAKAB0AGUAeAAsACAAZgBsAG8AYQB0ADQAKABVAFYALgByACsAZgByAGEAYwAoAHMAcABlAGUAZAAqAHQAaQBtAGUALgB4ACoAMAAuADAAMwApACwAVQBWAC4AZwArAHMAaQBuAFQAaQBtAGUALAAwACwAMwApACkALgByADsACgBmAGwAbwBhAHQAMQAgAGMAbABvAHUAZABzADMAIAA9ACAAdABlAHgAMgBEAGIAaQBhAHMAKAB0AGUAeAAsACAAZgBsAG8AYQB0ADQAKAAtAFUAVgAuAHIALQBmAHIAYQBjACgAcwBwAGUAZQBkACoAdABpAG0AZQAuAHgAKgAwAC4AMAAzADUALQAwAC4AMwA1ACkALAAtAFUAVgAuAGcAKwBzAGkAbgBUAGkAbQBlADMALAAwACwAMwApACkALgByADsACgBmAGwAbwBhAHQAMQAgAGMAbABvAHUAZABzADQAIAA9ACAAdABlAHgAMgBEAGIAaQBhAHMAKAB0AGUAeAAsACAAZgBsAG8AYQB0ADQAKABVAFYALgByAC0AZgByAGEAYwAoAHMAcABlAGUAZAAqAHQAaQBtAGUALgB4ACoAMAAuADAAMwApACwAVQBWAC4AZwArAHMAaQBuAFQAaQBtAGUANAAsADAALAAzACkAKQAuAHIAOwAKAGkAZgAoACAARQAgAD0APQAgADEALgAwACkADQAKACAAIAAgACAAcgBlAHQAdQByAG4AKABzAGEAdAB1AHIAYQB0AGUAKAAoADIAKgBjAGwAbwB1AGQAcwAxACsAYwBsAG8AdQBkAHMAMgArADIAKgBjAGwAbwB1AGQAcwAzACsAYwBsAG8AdQBkAHMAMgApACoAMAAuADMAKQApADsADQAKAGUAbABzAGUADQAKACAAIAAgACAAcgBlAHQAdQByAG4AKABzAGEAdAB1AHIAYQB0AGUAKAAoADIAKgBjAGwAbwB1AGQAcwAxACoAYwBsAG8AdQBkAHMAMgArADIAKgBjAGwAbwB1AGQAcwAzACoAYwBsAG8AdQBkAHMAMgApACoAMAAuADUANQApACkAOwA=,output:0,fname:CloudsShadows,width:641,height:211,input:1,input:0,input:12,input:0,input:8,input_1_label:UV,input_2_label:time,input_3_label:tex,input_4_label:speed,input_5_label:E|A-6852-OUT,B-9728-T,C-9428-TEX,D-5913-OUT,E-1528-OUT;n:type:ShaderForge.SFN_TexCoord,id:6899,x:31338,y:38816,varname:node_6899,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Clamp01,id:4106,x:33521,y:38533,varname:node_4106,prsc:2|IN-9780-OUT;n:type:ShaderForge.SFN_LightVector,id:3363,x:30649,y:38284,varname:node_3363,prsc:2;n:type:ShaderForge.SFN_Tangent,id:1235,x:30649,y:38436,varname:node_1235,prsc:2;n:type:ShaderForge.SFN_Dot,id:7161,x:30879,y:38366,varname:node_7161,prsc:2,dt:0|A-3363-OUT,B-1235-OUT;n:type:ShaderForge.SFN_LightVector,id:7555,x:30649,y:38571,varname:node_7555,prsc:2;n:type:ShaderForge.SFN_Bitangent,id:1830,x:30649,y:38713,varname:node_1830,prsc:2;n:type:ShaderForge.SFN_Dot,id:2402,x:30885,y:38638,varname:node_2402,prsc:2,dt:0|A-7555-OUT,B-1830-OUT;n:type:ShaderForge.SFN_Append,id:6759,x:31085,y:38502,varname:node_6759,prsc:2|A-7161-OUT,B-2402-OUT;n:type:ShaderForge.SFN_Add,id:6852,x:31526,y:38599,varname:node_6852,prsc:2|A-7327-OUT,B-6899-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7327,x:31340,y:38467,varname:node_7327,prsc:2|A-1658-OUT,B-6759-OUT;n:type:ShaderForge.SFN_Vector1,id:5031,x:31198,y:38271,varname:node_5031,prsc:2,v1:0.02;n:type:ShaderForge.SFN_Set,id:3132,x:33990,y:38510,varname:_cloudsShadows,prsc:2|IN-8412-OUT;n:type:ShaderForge.SFN_Get,id:747,x:33657,y:34022,varname:node_747,prsc:2|IN-3132-OUT;n:type:ShaderForge.SFN_OneMinus,id:7965,x:34030,y:33966,varname:node_7965,prsc:2|IN-931-OUT;n:type:ShaderForge.SFN_Multiply,id:8635,x:35162,y:32230,cmnt:Clouds Shadows,varname:node_8635,prsc:2|A-2869-OUT,B-7965-OUT;n:type:ShaderForge.SFN_Multiply,id:931,x:33847,y:34022,varname:node_931,prsc:2|A-747-OUT,B-6007-OUT;n:type:ShaderForge.SFN_Vector1,id:6007,x:33632,y:34210,varname:node_6007,prsc:2,v1:0.7;n:type:ShaderForge.SFN_Slider,id:4964,x:34944,y:33758,ptovrint:False,ptlb:CloudsHeight,ptin:_CloudsHeight,varname:_CloudsHeight,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2055926,max:1;n:type:ShaderForge.SFN_Multiply,id:1658,x:31410,y:38341,varname:node_1658,prsc:2|A-5031-OUT,B-4964-OUT;n:type:ShaderForge.SFN_Power,id:8412,x:33821,y:38510,varname:node_8412,prsc:2|VAL-4106-OUT,EXP-771-OUT;n:type:ShaderForge.SFN_Power,id:9660,x:33734,y:37510,varname:node_9660,prsc:2|VAL-9432-OUT,EXP-6545-OUT;n:type:ShaderForge.SFN_Slider,id:1677,x:33069,y:37687,ptovrint:False,ptlb:CloudsSpread,ptin:_CloudsSpread,varname:_CloudsSpread,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:6545,x:33483,y:37590,varname:node_6545,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0.5|IN-1677-OUT;n:type:ShaderForge.SFN_RemapRange,id:771,x:33521,y:38371,varname:node_771,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0.5|IN-1677-OUT;n:type:ShaderForge.SFN_Lerp,id:9816,x:34916,y:31499,cmnt:Spec,varname:node_9816,prsc:2|A-4285-OUT,B-6923-OUT,T-6691-OUT;n:type:ShaderForge.SFN_Vector1,id:6923,x:34700,y:31653,varname:node_6923,prsc:2,v1:0;n:type:ShaderForge.SFN_Get,id:6691,x:34721,y:31871,varname:node_6691,prsc:2|IN-9127-OUT;n:type:ShaderForge.SFN_OneMinus,id:8433,x:32253,y:38299,varname:oneMinusCloudsAmount,prsc:2|IN-8615-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:5544,x:29213,y:36368,ptovrint:False,ptlb:Normal,ptin:_Normal,varname:_Normal,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:877a709325ffbb340a453962d119c2ca,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:4678,x:29776,y:36091,varname:NormalX,prsc:2,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False|UVIN-2026-OUT,TEX-5544-TEX;n:type:ShaderForge.SFN_Tex2d,id:7295,x:29776,y:36266,varname:NormalY,prsc:2,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False|UVIN-2437-OUT,TEX-5544-TEX;n:type:ShaderForge.SFN_Tex2d,id:5802,x:29776,y:36439,varname:NormalZ,prsc:2,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False|UVIN-1781-OUT,TEX-5544-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:6727,x:32300,y:34830,varname:normalsBlended,prsc:2,chbt:0|M-49-OUT,R-6531-OUT,G-4952-OUT,B-2016-OUT;n:type:ShaderForge.SFN_RemapRange,id:4143,x:26191,y:32641,varname:node_4143,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-6736-OUT;n:type:ShaderForge.SFN_RemapRange,id:1164,x:26191,y:32429,varname:_PolesPos1,prsc:1,frmn:-1,frmx:1,tomn:0,tomx:1|IN-8892-OUT;n:type:ShaderForge.SFN_RemapRange,id:7562,x:26191,y:32267,varname:node_7562,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-5559-OUT;n:type:ShaderForge.SFN_Code,id:9631,x:31140,y:35848,varname:node_9631,prsc:2,code:ZgBsAG8AYQB0ACAAbgB4ACAAPQAgAE4AbwByAG0AYQBsAC4AeAA7AA0ACgBmAGwAbwBhAHQAIABuAHkAIAA9ACAATgBvAHIAbQBhAGwALgB5ADsADQAKAGYAbABvAGEAdAAgAG4AegAgAD0AIABOAG8AcgBtAGEAbAAuAHoAOwANAAoADQAKAGYAbABvAGEAdAAgAGEAPQBBAG4AZwBsAGUAOwANAAoACgBmAGwAbwBhAHQAIABjAGEAPQBjAG8AcwAoAGEAKQA7AA0ACgBmAGwAbwBhAHQAIABzAGEAPQBzAGkAbgAoAGEAKQA7AA0ACgBmAGwAbwBhAHQAMwAgAHIATgA9AGYAbABvAGEAdAAzACgAYwBhACoAbgB4AC0AcwBhACoAbgB5ACwAcwBhACoAbgB4ACsAYwBhACoAbgB5ACwAbgB6ACkAOwAKAAoACgANAAoAcgBlAHQAdQByAG4AIAByAE4AOwA=,output:2,fname:Rotate3,width:335,height:233,input:2,input:0,input_1_label:Normal,input_2_label:Angle|A-9044-OUT,B-2852-OUT;n:type:ShaderForge.SFN_Code,id:8871,x:31141,y:35623,varname:node_8871,prsc:2,code:ZgBsAG8AYQB0ACAAbgB4ACAAPQAgAE4AbwByAG0AYQBsAC4AeAA7AA0ACgBmAGwAbwBhAHQAIABuAHkAIAA9ACAATgBvAHIAbQBhAGwALgB5ADsADQAKAGYAbABvAGEAdAAgAG4AegAgAD0AIABOAG8AcgBtAGEAbAAuAHoAOwANAAoAZgBsAG8AYQB0ACAAYQA9AEEAbgBnAGwAZQA7AA0ACgANAAoAZgBsAG8AYQB0ACAAYwBhAD0AYwBvAHMAKABhACkAOwANAAoAZgBsAG8AYQB0ACAAcwBhAD0AcwBpAG4AKABhACkAOwANAAoAZgBsAG8AYQB0ADMAIAByAE4APQBmAGwAbwBhAHQAMwAoAGMAYQAqAG4AeAAtAHMAYQAqAG4AeQAsAHMAYQAqAG4AeAArAGMAYQAqAG4AeQAsAG4AegApADsADQAKAHIATgA9AHIATgAuAHkAeAB6ADsACgAKAHIAZQB0AHUAcgBuACAAcgBOADsA,output:2,fname:Rotate2,width:332,height:190,input:2,input:0,input_1_label:Normal,input_2_label:Angle|A-1384-OUT,B-1120-OUT;n:type:ShaderForge.SFN_Code,id:2345,x:31143,y:35263,varname:node_2345,prsc:2,code:DQAKAGYAbABvAGEAdAAgAG4AeAAgAD0AIABOAG8AcgBtAGEAbAAuAHgAOwANAAoAZgBsAG8AYQB0ACAAbgB5ACAAPQAgAE4AbwByAG0AYQBsAC4AeQA7AA0ACgBmAGwAbwBhAHQAIABuAHoAIAA9ACAATgBvAHIAbQBhAGwALgB6ADsADQAKAA0ACgBmAGwAbwBhAHQAIABhAD0AQQBuAGcAbABlADsADQAKAAoADQAKAGYAbABvAGEAdAAgAGMAYQA9AGMAbwBzACgAYQApADsADQAKAGYAbABvAGEAdAAgAHMAYQA9AHMAaQBuACgAYQApADsADQAKAGYAbABvAGEAdAAzACAAcgBOAD0AZgBsAG8AYQB0ADMAKABjAGEAKgBuAHgALQBzAGEAKgBuAHkALABzAGEAKgBuAHgAKwBjAGEAKgBuAHkALABuAHoAKQA7AA0ACgAKAHIATgA9AHIATgAuAHkAeAB6ADsACgAKAHIAZQB0AHUAcgBuACAAcgBOADsA,output:2,fname:Rotate,width:344,height:228,input:2,input:0,input_1_label:Normal,input_2_label:Angle|A-8038-OUT,B-2564-OUT;n:type:ShaderForge.SFN_Code,id:6531,x:31662,y:35476,varname:node_6531,prsc:2,code:ZgBsAG8AYQB0ADMAIAB4AE4AbwByAG0AIAA9AG4AbwByAG0AYQBsAGkAegBlACgAaABhAGwAZgAzACgAbgBvAHIAbQAuAHgAeQAgACAAKwAgAG4AbwByAG0ARABpAHIALgB6AHkALAAgAG4AbwByAG0ARABpAHIALgB4ACkAKQA7AA0ACgANAAoAeABOAG8AcgBtAD0AeABOAG8AcgBtAC4AegB5AHgAOwANAAoAcgBlAHQAdQByAG4AIAB4AE4AbwByAG0AOwA=,output:2,fname:normX,width:490,height:112,input:2,input:2,input_1_label:norm,input_2_label:normDir|A-2345-OUT,B-5609-OUT;n:type:ShaderForge.SFN_Code,id:4952,x:31662,y:35626,varname:node_4952,prsc:2,code:ZgBsAG8AYQB0ADMAIAB5AE4AbwByAG0AIAA9ACAAbgBvAHIAbQBhAGwAaQB6AGUAKABoAGEAbABmADMAKABuAG8AcgBtAC4AeAB5ACAAKwAgAG4AbwByAG0ARABpAHIALgB6AHgALAAgAG4AbwByAG0ARABpAHIALgB5ACkAKQA7AA0ACgANAAoAeQBOAG8AcgBtAD0AeQBOAG8AcgBtAC4AeQB6AHgAOwANAAoAcgBlAHQAdQByAG4AIAB5AE4AbwByAG0AOwA=,output:2,fname:normYX,width:502,height:112,input:2,input:2,input_1_label:norm,input_2_label:normDir|A-8871-OUT,B-5609-OUT;n:type:ShaderForge.SFN_Code,id:2016,x:31662,y:35773,varname:node_2016,prsc:2,code:ZgBsAG8AYQB0ADMAIAB6AE4AbwByAG0AIAA9ACAAbgBvAHIAbQBhAGwAaQB6AGUAKABoAGEAbABmADMAKABuAG8AcgBtAC4AeAB5ACAAIAArACAAbgBvAHIAbQBEAGkAcgAuAHgAeQAsACAAbgBvAHIAbQBEAGkAcgAuAHoAKQApADsADQAKAHIAZQB0AHUAcgBuACAAegBOAG8AcgBtADsA,output:2,fname:normXZ,width:492,height:112,input:2,input:2,input_1_label:norm,input_2_label:normDir|A-9631-OUT,B-5609-OUT;n:type:ShaderForge.SFN_Multiply,id:1120,x:30290,y:35655,varname:node_1120,prsc:2|A-2564-OUT,B-2266-OUT;n:type:ShaderForge.SFN_Vector1,id:2266,x:30074,y:35714,varname:node_2266,prsc:2,v1:4;n:type:ShaderForge.SFN_Multiply,id:2852,x:30290,y:35818,varname:node_2852,prsc:2|A-2564-OUT,B-2054-OUT;n:type:ShaderForge.SFN_Vector1,id:2054,x:30046,y:35886,varname:node_2054,prsc:2,v1:8;n:type:ShaderForge.SFN_Lerp,id:9000,x:33300,y:34960,cmnt:Norm,varname:node_9000,prsc:2|A-4464-OUT,B-189-OUT,T-5092-OUT;n:type:ShaderForge.SFN_Get,id:4704,x:32753,y:35285,varname:node_4704,prsc:2|IN-7925-OUT;n:type:ShaderForge.SFN_Get,id:8323,x:32753,y:35351,varname:node_8323,prsc:2|IN-9127-OUT;n:type:ShaderForge.SFN_Max,id:5092,x:33359,y:35332,varname:node_5092,prsc:2|A-5507-OUT,B-8323-OUT;n:type:ShaderForge.SFN_NormalVector,id:189,x:32975,y:35011,prsc:2,pt:False;n:type:ShaderForge.SFN_Transform,id:9621,x:32639,y:34772,varname:node_9621,prsc:2,tffrom:1,tfto:0|IN-6727-OUT;n:type:ShaderForge.SFN_Multiply,id:8038,x:30966,y:35252,varname:node_8038,prsc:2|A-2493-OUT,B-4678-RGB,C-4006-OUT;n:type:ShaderForge.SFN_Slider,id:2493,x:30396,y:35611,ptovrint:False,ptlb:Relief,ptin:_Relief,varname:_Relief,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.3980583,max:1;n:type:ShaderForge.SFN_Multiply,id:1384,x:30933,y:35678,varname:node_1384,prsc:2|A-2493-OUT,B-7295-RGB,C-4006-OUT;n:type:ShaderForge.SFN_Multiply,id:9044,x:30912,y:35844,varname:node_9044,prsc:2|A-2493-OUT,B-5802-RGB,C-4006-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:7528,x:30402,y:32898,ptovrint:False,ptlb:FertilityMap,ptin:_FertilityMap,varname:_FertilityMap,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:7077,x:30632,y:33147,varname:VegetationZ,prsc:1,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-1781-OUT,TEX-7528-TEX;n:type:ShaderForge.SFN_Tex2d,id:7319,x:30632,y:32962,varname:VegetationY,prsc:1,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-2437-OUT,TEX-7528-TEX;n:type:ShaderForge.SFN_Tex2d,id:799,x:30577,y:32762,varname:VegetationX,prsc:1,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-2026-OUT,TEX-7528-TEX;n:type:ShaderForge.SFN_Color,id:3834,x:32572,y:33462,ptovrint:False,ptlb:Vegetation,ptin:_Vegetation,varname:_Vegetation,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0.097,c3:0.004462,c4:1;n:type:ShaderForge.SFN_Clamp01,id:1186,x:33422,y:31583,varname:PlantsMask,prsc:1|IN-1324-OUT;n:type:ShaderForge.SFN_ChannelBlend,id:4117,x:31800,y:32059,varname:node_4117,prsc:2,chbt:0|M-49-OUT,R-799-A,G-7319-A,B-7077-A;n:type:ShaderForge.SFN_Multiply,id:8785,x:31771,y:31944,varname:node_8785,prsc:2|A-6955-OUT,B-5265-OUT;n:type:ShaderForge.SFN_Vector1,id:5265,x:31524,y:31944,varname:node_5265,prsc:2,v1:-0.3;n:type:ShaderForge.SFN_Add,id:454,x:32039,y:32040,varname:node_454,prsc:2|A-4117-OUT,B-8785-OUT;n:type:ShaderForge.SFN_Slider,id:4367,x:31668,y:31737,ptovrint:True,ptlb:Fertility,ptin:_Fertility,varname:_Fertility,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6116505,max:1;n:type:ShaderForge.SFN_Normalize,id:4198,x:26215,y:31507,varname:node_4198,prsc:2|IN-9920-OUT;n:type:ShaderForge.SFN_Normalize,id:5609,x:26657,y:31476,varname:NormalsLocalNormalized,prsc:2|IN-57-XYZ;n:type:ShaderForge.SFN_Normalize,id:4464,x:32878,y:34772,varname:node_4464,prsc:2|IN-9621-XYZ;n:type:ShaderForge.SFN_Clamp01,id:3150,x:34176,y:32142,varname:node_3150,prsc:2|IN-1542-OUT;n:type:ShaderForge.SFN_Multiply,id:6714,x:31116,y:32322,varname:Height,prsc:1|A-8691-OUT,B-7343-OUT;n:type:ShaderForge.SFN_Vector1,id:8691,x:30916,y:32525,varname:node_8691,prsc:2,v1:1;n:type:ShaderForge.SFN_Negate,id:8762,x:32425,y:37074,varname:CloudsAmounbtNeg,prsc:1|IN-7522-OUT;n:type:ShaderForge.SFN_Add,id:5209,x:32903,y:37179,varname:node_5209,prsc:2|A-8762-OUT,B-7712-OUT;n:type:ShaderForge.SFN_OneMinus,id:7522,x:32246,y:37074,varname:node_7522,prsc:2|IN-8615-OUT;n:type:ShaderForge.SFN_Negate,id:5606,x:32549,y:38488,varname:node_5606,prsc:2|IN-8433-OUT;n:type:ShaderForge.SFN_Add,id:4392,x:32819,y:38671,varname:node_4392,prsc:2|A-4175-OUT,B-5606-OUT;n:type:ShaderForge.SFN_RemapRange,id:9557,x:32067,y:31832,varname:node_9557,prsc:1,frmn:0,frmx:1,tomn:-1,tomx:0.6|IN-4367-OUT;n:type:ShaderForge.SFN_Vector1,id:9820,x:32408,y:31239,varname:zero4,prsc:1,v1:0;n:type:ShaderForge.SFN_Slider,id:7302,x:31960,y:32172,ptovrint:False,ptlb:VegetationContrast,ptin:_VegetationContrast,varname:_VegetationContrast,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1279525,max:0.5;n:type:ShaderForge.SFN_Add,id:5189,x:32916,y:33463,varname:sd,prsc:1|A-4412-OUT,B-3834-RGB;n:type:ShaderForge.SFN_Multiply,id:4412,x:32659,y:33712,varname:node_4412,prsc:2|A-5054-OUT,B-6955-OUT;n:type:ShaderForge.SFN_Vector1,id:5054,x:32463,y:33665,varname:node_5054,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Clamp01,id:223,x:33133,y:33463,varname:VegetationColor,prsc:1|IN-5189-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:6134,x:32744,y:34104,varname:node_6134,prsc:2|IN-786-OUT,IMIN-7544-OUT,IMAX-2641-OUT,OMIN-6746-OUT,OMAX-3562-OUT;n:type:ShaderForge.SFN_Vector1,id:2641,x:32388,y:34246,varname:node_2641,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:6211,x:31555,y:31541,varname:zero5,prsc:0,v1:0;n:type:ShaderForge.SFN_Vector1,id:3562,x:32388,y:34401,varname:node_3562,prsc:2,v1:1;n:type:ShaderForge.SFN_ComponentMask,id:4886,x:28676,y:30539,varname:normalY,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-5609-OUT;n:type:ShaderForge.SFN_Multiply,id:4986,x:31406,y:31666,varname:node_4986,prsc:2|A-9214-OUT,B-6955-OUT;n:type:ShaderForge.SFN_Vector1,id:9214,x:31236,y:31656,varname:node_9214,prsc:2,v1:0.35;n:type:ShaderForge.SFN_Slider,id:2334,x:28583,y:29376,ptovrint:False,ptlb:Frost,ptin:_Frost,varname:_Frost,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-0.51,cur:-0.407767,max:3;n:type:ShaderForge.SFN_RemapRange,id:4951,x:32016,y:31324,varname:node_4951,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:0.3|IN-394-OUT;n:type:ShaderForge.SFN_Clamp01,id:2661,x:31650,y:28443,cmnt:Frezing,varname:Freezing,prsc:1|IN-9956-OUT;n:type:ShaderForge.SFN_OneMinus,id:3784,x:31598,y:30493,varname:node_3784,prsc:2|IN-6110-OUT;n:type:ShaderForge.SFN_Add,id:7828,x:32395,y:30508,varname:node_7828,prsc:2|A-3784-OUT,B-2572-OUT;n:type:ShaderForge.SFN_Multiply,id:4113,x:31968,y:30589,varname:node_4113,prsc:2|A-3764-OUT,B-6955-OUT;n:type:ShaderForge.SFN_Vector1,id:3764,x:31771,y:30578,varname:node_3764,prsc:2,v1:-0.5;n:type:ShaderForge.SFN_RemapRange,id:4966,x:31968,y:30765,varname:node_4966,prsc:2,frmn:0.4,frmx:1,tomn:0,tomx:1.5|IN-6063-OUT;n:type:ShaderForge.SFN_Clamp01,id:9588,x:32642,y:30560,cmnt:Heat,varname:Heat,prsc:2|IN-7828-OUT;n:type:ShaderForge.SFN_Slider,id:8967,x:34292,y:31181,ptovrint:False,ptlb:Specularity,ptin:_Specularity,varname:_Specularity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1650485,max:1;n:type:ShaderForge.SFN_Lerp,id:2869,x:34900,y:32118,cmnt:Add Frost,varname:node_2869,prsc:2|A-9607-OUT,B-4884-OUT,T-2661-OUT;n:type:ShaderForge.SFN_RemapRange,id:2422,x:32555,y:31554,varname:node_2422,prsc:2,frmn:0.3,frmx:0.65,tomn:0,tomx:1|IN-8930-OUT;n:type:ShaderForge.SFN_Clamp01,id:4629,x:32795,y:31571,varname:node_4629,prsc:2|IN-2422-OUT;n:type:ShaderForge.SFN_Multiply,id:1324,x:33232,y:31571,varname:node_1324,prsc:2|A-4171-OUT,B-691-OUT;n:type:ShaderForge.SFN_OneMinus,id:4171,x:32977,y:31571,varname:node_4171,prsc:2|IN-4629-OUT;n:type:ShaderForge.SFN_Multiply,id:6529,x:33972,y:31384,varname:node_6529,prsc:2|A-2648-OUT,B-2661-OUT;n:type:ShaderForge.SFN_Vector1,id:2648,x:33780,y:31326,varname:node_2648,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Add,id:6393,x:34158,y:31384,varname:node_6393,prsc:2|A-6529-OUT,B-6011-OUT;n:type:ShaderForge.SFN_Get,id:5565,x:33742,y:31482,varname:node_5565,prsc:2|IN-7925-OUT;n:type:ShaderForge.SFN_Multiply,id:6011,x:33972,y:31532,varname:node_6011,prsc:2|A-5565-OUT,B-2831-OUT;n:type:ShaderForge.SFN_Vector1,id:2831,x:33763,y:31566,varname:node_2831,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Lerp,id:1231,x:34385,y:31314,varname:node_1231,prsc:2|A-703-OUT,B-6393-OUT,T-2661-OUT;n:type:ShaderForge.SFN_Get,id:703,x:34158,y:31272,varname:node_703,prsc:2|IN-7925-OUT;n:type:ShaderForge.SFN_OneMinus,id:3565,x:32800,y:35134,varname:node_3565,prsc:2|IN-2661-OUT;n:type:ShaderForge.SFN_Multiply,id:5507,x:33149,y:35234,varname:node_5507,prsc:2|A-3565-OUT,B-4704-OUT;n:type:ShaderForge.SFN_Get,id:7174,x:29957,y:35423,varname:node_7174,prsc:2|IN-7925-OUT;n:type:ShaderForge.SFN_Multiply,id:8573,x:30184,y:35387,varname:node_8573,prsc:2|A-9064-OUT,B-7174-OUT;n:type:ShaderForge.SFN_Vector1,id:9064,x:29957,y:35363,varname:node_9064,prsc:2,v1:0.7;n:type:ShaderForge.SFN_OneMinus,id:4006,x:30417,y:35387,varname:WaterRelief,prsc:2|IN-8573-OUT;n:type:ShaderForge.SFN_RemapRange,id:1980,x:32160,y:36901,varname:node_1980,prsc:2,frmn:0.7,frmx:0.9,tomn:1,tomx:0|IN-6110-OUT;n:type:ShaderForge.SFN_Multiply,id:5000,x:33099,y:37107,varname:node_5000,prsc:2|A-5209-OUT,B-1588-OUT;n:type:ShaderForge.SFN_Clamp01,id:1588,x:32322,y:36901,varname:PolesCaps,prsc:0|IN-1980-OUT;n:type:ShaderForge.SFN_Multiply,id:3311,x:33200,y:38507,varname:node_3311,prsc:2|A-1588-OUT,B-4392-OUT;n:type:ShaderForge.SFN_Add,id:8930,x:32257,y:31520,varname:node_8930,prsc:2|A-4951-OUT,B-6110-OUT,C-4986-OUT;n:type:ShaderForge.SFN_Multiply,id:1709,x:25701,y:32423,varname:PosScaled,prsc:2|A-4104-OUT,B-9950-XYZ;n:type:ShaderForge.SFN_Lerp,id:2184,x:34173,y:31810,varname:node_2184,prsc:2|A-3607-OUT,B-7627-OUT,T-6714-OUT;n:type:ShaderForge.SFN_Vector1,id:7627,x:33855,y:31884,varname:node_7627,prsc:2,v1:1;n:type:ShaderForge.SFN_LightAttenuation,id:9207,x:36508,y:34320,varname:node_9207,prsc:2;n:type:ShaderForge.SFN_LightColor,id:2734,x:36508,y:34186,varname:node_2734,prsc:2;n:type:ShaderForge.SFN_LightVector,id:2045,x:35632,y:33888,varname:node_2045,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:4237,x:35632,y:34016,prsc:2,pt:True;n:type:ShaderForge.SFN_HalfVector,id:5344,x:35632,y:34167,varname:node_5344,prsc:2;n:type:ShaderForge.SFN_Dot,id:9503,x:35844,y:33919,cmnt:Lambert,varname:Lightside,prsc:2,dt:1|A-2045-OUT,B-4237-OUT;n:type:ShaderForge.SFN_Dot,id:3102,x:35844,y:34105,cmnt:Blinn-Phong,varname:node_3102,prsc:2,dt:1|A-4237-OUT,B-5344-OUT;n:type:ShaderForge.SFN_Multiply,id:6407,x:36322,y:34097,cmnt:Specular Contribution,varname:node_6407,prsc:2|A-9503-OUT,B-693-OUT,C-9816-OUT,D-688-OUT;n:type:ShaderForge.SFN_Multiply,id:7346,x:36269,y:33927,cmnt:Diffuse Contribution,varname:node_7346,prsc:2|A-8712-OUT,B-9503-OUT;n:type:ShaderForge.SFN_Exp,id:7242,x:35844,y:34288,varname:node_7242,prsc:2,et:0|IN-6638-OUT;n:type:ShaderForge.SFN_Power,id:693,x:36047,y:34142,varname:node_693,prsc:2|VAL-3102-OUT,EXP-7242-OUT;n:type:ShaderForge.SFN_Add,id:5169,x:36508,y:34046,cmnt:Combine,varname:node_5169,prsc:2|A-7346-OUT,B-6407-OUT;n:type:ShaderForge.SFN_Multiply,id:7811,x:36753,y:34186,cmnt:Attenuate and Color,varname:node_7811,prsc:2|A-5169-OUT,B-2734-RGB,C-9207-OUT;n:type:ShaderForge.SFN_ConstantLerp,id:6638,x:35632,y:34290,varname:node_6638,prsc:2,a:1,b:11|IN-1711-OUT;n:type:ShaderForge.SFN_AmbientLight,id:4147,x:36196,y:33173,varname:node_4147,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3743,x:36450,y:33125,cmnt:Ambient Light,varname:node_3743,prsc:2|A-8712-OUT,B-4147-RGB;n:type:ShaderForge.SFN_Slider,id:5889,x:36510,y:33952,ptovrint:False,ptlb:Ambient,ptin:_Ambient,varname:_Ambient,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:9272,x:34454,y:31780,varname:node_9272,prsc:2|A-2184-OUT,B-2661-OUT;n:type:ShaderForge.SFN_Vector1,id:7552,x:29760,y:30412,varname:node_7552,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:1790,x:30196,y:30077,varname:node_1790,prsc:2|A-6714-OUT,B-7552-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:1536,x:30639,y:29245,varname:node_1536,prsc:2|IN-9532-OUT,IMIN-2939-OUT,IMAX-1767-OUT,OMIN-6211-OUT,OMAX-5965-OUT;n:type:ShaderForge.SFN_Subtract,id:2939,x:30322,y:29114,varname:IminFrostContrast,prsc:1|A-1939-OUT,B-2746-OUT;n:type:ShaderForge.SFN_Vector1,id:1939,x:29978,y:29051,varname:node_1939,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:1767,x:30337,y:29362,varname:node_1767,prsc:2|A-9051-OUT,B-1230-OUT;n:type:ShaderForge.SFN_OneMinus,id:4750,x:29978,y:29208,varname:node_4750,prsc:2|IN-5836-OUT;n:type:ShaderForge.SFN_Multiply,id:2746,x:30151,y:29220,varname:node_2746,prsc:2|A-4750-OUT,B-8831-OUT;n:type:ShaderForge.SFN_Vector1,id:8831,x:29978,y:29353,varname:node_8831,prsc:2,v1:0.5;n:type:ShaderForge.SFN_OneMinus,id:8353,x:29986,y:29524,varname:node_8353,prsc:2|IN-5836-OUT;n:type:ShaderForge.SFN_Multiply,id:1230,x:30159,y:29536,varname:node_1230,prsc:2|A-8353-OUT,B-1829-OUT;n:type:ShaderForge.SFN_Vector1,id:1829,x:29986,y:29669,varname:node_1829,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:9051,x:29986,y:29466,varname:node_9051,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:5965,x:30492,y:29422,varname:node_5965,prsc:2,v1:1;n:type:ShaderForge.SFN_Blend,id:872,x:31015,y:29227,varname:PolesReachMao,prsc:1,blmd:10,clmp:False|SRC-6283-OUT,DST-26-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:9956,x:31240,y:28438,varname:node_9956,prsc:2|IN-872-OUT,IMIN-1167-OUT,IMAX-7666-OUT,OMIN-6211-OUT,OMAX-7437-OUT;n:type:ShaderForge.SFN_Subtract,id:1167,x:30923,y:28307,varname:PolesContrastIMin,prsc:1|A-6997-OUT,B-3616-OUT;n:type:ShaderForge.SFN_Vector1,id:6997,x:30579,y:28244,varname:node_6997,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Add,id:7666,x:30938,y:28555,varname:node_7666,prsc:2|A-8352-OUT,B-8213-OUT;n:type:ShaderForge.SFN_OneMinus,id:2678,x:30579,y:28401,varname:node_2678,prsc:2|IN-2523-OUT;n:type:ShaderForge.SFN_Multiply,id:3616,x:30752,y:28413,varname:node_3616,prsc:2|A-2678-OUT,B-5367-OUT;n:type:ShaderForge.SFN_Vector1,id:5367,x:30579,y:28546,varname:node_5367,prsc:2,v1:0.5;n:type:ShaderForge.SFN_OneMinus,id:8135,x:30587,y:28717,varname:node_8135,prsc:2|IN-2523-OUT;n:type:ShaderForge.SFN_Multiply,id:8213,x:30760,y:28729,varname:node_8213,prsc:2|A-8135-OUT,B-5332-OUT;n:type:ShaderForge.SFN_Vector1,id:5332,x:30587,y:28862,varname:node_5332,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:8352,x:30587,y:28659,varname:node_8352,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Vector1,id:7437,x:31093,y:28615,varname:node_7437,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:9532,x:29840,y:28894,varname:node_9532,prsc:2|A-4838-OUT,B-6110-OUT;n:type:ShaderForge.SFN_RemapRange,id:5836,x:29435,y:29541,varname:polesContrast,prsc:1,frmn:-0.5,frmx:2,tomn:0.95,tomx:-3|IN-2334-OUT;n:type:ShaderForge.SFN_Add,id:2572,x:32137,y:30649,varname:node_2572,prsc:2|A-4113-OUT,B-4966-OUT;n:type:ShaderForge.SFN_NormalVector,id:4347,x:35644,y:34597,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:3892,x:35856,y:34512,cmnt:Lambert,varname:LightSide,prsc:1,dt:2|A-111-OUT,B-4347-OUT;n:type:ShaderForge.SFN_LightVector,id:111,x:35644,y:34469,varname:node_111,prsc:2;n:type:ShaderForge.SFN_Clamp01,id:394,x:31511,y:29926,cmnt:PlantsFrost,varname:node_394,prsc:2|IN-517-OUT;n:type:ShaderForge.SFN_Subtract,id:517,x:31334,y:29245,varname:node_517,prsc:2|A-872-OUT,B-6978-OUT;n:type:ShaderForge.SFN_Slider,id:4751,x:30517,y:29705,ptovrint:False,ptlb:VegetationFrostResistance,ptin:_VegetationFrostResistance,varname:_VegetationFrostResistance,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4563107,max:1;n:type:ShaderForge.SFN_Negate,id:6978,x:31195,y:29625,varname:node_6978,prsc:2|IN-2512-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:691,x:32607,y:32008,varname:node_691,prsc:2|IN-6763-OUT,IMIN-7302-OUT,IMAX-4334-OUT,OMIN-9820-OUT,OMAX-83-OUT;n:type:ShaderForge.SFN_OneMinus,id:4334,x:32311,y:32189,varname:node_4334,prsc:2|IN-7302-OUT;n:type:ShaderForge.SFN_Add,id:6406,x:32282,y:31883,varname:node_6406,prsc:2|A-9557-OUT,B-454-OUT;n:type:ShaderForge.SFN_Vector1,id:83,x:32473,y:32189,varname:node_83,prsc:2,v1:1;n:type:ShaderForge.SFN_OneMinus,id:2512,x:31038,y:29625,varname:node_2512,prsc:2|IN-470-OUT;n:type:ShaderForge.SFN_RemapRange,id:470,x:30890,y:29625,varname:node_470,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:1|IN-4751-OUT;n:type:ShaderForge.SFN_RgbToHsv,id:4078,x:33501,y:33462,varname:VegetationHSV,prsc:1|IN-223-OUT;n:type:ShaderForge.SFN_Subtract,id:1540,x:33709,y:33340,varname:node_1540,prsc:2|A-4078-SOUT,B-9814-OUT;n:type:ShaderForge.SFN_Vector1,id:9814,x:33501,y:33399,varname:node_9814,prsc:2,v1:0.5;n:type:ShaderForge.SFN_HsvToRgb,id:2766,x:34013,y:33468,varname:node_2766,prsc:2|H-4078-HOUT,S-2632-OUT,V-4078-VOUT;n:type:ShaderForge.SFN_Lerp,id:9789,x:34069,y:32913,cmnt:Plants Heat,varname:node_9789,prsc:2|A-528-OUT,B-2766-OUT,T-9588-OUT;n:type:ShaderForge.SFN_Vector2,id:1217,x:32976,y:30444,varname:node_1217,prsc:2,v1:0,v2:0;n:type:ShaderForge.SFN_Tex2dAsset,id:3637,x:30206,y:34928,ptovrint:False,ptlb:Cities,ptin:_Cities,varname:_Cities,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a7e1c9f4b6d143b41bc99d303d55d1dd,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6141,x:30493,y:34357,varname:CityX,prsc:2,tex:a7e1c9f4b6d143b41bc99d303d55d1dd,ntxv:0,isnm:False|UVIN-6921-OUT,TEX-3637-TEX;n:type:ShaderForge.SFN_Tex2d,id:3418,x:30493,y:34542,varname:CityY,prsc:2,tex:a7e1c9f4b6d143b41bc99d303d55d1dd,ntxv:0,isnm:False|UVIN-2949-OUT,TEX-3637-TEX;n:type:ShaderForge.SFN_Tex2d,id:8874,x:30493,y:34738,varname:CityZ,prsc:2,tex:a7e1c9f4b6d143b41bc99d303d55d1dd,ntxv:0,isnm:False|UVIN-556-OUT,TEX-3637-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:3252,x:30852,y:34516,varname:node_3252,prsc:2,chbt:0|M-49-OUT,R-6141-R,G-3418-R,B-8874-R;n:type:ShaderForge.SFN_Multiply,id:3319,x:31648,y:34366,varname:node_3319,prsc:2|A-3252-OUT,B-2541-OUT;n:type:ShaderForge.SFN_OneMinus,id:4565,x:30913,y:33100,varname:node_4565,prsc:2|IN-6955-OUT;n:type:ShaderForge.SFN_Get,id:8223,x:30968,y:34886,varname:node_8223,prsc:2|IN-7925-OUT;n:type:ShaderForge.SFN_OneMinus,id:8944,x:31208,y:34774,varname:node_8944,prsc:2|IN-8223-OUT;n:type:ShaderForge.SFN_Multiply,id:6921,x:30082,y:34163,varname:_CityUVX,prsc:2|A-2026-OUT,B-5004-OUT;n:type:ShaderForge.SFN_Vector1,id:5004,x:29790,y:34196,varname:node_5004,prsc:2,v1:3;n:type:ShaderForge.SFN_Vector1,id:7428,x:29958,y:34479,varname:node_7428,prsc:2,v1:3;n:type:ShaderForge.SFN_Multiply,id:2949,x:30100,y:34409,varname:_CityUVY,prsc:2|A-2437-OUT,B-7428-OUT;n:type:ShaderForge.SFN_Multiply,id:556,x:30213,y:34628,varname:_CityUVZ,prsc:2|A-1781-OUT,B-2296-OUT;n:type:ShaderForge.SFN_Vector1,id:2296,x:30060,y:34677,varname:node_2296,prsc:2,v1:3;n:type:ShaderForge.SFN_Add,id:9410,x:31684,y:33680,varname:node_9410,prsc:2|A-552-OUT,B-3986-OUT;n:type:ShaderForge.SFN_Slider,id:4999,x:29436,y:33996,ptovrint:False,ptlb:Population,ptin:_Population,varname:_Population,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_RemapRange,id:552,x:31514,y:33727,varname:node_552,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-7448-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:9790,x:32255,y:34322,varname:node_9790,prsc:2,min:0,max:1|IN-4818-OUT;n:type:ShaderForge.SFN_RemapRange,id:7272,x:31826,y:33776,varname:node_7272,prsc:2,frmn:0.1,frmx:0.3,tomn:0,tomx:1|IN-9410-OUT;n:type:ShaderForge.SFN_Clamp01,id:9015,x:31972,y:33776,varname:PopMask,prsc:2|IN-7272-OUT;n:type:ShaderForge.SFN_OneMinus,id:4783,x:29893,y:33752,varname:node_4783,prsc:2|IN-2661-OUT;n:type:ShaderForge.SFN_Multiply,id:7223,x:29893,y:33612,varname:node_7223,prsc:2|A-4999-OUT,B-9286-OUT;n:type:ShaderForge.SFN_Lerp,id:5198,x:30184,y:33628,cmnt:PopFrost,varname:popFrost,prsc:1|A-7223-OUT,B-4999-OUT,T-4783-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9286,x:29574,y:33467,ptovrint:True,ptlb:PopulationFrostModifier,ptin:_PopulationFrostModifier,varname:_PopulationFrostModifier,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Multiply,id:6343,x:36327,y:34727,cmnt:Population,varname:node_6343,prsc:2|A-9790-OUT,B-6274-OUT;n:type:ShaderForge.SFN_Add,id:6175,x:37002,y:34571,varname:node_6175,prsc:2|A-7811-OUT,B-6607-OUT;n:type:ShaderForge.SFN_Multiply,id:6607,x:36719,y:34727,varname:node_6607,prsc:2|A-6343-OUT,B-6400-RGB;n:type:ShaderForge.SFN_Color,id:6400,x:36341,y:34868,ptovrint:False,ptlb:CitiesColor,ptin:_CitiesColor,varname:_CitiesColor,prsc:1,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_OneMinus,id:5943,x:36125,y:34547,varname:node_5943,prsc:2|IN-3892-OUT;n:type:ShaderForge.SFN_RemapRange,id:9490,x:36372,y:34482,varname:node_9490,prsc:2,frmn:0.8,frmx:2,tomn:0,tomx:1|IN-5943-OUT;n:type:ShaderForge.SFN_Clamp01,id:5135,x:36495,y:34591,varname:node_5135,prsc:2|IN-9490-OUT;n:type:ShaderForge.SFN_Abs,id:6274,x:36108,y:34788,varname:node_6274,prsc:2|IN-3892-OUT;n:type:ShaderForge.SFN_ComponentMask,id:9217,x:26864,y:31699,varname:node_9217,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-5609-OUT;n:type:ShaderForge.SFN_Sign,id:7553,x:27020,y:31699,varname:node_7553,prsc:2|IN-9217-OUT;n:type:ShaderForge.SFN_ComponentMask,id:723,x:26864,y:31859,varname:node_723,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-5609-OUT;n:type:ShaderForge.SFN_Sign,id:8895,x:27020,y:31859,varname:node_8895,prsc:2|IN-723-OUT;n:type:ShaderForge.SFN_ComponentMask,id:3413,x:26864,y:32009,varname:node_3413,prsc:2,cc1:2,cc2:-1,cc3:-1,cc4:-1|IN-5609-OUT;n:type:ShaderForge.SFN_Sign,id:9382,x:27020,y:32009,varname:node_9382,prsc:2|IN-3413-OUT;n:type:ShaderForge.SFN_RemapRange,id:8132,x:27174,y:31699,varname:node_8132,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-7553-OUT;n:type:ShaderForge.SFN_RemapRange,id:6664,x:27174,y:31859,varname:node_6664,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-8895-OUT;n:type:ShaderForge.SFN_RemapRange,id:9144,x:27174,y:32009,varname:node_9144,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-9382-OUT;n:type:ShaderForge.SFN_Add,id:8089,x:27485,y:32204,varname:node_8089,prsc:2|A-176-OUT,B-7180-UVOUT;n:type:ShaderForge.SFN_Vector2,id:176,x:27323,y:32170,varname:node_176,prsc:1,v1:0.3,v2:0;n:type:ShaderForge.SFN_Lerp,id:8181,x:27678,y:32158,varname:node_8181,prsc:2|A-7180-UVOUT,B-8089-OUT,T-8132-OUT;n:type:ShaderForge.SFN_Add,id:616,x:27499,y:32415,varname:node_616,prsc:2|A-5312-OUT,B-6591-UVOUT;n:type:ShaderForge.SFN_Vector2,id:5312,x:27337,y:32381,varname:node_5312,prsc:1,v1:0.3,v2:0.3;n:type:ShaderForge.SFN_Lerp,id:4538,x:27692,y:32369,varname:node_4538,prsc:2|A-6591-UVOUT,B-616-OUT,T-6664-OUT;n:type:ShaderForge.SFN_Add,id:109,x:27447,y:32726,varname:node_109,prsc:2|A-8687-OUT,B-3685-UVOUT;n:type:ShaderForge.SFN_Vector2,id:8687,x:27277,y:32674,varname:node_8687,prsc:1,v1:0,v2:0.3;n:type:ShaderForge.SFN_Lerp,id:1979,x:27658,y:32589,varname:node_1979,prsc:2|A-3685-UVOUT,B-109-OUT,T-9144-OUT;n:type:ShaderForge.SFN_Vector1,id:688,x:36064,y:34364,varname:node_688,prsc:2,v1:2;n:type:ShaderForge.SFN_Fresnel,id:6936,x:33568,y:32052,varname:node_6936,prsc:2|EXP-5458-OUT;n:type:ShaderForge.SFN_Vector1,id:5458,x:33396,y:32072,varname:node_5458,prsc:2,v1:6;n:type:ShaderForge.SFN_Multiply,id:1542,x:33991,y:32142,varname:node_1542,prsc:2|A-4482-OUT,B-8442-OUT;n:type:ShaderForge.SFN_RemapRange,id:4482,x:33748,y:32052,varname:node_4482,prsc:2,frmn:0,frmx:1,tomn:0.5,tomx:1|IN-6936-OUT;n:type:ShaderForge.SFN_Slider,id:2562,x:32501,y:32357,ptovrint:False,ptlb:OceanOpacity,ptin:_OceanOpacity,varname:_OceanOpacity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:5138,x:32821,y:32327,varname:OpacityRemaped,prsc:1,frmn:0,frmx:1,tomn:-2,tomx:0|IN-2562-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:1201,x:29473,y:32011,ptovrint:False,ptlb:AdditionalDetails,ptin:_AdditionalDetails,varname:_AdditionalDetails,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:efa2cf83312cc464696ad78683c2dba3,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:4772,x:29767,y:32298,varname:DetailsZ,prsc:1,tex:efa2cf83312cc464696ad78683c2dba3,ntxv:0,isnm:False|UVIN-1781-OUT,TEX-1201-TEX;n:type:ShaderForge.SFN_Tex2d,id:6401,x:29767,y:32132,varname:DetailsY,prsc:1,tex:efa2cf83312cc464696ad78683c2dba3,ntxv:0,isnm:False|UVIN-2437-OUT,TEX-1201-TEX;n:type:ShaderForge.SFN_Tex2d,id:2492,x:29767,y:31959,varname:DetailsX,prsc:1,tex:efa2cf83312cc464696ad78683c2dba3,ntxv:0,isnm:False|UVIN-2026-OUT,TEX-1201-TEX;n:type:ShaderForge.SFN_ChannelBlend,id:5548,x:30204,y:32024,varname:DetailsAlpha,prsc:1,chbt:0|M-49-OUT,R-2492-A,G-6401-A,B-4772-A;n:type:ShaderForge.SFN_Tex2d,id:6719,x:33152,y:33199,ptovrint:False,ptlb:DetailsGradient,ptin:_DetailsGradient,varname:_DetailsGradient,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False|UVIN-3042-OUT;n:type:ShaderForge.SFN_Append,id:3042,x:32965,y:33199,varname:aDetailsGradUV,prsc:1|A-5548-OUT,B-269-OUT;n:type:ShaderForge.SFN_Vector1,id:269,x:32751,y:33291,varname:node_269,prsc:2,v1:1;n:type:ShaderForge.SFN_Blend,id:5442,x:33703,y:32984,varname:Ground1,prsc:1,blmd:8,clmp:False|SRC-4221-RGB,DST-6719-RGB;n:type:ShaderForge.SFN_Blend,id:1236,x:34325,y:32803,cmnt:Plants Color,varname:node_1236,prsc:2,blmd:10,clmp:True|SRC-6475-OUT,DST-9789-OUT;n:type:ShaderForge.SFN_Lerp,id:3523,x:34494,y:32577,cmnt:Add Plants,varname:node_3523,prsc:2|A-6475-OUT,B-1236-OUT,T-1186-OUT;n:type:ShaderForge.SFN_Vector1,id:8656,x:32273,y:33932,varname:ShoresContrast,prsc:1,v1:0.9;n:type:ShaderForge.SFN_Abs,id:6110,x:28879,y:30539,varname:poles,prsc:2|IN-4886-OUT;n:type:ShaderForge.SFN_Clamp01,id:26,x:30823,y:29271,varname:node_26,prsc:2|IN-1536-OUT;n:type:ShaderForge.SFN_Slider,id:2523,x:30086,y:28753,ptovrint:False,ptlb:FrostContrast,ptin:_FrostContrast,varname:_FrostContrast,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5436893,max:1;n:type:ShaderForge.SFN_Vector1,id:3201,x:31143,y:29438,varname:node_3201,prsc:2,v1:0;n:type:ShaderForge.SFN_Slider,id:7668,x:32156,y:34066,ptovrint:False,ptlb:ShoresContrast,ptin:_ShoresContrast,varname:_ShoresContrast,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2427184,max:1;n:type:ShaderForge.SFN_RemapRange,id:7544,x:32472,y:33995,varname:ShoresContrastRemaped,prsc:1,frmn:0,frmx:1,tomn:0.9,tomx:0.99|IN-7668-OUT;n:type:ShaderForge.SFN_Slider,id:6063,x:31488,y:30808,ptovrint:False,ptlb:Heat,ptin:_Heat,varname:_Heat,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.06796116,max:1;n:type:ShaderForge.SFN_ConstantClamp,id:2632,x:33859,y:33340,varname:node_2632,prsc:2,min:0.2,max:1|IN-1540-OUT;n:type:ShaderForge.SFN_Blend,id:4884,x:34695,y:31941,varname:node_4884,prsc:2,blmd:6,clmp:True|SRC-9272-OUT,DST-1280-OUT;n:type:ShaderForge.SFN_Multiply,id:1280,x:34479,y:31958,varname:node_1280,prsc:2|A-5548-OUT,B-9496-OUT;n:type:ShaderForge.SFN_Vector1,id:9496,x:34261,y:31992,varname:node_9496,prsc:2,v1:0.4;n:type:ShaderForge.SFN_RemapRange,id:6163,x:32894,y:33767,varname:node_6163,prsc:2,frmn:0,frmx:0.1,tomn:0.1,tomx:0|IN-6955-OUT;n:type:ShaderForge.SFN_Clamp01,id:1397,x:33111,y:33751,varname:node_1397,prsc:2|IN-6163-OUT;n:type:ShaderForge.SFN_Subtract,id:1328,x:33712,y:33683,varname:node_1328,prsc:2|A-4078-VOUT,B-1397-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:2333,x:33875,y:33683,varname:node_2333,prsc:2,min:0.1,max:1|IN-1328-OUT;n:type:ShaderForge.SFN_HsvToRgb,id:528,x:34013,y:33601,varname:node_528,prsc:2|H-4078-HOUT,S-4078-SOUT,V-2333-OUT;n:type:ShaderForge.SFN_Lerp,id:6973,x:31085,y:33286,varname:node_6973,prsc:2|A-4565-OUT,B-6955-OUT,T-1557-OUT;n:type:ShaderForge.SFN_Slider,id:1557,x:30720,y:33383,ptovrint:False,ptlb:PopulationShoresMountains,ptin:_PopulationShoresMountains,varname:_PopulationShoresMountains,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:5069,x:30423,y:33748,varname:node_5069,prsc:2|A-5198-OUT,B-3461-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3461,x:30153,y:33865,ptovrint:False,ptlb:HeatMultiplier,ptin:_HeatMultiplier,varname:_HeatMultiplier,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Lerp,id:873,x:30695,y:33708,cmnt:PopHeat,varname:popHeat,prsc:1|A-5198-OUT,B-5069-OUT,T-9588-OUT;n:type:ShaderForge.SFN_Multiply,id:9954,x:30866,y:33871,varname:node_9954,prsc:2|A-873-OUT,B-8067-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8067,x:30285,y:34098,ptovrint:False,ptlb:VegetationMultiplier,ptin:_VegetationMultiplier,varname:_VegetationMultiplier,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Lerp,id:7717,x:31056,y:33803,varname:popVeg,prsc:1|A-873-OUT,B-9954-OUT,T-1186-OUT;n:type:ShaderForge.SFN_OneMinus,id:731,x:30890,y:34165,varname:node_731,prsc:2|IN-1186-OUT;n:type:ShaderForge.SFN_Multiply,id:4545,x:31200,y:33980,varname:node_4545,prsc:2|A-7717-OUT,B-5910-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5910,x:30515,y:34189,ptovrint:False,ptlb:NoVegetationMultiplier,ptin:_NoVegetationMultiplier,varname:_NoVegetationMultiplier,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Lerp,id:7448,x:31440,y:33958,varname:node_7448,prsc:2|A-7717-OUT,B-4545-OUT,T-731-OUT;n:type:ShaderForge.SFN_Lerp,id:3986,x:31350,y:33231,varname:node_3986,prsc:2|A-6973-OUT,B-3854-OUT,T-8833-OUT;n:type:ShaderForge.SFN_Slider,id:8833,x:30965,y:33501,ptovrint:False,ptlb:PopulationLandOcean,ptin:_PopulationLandOcean,varname:_PopulationLandOcean,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Lerp,id:2541,x:31479,y:34799,varname:node_2541,prsc:2|A-8944-OUT,B-1652-OUT,T-8833-OUT;n:type:ShaderForge.SFN_Get,id:1652,x:31052,y:34997,varname:node_1652,prsc:2|IN-7925-OUT;n:type:ShaderForge.SFN_Tex2d,id:6356,x:32295,y:37753,varname:_CloudsPoleDif,prsc:1,ntxv:2,isnm:False|UVIN-9436-UVOUT,TEX-2380-TEX;n:type:ShaderForge.SFN_Add,id:1523,x:33166,y:37428,varname:node_1523,prsc:2|A-5000-OUT,B-4141-OUT;n:type:ShaderForge.SFN_Add,id:4141,x:32825,y:37515,varname:node_4141,prsc:2|A-8762-OUT,B-3688-OUT;n:type:ShaderForge.SFN_Rotator,id:9436,x:32024,y:37708,varname:CloudsPoleUV,prsc:1|UVIN-1184-OUT,PIV-1223-OUT,SPD-194-OUT;n:type:ShaderForge.SFN_Vector2,id:1223,x:31762,y:37966,varname:node_1223,prsc:1,v1:0.5,v2:0.5;n:type:ShaderForge.SFN_Multiply,id:194,x:31940,y:38011,varname:node_194,prsc:2|A-5913-OUT,B-9643-OUT;n:type:ShaderForge.SFN_Vector1,id:9643,x:31780,y:38150,varname:node_9643,prsc:2,v1:-0.1;n:type:ShaderForge.SFN_Tex2dAsset,id:2380,x:32103,y:38043,ptovrint:False,ptlb:CloudsPole,ptin:_CloudsPole,varname:_CloudsPole,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Code,id:3338,x:32313,y:38047,varname:node_3338,prsc:2,code:cgBlAHQAdQByAG4AKAB0AGUAeAAyAEQAYgBpAGEAcwAoAHQAZQB4ACwAZgBsAG8AYQB0ADQAKABVAFYALAAwACwANQApACkALgByACkAOwA=,output:0,fname:CloudsPoleShadowsUnpack,width:498,height:146,input:12,input:1,input_1_label:tex,input_2_label:UV|A-2380-TEX,B-9436-UVOUT;n:type:ShaderForge.SFN_Add,id:9361,x:33205,y:37896,varname:node_9361,prsc:2|A-8762-OUT,B-9598-OUT;n:type:ShaderForge.SFN_Add,id:9780,x:33331,y:38150,varname:node_9780,prsc:2|A-9361-OUT,B-3311-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:1528,x:31648,y:38502,ptovrint:False,ptlb:CloudsAvgBlend,ptin:_CloudsAvgBlend,varname:_CloudsAvgBlend,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_RemapRange,id:1184,x:31049,y:37572,varname:node_1184,prsc:2,frmn:0,frmx:1,tomn:0.21,tomx:0.81|IN-1164-OUT;n:type:ShaderForge.SFN_Lerp,id:6475,x:34115,y:32660,varname:Ground,prsc:1|A-4221-RGB,B-5442-OUT,T-6719-A;n:type:ShaderForge.SFN_Clamp01,id:1915,x:32517,y:33066,varname:node_1915,prsc:2|IN-5548-OUT;n:type:ShaderForge.SFN_Subtract,id:3712,x:32520,y:37731,varname:node_3712,prsc:2|A-6356-R,B-1588-OUT;n:type:ShaderForge.SFN_Clamp01,id:3688,x:32878,y:37754,varname:node_3688,prsc:2|IN-3712-OUT;n:type:ShaderForge.SFN_Subtract,id:6425,x:32712,y:37856,varname:node_6425,prsc:2|A-3338-OUT,B-1588-OUT;n:type:ShaderForge.SFN_Clamp01,id:9598,x:32893,y:37887,varname:node_9598,prsc:2|IN-6425-OUT;n:type:ShaderForge.SFN_Get,id:825,x:35752,y:33828,varname:node_825,prsc:2|IN-9127-OUT;n:type:ShaderForge.SFN_Vector1,id:4974,x:35449,y:33750,varname:node_4974,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Subtract,id:2578,x:37246,y:33354,varname:node_2578,prsc:2|A-8712-OUT,B-2933-OUT;n:type:ShaderForge.SFN_Vector1,id:2933,x:35630,y:32593,varname:node_2933,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:5206,x:37823,y:33022,varname:node_5206,prsc:2|A-9278-OUT,B-5883-OUT;n:type:ShaderForge.SFN_Clamp01,id:9278,x:37513,y:33302,varname:node_9278,prsc:2|IN-2578-OUT;n:type:ShaderForge.SFN_Multiply,id:5883,x:37262,y:34065,varname:node_5883,prsc:2|A-3743-OUT,B-5889-OUT;n:type:ShaderForge.SFN_OneMinus,id:3008,x:31735,y:34108,varname:node_3008,prsc:2|IN-9015-OUT;n:type:ShaderForge.SFN_Subtract,id:4818,x:31888,y:34276,varname:node_4818,prsc:2|A-3319-OUT,B-3008-OUT;n:type:ShaderForge.SFN_Lerp,id:3607,x:33811,y:31760,varname:node_3607,prsc:2|A-201-RGB,B-332-OUT,T-2360-OUT;n:type:ShaderForge.SFN_Vector1,id:2360,x:33543,y:31824,varname:node_2360,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Vector1,id:332,x:33554,y:31770,varname:node_332,prsc:2,v1:1;n:type:ShaderForge.SFN_Add,id:745,x:33400,y:32375,varname:node_745,prsc:2|A-4668-OUT,B-3460-OUT;n:type:ShaderForge.SFN_Vector1,id:3460,x:33208,y:32354,varname:node_3460,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:9062,x:32942,y:32573,varname:node_9062,prsc:2|IN-3854-OUT,IMIN-6746-OUT,IMAX-9462-OUT,OMIN-5138-OUT,OMAX-5191-OUT;n:type:ShaderForge.SFN_Multiply,id:4668,x:33256,y:32573,varname:OceanDepthRemapped,prsc:1|A-3462-OUT,B-265-OUT;n:type:ShaderForge.SFN_Vector1,id:265,x:33072,y:32725,varname:node_265,prsc:2,v1:2.5;n:type:ShaderForge.SFN_Vector1,id:9462,x:32738,y:32607,varname:node_9462,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:5191,x:32738,y:32653,varname:node_5191,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:7137,x:33549,y:32331,varname:Oceans,prsc:1|A-201-RGB,B-745-OUT;n:type:ShaderForge.SFN_RgbToHsv,id:3902,x:33705,y:32331,varname:OceansHSV,prsc:1|IN-7137-OUT;n:type:ShaderForge.SFN_Subtract,id:1427,x:33959,y:32331,varname:node_1427,prsc:2|A-3902-HOUT,B-7904-OUT;n:type:ShaderForge.SFN_Multiply,id:7904,x:33523,y:32594,varname:node_7904,prsc:2|A-4668-OUT,B-3806-OUT;n:type:ShaderForge.SFN_Vector1,id:3806,x:33244,y:32836,varname:node_3806,prsc:2,v1:0.025;n:type:ShaderForge.SFN_HsvToRgb,id:8442,x:34182,y:32419,varname:node_8442,prsc:2|H-1427-OUT,S-3902-SOUT,V-3902-VOUT;n:type:ShaderForge.SFN_Lerp,id:6283,x:30542,y:30114,varname:node_6283,prsc:2|A-1790-OUT,B-1819-OUT,T-8607-OUT;n:type:ShaderForge.SFN_Get,id:8607,x:30175,y:30378,varname:node_8607,prsc:2|IN-7925-OUT;n:type:ShaderForge.SFN_Multiply,id:1819,x:30611,y:30579,varname:node_1819,prsc:2|A-8960-OUT,B-3854-OUT;n:type:ShaderForge.SFN_Vector1,id:8960,x:30115,y:30604,varname:node_8960,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:9978,x:29095,y:29546,varname:node_9978,prsc:2|A-2334-OUT,B-9996-OUT,T-2098-OUT;n:type:ShaderForge.SFN_Subtract,id:9996,x:28848,y:29566,varname:node_9996,prsc:2|A-2334-OUT,B-258-OUT;n:type:ShaderForge.SFN_Vector1,id:258,x:28560,y:29647,varname:node_258,prsc:2,v1:0.3;n:type:ShaderForge.SFN_Get,id:2098,x:28996,y:29832,varname:node_2098,prsc:2|IN-7925-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:4838,x:29261,y:29453,varname:node_4838,prsc:2,min:-0.51,max:3|IN-9978-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:3807,x:32880,y:30978,varname:node_3807,prsc:2|IN-9588-OUT,IMIN-7302-OUT,IMAX-7422-OUT,OMIN-9820-OUT,OMAX-8837-OUT;n:type:ShaderForge.SFN_OneMinus,id:7422,x:32752,y:31351,varname:node_7422,prsc:2|IN-7302-OUT;n:type:ShaderForge.SFN_Vector1,id:8837,x:32419,y:31339,varname:node_8837,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:8694,x:33065,y:31014,varname:node_8694,prsc:2|IN-3807-OUT;n:type:ShaderForge.SFN_OneMinus,id:1817,x:33344,y:31032,varname:node_1817,prsc:2|IN-8694-OUT;n:type:ShaderForge.SFN_Multiply,id:6763,x:32607,y:31833,varname:node_6763,prsc:2|A-1817-OUT,B-6406-OUT;n:type:ShaderForge.SFN_Sign,id:2656,x:31315,y:36337,varname:node_2656,prsc:2|IN-5609-OUT;n:type:ShaderForge.SFN_Code,id:8191,x:31794,y:36358,varname:node_8191,prsc:2,code:WAAuAHoAKgA9AFMAaQBnAG4ALgB4ADsACgBZAC4AegAqAD0AUwBpAGcAbgAuAHkAOwAKAFoALgB6ACoAPQBTAGkAZwBuAC4AegA7AAoAaABhAGwAZgAzACAATgBvAHIAbQAgAD0AIABYAC4AegB5AHgAKgBNAGEAcwBrAC4AeAArAFkALgB4AHoAeQAqAE0AYQBzAGsALgB5ACsAWgAqAE0AYQBzAGsALgB6ADsACgByAGUAdAB1AHIAbgAgAE4AbwByAG0AOwA=,output:6,fname:Function_node_8191,width:685,height:217,input:2,input:2,input:2,input:2,input:2,input_1_label:X,input_2_label:Y,input_3_label:Z,input_4_label:Sign,input_5_label:Mask|A-2345-OUT,B-8871-OUT,C-9631-OUT,D-2656-OUT,E-49-OUT;n:type:ShaderForge.SFN_NormalVector,id:8670,x:31579,y:35263,prsc:2,pt:False;proporder:3787-1201-2564-568-201-8617-7668-2562-1711-8967-2334-2523-6063-7447-4221-6719-9428-2380-1528-5913-8615-4964-1677-5544-2493-7528-3834-4367-7302-5889-4751-3637-9286-6400-4999-1557-3461-8067-5910-8833;pass:END;sub:END;*/

Shader "Human Unit/Planet" {
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
        [MaterialToggle] _CloudsAvgBlend ("CloudsAvgBlend", Float ) = 0
        _CloudsSpeed ("CloudsSpeed", Range(0, 1)) = 0.4368932
        _CloudsAmount ("CloudsAmount", Range(0, 1)) = 0
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
        _PopulationFrostModifier ("PopulationFrostModifier", Float ) = 0
        [HDR]_CitiesColor ("CitiesColor", Color) = (0.5,0.5,0.5,1)
        _Population ("Population", Range(0, 1)) = 0
        _PopulationShoresMountains ("PopulationShoresMountains", Range(0, 1)) = 0
        _HeatMultiplier ("HeatMultiplier", Float ) = 0
        _VegetationMultiplier ("VegetationMultiplier", Float ) = 1
        _NoVegetationMultiplier ("NoVegetationMultiplier", Float ) = 1
        _PopulationLandOcean ("PopulationLandOcean", Range(0, 1)) = 0
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
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Height; uniform float4 _Height_ST;
            uniform float _RandomSeed;
            uniform float _Size;
            uniform float _WaterLevel;
            uniform half4 _AtmosphereColor;
            uniform float _Gloss;
            uniform sampler2D _HeightGradient; uniform float4 _HeightGradient_ST;
            uniform sampler2D _Clouds; uniform float4 _Clouds_ST;
            uniform float4 _CloudsColor;
            float Clouds( float2 UV , float time , sampler2D tex , float speed , fixed E ){
            speed=speed*0.3;
            float1 sinTime = frac(sin(time.x*speed)*0.05);
            float1 sinTime2 = frac(sin(time.x*speed+0.78)*0.05);
            float1 sinTime3 = frac(sin(time.x*speed+1.57)*0.05);
            float1 sinTime4 = frac(sin(time.x*speed+2.35)*0.05);
            float1 clouds1 = tex2D(tex, float2(-UV.r+frac(speed*time.x*0.035+0.3), -UV.g+sinTime2)).r;
            float1 clouds2 = tex2D(tex, float2(UV.r+frac(speed*time.x*0.03),UV.g+sinTime)).r;
            float1 clouds3 = tex2D(tex, float2(-UV.r-frac(speed*time.x*0.035-0.35),-UV.g+sinTime3)).r;
            float1 clouds4 = tex2D(tex, float2(UV.r-frac(speed*time.x*0.03),UV.g+sinTime4)).r;
            if( E == 1.0)
                return(saturate((2*clouds1+clouds2+2*clouds3+clouds2)*0.25));
            else
                return(saturate((2*clouds1*clouds2+2*clouds3*clouds2)*0.5));
            
            }
            
            uniform float _CloudsSpeed;
            uniform float _CloudsAmount;
            float CloudsShadows( float2 UV , float time , sampler2D tex , float speed , fixed E ){
            speed=speed*0.3;
            float1 sinTime = frac(sin(time.x*speed)*0.05);
            float1 sinTime2 = frac(sin(time.x*speed+0.78)*0.05);
            float1 sinTime3 = frac(sin(time.x*speed+1.57)*0.05);
            float1 sinTime4 = frac(sin(time.x*speed+2.35)*0.05);
            float1 clouds1 = tex2Dbias(tex, float4(-UV.r+frac(speed*time.x*0.035+0.3), -UV.g+sinTime2,0,3)).r;
            float1 clouds2 = tex2Dbias(tex, float4(UV.r+frac(speed*time.x*0.03),UV.g+sinTime,0,3)).r;
            float1 clouds3 = tex2Dbias(tex, float4(-UV.r-frac(speed*time.x*0.035-0.35),-UV.g+sinTime3,0,3)).r;
            float1 clouds4 = tex2Dbias(tex, float4(UV.r-frac(speed*time.x*0.03),UV.g+sinTime4,0,3)).r;
            if( E == 1.0)
                return(saturate((2*clouds1+clouds2+2*clouds3+clouds2)*0.3));
            else
                return(saturate((2*clouds1*clouds2+2*clouds3*clouds2)*0.55));
            }
            
            uniform float _CloudsHeight;
            uniform float _CloudsSpread;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            float3 Rotate3( float3 Normal , float Angle ){
            float nx = Normal.x;
            float ny = Normal.y;
            float nz = Normal.z;
            
            float a=Angle;
            
            float ca=cos(a);
            float sa=sin(a);
            float3 rN=float3(ca*nx-sa*ny,sa*nx+ca*ny,nz);
            
            
            
            return rN;
            }
            
            float3 Rotate2( float3 Normal , float Angle ){
            float nx = Normal.x;
            float ny = Normal.y;
            float nz = Normal.z;
            float a=Angle;
            
            float ca=cos(a);
            float sa=sin(a);
            float3 rN=float3(ca*nx-sa*ny,sa*nx+ca*ny,nz);
            rN=rN.yxz;
            
            return rN;
            }
            
            float3 Rotate( float3 Normal , float Angle ){
            
            float nx = Normal.x;
            float ny = Normal.y;
            float nz = Normal.z;
            
            float a=Angle;
            
            
            float ca=cos(a);
            float sa=sin(a);
            float3 rN=float3(ca*nx-sa*ny,sa*nx+ca*ny,nz);
            
            rN=rN.yxz;
            
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
            
            float3 normXZ( float3 norm , float3 normDir ){
            float3 zNorm = normalize(half3(norm.xy  + normDir.xy, normDir.z));
            return zNorm;
            }
            
            uniform float _Relief;
            uniform sampler2D _FertilityMap; uniform float4 _FertilityMap_ST;
            uniform half4 _Vegetation;
            uniform float _Fertility;
            uniform float _VegetationContrast;
            uniform float _Frost;
            uniform float _Specularity;
            uniform half _Ambient;
            uniform float _VegetationFrostResistance;
            uniform sampler2D _Cities; uniform float4 _Cities_ST;
            uniform half _Population;
            uniform half _PopulationFrostModifier;
            uniform half4 _CitiesColor;
            uniform float _OceanOpacity;
            uniform sampler2D _AdditionalDetails; uniform float4 _AdditionalDetails_ST;
            uniform sampler2D _DetailsGradient; uniform float4 _DetailsGradient_ST;
            uniform float _FrostContrast;
            uniform half _ShoresContrast;
            uniform half _Heat;
            uniform half _PopulationShoresMountains;
            uniform half _HeatMultiplier;
            uniform half _VegetationMultiplier;
            uniform half _NoVegetationMultiplier;
            uniform float _PopulationLandOcean;
            uniform sampler2D _CloudsPole; uniform float4 _CloudsPole_ST;
            float CloudsPoleShadowsUnpack( sampler2D tex , float2 UV ){
            return(tex2Dbias(tex,float4(UV,0,5)).r);
            }
            
            uniform fixed _CloudsAvgBlend;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 NormalsLocalNormalized = normalize(mul( unity_WorldToObject, float4(normalize(i.normalDir),0) ).xyz.rgb);
                fixed3 NormalMult1 = (NormalsLocalNormalized*3.8416*NormalsLocalNormalized*NormalsLocalNormalized*NormalsLocalNormalized);
                fixed3 NormalComp = NormalMult1.rgb;
                float3 Mask = (NormalMult1/(NormalComp.r+NormalComp.g+NormalComp.b));
                fixed3 _Mask = Mask;
                float UVRotX_ang = _RandomSeed;
                float UVRotX_spd = 1.0;
                float UVRotX_cos = cos(UVRotX_spd*UVRotX_ang);
                float UVRotX_sin = sin(UVRotX_spd*UVRotX_ang);
                float2 UVRotX_piv = float2(0.5,0.5);
                float3 PosScaled = ((_Size*4.9+0.1)*mul( unity_WorldToObject, float4((i.posWorld.rgb-objPos.rgb),0) ).xyz.rgb);
                float2 UVRotX = (mul((PosScaled.gb*0.5+0.5)-UVRotX_piv,float2x2( UVRotX_cos, -UVRotX_sin, UVRotX_sin, UVRotX_cos))+UVRotX_piv);
                float2 UVPanX = (UVRotX+_RandomSeed*float2(0.7,0));
                float2 UVX = lerp(UVPanX,(half2(0.3,0)+UVPanX),(sign(NormalsLocalNormalized.r)*0.5+0.5));
                float2 _UVX = UVX;
                float3 NormalX = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(_UVX, _Normal)));
                float4 HeightX = tex2D(_Height,TRANSFORM_TEX(_UVX, _Height));
                float UVRotY_ang = (_RandomSeed*4.0);
                float UVRotY_spd = 1.0;
                float UVRotY_cos = cos(UVRotY_spd*UVRotY_ang);
                float UVRotY_sin = sin(UVRotY_spd*UVRotY_ang);
                float2 UVRotY_piv = float2(0.5,0.5);
                half2 _PolesPos1 = (PosScaled.rb*0.5+0.5);
                float2 UVRotY = (mul(_PolesPos1-UVRotY_piv,float2x2( UVRotY_cos, -UVRotY_sin, UVRotY_sin, UVRotY_cos))+UVRotY_piv);
                float2 UVPanY = (UVRotY+_RandomSeed*float2(0,0.7));
                float2 UVY = lerp(UVPanY,(half2(0.3,0.3)+UVPanY),(sign(NormalsLocalNormalized.g)*0.5+0.5));
                float2 _UVY = UVY;
                float4 HeightY = tex2D(_Height,TRANSFORM_TEX(_UVY, _Height));
                float UVRotZ_ang = (_RandomSeed*8.0);
                float UVRotZ_spd = 1.0;
                float UVRotZ_cos = cos(UVRotZ_spd*UVRotZ_ang);
                float UVRotZ_sin = sin(UVRotZ_spd*UVRotZ_ang);
                float2 UVRotZ_piv = float2(0.5,0.5);
                float2 UVRotZ = (mul((PosScaled.rg*0.5+0.5)-UVRotZ_piv,float2x2( UVRotZ_cos, -UVRotZ_sin, UVRotZ_sin, UVRotZ_cos))+UVRotZ_piv);
                float2 UVPanZ = (UVRotZ+_RandomSeed*float2(-0.7,0.7));
                float2 UVZ = lerp(UVPanZ,(half2(0,0.3)+UVPanZ),(sign(NormalsLocalNormalized.b)*0.5+0.5));
                float2 _UVZ = UVZ;
                float4 HeightZ = tex2D(_Height,TRANSFORM_TEX(_UVZ, _Height));
                half Height = (1.0*(_Mask.r*HeightX.a + _Mask.g*HeightY.a + _Mask.b*HeightZ.a));
                half zero = 0.0;
                float heightNormalized = saturate((zero + ( (Height - _WaterLevel) * (1.0 - zero) ) / (1.0 - _WaterLevel)));
                half ShoresContrastRemaped = (_ShoresContrast*0.09000003+0.9);
                float _water = saturate((zero + ( ((1.0 - heightNormalized) - ShoresContrastRemaped) * (1.0 - zero) ) / (1.0 - ShoresContrastRemaped)));
                float WaterRelief = (1.0 - (0.7*_water));
                float3 node_2345 = Rotate( (_Relief*NormalX.rgb*WaterRelief) , _RandomSeed );
                float3 NormalY = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(_UVY, _Normal)));
                float3 node_8871 = Rotate2( (_Relief*NormalY.rgb*WaterRelief) , (_RandomSeed*4.0) );
                float3 NormalZ = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(_UVZ, _Normal)));
                float3 node_9631 = Rotate3( (_Relief*NormalZ.rgb*WaterRelief) , (_RandomSeed*8.0) );
                fixed minuszero = (-0.001);
                half oceanDepth = (zero + ( (Height - minuszero) * (1.0 - zero) ) / (_WaterLevel - minuszero));
                float poles = abs(NormalsLocalNormalized.g);
                half polesContrast = (_Frost*-1.58+0.16);
                half IminFrostContrast = (0.5-((1.0 - polesContrast)*0.5));
                fixed zero5 = 0.0;
                half PolesReachMao = ( saturate((zero5 + ( ((clamp(lerp(_Frost,(_Frost-0.3),_water),-0.51,3)+poles) - IminFrostContrast) * (1.0 - zero5) ) / ((0.5+((1.0 - polesContrast)*0.5)) - IminFrostContrast))) > 0.5 ? (1.0-(1.0-2.0*(saturate((zero5 + ( ((clamp(lerp(_Frost,(_Frost-0.3),_water),-0.51,3)+poles) - IminFrostContrast) * (1.0 - zero5) ) / ((0.5+((1.0 - polesContrast)*0.5)) - IminFrostContrast)))-0.5))*(1.0-lerp((Height*1.0),(1.0*oceanDepth),_water))) : (2.0*saturate((zero5 + ( ((clamp(lerp(_Frost,(_Frost-0.3),_water),-0.51,3)+poles) - IminFrostContrast) * (1.0 - zero5) ) / ((0.5+((1.0 - polesContrast)*0.5)) - IminFrostContrast)))*lerp((Height*1.0),(1.0*oceanDepth),_water)) );
                half PolesContrastIMin = (0.5-((1.0 - _FrostContrast)*0.5));
                half Freezing = saturate((zero5 + ( (PolesReachMao - PolesContrastIMin) * (1.0 - zero5) ) / ((0.5+((1.0 - _FrostContrast)*0.5)) - PolesContrastIMin))); // Frezing
                half CloudsAmounbtNeg = (-1*(1.0 - _CloudsAmount));
                float4 timeClouds = _Time + _TimeEditor;
                fixed PolesCaps = saturate((poles*-5.0+4.5));
                float4 node_3903 = _Time + _TimeEditor;
                float CloudsPoleUV_ang = node_3903.g;
                float CloudsPoleUV_spd = (_CloudsSpeed*(-0.1));
                float CloudsPoleUV_cos = cos(CloudsPoleUV_spd*CloudsPoleUV_ang);
                float CloudsPoleUV_sin = sin(CloudsPoleUV_spd*CloudsPoleUV_ang);
                float2 CloudsPoleUV_piv = half2(0.5,0.5);
                half2 CloudsPoleUV = (mul((_PolesPos1*0.6+0.21)-CloudsPoleUV_piv,float2x2( CloudsPoleUV_cos, -CloudsPoleUV_sin, CloudsPoleUV_sin, CloudsPoleUV_cos))+CloudsPoleUV_piv);
                half4 _CloudsPoleDif = tex2D(_CloudsPole,TRANSFORM_TEX(CloudsPoleUV, _CloudsPole));
                float _clouds = pow(saturate((((CloudsAmounbtNeg+Clouds( i.uv0 , timeClouds.g , _Clouds , _CloudsSpeed , _CloudsAvgBlend ))*PolesCaps)+(CloudsAmounbtNeg+saturate((_CloudsPoleDif.r-PolesCaps))))),(_CloudsSpread*-0.5+1.0));
                float3 normalDirection = lerp(normalize(mul( unity_ObjectToWorld, float4((_Mask.r*normX( node_2345 , NormalsLocalNormalized ) + _Mask.g*normYX( node_8871 , NormalsLocalNormalized ) + _Mask.b*normXZ( node_9631 , NormalsLocalNormalized )),0) ).xyz.rgb),i.normalDir,max(((1.0 - Freezing)*_water),_clouds));
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float2 heightGradientUV = float2(heightNormalized,0.0);
                half4 _HeightGradient_var = tex2D(_HeightGradient,TRANSFORM_TEX(heightGradientUV, _HeightGradient));
                half4 DetailsX = tex2D(_AdditionalDetails,TRANSFORM_TEX(_UVX, _AdditionalDetails));
                half4 DetailsY = tex2D(_AdditionalDetails,TRANSFORM_TEX(_UVY, _AdditionalDetails));
                half4 DetailsZ = tex2D(_AdditionalDetails,TRANSFORM_TEX(_UVZ, _AdditionalDetails));
                half DetailsAlpha = (_Mask.r*DetailsX.a + _Mask.g*DetailsY.a + _Mask.b*DetailsZ.a);
                half2 aDetailsGradUV = float2(DetailsAlpha,1.0);
                half4 _DetailsGradient_var = tex2D(_DetailsGradient,TRANSFORM_TEX(aDetailsGradUV, _DetailsGradient));
                half3 Ground = lerp(_HeightGradient_var.rgb,(_HeightGradient_var.rgb+_DetailsGradient_var.rgb),_DetailsGradient_var.a);
                half3 VegetationColor = saturate(((0.3*heightNormalized)+_Vegetation.rgb));
                float4 VegetationHSV_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 VegetationHSV_p = lerp(float4(float4(VegetationColor,0.0).zy, VegetationHSV_k.wz), float4(float4(VegetationColor,0.0).yz, VegetationHSV_k.xy), step(float4(VegetationColor,0.0).z, float4(VegetationColor,0.0).y));
                float4 VegetationHSV_q = lerp(float4(VegetationHSV_p.xyw, float4(VegetationColor,0.0).x), float4(float4(VegetationColor,0.0).x, VegetationHSV_p.yzx), step(VegetationHSV_p.x, float4(VegetationColor,0.0).x));
                float VegetationHSV_d = VegetationHSV_q.x - min(VegetationHSV_q.w, VegetationHSV_q.y);
                float VegetationHSV_e = 1.0e-10;
                half3 VegetationHSV = float3(abs(VegetationHSV_q.z + (VegetationHSV_q.w - VegetationHSV_q.y) / (6.0 * VegetationHSV_d + VegetationHSV_e)), VegetationHSV_d / (VegetationHSV_q.x + VegetationHSV_e), VegetationHSV_q.x);;
                float Heat = saturate(((1.0 - poles)+(((-0.5)*heightNormalized)+(_Heat*2.5+-1.0)))); // Heat
                half zero4 = 0.0;
                half4 VegetationX = tex2D(_FertilityMap,TRANSFORM_TEX(_UVX, _FertilityMap));
                half4 VegetationY = tex2D(_FertilityMap,TRANSFORM_TEX(_UVY, _FertilityMap));
                half4 VegetationZ = tex2D(_FertilityMap,TRANSFORM_TEX(_UVZ, _FertilityMap));
                half PlantsMask = saturate(((1.0 - saturate((((saturate((PolesReachMao-(-1*(1.0 - (_VegetationFrostResistance*0.5+0.5)))))*1.3+-1.0)+poles+(0.35*heightNormalized))*2.857143+-0.857143)))*(zero4 + ( (((1.0 - saturate((zero4 + ( (Heat - _VegetationContrast) * (1.0 - zero4) ) / ((1.0 - _VegetationContrast) - _VegetationContrast))))*((_Fertility*1.6+-1.0)+((_Mask.r*VegetationX.a + _Mask.g*VegetationY.a + _Mask.b*VegetationZ.a)+(heightNormalized*(-0.3))))) - _VegetationContrast) * (1.0 - zero4) ) / ((1.0 - _VegetationContrast) - _VegetationContrast))));
                half OpacityRemaped = (_OceanOpacity*2.0+-2.0);
                half OceanDepthRemapped = (saturate((OpacityRemaped + ( (oceanDepth - zero) * (1.0 - OpacityRemaped) ) / (1.0 - zero)))*2.5);
                half3 Oceans = (_AtmosphereColor.rgb*(OceanDepthRemapped+1.0));
                float4 OceansHSV_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 OceansHSV_p = lerp(float4(float4(Oceans,0.0).zy, OceansHSV_k.wz), float4(float4(Oceans,0.0).yz, OceansHSV_k.xy), step(float4(Oceans,0.0).z, float4(Oceans,0.0).y));
                float4 OceansHSV_q = lerp(float4(OceansHSV_p.xyw, float4(Oceans,0.0).x), float4(float4(Oceans,0.0).x, OceansHSV_p.yzx), step(OceansHSV_p.x, float4(Oceans,0.0).x));
                float OceansHSV_d = OceansHSV_q.x - min(OceansHSV_q.w, OceansHSV_q.y);
                float OceansHSV_e = 1.0e-10;
                half3 OceansHSV = float3(abs(OceansHSV_q.z + (OceansHSV_q.w - OceansHSV_q.y) / (6.0 * OceansHSV_d + OceansHSV_e)), OceansHSV_d / (OceansHSV_q.x + OceansHSV_e), OceansHSV_q.x);;
                float node_332 = 1.0;
                float node_7627 = 1.0;
                float _cloudsShadows = pow(saturate(((CloudsAmounbtNeg+saturate((CloudsPoleShadowsUnpack( _CloudsPole , CloudsPoleUV )-PolesCaps)))+(PolesCaps*(CloudsShadows( (((0.02*_CloudsHeight)*float2(dot(lightDirection,i.tangentDir),dot(lightDirection,i.bitangentDir)))+i.uv0) , timeClouds.g , _Clouds , _CloudsSpeed , _CloudsAvgBlend )+(-1*(1.0 - _CloudsAmount)))))),(_CloudsSpread*-0.5+1.0));
                float3 Diffuze = lerp((lerp(lerp(lerp(Ground,saturate(( lerp((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),VegetationHSV.g)*clamp((VegetationHSV.b-saturate((heightNormalized*-1.0+0.1))),0.1,1)),(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),clamp((VegetationHSV.g-0.5),0.2,1))*VegetationHSV.b),Heat) > 0.5 ? (1.0-(1.0-2.0*(lerp((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),VegetationHSV.g)*clamp((VegetationHSV.b-saturate((heightNormalized*-1.0+0.1))),0.1,1)),(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),clamp((VegetationHSV.g-0.5),0.2,1))*VegetationHSV.b),Heat)-0.5))*(1.0-Ground)) : (2.0*lerp((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),VegetationHSV.g)*clamp((VegetationHSV.b-saturate((heightNormalized*-1.0+0.1))),0.1,1)),(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),clamp((VegetationHSV.g-0.5),0.2,1))*VegetationHSV.b),Heat)*Ground) )),PlantsMask),saturate(((pow(1.0-max(0,dot(normalDirection, viewDirection)),6.0)*0.5+0.5)*(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((OceansHSV.r-(OceanDepthRemapped*0.025))+float3(0.0,-1.0/3.0,1.0/3.0)))-1),OceansHSV.g)*OceansHSV.b))),_water),saturate((1.0-(1.0-(lerp(lerp(_AtmosphereColor.rgb,float3(node_332,node_332,node_332),0.1),float3(node_7627,node_7627,node_7627),Height)*Freezing))*(1.0-(DetailsAlpha*0.4)))),Freezing)*(1.0 - (_cloudsShadows*0.7))),_CloudsColor.rgb,_clouds); // Diffuse
                float3 emissive = (saturate((Diffuze-1.0))+((Diffuze*UNITY_LIGHTMODEL_AMBIENT.rgb)*_Ambient));
                float Lightside = max(0,dot(lightDirection,normalDirection)); // Lambert
                float node_6923 = 0.0;
                float3 node_9816 = lerp((lerp(_water,((0.1*Freezing)+(_water*0.1)),Freezing)*saturate((0.6+_AtmosphereColor.rgb))*_Specularity),float3(node_6923,node_6923,node_6923),_clouds); // Spec
                float2 _CityUVX = (_UVX*3.0);
                float4 CityX = tex2D(_Cities,TRANSFORM_TEX(_CityUVX, _Cities));
                float2 _CityUVY = (_UVY*3.0);
                float4 CityY = tex2D(_Cities,TRANSFORM_TEX(_CityUVY, _Cities));
                float2 _CityUVZ = (_UVZ*3.0);
                float4 CityZ = tex2D(_Cities,TRANSFORM_TEX(_CityUVZ, _Cities));
                half popFrost = lerp((_Population*_PopulationFrostModifier),_Population,(1.0 - Freezing)); // PopFrost
                half popHeat = lerp(popFrost,(popFrost*_HeatMultiplier),Heat); // PopHeat
                half popVeg = lerp(popHeat,(popHeat*_VegetationMultiplier),PlantsMask);
                half LightSide = min(0,dot(lightDirection,i.normalDir)); // Lambert
                float3 finalColor = emissive + ((((Diffuze*Lightside)+(Lightside*pow(max(0,dot(normalDirection,halfDirection)),exp(lerp(1,11,_Gloss)))*node_9816*2.0))*_LightColor0.rgb*attenuation)+((clamp((((_Mask.r*CityX.r + _Mask.g*CityY.r + _Mask.b*CityZ.r)*lerp((1.0 - _water),_water,_PopulationLandOcean))-(1.0 - saturate((((lerp(popVeg,(popVeg*_NoVegetationMultiplier),(1.0 - PlantsMask))*2.0+-1.0)+lerp(lerp((1.0 - heightNormalized),heightNormalized,_PopulationShoresMountains),oceanDepth,_PopulationLandOcean))*5.0+-0.5)))),0,1)*abs(LightSide))*_CitiesColor.rgb));
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
            #pragma multi_compile_fwdadd_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _Height; uniform float4 _Height_ST;
            uniform float _RandomSeed;
            uniform float _Size;
            uniform float _WaterLevel;
            uniform half4 _AtmosphereColor;
            uniform float _Gloss;
            uniform sampler2D _HeightGradient; uniform float4 _HeightGradient_ST;
            uniform sampler2D _Clouds; uniform float4 _Clouds_ST;
            uniform float4 _CloudsColor;
            float Clouds( float2 UV , float time , sampler2D tex , float speed , fixed E ){
            speed=speed*0.3;
            float1 sinTime = frac(sin(time.x*speed)*0.05);
            float1 sinTime2 = frac(sin(time.x*speed+0.78)*0.05);
            float1 sinTime3 = frac(sin(time.x*speed+1.57)*0.05);
            float1 sinTime4 = frac(sin(time.x*speed+2.35)*0.05);
            float1 clouds1 = tex2D(tex, float2(-UV.r+frac(speed*time.x*0.035+0.3), -UV.g+sinTime2)).r;
            float1 clouds2 = tex2D(tex, float2(UV.r+frac(speed*time.x*0.03),UV.g+sinTime)).r;
            float1 clouds3 = tex2D(tex, float2(-UV.r-frac(speed*time.x*0.035-0.35),-UV.g+sinTime3)).r;
            float1 clouds4 = tex2D(tex, float2(UV.r-frac(speed*time.x*0.03),UV.g+sinTime4)).r;
            if( E == 1.0)
                return(saturate((2*clouds1+clouds2+2*clouds3+clouds2)*0.25));
            else
                return(saturate((2*clouds1*clouds2+2*clouds3*clouds2)*0.5));
            
            }
            
            uniform float _CloudsSpeed;
            uniform float _CloudsAmount;
            float CloudsShadows( float2 UV , float time , sampler2D tex , float speed , fixed E ){
            speed=speed*0.3;
            float1 sinTime = frac(sin(time.x*speed)*0.05);
            float1 sinTime2 = frac(sin(time.x*speed+0.78)*0.05);
            float1 sinTime3 = frac(sin(time.x*speed+1.57)*0.05);
            float1 sinTime4 = frac(sin(time.x*speed+2.35)*0.05);
            float1 clouds1 = tex2Dbias(tex, float4(-UV.r+frac(speed*time.x*0.035+0.3), -UV.g+sinTime2,0,3)).r;
            float1 clouds2 = tex2Dbias(tex, float4(UV.r+frac(speed*time.x*0.03),UV.g+sinTime,0,3)).r;
            float1 clouds3 = tex2Dbias(tex, float4(-UV.r-frac(speed*time.x*0.035-0.35),-UV.g+sinTime3,0,3)).r;
            float1 clouds4 = tex2Dbias(tex, float4(UV.r-frac(speed*time.x*0.03),UV.g+sinTime4,0,3)).r;
            if( E == 1.0)
                return(saturate((2*clouds1+clouds2+2*clouds3+clouds2)*0.3));
            else
                return(saturate((2*clouds1*clouds2+2*clouds3*clouds2)*0.55));
            }
            
            uniform float _CloudsHeight;
            uniform float _CloudsSpread;
            uniform sampler2D _Normal; uniform float4 _Normal_ST;
            float3 Rotate3( float3 Normal , float Angle ){
            float nx = Normal.x;
            float ny = Normal.y;
            float nz = Normal.z;
            
            float a=Angle;
            
            float ca=cos(a);
            float sa=sin(a);
            float3 rN=float3(ca*nx-sa*ny,sa*nx+ca*ny,nz);
            
            
            
            return rN;
            }
            
            float3 Rotate2( float3 Normal , float Angle ){
            float nx = Normal.x;
            float ny = Normal.y;
            float nz = Normal.z;
            float a=Angle;
            
            float ca=cos(a);
            float sa=sin(a);
            float3 rN=float3(ca*nx-sa*ny,sa*nx+ca*ny,nz);
            rN=rN.yxz;
            
            return rN;
            }
            
            float3 Rotate( float3 Normal , float Angle ){
            
            float nx = Normal.x;
            float ny = Normal.y;
            float nz = Normal.z;
            
            float a=Angle;
            
            
            float ca=cos(a);
            float sa=sin(a);
            float3 rN=float3(ca*nx-sa*ny,sa*nx+ca*ny,nz);
            
            rN=rN.yxz;
            
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
            
            float3 normXZ( float3 norm , float3 normDir ){
            float3 zNorm = normalize(half3(norm.xy  + normDir.xy, normDir.z));
            return zNorm;
            }
            
            uniform float _Relief;
            uniform sampler2D _FertilityMap; uniform float4 _FertilityMap_ST;
            uniform half4 _Vegetation;
            uniform float _Fertility;
            uniform float _VegetationContrast;
            uniform float _Frost;
            uniform float _Specularity;
            uniform half _Ambient;
            uniform float _VegetationFrostResistance;
            uniform sampler2D _Cities; uniform float4 _Cities_ST;
            uniform half _Population;
            uniform half _PopulationFrostModifier;
            uniform half4 _CitiesColor;
            uniform float _OceanOpacity;
            uniform sampler2D _AdditionalDetails; uniform float4 _AdditionalDetails_ST;
            uniform sampler2D _DetailsGradient; uniform float4 _DetailsGradient_ST;
            uniform float _FrostContrast;
            uniform half _ShoresContrast;
            uniform half _Heat;
            uniform half _PopulationShoresMountains;
            uniform half _HeatMultiplier;
            uniform half _VegetationMultiplier;
            uniform half _NoVegetationMultiplier;
            uniform float _PopulationLandOcean;
            uniform sampler2D _CloudsPole; uniform float4 _CloudsPole_ST;
            float CloudsPoleShadowsUnpack( sampler2D tex , float2 UV ){
            return(tex2Dbias(tex,float4(UV,0,5)).r);
            }
            
            uniform fixed _CloudsAvgBlend;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 NormalsLocalNormalized = normalize(mul( unity_WorldToObject, float4(normalize(i.normalDir),0) ).xyz.rgb);
                fixed3 NormalMult1 = (NormalsLocalNormalized*3.8416*NormalsLocalNormalized*NormalsLocalNormalized*NormalsLocalNormalized);
                fixed3 NormalComp = NormalMult1.rgb;
                float3 Mask = (NormalMult1/(NormalComp.r+NormalComp.g+NormalComp.b));
                fixed3 _Mask = Mask;
                float UVRotX_ang = _RandomSeed;
                float UVRotX_spd = 1.0;
                float UVRotX_cos = cos(UVRotX_spd*UVRotX_ang);
                float UVRotX_sin = sin(UVRotX_spd*UVRotX_ang);
                float2 UVRotX_piv = float2(0.5,0.5);
                float3 PosScaled = ((_Size*4.9+0.1)*mul( unity_WorldToObject, float4((i.posWorld.rgb-objPos.rgb),0) ).xyz.rgb);
                float2 UVRotX = (mul((PosScaled.gb*0.5+0.5)-UVRotX_piv,float2x2( UVRotX_cos, -UVRotX_sin, UVRotX_sin, UVRotX_cos))+UVRotX_piv);
                float2 UVPanX = (UVRotX+_RandomSeed*float2(0.7,0));
                float2 UVX = lerp(UVPanX,(half2(0.3,0)+UVPanX),(sign(NormalsLocalNormalized.r)*0.5+0.5));
                float2 _UVX = UVX;
                float3 NormalX = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(_UVX, _Normal)));
                float4 HeightX = tex2D(_Height,TRANSFORM_TEX(_UVX, _Height));
                float UVRotY_ang = (_RandomSeed*4.0);
                float UVRotY_spd = 1.0;
                float UVRotY_cos = cos(UVRotY_spd*UVRotY_ang);
                float UVRotY_sin = sin(UVRotY_spd*UVRotY_ang);
                float2 UVRotY_piv = float2(0.5,0.5);
                half2 _PolesPos1 = (PosScaled.rb*0.5+0.5);
                float2 UVRotY = (mul(_PolesPos1-UVRotY_piv,float2x2( UVRotY_cos, -UVRotY_sin, UVRotY_sin, UVRotY_cos))+UVRotY_piv);
                float2 UVPanY = (UVRotY+_RandomSeed*float2(0,0.7));
                float2 UVY = lerp(UVPanY,(half2(0.3,0.3)+UVPanY),(sign(NormalsLocalNormalized.g)*0.5+0.5));
                float2 _UVY = UVY;
                float4 HeightY = tex2D(_Height,TRANSFORM_TEX(_UVY, _Height));
                float UVRotZ_ang = (_RandomSeed*8.0);
                float UVRotZ_spd = 1.0;
                float UVRotZ_cos = cos(UVRotZ_spd*UVRotZ_ang);
                float UVRotZ_sin = sin(UVRotZ_spd*UVRotZ_ang);
                float2 UVRotZ_piv = float2(0.5,0.5);
                float2 UVRotZ = (mul((PosScaled.rg*0.5+0.5)-UVRotZ_piv,float2x2( UVRotZ_cos, -UVRotZ_sin, UVRotZ_sin, UVRotZ_cos))+UVRotZ_piv);
                float2 UVPanZ = (UVRotZ+_RandomSeed*float2(-0.7,0.7));
                float2 UVZ = lerp(UVPanZ,(half2(0,0.3)+UVPanZ),(sign(NormalsLocalNormalized.b)*0.5+0.5));
                float2 _UVZ = UVZ;
                float4 HeightZ = tex2D(_Height,TRANSFORM_TEX(_UVZ, _Height));
                half Height = (1.0*(_Mask.r*HeightX.a + _Mask.g*HeightY.a + _Mask.b*HeightZ.a));
                half zero = 0.0;
                float heightNormalized = saturate((zero + ( (Height - _WaterLevel) * (1.0 - zero) ) / (1.0 - _WaterLevel)));
                half ShoresContrastRemaped = (_ShoresContrast*0.09000003+0.9);
                float _water = saturate((zero + ( ((1.0 - heightNormalized) - ShoresContrastRemaped) * (1.0 - zero) ) / (1.0 - ShoresContrastRemaped)));
                float WaterRelief = (1.0 - (0.7*_water));
                float3 node_2345 = Rotate( (_Relief*NormalX.rgb*WaterRelief) , _RandomSeed );
                float3 NormalY = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(_UVY, _Normal)));
                float3 node_8871 = Rotate2( (_Relief*NormalY.rgb*WaterRelief) , (_RandomSeed*4.0) );
                float3 NormalZ = UnpackNormal(tex2D(_Normal,TRANSFORM_TEX(_UVZ, _Normal)));
                float3 node_9631 = Rotate3( (_Relief*NormalZ.rgb*WaterRelief) , (_RandomSeed*8.0) );
                fixed minuszero = (-0.001);
                half oceanDepth = (zero + ( (Height - minuszero) * (1.0 - zero) ) / (_WaterLevel - minuszero));
                float poles = abs(NormalsLocalNormalized.g);
                half polesContrast = (_Frost*-1.58+0.16);
                half IminFrostContrast = (0.5-((1.0 - polesContrast)*0.5));
                fixed zero5 = 0.0;
                half PolesReachMao = ( saturate((zero5 + ( ((clamp(lerp(_Frost,(_Frost-0.3),_water),-0.51,3)+poles) - IminFrostContrast) * (1.0 - zero5) ) / ((0.5+((1.0 - polesContrast)*0.5)) - IminFrostContrast))) > 0.5 ? (1.0-(1.0-2.0*(saturate((zero5 + ( ((clamp(lerp(_Frost,(_Frost-0.3),_water),-0.51,3)+poles) - IminFrostContrast) * (1.0 - zero5) ) / ((0.5+((1.0 - polesContrast)*0.5)) - IminFrostContrast)))-0.5))*(1.0-lerp((Height*1.0),(1.0*oceanDepth),_water))) : (2.0*saturate((zero5 + ( ((clamp(lerp(_Frost,(_Frost-0.3),_water),-0.51,3)+poles) - IminFrostContrast) * (1.0 - zero5) ) / ((0.5+((1.0 - polesContrast)*0.5)) - IminFrostContrast)))*lerp((Height*1.0),(1.0*oceanDepth),_water)) );
                half PolesContrastIMin = (0.5-((1.0 - _FrostContrast)*0.5));
                half Freezing = saturate((zero5 + ( (PolesReachMao - PolesContrastIMin) * (1.0 - zero5) ) / ((0.5+((1.0 - _FrostContrast)*0.5)) - PolesContrastIMin))); // Frezing
                half CloudsAmounbtNeg = (-1*(1.0 - _CloudsAmount));
                float4 timeClouds = _Time + _TimeEditor;
                fixed PolesCaps = saturate((poles*-5.0+4.5));
                float4 node_393 = _Time + _TimeEditor;
                float CloudsPoleUV_ang = node_393.g;
                float CloudsPoleUV_spd = (_CloudsSpeed*(-0.1));
                float CloudsPoleUV_cos = cos(CloudsPoleUV_spd*CloudsPoleUV_ang);
                float CloudsPoleUV_sin = sin(CloudsPoleUV_spd*CloudsPoleUV_ang);
                float2 CloudsPoleUV_piv = half2(0.5,0.5);
                half2 CloudsPoleUV = (mul((_PolesPos1*0.6+0.21)-CloudsPoleUV_piv,float2x2( CloudsPoleUV_cos, -CloudsPoleUV_sin, CloudsPoleUV_sin, CloudsPoleUV_cos))+CloudsPoleUV_piv);
                half4 _CloudsPoleDif = tex2D(_CloudsPole,TRANSFORM_TEX(CloudsPoleUV, _CloudsPole));
                float _clouds = pow(saturate((((CloudsAmounbtNeg+Clouds( i.uv0 , timeClouds.g , _Clouds , _CloudsSpeed , _CloudsAvgBlend ))*PolesCaps)+(CloudsAmounbtNeg+saturate((_CloudsPoleDif.r-PolesCaps))))),(_CloudsSpread*-0.5+1.0));
                float3 normalDirection = lerp(normalize(mul( unity_ObjectToWorld, float4((_Mask.r*normX( node_2345 , NormalsLocalNormalized ) + _Mask.g*normYX( node_8871 , NormalsLocalNormalized ) + _Mask.b*normXZ( node_9631 , NormalsLocalNormalized )),0) ).xyz.rgb),i.normalDir,max(((1.0 - Freezing)*_water),_clouds));
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float2 heightGradientUV = float2(heightNormalized,0.0);
                half4 _HeightGradient_var = tex2D(_HeightGradient,TRANSFORM_TEX(heightGradientUV, _HeightGradient));
                half4 DetailsX = tex2D(_AdditionalDetails,TRANSFORM_TEX(_UVX, _AdditionalDetails));
                half4 DetailsY = tex2D(_AdditionalDetails,TRANSFORM_TEX(_UVY, _AdditionalDetails));
                half4 DetailsZ = tex2D(_AdditionalDetails,TRANSFORM_TEX(_UVZ, _AdditionalDetails));
                half DetailsAlpha = (_Mask.r*DetailsX.a + _Mask.g*DetailsY.a + _Mask.b*DetailsZ.a);
                half2 aDetailsGradUV = float2(DetailsAlpha,1.0);
                half4 _DetailsGradient_var = tex2D(_DetailsGradient,TRANSFORM_TEX(aDetailsGradUV, _DetailsGradient));
                half3 Ground = lerp(_HeightGradient_var.rgb,(_HeightGradient_var.rgb+_DetailsGradient_var.rgb),_DetailsGradient_var.a);
                half3 VegetationColor = saturate(((0.3*heightNormalized)+_Vegetation.rgb));
                float4 VegetationHSV_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 VegetationHSV_p = lerp(float4(float4(VegetationColor,0.0).zy, VegetationHSV_k.wz), float4(float4(VegetationColor,0.0).yz, VegetationHSV_k.xy), step(float4(VegetationColor,0.0).z, float4(VegetationColor,0.0).y));
                float4 VegetationHSV_q = lerp(float4(VegetationHSV_p.xyw, float4(VegetationColor,0.0).x), float4(float4(VegetationColor,0.0).x, VegetationHSV_p.yzx), step(VegetationHSV_p.x, float4(VegetationColor,0.0).x));
                float VegetationHSV_d = VegetationHSV_q.x - min(VegetationHSV_q.w, VegetationHSV_q.y);
                float VegetationHSV_e = 1.0e-10;
                half3 VegetationHSV = float3(abs(VegetationHSV_q.z + (VegetationHSV_q.w - VegetationHSV_q.y) / (6.0 * VegetationHSV_d + VegetationHSV_e)), VegetationHSV_d / (VegetationHSV_q.x + VegetationHSV_e), VegetationHSV_q.x);;
                float Heat = saturate(((1.0 - poles)+(((-0.5)*heightNormalized)+(_Heat*2.5+-1.0)))); // Heat
                half zero4 = 0.0;
                half4 VegetationX = tex2D(_FertilityMap,TRANSFORM_TEX(_UVX, _FertilityMap));
                half4 VegetationY = tex2D(_FertilityMap,TRANSFORM_TEX(_UVY, _FertilityMap));
                half4 VegetationZ = tex2D(_FertilityMap,TRANSFORM_TEX(_UVZ, _FertilityMap));
                half PlantsMask = saturate(((1.0 - saturate((((saturate((PolesReachMao-(-1*(1.0 - (_VegetationFrostResistance*0.5+0.5)))))*1.3+-1.0)+poles+(0.35*heightNormalized))*2.857143+-0.857143)))*(zero4 + ( (((1.0 - saturate((zero4 + ( (Heat - _VegetationContrast) * (1.0 - zero4) ) / ((1.0 - _VegetationContrast) - _VegetationContrast))))*((_Fertility*1.6+-1.0)+((_Mask.r*VegetationX.a + _Mask.g*VegetationY.a + _Mask.b*VegetationZ.a)+(heightNormalized*(-0.3))))) - _VegetationContrast) * (1.0 - zero4) ) / ((1.0 - _VegetationContrast) - _VegetationContrast))));
                half OpacityRemaped = (_OceanOpacity*2.0+-2.0);
                half OceanDepthRemapped = (saturate((OpacityRemaped + ( (oceanDepth - zero) * (1.0 - OpacityRemaped) ) / (1.0 - zero)))*2.5);
                half3 Oceans = (_AtmosphereColor.rgb*(OceanDepthRemapped+1.0));
                float4 OceansHSV_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 OceansHSV_p = lerp(float4(float4(Oceans,0.0).zy, OceansHSV_k.wz), float4(float4(Oceans,0.0).yz, OceansHSV_k.xy), step(float4(Oceans,0.0).z, float4(Oceans,0.0).y));
                float4 OceansHSV_q = lerp(float4(OceansHSV_p.xyw, float4(Oceans,0.0).x), float4(float4(Oceans,0.0).x, OceansHSV_p.yzx), step(OceansHSV_p.x, float4(Oceans,0.0).x));
                float OceansHSV_d = OceansHSV_q.x - min(OceansHSV_q.w, OceansHSV_q.y);
                float OceansHSV_e = 1.0e-10;
                half3 OceansHSV = float3(abs(OceansHSV_q.z + (OceansHSV_q.w - OceansHSV_q.y) / (6.0 * OceansHSV_d + OceansHSV_e)), OceansHSV_d / (OceansHSV_q.x + OceansHSV_e), OceansHSV_q.x);;
                float node_332 = 1.0;
                float node_7627 = 1.0;
                float _cloudsShadows = pow(saturate(((CloudsAmounbtNeg+saturate((CloudsPoleShadowsUnpack( _CloudsPole , CloudsPoleUV )-PolesCaps)))+(PolesCaps*(CloudsShadows( (((0.02*_CloudsHeight)*float2(dot(lightDirection,i.tangentDir),dot(lightDirection,i.bitangentDir)))+i.uv0) , timeClouds.g , _Clouds , _CloudsSpeed , _CloudsAvgBlend )+(-1*(1.0 - _CloudsAmount)))))),(_CloudsSpread*-0.5+1.0));
                float3 Diffuze = lerp((lerp(lerp(lerp(Ground,saturate(( lerp((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),VegetationHSV.g)*clamp((VegetationHSV.b-saturate((heightNormalized*-1.0+0.1))),0.1,1)),(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),clamp((VegetationHSV.g-0.5),0.2,1))*VegetationHSV.b),Heat) > 0.5 ? (1.0-(1.0-2.0*(lerp((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),VegetationHSV.g)*clamp((VegetationHSV.b-saturate((heightNormalized*-1.0+0.1))),0.1,1)),(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),clamp((VegetationHSV.g-0.5),0.2,1))*VegetationHSV.b),Heat)-0.5))*(1.0-Ground)) : (2.0*lerp((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),VegetationHSV.g)*clamp((VegetationHSV.b-saturate((heightNormalized*-1.0+0.1))),0.1,1)),(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(VegetationHSV.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),clamp((VegetationHSV.g-0.5),0.2,1))*VegetationHSV.b),Heat)*Ground) )),PlantsMask),saturate(((pow(1.0-max(0,dot(normalDirection, viewDirection)),6.0)*0.5+0.5)*(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((OceansHSV.r-(OceanDepthRemapped*0.025))+float3(0.0,-1.0/3.0,1.0/3.0)))-1),OceansHSV.g)*OceansHSV.b))),_water),saturate((1.0-(1.0-(lerp(lerp(_AtmosphereColor.rgb,float3(node_332,node_332,node_332),0.1),float3(node_7627,node_7627,node_7627),Height)*Freezing))*(1.0-(DetailsAlpha*0.4)))),Freezing)*(1.0 - (_cloudsShadows*0.7))),_CloudsColor.rgb,_clouds); // Diffuse
                float Lightside = max(0,dot(lightDirection,normalDirection)); // Lambert
                float node_6923 = 0.0;
                float3 node_9816 = lerp((lerp(_water,((0.1*Freezing)+(_water*0.1)),Freezing)*saturate((0.6+_AtmosphereColor.rgb))*_Specularity),float3(node_6923,node_6923,node_6923),_clouds); // Spec
                float2 _CityUVX = (_UVX*3.0);
                float4 CityX = tex2D(_Cities,TRANSFORM_TEX(_CityUVX, _Cities));
                float2 _CityUVY = (_UVY*3.0);
                float4 CityY = tex2D(_Cities,TRANSFORM_TEX(_CityUVY, _Cities));
                float2 _CityUVZ = (_UVZ*3.0);
                float4 CityZ = tex2D(_Cities,TRANSFORM_TEX(_CityUVZ, _Cities));
                half popFrost = lerp((_Population*_PopulationFrostModifier),_Population,(1.0 - Freezing)); // PopFrost
                half popHeat = lerp(popFrost,(popFrost*_HeatMultiplier),Heat); // PopHeat
                half popVeg = lerp(popHeat,(popHeat*_VegetationMultiplier),PlantsMask);
                half LightSide = min(0,dot(lightDirection,i.normalDir)); // Lambert
                float3 finalColor = ((((Diffuze*Lightside)+(Lightside*pow(max(0,dot(normalDirection,halfDirection)),exp(lerp(1,11,_Gloss)))*node_9816*2.0))*_LightColor0.rgb*attenuation)+((clamp((((_Mask.r*CityX.r + _Mask.g*CityY.r + _Mask.b*CityZ.r)*lerp((1.0 - _water),_water,_PopulationLandOcean))-(1.0 - saturate((((lerp(popVeg,(popVeg*_NoVegetationMultiplier),(1.0 - PlantsMask))*2.0+-1.0)+lerp(lerp((1.0 - heightNormalized),heightNormalized,_PopulationShoresMountains),oceanDepth,_PopulationLandOcean))*5.0+-0.5)))),0,1)*abs(LightSide))*_CitiesColor.rgb));
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
