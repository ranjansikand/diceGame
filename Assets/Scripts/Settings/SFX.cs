// Plays audio effects


using UnityEngine;

public class SFX : MonoBehaviour
{
    AudioSource audioSource;

    public delegate void AudioEvent();
    public static AudioEvent playClick, playHoverDie, playHoverCard, playHoverUI;

    public delegate void ChosenAudio(int x);
    public static ChosenAudio playMoney;

    [SerializeField] AudioClip[] diceRolls, click;
    [SerializeField] AudioClip hoverDie, hoverCard, hoverUI;
    [SerializeField] AudioClip[] money;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable() {
        Dice.rolled += DiceRoll;
        playClick += Click;
        playHoverDie += PlayHoverDie;
        playHoverCard += PlayHoverCard;
        playHoverUI += PlayHoverUI;
        playMoney += PlayMoney;
    }

    private void OnDisable() {
        Dice.rolled -= DiceRoll;
        playClick -= Click;
        playHoverDie -= PlayHoverDie;
        playHoverCard -= PlayHoverCard;
        playHoverUI -= PlayHoverUI;
        playMoney -= PlayMoney;
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

    private void PlayMoney(int i) {
        audioSource.pitch = Random.Range(0.9f, 1.1f);
        
        if (i <= 0) {
            audioSource.PlayOneShot(
                money[0],
                Data.sfxVolume
            );
        } else {
            audioSource.PlayOneShot(
                money[1],
                Data.sfxVolume
            );
        }
    }
}
