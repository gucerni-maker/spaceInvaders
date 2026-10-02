using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnManager : MonoBehaviour
{
    public GameObject grupoEnemigos;
    public GameObject enemigo1;
    public GameObject enemigo2;
    public GameObject enemigo3;
    public GameObject bloque;
    public GameObject player;
    
    private float[] enemigo_PosX = {-2.5f, -0.5f, 1.5f, 3.5f, 5.5f};
    private float[] enemigo_PosY =  {4.1f, 2.7f, 1.1f};
    private float columna = -2f;
    private float fila = -3.5f;
    private float avanceFila = 0.61f;
    
    void Start()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;

        if(escenaActual > 0){
          SpawnEnemigo();
          SpawnPlayer();
          SpawnBloque();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemigo(){
        for (int a = 0; a < enemigo_PosX.Length; a++){
            Instantiate(enemigo1, new Vector2(enemigo_PosX[a], enemigo_PosY[0]), Quaternion.identity, grupoEnemigos.transform); 
            Instantiate(enemigo2, new Vector2(enemigo_PosX[a], enemigo_PosY[1]), Quaternion.identity, grupoEnemigos.transform);
            Instantiate(enemigo3, new Vector2(enemigo_PosX[a], enemigo_PosY[2]), Quaternion.identity, grupoEnemigos.transform);
        }
    }

    void SpawnBloque(){
        for (int b = 0; b < 3; b++){
            for(int c = 0; c < 5; c++){
                Instantiate(bloque, new Vector2(fila, columna), Quaternion.identity);  
                fila += avanceFila;
            }
            fila = 4f;
            for(int e = 0; e < 5; e++){
                Instantiate(bloque, new Vector2(fila, columna), Quaternion.identity);  
                fila += avanceFila;
            }            
            fila = -3.5f;            
            columna -= avanceFila;    
        }  
    }

    void SpawnPlayer(){
        Instantiate(player, new Vector2(1.5f, -4.2f), Quaternion.identity); 
    }    
}
