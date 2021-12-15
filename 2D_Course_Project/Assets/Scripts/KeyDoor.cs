using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;

    [SerializeField] private AudioClip doorOpen;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }
    
    public void OpenDoor()
    {
        // Проигрыш звука
        audioSource.PlayOneShot(doorOpen, 1f);

        Destroy(gameObject, 0.5f);
    }
}
