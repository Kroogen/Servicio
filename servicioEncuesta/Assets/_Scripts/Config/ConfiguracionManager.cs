using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfiguracionManager : MonoBehaviour
{

    public TextMeshProUGUI correoActual;          //Texto que muestra el correo donde se manda la información
    public TMP_InputField correoNuevo;            //Campo de Texto para cambiar el correo
    public TMP_InputField passNuevo;              //Campo de Texto para cambiar la contraseña
    public TMP_InputField passConfirmacion;       //Campo de Texto para confirmar nueva contraseña
    public GameObject panelError;                 //Panel con mensaje de contraseña equivocada
    public TextMeshProUGUI mensajeError;          //Texto para informar sobre el error 
    public GameObject panelConfirmacion;          //Panel de confirmación 
    public TextMeshProUGUI mensajeConfirmacion;   //Texto para confirmar el cambio realizado
    public InputField passVerificacion;           //Campo de Texto para ingresar la contraseña 
    public GameObject panelVerificacion;          //Panel para confirmar contraseña

    private string pass;                          //Variable para almacenar la contraseña momentaneamente 
    private bool pass_email;                      //variable de control (false pass - true email)
    
    //Configuración inicial
    private void Start()
    {
        panelError.SetActive(false);
        panelConfirmacion.SetActive(false);
        panelVerificacion.SetActive(false);
        pass_email = false;
        pass = SaveSystem.LoadConfiguracion().getPass();
        correoActual.text = SaveSystem.LoadConfiguracion().getEmail();
        passVerificacion.inputType = InputField.InputType.Password;
    }

    /// <summary>
    /// En caso de querer hacer un cambio se verifica que la contraseña sea correcta 
    /// </summary>
    private void FixedUpdate()
    {
        if (pass == passVerificacion.text)
        {
            passVerificacion.text = "";
            panelVerificacion.SetActive(false);
            if (pass_email)
            {
                CambiaCorreo();
            }
            else
            {
                CambiaPass();
            }
        }
    }

    /// <summary>
    /// Método que se encarga de hacer el cambio de contraseña
    /// </summary>
    public void CambiaPass()
    {
            Configuracion configuracion = SaveSystem.LoadConfiguracion();
            if (configuracion.setPass(passNuevo.text,passConfirmacion.text)) //formato correcto
            {
                mensajeConfirmacion.text = Constantes.CONFIRMACION_PASS;
                SaveSystem.SaveConfiguracion(configuracion);
                passNuevo.text = "";
                passConfirmacion.text = "";
                panelConfirmacion.SetActive(true);
            }
            else //Mostrar Mensaje Error
            {
                mensajeError.text = Constantes.ERROR_PASS;
                panelError.SetActive(true);
            }
    }

    /// <summary>
    /// Método que se encarga de hacer el cambio de correo 
    /// </summary>
    public void CambiaCorreo()
    {
            Configuracion configuracion = SaveSystem.LoadConfiguracion();
            if (configuracion.setEmail(correoNuevo.text)) //formato correcto
            {
                SaveSystem.SaveConfiguracion(configuracion);
                correoActual.text = SaveSystem.LoadConfiguracion().getEmail();
                correoNuevo.text = "";
                mensajeConfirmacion.text = Constantes.CONFIRMACION_EMAIL;
                panelConfirmacion.SetActive(true);
            }
            else //Mostrar Mensaje Error
            {
                mensajeError.text = Constantes.ERROR_EMAIL;
                panelError.SetActive(true);
            }
    }

    public void OcultarMensajeError()
    {
        panelError.SetActive(false);
    }
    
    public void OcultarMensajeConformacion()
    {
        panelConfirmacion.SetActive(false);
    }

    /// <summary>
    /// Método para identificar que tipo de cambio se desea realizar y mostrar el panel para ingresar la contraseña actual
    /// </summary>
    /// <param name="tipo">controla el tipo de cambio a la configuración</param>
    public void ConfiguracionPass(bool tipo)
    {
        pass_email = tipo;
        panelVerificacion.SetActive(true);
        panelError.SetActive(false);
        panelConfirmacion.SetActive(false);
    }

    /// <summary>
    /// Método que regresa al menú principal
    /// </summary>
    public void IniciaEncuesta()
    {
        SceneManager.LoadScene(Constantes.SCENE_MENUPRINCIPAL);
    }
    
}
