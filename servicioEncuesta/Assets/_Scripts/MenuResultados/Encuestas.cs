using TMPro;
using UnityEngine;

public class Encuestas : MonoBehaviour
{

    private PlayerData _playerData; //Estructura con datos para llenar los arreglos
    
    public TextMeshProUGUI numEncuesta;
    public TextMeshProUGUI nombrePaciente;
    public TextMeshProUGUI idPaciente;
    public GameObject resultadosManager;

    private int pos;

    private void Start()
    {
        resultadosManager = GameObject.Find("ControlDatos");
    }

    public void CargaDatos(int pos, string nombre, string id)
    {
        numEncuesta.text = pos.ToString();
        nombrePaciente.text = nombre;
        idPaciente.text = id;
        this.pos = pos-1;
    }

    public void Seleccion()
    {
        resultadosManager.GetComponent<ResultadosManager>().CargaRespuestasSeleccion(pos);
    }

    public void CargaDatos(PlayerData _playerData)
    {
        this._playerData = _playerData;
    }

}
