[System.Serializable]
public class PlayerData
{
    public string idPaciente;      //Id del usuario
    public string nombrePaciente;  //Nombre del usuario
    public string nombreTest;      //Nombre del Test que fue contestado
    public string resultado;       //Resultado general del Test
    public string[] resultados;    //Resultados individuales 

    public PlayerData(Player player, string []resultados, string resultado)
    {
        idPaciente = player.idPaciente;
        nombrePaciente = player.nombrePaciente;
        nombreTest = player.nombreTest;
        this.resultado = resultado;
        this.resultados = resultados;
    }
}
