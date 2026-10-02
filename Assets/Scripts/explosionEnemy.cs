using UnityEngine;

public class explosionEnemy : MonoBehaviour
{
    public GameObject explosion;
    private Vector2 posicionExplosion;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //hace que el bloque explote al chocar con la bala
    void OnCollisionEnter2D(Collision2D collision){
       /* if (collision.gameObject.CompareTag("bala")){
            posicionExplosion = new Vector2(transform.position.x, transform.position.y);
            GameObject explosionActual = Instantiate(explosion, posicionExplosion, Quaternion.identity);
            Destroy(explosionActual, 0.5f);
        }   */
        if (collision.gameObject.CompareTag("enemigo")){
            /*posicionExplosion = new Vector2(transform.position.x, transform.position.y);
            GameObject explosionActual = Instantiate(explosion, posicionExplosion, Quaternion.identity);
            Destroy(explosionActual, 0.5f);
            Destroy(gameObject);*/
           // Debug.Log("Choca");
        }                 
    } 
       
}
