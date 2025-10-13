// Plays audio effects


using UnityEngine;

public class SFX : MonoBehaviour
{
    AudioSource audioSource;

    public delegate void AudioEvent();
    public static AudioEvent playClick, playHoverDie, playHoverCard, playHoverUI;

    [SerializeField] AudioClip[] diceRolls, click;
    [SerializeField] AudioClip hoverDie, hoverCard, hoverUI;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() {
        Dice.rolled += DiceRoll;
        playClick += Click;
        playHoverDie += PlayHoverDie;
        playHoverCard += PlayHoverCard;
        playHoverUI += PlayHoverUI;
    }

    private void OnDisable() {
        Dice.rolled -= DiceRoll;
        playClick -= Click;
        playHoverDie -= PlayHoverDie;
        playHoverCard -= PlayHoverCard;
        playHoverUI -= PlayHoverUI;
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

    private void PlayHoverDie() {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(
            hoverDie,
            Data.sfxVolume
        );
    }

    private void PlayHoverCard() {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(
            hoverCard,
            Data.sfxVolume
        );
    }

        private void PlayHoverUI() {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(
            hoverUI,
            Data.sfxVolume
        );
    }
}
