using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float _speed = 4;

        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetBool("isMove", Input.GetKey(KeyCode.D));
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.Translate(_speed * Time.deltaTime * 1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _animator.SetBool("isMove", Input.GetKey(KeyCode.A));
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.Translate(_speed * Time.deltaTime * 1, 0, 0);
        }
        else
        {
            _animator.SetBool("isMove", false);
        }
    }
}