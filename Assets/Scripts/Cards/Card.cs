// Card that can be collected
// Impacts scoring


using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public string Name;
    [TextArea] public string Description;

    public virtual void BeforeScoringEffect() {}
    public virtual void AfterScoringEffect() {}
}
