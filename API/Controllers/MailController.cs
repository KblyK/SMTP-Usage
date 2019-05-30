using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private SmtpClient _smtpClient;
        private IConfiguration _configuration;
        private string _from;

        public MailController(SmtpClient smtpClient, IConfiguration configuration)
        {
            _smtpClient = smtpClient;
            _configuration = configuration;
            _from = configuration.GetValue<string>("Email:Smtp:Username");
        }

        // POST api/values
        [HttpPost]
        public IActionResult MailPost([FromBody] string value)
        {
            try
            {
                _smtpClient.Send(new MailMessage(
                    from: _from,
                    to: "kubilaykocabal@gmail.com",
                    subject: "Test message subject",
                    body: "Test message body"
                ));
                return Ok("Okay");
            }
            catch (Exception e)
            {
                return Ok("Error" + e.ToString());
            }
        }
    }
}