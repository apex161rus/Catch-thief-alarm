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
        _slider.value = 0;
        _audioSource.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Plaer>(out Plaer plaer))
        {
            CheckForWork(_coroutine);
            _renderer.color = Color.red;
            _audioSource.clip = _audioClip;
            _audioSource.Play();
            _slider.value = _audioSource.volume;
            _coroutine = StartCoroutine(TurnUpVolume());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Plaer>(out Plaer plaer))
        {
            CheckForWork(_coroutine);
            _renderer.color = Color.green;
            _coroutine = StartCoroutine(TurndownVolume());
        }
    }

    private void CheckForWork(Coroutine carutina)
    {
        if (carutina != null)
        {
            StopCoroutine(carutina);
        }
    }

    private IEnumerator TurnUpVolume()
    {
        for (int i = 0; i < 500; i++)
        {
            Debug.Log(Time.deltaTime);
            _audioSource.volume += 0.002f;
            _slider.value = _audioSource.volume;
            yield return null;
        }
    }

    private IEnumerator TurndownVolume()
    {
        for (int i = 0; i < 500; i++)
        {
            Debug.Log(Time.deltaTime);
            _audioSource.volume -= 0.002f;
            _slider.value = _audioSource.volume;
            yield return null;
        }
    }
}
