using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameManager : MonoBehaviour
{

    public UIDocument uiDocument;
    private Button botonStart;
    private Label tituloText;
    private Label scoreText1;
    public DatosJuego DatosJuego;

    void Awake() {
        if (SceneManager.GetActiveScene().buildIndex == 0){
            tituloText = uiDocument.rootVisualElement.Q<Label>("titulo");
            botonStart = uiDocument.rootVisualElement.Q<Button>("start");
        }

        if (SceneManager.GetActiveScene().buildIndex == 1){
          scoreText1 = uiDocument.rootVisualElement.Q<Label>("puntaje");
        }
    }

    void Start(){
        if (SceneManager.GetActiveScene().buildIndex == 0){
            botonStart.clicked += iniciarJuego;
        }

        if (SceneManager.GetActiveScene().buildIndex == 1){
          scoreText1.text = DatosJuego.Instance.puntaje1.ToString();
        }
        
    }

    void Update(){
        
    }

    //*************************************************************************
    //                              INICIA JUEGO
    //*************************************************************************
        public void iniciarJuego(){
            botonStart.style.display = DisplayStyle.None;
            tituloText.style.display = DisplayStyle.None;
            siguienteScene();
        }   
        
    //*************************************************************************    
    //                         CAMBIA AL SIGUIENTE NIVEL 
    //*************************************************************************
    void siguienteScene(){
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual + 1);
    }  

    //*************************************************************************    
    //                                GAME PLAY 
    //*************************************************************************   

    public void PerderVida(){
        StartCoroutine(recargarEscena());
    }    

    IEnumerator recargarEscena(){
        yield return new WaitForSeconds(3);
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }    

    public void AnotaPuntos(){
         DatosJuego.Instance.puntaje1+=10;
         scoreText1.text = DatosJuego.Instance.puntaje1.ToString();
    }
}
