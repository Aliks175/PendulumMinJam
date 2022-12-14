using UnityEngine;

public class OnStartParticleEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;

    private void OnDestroy()
    {
        _particle.Play();
    }
}
