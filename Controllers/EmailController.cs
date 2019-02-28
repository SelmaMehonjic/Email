using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Send_and_track.DTO;
using Send_and_track.models;
using Send_and_track.Repository;

namespace Send_and_track.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public EmailController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost()]

        public async Task<IActionResult> CreateEmail([FromBody] EMailDTO email)
        {
            var emailForSave = _mapper.Map<Email>(email);
            var id = await _repository.SendEmail(emailForSave);
            // string path = @"C:\Users\Tijana Tomic\Desktop\file.pdf";
            byte[] bytes = System.IO.File.ReadAllBytes(email.File);
            var attachment = new AttachmentDTO { BinaryFile = bytes, EmailId = emailForSave.Id };
            var attachementForSave = _mapper.Map<models.Attachment>(attachment);
            await _repository.SendAttachments(attachementForSave);
            MailMessage mail = new MailMessage();
            mail.To.Add(email.SendTo);
            mail.From = new MailAddress("selma.mehonjic@digitalcontrol.me");
            mail.Subject = email.Subject;
            string Body = email.Body + " http://localhost:5000/api/email/" + id.Id;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.digitalcontrol.me";
            smtp.Port = 25;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("selma.mehonjic@digitalcontrol.me", "s%Kqryt0");
            smtp.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.Send(mail);
            return Ok();
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetAttachment(int id)
        {
            var pdfBytes = await _repository.GetAttachmentByteArray(id);
            FileResult fileResult = new FileContentResult(pdfBytes, "application/pdf");
            fileResult.FileDownloadName = "Report.pdf";
            await _repository.Updateatt(id);
            return fileResult;

        }
    }
}