// Dice rolling


using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using DG.Tweening;

public class Dice : MonoBehaviour,
    IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public delegate void DiceEvent(Dice dice);
    public static DiceEvent valueCalculated, rolled;
    
    public delegate void ScoreEvent(Dice die, string message);
    public static ScoreEvent bonus, multiplier;

    private Rigidbody2D rb;
    private BoxCollider2D bc;
    [SerializeField] SpriteRenderer pip;
    [SerializeField] SpriteRenderer sr;
    private Transform die;
    private SortingGroup sg;

    public DiceData diceData { get; private set; }
    [SerializeField] DiePips diePips;

    public bool hasSettled { get { return rb.IsSleeping(); }}
    public int value { get; set; }
    private Vector2 originalPosition;
    Vector3 lastPos;
    Vector3 dragVelocity;

    // Random information
    public int timesRolled { get; private set; } = 0;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        die = transform.GetChild(0);
        sg = GetComponent<SortingGroup>();
    }

    public void Create(DiceData diceData) {
        this.diceData = diceData;

        pip.sprite = diePips.sprites[
            diceData.values[Random.Range(0, diceData.values.Length)]
        ];

        sr.color = diceData.color;
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
        StartCoroutine(ShuffleNumbers());
    }

    public int CalculateValue() {
        StopAllCoroutines();

        int sideIndex = Random.Range(0, diceData.values.Length);
        value = diceData.values[sideIndex];
        pip.sprite = diePips.sprites[value];

        return value;
    }

    public IEnumerator Score() {
        transform.DOScale(Vector3.one * 1.25f, 0.125f);
        if (valueCalculated != null) valueCalculated(this);

        yield return diceData.Score(this);
        transform.DOScale(Vector3.one, 0.05f);
    }

    IEnumerator ShuffleNumbers() {
        while (!rb.IsSleeping()) {
            pip.sprite = diePips.sprites[
                diceData.values[Random.Range(0, diceData.values.Length)]
            ];
            yield return Data.quarterSecond;
        }
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

    public void OnPointerEnter(PointerEventData data) {
        if (PlayerData.dragging) return;
        
        SFX.playHover();
        transform.DOScale(Vector3.one * 1.1f, 0.125f);
        Tooltip.instance.Show(diceData.Name, diceData.Description, data.position);
    }

    public void OnPointerExit(PointerEventData data) {
        transform.DOScale(Vector3.one, 0.125f);
        Tooltip.instance.Hide();
    }

    public void OnBeginDrag(PointerEventData data) {
        originalPosition = transform.position;
        lastPos = transform.position;
        bc.enabled = false;
        sg.sortingOrder = 1;
        PlayerData.dragging = true;
    }

    public void OnDrag(PointerEventData data) {
        Vector2 pos = Camera.main.ScreenToWorldPoint(data.position);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);

        // --- Add subtle visual movement ---
        dragVelocity = (transform.position - lastPos) / Time.deltaTime;
        lastPos = transform.position;

        // Move the visual slightly in drag direction
        Vector3 offset = dragVelocity.normalized * 0.25f;
        offset.z = 0;

        // Smoothly lerp localPosition to offset
        die.transform.localPosition = Vector3.Lerp(
            die.transform.localPosition,
            offset,
            Time.deltaTime * 8f // smoothing speed
        );

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
        sg.sortingOrder = 0;
        PlayerData.dragging = false;

        die.transform.DOLocalMove(Vector3.zero, 0.1f);
        
    }
    #endregion
}
