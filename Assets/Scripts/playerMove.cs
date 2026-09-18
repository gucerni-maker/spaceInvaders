using UnityEngine;
using UnityEngine.InputSystem;//nuevo sistema para mover objetos

public class playerMove : MonoBehaviour
{
    //Para mover la nave
    public float velocidad = 5f;
    public GameObject balaPrefab;
    private Vector2 posicionBala; 
    private Rigidbody2D rb;
    private float movimiento;


    void Awake(){
        //Para mover la nave
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }
    
    void Update(){
        moverNave();
        disparar();
    }

    void FixedUpdate(){
        //Para mover la nave
        Vector2 nuevaPosicion = rb.position + Vector2.right * movimiento * velocidad * Time.fixedDeltaTime;
        rb.MovePosition(nuevaPosicion);
    }

    //Para mover la nave
    void moverNave(){
        movimiento = 0f;
        if (Keyboard.current.leftArrowKey.isPressed && transform.position.x > -8.2f)
            movimiento = -1f;

        if (Keyboard.current.rightArrowKey.isPressed && transform.position.x < 8.2f)
            movimiento = 1f;
    }

    //Disparar
    void disparar(){
        posicionBala = new Vector2(transform.position.x, transform.position.y + 1f);
        if (Keyboard.current.upArrowKey.wasPressedThisFrame){
            Instantiate(balaPrefab, posicionBala, Quaternion.identity);
        }
    }
}
