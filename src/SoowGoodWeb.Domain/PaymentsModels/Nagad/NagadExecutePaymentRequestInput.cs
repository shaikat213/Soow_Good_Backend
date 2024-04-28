using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoowGoodWeb.NagadData
{
    public class NagadPaymentRequestInput
    {
        public readonly string MerchantId = "687924075735399";
        // public readonly string MerchantId = "683002007104225"; //sandbox

        public readonly string languageBN = "BN";
        public readonly string languageEN = "EN";

        private static DateTime DateTime = DateTime.Now;//.AddMinutes(-10);
        public string RequestDateTime = DateTime.ToString("yyyyMMddHHmmss"); //{// Format should be 20200827134915

        //Generate Random Number
        private static Random r = new Random();

        public int RandomNumber = r.Next(100000000, 999999999); //Randam Number should be less than 20 char
        public string OrderId { get; set; }
        public double ApplicantFee { get; set; }
    }
}