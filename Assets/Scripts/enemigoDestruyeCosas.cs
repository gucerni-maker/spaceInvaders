using UnityEngine;

public class enemigoDestruyeCosas : MonoBehaviour
{
    public GameObject explosionBloque;
    private Vector2 posicionExplosion;
    public GameObject explosionPlayer;
    private Vector2 posicionExplosionPlayer;    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("bloque")){
            posicionExplosion = new Vector2(collision.transform.position.x, collision.transform.position.y);
            GameObject explosionActual = Instantiate(explosionBloque, posicionExplosion, Quaternion.identity);
            Destroy(explosionActual, 0.5f);            
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("player")){
            gameManager gm = FindFirstObjectByType<gameManager>();
            posicionExplosionPlayer = new Vector2(collision.transform.position.x, collision.transform.position.y);
            GameObject explosionActualPlayer = Instantiate(explosionPlayer, posicionExplosionPlayer, Quaternion.identity);
            gm.PerderVida();
            Destroy(explosionActualPlayer, 0.5f);            
            Destroy(collision.gameObject);
        }          
    }    

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("lineaInferior")){
            gameManager gm = FindFirstObjectByType<gameManager>(); 
            gm.PerderVida();
        }
    } 

}
