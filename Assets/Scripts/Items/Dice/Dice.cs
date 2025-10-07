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

    private Rigidbody rb;

    // Check the die's local axes
    Vector3[] directions;

    // Map directions to die numbers (adjust this mapping for your model!)
    public DiceData diceData { get; private set; }
    // Order: [0]=forward, [1]=up, [2]=right, [3]=back, [4]=down, [5]=left

    public bool hasSettled { get { return rb.IsSleeping(); }}
    public int value { get; set; }

    void Awake() {
        rb = GetComponent<Rigidbody>();
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
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Add random upward + sideways force
        rb.AddForce(new Vector3(
            Random.Range(-2f, 2f),
            Random.Range(5f, 10f),
            Random.Range(-2f, 2f)
        ), ForceMode.Impulse);

        // Add random spin
        rb.AddTorque(
            Random.Range(-10f, 10f),
            Random.Range(-10f, 10f),
            Random.Range(-10f, 10f),
            ForceMode.Impulse
        );

        if (rolled != null) rolled(this);
    }

    public int CalculateValue() {
        Vector3[] vectors = { transform.forward, transform.up, transform.right };
        float max = -1f;
        int sideIndex = 0;

        for (int i = 0; i < vectors.Length; i++) {
            float dot = Vector3.Dot(vectors[i], Vector3.up);

            if (Mathf.Abs(dot) >= max) {
                max = Mathf.Abs(dot);
                // if dot is negative, it’s the opposite side → i+3
                sideIndex = dot < 0 ? i + 3 : i;
            }
        }

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
