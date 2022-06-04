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

    private IEnumerator _enumerator1;

    private void Start()
    {
        _slider.value = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Plaer>(out Plaer plaer))
        {
            _renderer.color = Color.red;
            _audioSource.clip = _audioClip;
            _audioSource.Play();
            _audioSource.volume = 1.0f;
            _slider.value = _audioSource.volume;
            StopCoroutine(_enumerator1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _enumerator1 = TurnDownVolume();

        if (collision.TryGetComponent<Plaer>(out Plaer plaer))
        {
            _renderer.color = Color.green;
            StartCoroutine(_enumerator1);
        }
    }

    private IEnumerator TurnDownVolume()
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
