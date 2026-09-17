using UnityEngine;

public class enemyMove : MonoBehaviour
{
    private float velocidad = 0.5f;
    private float distanciaBajada = 0.5f;

    private float limiteDerecho = 2f;
    private float limiteIzquierdo = -1f;

    private int direccion = 1;

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