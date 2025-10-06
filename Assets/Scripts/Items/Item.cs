// Item that can be obtained and bought


using UnityEngine;

public class Item : ScriptableObject {
    public string Name;
    public virtual Type type { get { return Type.Dice; }}
}

public enum Type {
    Dice, Card
}

