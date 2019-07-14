using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Galaxy;
using UnityEngine.UI;
using System.Linq;

public class PlanetManager : MonoBehaviour {

    public Dropdown dropDownHeight;
    public Dropdown dropDownDetails;
    public Gradient[] gradients;
    private List<Sprite> gradSprites = new List<Sprite>() { };


    public HPlanet[] planets;
    public HPlanet selected;
    public Slider seed;
    public Slider size;
    public Slider ambient;
    public Slider relief;
    public Slider waterLevel;
    public Slider shoresContrast;
    public Slider opacity;
    public ColorPicker liquidColor;
    public Slider specularity;
    public Slider gloss;
    public ColorPicker cloudsColor;
    public Slider cloudsAmount;
    public Slider cloudsSpeed;
    public Slider cloudsSpread;
    public Slider cloudsHeight;
    public ColorPicker atmosphereColor;
    public Slider atmosphereBrightness;
    public Slider atmosphereSize;
    public Slider atmosphereDensity;
    public Slider atmossphereRefraction;
    public Slider atmosphereRim;
    public Slider frost;
    public Slider frostContrast;
    public Slider heat;
    public ColorPicker vegetationColor;
    public Slider fertility;
    public Slider vegetationContrast;
    public Slider frostResistance;
    public ColorPicker citiesColor;
    public Slider population;
    public Toggle popOnLand;
    public Toggle popOnOcean;
    public Toggle popOnShores;
    public Toggle popOnMountains;
    public Slider popFrost;
    public Slider popHeat;
    public Slider popVeg;
    public Slider popNoVeg;
    bool swaping=false;
    private void Start()
    {
        selected = planets[2];
        InitGrad();
        InitUI();

    }

    private void InitGrad()
    {
        dropDownHeight.ClearOptions();
        dropDownDetails.ClearOptions();
        List<Sprite> optList = new List<Sprite>() { };
        for(int i = 0; i < gradients.Length; i++)
        {
            Texture2D text = new Texture2D(300, 30);
            for(int x = 0; x < 300; x++)
            {
                for (int y = 0; y < 30; y++)
                {
                    text.SetPixel(x, y, gradients[i].Evaluate(x / 300.0f));
                }
            }
            text.Apply();
            optList.Add(Sprite.Create(text, new Rect(0, 0, 300, 30), Vector2.zero));
        }
        dropDownHeight.AddOptions(optList);
        dropDownDetails.AddOptions(optList);
    }

    public void SwapPlanet(int i)
    {
        if (selected == planets[i]) return;
        swaping = true;
        StartCoroutine(MoveAway(selected.gameObject));
        selected = planets[i];
        StartCoroutine(MoveIn(selected.gameObject));
        InitUI();
        swaping = false;
    }

