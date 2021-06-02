using UnityEngine;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class EmailEnvio : MonoBehaviour
{
    private const string SMTPServer = "smtp.live.com";
    private const int SMTPPort = 587;
    
    private const string EmailEmisor = "mario_15200@hotmail.com";
    private const string EmailEmisorPass = "Oikl8-poui9-mlo10";
    
    //private string EmailReceptor;
    
    private static string EmailCuerpo = "Cuerpo";
    private static string EmailAsunto = "Asunto";

    public static void Envio (string Asunto, string Cuerpo)
    {
        string EmailReceptor = SaveSystem.LoadConfiguracion().getEmail();
        EmailAsunto = Asunto;
        EmailCuerpo = Cuerpo;
        try
        {
            SmtpClient mailServer = new SmtpClient(SMTPServer, SMTPPort);
            mailServer.EnableSsl = true;
            mailServer.Credentials = new NetworkCredential(EmailEmisor, EmailEmisorPass) as ICredentialsByHost;
            ServicePointManager.ServerCertificateValidationCallback = delegate{
                return true;
            };

            MailMessage msg = new MailMessage(EmailEmisor, EmailReceptor);
            msg.Subject = EmailAsunto;
            msg.Body = EmailCuerpo;
            mailServer.SendAsync(msg, "");

            Debug.Log("SimpleEmail: Sending Email.");
        }
        catch (Exception ex)
        {
            Debug.LogWarning("SimpleEmail: " + ex);
        }
    }
}
