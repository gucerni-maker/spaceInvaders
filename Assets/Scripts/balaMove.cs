using UnityEngine;

public class balaMove : MonoBehaviour
{
    public float velocidad = 15f;
    private Rigidbody2D rb;
    public GameObject explosion;
    private Vector2 posicionExplosion;
    
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
            //generar explosion
            posicionExplosion = new Vector2(collision.transform.position.x, collision.transform.position.y);
            GameObject explosionActual = Instantiate(explosion, posicionExplosion, Quaternion.identity);
            Destroy(explosionActual, 0.5f);

            //anotar puntaje
            gameManager gm = FindFirstObjectByType<gameManager>();
            gm.AnotaPuntos();

            //destruir enemigo y bala
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
        if (collision.gameObject.CompareTag("bloque")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }        
    }    
}
