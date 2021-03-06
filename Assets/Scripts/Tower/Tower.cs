using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    [SerializeField] private Level _level;
    private TowerBuilder _towerBuilder;

    private List<Block> _blocks = new List<Block>();

    public event UnityAction<int> OnViewSizeUpdate;

    private void Awake()
    {
        _level.onStartGame += OnStartGame;
    }

    private void OnStartGame()
    {
        Initialize();
    }

    private void Initialize()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _blocks = _towerBuilder.Build();

        foreach (var block in _blocks)
        {
            block.OnBreak += BreakBlock;
        }

        OnViewSizeUpdate?.Invoke(_blocks.Count);
    }

    private void BreakBlock(Block block)
    {
        block.OnBreak -= BreakBlock;

        _blocks.Remove(block);
        transform.position = new Vector3(transform.position.x, transform.position.y - block.transform.localScale.y / 2f, transform.position.z);

        OnViewSizeUpdate?.Invoke(_blocks.Count);
    }

    private void OnDestroy()
    {
        _level.onStartGame -= OnStartGame;
    }
}