    IEnumerator MoveAway(GameObject obj)
    {
        float t = 0;
        while (t <= 1)
        {
            obj.transform.position = Vector3.Lerp(Vector3.zero, -Camera.main.transform.right*40, t);
            t += Time.deltaTime;
            yield return null;
        }
        obj.SetActive(false);
    }
    IEnumerator MoveIn(GameObject obj)
    {
        obj.SetActive(true);
        float t = 0;
        while (t <= 1)
        {
            obj.transform.position = Vector3.Lerp(Camera.main.transform.right * 40, Vector3.zero, t);
            t += Time.deltaTime;
            yield return null;
        }
        obj.transform.position = Vector3.zero;
    }
    private void Update()
    {
        if(!swaping)
            InitPlanet();    
    }
    private void InitUI()
    {
        seed.value = selected.RandomSeed;
        size.value = selected.Size;
        ambient.value = selected.Ambient;
        relief.value = selected.Relief;
        waterLevel.value = selected.WaterLevel;
        shoresContrast.value = selected.ShoresContrast;
        opacity.value = selected.OceanOpacity;
        liquidColor.col = selected.LiquidColor;
        specularity.value = selected.Specularity;
        gloss.value = selected.Gloss;
        cloudsColor.col = selected.CloudsColor;
        cloudsAmount.value = selected.CloudsAmount;
        cloudsSpeed.value = selected.CloudsSpeed;
        cloudsSpread.value = selected.CloudsSpread;
        cloudsHeight.value = selected.CloudsHeight;
        atmosphereColor.col = selected.AtmosphereColor;
        atmosphereBrightness.value = selected.AtmosphereBrightness;
        atmosphereSize.value = selected.AtmosphereSize;
        atmosphereDensity.value = selected.AtmosphereDensity;
        atmossphereRefraction.value = selected.AtmosphereRefraction;
        atmosphereRim.value = selected.AtmosphereRim;
        frost.value = selected.Frost;
        frostContrast.value = selected.FrostContrast;
        heat.value = selected.Heat;
        vegetationColor.col = selected.VegetationColor;
        fertility.value = selected.Fertility;
        vegetationContrast.value = selected.VegetationContrast;
        frostResistance.value = selected.VegetationFrostResistance;
        citiesColor.col = selected.CitiesColor;
        population.value = selected.Population;
        popOnLand.isOn = selected.PopulationOnLand;
        popOnOcean.isOn = !selected.PopulationOnLand;
        popOnShores.isOn = selected.PopulationShoresMountainsBalance == 0;
        popOnMountains.isOn = selected.PopulationShoresMountainsBalance == 1;
        popFrost.value = selected.PopulationFrostModifier;
        popHeat.value = selected.PopulationHeatMultiplier;
        popVeg.value = selected.PopulationVegetationMultiplier;
        popNoVeg.value = selected.PopulationNoVegetationMultiplier;
        for(int i = 0; i < gradients.Length; i++)
        {
            if (gradients[i].colorKeys.SequenceEqual(selected.HeightGradient.colorKeys))
            {
                dropDownHeight.value = i;

            }
            if (gradients[i].colorKeys.SequenceEqual(selected.DetailsGradient.colorKeys))
            {
                dropDownDetails.value = i;
            }
        }
    }
    public void HeightGradientSelected(int i)
    {
        selected.HeightGradient = gradients[i];
    }
    public void DetailsGradientSelected(int i)
    {
        selected.DetailsGradient = gradients[i];
    }
    private void InitPlanet()
    {
        selected.RandomSeed = seed.value;
        selected.Size = size.value;
        selected.Ambient = ambient.value;
        selected.Relief = relief.value;
        selected.WaterLevel = waterLevel.value;
        selected.ShoresContrast = shoresContrast.value;
        selected.OceanOpacity = opacity.value;
        selected.LiquidColor = liquidColor.col;
        selected.Specularity = specularity.value;
        selected.Gloss = gloss.value;
        selected.CloudsColor = cloudsColor.col;
        selected.CloudsAmount = cloudsAmount.value;
        selected.CloudsSpeed = cloudsSpeed.value;
        selected.CloudsSpread = cloudsSpread.value;
        selected.CloudsHeight = cloudsHeight.value;
        selected.AtmosphereColor = atmosphereColor.col;
        selected.AtmosphereBrightness = atmosphereBrightness.value;
        selected.AtmosphereSize = atmosphereSize.value;
        selected.AtmosphereDensity = atmosphereDensity.value;
        selected.AtmosphereRefraction = atmossphereRefraction.value;
        selected.AtmosphereRim = atmosphereRim.value;
        selected.Frost = frost.value;
        selected.FrostContrast = frostContrast.value;
        selected.Heat = heat.value;
        selected.VegetationColor = vegetationColor.col;
        selected.Fertility = fertility.value;
        selected.VegetationContrast = vegetationContrast.value;
        selected.VegetationFrostResistance = frostResistance.value;
        selected.CitiesColor = citiesColor.col;
        selected.Population = population.value;
        selected.PopulationOnLand = popOnLand.isOn;
        selected.PopulationOnLand = !popOnOcean.isOn;
        selected.PopulationShoresMountainsBalance = popOnShores.isOn ? 0:1;
        selected.PopulationFrostModifier = popFrost.value;
        selected.PopulationHeatMultiplier = popHeat.value;
        selected.PopulationVegetationMultiplier = popVeg.value;
        selected.PopulationNoVegetationMultiplier = popNoVeg.value;

    }
}