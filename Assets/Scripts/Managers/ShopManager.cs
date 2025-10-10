// Handles behavior for shop game state


using System.Collections;
using UnityEngine;

public class ShopManager : Manager
{
    public ShopManager(GameManager gm): base(gm) {
        gm.player.SpawnDice();
        
        // Stop game mode
        gm.gameplayCanvas.SetActive(false);
        gm.vcamGame.SetActive(false);

        gm.vcamShop.SetActive(true);
        gm.shopCanvas.SetActive(true);

        gm.StartCoroutine(Routine());
    }

    protected override IEnumerator Routine() {
        yield return new WaitUntil(() => !gm.shopCanvas.activeSelf);
        complete = true;
    }
}
