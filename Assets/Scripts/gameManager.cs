using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public UIDocument uiDocument;
    private Button botonStart;
    private Label tituloText;

    void Awake() {
        tituloText = uiDocument.rootVisualElement.Q<Label>("titulo");
        botonStart = uiDocument.rootVisualElement.Q<Button>("start");
    }

    void Start(){
        botonStart.clicked += iniciarJuego;
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
    //                           CAMBIA AL SIGUIENTE NIVEL 
    //*************************************************************************
    void siguienteScene(){
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual + 1);
    }         
}
