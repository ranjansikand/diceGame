// Holds player information


using System.Collections.Generic;

public static class PlayerData {
    // Monitored events
    public delegate void PlayerDataUpdate();
    public static PlayerDataUpdate moneyUpdated, rollsUpdated, maxRollsUpdated;
    public static PlayerDataUpdate scoreUpdated, pointsUpdated, multipleUpdated;
    public static PlayerDataUpdate diceUpdated;

    // Variables
    public static List<DiceData> dice;
    public static List<CardData> cards;
    public static bool performRoll = false;
    public static bool dragging = false;
    

    #region Finances
    private static int _money = 10;
    public static int money {
        get { return _money; }
        set {
            _money = value;
            int change = value - _money;
            if (moneyUpdated != null) moneyUpdated();
        }
    }

    private static int _salary = 4;
    public static int salary {
        get { return _salary; }
        set { _salary = value; }
    }
    #endregion

    #region Rolling
    private static int _rolls = 3;  
    public static int rolls {
        get { return _rolls; }
        set {
            _rolls = value;
            int change = value - _rolls;
            if (rollsUpdated != null) rollsUpdated();
        }
    }
    
    private static int _maxRolls = 3;
    public static int maxRolls {
        get { return _maxRolls; }
        set {
            _maxRolls = value;
            int change = value - _maxRolls;
            if (maxRollsUpdated != null) maxRollsUpdated();
        }
    }
    #endregion

    #region Scoring
    private static int _score = 0;
    public static int score {
        get { return _score; }
        set {
            _score = value;
            int change = value - _score;
            if (scoreUpdated != null) scoreUpdated();
        }
    }
    #endregion
}
