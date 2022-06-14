using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    private Sren _sren;
    private Coroutine _coroutine;

    private void Start()
    {
        _sren = GetComponent<Sren>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float maxVolume = 1f;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            CheckForStopAttempt(_coroutine);
            _renderer.color = Color.red;
            _coroutine = StartCoroutine(_sren.TurnUpVolume(maxVolume));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        float minVolume = 0f;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            CheckForStopAttempt(_coroutine);
            _renderer.color = Color.green;
            _coroutine = StartCoroutine(_sren.TurnUpVolume(minVolume));
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
