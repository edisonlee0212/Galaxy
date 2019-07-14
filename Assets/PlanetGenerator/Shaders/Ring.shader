// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:0,wrdp:False,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:True,aust:False,igpj:True,qofs:1,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:35412,y:32442,varname:node_9361,prsc:2|diff-3265-OUT,alpha-188-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:9684,x:32766,y:32965,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:_Noise,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6171,x:33277,y:32841,varname:_node_6171,prsc:2,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False|UVIN-8645-OUT,TEX-9684-TEX;n:type:ShaderForge.SFN_TexCoord,id:8061,x:31483,y:32785,varname:node_8061,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Append,id:8645,x:32954,y:32753,varname:node_8645,prsc:2|A-9129-OUT,B-3646-OUT;n:type:ShaderForge.SFN_Vector1,id:5085,x:32485,y:32458,varname:node_5085,prsc:2,v1:6;n:type:ShaderForge.SFN_RemapRange,id:7014,x:32091,y:32813,varname:node_7014,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-8061-UVOUT;n:type:ShaderForge.SFN_Length,id:274,x:32456,y:32819,varname:node_274,prsc:2|IN-7014-OUT;n:type:ShaderForge.SFN_Clamp01,id:7091,x:32804,y:33188,varname:node_7091,prsc:2|IN-707-OUT;n:type:ShaderForge.SFN_OneMinus,id:5552,x:32965,y:33188,varname:node_5552,prsc:2|IN-7091-OUT;n:type:ShaderForge.SFN_Multiply,id:2335,x:33693,y:32842,varname:node_2335,prsc:2|A-6171-R,B-7034-OUT;n:type:ShaderForge.SFN_Slider,id:3646,x:32410,y:33002,ptovrint:True,ptlb:RandomSeed,ptin:_RandomSeed,varname:_RandomSeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_NormalVector,id:5515,x:33219,y:33038,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:3062,x:33479,y:33088,varname:node_3062,prsc:2,dt:0|A-5515-OUT,B-9093-OUT;n:type:ShaderForge.SFN_ViewVector,id:9093,x:33219,y:33188,varname:node_9093,prsc:2;n:type:ShaderForge.SFN_ArcTan2,id:7250,x:32360,y:32542,varname:node_7250,prsc:2,attp:2|A-6058-G,B-6058-R;n:type:ShaderForge.SFN_ComponentMask,id:6058,x:32268,y:32680,varname:node_6058,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-7014-OUT;n:type:ShaderForge.SFN_Append,id:3919,x:33119,y:32520,varname:node_3919,prsc:2|A-5825-OUT,B-9025-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:5167,x:32753,y:33700,varname:node_5167,prsc:2|IN-274-OUT,IMIN-8518-OUT,IMAX-5305-OUT,OMIN-8887-OUT,OMAX-7967-OUT;n:type:ShaderForge.SFN_Vector1,id:8887,x:32530,y:33771,varname:node_8887,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:7967,x:32530,y:33867,varname:node_7967,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:1297,x:32023,y:33396,varname:node_1297,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Slider,id:5305,x:32040,y:33717,ptovrint:False,ptlb:InnerRadius,ptin:_InnerRadius,varname:_InnerRadius,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5798105,max:1;n:type:ShaderForge.SFN_Subtract,id:8518,x:32530,y:33630,varname:node_8518,prsc:2|A-5305-OUT,B-4437-OUT;n:type:ShaderForge.SFN_Slider,id:6558,x:31927,y:33553,ptovrint:False,ptlb:Border,ptin:_Border,varname:_Border,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2860786,max:1;n:type:ShaderForge.SFN_Multiply,id:4437,x:32257,y:33416,varname:node_4437,prsc:2|A-1297-OUT,B-6558-OUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:707,x:32766,y:33411,varname:node_707,prsc:2|IN-274-OUT,IMIN-1643-OUT,IMAX-820-OUT,OMIN-4156-OUT,OMAX-6623-OUT;n:type:ShaderForge.SFN_Vector1,id:6623,x:32529,y:33517,varname:node_6623,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:4156,x:32529,y:33445,varname:node_4156,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:820,x:32529,y:33392,varname:node_820,prsc:2,v1:1;n:type:ShaderForge.SFN_OneMinus,id:1643,x:32375,y:33251,varname:node_1643,prsc:2|IN-4437-OUT;n:type:ShaderForge.SFN_OneMinus,id:2838,x:32916,y:33700,varname:node_2838,prsc:2|IN-5167-OUT;n:type:ShaderForge.SFN_Multiply,id:7034,x:33157,y:33419,varname:node_7034,prsc:2|A-5552-OUT,B-7506-OUT;n:type:ShaderForge.SFN_Clamp01,id:7506,x:33117,y:33606,varname:node_7506,prsc:2|IN-2838-OUT;n:type:ShaderForge.SFN_Multiply,id:1376,x:32654,y:32444,varname:node_1376,prsc:2|A-5085-OUT,B-7250-OUT;n:type:ShaderForge.SFN_Add,id:9025,x:32941,y:32384,varname:node_9025,prsc:2|A-4213-OUT,B-1376-OUT;n:type:ShaderForge.SFN_Time,id:9277,x:32597,y:32276,varname:node_9277,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5825,x:32607,y:32622,varname:node_5825,prsc:2|A-8637-OUT,B-274-OUT;n:type:ShaderForge.SFN_Vector1,id:8637,x:32523,y:32573,varname:node_8637,prsc:2,v1:3;n:type:ShaderForge.SFN_Multiply,id:4188,x:34537,y:32743,varname:node_4188,prsc:2|A-4315-OUT,B-3062-OUT;n:type:ShaderForge.SFN_LightVector,id:453,x:30198,y:32730,varname:node_453,prsc:2;n:type:ShaderForge.SFN_Rotator,id:986,x:31761,y:32593,varname:node_986,prsc:2|UVIN-7014-OUT,PIV-1810-OUT,ANG-8876-OUT;n:type:ShaderForge.SFN_Vector2,id:1810,x:31501,y:32623,varname:node_1810,prsc:2,v1:0,v2:0;n:type:ShaderForge.SFN_Multiply,id:8876,x:31488,y:32474,varname:node_8876,prsc:2|A-9998-OUT,B-2073-OUT,C-4921-OUT,D-9336-VFACE;n:type:ShaderForge.SFN_Tau,id:9209,x:31115,y:32484,varname:node_9209,prsc:2;n:type:ShaderForge.SFN_Vector1,id:9998,x:31255,y:32559,varname:node_9998,prsc:2,v1:6.283185;n:type:ShaderForge.SFN_ComponentMask,id:1397,x:31911,y:32547,varname:node_1397,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-986-UVOUT;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:3194,x:32285,y:32346,varname:node_3194,prsc:2|IN-1397-R,IMIN-7317-OUT,IMAX-8553-OUT,OMIN-5918-OUT,OMAX-4530-OUT;n:type:ShaderForge.SFN_Vector1,id:4530,x:31891,y:32474,varname:node_4530,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:5918,x:31835,y:32381,varname:node_5918,prsc:2,v1:1;n:type:ShaderForge.SFN_Slider,id:1405,x:31348,y:32306,ptovrint:False,ptlb:ShadowSize,ptin:_ShadowSize,varname:_ShadowSize,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4715023,max:1;n:type:ShaderForge.SFN_Vector1,id:5168,x:31835,y:32270,varname:node_5168,prsc:2,v1:0.03;n:type:ShaderForge.SFN_Subtract,id:7317,x:31996,y:32249,varname:node_7317,prsc:2|A-8553-OUT,B-5168-OUT;n:type:ShaderForge.SFN_Min,id:8553,x:31733,y:32094,varname:node_8553,prsc:2|A-1405-OUT,B-5305-OUT;n:type:ShaderForge.SFN_Vector1,id:302,x:31944,y:32020,varname:node_302,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:4424,x:31888,y:31927,varname:node_4424,prsc:2,v1:1;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:5856,x:32304,y:31822,varname:node_5856,prsc:2|IN-4775-OUT,IMIN-4323-OUT,IMAX-8553-OUT,OMIN-4424-OUT,OMAX-302-OUT;n:type:ShaderForge.SFN_Subtract,id:4323,x:32049,y:31795,varname:node_4323,prsc:2|A-8553-OUT,B-7696-OUT;n:type:ShaderForge.SFN_Vector1,id:7696,x:31888,y:31816,varname:node_7696,prsc:2,v1:0.03;n:type:ShaderForge.SFN_Negate,id:4775,x:32149,y:32064,varname:node_4775,prsc:2|IN-1397-R;n:type:ShaderForge.SFN_Multiply,id:1418,x:32648,y:32030,varname:node_1418,prsc:2|A-4428-OUT,B-1783-OUT;n:type:ShaderForge.SFN_Clamp01,id:4428,x:32438,y:31990,varname:node_4428,prsc:2|IN-5856-OUT;n:type:ShaderForge.SFN_Clamp01,id:1783,x:32438,y:32121,varname:node_1783,prsc:2|IN-3194-OUT;n:type:ShaderForge.SFN_RemapRange,id:697,x:32130,y:32531,varname:node_697,prsc:2,frmn:0,frmx:0.1,tomn:0,tomx:1|IN-1397-G;n:type:ShaderForge.SFN_Clamp01,id:8001,x:32648,y:32142,varname:node_8001,prsc:2|IN-697-OUT;n:type:ShaderForge.SFN_Multiply,id:2939,x:32869,y:32061,varname:node_2939,prsc:2|A-1418-OUT,B-8001-OUT;n:type:ShaderForge.SFN_OneMinus,id:9557,x:33390,y:32284,varname:node_9557,prsc:2|IN-2939-OUT;n:type:ShaderForge.SFN_Multiply,id:776,x:34821,y:32389,varname:node_776,prsc:2|A-550-OUT,B-9557-OUT;n:type:ShaderForge.SFN_Append,id:284,x:30760,y:32287,varname:node_284,prsc:2;n:type:ShaderForge.SFN_Cross,id:1695,x:30688,y:32840,varname:node_1695,prsc:2|A-4294-OUT,B-2325-OUT;n:type:ShaderForge.SFN_Vector1,id:4921,x:31203,y:32742,varname:node_4921,prsc:2,v1:1;n:type:ShaderForge.SFN_Normalize,id:2325,x:30407,y:32930,varname:node_2325,prsc:2|IN-2353-OUT;n:type:ShaderForge.SFN_Normalize,id:3180,x:30427,y:33179,varname:node_3180,prsc:2|IN-4294-OUT;n:type:ShaderForge.SFN_Dot,id:3718,x:30874,y:33021,varname:node_3718,prsc:2,dt:0|A-2325-OUT,B-3180-OUT;n:type:ShaderForge.SFN_ArcTan2,id:93,x:31123,y:32922,varname:node_93,prsc:2,attp:2|A-4759-OUT,B-3718-OUT;n:type:ShaderForge.SFN_Tangent,id:7273,x:30025,y:32974,varname:node_7273,prsc:2;n:type:ShaderForge.SFN_Bitangent,id:4294,x:30125,y:33106,varname:node_4294,prsc:2;n:type:ShaderForge.SFN_Vector3,id:9475,x:30650,y:33197,varname:node_9475,prsc:2,v1:0,v2:0,v3:0;n:type:ShaderForge.SFN_Clamp01,id:2863,x:30607,y:33006,varname:node_2863,prsc:2|IN-4294-OUT;n:type:ShaderForge.SFN_ComponentMask,id:9445,x:30872,y:32676,varname:node_9445,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-1695-OUT;n:type:ShaderForge.SFN_NormalVector,id:8746,x:30639,y:32677,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:4759,x:30902,y:32830,varname:node_4759,prsc:2,dt:0|A-8746-OUT,B-1695-OUT;n:type:ShaderForge.SFN_Negate,id:2073,x:31378,y:32954,varname:node_2073,prsc:2|IN-93-OUT;n:type:ShaderForge.SFN_Color,id:8266,x:34036,y:31932,ptovrint:False,ptlb:Color1,ptin:_Color1,varname:_Color1,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Code,id:550,x:34391,y:32193,varname:node_550,prsc:2,code:ZgBsAG8AYQB0ADMAIABvADsACgBpAGYAKAB0ADwAMAApAAoAbwA9AGwAZQByAHAAKABBACwAQgAsAHQAKwAxACkAOwAKAGkAZgAoAHQAPgA9ADEAKQAKAG8APQBsAGUAcgBwACgAQgAsAEMALAB0ACkAOwAKAHIAZQB0AHUAcgBuACAAbwA7AA==,output:2,fname:Function_node_550,width:247,height:132,input:2,input:2,input:2,input:0,input_1_label:A,input_2_label:B,input_3_label:C,input_4_label:t|A-8266-RGB,B-5244-RGB,C-9692-RGB,D-1926-OUT;n:type:ShaderForge.SFN_Color,id:5244,x:34036,y:32143,ptovrint:False,ptlb:Color2,ptin:_Color2,varname:_Color2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Color,id:9692,x:34022,y:32371,ptovrint:False,ptlb:Color3,ptin:_Color3,varname:_Color3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.7655173,c3:0,c4:1;n:type:ShaderForge.SFN_RemapRange,id:1926,x:34180,y:32532,varname:node_1926,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-4315-OUT;n:type:ShaderForge.SFN_Multiply,id:757,x:33295,y:32490,varname:node_757,prsc:2|A-3919-OUT,B-2327-OUT;n:type:ShaderForge.SFN_Vector1,id:2327,x:33147,y:32333,varname:node_2327,prsc:2,v1:1;n:type:ShaderForge.SFN_Tex2d,id:2002,x:33576,y:32530,varname:_node_1592,prsc:2,tex:877a709325ffbb340a453962d119c2ca,ntxv:0,isnm:False|UVIN-757-OUT,TEX-9684-TEX;n:type:ShaderForge.SFN_RemapRange,id:4498,x:33853,y:32592,varname:node_4498,prsc:2,frmn:0.5,frmx:1,tomn:0,tomx:1|IN-664-OUT;n:type:ShaderForge.SFN_Slider,id:4132,x:32790,y:32238,ptovrint:False,ptlb:Speed,ptin:_Speed,varname:_Speed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:4213,x:32801,y:32324,varname:node_4213,prsc:2|A-4132-OUT,B-9277-TSL;n:type:ShaderForge.SFN_Lerp,id:4315,x:34275,y:32731,varname:node_4315,prsc:2|A-4498-OUT,B-2335-OUT,T-5641-OUT;n:type:ShaderForge.SFN_Depth,id:4842,x:33777,y:33110,varname:node_4842,prsc:2;n:type:ShaderForge.SFN_Clamp01,id:5641,x:34184,y:33110,varname:node_5641,prsc:2|IN-7552-OUT;n:type:ShaderForge.SFN_RemapRange,id:7552,x:33945,y:33016,varname:node_7552,prsc:2,frmn:0,frmx:1,tomn:0.7,tomx:1|IN-4842-OUT;n:type:ShaderForge.SFN_Multiply,id:9129,x:32690,y:32768,varname:node_9129,prsc:2|A-5915-OUT,B-274-OUT;n:type:ShaderForge.SFN_Slider,id:5915,x:32366,y:32727,ptovrint:False,ptlb:Coils,ptin:_Coils,varname:_Coils,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:2;n:type:ShaderForge.SFN_Tex2d,id:8238,x:33512,y:32190,ptovrint:False,ptlb:Details,ptin:_Details,varname:_Details,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:14f3a1b08a68f25438495eccc7f73555,ntxv:0,isnm:False|UVIN-757-OUT;n:type:ShaderForge.SFN_LightColor,id:6376,x:34708,y:31995,varname:node_6376,prsc:2;n:type:ShaderForge.SFN_Slider,id:9187,x:34583,y:32559,ptovrint:False,ptlb:Brightness,ptin:_Brightness,varname:_Brightness,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.830409,max:7;n:type:ShaderForge.SFN_Multiply,id:3265,x:35046,y:32426,varname:node_3265,prsc:2|A-9187-OUT,B-776-OUT;n:type:ShaderForge.SFN_Multiply,id:664,x:33821,y:32238,varname:node_664,prsc:2|A-8238-R,B-7034-OUT;n:type:ShaderForge.SFN_Clamp01,id:188,x:34829,y:32700,varname:node_188,prsc:2|IN-8056-OUT;n:type:ShaderForge.SFN_RemapRange,id:8056,x:34694,y:32893,varname:node_8056,prsc:2,frmn:0,frmx:0.8,tomn:0,tomx:1|IN-4188-OUT;n:type:ShaderForge.SFN_FaceSign,id:9336,x:31325,y:32638,varname:node_9336,prsc:2,fstp:1;n:type:ShaderForge.SFN_LightPosition,id:3343,x:30227,y:32559,varname:node_3343,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:2693,x:30227,y:32432,varname:node_2693,prsc:2;n:type:ShaderForge.SFN_Subtract,id:3148,x:30421,y:32342,varname:node_3148,prsc:2|A-3343-XYZ,B-2693-XYZ;n:type:ShaderForge.SFN_Lerp,id:2353,x:30622,y:32453,varname:node_2353,prsc:2|A-3343-XYZ,B-3148-OUT,T-3343-PNT;n:type:ShaderForge.SFN_Max,id:8929,x:33710,y:32392,varname:node_8929,prsc:2;proporder:9684-3646-6558-5305-1405-8266-5244-9692-4132-5915-8238-9187;pass:END;sub:END;*/

