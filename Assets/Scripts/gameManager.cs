using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameManager : MonoBehaviour
{

    public UIDocument uiDocument;
    private Button botonStart, botonRestart, botonFinal;
    private Label tituloText;
    private Label scoreText1, vidasRestantes;

    public DatosJuego DatosJuego;

    void Awake() {
        if (SceneManager.GetActiveScene().buildIndex == 0){
            tituloText = uiDocument.rootVisualElement.Q<Label>("titulo");
            botonStart = uiDocument.rootVisualElement.Q<Button>("start");
        }

        if (SceneManager.GetActiveScene().buildIndex == 1){
          scoreText1 = uiDocument.rootVisualElement.Q<Label>("puntaje");
          vidasRestantes = uiDocument.rootVisualElement.Q<Label>("vidas");
        }

        if (SceneManager.GetActiveScene().buildIndex == 2){
            botonRestart = uiDocument.rootVisualElement.Q<Button>("restart");
        }

        if (SceneManager.GetActiveScene().buildIndex == 3){
            botonFinal = uiDocument.rootVisualElement.Q<Button>("youwin");
        }        
        
    }

    void Start(){
        if (SceneManager.GetActiveScene().buildIndex == 0){
            botonStart.clicked += iniciarJuego;
        }

        if (SceneManager.GetActiveScene().buildIndex == 1){
          scoreText1.text = DatosJuego.Instance.puntaje1.ToString();
          vidasRestantes.text =  DatosJuego.Instance.vidas.ToString();
        }

        if (SceneManager.GetActiveScene().buildIndex == 2){
            botonRestart.clicked += reiniciarJuego;
        }

        if (SceneManager.GetActiveScene().buildIndex == 3){
            botonFinal.clicked += restartJuego;
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
        DatosJuego.Instance.vidas--;
       
        //Si hay vidas restantes, se reinicia la escena
        if(DatosJuego.Instance.vidas >= 0){
            vidasRestantes.text =  DatosJuego.Instance.vidas.ToString();
            StartCoroutine(recargarEscena());
        }
        //de lo contrario se muestra la pantalla de gameover
        else{
            StartCoroutine(finDelJuego());
        }
    }   
    
    IEnumerator recargarEscena(){
        yield return new WaitForSeconds(3);
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }    

    public void AnotaPuntos(){
        DatosJuego.Instance.puntaje1+=10;
        scoreText1.text = DatosJuego.Instance.puntaje1.ToString();
        
        //al eliminar un enemigo contamos cuantos quedan
        cuentaEnemigos();
    }

    //luego de perder todas las vidas
    public void reiniciarJuego(){
        botonRestart.style.display = DisplayStyle.None;
        SceneManager.LoadScene(0);
    } 

    //contar enemigos restantes y si no queda ninguno, pasamos de escena
    public void cuentaEnemigos(){
        int cantidadEnemigos = GameObject.FindGameObjectsWithTag("enemigo").Length;

        Debug.Log(cantidadEnemigos);
        if (cantidadEnemigos == 1){
            StartCoroutine(Victoria());
        }
    }

    //luego de eliminar a todos los enemigos
    public void restartJuego(){
        botonFinal.style.display = DisplayStyle.None;
        SceneManager.LoadScene(0);
    }     

    //al perder todas las vidas cargamos la escena de game over
    IEnumerator finDelJuego(){
        yield return new WaitForSeconds(3);
        siguienteScene();
    }

    //al elinimar a todos los enemigos cargamos la escena de victoria
    IEnumerator Victoria(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }      
}
