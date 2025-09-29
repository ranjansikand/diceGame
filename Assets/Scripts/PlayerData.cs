// Holds player information


using System.Collections.Generic;

public static class PlayerData {
    // Monitored events
    public delegate void PlayerDataUpdate(int amount);
    public static PlayerDataUpdate moneyUpdated, rollsUpdated, maxRollsUpdated;
    public static PlayerDataUpdate scoreUpdated, pointsUpdated, multipleUpdated;

    // Variables
    public static List<Dice> dice;
    public static bool performRoll = false;
    

    #region Finances
    private static int _money = 0;
    public static int money {
        get { return _money; }
        set {
            _money = value;
            int change = value - _money;
            if (moneyUpdated != null) moneyUpdated(change);
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
            if (rollsUpdated != null) rollsUpdated(change);
        }
    }
    
    private static int _maxRolls = 3;
    public static int maxRolls {
        get { return _maxRolls; }
        set {
            _maxRolls = value;
            int change = value - _maxRolls;
            if (maxRollsUpdated != null) maxRollsUpdated(change);
        }
    }
    #endregion

    #region Scoring
    private static int _pointValue = 0;
    public static int pointValue {
        get { return _pointValue; }
        set {
            _pointValue = value;
            if (pointsUpdated != null) pointsUpdated(0);
        }
    }

    private static int _multiplier = 1;
    public static int multiplier {
        get { return _multiplier; }
        set {
            _multiplier = value;
            if (multipleUpdated != null) multipleUpdated(0);
        }
    }
    
    private static int _score = 0;
    public static int score {
        get { return _score; }
        set {
            _score = value;
            int change = value - _score;
            if (scoreUpdated != null) scoreUpdated(change);
        }
    }
    #endregion
}
