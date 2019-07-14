using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Galaxy;
[CustomEditor(typeof(HPlanet))]
public class HPlanetEditor : Editor {
    int toolBar = 0;
    bool debug = false;
    string path = "Assets/";

    Texture heightMap, detailsMap, normalsMap, cloudsMap, cloudsPoleMap, fertilityMap, citiesMap;
    float detailsScale, randomSeed, size, ambient, waterLevel, shoresContrast, oceanOpacity, specularity, gloss, relief;
    float cloudsAmount, cloudsSpeed, cloudsSpread, cloudsHeight, atmosphereBrightness, atmosphereSize, atmosphereDensity, atmosphereRefraction, atmosphereRim;
    float vegetationScale, fertility, vegetationContrast, vegetationFrostResistance, frost, frostContrast, heat;
    float citiesMapScale, population, popFrost, popHeat, popVeg, popNoVeg;
    bool cloudsAvgBlend, complexClouds;
    bool populationOnLand, simpleShader, emissiveWater;
    float populationShoresMountains;
    Color liquidColor, atmosphereColor, vegetationColor, citiesColor, cloudsColor;

    public override void OnInspectorGUI()
    {
        serializedObject.ApplyModifiedProperties();
        //debug = EditorGUILayout.Toggle(debug);
        if (debug) DrawDefaultInspector();

        HPlanet planet = (HPlanet)target;


        string[] toolBarOptions = new string[4] { "General", "Atmoshere", "Climate", "Population" };
        float iconSize = Mathf.Min(200, Screen.width * 0.5f - 30);
        if (GUILayout.Button(new GUIContent("Make Unique", "Use HPlanet.MakeUnique() if you want to generate planets at runtime")))
        {
            
            path = EditorUtility.SaveFilePanel("Choose folder to save material", path, "Planet Name", "mat");
            if (path.Length != 0)
            {
                if (path.Substring(path.Length - 4) == ".mat")
                {
                    path = path.Remove(path.Length - 4);
                }
                path = "Assets" + path.Substring(Application.dataPath.Length);
                AssetDatabase.CreateAsset(new Material(planet.PlanetMaterial), path + ".mat");
                planet.PlanetMaterial = AssetDatabase.LoadAssetAtPath<Material>(path + ".mat");
                planet.AtmosphereMaterial = new Material(planet.AtmosphereMaterial);
            }
        }

        toolBar = GUILayout.Toolbar(toolBar, toolBarOptions);



        switch (toolBar)
        {
            case 0:
                {
                    EditorGUI.BeginChangeCheck();


                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Height", GUILayout.Width(iconSize));
                    //GUILayout.FlexibleSpace();
                    EditorGUILayout.LabelField("Details", GUILayout.Width(iconSize));
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    heightMap = (Texture)EditorGUILayout.ObjectField(planet.HeightMap, typeof(Texture), true, GUILayout.Width(iconSize), GUILayout.Height(iconSize));
                    //GUILayout.FlexibleSpace();
                    detailsMap = (Texture)EditorGUILayout.ObjectField(planet.DetailsMap, typeof(Texture), true, GUILayout.Width(iconSize), GUILayout.Height(iconSize));
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();

                    EditorGUILayout.PropertyField(serializedObject.FindProperty("HeightGradient"), new GUIContent(""), GUILayout.Width(iconSize), GUILayout.Height(40));

                    EditorGUILayout.PropertyField(serializedObject.FindProperty("DetailsGradient"), new GUIContent(""), GUILayout.Width(iconSize), GUILayout.Height(40));

                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("", GUILayout.Width(iconSize));
                    EditorGUILayout.LabelField("Details Scale:");
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("", GUILayout.Width(iconSize));
                    //GUILayout.FlexibleSpace();
                    detailsScale=EditorGUILayout.Slider(planet.DetailsScale, 0, 3);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    //GUILayout.FlexibleSpace();
                    EditorGUILayout.LabelField("", GUILayout.Width(iconSize*0.5f));
                    EditorGUILayout.LabelField("Normal Map", GUILayout.Width(iconSize));
                    //GUILayout.FlexibleSpace();
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("", GUILayout.Width(iconSize * 0.5f));
                    normalsMap = (Texture)EditorGUILayout.ObjectField(planet.NormalsMap, typeof(Texture), true, GUILayout.Width(iconSize), GUILayout.Height(iconSize));
                    EditorGUILayout.EndHorizontal();



                    EditorGUILayout.LabelField("Main:", EditorStyles.boldLabel);
                    simpleShader = EditorGUILayout.Toggle(new GUIContent(" Simplified Shader:","Simplier clouds, faster projection"), planet.PlanetShader == Shader.Find("Human Unit/Planet Simple"));
                    randomSeed = EditorGUILayout.Slider(" Random Seed:", planet.RandomSeed, 0, 1000);
                    size = EditorGUILayout.Slider(" Size:", planet.Size, 0, 1);
                    ambient = EditorGUILayout.Slider(" Ambient:", planet.Ambient, 0, 1);
                    relief = EditorGUILayout.Slider(" Relief:", planet.Relief, 0, 1);


                    EditorGUILayout.LabelField("Oceans:", EditorStyles.boldLabel);
                    emissiveWater = EditorGUILayout.Toggle(" Emissive:", planet.EmissiveWater);
                    waterLevel = EditorGUILayout.Slider(" Water Level:", planet.WaterLevel, 0, 1);
                    shoresContrast = EditorGUILayout.Slider(" Shores Contrast:", planet.ShoresContrast, 0, 1);
                    oceanOpacity = EditorGUILayout.Slider(" Ocean Opacity:", planet.OceanOpacity, 0, 1);
                    EditorGUILayout.LabelField("Liquid Properties:", EditorStyles.boldLabel);

                    EditorGUILayout.BeginHorizontal();
                    liquidColor = EditorGUILayout.ColorField(new GUIContent(" Color:"), planet.LiquidColor,true,false,false,new ColorPickerHDRConfig(0,4,0,4));
                    if ((GUILayout.Button(new GUIContent("Copy from atmosphere"))))
                    {
                        liquidColor = planet.AtmosphereColor;
                    }
                    EditorGUILayout.EndHorizontal();

                    specularity = EditorGUILayout.Slider(" Specularity:", planet.Specularity, 0, 1);
                    gloss = EditorGUILayout.Slider(" Gloss:", planet.Gloss, 0, 1);


                    if (EditorGUI.EndChangeCheck())
                    {
                        serializedObject.ApplyModifiedProperties();
                        Undo.RecordObject(planet, "Modified General of " + planet.name);
                        planet.PlanetShader = simpleShader ? Shader.Find("Human Unit/Planet Simple") : Shader.Find("Human Unit/Planet");
                        planet.UpdateHeightGradientMap();
                        planet.UpdateDetailsGradientMap();
                        planet.HeightMap = heightMap;
                        planet.DetailsMap = detailsMap;
                        planet.DetailsScale = detailsScale;
                        planet.NormalsMap = normalsMap;
                        planet.RandomSeed = randomSeed;
                        planet.Size = size;
                        planet.EmissiveWater = emissiveWater;
                        planet.Ambient = ambient;
                        planet.Relief = relief;
                        planet.WaterLevel = waterLevel;
                        planet.OceanOpacity = oceanOpacity;
                        planet.ShoresContrast = shoresContrast;
                        planet.LiquidColor = liquidColor;
                        planet.Specularity = specularity;
                        planet.Gloss = gloss;

                        EditorUtility.SetDirty(planet);
                    }
                    break;
                }
            case 1:
                {
                    EditorGUI.BeginChangeCheck();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Clouds", GUILayout.Width(iconSize));
                    //GUILayout.FlexibleSpace();
                    EditorGUILayout.LabelField("Polar", GUILayout.Width(iconSize));
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    cloudsMap = (Texture)EditorGUILayout.ObjectField(planet.CloudsMap, typeof(Texture), true, GUILayout.Width(iconSize), GUILayout.Height(iconSize));
                    //GUILayout.FlexibleSpace();
                    cloudsPoleMap = (Texture)EditorGUILayout.ObjectField(planet.CloudsPoleMap, typeof(Texture), true, GUILayout.Width(iconSize), GUILayout.Height(iconSize));
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.LabelField("Clouds:", EditorStyles.boldLabel);

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(" Blend Mode:");
                    cloudsAvgBlend = GUILayout.Toolbar(System.Convert.ToInt32(planet.CloudsAvgBlend), new string[2] { "MLT", "AVG" })==1;
                    EditorGUILayout.EndHorizontal();
                    cloudsColor = EditorGUILayout.ColorField(new GUIContent(" Color:"), planet.CloudsColor,true,false,false, new ColorPickerHDRConfig(0,1,0,1));
                    complexClouds = EditorGUILayout.Toggle(" Complex:", planet.ComplexClouds);
                    cloudsAmount = EditorGUILayout.Slider(" Amount:", planet.CloudsAmount, 0, 1);
                    cloudsSpeed = EditorGUILayout.Slider(" Speed:", planet.CloudsSpeed, 0, 1);
                    cloudsSpread = EditorGUILayout.Slider(" Spread:", planet.CloudsSpread, 0, 1);
                    cloudsHeight = EditorGUILayout.Slider(" Height:", planet.CloudsHeight, 0, 1);

                    EditorGUILayout.LabelField("Atmosphere:", EditorStyles.boldLabel);
                    EditorGUILayout.BeginHorizontal();
                    atmosphereColor = EditorGUILayout.ColorField(new GUIContent(" Color:"), planet.AtmosphereColor, true,false,false, new ColorPickerHDRConfig(0, 1, 0, 1));
                    if ((GUILayout.Button(new GUIContent("Copy from liquid"))))
                    {
                        atmosphereColor = planet.LiquidColor;
                    }
                    EditorGUILayout.EndHorizontal();
                    atmosphereBrightness = EditorGUILayout.Slider(" Brightness:", planet.AtmosphereBrightness, 0, 3);
                    atmosphereSize = EditorGUILayout.Slider(" Size:", planet.AtmosphereSize, 0, 1);
                    atmosphereDensity = EditorGUILayout.Slider(" Density:", planet.AtmosphereDensity, 0, 1);
                    atmosphereRefraction = EditorGUILayout.Slider(" Refraction:", planet.AtmosphereRefraction, 0, 1);
                    atmosphereRim = EditorGUILayout.Slider(" Rim:", planet.AtmosphereRim, 0, 1);

                    if (EditorGUI.EndChangeCheck())
                    {
                        serializedObject.ApplyModifiedProperties();
                        Undo.RecordObject(planet, "Modified Atmosphere of " + planet.name);
                        planet.CloudsMap = cloudsMap;
                        planet.ComplexClouds = complexClouds;
                        planet.CloudsPoleMap = cloudsPoleMap;
                        planet.CloudsAvgBlend = cloudsAvgBlend;
                        planet.CloudsAmount = cloudsAmount;
                        planet.CloudsSpeed = cloudsSpeed;
                        planet.CloudsSpread = cloudsSpread;
                        planet.CloudsHeight = cloudsHeight;
                        planet.CloudsColor = cloudsColor;
                        planet.AtmosphereColor = atmosphereColor;
                        planet.AtmosphereBrightness = atmosphereBrightness;
                        planet.AtmosphereSize = atmosphereSize;
                        planet.AtmosphereDensity = atmosphereDensity;
                        planet.AtmosphereRefraction = atmosphereRefraction;
                        planet.AtmosphereRim = atmosphereRim;

                        EditorUtility.SetDirty(planet);
                    }


                    break;

                }
            case 2:
                {
                    EditorGUI.BeginChangeCheck();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("", GUILayout.Width(iconSize * 0.5f));
                    EditorGUILayout.LabelField("Fertility Map:", GUILayout.Width(iconSize));
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("", GUILayout.Width(iconSize * 0.5f));
                    fertilityMap = (Texture)EditorGUILayout.ObjectField(planet.FertilityMap, typeof(Texture), true, GUILayout.Width(iconSize), GUILayout.Height(iconSize));
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("", GUILayout.Width(iconSize * 0.5f));
                    EditorGUILayout.LabelField("Map Scale:");
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("", GUILayout.Width(iconSize * 0.5f));
                    vegetationScale = EditorGUILayout.Slider(planet.FertilityScale, 0, 3);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.LabelField("Vegetation:", EditorStyles.boldLabel);
                    vegetationColor = EditorGUILayout.ColorField(new GUIContent(" Vegetation Color:"), planet.VegetationColor,true,false,false,new ColorPickerHDRConfig(0,4,0,4));
                    fertility = EditorGUILayout.Slider(" Fertility:", planet.Fertility, 0, 1);
                    vegetationContrast = EditorGUILayout.Slider(" Contrast:", planet.VegetationContrast, 0, 1);
                    vegetationFrostResistance = EditorGUILayout.Slider(" Frost Resistance:", planet.VegetationFrostResistance, 0, 1);

                    EditorGUILayout.LabelField("Temperature:", EditorStyles.boldLabel);
                    frost = EditorGUILayout.Slider(" Frost:", planet.Frost, 0, 1);
                    frostContrast = EditorGUILayout.Slider(" FrostContrast:", planet.FrostContrast, 0, 1);
                    heat = EditorGUILayout.Slider(" Heat", planet.Heat, 0, 1);

                    if (EditorGUI.EndChangeCheck())
                    {
                        serializedObject.ApplyModifiedProperties();
                        Undo.RecordObject(planet, "Modified Climate of " + planet.name);

                        planet.FertilityMap = fertilityMap;
                        planet.FertilityScale = vegetationScale;
                        planet.VegetationColor = vegetationColor;
                        planet.Fertility = fertility;
                        planet.VegetationContrast = vegetationContrast;
                        planet.VegetationFrostResistance = vegetationFrostResistance;
                        planet.Frost = frost;
                        planet.FrostContrast = frostContrast;
                        planet.Heat = heat;

                        EditorUtility.SetDirty(planet);
                    }

                    break;
                }
            case 3:
                {
                    EditorGUI.BeginChangeCheck();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("", GUILayout.Width(iconSize * 0.5f));
                    EditorGUILayout.LabelField("Cities Map:", GUILayout.Width(iconSize));
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("", GUILayout.Width(iconSize * 0.5f));
                    citiesMap = (Texture)EditorGUILayout.ObjectField(planet.CitiesMap, typeof(Texture), true, GUILayout.Width(iconSize), GUILayout.Height(iconSize));
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("", GUILayout.Width(iconSize * 0.5f));
                    EditorGUILayout.LabelField("Map Scale:");
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("", GUILayout.Width(iconSize * 0.5f));
                    citiesMapScale = EditorGUILayout.Slider(planet.CitiesScale, 0, 3);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.LabelField("Main:", EditorStyles.boldLabel);
                    population = EditorGUILayout.Slider(" Population:", planet.Population, 0, 1);
                    citiesColor = EditorGUILayout.ColorField(new GUIContent(" Sities Color:"), planet.CitiesColor,true,false,true,new ColorPickerHDRConfig(0,4,0,4));

                    EditorGUILayout.LabelField("Modifiers:", EditorStyles.boldLabel);

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("");
                    populationOnLand = GUILayout.Toolbar(System.Convert.ToInt32(planet.PopulationOnLand), new string[2] { "Ocean", "Land" }, GUILayout.Width(iconSize)) == 1;
                    EditorGUILayout.EndHorizontal();

                    if (populationOnLand)
                    {
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.LabelField("");
                        populationShoresMountains = GUILayout.Toolbar((int)planet.PopulationShoresMountainsBalance, new string[2] { "Shores", "Mountains" }, GUILayout.Width(iconSize));
                        EditorGUILayout.EndHorizontal();
                    }

                    popFrost = EditorGUILayout.Slider(" Frost:", planet.PopulationFrostModifier, 0, 2);
                    popHeat = EditorGUILayout.Slider(" Heat:", planet.PopulationHeatMultiplier, 0, 2);
                    popVeg = EditorGUILayout.Slider(" Vegetation:", planet.PopulationVegetationMultiplier, 0, 2);
                    popNoVeg = EditorGUILayout.Slider(" No Vegetation:", planet.PopulationNoVegetationMultiplier, 0, 2);

                    if (EditorGUI.EndChangeCheck())
                    {
                        serializedObject.ApplyModifiedProperties();
                        Undo.RecordObject(planet, "Modified population of " + planet.name);

                        planet.CitiesMap = citiesMap;
                        planet.CitiesScale = citiesMapScale;
                        planet.CitiesColor = citiesColor;
                        planet.Population = population;
                        planet.PopulationOnLand = populationOnLand;
                        planet.PopulationShoresMountainsBalance = populationShoresMountains;
                        planet.PopulationFrostModifier = popFrost;
                        planet.PopulationHeatMultiplier = popHeat;
                        planet.PopulationVegetationMultiplier = popVeg;
                        planet.PopulationNoVegetationMultiplier = popNoVeg;

                        EditorUtility.SetDirty(planet);
                    }

                    break;
                }
                
        }

    }

    private void GradientField(string PropertyName, float size)
    {
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(serializedObject.FindProperty(PropertyName), new GUIContent(""), GUILayout.Width(size), GUILayout.Height(40));
        if (EditorGUI.EndChangeCheck())
            serializedObject.ApplyModifiedProperties();
    }
}
