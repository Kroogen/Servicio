using System.Xml.Schema;

[System.Serializable]
public class Configuracion
{

    private string email;
    private string pass;

    public Configuracion(string email, string pass)
    {
        this.email = email;
        this.pass = pass;
    }

    public string getEmail()
    {
        return email;
    }

    public string getPass()
    {
        return pass;
    }

    public bool setEmail(string email)
    {
            int tam = email.Length;
            bool arroba = false;
            for (int i = 0; i < tam; i++)
            {
                if (email[i] == '@')
                {
                    if (!arroba  && i <= tam - 7) //arroba aceptable
                    {
                        arroba = true;
                    }
                    else //problema con arroba
                    {
                        return false;
                    }
                }
            }

            if (arroba)
            {
                this.email = email;
                return true;
            }

            return false;
    }

    public bool setPass(string pass1, string pass2)
    {
        if (pass1.Equals(pass2) && pass1.Length > 5)
        {
            pass = pass1;
            return true;
        }
        return false;
    }

}
