using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultadosManager : MonoBehaviour
{
    private PlayerData[] _playerData; //Estructura con datos para llenar los arreglos

    public TextMeshProUGUI tmpId;             //Texto superior derecho con el id
    public TextMeshProUGUI tmpNombre;         //Texto superior derecho con el nombre
    public TextMeshProUGUI tmpEncuesta;       //Texto superior derecho con el tipo de encuesta
    public TextMeshProUGUI tmpResultado;      //Texto superior derecho con el resultado de la encuesta
    public RectTransform transformEncuesta;   //Panel de Encuestas
    public RectTransform transformRespuestas; //Panel de Resultados

    public GameObject encuestaPrefab;         //Referencia al prefab de los datos básicos 
    public GameObject resultadoPrefab;        //Referencia al prefab de los resultados
    
    private void Start()
    {
        if (SaveSystem.LoadControl() > 0)
        {
            CargaEncuestas();
            AgregaElementosEncuesta(SaveSystem.LoadControl());
            AgregaElementosRespuestas(_playerData[0].resultados.Length);
            CargaRespuestasIniciales(_playerData[0]);
        }else
        {
            SinDatos();
        }
    }

    /// <summary>
    /// Cálculo de los datos básicos para agregar resultados de una encuesta
    /// </summary>
    /// <param name="data">Datos del usuario</param>
    private void CargaRespuestasIniciales(PlayerData data)
    {
        float altura = data.resultados.Length * Constantes.TAMANIO_RESULTADO;
        float porcentaje = (Constantes.TAMANIO_RESULTADO * 100) / altura;
        float final = porcentaje / 100;
        for (int i = 0; i < data.resultados.Length; i++)
        {
            AgregaElementoRespuesta(data.nombreTest, i, data.resultados[i], final);
        }
    }

    /// <summary>
    /// Método para cargar datos de alguna encuesta diferente a la actual 
    /// </summary>
    /// <param name="pos">Número de la encuesta a cargar</param>
    public void CargaRespuestasSeleccion(int pos)
    {
        LimpiaResultadosAnteriores();
        AgregaElementosRespuestas(_playerData[pos].resultados.Length);
        CargaRespuestasIniciales(_playerData[pos]);
        tmpId.text = Constantes.MENSAJE_TITULO_ID + _playerData[pos].idPaciente;
        tmpNombre.text = Constantes.MENSAJE_TITULO_NOMBRE + _playerData[pos].nombrePaciente;
        tmpEncuesta.text = Constantes.MENSAJE_TITULO_ENCUESTA + _playerData[pos].nombreTest;
        tmpResultado.text = Constantes.MENSAJE_TITULO_RESULTADO + (CalculaResultado.Calcula(_playerData[pos].nombreTest, _playerData[pos].resultados).Substring(10) );
    }

    /// <summary>
    /// Agrega los prefab de las respuestas necesarios con una configuración básica
    /// </summary>
    /// <param name="total">Total de respuestas a agregar</param>
    private void AgregaElementosRespuestas(int total)
    {
        float altura = total * Constantes.TAMANIO_RESULTADO;
        transformRespuestas.anchorMin = new Vector2(0, 1);
        transformRespuestas.anchorMax = new Vector2(1, 1);
        transformRespuestas.offsetMin = new Vector2(0, 0);
        transformRespuestas.offsetMax = new Vector2(0, 0);
        transformRespuestas.offsetMin = new Vector2(0, -altura);
    }

    /// <summary>
    /// Agrega los prefab de las encuestas necesarios con una configuración básica
    /// </summary>
    /// <param name="total">Total de encuesas a agregar</param>
    private void AgregaElementosEncuesta(int total)
    {
        float altura = total * Constantes.TAMANIO_ENCUESTA;
        transformEncuesta.anchorMin = new Vector2(0, 1);
        transformEncuesta.anchorMax = new Vector2(1, 1);
        transformEncuesta.offsetMin = new Vector2(0, 0);
        transformEncuesta.offsetMax = new Vector2(0, 0);
        transformEncuesta.offsetMin = new Vector2(0, -altura);
    }

    /// <summary>
    /// Hace la configuración personalizada de cada uno de las respuestas
    /// </summary>
    /// <param name="pos">Número de respuesta cargada</param>
    /// <param name="playerData">Datos a ingresar</param>
    /// <param name="porcentaje">Total de espacio disponible para ser usado</param>
    public void AgregaElementoRespuesta(string encuesta, int pos, string playerData, float porcentaje)
    {
        GameObject respuestaHijo = Instantiate(resultadoPrefab); //instancia del prefab
        respuestaHijo.transform.SetParent(transformRespuestas.transform);
        respuestaHijo.name = Constantes.PREFAB_RESPUESTA + pos;
        RectTransform transformResultado = respuestaHijo.GetComponent<RectTransform>();
        
        float min = 1 - porcentaje * (pos+1);
        float max = 1 - porcentaje * pos;
        
        transformResultado.offsetMin = new Vector2(0, 0);
        transformResultado.offsetMax = new Vector2(0, 0);
        transformResultado.localScale = new Vector3(1, 1, 1);
        transformResultado.anchorMin = new Vector2(0f, min);
        transformResultado.anchorMax = new Vector2(1f, max);

        respuestaHijo.GetComponent<Resultados>().CargaDatos(encuesta,pos+1,playerData);
        
    }

    /// <summary>
    /// Hace la configuración personalizada de cada una de las encuestas
    /// </summary>
    /// <param name="id">Número de encuesta cargada</param>
    /// <param name="nombrePaciente">Nombre del paciente</param>
    /// <param name="idPaciente">Id del paciente</param>
    /// <param name="porcentaje">Total de espacio disponible para ser usado</param>
    public void AgregaElementoEncuesta(int id, string nombrePaciente, string idPaciente, float porcentaje)
    {
        GameObject encuestaHijo = Instantiate(encuestaPrefab) as GameObject; //instancia del prefab
        encuestaHijo.transform.SetParent(transformEncuesta.transform);
        encuestaHijo.name = Constantes.PREFAB_ENCUESTA + id;
        RectTransform transformResultado = encuestaHijo.GetComponent<RectTransform>();
        
        float min = 1 - porcentaje * (id+1);
        float max = 1 - porcentaje * id;
        
        transformResultado.offsetMin = new Vector2(0, 0);
        transformResultado.offsetMax = new Vector2(0, 0);
        transformResultado.localScale = new Vector3(1, 1, 1);
        transformResultado.anchorMin = new Vector2(0f, min);
        transformResultado.anchorMax = new Vector2(1f, max);
        
        encuestaHijo.GetComponent<Encuestas>().CargaDatos(id+1,nombrePaciente,idPaciente);
        encuestaHijo.GetComponent<Encuestas>().CargaDatos(_playerData[id]);
    }

    /// <summary>
    /// Elimina resultados cargados anteriormente para agregar nuevos
    /// </summary>
    public void LimpiaResultadosAnteriores()
    {
        GameObject[] resultadosAntiguos = GameObject.FindGameObjectsWithTag(Constantes.PREFAB_ENCUESTA_NOMBRE);
        GameObject resultadoEncontrado;
        int totalResultados = resultadosAntiguos.Length;

        if (totalResultados > 0)
        {
            for (int i = 0; i <= totalResultados; i++)
            {
                resultadoEncontrado = GameObject.Find(Constantes.PREFAB_RESPUESTA + (totalResultados - i));
                if (resultadoEncontrado != null)
                {
                    Destroy(resultadoEncontrado);
                }
            }
        }

    }

    /// <summary>
    /// Elimina encuestas cargados anteriormente para agregar nuevos
    /// </summary>
    private void LimpiaencuestasAnteriores()
    {
        GameObject[] encuestasAntiguas = GameObject.FindGameObjectsWithTag(Constantes.PREFAB_ENCUESTA_ENCUESTA);
        GameObject encuestaEncontrada;
        int totalResultados = encuestasAntiguas.Length;

        if (totalResultados > 0)
        {
            for (int i = 0; i <= totalResultados; i++)
            {
                encuestaEncontrada = GameObject.Find(Constantes.PREFAB_ENCUESTA + (totalResultados - i));
                if (encuestaEncontrada != null)
                {
                    Destroy(encuestaEncontrada);
                }
            }
        }
    }

    /// <summary>
    /// Carga todas las encuestas guardadas y además pobla los textos principales
    /// </summary>
    private void CargaEncuestas()
    {
        int tamanio = SaveSystem.LoadControl();
        if (tamanio > 0) //Existen datos para cargar
        {
            _playerData = new PlayerData[tamanio];
            float porcentaje = 100 / tamanio;
            float valor2 = porcentaje / 100;
            for (int i = 0; i < tamanio; i++)
            {
                _playerData[i] = SaveSystem.LoadPlayer(i);
                AgregaElementoEncuesta((i), _playerData[i].nombrePaciente, _playerData[i].idPaciente, valor2);
            }
            
            tmpId.text = Constantes.MENSAJE_TITULO_ID + _playerData[0].idPaciente;
            tmpNombre.text = Constantes.MENSAJE_TITULO_NOMBRE + _playerData[0].nombrePaciente;
            tmpEncuesta.text = Constantes.MENSAJE_TITULO_ENCUESTA + _playerData[0].nombreTest;
            tmpResultado.text = Constantes.MENSAJE_TITULO_RESULTADO + (CalculaResultado.Calcula(_playerData[0].nombreTest, _playerData[0].resultados).Substring(10) );
        }
    }

    /// <summary>
    /// Método para regresar al menú principal
    /// </summary>
    public void Regresar()
    {
        SceneManager.LoadScene(Constantes.SCENE_MENUPRINCIPAL);
    }

    /// <summary>
    /// Configuración del asunto y el cuerpo del mensaje a enviar
    /// El mensaje enviado va con la fecha del envío como control
    /// </summary>
    public void EnvioMensaje()
    {
        if (SaveSystem.LoadControl() > 0)
        {
            string asunto = Constantes.EMAIL_ASUNTO + DateTime.Now;
            string cuerpo = "";
            for (int i = 0; i < _playerData.Length; i++)
            {
                cuerpo += Constantes.MENSAJE_TITULO_ID + _playerData[i].idPaciente + "\n" +
                          Constantes.MENSAJE_TITULO_NOMBRE + _playerData[i].nombrePaciente + "\n" +
                          Constantes.MENSAJE_TITULO_ENCUESTA + _playerData[i].nombreTest + "\n" +
                          Constantes.MENSAJE_TITULO_RESULTADO + CalculaResultado.Calcula(_playerData[i].nombreTest, _playerData[i].resultados) + "\n\n";
            }

            EmailEnvio.Envio(asunto,cuerpo);
        }
    }
    
    /// <summary>
    /// Borra todas las encuestas contestadas previamente
    /// </summary>
    public void BorraMemoria()
    {
        if (SaveSystem.LoadControl() > 0)
        {
            SaveSystem.BorraMemoria();
            LimpiaResultadosAnteriores();
            LimpiaencuestasAnteriores();
            SinDatos();
        }
    }

    /// <summary>
    /// Método para cuando no hay datos agregados
    /// </summary>
    private void SinDatos()
    {
        AgregaElementosEncuesta(0);
        AgregaElementosRespuestas(0);
    }

}
