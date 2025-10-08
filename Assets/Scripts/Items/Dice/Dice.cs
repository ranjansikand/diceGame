// Dice rolling


using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Dice : MonoBehaviour
{
    public delegate void DiceEvent(Dice dice);
    public static DiceEvent valueCalculated, rolled;
    
    public delegate void ScoreEvent(Dice die, string message);
    public static ScoreEvent bonus, multiplier;

    private Rigidbody2D rb;

    // Check the die's local axes
    Vector3[] directions;

    // Map directions to die numbers (adjust this mapping for your model!)
    public DiceData diceData { get; private set; }
    // Order: [0]=forward, [1]=up, [2]=right, [3]=back, [4]=down, [5]=left

    public bool hasSettled { get { return rb.IsSleeping(); }}
    public int value { get; set; }

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        directions = new Vector3[] {
            transform.up,     // top
            -transform.up,    // bottom
            transform.forward,  // front
            -transform.forward, // back
            transform.right,    // right
            -transform.right    // left
        };
    }

    public void Create(DiceData diceData) {
        this.diceData = diceData;
    }

    public void RollDice() {
        // Optional: clear out current momentum so the new roll is consistent
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;

        // Add random upward + sideways force
        float forceRange = 8f;
        rb.AddForce(new Vector2(
            Random.Range(-forceRange, forceRange),
            Random.Range(-forceRange, forceRange)
        ), ForceMode2D.Impulse);

        // Add random spin
        rb.AddTorque(Random.Range(-10f, 10f));

        if (rolled != null) rolled(this);
    }

    public int CalculateValue() {
        int sideIndex = Random.Range(0, diceData.values.Length);
        value = diceData.values[sideIndex];

        if (valueCalculated != null) valueCalculated(this);
        return value;
    }

    public IEnumerator Score() {
        transform.DOScale(Vector3.one * 1.25f, 0.125f);
        yield return diceData.Score(this);
        transform.DOScale(Vector3.one, 0.05f);
    }
}
