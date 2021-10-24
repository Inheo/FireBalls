using UnityEngine;

[CreateAssetMenu(menuName = "Level Settings", fileName = "level-settings-")]
public class LevelSettings : ScriptableObject, ITowerSettingsProvider, ITankSettingsProvider, IObstacleSettingsProvider,
                                IBridgeSettingsProvider, ITowerSizeViewProvider, IWaterSettingsProvider
{
    [SerializeField] private int _towerSize;
    [SerializeField] private Color _bulletColor;
    [SerializeField] private Color _tankColor;
    [SerializeField] private Color _obstacleColor;
    [SerializeField] private Color _bridgeColor;
    [SerializeField] private Color _towerSizeViewColor;
    [SerializeField] private Color _waterColor;
    [SerializeField] private Color[] _pipeColors;
    public ObstacleSettings[] obstacleSettings;

#region 

    public int TowerSize => _towerSize;
    public Color BulletColor => _bulletColor;
    public Color TankColor => _tankColor;
    public Color BridgeColor => _bridgeColor;
    public Color ObstacleColor => _obstacleColor;
    public Color TowerSizeViewColor => _towerSizeViewColor;
    public Color WaterColor => _waterColor;
    public Color[] PipeColors => _pipeColors;

    #endregion
}
