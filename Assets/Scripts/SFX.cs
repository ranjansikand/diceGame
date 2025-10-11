// Plays audio effects


using UnityEngine;

public class SFX : MonoBehaviour
{
    AudioSource audioSource;

    public delegate void AudioEvent();
    public static AudioEvent playClick, playHover;

    [SerializeField] AudioClip[] diceRolls, click, hover;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() {
        Dice.rolled += DiceRoll;
        playClick += Click;
        playHover += Hover;
    }

    private void OnDisable() {
        Dice.rolled -= DiceRoll;
        playClick -= Click;
        playHover -= Hover;
    }

    private void DiceRoll(Dice dice) {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(
            diceRolls[Random.Range(0, diceRolls.Length)], 
            Data.sfxVolume
        );
    }

    private void Click() {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(
            click[Random.Range(0, click.Length)], 
            Data.sfxVolume
        );
    }

    private void Hover() {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(
            hover[Random.Range(0, hover.Length)], 
            Data.sfxVolume
        );
    }
}
