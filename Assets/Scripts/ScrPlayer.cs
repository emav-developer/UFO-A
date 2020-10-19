using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPlayer : MonoBehaviour
{

    Rigidbody2D rb;
    float x, y;
    [SerializeField]
    float forsa = 5;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(x * forsa, y * forsa));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        if (collision.tag == "pickup")
        {
            Destroy(collision.gameObject);
            ScrControlGame.punts += 5;
            print(ScrControlGame.punts);
        }
    }
}
