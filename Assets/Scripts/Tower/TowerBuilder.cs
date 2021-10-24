using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;

    [SerializeField] private Material[] _materialsForBlock;

    private List<Block> _blocks = new List<Block>();

    public List<Block> Build()
    {
        Transform currentPoint = _buildPoint;
        _materialsForBlock = _level.PipeMaterials.ToArray();

        for (int i = 0; i < _level.TowerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            newBlock.MeshRenderer.material = _materialsForBlock[i % _materialsForBlock.Length];

            _blocks.Add(newBlock);

            currentPoint = newBlock.transform;
        }

        return _blocks;
    }

    private Block BuildBlock(Transform buildPoint)
    {
        return Instantiate(_block, GetBuildPoint(buildPoint), Quaternion.identity, _buildPoint);
    }

    private Vector3 GetBuildPoint(Transform point)
    {
        return new Vector3(point.position.x, point.position.y + _block.transform.localScale.y / 2f, point.position.z);
    }

}
