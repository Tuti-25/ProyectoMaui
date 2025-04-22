using MailKit.Net.Smtp;
using MimeKit;

public class Correo
{
    public void EnviarCorreo(string destinatario)
    {
        try
        {
            // Crear el mensaje
            var mensaje = new MimeMessage();
            mensaje.From.Add(new MailboxAddress("Tu Nombre", "tutidecalle076@gmail.com"));
            mensaje.To.Add(new MailboxAddress("", destinatario));
            mensaje.Subject = "Código de Verificación";

            // Crear el contenido del correo
            var cuerpo = new TextPart("html")
            {
                Text = "<h1>Tu código de verificación es: 123456</h1>"
            };
            mensaje.Body = cuerpo;

            // Conectar al servidor SMTP y enviar el mensaje
            using (var cliente = new SmtpClient())
            {
                cliente.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                cliente.Authenticate("tu_correo@gmail.com", "tu_contrasena");
                cliente.Send(mensaje);
                cliente.Disconnect(true);
            }

            Console.WriteLine("Correo enviado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al enviar el correo: {ex.Message}");
        }
    }
}
