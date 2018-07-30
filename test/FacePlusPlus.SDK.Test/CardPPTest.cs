using System;
using System.Diagnostics;
using System.IO;
using Xunit;

namespace FacePlusPlus.SDK.Test
{
    public class CardPPTest : TestBase
    {
        [Fact]
        public void TestDetectImageFile()
        {
            var client = new APIClient(API_Key, API_Secret);
            var path = "";
            var error = 0d;
            var excep = 0d;
            foreach (var filePath in Directory.GetFiles(path))
            {
                var file = new FileInfo(filePath);
                var name = file.Name;
                try
                {
                    var values = name.Split('.')[0].Split('_');
                    var cardno = values[0];
                    //var bank = values[1];
                    var response = client.OCR_BankCard(filePath);
                    if (response.bank_cards == null || response.bank_cards.Length == 0 || response.bank_cards[0].number != cardno)
                    {
                        error++;
                        Trace.WriteLine(string.Format("Error Detact: {0}", name));
                    }
                }
                catch (System.Exception ex)
                {
                    excep++;
                    Trace.WriteLine(string.Format("Exception Detact: {0} Exception: {1}", name, ex.Message));
                }
            }
            Trace.WriteLine(excep);
            Trace.WriteLine(error);
            Assert.NotEqual(0, error);
        }


        [Fact]
        public void TestDetectSingleImageFile()
        {
            var client = new APIClient(API_Key, API_Secret);
            var path = "";

            var file = new FileInfo(path);
            var name = file.Name;
            var values = name.Split('.')[0].Split('_');
            var cardno = values[0];
            //var bank = values[1]; 
            var response = client.OCR_BankCard(path);
            Assert.NotEmpty(response.bank_cards);
            Assert.Equal(cardno, response.bank_cards[0].number);
        }
    }
}
