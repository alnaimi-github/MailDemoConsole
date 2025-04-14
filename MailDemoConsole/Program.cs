
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using MimeKit.Utils;

var message = new MimeMessage();

var from = new MailboxAddress("alnuaimi","abdulwaisaalnuaimi@gmail.com");
message.From.Add(from);


var to = new MailboxAddress("waisa", "alnymybdalwas1@gmail.com");
message.To.Add(to);

message.Subject = "Hi waisa";

var bb = new BodyBuilder();

//bb.Attachments.Add("H:\\Development\\My Learning\\Email projects\\MailDemoConsole\\MailDemoConsole\\test.png");

var imagePath = "H:\\\\Development\\\\My Learning\\\\Email projects\\\\MailDemoConsole\\\\MailDemoConsole\\\\test.png";
var imageEntity = bb.LinkedResources.Add(imagePath);
imageEntity.ContentId = MimeUtils.GenerateMessageId();


bb.TextBody = "Hello Waisa";
bb.HtmlBody = "<p>Hello Waisa,</p>" 
              +
              "<p>Hope you are doing well. Please find the attached image below:</p><img src=\"cid:" 
              + imageEntity.ContentId + "\"><p>Best regards,<br>Alnuaimi</br></p>";


message.Body = bb.ToMessageBody();


using var smtp = new SmtpClient();
await smtp.ConnectAsync("localhost", 11230);
await smtp.SendAsync(message);
await smtp.DisconnectAsync(true);

Console.WriteLine($"Mail send to {to.Address}");