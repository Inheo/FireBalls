using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private float _delayBetweenShoot;
    [SerializeField] private Transform _parentBullet;
    [SerializeField] private float _recoilDistance;

    private float _timeAfterShoot;

    private void Update()
    {
        _timeAfterShoot += Time.deltaTime;

        if(Input.GetMouseButton(0) && _timeAfterShoot >= _delayBetweenShoot)
        {
            Shoot();
            transform.DOMoveZ(transform.position.z - _recoilDistance, _delayBetweenShoot / 2f).SetLoops(2, LoopType.Yoyo);
            _timeAfterShoot = 0;
        }
    }

    private void Shoot()
    {
        Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity, _parentBullet);
    }

}
