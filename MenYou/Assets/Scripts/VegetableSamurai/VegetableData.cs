using Unity.VisualScripting;
using UnityEngine;

public class VegetableData : MonoBehaviour
{

    [SerializeField]
    [Header("Force")]
    public float upVelocity;
    public float degreeVelocity;

    [SerializeField]
    [Header("Points")]
    public int score;

    [SerializeField]
    [Header("Components")]
    public Rigidbody2D rb;
    public SpriteRenderer whole;
    public GameObject sliced;

    [SerializeField]
    [Header("Barrier")]
    public GameObject destroyBarrier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        destroyBarrier = GameObject.FindGameObjectWithTag("Barrier");

        sliced.SetActive(false);
        upVelocity = Random.Range(5f, 15f);
        degreeVelocity = Random.Range(-5f, 5f);
        rb.angularVelocity = degreeVelocity;
        rb.AddForce(new Vector2(degreeVelocity ,upVelocity), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == destroyBarrier) 
        {
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "Blade")
        {
            whole.enabled = false;
            sliced.SetActive(true);
        }
    }
}
