using UnityEngine;

public class balaMove : MonoBehaviour
{
    public float velocidad = 15f;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * velocidad;        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 6f){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("enemigo")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("bloque")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }        
    }    
}
