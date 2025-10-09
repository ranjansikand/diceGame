// Handles behavior for shop game state


using System.Collections;
using UnityEngine;

public class ShopManager : Manager
{
    public ShopManager(GameManager gm): base(gm) {
        // Reset data
        gm.gameplayCanvas.SetActive(false);
        gm.shopCanvas.SetActive(true);

        gm.StartCoroutine(Routine());
    }

    protected override IEnumerator Routine() {
        yield return new WaitUntil(() => !gm.shopCanvas.activeSelf);
        gm.gameplayCanvas.SetActive(true);
        complete = true;
    }
}
