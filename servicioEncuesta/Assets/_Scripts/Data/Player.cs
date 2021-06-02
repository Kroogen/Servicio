[System.Serializable]
public class Player
{
    public string idPaciente;
    public string nombrePaciente;
    public string nombreTest;

    public Player(string idPaciente, string nombrePaciente, string nombreTest)
    {
        this.idPaciente = idPaciente;
        this.nombrePaciente = nombrePaciente;
        this.nombreTest = nombreTest;
    }
}
