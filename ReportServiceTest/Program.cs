using EO.Pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {

            RectangleF rectf = new RectangleF(0.5f, 0.5f, 7.5f, 10f);
            var serialisedRectf = JsonConvert.SerializeObject(rectf);

            var htmlOptions = new HtmlToPdfOptions
            {
                MaxLoadWaitTime = 50000,
                UserStyleSheet = "table tr td{font-size:14px!important;} p{font-size:16px!important; line-height:26px!important} .action{display:none} #main-nav{display:none} .e-shad{box-shadow:none; border:1px solid lightgray}",
                VisibleElementIds = "main-content",
                InvisibleElementIds = "siblings-nav;control-panel",
                OutputArea = rectf
            };
            PdfDocument ResultDocument = new PdfDocument();

             
            List<string> urls = new List<string>();
            //urls.Add(@"https://economy.id.com.au/monash/population");
            //urls.Add(@"http://economy-next.id.com.au:9090/monash");
            urls.Add(@"https://economy.id.com.au/alpine/population");
            //urls.Add(@"https://econext-dev.azurewebsites.net/monash/population?WebID=10");
            //urls.Add(@"http://economy.idcommdev.idc.local/monash/population");
            //urls.Add(@"https://reportwebah.azurewebsites.net/ReportCoverPage/Get?Product=profile&Title=test%20title&ClientAlias=monash&ClientDisplayName=city%20of%20monash&ClientId=102");
            //urls.Add(@"file:///C:/Users/fabrice/Documents/Workspace/IDReportCoverPage/index.html?alias=monash&prettyname=City%20of%20Monash&title=report%20title&product=profile");

            foreach (var url in urls)
            {
                HtmlToPdf.ConvertUrl(url, ResultDocument, htmlOptions);
            }


            ///// Economy space
            ///// 
            var ehtmlOptions = new HtmlToPdfOptions
            {
                MaxLoadWaitTime = 50000
            };

            List<string> eurls = new List<string>();
            //eurls.Add(@"https://economy.local.com.au/monash/gross-product?pdf=1");
            //// Add urls here

            foreach (var url in eurls)
            {
                HtmlToPdf.ConvertUrl(url, ResultDocument, ehtmlOptions);
            }



            Guid g = Guid.NewGuid();
            ResultDocument.Save($"c://temp/{g}.pdf");
        }
    }
}
