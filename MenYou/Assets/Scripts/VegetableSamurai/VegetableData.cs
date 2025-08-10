using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class VegetableData : MonoBehaviour
{

    [SerializeField]
    [Header("Force")]
    public float upVelocity;
    public float degreeVelocity;
    public Vector2 currentVelocity;

    [SerializeField]
    [Header("Points")]
    public int score;

    [SerializeField]
    [Header("Components")]
    public Rigidbody2D wholeRb;
    public Rigidbody2D[] slicedRb;
    public SpriteRenderer whole;
    public GameObject sliced;

    [SerializeField]
    [Header("Barrier")]
    public GameObject destroyBarrier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wholeRb = this.GetComponent<Rigidbody2D>();
        destroyBarrier = GameObject.FindGameObjectWithTag("Barrier");
        slicedRb = sliced.GetComponentsInChildren<Rigidbody2D>();
        sliced.SetActive(false);
        upVelocity = Random.Range(5f, 15f);
        degreeVelocity = Random.Range(-5f, 5f);
        wholeRb.angularVelocity = degreeVelocity;
        wholeRb.AddForce(new Vector2(degreeVelocity ,upVelocity), ForceMode2D.Impulse);
        currentVelocity = wholeRb.linearVelocity;
    }

    private void Slice(Vector3 direction, Vector3 position, float force)
    {
        // Disable the whole fruit
        whole.GetComponent<BoxCollider2D>().isTrigger = true;
        whole.enabled = false;

        // Enable the sliced fruit
        sliced.SetActive(true);

        // Rotate sliced sprite to match cut
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        sliced.transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Normalize blade direction
        Vector2 dirNorm = direction.normalized;

        // Get a perpendicular vector to the cut direction
        Vector2 perpendicular = new Vector2(-dirNorm.y, dirNorm.x);

        // Apply opposite perpendicular forces
        for (int i = 0; i < slicedRb.Length; i++)
        {
            Rigidbody2D slice = slicedRb[i];

            // Keep original velocity so halves fly in the arc
            slice.linearVelocity = wholeRb.linearVelocity;

            // Alternate halves: index 0 gets +perpendicular, index 1 gets -perpendicular
            Vector2 splitDir = (i % 2 == 0) ? perpendicular : -perpendicular;

            // Add perpendicular split force + small amount of forward blade force
            slice.AddForce(splitDir * force + dirNorm * (force * 0.3f), ForceMode2D.Impulse);

            // Optional: Add some spin for visual flair
            slice.AddTorque(Random.Range(-5f, 5f), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == destroyBarrier) 
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Blade")
        {
            Blade blade = collision.gameObject.GetComponentInParent<Blade>();
            Slice(blade.direction, blade.transform.position, blade.sliceForce);
            ScoreUpdate.Instance.AddScore(score);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == destroyBarrier)
        {
            Destroy(this.gameObject);
        }
    }
}
