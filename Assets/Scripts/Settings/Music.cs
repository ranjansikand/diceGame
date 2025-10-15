// Adjusts music volume


using UnityEngine;

public class Music : MonoBehaviour
{
    AudioSource audioSource;
    private void Awake() { audioSource = GetComponent<AudioSource>(); }
    private void OnEnable() { Data.volume += UpdateVolume; }
    private void OnDisable() { Data.volume -= UpdateVolume; }

    private void UpdateVolume() {
        audioSource.volume = Data.musicVolume;
    }
}
