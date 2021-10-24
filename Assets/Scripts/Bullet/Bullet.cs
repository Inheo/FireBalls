using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    private Camera cameraMain;

    private Vector3 moveDirection;

    private void OnEnable()
    {
        moveDirection = transform.forward;
    }

    private void Start()
    {
        cameraMain = Camera.main;
    }

    private void Update()
    {
        transform.Translate(moveDirection * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            block.Break();
            gameObject.SetActive(false);
        }
        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Bounce();
        }
    }

    private void Bounce()
    {
        moveDirection = (cameraMain.transform.position - transform.position).normalized;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddExplosionForce(_bounceForce, transform.position + new Vector3(0, -1, -1), _bounceRadius);

        StartCoroutine(Delay(2f, () =>
        {
            rigidbody.isKinematic = true;
            rigidbody.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
        ));
    }

    private void OnDisable()
    {
        transform.position = Vector3.zero;
    }

    private IEnumerator Delay(float time, System.Action action)
    {
        yield return new WaitForSeconds(time);
        action?.Invoke();
    }
}
