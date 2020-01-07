using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace mkplacepagos.data
{
    [DataContract]
    public class dataPagos
    {
        [DataMember(Name = "referenceCode")]
        public string referenceCode { get; set; }
        [DataMember(Name = "amount")]
        public decimal amount { get; set; }
        [DataMember(Name = "currency")]
        public string currency { get; set; }
        [DataMember(Name = "buyerEmail")]
        public string buyerEmail { get; set; }
    }
    [DataContract]
    public class dataPartner
    {
        [DataMember(Name = "merchantId")]
        public int merchantId { get; set; }
        [DataMember(Name = "accountId")]
        public int accountId { get; set; }
        [DataMember(Name = "apiKey")]
        public string apiKey { get; set; }
    }
    [DataContract]
    public class dataSignature
    {
        [DataMember(Name = "signature")]
        public string signature { get; set; }
    }
}