Shader "Human Unit/Ring" {
    Properties {
        _Noise ("Noise", 2D) = "white" {}
        _RandomSeed ("RandomSeed", Range(0, 1)) = 1
        _Border ("Border", Range(0, 1)) = 0.2860786
        _InnerRadius ("InnerRadius", Range(0, 1)) = 0.5798105
        _ShadowSize ("ShadowSize", Range(0, 1)) = 0.4715023
        _Color1 ("Color1", Color) = (1,0,0,1)
        _Color2 ("Color2", Color) = (1,1,1,1)
        _Color3 ("Color3", Color) = (1,0.7655173,0,1)
        _Speed ("Speed", Range(0, 1)) = 0
        _Coils ("Coils", Range(0, 2)) = 2
        _Details ("Details", 2D) = "white" {}
        _Brightness ("Brightness", Range(0, 7)) = 1.830409
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent+1"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZTest Less
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _RandomSeed;
            uniform float _InnerRadius;
            uniform float _Border;
            uniform float _ShadowSize;
            uniform float4 _Color1;
            float3 Function_node_550( float3 A , float3 B , float3 C , float t ){
            float3 o;
            if(t<0)
            o=lerp(A,B,t+1);
            if(t>=1)
            o=lerp(B,C,t);
            return o;
            }
            
            uniform float4 _Color2;
            uniform float4 _Color3;
            uniform float _Speed;
            uniform float _Coils;
            uniform sampler2D _Details; uniform float4 _Details_ST;
            uniform float _Brightness;
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
                float4 projPos : TEXCOORD5;
                UNITY_FOG_COORDS(6)
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
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float2 node_7014 = (i.uv0*2.0+-1.0);
                float node_274 = length(node_7014);
                float4 node_9277 = _Time;
                float2 node_6058 = node_7014.rg;
                float2 node_757 = (float2((3.0*node_274),((_Speed*node_9277.r)+(6.0*((atan2(node_6058.g,node_6058.r)/6.28318530718)+0.5))))*1.0);
                float4 _Details_var = tex2D(_Details,TRANSFORM_TEX(node_757, _Details));
                float node_4437 = (0.2*_Border);
                float node_1643 = (1.0 - node_4437);
                float node_4156 = 0.0;
                float node_8518 = (_InnerRadius-node_4437);
                float node_8887 = 1.0;
                float node_7034 = ((1.0 - saturate((node_4156 + ( (node_274 - node_1643) * (1.0 - node_4156) ) / (1.0 - node_1643))))*saturate((1.0 - (node_8887 + ( (node_274 - node_8518) * (0.0 - node_8887) ) / (_InnerRadius - node_8518)))));
                float2 node_8645 = float2((_Coils*node_274),_RandomSeed);
                float4 _node_6171 = tex2D(_Noise,TRANSFORM_TEX(node_8645, _Noise));
                float node_4315 = lerp(((_Details_var.r*node_7034)*2.0+-1.0),(_node_6171.r*node_7034),saturate((partZ*0.3+0.7)));
                float3 node_2325 = normalize(lerp(_WorldSpaceLightPos0.rgb,(_WorldSpaceLightPos0.rgb-objPos.rgb),_WorldSpaceLightPos0.a));
                float3 node_1695 = cross(i.bitangentDir,node_2325);
                float node_986_ang = (6.283185*(-1*((atan2(dot(i.normalDir,node_1695),dot(node_2325,normalize(i.bitangentDir)))/6.28318530718)+0.5))*1.0*faceSign);
                float node_986_spd = 1.0;
                float node_986_cos = cos(node_986_spd*node_986_ang);
                float node_986_sin = sin(node_986_spd*node_986_ang);
                float2 node_986_piv = float2(0,0);
                float2 node_986 = (mul(node_7014-node_986_piv,float2x2( node_986_cos, -node_986_sin, node_986_sin, node_986_cos))+node_986_piv);
                float2 node_1397 = node_986.rg;
                float node_8553 = min(_ShadowSize,_InnerRadius);
                float node_4323 = (node_8553-0.03);
                float node_4424 = 1.0;
                float node_7317 = (node_8553-0.03);
                float node_5918 = 1.0;
                float3 diffuseColor = (_Brightness*(Function_node_550( _Color1.rgb , _Color2.rgb , _Color3.rgb , (node_4315*2.0+-1.0) )*(1.0 - ((saturate((node_4424 + ( ((-1*node_1397.r) - node_4323) * (0.0 - node_4424) ) / (node_8553 - node_4323)))*saturate((node_5918 + ( (node_1397.r - node_7317) * (0.0 - node_5918) ) / (node_8553 - node_7317))))*saturate((node_1397.g*10.0+0.0))))));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,saturate(((node_4315*dot(i.normalDir,viewDirection))*1.25+0.0)));
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
            Cull Off
            ZTest Less
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            uniform float _RandomSeed;
            uniform float _InnerRadius;
            uniform float _Border;
            uniform float _ShadowSize;
            uniform float4 _Color1;
            float3 Function_node_550( float3 A , float3 B , float3 C , float t ){
            float3 o;
            if(t<0)
            o=lerp(A,B,t+1);
            if(t>=1)
            o=lerp(B,C,t);
            return o;
            }
            
            uniform float4 _Color2;
            uniform float4 _Color3;
            uniform float _Speed;
            uniform float _Coils;
            uniform sampler2D _Details; uniform float4 _Details_ST;
            uniform float _Brightness;
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
                float4 projPos : TEXCOORD5;
                LIGHTING_COORDS(6,7)
                UNITY_FOG_COORDS(8)
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
                UNITY_TRANSFER_FOG(o,o.pos);
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float2 node_7014 = (i.uv0*2.0+-1.0);
                float node_274 = length(node_7014);
                float4 node_9277 = _Time;
                float2 node_6058 = node_7014.rg;
                float2 node_757 = (float2((3.0*node_274),((_Speed*node_9277.r)+(6.0*((atan2(node_6058.g,node_6058.r)/6.28318530718)+0.5))))*1.0);
                float4 _Details_var = tex2D(_Details,TRANSFORM_TEX(node_757, _Details));
                float node_4437 = (0.2*_Border);
                float node_1643 = (1.0 - node_4437);
                float node_4156 = 0.0;
                float node_8518 = (_InnerRadius-node_4437);
                float node_8887 = 1.0;
                float node_7034 = ((1.0 - saturate((node_4156 + ( (node_274 - node_1643) * (1.0 - node_4156) ) / (1.0 - node_1643))))*saturate((1.0 - (node_8887 + ( (node_274 - node_8518) * (0.0 - node_8887) ) / (_InnerRadius - node_8518)))));
                float2 node_8645 = float2((_Coils*node_274),_RandomSeed);
                float4 _node_6171 = tex2D(_Noise,TRANSFORM_TEX(node_8645, _Noise));
                float node_4315 = lerp(((_Details_var.r*node_7034)*2.0+-1.0),(_node_6171.r*node_7034),saturate((partZ*0.3+0.7)));
                float3 node_2325 = normalize(lerp(_WorldSpaceLightPos0.rgb,(_WorldSpaceLightPos0.rgb-objPos.rgb),_WorldSpaceLightPos0.a));
                float3 node_1695 = cross(i.bitangentDir,node_2325);
                float node_986_ang = (6.283185*(-1*((atan2(dot(i.normalDir,node_1695),dot(node_2325,normalize(i.bitangentDir)))/6.28318530718)+0.5))*1.0*faceSign);
                float node_986_spd = 1.0;
                float node_986_cos = cos(node_986_spd*node_986_ang);
                float node_986_sin = sin(node_986_spd*node_986_ang);
                float2 node_986_piv = float2(0,0);
                float2 node_986 = (mul(node_7014-node_986_piv,float2x2( node_986_cos, -node_986_sin, node_986_sin, node_986_cos))+node_986_piv);
                float2 node_1397 = node_986.rg;
                float node_8553 = min(_ShadowSize,_InnerRadius);
                float node_4323 = (node_8553-0.03);
                float node_4424 = 1.0;
                float node_7317 = (node_8553-0.03);
                float node_5918 = 1.0;
                float3 diffuseColor = (_Brightness*(Function_node_550( _Color1.rgb , _Color2.rgb , _Color3.rgb , (node_4315*2.0+-1.0) )*(1.0 - ((saturate((node_4424 + ( ((-1*node_1397.r) - node_4323) * (0.0 - node_4424) ) / (node_8553 - node_4323)))*saturate((node_5918 + ( (node_1397.r - node_7317) * (0.0 - node_5918) ) / (node_8553 - node_7317))))*saturate((node_1397.g*10.0+0.0))))));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * saturate(((node_4315*dot(i.normalDir,viewDirection))*1.25+0.0)),0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
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
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal d3d11_9x 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
