using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PlayerController : MonoBehaviour
{ 
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObjects;

    private Rigidbody rb;
    private int count;
  
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        
        SetCountText ();
        winTextObjects.SetActive(false);
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            SetCountText ();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
        other.gameObject.SetActive(false);
        count = count - 1;
        SetCountText();
        }

        if (count == 12) 
        {
        transform.position = new Vector3(0f, 30.2f, 0.0f); 
        }
    }
    void SetCountText ()
    {
        countText.text = "Count:" + count.ToString ();

        if(count >= 20)
        {
            winTextObjects.SetActive(true);
        }
}
}
