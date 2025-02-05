using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using MamunTutorial.Data;
using MamunTutorial.Models;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Cors;


[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class SendPdfController : ControllerBase
{
    private readonly ApplicationDBContext _dbcontext;

    public SendPdfController(ApplicationDBContext configuration)
    {
        _dbcontext = configuration;
    }


    /*[HttpPost("send-pdf")]
    public async Task<IActionResult> SendPdfToEmail(IFormFile pdf, string email)
    {
        if (pdf == null || string.IsNullOrEmpty(email))
        {
            return BadRequest("Invalid request.");
        }

        try
        {
            // Set up email settings from configuration
            var smtpServer = _configuration["SmtpServer"];
            var smtpPort = int.Parse(_configuration["SmtpPort"]);
            var smtpUser = _configuration["SmtpUser"];
            var smtpPass = _configuration["SmtpPass"];
            var senderEmail = _configuration["SenderEmail"];

            // Convert PDF to byte array
            byte[] pdfBytes;
            using (var memoryStream = new MemoryStream())
            {
                await pdf.CopyToAsync(memoryStream);
                pdfBytes = memoryStream.ToArray();
            }

            var mailMessage = new MailMessage
            {
                From = new MailAddress(senderEmail),
                Subject = "Bill Summary",
                Body = "Please find the attached bill summary.",
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            var attachment = new Attachment(new MemoryStream(pdfBytes), "bill-summary.pdf", "application/pdf");
            mailMessage.Attachments.Add(attachment);

            using (var smtpClient = new SmtpClient(smtpServer, smtpPort)
            {
                Credentials = new NetworkCredential(smtpUser, smtpPass),
                EnableSsl = true
            })
            {
                await smtpClient.SendMailAsync(mailMessage);
            }

            return Ok(new { message = "PDF sent successfully!" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Failed to send email", error = ex.Message });
        }
    }*/
    /*[AllowAnonymous]
    [HttpPost]
    [Route("send-pdf")]
    // Make sure the endpoint allows unauthenticated access
    public IActionResult SendPDF(int x)
    {
       *//* if (pdf == null || pdf.Length == 0)
            return BadRequest("PDF file is required.");

      *//*
        // Process the PDF and email here

        return Ok(new { message = "PDF received successfully!" });
    }*/


    [Authorize]
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> PostSendPDF([FromForm] IFormFile pdf, [FromForm] string email)
    {
        try
        {
            // Step 1: PDF is received and saved  to a temporary location
            var tempFilePath = Path.Combine(Path.GetTempPath(), pdf.FileName);
            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await pdf.CopyToAsync(stream);
            }
            // Step 2: Creating the email message
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("MamunTutorial", "mir.udemy2024@gmail.com")); 
            message.To.Add(new MailboxAddress("Target User", email));
            message.Subject = "Monthly Bill";
            var bodyBuilder = new BodyBuilder
            {
                TextBody = "Dear User,\n\nPlease find your bill attached as a PDF for testing purposes.\n\nRegards,\nYour App Team"
            };
            // Step 3: Attaching the PDF to the email
            if (System.IO.File.Exists(tempFilePath))
            {
                bodyBuilder.Attachments.Add(tempFilePath);
            }
            else
            {
                return StatusCode(500, new { message = "PDF file not found." });
            }

            message.Body = bodyBuilder.ToMessageBody();

            // Step 4: Sending the email using MailKit
            using (var smtpClient = new MailKit.Net.Smtp.SmtpClient())
            {
                smtpClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtpClient.Authenticate("mir.udemy2024@gmail.com", "kfyd euct svko cyeb"); //  credentials
                await smtpClient.SendAsync(message);
                smtpClient.Disconnect(true);

            }

            return Ok(new { message = "PDF sent successfully!" });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during email sending: {ex.Message}");
            return StatusCode(500, new { message = "Error sending email", error = ex.Message });
        }

    }






}
