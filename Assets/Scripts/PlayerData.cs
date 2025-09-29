// Holds player information


using System.Collections.Generic;

public static class PlayerData {
    // Monitored events
    public delegate void PlayerDataUpdate(int amount);
    public static PlayerDataUpdate moneyUpdated, rollsUpdated, scoreUpdated, maxRollsUpdated;

    // Variables
    private static int _money = 50;
    private static int _rolls = 3;  
    private static int _maxRolls = 3;
    private static int _score = 0;
    public static List<Dice> dice;
    public static bool performRoll = false;
    
    // Accessors and event calls
    public static int money {
        get { return _money; }
        set {
            _money = value;
            int change = value - _money;
            if (moneyUpdated != null) moneyUpdated(change);
        }
    }
    public static int rolls {
        get { return _rolls; }
        set {
            _rolls = value;
            int change = value - _rolls;
            if (rollsUpdated != null) rollsUpdated(change);
        }
    }
    public static int maxRolls {
        get { return _maxRolls; }
        set {
            _maxRolls = value;
            int change = value - _maxRolls;
            if (maxRollsUpdated != null) maxRollsUpdated(change);
        }
    }
    public static int score {
        get { return _score; }
        set {
            _score = value;
            int change = value - _score;
            if (scoreUpdated != null) scoreUpdated(change);
        }
    }
}
