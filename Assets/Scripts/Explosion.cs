using UnityEngine;

public class Explosion : MonoBehaviour
{
    public AudioClip explosionSFX;
    void Start()
    {
        // Add an AudioSource component if not already present
        var audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(explosionSFX, 0.7f);
        Destroy(gameObject, 1);
    }
}