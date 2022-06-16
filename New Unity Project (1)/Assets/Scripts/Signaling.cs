using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Signaling : MonoBehaviour
{
    [Tooltip("Insert audio signal")]
    [SerializeField] private AudioClip _audioClip;

    private AudioSource _audioSource;
    private Coroutine _coroutine;

    public void MaxVolume()
    {
        float maxVolume = 1f;
        CheckForStopAttempt(_coroutine);
        _coroutine = StartCoroutine(RenameVolume(maxVolume));
    }

    public void MinVolume()
    {
        float minVolume = 0f;
        CheckForStopAttempt(_coroutine);
        _coroutine = StartCoroutine(RenameVolume(minVolume));
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _audioClip;
        _audioSource.volume = 0;
        _audioSource.Play();
    }

    private IEnumerator RenameVolume(float volume)
    {
        while (_audioSource.volume != volume)
        {
            float speed = 0.1f;
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, speed * Time.deltaTime);
            yield return null;
        }
    }

    private void CheckForStopAttempt(Coroutine coroutine)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }
}
