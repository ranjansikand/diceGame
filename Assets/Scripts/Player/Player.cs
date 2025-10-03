// Controls the UI interaction


using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Dice dicePrefab;
    [SerializeField] List<DiceData> startingDice;
    [SerializeField] List<CardData> startingCards;

    public static List<Dice> dice = new List<Dice>();

    private void Awake() {
        PlayerData.dice = startingDice;
        PlayerData.cards = startingCards;
    }

    public void Roll() {
        PlayerData.performRoll = true;
    }

    public void SpawnDice() {
        if (dice.Count == 0 && PlayerData.cards.Count > 0) {
            // Draw all the cards
            foreach (DiceData die in PlayerData.dice) {
                Dice newDie = Instantiate(dicePrefab, transform);
                newDie.Create(die);
                dice.Add(newDie);
            }
        } else if (dice.Count < PlayerData.dice.Count) {
            for (int i = dice.Count; i < PlayerData.dice.Count; i++) {
                Dice newDie = Instantiate(dicePrefab, transform);
                newDie.Create(PlayerData.dice[i]);
                dice.Add(newDie);
            }
           
        }
    }
}