using TMPro;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class UIManagerDepresionBeck : MonoBehaviour
{
    private bool respuestas;                     //Controla el poder solo seleccionar una respuesta
    public int _posicion = 0;                   //Posición del Item (número de pregunta)
    public string[] resultados;                 //Respuestas elegidas por el usuario

    public GameObject panelFinal;                //Panel que muestra el mensaje de finalizado
    public TextMeshProUGUI btn1;                 //Texto donde se pone la respuesta 1
    public TextMeshProUGUI btn2;                 //Texto donde se pone la respuesta 2
    public TextMeshProUGUI btn3;                 //Texto donde se pone la respuesta 3
    public TextMeshProUGUI btn4;                 //Texto donde se pone la respuesta 4
    public CinemachineVirtualCamera vcEncuesta;  //Camara virtual para la encuesta
    public GameObject panelUltimaPregunta;
    public Animator animatorPreguntaFinal;
    

    // Start is called before the first frame update
    void Start()
    {
        panelFinal.SetActive(false);
        respuestas = false;
        resultados = new string[Constantes.TOTAL_PREGUNTAS_DEPRESION_BECK+1];
        ConfiguracionPregunta();
    }
    
    /// <summary>
    /// Guarda los resultados de la encuesta 
    /// </summary>
    private void GuardaDatos()
    {
        Player player = new Player(DatosBasicos.getId(), DatosBasicos.getNombre(), Constantes.NOMBRE_ENCUESTA_DEPRESION_BECK);
        player.nombreTest = Constantes.NOMBRE_ENCUESTA_DEPRESION_BECK;
        SaveSystem.SavePlayer(player, resultados, CalculaResultado.Calcula(Constantes.NOMBRE_ENCUESTA_DEPRESION_BECK,resultados));
        DatosBasicos.DestruirDatos(); //Borra los datos iniciales para tener que poner la contraseña nuevamente
    }
     
    /// <summary>
    /// Elige la pregunta a mostrar y si ya se contestaron todas guarda la información y muestra el mensaje final
    /// </summary>
    private void ConfiguracionPregunta()
    {
        if (_posicion < Constantes.TOTAL_PREGUNTAS_DEPRESION_BECK)
        {
            //question.text = Constantes.QUESTIONS_ANSIEDAD_BECK_CABECERA + "\n" + Constantes.QUESTIONS_ANSIEDAD_BECK[_posicion++];
            btn1.text = Constantes.ANSWER_DEPRESION_BECK[(_posicion * 4)];
            btn2.text = Constantes.ANSWER_DEPRESION_BECK[(_posicion * 4) + 1];
            btn3.text = Constantes.ANSWER_DEPRESION_BECK[(_posicion * 4) + 2];
            btn4.text = Constantes.ANSWER_DEPRESION_BECK[(_posicion * 4) + 3];
            _posicion++;
        }
        else if (_posicion == Constantes.TOTAL_PREGUNTAS_DEPRESION_BECK)
        {
            panelUltimaPregunta.SetActive(true);
            animatorPreguntaFinal.Play("AbriendoDietaBeck");
        }
        respuestas = true;
    }
    
    /// <summary>
    /// Desactiva la interfaz de la encuesta, hace el cambio de la camara por la principal y configura la siguiente pregunta
    /// </summary>
    /// <param name="total">Número de respuesta seleccionada</param>
    public void BtnPrecionado(int total)
    {
        respuestas = false;;
        resultados[_posicion - 1] = total.ToString();
        vcEncuesta.gameObject.SetActive(false);
        Invoke("ConfiguracionPregunta",1.5f);
    }

    /// <summary>
    /// Guarda el valor asignado al botón (1)
    /// </summary>
    public void Opcion1()
    {
        if (respuestas)
        {
            BtnPrecionado(1);
        }
    }
    
    //Guarda el valor asignado al botón (2)
    public void Opcion2()
    {
        if (respuestas)
        {
            BtnPrecionado(2);
        }
    }
    
    /// <summary>
    /// Guarda el valor asignado al botón (3)
    /// </summary>
    public void Opcion3()
    {
        if (respuestas)
        {
            BtnPrecionado(3);
        }
    }
    
    /// <summary>
    /// Guarda el valor asignado al botón (4)
    /// </summary>
    public void Opcion4()
    {
        if (respuestas)
        {
            BtnPrecionado(4);
        }
    }

    public void OpcionDieta(bool dieta)
    {
        if (respuestas)
        {
            respuestas = false;
            _posicion++;
            
            if(dieta)
                resultados[_posicion - 1] = "Si se esta a dieta";
            else
                resultados[_posicion - 1] = "No esta a dieta";
            
            vcEncuesta.gameObject.SetActive(false);
            
            GuardaDatos();
            panelFinal.SetActive(true);
        }
    }

    /// <summary>
    /// Método para regresar al menú principal
    /// </summary>
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(Constantes.SCENE_MENUPRINCIPAL);
    }
}
