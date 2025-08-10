using Unity.VisualScripting;
using UnityEngine;

public class Blade : MonoBehaviour
{

    public Vector2 mousePosition;

    public Vector2 direction { get; private set; }

    public GameObject bladeTrail;

    public float trailSpeed;

    public float sliceForce = 5f;

    private void Awake()
    {
        trailSpeed = 0.3f;
        bladeTrail = this.transform.GetChild(0).gameObject;
        bladeTrail.SetActive(false);
    }
    private void FixedUpdate()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = mousePosition;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bladeTrail.SetActive(true);
            bladeTrail.GetComponent<TrailRenderer>().time = trailSpeed;
        }
        if (Input.GetMouseButtonUp(0))
        {
            bladeTrail.SetActive(false);
            bladeTrail.GetComponent <TrailRenderer>().time = 0f;
        }
    }

}
