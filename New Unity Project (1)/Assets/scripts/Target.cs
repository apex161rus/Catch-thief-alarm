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

    private bool _isWork;
    private Coroutine _coroutine;

    private void Start()
    {
        _slider.value = 0;
        _audioSource.volume = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isWork = true;
        if (collision.TryGetComponent<Plaer>(out Plaer plaer))
        {
            CheckForWork(TurndownVolume());
            _renderer.color = Color.red;
            _audioSource.clip = _audioClip;
            _audioSource.Play();
            _slider.value = _audioSource.volume;
            _coroutine = StartCoroutine(TurnUpVolume(_isWork));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isWork = false;
        if (collision.TryGetComponent<Plaer>(out Plaer plaer))
        {
            CheckForWork(TurnUpVolume(_isWork));
            _coroutine = StartCoroutine(TurndownVolume());
            _renderer.color = Color.green;
        }
    }

    private void CheckForWork(IEnumerator enumerator)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator TurnUpVolume(bool isTest)
    {
        while (isTest)
        {
            for (int i = 0; i < 500; i++)
            {
                Debug.Log(Time.deltaTime);
                _audioSource.volume += 0.002f;
                _slider.value = _audioSource.volume;
                yield return null;
            }
            for (int i = 0; i < 500; i++)
            {
                Debug.Log(Time.deltaTime);
                _audioSource.volume -= 0.002f;
                _slider.value = _audioSource.volume;
                yield return null;
            }
        }
        //for (int i = 0; i < 500; i++)
        //{
        //    Debug.Log(Time.deltaTime);
        //    _audioSource.volume += 0.002f;
        //    _slider.value = _audioSource.volume;
        //    yield return null;
        //}
        //for (int i = 0; i < 500; i++)
        //{
        //    Debug.Log(Time.deltaTime);
        //    _audioSource.volume -= 0.002f;
        //    _slider.value = _audioSource.volume;
        //    yield return null;
        //}
    }

    private IEnumerator TurndownVolume()
    {
        for (int i = 0; i < 500; i++)
        {
            Debug.Log(Time.deltaTime);
            _audioSource.volume += 0.002f;
            _slider.value = _audioSource.volume;
            yield return null;
        }
        for (int i = 0; i < 500; i++)
        {
            Debug.Log(Time.deltaTime);
            _audioSource.volume -= 0.002f;
            _slider.value = _audioSource.volume;
            yield return null;
        }
    }
}
