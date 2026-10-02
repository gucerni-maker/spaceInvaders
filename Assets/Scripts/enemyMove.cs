using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float velocidad;
    private float distanciaBajada = 0.5f;
    private float limiteDerecho = 2.2f;
    private float limiteIzquierdo = -2.4f;

    private int direccion = 1;

    void Update(){
        int enemigosRestantes = transform.childCount;
        velocidad = 0.5f + (21 - enemigosRestantes) * 0.2f;
    }


    void FixedUpdate()
    {
        transform.Translate(Vector2.right * direccion * velocidad * Time.fixedDeltaTime);

        if (transform.position.x >= limiteDerecho){
            direccion = -1;
            transform.Translate(Vector2.down * distanciaBajada);
        }

        if (transform.position.x <= limiteIzquierdo){
            direccion = 1;
            transform.Translate(Vector2.down * distanciaBajada);
        }
    }
   
}