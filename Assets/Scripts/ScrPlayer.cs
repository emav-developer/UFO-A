using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// -----------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per gestionar les acciones relacionades amb la UI
/// AUTOR:  Jordi Aguilera
/// DATA:   26/10/20
/// VERSIÓ: 1.0
/// CONTROL DE VERSIONS
///         1.0: primera versió. Mostra puntuació
/// -----------------------------------------------------------------------------
/// </summary>


public class ScrPlayer : MonoBehaviour
{

    Rigidbody2D rb;
    ScrPickup scr;
    AudioSource a;




    float x, y;
    [SerializeField]
    float forsa = 5;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        a = GetComponent<AudioSource>();
        print(ScrControlGame.pickupsRestants);
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
        if (collision.tag == "pickup")
        {
            AudioSource audioP;
            audioP = collision.GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(audioP.clip, Camera.main.transform.position);

            scr = collision.GetComponent<ScrPickup>();
            ScrControlGame.punts += scr.valor;
            ScrControlGame.pickupsRestants--;
            Destroy(collision.gameObject);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        a.Play();
    }
}
