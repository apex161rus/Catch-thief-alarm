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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Plaer>(out Plaer plaer))
        {
            _renderer.color = _rendererColor;
            _audioSource.clip = _audioClip;
            _audioSource.Play();
            _audioSource.volume = 1.0f;
            _slider.value = _audioSource.volume;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Plaer>(out Plaer plaer))
        {
            StopCoroutine(TurnDownVolume());
            _renderer.color = Color.green;
            //Debug.Log(Time.deltaTime);
            StartCoroutine(TurnDownVolume());
        }
    }

    private IEnumerator TurnDownVolume()
    {
        for (int i = 0; i < 990; i++)
        {
            Debug.Log(Time.deltaTime);
            _audioSource.volume -= 0.001f;
            _slider.value = _audioSource.volume;
            yield return null;
            //yield return null;
        }
    }
}
