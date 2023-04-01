using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualSequence : MonoBehaviour
{
    [SerializeField] List<Transform> _instantiateTransforms;
    [SerializeField] ParticleSystem _particles;
    [SerializeField] Light _light;
    [SerializeField] AudioClip _ritualMusic;
    [SerializeField] AudioSource _musicSource;
    [SerializeField] GameObject _finalCake;

    public void StartRitual()
    {
        StartCoroutine(Ritual());
    }

    public IEnumerator Ritual()
    {
        if (_musicSource)
        {
            if (_ritualMusic)
                _musicSource.clip = _ritualMusic;
        }
        yield return new WaitForSeconds(0.5f);
        
        foreach (Transform spawnPoint in _instantiateTransforms)
        {
            var newParticle = Instantiate(_particles, spawnPoint, false);
            newParticle.Play();
            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(0.5f);
        _light.enabled = true;

        yield return new WaitForSeconds(0.5f);
        Instantiate(_finalCake, this.transform, true);

        yield return new WaitForSeconds(0.5f);

    }
}
