using System;

public class CalculaResultado
{
    /// <summary>
    /// Concatena todos los resultados de alguna encuesta para obtener un resultado general
    /// </summary>
    /// <param name="test">Nombre del test a evaular</param>
    /// <param name="resultados">resultados dados en ese test</param>
    /// <returns>Concatenación de resultados dependiendo la encuesta</returns>
    public static string Calcula(string test, string []resultados)
    {
        string resultado = "";
        
        switch (test)
        {
            case Constantes.NOMBRE_ENCUESTA_ZARIT:
                return CalculaSobrecargaZarit(resultados);
            case Constantes.NOMBRE_ENCUESTA_SPENCE:
                return CalculaAnsiedadSpence(resultados);
            case Constantes.NOMBRE_ENCUESTA_ANSIEDAD_BECK:
                return CalculaAnsiedadBeck(resultados);
            case Constantes.NOMBRE_ENCUESTA_DEPRESION_BECK:
                return CalculaDepresionBeck(resultados);
        }
        return resultado;
    }
    
    private static string CalculaSobrecargaZarit(string[] resultados)
    {
        string resultado = "";
        int nunca = 0;
        int raraVez = 0;
        int algunasVeces = 0;
        int bastantesVeces = 0;
        int casiSiempre = 0;
        int total = 0;

        for (int i = 0; i < resultados.Length; i++)
        {
            switch (resultados[i])
            {
                case "1":
                    total += 1;
                    nunca++;
                    break;
                case "2":
                    total += 2;
                    raraVez++;
                    break;
                case "3":
                    total += 3;
                    algunasVeces++;
                    break;
                case "4":
                    total += 4;
                    bastantesVeces++;
                    break;
                case "5":
                    total += 5;
                    casiSiempre++;
                    break;
            }
        }

        resultado += Constantes.MENSAJE_TITULO_TOTAL;
        
        if (total < 47)
        {
            resultado += Constantes.RESULTADO_ZARIT_NOSOBRECARGA;
        }else if (total < 56)
        {
            resultado += Constantes.RESULTADO_ZARIT_SOBRECARGALEVE;
        }
        else
        {
            resultado += Constantes.RESULTADO_ZARIT_SOBRECARGAINTENSA;
        }

        resultado += Constantes.RESULTADO_ZARIT_NUNCA + nunca +
                     Constantes.RESULTADO_ZARIT_RARAVEZ + raraVez +
                     Constantes.RESULTADO_ZARIT_ALGUNAVEZ + algunasVeces +
                     Constantes.RESULTADO_ZARIT_BASTANTE + bastantesVeces +
                     Constantes.RESULTADO_ZARIT_CASISIEMPRE + casiSiempre;

        return resultado;
    }

    private static string CalculaAnsiedadSpence(string[] resultados)
    {
        string resultado = "";
        int nunca = 0;
        int aVeces = 0;
        int muchasVeces = 0;
        int siempre = 0;
        
        for (int i = 0; i < resultados.Length-3; i++)
        {
            switch (resultados[i])
            {
                case "1":
                    nunca++;
                    break;
                case "2":
                    aVeces++;
                    break;
                case "3":
                    muchasVeces++;
                    break;
                case "4":
                    siempre++;
                    break;
            }
        }
        
        resultado += Constantes.RESULTADO_SPENCE_NUNCA + nunca +
                     Constantes.RESULTADO_SPENCE_AVECES + aVeces +
                     Constantes.RESULTADO_SPENCE_MUCHASVECES + muchasVeces +
                     Constantes.RESULTADO_SPENCE_SIEMPRE + siempre + "\n";
        resultado += /*Constantes.RESULTADO_SPENCE_ULTIMA +*/ 
                     resultados[resultados.Length - 3] +
                     resultados[resultados.Length - 2] +
                     resultados[resultados.Length - 1]
                     ;
        
        return resultado;
    }

    private static string CalculaDepresionBeck(string[] resultados)
    {
        string resultado = "";
        int total = 0;

        for (int i = 0; i < resultados.Length-1; i++)
        {
            total += Int32.Parse(resultados[i]);
        }

        if (total < 11)
        {
            resultado += Constantes.RESULTADO_DEPRESION_BECK_1;
        }else if (total < 17)
        {
            resultado += Constantes.RESULTADO_DEPRESION_BECK_2;
        }else if (total < 21)
        {
            resultado += Constantes.RESULTADO_DEPRESION_BECK_3;
        }else if (total < 31)
        {
            resultado += Constantes.RESULTADO_DEPRESION_BECK_4;
        }else if (total < 41)
        {
            resultado += Constantes.RESULTADO_DEPRESION_BECK_5;
        }else if (total > 40)
        {
            resultado += Constantes.RESULTADO_DEPRESION_BECK_6;
        }

        resultado += Constantes.RESULTADO_DEPRESION_BECK_PUNTUACION + total;
        
        return resultado;
    }

    private static string CalculaAnsiedadBeck(string []resultados)
    {
        string resultado = "";
        int enAbsoluto = 0;
        int levemente = 0;
        int moderadamente = 0;
        int severamente = 0;
        for (int i = 0; i < resultados.Length; i++)
        {
            switch (resultados[i])
            {
                case "1":
                    enAbsoluto++;
                    break;
                case "2":
                    levemente++;
                    break;
                case "3":
                    moderadamente++;
                    break;
                case "4":
                    severamente++;
                    break;
            }
        }

        resultado += Constantes.RESULTADO_ANSIEDAD_BECK_ENABSOLUTO + enAbsoluto +
                     Constantes.RESULTADO_ANSIEDAD_BECK_LEVEMENTE + levemente +
                     Constantes.RESULTADO_ANSIEDAD_BECK_MODERADAMENTE + moderadamente +
                     Constantes.RESULTADO_ANSIEDAD_BECK_SEVERAMENTE + severamente + "\n";
        return resultado;
    }
    
}
