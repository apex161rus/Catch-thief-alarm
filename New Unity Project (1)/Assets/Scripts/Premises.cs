using UnityEngine;

[RequireComponent(typeof(Signaling))]
[RequireComponent(typeof(BoxCollider2D))]

public class Premises : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;

    private BoxCollider2D _box;
    private Signaling _sren;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _box = GetComponent<BoxCollider2D>();
        _sren = GetComponent<Signaling>();
        _box.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _renderer.color = Color.red;
            _sren.MaxVolume();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _renderer.color = Color.green;
            _sren.MinVolume();
        }
    }
}
