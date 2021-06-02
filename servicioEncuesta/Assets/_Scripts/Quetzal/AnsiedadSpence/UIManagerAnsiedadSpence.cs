using TMPro;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerAnsiedadSpence : MonoBehaviour
{
    private bool respuestas;                     //Controla el poder solo seleccionar una respuesta
    public int _posicion = 0;                   //Posición del Item (número de pregunta)
    public string[] resultados;                 //Respuestas elegidas por el usuario

    public GameObject panelFinal;                //Panel que muestra el mensaje de finalizado
    public TextMeshProUGUI btn1;                 //Texto donde se pone la respuesta 1
    public TextMeshProUGUI btn2;                 //Texto donde se pone la respuesta 2
    public TextMeshProUGUI btn3;                 //Texto donde se pone la respuesta 3
    public TextMeshProUGUI btn4;                 //Texto donde se pone la respuesta 4
    public TextMeshProUGUI question;             //Texto donde se pone la pregunta
    public CinemachineVirtualCamera vcEncuesta;  //Camara virtual para la encuesta
    public GameObject panelPreguntaFinal;
    public Animator animatorFinal;
    public InputField miedo;
    public bool ultima;

    // Start is called before the first frame update
    void Start()
    {
        ultima = false;
        panelPreguntaFinal.SetActive(false);
        panelFinal.SetActive(false);
        respuestas = false;
        /*Se guardan 2 respuestas
         1.- Miedo a otra cosa?
         2.- Que cosa te da miedo?
         */
        resultados = new string[Constantes.TOTAL_PREGUNTAS_ANSIEDAD_SPENCE+2];
        ConfiguracionPregunta();
        ConfiguraBotones();
    }
    
    /// <summary>
    /// Guarda los resultados de la encuesta 
    /// </summary>
    private void GuardaDatos()
    {
        Player player = new Player(DatosBasicos.getId(), DatosBasicos.getNombre(), Constantes.NOMBRE_ENCUESTA_SPENCE);
        player.nombreTest = Constantes.NOMBRE_ENCUESTA_SPENCE;
        SaveSystem.SavePlayer(player, resultados, CalculaResultado.Calcula(Constantes.NOMBRE_ENCUESTA_SPENCE,resultados));
        DatosBasicos.DestruirDatos(); //Borra los datos iniciales para tener que poner la contraseña nuevamente
    }

    /// <summary>
    /// Elige la pregunta a mostrar y si ya se contestaron todas guarda la información y muestra el mensaje final
    /// </summary>
    private void ConfiguracionPregunta()
    {
        if (_posicion < Constantes.TOTAL_PREGUNTAS_ANSIEDAD_SPENCE)
        {
            if (_posicion < Constantes.TOTAL_PREGUNTAS_ANSIEDAD_SPENCE - 1) //Preguntas de 0 al 43
            {
                question.text = Constantes.QUESTIONS_ANSIEDAD_SPENCE[_posicion++];
            }
            else //última pregunta 44
            {
                if (!ultima)
                {
                    ultima = true;
                    _posicion++;
                    panelPreguntaFinal.SetActive(true);
                }
            }
        }
        else
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
        btn1.text = Constantes.ANSWER_1_ANSIEDAD_SPENCE;
        btn2.text = Constantes.ANSWER_2_ANSIEDAD_SPENCE;
        btn3.text = Constantes.ANSWER_3_ANSIEDAD_SPENCE;
        btn4.text = Constantes.ANSWER_4_ANSIEDAD_SPENCE;
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

    public void OpcionFinal(bool valor)
    {
        if (respuestas)
        {
            respuestas = false;
            
            if(valor)
            {
                resultados[_posicion - 1] = "Si";
                animatorFinal.Play("DesaparecerSiNoSpence");
            }else
            {
                resultados[_posicion - 1] = "No";
                ConfiguracionPregunta();
            }
            
        }
    }

    public void MiedoFinal()
    {
        if (miedo.text.Length > 1)
        {
            _posicion++;
            resultados[_posicion - 1] = miedo.text;
            animatorFinal.Play("CerrarSpence");
            Invoke("DesactivaPanel",1);
            
        }
    }

    private void DesactivaPanel()
    {
        panelPreguntaFinal.SetActive(false);
        respuestas = true;
        _posicion++;
    }

    /// <summary>
    /// Método para regresar al menú principal
    /// </summary>
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(Constantes.SCENE_MENUPRINCIPAL);
    }
}
