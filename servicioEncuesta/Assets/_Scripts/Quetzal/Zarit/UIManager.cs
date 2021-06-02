using TMPro;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    
    private bool respuestas;                     //Controla el poder solo seleccionar una respuesta
    private int _posicion = 0;                   //Posición del Item (número de pregunta)
    private string[] resultados;                 //Respuestas elegidas por el usuario

    public GameObject panelFinal;                //Panel que muestra el mensaje de finalizado
    public TextMeshProUGUI btn1;                 //Texto donde se pone la respuesta 1
    public TextMeshProUGUI btn2;                 //Texto donde se pone la respuesta 2
    public TextMeshProUGUI btn3;                 //Texto donde se pone la respuesta 3
    public TextMeshProUGUI btn4;                 //Texto donde se pone la respuesta 4
    public TextMeshProUGUI btn5;                 //Texto donde se pone la respuesta 5
    public TextMeshProUGUI question;             //Texto donde se pone la pregunta
    public CinemachineVirtualCamera vcEncuesta;  //Camara virtual para la encuesta
    

    // Start is called before the first frame update
    void Start()
    {
        panelFinal.SetActive(false);
        respuestas = false;
        resultados = new string[Constantes.TOTAL_PREGUNTAS_ZARIT];
        ConfiguracionPregunta();
        ConfiguraBotones();
    }
    
    /// <summary>
    /// Guarda los resultados de la encuesta 
    /// </summary>
    private void GuardaDatos()
    {
        Player player = new Player(DatosBasicos.getId(), DatosBasicos.getNombre(), Constantes.NOMBRE_ENCUESTA_ZARIT);
        player.nombreTest = Constantes.NOMBRE_ENCUESTA_ZARIT;
        SaveSystem.SavePlayer(player, resultados, CalculaResultado.Calcula(Constantes.NOMBRE_ENCUESTA_ZARIT,resultados));
        DatosBasicos.DestruirDatos(); //Borra los datos iniciales para tener que poner la contraseña nuevamente
    }
     
    /// <summary>
    /// Elige la pregunta a mostrar y si ya se contestaron todas guarda la información y muestra el mensaje final
    /// </summary>
    private void ConfiguracionPregunta()
    {
        if (_posicion < Constantes.TOTAL_PREGUNTAS_ZARIT)
        {
            question.text = Constantes.QUESTIONS_ZARIT[_posicion++];
        }
        else if (_posicion == Constantes.TOTAL_PREGUNTAS_ZARIT)
        {
            GuardaDatos();
            panelFinal.SetActive(true);
        }
        respuestas = true;
    }

    /// <summary>
    /// Asigna el texto a cada botón de respuestas
    /// </summary>
    private void ConfiguraBotones()
    {
        btn1.text = Constantes.ANSWER_1_ZARIT;
        btn2.text = Constantes.ANSWER_2_ZARIT;
        btn3.text = Constantes.ANSWER_3_ZARIT;
        btn4.text = Constantes.ANSWER_4_ZARIT;
        btn5.text = Constantes.ANSWER_5_ZARIT;
    }
    
    /// <summary>
    /// Desactiva la interfaz de la encuesta, hace el cambio de la camara por la principal y configura la siguiente pregunta
    /// </summary>
    /// <param name="total">Número de respuesta seleccionada</param>
    public void BtnPrecionado(int total)
    {
        respuestas = false;
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
    
    /// <summary>
    /// Guarda el valor asignado al botón (5)
    /// </summary>
    public void Opcion5()
    {
        if (respuestas)
        {
            BtnPrecionado(5);
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

