using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Slider _slider;
    [SerializeField] private Color _rendererColor;
    [SerializeField] private Sren _sren;

    private Coroutine _coroutine;

    private void Start()
    {
        _slider.value = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float maxVolume = 1f;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            CheckForWork(_coroutine);
            _renderer.color = Color.red;
            _sren.Plaer();
            _coroutine = StartCoroutine(TurnUpVolume(maxVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        float minVolume = 0f;

        if (collision.TryGetComponent<Player>(out Player player))
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
        while (_sren.GetVolume() != targetVolume)
        {
            float speed = 0.1f;
            Debug.Log(Time.deltaTime);
            _sren.ChangeVolume(Mathf.MoveTowards(_sren.GetVolume(), targetVolume, speed * Time.deltaTime));
            _slider.value = _sren.GetVolume();
            yield return null;
        }
    }
}
