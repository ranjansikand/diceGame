// Controls the UI interaction


using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] List<Dice> startingDice;
    [SerializeField] List<CardData> startingCards;

    private void Awake() {
        PlayerData.dice = startingDice;
        PlayerData.cards = startingCards;
    }


    public void Roll() {
        PlayerData.performRoll = true;
    }
}