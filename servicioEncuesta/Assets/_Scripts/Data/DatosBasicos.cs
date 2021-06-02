using UnityEngine;

public class DatosBasicos : MonoBehaviour
{
    
    public string nombre; //Nombre del usuario - es requisito forzoso
    public string id;     //id del usuario - opcional
    public bool estado;   //true hay datos validos, false hay que llenar el formulario 

    public static DatosBasicos datosBasicos; //Instancia para accesar a los valores
    
    /// <summary>
    /// Validación de que soloamente existirá una instancia de este objeto
    /// </summary>
    private void Awake()
    {
        if (datosBasicos == null)
        {
            datosBasicos = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// En su primera carga se marca que no hay valores ingresados
    /// </summary>
    private void Start()
    {
        nombre = "";
        id = "";
        estado = false;
    }

    public static string getNombre()
    {
        return datosBasicos.nombre;
    }

    public static string getId()
    {
        return datosBasicos.id;
    }

    public static bool getEstado()
    {
        return datosBasicos.estado;
    }

    public static void setValores(string nombre, string id)
    {
        datosBasicos.nombre = nombre;
        datosBasicos.id = id;
        datosBasicos.estado = true;
    }

    public static void DestruirDatos()
    {
        datosBasicos.estado = false;
        datosBasicos.nombre = "";
        datosBasicos.id = "";
    }

}
