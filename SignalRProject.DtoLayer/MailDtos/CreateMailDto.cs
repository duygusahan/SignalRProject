using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.DtoLayer.MailDtos
{
    public class CreateMailDto
    {
        public string ReciverMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
