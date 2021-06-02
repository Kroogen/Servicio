using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public InputField ingreso;              //Campo de Texto para verificar contraseña
    public GameObject passArea;             //Panel de la contraseña
    public GameObject seleccionEncuesta;    //Panel de Menú Principal
    public GameObject seccionDatosbasicos;  //Panel de Datos Básicos (Nombre, Id)
    public TextMeshProUGUI campoId;         //Campo de Texto para ingresar el Id
    public TextMeshProUGUI campoNombre;     //Campo de Texto para ingresar el Nombre
    public TextMeshProUGUI textoNombre;     //Texto donde se muestra el nombre ingresado
    public TextMeshProUGUI textoId;         //Texto donde se muestra el id ingresado

    private string clave;                   // Variable para controlar la verificación de la contraseña

    
    private void Start()
    {
        ingreso.inputType = InputField.InputType.Password;
        CargaPantallaInicio();
        CargaConfiguracionInicial();
    }

    /// <summary>
    /// Verifica que ya exista una configuración previa
    /// Si no la hay creará una pass "base" e iniciará sin correo
    /// </summary>
    private void CargaConfiguracionInicial()
    {
        Configuracion config = SaveSystem.LoadConfiguracion();
        if (config != null)
        {
            clave = config.getPass();
        }
        else
        {
            config = new Configuracion("",Constantes.CLAVE_BASE);
            SaveSystem.SaveConfiguracion(config);
            clave = config.getPass();
        }
        
    }
    
    /// <summary>
    /// Método que se encargará de verificar que la contraseña sea correcta
    /// </summary>
    private void FixedUpdate()
    {
        if (clave == ingreso.text)
        {
            ingreso.text = "";
            passArea.SetActive(false);
            seleccionEncuesta.SetActive(true);
        }
    }

    /// <summary>
    /// Depende del número que sea pasado será la escena que se cargue
    /// </summary>
    /// <param name="num">Número para identificar la escena a cargar</param>
    public void IniciaEncuesta(int num)
    {
        SceneManager.LoadScene(num);
    }

    /// <summary>
    /// Selección del panel a mostrar dependiendo el caso
    /// Si hay datos ya ingresados (nombre , id) no los pedirá nuevamente
    /// Si no hay datos ya ingresados los solicitará al usuario
    /// </summary>
    public void CargaPantallaInicio()
    {
        passArea.SetActive(false);
        seleccionEncuesta.SetActive(false);
        seccionDatosbasicos.SetActive(false);
        
        if(DatosBasicos.getEstado())
        {
            MuestraDatosPasiente();
            seleccionEncuesta.SetActive(true);
        }
        else
        {
            seccionDatosbasicos.SetActive(true);
        }
    }

    /// <summary>
    /// Muestra en el menú principal los datos de la persona a ser evauluada
    /// </summary>
    private void MuestraDatosPasiente()
    {
        textoNombre.text = DatosBasicos.getNombre();
        textoId.text = DatosBasicos.getId();
    }

    /// <summary>
    /// Verifica que el nombre dado tenga un tamaño mínimo
    /// Realiza la configuración inicial y carga las animaciónes del menú
    /// </summary>
    public void CargaDatosBasicos()
    {
        if (campoNombre.text.Length > 5)
        {
            DatosBasicos.setValores(campoNombre.text,campoId.text);
            seccionDatosbasicos.GetComponent<Animator>().Play(Constantes.ANIMACION_MENU_BOTONPULSADO);
            seccionDatosbasicos.GetComponent<Animator>().Play(Constantes.ANIMACION_MENU_DESAPARECER);
            
            passArea.SetActive(true);
            seleccionEncuesta.SetActive(false);
            seccionDatosbasicos.SetActive(false);
            MuestraDatosPasiente();
        }
        else
        {
            seccionDatosbasicos.GetComponent<Animator>().Play(Constantes.ANIMACION_MENU_BOTONCLICK);
        }
    }
}
