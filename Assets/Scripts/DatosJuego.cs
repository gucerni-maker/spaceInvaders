using UnityEngine;

public class DatosJuego : MonoBehaviour
{
    public static DatosJuego Instance;
    public int puntaje1 = 0;
    public int vidas = 3;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
