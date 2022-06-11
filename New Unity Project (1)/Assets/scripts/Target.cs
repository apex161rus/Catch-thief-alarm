using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Slider _slider;
    [SerializeField] private Color _rendererColor;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private Coroutine _coroutine;

    private void Start()
    {
        _slider.value = 0f;
        _audioSource.volume = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float maxVolume = 1f;

        if (collision.TryGetComponent<Plaer>(out Plaer plaer))
        {
            CheckForWork(_coroutine);
            _renderer.color = Color.red;
            _audioSource.clip = _audioClip;
            _audioSource.Play();
            _coroutine = StartCoroutine(TurnUpVolume(maxVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        float minVolume = 0f;

        if (collision.TryGetComponent<Plaer>(out Plaer plaer))
        {
            CheckForWork(_coroutine);
            _renderer.color = Color.green;
            _coroutine = StartCoroutine(TurnUpVolume(minVolume));
        }
    }

    private void CheckForWork(Coroutine coroutine)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    private IEnumerator TurnUpVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            float speed = 0.1f;
            Debug.Log(Time.deltaTime);
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, speed * Time.deltaTime);
            _slider.value = _audioSource.volume;
            yield return null;
        }
    }
}
