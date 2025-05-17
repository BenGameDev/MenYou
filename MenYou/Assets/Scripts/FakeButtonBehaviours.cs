using UnityEngine;

public class FakeButtonBehaviours : MonoBehaviour
{
    public float buttonClicked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(buttonClicked >=1)
        {
            Debug.Log(buttonClicked);
        }
    }

    public void AddCount()
    {
        buttonClicked++;
    }

}
