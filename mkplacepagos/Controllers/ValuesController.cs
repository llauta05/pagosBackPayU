using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using mkplacepagos.data;

namespace mkplacepagos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<dataPartner> Get()
        {
            return GetDataPartner();
        }
        public dataPartner GetDataPartner() {
            return new dataPartner
            {
                accountId = 512326,
                apiKey = "4Vj8eK4rloUd272L48hsrarnUA",
                merchantId = 508029
            };
        }

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        // GET api/values/data
        [HttpPost]
        [Route("CreateSignature")]
        public ActionResult<dataSignature> CreateSignature([FromBody] dataPagos data)
        {
            var dataPartner = GetDataPartner();
            var key = dataPartner.apiKey + '~' + dataPartner.merchantId + '~' + data.referenceCode + '~' + data.amount + '~' + data.currency;
            return new dataSignature {signature = GetSHA256(key) };
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
