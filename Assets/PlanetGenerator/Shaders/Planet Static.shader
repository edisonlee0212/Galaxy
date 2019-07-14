// Shader created with Shader Forge v1.37 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.37;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:False,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:37985,y:33943,varname:node_4013,prsc:2|gloss-1711-OUT,normal-4664-OUT,emission-5883-OUT,custl-6175-OUT;n:type:ShaderForge.SFN_NormalVector,id:9920,x:21016,y:36902,prsc:2,pt:False;n:type:ShaderForge.SFN_FragmentPosition,id:2254,x:21638,y:35890,varname:node_2254,prsc:2;n:type:ShaderForge.SFN_Transform,id:9950,x:21969,y:35890,varname:node_9950,prsc:2,tffrom:0,tfto:1|IN-6365-OUT;n:type:ShaderForge.SFN_Transform,id:57,x:21409,y:36892,varname:LocalNorm,prsc:0,tffrom:0,tfto:1|IN-4198-OUT;n:type:ShaderForge.SFN_Subtract,id:6365,x:21818,y:35890,varname:node_6365,prsc:2|A-2254-XYZ,B-9313-XYZ;n:type:ShaderForge.SFN_ObjectPosition,id:9313,x:21638,y:36023,varname:node_9313,prsc:2;n:type:ShaderForge.SFN_ComponentMask,id:5559,x:22512,y:35599,varname:node_5559,prsc:2,cc1:1,cc2:2,cc3:-1,cc4:-1|IN-1709-OUT;n:type:ShaderForge.SFN_ComponentMask,id:8892,x:22512,y:35753,varname:_PolesPos,prsc:2,cc1:0,cc2:2,cc3:-1,cc4:-1|IN-1709-OUT;n:type:ShaderForge.SFN_ComponentMask,id:6736,x:22459,y:35926,varname:node_6736,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1709-OUT;n:type:ShaderForge.SFN_Slider,id:568,x:21618,y:35699,ptovrint:False,ptlb:Size,ptin:_Size,varname:_Size,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1359223,max:1;n:type:ShaderForge.SFN_RemapRange,id:4104,x:21969,y:35701,varname:node_4104,prsc:2,frmn:0,frmx:1,tomn:0.1,tomx:5|IN-4965-OUT;n:type:ShaderForge.SFN_Slider,id:1711,x:35124,y:34456,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:_Gloss,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Tex2dAsset,id:9428,x:31447,y:37842,ptovrint:False,ptlb:Clouds,ptin:_Clouds,varname:_Clouds,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:9effae18b33be2c4fbce814725a8d014,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Get,id:8619,x:35816,y:33147,varname:node_8619,prsc:1|IN-9127-OUT;n:type:ShaderForge.SFN_Color,id:7447,x:35816,y:32953,ptovrint:False,ptlb:CloudsColor,ptin:_CloudsColor,varname:_CloudsColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Time,id:9728,x:30952,y:37913,varname:timeClouds,prsc:2;n:type:ShaderForge.SFN_Code,id:7712,x:31907,y:37357,varname:cloudsBlended,prsc:2,code:cwBwAGUAZQBkAD0AcwBwAGUAZQBkACoAMAAuADMAOwAKAGYAbABvAGEAdAAxACAAcwBpAG4AVABpAG0AZQAgAD0AIABmAHIAYQBjACgAcwBpAG4AKAB0AGkAbQBlAC4AeAAqAHMAcABlAGUAZAApACoAMAAuADAANQApADsACgBmAGwAbwBhAHQAMQAgAHMAaQBuAFQAaQBtAGUAMgAgAD0AIABmAHIAYQBjACgAcwBpAG4AKAB0AGkAbQBlAC4AeAAqAHMAcABlAGUAZAArADAALgA3ADgAKQAqADAALgAwADUAKQA7AAoAZgBsAG8AYQB0ADEAIABzAGkAbgBUAGkAbQBlADMAIAA9ACAAZgByAGEAYwAoAHMAaQBuACgAdABpAG0AZQAuAHgAKgBzAHAAZQBlAGQAKwAxAC4ANQA3ACkAKgAwAC4AMAA1ACkAOwAKAGYAbABvAGEAdAAxACAAcwBpAG4AVABpAG0AZQA0ACAAPQAgAGYAcgBhAGMAKABzAGkAbgAoAHQAaQBtAGUALgB4ACoAcwBwAGUAZQBkACsAMgAuADMANQApACoAMAAuADAANQApADsACgBmAGwAbwBhAHQAMQAgAGMAbABvAHUAZABzADEAIAA9ACAAdABlAHgAMgBEACgAdABlAHgALAAgAGYAbABvAGEAdAAyACgALQBVAFYALgByACsAZgByAGEAYwAoAHMAcABlAGUAZAAqAHQAaQBtAGUALgB4ACoAMAAuADAAMwA1ACsAMAAuADMAKQAsACAALQBVAFYALgBnACsAcwBpAG4AVABpAG0AZQAyACkAKQAuAHIAOwAKAGYAbABvAGEAdAAxACAAYwBsAG8AdQBkAHMAMgAgAD0AIAB0AGUAeAAyAEQAKAB0AGUAeAAsACAAZgBsAG8AYQB0ADIAKABVAFYALgByACsAZgByAGEAYwAoAHMAcABlAGUAZAAqAHQAaQBtAGUALgB4ACoAMAAuADAAMwApACwAVQBWAC4AZwArAHMAaQBuAFQAaQBtAGUAKQApAC4AcgA7AAoAZgBsAG8AYQB0ADEAIABjAGwAbwB1AGQAcwAzACAAPQAgAHQAZQB4ADIARAAoAHQAZQB4ACwAIABmAGwAbwBhAHQAMgAoAC0AVQBWAC4AcgAtAGYAcgBhAGMAKABzAHAAZQBlAGQAKgB0AGkAbQBlAC4AeAAqADAALgAwADMANQAtADAALgAzADUAKQAsAC0AVQBWAC4AZwArAHMAaQBuAFQAaQBtAGUAMwApACkALgByADsACgBmAGwAbwBhAHQAMQAgAGMAbABvAHUAZABzADQAIAA9ACAAdABlAHgAMgBEACgAdABlAHgALAAgAGYAbABvAGEAdAAyACgAVQBWAC4AcgAtAGYAcgBhAGMAKABzAHAAZQBlAGQAKgB0AGkAbQBlAC4AeAAqADAALgAwADMAKQAsAFUAVgAuAGcAKwBzAGkAbgBUAGkAbQBlADQAKQApAC4AcgA7AAoAaQBmACgAIABFACAAPQA9ACAAMQAuADAAKQANAAoAIAAgACAAIAByAGUAdAB1AHIAbgAoAHMAYQB0AHUAcgBhAHQAZQAoACgAMgAqAGMAbABvAHUAZABzADEAKwBjAGwAbwB1AGQAcwAyACsAMgAqAGMAbABvAHUAZABzADMAKwBjAGwAbwB1AGQAcwAyACkAKgAwAC4AMgA1ACkAKQA7AA0ACgBlAGwAcwBlAA0ACgAgACAAIAAgAHIAZQB0AHUAcgBuACgAcwBhAHQAdQByAGEAdABlACgAKAAyACoAYwBsAG8AdQBkAHMAMQAqAGMAbABvAHUAZABzADIAKwAyACoAYwBsAG8AdQBkAHMAMwAqAGMAbABvAHUAZABzADIAKQAqADAALgA1ACkAKQA7AAoA,output:0,fname:Clouds,width:720,height:244,input:1,input:0,input:12,input:0,input:8,input_1_label:UV,input_2_label:time,input_3_label:tex,input_4_label:speed,input_5_label:E|A-2828-UVOUT,B-9728-T,C-9428-TEX,D-5913-OUT,E-1528-OUT;n:type:ShaderForge.SFN_TexCoord,id:2828,x:31136,y:37343,varname:node_2828,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:5913,x:31290,y:38048,ptovrint:False,ptlb:CloudsSpeed,ptin:_CloudsSpeed,varname:_CloudsSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.4368932,max:1;n:type:ShaderForge.SFN_Slider,id:8615,x:31833,y:37090,ptovrint:False,ptlb:CloudsAmount,ptin:_CloudsAmount,varname:_CloudsAmount,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Set,id:9127,x:33945,y:37510,varname:_clouds,prsc:2|IN-9660-OUT;n:type:ShaderForge.SFN_Clamp01,id:9432,x:33449,y:37306,varname:node_9432,prsc:2|IN-1523-OUT;n:type:ShaderForge.SFN_Code,id:4175,x:32010,y:38866,varname:cloudsShadowsBlended,prsc:2,code:cwBwAGUAZQBkAD0AcwBwAGUAZQBkACoAMAAuADMAOwAKAGYAbABvAGEAdAAxACAAcwBpAG4AVABpAG0AZQAgAD0AIABmAHIAYQBjACgAcwBpAG4AKAB0AGkAbQBlAC4AeAAqAHMAcABlAGUAZAApACoAMAAuADAANQApADsACgBmAGwAbwBhAHQAMQAgAHMAaQBuAFQAaQBtAGUAMgAgAD0AIABmAHIAYQBjACgAcwBpAG4AKAB0AGkAbQBlAC4AeAAqAHMAcABlAGUAZAArADAALgA3ADgAKQAqADAALgAwADUAKQA7AAoAZgBsAG8AYQB0ADEAIABzAGkAbgBUAGkAbQBlADMAIAA9ACAAZgByAGEAYwAoAHMAaQBuACgAdABpAG0AZQAuAHgAKgBzAHAAZQBlAGQAKwAxAC4ANQA3ACkAKgAwAC4AMAA1ACkAOwAKAGYAbABvAGEAdAAxACAAcwBpAG4AVABpAG0AZQA0ACAAPQAgAGYAcgBhAGMAKABzAGkAbgAoAHQAaQBtAGUALgB4ACoAcwBwAGUAZQBkACsAMgAuADMANQApACoAMAAuADAANQApADsACgBmAGwAbwBhAHQAMQAgAGMAbABvAHUAZABzADEAIAA9ACAAdABlAHgAMgBEAGIAaQBhAHMAKAB0AGUAeAAsACAAZgBsAG8AYQB0ADQAKAAtAFUAVgAuAHIAKwBmAHIAYQBjACgAcwBwAGUAZQBkACoAdABpAG0AZQAuAHgAKgAwAC4AMAAzADUAKwAwAC4AMwApACwAIAAtAFUAVgAuAGcAKwBzAGkAbgBUAGkAbQBlADIALAAwACwAMwApACkALgByADsACgBmAGwAbwBhAHQAMQAgAGMAbABvAHUAZABzADIAIAA9ACAAdABlAHgAMgBEAGIAaQBhAHMAKAB0AGUAeAAsACAAZgBsAG8AYQB0ADQAKABVAFYALgByACsAZgByAGEAYwAoAHMAcABlAGUAZAAqAHQAaQBtAGUALgB4ACoAMAAuADAAMwApACwAVQBWAC4AZwArAHMAaQBuAFQAaQBtAGUALAAwACwAMwApACkALgByADsACgBmAGwAbwBhAHQAMQAgAGMAbABvAHUAZABzADMAIAA9ACAAdABlAHgAMgBEAGIAaQBhAHMAKAB0AGUAeAAsACAAZgBsAG8AYQB0ADQAKAAtAFUAVgAuAHIALQBmAHIAYQBjACgAcwBwAGUAZQBkACoAdABpAG0AZQAuAHgAKgAwAC4AMAAzADUALQAwAC4AMwA1ACkALAAtAFUAVgAuAGcAKwBzAGkAbgBUAGkAbQBlADMALAAwACwAMwApACkALgByADsACgBmAGwAbwBhAHQAMQAgAGMAbABvAHUAZABzADQAIAA9ACAAdABlAHgAMgBEAGIAaQBhAHMAKAB0AGUAeAAsACAAZgBsAG8AYQB0ADQAKABVAFYALgByAC0AZgByAGEAYwAoAHMAcABlAGUAZAAqAHQAaQBtAGUALgB4ACoAMAAuADAAMwApACwAVQBWAC4AZwArAHMAaQBuAFQAaQBtAGUANAAsADAALAAzACkAKQAuAHIAOwAKAGkAZgAoACAARQAgAD0APQAgADEALgAwACkADQAKACAAIAAgACAAcgBlAHQAdQByAG4AKABzAGEAdAB1AHIAYQB0AGUAKAAoADIAKgBjAGwAbwB1AGQAcwAxACsAYwBsAG8AdQBkAHMAMgArADIAKgBjAGwAbwB1AGQAcwAzACsAYwBsAG8AdQBkAHMAMgApACoAMAAuADMAKQApADsADQAKAGUAbABzAGUADQAKACAAIAAgACAAcgBlAHQAdQByAG4AKABzAGEAdAB1AHIAYQB0AGUAKAAoADIAKgBjAGwAbwB1AGQAcwAxACoAYwBsAG8AdQBkAHMAMgArADIAKgBjAGwAbwB1AGQAcwAzACoAYwBsAG8AdQBkAHMAMgApACoAMAAuADUANQApACkAOwA=,output:0,fname:CloudsShadows,width:641,height:211,input:1,input:0,input:12,input:0,input:8,input_1_label:UV,input_2_label:time,input_3_label:tex,input_4_label:speed,input_5_label:E|A-6852-OUT,B-9728-T,C-9428-TEX,D-5913-OUT,E-1528-OUT;n:type:ShaderForge.SFN_TexCoord,id:6899,x:31338,y:38816,varname:node_6899,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Clamp01,id:4106,x:33521,y:38533,varname:node_4106,prsc:2|IN-9780-OUT;n:type:ShaderForge.SFN_LightVector,id:3363,x:30649,y:38284,varname:node_3363,prsc:2;n:type:ShaderForge.SFN_Tangent,id:1235,x:30649,y:38436,varname:node_1235,prsc:2;n:type:ShaderForge.SFN_Dot,id:7161,x:30879,y:38366,varname:node_7161,prsc:2,dt:0|A-3363-OUT,B-1235-OUT;n:type:ShaderForge.SFN_LightVector,id:7555,x:30649,y:38571,varname:node_7555,prsc:2;n:type:ShaderForge.SFN_Bitangent,id:1830,x:30649,y:38713,varname:node_1830,prsc:2;n:type:ShaderForge.SFN_Dot,id:2402,x:30885,y:38638,varname:node_2402,prsc:2,dt:0|A-7555-OUT,B-1830-OUT;n:type:ShaderForge.SFN_Append,id:6759,x:31085,y:38502,varname:node_6759,prsc:2|A-7161-OUT,B-2402-OUT;n:type:ShaderForge.SFN_Add,id:6852,x:31526,y:38599,varname:node_6852,prsc:2|A-7327-OUT,B-6899-UVOUT;n:type:ShaderForge.SFN_Multiply,id:7327,x:31340,y:38467,varname:node_7327,prsc:2|A-1658-OUT,B-6759-OUT;n:type:ShaderForge.SFN_Vector1,id:5031,x:31198,y:38271,varname:node_5031,prsc:2,v1:0.02;n:type:ShaderForge.SFN_Set,id:3132,x:33990,y:38510,varname:_cloudsShadows,prsc:2|IN-8412-OUT;n:type:ShaderForge.SFN_Get,id:747,x:34752,y:32780,varname:node_747,prsc:2|IN-3132-OUT;n:type:ShaderForge.SFN_OneMinus,id:7965,x:35269,y:32734,varname:node_7965,prsc:2|IN-931-OUT;n:type:ShaderForge.SFN_Multiply,id:8635,x:35781,y:32753,cmnt:Clouds Shadows,varname:node_8635,prsc:2|A-4716-RGB,B-7965-OUT;n:type:ShaderForge.SFN_Multiply,id:931,x:35004,y:32854,varname:node_931,prsc:2|A-747-OUT,B-6007-OUT;n:type:ShaderForge.SFN_Vector1,id:6007,x:34817,y:32949,varname:node_6007,prsc:2,v1:0.7;n:type:ShaderForge.SFN_Slider,id:4964,x:35053,y:33966,ptovrint:False,ptlb:CloudsHeight,ptin:_CloudsHeight,varname:_CloudsHeight,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2055926,max:1;n:type:ShaderForge.SFN_Multiply,id:1658,x:31410,y:38341,varname:node_1658,prsc:2|A-5031-OUT,B-4964-OUT;n:type:ShaderForge.SFN_Power,id:8412,x:33821,y:38510,varname:node_8412,prsc:2|VAL-4106-OUT,EXP-771-OUT;n:type:ShaderForge.SFN_Power,id:9660,x:33734,y:37510,varname:node_9660,prsc:2|VAL-9432-OUT,EXP-6545-OUT;n:type:ShaderForge.SFN_Slider,id:1677,x:33069,y:37687,ptovrint:False,ptlb:CloudsSpread,ptin:_CloudsSpread,varname:_CloudsSpread,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_RemapRange,id:6545,x:33483,y:37590,varname:node_6545,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0.5|IN-1677-OUT;n:type:ShaderForge.SFN_RemapRange,id:771,x:33521,y:38371,varname:node_771,prsc:2,frmn:0,frmx:1,tomn:1,tomx:0.5|IN-1677-OUT;n:type:ShaderForge.SFN_OneMinus,id:8433,x:32253,y:38299,varname:oneMinusCloudsAmount,prsc:2|IN-8615-OUT;n:type:ShaderForge.SFN_RemapRange,id:4143,x:22703,y:35937,varname:node_4143,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-6736-OUT;n:type:ShaderForge.SFN_RemapRange,id:1164,x:22751,y:36586,varname:_PolesPos1,prsc:1,frmn:-1,frmx:1,tomn:0,tomx:1|IN-8892-OUT;n:type:ShaderForge.SFN_RemapRange,id:7562,x:22703,y:35563,varname:node_7562,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-5559-OUT;n:type:ShaderForge.SFN_Slider,id:2493,x:36492,y:35030,ptovrint:False,ptlb:Relief,ptin:_Relief,varname:_Relief,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Normalize,id:4198,x:21208,y:36909,varname:node_4198,prsc:2|IN-9920-OUT;n:type:ShaderForge.SFN_Normalize,id:5609,x:22093,y:36898,varname:NormalsLocalNormalized,prsc:2|IN-57-XYZ;n:type:ShaderForge.SFN_Negate,id:8762,x:32425,y:37074,varname:CloudsAmounbtNeg,prsc:1|IN-7522-OUT;n:type:ShaderForge.SFN_Add,id:5209,x:32903,y:37179,varname:node_5209,prsc:2|A-8762-OUT,B-7712-OUT;n:type:ShaderForge.SFN_OneMinus,id:7522,x:32246,y:37074,varname:node_7522,prsc:2|IN-8615-OUT;n:type:ShaderForge.SFN_Negate,id:5606,x:32549,y:38488,varname:node_5606,prsc:2|IN-8433-OUT;n:type:ShaderForge.SFN_Add,id:4392,x:32819,y:38671,varname:node_4392,prsc:2|A-4175-OUT,B-5606-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4886,x:25028,y:36515,varname:normalY,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-5609-OUT;n:type:ShaderForge.SFN_Slider,id:8967,x:35959,y:34142,ptovrint:False,ptlb:Specularity,ptin:_Specularity,varname:_Specularity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1650485,max:1;n:type:ShaderForge.SFN_RemapRange,id:1980,x:31680,y:36885,varname:node_1980,prsc:2,frmn:0.7,frmx:0.9,tomn:1,tomx:0|IN-6110-OUT;n:type:ShaderForge.SFN_Multiply,id:5000,x:33099,y:37107,varname:node_5000,prsc:2|A-5209-OUT,B-1588-OUT;n:type:ShaderForge.SFN_Clamp01,id:1588,x:32322,y:36901,varname:PolesCaps,prsc:0|IN-1980-OUT;n:type:ShaderForge.SFN_Multiply,id:3311,x:33200,y:38507,varname:node_3311,prsc:2|A-1588-OUT,B-4392-OUT;n:type:ShaderForge.SFN_Multiply,id:1709,x:22213,y:35719,varname:PosScaled,prsc:2|A-4104-OUT,B-9950-XYZ;n:type:ShaderForge.SFN_LightAttenuation,id:9207,x:36508,y:34320,varname:node_9207,prsc:2;n:type:ShaderForge.SFN_LightColor,id:2734,x:36508,y:34186,varname:node_2734,prsc:2;n:type:ShaderForge.SFN_LightVector,id:2045,x:35632,y:33888,varname:node_2045,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:4237,x:35632,y:34016,prsc:2,pt:True;n:type:ShaderForge.SFN_HalfVector,id:5344,x:35632,y:34167,varname:node_5344,prsc:2;n:type:ShaderForge.SFN_Dot,id:9503,x:35844,y:33919,cmnt:Lambert,varname:Lightside,prsc:2,dt:1|A-2045-OUT,B-4237-OUT;n:type:ShaderForge.SFN_Dot,id:3102,x:35844,y:34105,cmnt:Blinn-Phong,varname:node_3102,prsc:2,dt:1|A-4237-OUT,B-5344-OUT;n:type:ShaderForge.SFN_Multiply,id:6407,x:36322,y:34097,cmnt:Specular Contribution,varname:node_6407,prsc:2|A-9503-OUT,B-693-OUT,C-8043-OUT,D-8967-OUT;n:type:ShaderForge.SFN_Multiply,id:7346,x:36271,y:33779,cmnt:Diffuse Contribution,varname:node_7346,prsc:2|A-505-OUT,B-414-OUT;n:type:ShaderForge.SFN_Exp,id:7242,x:35844,y:34288,varname:node_7242,prsc:2,et:0|IN-6638-OUT;n:type:ShaderForge.SFN_Power,id:693,x:36116,y:34124,varname:node_693,prsc:2|VAL-3102-OUT,EXP-7242-OUT;n:type:ShaderForge.SFN_Add,id:5169,x:36508,y:34046,cmnt:Combine,varname:node_5169,prsc:2|A-7346-OUT,B-6407-OUT;n:type:ShaderForge.SFN_Multiply,id:7811,x:36753,y:34186,cmnt:Attenuate and Color,varname:node_7811,prsc:2|A-5169-OUT,B-2734-RGB,C-9207-OUT;n:type:ShaderForge.SFN_ConstantLerp,id:6638,x:35632,y:34290,varname:node_6638,prsc:2,a:1,b:11|IN-1711-OUT;n:type:ShaderForge.SFN_AmbientLight,id:4147,x:36238,y:33172,varname:node_4147,prsc:2;n:type:ShaderForge.SFN_Multiply,id:3743,x:36450,y:33125,cmnt:Ambient Light,varname:node_3743,prsc:2|A-505-OUT,B-4147-RGB;n:type:ShaderForge.SFN_Slider,id:5889,x:36510,y:33952,ptovrint:False,ptlb:Ambient,ptin:_Ambient,varname:_Ambient,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_NormalVector,id:4347,x:35644,y:34597,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:3892,x:35856,y:34512,cmnt:Lambert,varname:LightSide,prsc:1,dt:2|A-111-OUT,B-4347-OUT;n:type:ShaderForge.SFN_LightVector,id:111,x:35644,y:34469,varname:node_111,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6343,x:36327,y:34727,cmnt:Population,varname:node_6343,prsc:2|A-1656-RGB,B-6274-OUT;n:type:ShaderForge.SFN_Add,id:6175,x:37002,y:34571,varname:node_6175,prsc:2|A-7811-OUT,B-6607-OUT;n:type:ShaderForge.SFN_Multiply,id:6607,x:36719,y:34727,varname:node_6607,prsc:2|A-6343-OUT,B-6400-RGB;n:type:ShaderForge.SFN_Color,id:6400,x:36341,y:34868,ptovrint:False,ptlb:CitiesColor,ptin:_CitiesColor,varname:_CitiesColor,prsc:1,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_OneMinus,id:5943,x:36125,y:34547,varname:node_5943,prsc:2|IN-3892-OUT;n:type:ShaderForge.SFN_RemapRange,id:9490,x:36372,y:34482,varname:node_9490,prsc:2,frmn:0.8,frmx:2,tomn:0,tomx:1|IN-5943-OUT;n:type:ShaderForge.SFN_Clamp01,id:5135,x:36495,y:34591,varname:node_5135,prsc:2|IN-9490-OUT;n:type:ShaderForge.SFN_Abs,id:6274,x:36108,y:34788,varname:node_6274,prsc:2|IN-3892-OUT;n:type:ShaderForge.SFN_Vector1,id:688,x:36064,y:34364,varname:node_688,prsc:2,v1:2;n:type:ShaderForge.SFN_Abs,id:6110,x:25231,y:36515,varname:poles,prsc:2|IN-4886-OUT;n:type:ShaderForge.SFN_Tex2d,id:6356,x:32295,y:37753,varname:_CloudsPoleDif,prsc:1,ntxv:2,isnm:False|UVIN-9436-UVOUT,TEX-2380-TEX;n:type:ShaderForge.SFN_Add,id:1523,x:33166,y:37428,varname:node_1523,prsc:2|A-5000-OUT,B-4141-OUT;n:type:ShaderForge.SFN_Add,id:4141,x:32825,y:37515,varname:node_4141,prsc:2|A-8762-OUT,B-3688-OUT;n:type:ShaderForge.SFN_Rotator,id:9436,x:32024,y:37708,varname:CloudsPoleUV,prsc:1|UVIN-1184-OUT,PIV-1223-OUT,SPD-194-OUT;n:type:ShaderForge.SFN_Vector2,id:1223,x:31762,y:37966,varname:node_1223,prsc:1,v1:0.5,v2:0.5;n:type:ShaderForge.SFN_Multiply,id:194,x:31940,y:38011,varname:node_194,prsc:2|A-5913-OUT,B-9643-OUT;n:type:ShaderForge.SFN_Vector1,id:9643,x:31780,y:38150,varname:node_9643,prsc:2,v1:-0.1;n:type:ShaderForge.SFN_Tex2dAsset,id:2380,x:32103,y:38043,ptovrint:False,ptlb:CloudsPole,ptin:_CloudsPole,varname:_CloudsPole,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Code,id:3338,x:32313,y:38047,varname:node_3338,prsc:2,code:cgBlAHQAdQByAG4AKAB0AGUAeAAyAEQAYgBpAGEAcwAoAHQAZQB4ACwAZgBsAG8AYQB0ADQAKABVAFYALAAwACwANQApACkALgByACkAOwA=,output:0,fname:CloudsPoleShadowsUnpack,width:498,height:146,input:12,input:1,input_1_label:tex,input_2_label:UV|A-2380-TEX,B-9436-UVOUT;n:type:ShaderForge.SFN_Add,id:9361,x:33205,y:37896,varname:node_9361,prsc:2|A-8762-OUT,B-9598-OUT;n:type:ShaderForge.SFN_Add,id:9780,x:33331,y:38150,varname:node_9780,prsc:2|A-9361-OUT,B-3311-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:1528,x:31648,y:38502,ptovrint:False,ptlb:CloudsAvgBlend,ptin:_CloudsAvgBlend,varname:_CloudsAvgBlend,prsc:0,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False;n:type:ShaderForge.SFN_RemapRange,id:1184,x:31049,y:37572,varname:node_1184,prsc:2,frmn:0,frmx:1,tomn:0.21,tomx:0.81|IN-1164-OUT;n:type:ShaderForge.SFN_Subtract,id:3712,x:32520,y:37731,varname:node_3712,prsc:2|A-6356-R,B-1588-OUT;n:type:ShaderForge.SFN_Clamp01,id:3688,x:32878,y:37754,varname:node_3688,prsc:2|IN-3712-OUT;n:type:ShaderForge.SFN_Subtract,id:6425,x:32712,y:37856,varname:node_6425,prsc:2|A-3338-OUT,B-1588-OUT;n:type:ShaderForge.SFN_Clamp01,id:9598,x:32893,y:37887,varname:node_9598,prsc:2|IN-6425-OUT;n:type:ShaderForge.SFN_Add,id:414,x:36068,y:33859,varname:node_414,prsc:2|A-9526-OUT,B-9503-OUT;n:type:ShaderForge.SFN_Get,id:825,x:35752,y:33828,varname:node_825,prsc:2|IN-9127-OUT;n:type:ShaderForge.SFN_Multiply,id:9526,x:35883,y:33726,varname:node_9526,prsc:2|A-4964-OUT,B-825-OUT,C-4974-OUT;n:type:ShaderForge.SFN_Vector1,id:4974,x:35449,y:33750,varname:node_4974,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Vector1,id:2933,x:35630,y:32593,varname:node_2933,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:5883,x:37266,y:33620,varname:node_5883,prsc:2|A-3743-OUT,B-5889-OUT;n:type:ShaderForge.SFN_Tex2d,id:9545,x:36619,y:33554,ptovrint:True,ptlb:Normal,ptin:_NormalMap,varname:_NormalMap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Tex2d,id:4716,x:35293,y:32951,ptovrint:True,ptlb:Diffuse,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6084,x:35271,y:33237,ptovrint:False,ptlb:Specular,ptin:_Specular,varname:_Specular,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:505,x:36060,y:32810,varname:node_505,prsc:2|A-8635-OUT,B-7447-RGB,T-8619-OUT;n:type:ShaderForge.SFN_Length,id:8908,x:35591,y:33250,varname:node_8908,prsc:2|IN-6084-RGB;n:type:ShaderForge.SFN_RemapRange,id:6297,x:35891,y:33282,varname:node_6297,prsc:2,frmn:0,frmx:0.1,tomn:0,tomx:1|IN-8908-OUT;n:type:ShaderForge.SFN_Clamp01,id:8269,x:36093,y:33300,varname:node_8269,prsc:2|IN-6297-OUT;n:type:ShaderForge.SFN_OneMinus,id:2394,x:35772,y:33467,varname:node_2394,prsc:2|IN-8619-OUT;n:type:ShaderForge.SFN_Multiply,id:8043,x:35926,y:33580,varname:node_8043,prsc:2|A-6084-RGB,B-2394-OUT;n:type:ShaderForge.SFN_Tex2d,id:1656,x:35825,y:34830,ptovrint:False,ptlb:Population,ptin:_Population,varname:_Population,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Lerp,id:4664,x:37336,y:33951,varname:node_4664,prsc:2|A-1651-OUT,B-9545-RGB,T-2493-OUT;n:type:ShaderForge.SFN_Vector3,id:1651,x:37016,y:33838,varname:node_1651,prsc:1,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Vector1,id:4965,x:21796,y:35412,varname:node_4965,prsc:2,v1:0.64;proporder:568-1711-8967-7447-9428-2380-1528-5913-8615-4964-1677-2493-5889-6400-9545-4716-6084-1656-6141-3418-8874-7077-7319-799-4678-7295-5802-4507-4772-6401-2492;pass:END;sub:END;*/

