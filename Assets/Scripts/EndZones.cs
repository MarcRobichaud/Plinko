using UnityEngine;

public class EndZones : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AudioSource audio = other.GetComponent<AudioSource>();
        audio.Play();
    }
}