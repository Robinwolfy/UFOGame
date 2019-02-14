using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;    
    private int count;
    public float speed;
    public Text scoreText;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        winText.text = "";
        
    }

    // FixedUpdate is called at the start of each frame (Physics)
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
            
    }

    void SetCountText()
    {
        scoreText.text = "Score: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!!!";
        }
    }

}