Shader "Human Unit/Planet Static" {
    Properties {
        _Size ("Size", Range(0, 1)) = 0.1359223
        _Gloss ("Gloss", Range(0, 1)) = 0
        _Specularity ("Specularity", Range(0, 1)) = 0.1650485
        _CloudsColor ("CloudsColor", Color) = (1,1,1,1)
        _Clouds ("Clouds", 2D) = "gray" {}
        _CloudsPole ("CloudsPole", 2D) = "black" {}
        [MaterialToggle] _CloudsAvgBlend ("CloudsAvgBlend", Float ) = 0
        _CloudsSpeed ("CloudsSpeed", Range(0, 1)) = 0.4368932
        _CloudsAmount ("CloudsAmount", Range(0, 1)) = 1
        _CloudsHeight ("CloudsHeight", Range(0, 1)) = 0.2055926
        _CloudsSpread ("CloudsSpread", Range(0, 1)) = 1
        _Relief ("Relief", Range(0, 1)) = 1
        _Ambient ("Ambient", Range(0, 1)) = 0
        [HDR]_CitiesColor ("CitiesColor", Color) = (0.5,0.5,0.5,1)
        _NormalMap ("Normal", 2D) = "bump" {}
        _MainTex ("Diffuse", 2D) = "white" {}
        _Specular ("Specular", 2D) = "white" {}
        _Population ("Population", 2D) = "black" {}
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
            uniform float _Gloss;
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
            uniform float _Relief;
            uniform float _Specularity;
            uniform half _Ambient;
            uniform half4 _CitiesColor;
            uniform sampler2D _CloudsPole; uniform float4 _CloudsPole_ST;
            float CloudsPoleShadowsUnpack( sampler2D tex , float2 UV ){
            return(tex2Dbias(tex,float4(UV,0,5)).r);
            }
            
            uniform fixed _CloudsAvgBlend;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Specular; uniform float4 _Specular_ST;
            uniform sampler2D _Population; uniform float4 _Population_ST;
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
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float3 normalLocal = lerp(half3(0,0,1),_NormalMap_var.rgb,_Relief);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
////// Emissive:
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                half CloudsAmounbtNeg = (-1*(1.0 - _CloudsAmount));
                float4 node_8721 = _Time + _TimeEditor;
                float CloudsPoleUV_ang = node_8721.g;
                float CloudsPoleUV_spd = (_CloudsSpeed*(-0.1));
                float CloudsPoleUV_cos = cos(CloudsPoleUV_spd*CloudsPoleUV_ang);
                float CloudsPoleUV_sin = sin(CloudsPoleUV_spd*CloudsPoleUV_ang);
                float2 CloudsPoleUV_piv = half2(0.5,0.5);
                float node_4104 = (0.64*4.9+0.1);
                half2 _PolesPos1 = ((node_4104*mul( unity_WorldToObject, float4((i.posWorld.rgb-objPos.rgb),0) ).xyz.rgb).rb*0.5+0.5);
                half2 CloudsPoleUV = (mul((_PolesPos1*0.6+0.21)-CloudsPoleUV_piv,float2x2( CloudsPoleUV_cos, -CloudsPoleUV_sin, CloudsPoleUV_sin, CloudsPoleUV_cos))+CloudsPoleUV_piv);
                float3 NormalsLocalNormalized = normalize(mul( unity_WorldToObject, float4(normalize(i.normalDir),0) ).xyz.rgb);
                float poles = abs(NormalsLocalNormalized.g);
                fixed PolesCaps = saturate((poles*-5.0+4.5));
                float4 timeClouds = _Time + _TimeEditor;
                float _cloudsShadows = pow(saturate(((CloudsAmounbtNeg+saturate((CloudsPoleShadowsUnpack( _CloudsPole , CloudsPoleUV )-PolesCaps)))+(PolesCaps*(CloudsShadows( (((0.02*_CloudsHeight)*float2(dot(lightDirection,i.tangentDir),dot(lightDirection,i.bitangentDir)))+i.uv0) , timeClouds.g , _Clouds , _CloudsSpeed , _CloudsAvgBlend )+(-1*(1.0 - _CloudsAmount)))))),(_CloudsSpread*-0.5+1.0));
                half4 _CloudsPoleDif = tex2D(_CloudsPole,TRANSFORM_TEX(CloudsPoleUV, _CloudsPole));
                float _clouds = pow(saturate((((CloudsAmounbtNeg+Clouds( i.uv0 , timeClouds.g , _Clouds , _CloudsSpeed , _CloudsAvgBlend ))*PolesCaps)+(CloudsAmounbtNeg+saturate((_CloudsPoleDif.r-PolesCaps))))),(_CloudsSpread*-0.5+1.0));
                half node_8619 = _clouds;
                float3 node_505 = lerp((_MainTex_var.rgb*(1.0 - (_cloudsShadows*0.7))),_CloudsColor.rgb,node_8619);
                float3 emissive = ((node_505*UNITY_LIGHTMODEL_AMBIENT.rgb)*_Ambient);
                float Lightside = max(0,dot(lightDirection,normalDirection)); // Lambert
                float4 _Specular_var = tex2D(_Specular,TRANSFORM_TEX(i.uv0, _Specular));
                float4 _Population_var = tex2D(_Population,TRANSFORM_TEX(i.uv0, _Population));
                half LightSide = min(0,dot(lightDirection,i.normalDir)); // Lambert
                float3 finalColor = emissive + ((((node_505*((_CloudsHeight*_clouds*0.1)+Lightside))+(Lightside*pow(max(0,dot(normalDirection,halfDirection)),exp(lerp(1,11,_Gloss)))*(_Specular_var.rgb*(1.0 - node_8619))*_Specularity))*_LightColor0.rgb*attenuation)+((_Population_var.rgb*abs(LightSide))*_CitiesColor.rgb));
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
            uniform float _Gloss;
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
            uniform float _Relief;
            uniform float _Specularity;
            uniform half _Ambient;
            uniform half4 _CitiesColor;
            uniform sampler2D _CloudsPole; uniform float4 _CloudsPole_ST;
            float CloudsPoleShadowsUnpack( sampler2D tex , float2 UV ){
            return(tex2Dbias(tex,float4(UV,0,5)).r);
            }
            
            uniform fixed _CloudsAvgBlend;
            uniform sampler2D _NormalMap; uniform float4 _NormalMap_ST;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Specular; uniform float4 _Specular_ST;
            uniform sampler2D _Population; uniform float4 _Population_ST;
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
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _NormalMap_var = UnpackNormal(tex2D(_NormalMap,TRANSFORM_TEX(i.uv0, _NormalMap)));
                float3 normalLocal = lerp(half3(0,0,1),_NormalMap_var.rgb,_Relief);
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                half CloudsAmounbtNeg = (-1*(1.0 - _CloudsAmount));
                float4 node_5603 = _Time + _TimeEditor;
                float CloudsPoleUV_ang = node_5603.g;
                float CloudsPoleUV_spd = (_CloudsSpeed*(-0.1));
                float CloudsPoleUV_cos = cos(CloudsPoleUV_spd*CloudsPoleUV_ang);
                float CloudsPoleUV_sin = sin(CloudsPoleUV_spd*CloudsPoleUV_ang);
                float2 CloudsPoleUV_piv = half2(0.5,0.5);
                float node_4104 = (0.64*4.9+0.1);
                half2 _PolesPos1 = ((node_4104*mul( unity_WorldToObject, float4((i.posWorld.rgb-objPos.rgb),0) ).xyz.rgb).rb*0.5+0.5);
                half2 CloudsPoleUV = (mul((_PolesPos1*0.6+0.21)-CloudsPoleUV_piv,float2x2( CloudsPoleUV_cos, -CloudsPoleUV_sin, CloudsPoleUV_sin, CloudsPoleUV_cos))+CloudsPoleUV_piv);
                float3 NormalsLocalNormalized = normalize(mul( unity_WorldToObject, float4(normalize(i.normalDir),0) ).xyz.rgb);
                float poles = abs(NormalsLocalNormalized.g);
                fixed PolesCaps = saturate((poles*-5.0+4.5));
                float4 timeClouds = _Time + _TimeEditor;
                float _cloudsShadows = pow(saturate(((CloudsAmounbtNeg+saturate((CloudsPoleShadowsUnpack( _CloudsPole , CloudsPoleUV )-PolesCaps)))+(PolesCaps*(CloudsShadows( (((0.02*_CloudsHeight)*float2(dot(lightDirection,i.tangentDir),dot(lightDirection,i.bitangentDir)))+i.uv0) , timeClouds.g , _Clouds , _CloudsSpeed , _CloudsAvgBlend )+(-1*(1.0 - _CloudsAmount)))))),(_CloudsSpread*-0.5+1.0));
                half4 _CloudsPoleDif = tex2D(_CloudsPole,TRANSFORM_TEX(CloudsPoleUV, _CloudsPole));
                float _clouds = pow(saturate((((CloudsAmounbtNeg+Clouds( i.uv0 , timeClouds.g , _Clouds , _CloudsSpeed , _CloudsAvgBlend ))*PolesCaps)+(CloudsAmounbtNeg+saturate((_CloudsPoleDif.r-PolesCaps))))),(_CloudsSpread*-0.5+1.0));
                half node_8619 = _clouds;
                float3 node_505 = lerp((_MainTex_var.rgb*(1.0 - (_cloudsShadows*0.7))),_CloudsColor.rgb,node_8619);
                float Lightside = max(0,dot(lightDirection,normalDirection)); // Lambert
                float4 _Specular_var = tex2D(_Specular,TRANSFORM_TEX(i.uv0, _Specular));
                float4 _Population_var = tex2D(_Population,TRANSFORM_TEX(i.uv0, _Population));
                half LightSide = min(0,dot(lightDirection,i.normalDir)); // Lambert
                float3 finalColor = ((((node_505*((_CloudsHeight*_clouds*0.1)+Lightside))+(Lightside*pow(max(0,dot(normalDirection,halfDirection)),exp(lerp(1,11,_Gloss)))*(_Specular_var.rgb*(1.0 - node_8619))*_Specularity))*_LightColor0.rgb*attenuation)+((_Population_var.rgb*abs(LightSide))*_CitiesColor.rgb));
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
