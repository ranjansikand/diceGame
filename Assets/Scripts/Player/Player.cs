// Controls the UI interaction


using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

    private void OnEnable() {
        Inventory.diceUpdated += SpawnDice;
    }

    private void OnDisable() {
        Inventory.diceUpdated -= SpawnDice;
    }

    public void Roll() {
        SFX.playClick();
        PlayerData.performRoll = true;
    }

    public void SpawnDice(int x = 0) {
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

        OrganizeDice();
    }

    public static void OrganizeDice(Dice skipDice = null) {
        if (Player.dice == null || Player.dice.Count == 0)
            return;

        float spacing = 1.5f;
        int count = Player.dice.Count;
        float totalWidth = (count - 1) * spacing;
        float startX = -totalWidth / 2f;

        for (int i = 0; i < count; i++) {
            if (Player.dice[i] == skipDice) continue; // Skip the dragged die

            Vector3 targetPos = new Vector3(startX + (i * spacing), 0f, 0f);
            
            // Don't move if you don't have to
            if (Player.dice[i].transform.position == targetPos) continue; 
            Player.dice[i].transform
                .DOMove(targetPos, 0.375f)
                .SetEase(Ease.OutQuad);
            Player.dice[i].transform
                .DORotate(Vector3.zero, 0.375f)
                .SetEase(Ease.OutQuad);
        }
    }
}