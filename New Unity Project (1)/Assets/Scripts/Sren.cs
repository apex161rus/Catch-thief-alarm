using System.Collections;
using UnityEngine;

public class Sren : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    private AudioSource _audioSource;

    public IEnumerator TurnUpVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            float speed = 0.1f;
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, speed * Time.deltaTime);
            Debug.Log(_audioSource.volume);
            yield return null;
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>(); ;
        _audioSource.clip = _audioClip;
        _audioSource.volume = 0;
        _audioSource.Play();
    }
}
