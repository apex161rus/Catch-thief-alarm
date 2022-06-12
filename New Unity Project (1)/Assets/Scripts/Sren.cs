using UnityEngine;

public class Sren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    private void Start()
    {
        _audioSource.clip = _audioClip;
        _audioSource.volume = 0;
    }

    public void Plaer()
    {
        _audioSource.Play();
    }

    public void ChangeVolume(float volume)
    {
        _audioSource.volume = volume;
    }

    public float GetVolume()
    {
        return _audioSource.volume;
    }
}
