using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Payroll {
    public static void Payout() {
        int interest = PlayerData.money / 5;
        PlayerData.money += (PlayerData.salary + interest + PlayerData.rolls);
    }
}
