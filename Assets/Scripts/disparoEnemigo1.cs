using UnityEngine;
using System.Collections;

public class disparoEnemigo1 : MonoBehaviour
{
    //private Vector2 posicionBala;
    public GameObject balaPrefab;
    private float tiempoDisparo;
    private Vector2 posicionBala;
    
    
    void Start(){
        tiempoDisparo = Random.Range(0f, 5f);
    }

    void Update(){
        tiempoDisparo -= Time.deltaTime;

        if (tiempoDisparo <= 0f){
            Disparar();
            tiempoDisparo = Random.Range(3f, 5f);
        }
    }

    void Disparar() {
        posicionBala = new Vector2(transform.position.x, transform.position.y - 1f);
        Instantiate(balaPrefab,posicionBala,Quaternion.identity);
    }
}
