// Dice rolling


using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Dice : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public delegate void DiceEvent(Dice dice);
    public static DiceEvent valueCalculated, rolled;
    
    public delegate void ScoreEvent(Dice die, string message);
    public static ScoreEvent bonus, multiplier;

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    public DiceData diceData { get; private set; }

    public bool hasSettled { get { return rb.IsSleeping(); }}
    public int value { get; set; }
    private Vector2 originalPosition;

    // Random information
    public int timesRolled { get; private set; } = 0;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    public void Create(DiceData diceData) {
        this.diceData = diceData;
    }

    #region Rolling
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

        timesRolled++;
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
    #endregion

    #region Manipulation
    bool InMovementRange() {
        if (Mathf.Abs(transform.position.x - originalPosition.x) > 1.5f &&
            Mathf.Abs(transform.position.y) < 1.5f)
        {
            return true;
        }

        return false;
    }


    public void OnBeginDrag(PointerEventData data) {
        originalPosition = transform.position;
        bc.enabled = false;
    }

    public void OnDrag(PointerEventData data) {
        Vector2 pos = Camera.main.ScreenToWorldPoint(data.position);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);

        if (InMovementRange()) {
            int currentIndex = Player.dice.IndexOf(this);
            int targetIndex = currentIndex;

            if (transform.position.x > originalPosition.x) {
                // Swap right
                targetIndex = Mathf.Min(currentIndex + 1, Player.dice.Count - 1);
            } else {
                // Swap left
                targetIndex = Mathf.Max(currentIndex - 1, 0);
            }

            if (targetIndex != currentIndex) {
                // Swap positions in the list
                Dice temp = Player.dice[targetIndex];
                Player.dice[targetIndex] = this;
                Player.dice[currentIndex] = temp;

                // Update the original position reference
                originalPosition = temp.transform.position;

                // Reorganize all dice except the one being dragged
                Player.OrganizeDice(this);
            }
        }
    }

    public void OnEndDrag(PointerEventData data) {
        Player.OrganizeDice();
        bc.enabled = true;
    }
    #endregion
}
