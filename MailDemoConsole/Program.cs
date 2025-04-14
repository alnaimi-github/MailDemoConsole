
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

var message = new MimeMessage();

var from = new MailboxAddress("alnuaimi","abdulwaisaalnuaimi@gmail.com");
message.From.Add(from);


var to = new MailboxAddress("waisa", "alnymybdalwas1@gmail.com");
message.To.Add(to);

message.Subject = "Hi waisa";

var bb = new BodyBuilder();
bb.TextBody = "Hello Waisa";
bb.HtmlBody = "<p> How are you doing? \r\n I hope you are doing well. \r\n Best regards, \r\n Abdulwais Alnuaimi</p>";

message.Body = bb.ToMessageBody();


using var smtp = new SmtpClient();
await smtp.ConnectAsync("localhost", 11230);
await smtp.SendAsync(message);
await smtp.DisconnectAsync(true);

Console.WriteLine($"Mail send to {to.Address}");