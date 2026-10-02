using UnityEngine;


public class balaEnemiga : MonoBehaviour
{
    public GameObject explosion;
    private float velocidad = 5f;
    private Rigidbody2D rb;
    private Vector2 posicionExplosion;
    public GameObject explosionPlayer;
    private Vector2 posicionExplosionPlayer;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = -transform.up * velocidad;        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -6f){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("player")){
            gameManager gm = FindFirstObjectByType<gameManager>(); 
            gm.PerderVida();
            posicionExplosionPlayer = new Vector2(transform.position.x, transform.position.y - 1f);
            GameObject explosionActualPlayer = Instantiate(explosionPlayer, posicionExplosionPlayer, Quaternion.identity);
            Destroy(explosionActualPlayer, 0.5f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag("bloque")){
            posicionExplosion = new Vector2(transform.position.x, transform.position.y -0.49f);
            GameObject explosionActual = Instantiate(explosion, posicionExplosion, Quaternion.identity);
            Destroy(explosionActual, 0.5f);            
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }    
}
