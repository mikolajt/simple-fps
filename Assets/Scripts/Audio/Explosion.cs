using UnityEngine;

public class Explosion : MonoBehaviour
{
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Play();
    }
}
