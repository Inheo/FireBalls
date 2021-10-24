using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private Material _waterMaterial;
    [SerializeField] private Material _waterGroundMaterial;
    [SerializeField] private Material _bulletMaterial;
    [SerializeField] private Material _tankMaterial;
    [SerializeField] private Material _bridgeMaterial;
    [SerializeField] private Material _obstacleMaterial;
    [SerializeField] private Material _basePipeMaterial;
    [SerializeField] private TMP_Text _towerSizeView;

    [SerializeField] private LevelSettings[] _levelSettings;

    public LevelSettings CurrentLevelSettings {get; private set; }

    public int TowerSize { get; private set; }

    public event System.Action onStartGame;

    public List<Material> PipeMaterials { get; private set; }
    
    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        PipeMaterials = new List<Material>();

        CurrentLevelSettings = _levelSettings[PlayerPrefs.GetInt(LevelUtillity.LEVEL_NAME, 0)];

        TowerSize = CurrentLevelSettings.TowerSize;

        _waterMaterial.SetColor("_WaterColor", CurrentLevelSettings.WaterColor);
        _waterGroundMaterial.SetColor("_WaterColor", CurrentLevelSettings.WaterColor);
        _bulletMaterial.color = CurrentLevelSettings.BulletColor;
        _bridgeMaterial.color = CurrentLevelSettings.BridgeColor;
        _tankMaterial.color = CurrentLevelSettings.TankColor;
        _obstacleMaterial.color = CurrentLevelSettings.ObstacleColor;
        _towerSizeView.color = CurrentLevelSettings.TowerSizeViewColor;
        
        for (var i = 0; i < CurrentLevelSettings.PipeColors.Length; i++)
        {
            if(PipeMaterials.Count <= i)
                PipeMaterials.Add(new Material(_basePipeMaterial.shader));
            PipeMaterials[i].color = CurrentLevelSettings.PipeColors[i];
        }

        onStartGame?.Invoke();
    }
}
