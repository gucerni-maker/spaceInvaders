using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnManager : MonoBehaviour
{
    public GameObject enemigo1;
    public GameObject enemigo2;
    public GameObject enemigo3;

    private float[] enemigo_PosX = {-7f, -5f, -3f, -1f, 1f, 3f, 5f, 7f};
    private float[] enemigo_PosY =  {4f, 2.6f, 1f};
    
    void Start()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;

        if(escenaActual > 0){
          SpawnEnemigo();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemigo(){
        for (int a = 0; a < enemigo_PosX.Length; a++){
            Instantiate(enemigo1, new Vector2(enemigo_PosX[a], enemigo_PosY[0]), Quaternion.identity); 
            Instantiate(enemigo2, new Vector2(enemigo_PosX[a], enemigo_PosY[1]), Quaternion.identity);
            Instantiate(enemigo3, new Vector2(enemigo_PosX[a], enemigo_PosY[2]), Quaternion.identity);
        }
    }
}
