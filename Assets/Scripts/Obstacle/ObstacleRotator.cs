using UnityEngine;
using DG.Tweening;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float _durationRotate360;

    private void Start()
    {
        transform.DORotate(Vector3.up * -360, _durationRotate360, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }
}
