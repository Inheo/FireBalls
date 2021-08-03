using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private ParticleSystem _deadParticle;

    public event UnityAction<Block> OnBreak;


    #region properties
    public MeshRenderer MeshRenderer => _meshRenderer;
    #endregion

    public void Break()
    {
        ParticleSystem particle = Instantiate(_deadParticle, transform.position, _deadParticle.transform.rotation);
        particle.startColor = _meshRenderer.material.color;
        particle.Play();

        OnBreak?.Invoke(this);
        Destroy(gameObject);
    }
}
