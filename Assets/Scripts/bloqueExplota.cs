using UnityEngine;

public class bloqueExplota : MonoBehaviour
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

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("bloque")){
            posicionExplosion = new Vector2(transform.position.x, transform.position.y);
            GameObject explosionBloque = Instantiate(explosion, posicionExplosion, Quaternion.identity);
            Destroy(explosionBloque, 0.5f);
        }   
    }     
}
