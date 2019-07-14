using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Galaxy
{
    [ExecuteInEditMode]
    [System.Serializable]
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]
    public class HPlanet : MonoBehaviour
    {
        #region Attribute
        [SerializeField]
        private Material _PlanetMaterial;
        [SerializeField]
        private GameObject _AtmosphereObject;
        [SerializeField]
        private Material _AtmosphereMaterial;
        [SerializeField]
        private Color _AtmosphereColor;
        [SerializeField]
        private float _AtmosphereSize;
        [SerializeField]
        private float _AtmosphereRim;
        [SerializeField]
        private float _AtmosphereRefraction;
        [SerializeField]
        private float _AtmosphereDensity;
        [SerializeField]
        private float _AtmosphereBrightness;
        [SerializeField]
        private int _HeightGradientResolution = 64;
        [SerializeField]
        private Texture2D _HeightGradientMap;
        [SerializeField]
        private int _DetailsGradientResolution = 64;
        [SerializeField]
        private Texture2D _DetailsGradientMap;
        #endregion

        public bool EmissiveWater
        {
            get
            {
                return _PlanetMaterial.GetInt("_EmissiveLiquid") == 1;
            }
            set
            {
                int i = value ? 1 : 0;
                _PlanetMaterial.SetInt("_EmissiveLiquid", i);
            }
        }
        public bool ComplexClouds
        {
            get
            {
                return _PlanetMaterial.IsKeywordEnabled("_COMPLEXCLOUDS");
            }
            set
            {
                if (value) _PlanetMaterial.EnableKeyword("_COMPLEXCLOUDS");
                else _PlanetMaterial.DisableKeyword("_COMPLEXCLOUDS");
            }
        }
        public Shader PlanetShader
        {
            get
            {
                return PlanetMaterial.shader;
            }
            set
            {
                PlanetMaterial.shader = value;
            }
        }
        public Material PlanetMaterial
        {
            get
            {
                if (_PlanetMaterial == null)
                    _PlanetMaterial = GetComponent<Renderer>().sharedMaterial;
                //if (_PlanetMaterial.shader != Shader.Find("Human Unit/Planet"))
                    //_PlanetMaterial.shader = Shader.Find("Human Unit/Planet");
                return _PlanetMaterial;
            }
            set
            {
                if (_PlanetMaterial == value) return;
                _PlanetMaterial = value;
                GetComponent<Renderer>().sharedMaterial = _PlanetMaterial;
                
            }
        }
        public GameObject AtmosphereObject
        {
            get
            {
                if (_AtmosphereObject == null)
                {
                    if (transform.Find("Atmosphere") != null)
                    {
                        _AtmosphereObject = transform.Find("Atmosphere").gameObject;
                    }
                    else
                    {
                        _AtmosphereObject = new GameObject("Atmosphere");
                    }
                    _AtmosphereObject.transform.SetParent(transform);
                    _AtmosphereObject.transform.localPosition = Vector2.zero;
                    MeshRenderer atmosphereMR=_AtmosphereObject.GetComponent<MeshRenderer>();
                    MeshFilter atmosphereMF= _AtmosphereObject.GetComponent<MeshFilter>();
                    if(atmosphereMR==null) atmosphereMR = _AtmosphereObject.AddComponent<MeshRenderer>();
                    if (atmosphereMF == null) atmosphereMF = _AtmosphereObject.AddComponent<MeshFilter>();
                    atmosphereMR.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                    atmosphereMF.sharedMesh = GetComponent<MeshFilter>().sharedMesh;
                    
                }
                return _AtmosphereObject;
            }
            set
            {
                _AtmosphereObject = value;
            }
        }
        public Material AtmosphereMaterial
        {
            get
            {
                //if (_AtmosphereMaterial == null)
                //{
                //    _AtmosphereMaterial = AtmosphereObject.GetComponent<MeshRenderer>().sharedMaterial;
                //    UpdateAtmosphereMaterial();
                //}
                //if(_AtmosphereMaterial == null)
                //{
                //    _AtmosphereMaterial = new Material(Shader.Find("Human Unit/Atmosphere"));
                //    AtmosphereObject.GetComponent<MeshRenderer>().sharedMaterial = _AtmosphereMaterial;
                //    UpdateAtmosphereMaterial();
                //}
                //if (_AtmosphereMaterial.shader != Shader.Find("Human Unit/Atmosphere"))
                //{
                //    _AtmosphereMaterial.shader = Shader.Find("Human Unit/Atmosphere");
                //    UpdateAtmosphereMaterial();
                //}
                
                return _AtmosphereMaterial;
            }
            set
            {
                AtmosphereObject.GetComponent<MeshRenderer>().sharedMaterial = value;
                _AtmosphereMaterial = value;
            }
        }
        public Color AtmosphereColor
        {
            get
            {
                return _AtmosphereColor;
            }
            set
            {
                _AtmosphereColor = value;
                AtmosphereMaterial.SetColor("_Color", value);
            }
        }
        public float AtmosphereSize
        {
            get
            {
                return _AtmosphereSize;
            }
            set
            {
                _AtmosphereSize = value;
                AtmosphereMaterial.SetFloat("_Size", Mathf.Max(value,0.01f));
                AtmosphereMaterial.SetFloat("_Border", AtmosphereBorderCurve(value));
            }
        }
        public float AtmosphereRim
        {
            get
            {
                return _AtmosphereRim;
            }
            set
            {
                _AtmosphereRim = value;
                AtmosphereMaterial.SetFloat("_Rim", value);
            }
        }
        public float AtmosphereRefraction
        {
            get
            {
                return _AtmosphereRefraction;
            }
            set
            {
                _AtmosphereRefraction = value;
                AtmosphereMaterial.SetFloat("_Refraction", value);
            }
        }
        public float AtmosphereDensity
        {
            get
            {
                return _AtmosphereDensity;
            }
            set
            {
                _AtmosphereDensity = value;
                AtmosphereMaterial.SetFloat("_Density", value);
            }
        }
        public float AtmosphereBrightness
        {
            get
            {
                return _AtmosphereBrightness;
            }
            set
            {
                _AtmosphereBrightness = value;
                AtmosphereMaterial.SetFloat("_Brightness", value);
            }
        }

        private Texture2D GenerateGradient(int width, Gradient gradient)
        {
            Texture2D tex = new Texture2D(width, 1, TextureFormat.ARGB32, false, true)
            {
                wrapMode = TextureWrapMode.Clamp
            };
            Color32[] pixels = new Color32[width];
            for(int x = 0; x < width; x++)
            {
                pixels[x] = gradient.Evaluate(x / (float)width);
            }
            tex.SetPixels32(pixels);
            
            tex.Apply(true);
            return tex;
        }
        public void UpdateHeightGradientMap()
        {
            Color32[] pixels = new Color32[HeightGradientMap.width];
            for (int x = 0; x < pixels.Length; x++)
            {
                pixels[x] = HeightGradient.Evaluate(x / (float)HeightGradientMap.width);
            }
            if (pixels == HeightGradientMap.GetPixels32()) return;
            HeightGradientMap.SetPixels32(pixels);
            HeightGradientMap.Apply(true);
            PlanetMaterial.SetTexture("_HeightGradient",HeightGradientMap);
        }
        public void UpdateDetailsGradientMap()
        {
            Color32[] pixels = new Color32[DetailsGradientMap.width];
            for (int x = 0; x < pixels.Length; x++)
            {
                pixels[x] = DetailsGradient.Evaluate(x / (float)DetailsGradientMap.width);
            }
            //if (pixels == DetailsGradientMap.GetPixels32()) return;
            DetailsGradientMap.SetPixels32(pixels);
            DetailsGradientMap.Apply(true);
            PlanetMaterial.SetTexture("_DetailsGradient", DetailsGradientMap);
        }

        //Begin Height Gradient

        
        public int HeightGradientResolution
        {
            get
            {
                return _HeightGradientResolution;
            }
            set
            {
                DestroyImmediate(HeightGradientMap);
                HeightGradientMap = GenerateGradient(value, HeightGradient);
                _HeightGradientResolution = value;
            }
        }

        public Gradient HeightGradient=new Gradient();

        
        private Texture2D HeightGradientMap
        {
            get
            {
                if (_HeightGradientMap == null)
                    _HeightGradientMap = new Texture2D(HeightGradientResolution, 1);
                _HeightGradientMap.wrapMode = TextureWrapMode.Clamp;
                return _HeightGradientMap;
            }
            set
            {
                _HeightGradientMap = value;
            }
        }

        //End Height Gradient
        //Begin Details Gradient

        
        public int DetailsGradientResolution
        {
            get
            {
                return _DetailsGradientResolution;
            }
            set
            {
                DestroyImmediate(DetailsGradientMap);
                DetailsGradientMap = GenerateGradient(value, DetailsGradient);
                _DetailsGradientResolution = value;
            }
        }
        public float detailsColorMultiplier = 1;
        public Gradient DetailsGradient = new Gradient();

        
        public Texture2D DetailsGradientMap
        {
            get
            {
                if (_DetailsGradientMap == null)
                    _DetailsGradientMap = new Texture2D(DetailsGradientResolution, 1);
                return _DetailsGradientMap;
            }
            set
            {
                _DetailsGradientMap = value;
            }
        }

        //End Details Gradient

        public float WaterLevel
        {
            get
            {
                return (PlanetMaterial.GetFloat("_WaterLevel")+1)*0.5f;
            }
            set
            {
                PlanetMaterial.SetFloat("_WaterLevel", (value * 2 - 1));
            }
        }

        public float ShoresContrast
        {
            get
            {
                return PlanetMaterial.GetFloat("_ShoresContrast");
            }
            set
            {
                PlanetMaterial.SetFloat("_ShoresContrast",value);
            }
        }
        public float OceanOpacity
        {
            get
            {
                return PlanetMaterial.GetFloat("_OceanOpacity");
            }
            set
            {
                PlanetMaterial.SetFloat("_OceanOpacity", value);
            }
        }
        public float Gloss
        {
            get
            {
                return PlanetMaterial.GetFloat("_Gloss");
            }
            set
            {
                PlanetMaterial.SetFloat("_Gloss", value);
            }
        }
        public float Specularity
        {
            get
            {
                return PlanetMaterial.GetFloat("_Specularity");
            }
            set
            {
                PlanetMaterial.SetFloat("_Specularity", value);
            }
        }
        public float Frost
        {
            get
            {
                return Remap(PlanetMaterial.GetFloat("_Frost"),-0.51f,3,0,1);
            }
            set
            {
                PlanetMaterial.SetFloat("_Frost", Remap(value,0,1,-0.51f,3));
            }
        }
        public float FrostContrast
        {
            get
            {
                return PlanetMaterial.GetFloat("_FrostContrast");
            }
            set
            {
                PlanetMaterial.SetFloat("_FrostContrast", value);
            }
        }
        public float Heat
        {
            get
            {
                return PlanetMaterial.GetFloat("_Heat");
            }
            set
            {
                PlanetMaterial.SetFloat("_Heat", value);
            }
        }
        public Color CloudsColor
        {
            get
            {
                return PlanetMaterial.GetColor("_CloudsColor");
            }
            set
            {
                PlanetMaterial.SetColor("_CloudsColor", value);
            }
        }

        public bool CloudsAvgBlend
        {
            get
            {
                return PlanetMaterial.GetInt("_CloudsAvgBlend") == 1;
            }
            set
            {
                if (value) PlanetMaterial.SetInt("_CloudsAvgBlend", 1);
                else PlanetMaterial.SetInt("_CloudsAvgBlend", 0);
            }
        }
        public float CloudsSpeed
        {
            get
            {
                return PlanetMaterial.GetFloat("_CloudsSpeed");
            }
            set
            {
                PlanetMaterial.SetFloat("_CloudsSpeed", value);
            }
        }
        public float CloudsAmount
        {
            get
            {
                return PlanetMaterial.GetFloat("_CloudsAmount");
            }
            set
            {
                PlanetMaterial.SetFloat("_CloudsAmount", value);
                if (value == 0) PlanetMaterial.DisableKeyword("_CLOUDS");
                else PlanetMaterial.EnableKeyword("_CLOUDS");

            }
        }
        public float CloudsHeight
        {
            get
            {
                return PlanetMaterial.GetFloat("_CloudsHeight");
            }
            set
            {
                PlanetMaterial.SetFloat("_CloudsHeight", value);
            }
        }
        public float CloudsSpread
        {
            get
            {
                return PlanetMaterial.GetFloat("_CloudsSpread");
            }
            set
            {
                PlanetMaterial.SetFloat("_CloudsSpread", value);
            }
        }
        public float Relief
        {
            get
            {
                return PlanetMaterial.GetFloat("_Relief");
            }
            set
            {
                PlanetMaterial.SetFloat("_Relief", value);
            }
        }
        public float Fertility
        {
            get
            {
                return PlanetMaterial.GetFloat("_Fertility");
            }
            set
            {
                PlanetMaterial.SetFloat("_Fertility", value);
            }
        }
        public float VegetationContrast
        {
            get
            {
                return PlanetMaterial.GetFloat("_VegetationContrast")*2;
            }
            set
            {
                PlanetMaterial.SetFloat("_VegetationContrast", value*0.5f);
            }
        }
        public float Ambient
        {
            get
            {
                return PlanetMaterial.GetFloat("_Ambient");
            }
            set
            {
                PlanetMaterial.SetFloat("_Ambient", value);
            }
        }
        public float VegetationFrostResistance
        {
            get
            {
                return PlanetMaterial.GetFloat("_VegetationFrostResistance");
            }
            set
            {
                PlanetMaterial.SetFloat("_VegetationFrostResistance", value);
            }
        }
        public Color VegetationColor
        {
            get
            {
                return PlanetMaterial.GetColor("_Vegetation");
            }
            set
            {
                PlanetMaterial.SetColor("_Vegetation", value);
            }
        }
        public float Population
        {
            get
            {
                return PlanetMaterial.GetFloat("_Population");
            }
            set
            {
                PlanetMaterial.SetFloat("_Population", value);
            }
        }
        public Color CitiesColor
        {
            get
            {
                return PlanetMaterial.GetColor("_CitiesColor");
            }
            set
            {
                PlanetMaterial.SetColor("_CitiesColor", value);
            }
        }
        public float PopulationFrostModifier
        {
            get
            {
                return PlanetMaterial.GetFloat("_PopulationFrostModifier");
            }
            set
            {
                PlanetMaterial.SetFloat("_PopulationFrostModifier", value);
            }
        }
        public float PopulationHeatMultiplier
        {
            get
            {
                return PlanetMaterial.GetFloat("_HeatMultiplier");
            }
            set
            {
                PlanetMaterial.SetFloat("_HeatMultiplier", value);
            }
        }
        public float PopulationVegetationMultiplier
        {
            get
            {
                return PlanetMaterial.GetFloat("_VegetationMultiplier");
            }
            set
            {
                PlanetMaterial.SetFloat("_VegetationMultiplier", value);
            }
        }
        public float PopulationNoVegetationMultiplier
        {
            get
            {
                return PlanetMaterial.GetFloat("_NoVegetationMultiplier");
            }
            set
            {
                PlanetMaterial.SetFloat("_NoVegetationMultiplier", value);
            }
        }
        public bool PopulationOnLand
        {
            get { return PlanetMaterial.GetFloat("_PopulationLandOcean") == 0; }
            set
            {
                if (value) PlanetMaterial.SetFloat("_PopulationLandOcean", 0);
                else PlanetMaterial.SetFloat("_PopulationLandOcean", 1);
            }
        }
        public float PopulationShoresMountainsBalance
        {
            get
            {
                return PlanetMaterial.GetFloat("_PopulationShoresMountains");
            }
            set
            {
                PlanetMaterial.SetFloat("_PopulationShoresMountains", value);
            }
        }
        public float RandomSeed
        {
            get
            {
                return PlanetMaterial.GetFloat("_RandomSeed");
            }
            set
            {
                PlanetMaterial.SetFloat("_RandomSeed", value);
            }
        }
        public float Size
        {
            get
            {
                return PlanetMaterial.GetFloat("_Size");
            }
            set
            {
                PlanetMaterial.SetFloat("_Size", value);
            }
        }

        public Color LiquidColor
        {
            get
            {
                return PlanetMaterial.GetColor("_AtmosphereColor");
            }
            set
            {
                PlanetMaterial.SetColor("_AtmosphereColor", value);
            }
        }
        public Texture HeightMap
        {
            get
            {
                return PlanetMaterial.GetTexture("_Height");
            }
            set
            {
                PlanetMaterial.SetTexture("_Height", value);
            }
        }
        public Texture DetailsMap
        {
            get
            {
                return PlanetMaterial.GetTexture("_AdditionalDetails");
            }
            set
            {
                PlanetMaterial.SetTexture("_AdditionalDetails", value);
            }
        }
        public float DetailsScale
        {
            get
            {
                return PlanetMaterial.GetTextureScale("_AdditionalDetails").x;
            }
            set
            {
                PlanetMaterial.SetTextureScale("_AdditionalDetails", Vector2.one * value);
            }
        }
        public Texture CloudsMap
        {
            get
            {
                return PlanetMaterial.GetTexture("_Clouds");
            }
            set
            {
                PlanetMaterial.SetTexture("_Clouds", value);
            }
        }
        public Texture CloudsPoleMap
        {
            get
            {
                return PlanetMaterial.GetTexture("_CloudsPole");
            }
            set
            {
                PlanetMaterial.SetTexture("_CloudsPole", value);
            }
        }
        public Texture NormalsMap
        {
            get
            {
                return PlanetMaterial.GetTexture("_Normal");
            }
            set
            {
                PlanetMaterial.SetTexture("_Normal", value);
            }
        }
        public Texture FertilityMap
        {
            get
            {
                return PlanetMaterial.GetTexture("_FertilityMap");
            }
            set
            {
                PlanetMaterial.SetTexture("_FertilityMap", value);
            }
        }
        public float FertilityScale
        {
            get
            {
                return PlanetMaterial.GetTextureScale("_FertilityMap").x;
            }
            set
            {
                PlanetMaterial.SetTextureScale("_FertilityMap", Vector2.one * value);
            }
        }
        public Texture CitiesMap
        {
            get
            {
                return PlanetMaterial.GetTexture("_Cities");
            }
            set
            {
                PlanetMaterial.SetTexture("_Cities", value);
            }
        }
        public float CitiesScale
        {
            get
            {
                return  PlanetMaterial.GetTextureScale("_Cities").x;
            }
            set
            {
                PlanetMaterial.SetTextureScale("_Cities", Vector2.one * value);
            }
        }

        private void Update()
        {
            if (Application.isEditor)
                UpdateGradients();
        }
        private void OnEnable()
        {
            CreateAtmosphereMaterial();
            UpdateDetailsGradientMap();
            UpdateHeightGradientMap();
        }
        private void UpdateGradients()
        {
            UpdateDetailsGradientMap();
            UpdateHeightGradientMap();
        }
        public void MakeUnique()
        {
            AtmosphereMaterial = new Material(AtmosphereMaterial);
            PlanetMaterial = new Material(PlanetMaterial);
        }

        public Material GetPlanetMaterial()
        {
            return new Material(PlanetMaterial);
        }

        public Material GetAtmosphereMaterial()
        {
            return new Material(AtmosphereMaterial);
        }

        private void CreateAtmosphereMaterial()
        {
            if (AtmosphereMaterial && AtmosphereMaterial.shader == Shader.Find("Human Unit/Atmosphere"))
            {
                UpdateAtmosphereMaterial();
                return;
            }
            DestroyImmediate(AtmosphereMaterial);
            Material atmosphere = new Material(Shader.Find("Human Unit/Atmosphere"));
            //print(_AtmosphereSize);
            AtmosphereMaterial = atmosphere;
            UpdateAtmosphereMaterial();

        }

        private void UpdateAtmosphereMaterial()
        {
            _AtmosphereMaterial = AtmosphereObject.GetComponent<MeshRenderer>().sharedMaterial;
            _AtmosphereMaterial.SetFloat("_Brightness", _AtmosphereBrightness);
            _AtmosphereMaterial.SetFloat("_Density", _AtmosphereDensity);
            _AtmosphereMaterial.SetFloat("_Refraction", _AtmosphereRefraction);
            _AtmosphereMaterial.SetFloat("_Rim", _AtmosphereRim);
            _AtmosphereMaterial.SetFloat("_Size", _AtmosphereSize);
            _AtmosphereMaterial.SetFloat("_Border", AtmosphereBorderCurve(_AtmosphereSize));
            _AtmosphereMaterial.SetColor("_Color", AtmosphereColor);
        }
        private float Remap(float value, float iMin, float iMax, float oMin, float oMax)
        {
            return oMin + (value - iMin) * (oMax - oMin) / (iMax - iMin);
        }
        private float AtmosphereBorderCurve(float x)
        {
            return -1.5961f * x * x * x * x + 3.8425f * x * x * x - 3.3143f * x * x + 1.4382f * x + 0.0022f;
        }
    }
}