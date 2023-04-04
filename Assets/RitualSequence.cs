using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RitualSequence : MonoBehaviour
{
    [SerializeField] List<Transform> _instantiateTransforms;
    [SerializeField] GameObject _fireParent;
    [SerializeField] GameObject _fireSwirl;
    [SerializeField] Light _light;
    [SerializeField] AudioClip _ritualMusic;
    [SerializeField] AudioSource _musicSource;
    [SerializeField] Transform _finalCakeSpawn;
    [SerializeField] GameObject _finalCake;
    GameObject _cake;
    bool _growCake;

    // private List<ParticleSystem> _particles;

   // private void Start()
   // {
   //     StartRitual(); //debug testing DELETE
   // }


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
            var newParticleSystem = Instantiate(_fireParent, spawnPoint, false);
            ParticleSystem[] _particles = newParticleSystem.GetComponentsInChildren<ParticleSystem>();
            for (int i = 0; i <= _particles.Length -1; i++)
            {
                _particles[i].Play();
            }
            yield return new WaitForSeconds(0.3f);
        }
        _fireSwirl.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        _light.enabled = true;

        yield return new WaitForSeconds(3f);
        _cake = Instantiate(_finalCake, _finalCakeSpawn, false);
        _cake.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
        _growCake = true;
        
        yield return new WaitForSeconds(3f);
        _light.enabled = false;
        _growCake = false;

    }

    private void Update()
    {
     if (_growCake)
        _cake.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);

    }
}
