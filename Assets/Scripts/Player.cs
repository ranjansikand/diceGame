// Controls the UI interaction


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] List<Dice> startingDice;

    private void Awake() {
        PlayerData.dice = startingDice;
    }


    public void Roll() {
        PlayerData.performRoll = true;
    }
}