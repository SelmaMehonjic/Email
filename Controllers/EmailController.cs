using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Send_and_track.DTO;
using Send_and_track.models;
using Send_and_track.Repository;
using System.Web;
using System;
using System.Net.Http;
using System.Collections.Generic;

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
            return Ok(id.Id);


        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromBody] Email email)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(email.SendTo);
            mail.From = new MailAddress("selma.mehonjic@digitalcontrol.me");
            mail.Subject = email.Subject;
            string Body = email.Body;
            var attlist = await _repository.GetAttachments(email.Id);

                Body = Body + " http://localhost:4200/anothertab/" +email.Id;
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
            // await _repository.Updateatt(id);
            return fileResult;

        }


        [HttpGet("send/{id}")]

        public async Task<IActionResult> GetEmail(int id)
        {
            var email = await _repository.GetEmail(id);
            return Ok(email);

        }



        [HttpGet("att/{id}")]

        public async Task<IActionResult> GetAtt(int id)
        {
            var att = await _repository.GetAttachment(id);
            return Ok(att);

        }




        [HttpPut("update")]

        public async Task<IActionResult> UpdateAtt([FromBody] models.Attachment att)
        {
            await _repository.Updateatt(att);
            return Ok();

        }

        [HttpPost("att")]

        public async Task<IActionResult> CreateAtt([FromForm] AttachmentDTO attachment, int id)
        {
            using (var ms = new MemoryStream())
            {
                foreach (var att in attachment.File)
                {

                    att.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    var attachmentDb = new attachmentforsaveDTO { BinaryFile = fileBytes, EmailId = id };
                    var attachementForSave = _mapper.Map<models.Attachment>(attachmentDb);
                    await _repository.SendAttachments(attachementForSave);


                }
                return Ok();

            }

        }

        [HttpGet("attach/{id}")]

        public async Task<IActionResult> GetAttByImailId(int id)
        {
            var att = await _repository.GetAttachments(id);
            System.Console.WriteLine(att);
            var mapped = _mapper.Map<IEnumerable<attformailDTO>>(att);
            return Ok(mapped);
        }

    }
}