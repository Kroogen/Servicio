using TMPro;
using UnityEngine;

public class Resultados : MonoBehaviour
{
    
    public TextMeshProUGUI numEncuesta;
    public TextMeshProUGUI respuesta;

    /// <summary>
    /// Carga el téxto equivalente a la respuesta que fue dada
    /// </summary>
    /// <param name="pos">Posición del elemento donde se pondrá la respuesta</param>
    /// <param name="respuesta">valor "numérico" de la respuesta</param>
    public void CargaDatos(string test, int pos, string respuesta)
    {
        switch (test)
        {
            case Constantes.NOMBRE_ENCUESTA_ANSIEDAD_BECK:
                CargaAnsiedadBeck(pos, respuesta);
                break;
            case Constantes.NOMBRE_ENCUESTA_ZARIT:
                CargaZarit(pos, respuesta);
                break;
            case Constantes.NOMBRE_ENCUESTA_SPENCE:
                CargaSpence(pos, respuesta);
                break;
            case Constantes.NOMBRE_ENCUESTA_DEPRESION_BECK:
                CargaDepresionBeck(pos, respuesta);
                break;
        }
    }

    private void CargaZarit(int pos, string respuesta)
    {
        numEncuesta.text = pos.ToString();

        switch (respuesta)
        {
            case "1":
                this.respuesta.text = Constantes.ANSWER_1_ZARIT;
                break;
            case "2":
                this.respuesta.text = Constantes.ANSWER_2_ZARIT;
                break;
            case "3":
                this.respuesta.text = Constantes.ANSWER_3_ZARIT;
                break;
            case "4":
                this.respuesta.text = Constantes.ANSWER_4_ZARIT;
                break;
            case "5":
                this.respuesta.text = Constantes.ANSWER_5_ZARIT;
                break;
        }
    }

    private void CargaSpence(int pos, string respuesta)
    {
        numEncuesta.text = pos.ToString();
        
        switch (respuesta)
        {
            case "1":
                this.respuesta.text = Constantes.ANSWER_1_ANSIEDAD_SPENCE;
                break;
            case "2":
                this.respuesta.text = Constantes.ANSWER_2_ANSIEDAD_SPENCE;
                break;
            case "3":
                this.respuesta.text = Constantes.ANSWER_3_ANSIEDAD_SPENCE;
                break;
            case "4":
                this.respuesta.text = Constantes.ANSWER_4_ANSIEDAD_SPENCE;
                break;
            default:
                this.respuesta.text = respuesta;
                break;
        }
    }

    private void CargaAnsiedadBeck(int pos, string respuesta)
    {
        numEncuesta.text = pos.ToString();
        
        switch (respuesta)
        {
            case "1":
                this.respuesta.text = Constantes.ANSWER_1_ANSIEDAD_BECK;
                break;
            case "2":
                this.respuesta.text = Constantes.ANSWER_2_ANSIEDAD_BECK;
                break;
            case "3":
                this.respuesta.text = Constantes.ANSWER_3_ANSIEDAD_BECK;
                break;
            case "4":
                this.respuesta.text = Constantes.ANSWER_4_ANSIEDAD_BECK;
                break;
        }
    }
    
    private void CargaDepresionBeck(int pos, string respuesta)
    {
        numEncuesta.text = pos.ToString();
        
        switch (respuesta)
        {
            case "1":
                this.respuesta.text = Constantes.ANSWER_1_ANSIEDAD_BECK;
                break;
            case "2":
                this.respuesta.text = Constantes.ANSWER_2_ANSIEDAD_BECK;
                break;
            case "3":
                this.respuesta.text = Constantes.ANSWER_3_ANSIEDAD_BECK;
                break;
            case "4":
                this.respuesta.text = Constantes.ANSWER_4_ANSIEDAD_BECK;
                break;
        }
    }
    
}
