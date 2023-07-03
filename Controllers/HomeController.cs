using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationCSharp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        [HttpGet]
        public HttpResponseMessage ConvertToPdf(string base64String )
        {
            //string base64 = "PGhlYWQ+CiAgPG1ldGEgY2hhcnNldD0idXRmLTgiPgogIDx0aXRsZT5Bbmd1bGFyUHJvamVjdEhpdGVzaDwvdGl0bGU+CiAgPGJhc2UgaHJlZj0iLyI+CiAgPG1ldGEgbmFtZT0idmlld3BvcnQiIGNvbnRlbnQ9IndpZHRoPWRldmljZS13aWR0aCwgaW5pdGlhbC1zY2FsZT0xIj4KICA8bGluayByZWw9Imljb24iIHR5cGU9ImltYWdlL3gtaWNvbiIgaHJlZj0iZmF2aWNvbi5pY28iPgo8bGluayByZWw9InN0eWxlc2hlZXQiIGhyZWY9InN0eWxlcy5jc3MiPjxzdHlsZT4KLyojIHNvdXJjZU1hcHBpbmdVUkw9ZGF0YTphcHBsaWNhdGlvbi9qc29uO2Jhc2U2NCxleUoyWlhKemFXOXVJam96TENKemIzVnlZMlZ6SWpwYlhTd2libUZ0WlhNaU9sdGRMQ0p0WVhCd2FXNW5jeUk2SWlJc0ltWnBiR1VpT2lKaGNIQXVZMjl0Y0c5dVpXNTBMbU56Y3lKOSAqLzwvc3R5bGU+PC9oZWFkPgo8Ym9keT4KICA8YXBwLXJvb3QgX25naG9zdC1lam8tYzQzPSIiIG5nLXZlcnNpb249IjE0LjAuNCI+PGh0bWwgX25nY29udGVudC1lam8tYzQzPSIiIGlkPSJHRkdfVVAiPjxkaXYgX25nY29udGVudC1lam8tYzQzPSIiIHN0eWxlPSJ0ZXh0LWFsaWduOiBjZW50ZXI7Ij48aDEgX25nY29udGVudC1lam8tYzQzPSIiIGNsYXNzPSJhcHAtdGl0bGUiPlRPRE8gTGlzdDwvaDE+PC9kaXY+PGRpdiBfbmdjb250ZW50LWVqby1jNDM9IiIgY2xhc3M9ImNvbnRhaW5lciI+PGgxIF9uZ2NvbnRlbnQtZWpvLWM0Mz0iIj5BREQgYSBUT0RPLi4uLjwvaDE+PGJyIF9uZ2NvbnRlbnQtZWpvLWM0Mz0iIj48aW5wdXQgX25nY29udGVudC1lam8tYzQzPSIiIHR5cGU9InRleHQiIHBsYWNlaG9sZGVyPSJUeXBlIGEgVE9ETyIgY2xhc3M9ImlucHV0LXRleHQgbmctdW50b3VjaGVkIG5nLXByaXN0aW5lIG5nLXZhbGlkIiBuZy1yZWZsZWN0LW1vZGVsPSIiPjxidXR0b24gX25nY29udGVudC1lam8tYzQzPSIiIGNsYXNzPSJhZGQtYnRuIiBkaXNhYmxlZD0iIj5BREQgVE9ETzwvYnV0dG9uPjxkaXYgX25nY29udGVudC1lam8tYzQzPSIiIGNsYXNzPSJsaXN0Ij48dWwgX25nY29udGVudC1lam8tYzQzPSIiPjwhLS1iaW5kaW5ncz17CiAgIm5nLXJlZmxlY3QtbmctZm9yLW9mIjogIiIKfS0tPjxpbnB1dCBfbmdjb250ZW50LWVqby1jNDM9IiIgdHlwZT0iY2hlY2tib3giIG5hbWU9ImlzRG9uZSI+PC91bD48YnV0dG9uIF9uZ2NvbnRlbnQtZWpvLWM0Mz0iIiBkaXNhYmxlZD0iIj5FbmFibGVkPC9idXR0b24+PGJ1dHRvbiBfbmdjb250ZW50LWVqby1jNDM9IiI+IGNsaWNrIGhlcmUgdG8gY29udmVydCBodG1sIHRvIGJhc2UgNjQgc3RyaW5nIDwvYnV0dG9uPjwvZGl2PjwvZGl2PjwvaHRtbD48L2FwcC1yb290Pgo8c2NyaXB0IHNyYz0icnVudGltZS5qcyIgdHlwZT0ibW9kdWxlIj48L3NjcmlwdD48c2NyaXB0IHNyYz0icG9seWZpbGxzLmpzIiB0eXBlPSJtb2R1bGUiPjwvc2NyaXB0PjxzY3JpcHQgc3JjPSJzdHlsZXMuanMiIGRlZmVyPSIiPjwvc2NyaXB0PjxzY3JpcHQgc3JjPSJ2ZW5kb3IuanMiIHR5cGU9Im1vZHVsZSI+PC9zY3JpcHQ+PHNjcmlwdCBzcmM9Im1haW4uanMiIHR5cGU9Im1vZHVsZSI+PC9zY3JpcHQ+Cgo8L2JvZHk+";
            //string base64 = "VE9ETyBMaXN0CkFERCBhIFRPRE8uLi4uCgpBREQgVE9ETwpFbmFibGVkY2xpY2sgaGVyZSB0byBjb252ZXJ0IGh0bWwgdG8gYmFzZSA2NCBzdHJpbmc=";//"PGhlYWQ+CiAgPG1ldGEgY2hhcnNldD0idXRmLTgiPgogIDx0aXRsZT5Bbmd1bGFyUHJvamVjdEhpdGVzaDwvdGl0bGU+CiAgPGJhc2UgaHJlZj0iLyI+CiAgPG1ldGEgbmFtZT0idmlld3BvcnQiIGNvbnRlbnQ9IndpZHRoPWRldmljZS13aWR0aCwgaW5pdGlhbC1zY2FsZT0xIj4KICA8bGluayByZWw9Imljb24iIHR5cGU9ImltYWdlL3gtaWNvbiIgaHJlZj0iZmF2aWNvbi5pY28iPgo8bGluayByZWw9InN0eWxlc2hlZXQiIGhyZWY9InN0eWxlcy5jc3MiPjxzdHlsZT4KLyojIHNvdXJjZU1hcHBpbmdVUkw9ZGF0YTphcHBsaWNhdGlvbi9qc29uO2Jhc2U2NCxleUoyWlhKemFXOXVJam96TENKemIzVnlZMlZ6SWpwYlhTd2libUZ0WlhNaU9sdGRMQ0p0WVhCd2FXNW5jeUk2SWlJc0ltWnBiR1VpT2lKaGNIQXVZMjl0Y0c5dVpXNTBMbU56Y3lKOSAqLzwvc3R5bGU+PC9oZWFkPgo8Ym9keT4KICA8YXBwLXJvb3QgX25naG9zdC1lam8tYzQzPSIiIG5nLXZlcnNpb249IjE0LjAuNCI+PGh0bWwgX25nY29udGVudC1lam8tYzQzPSIiIGlkPSJHRkdfVVAiPjxkaXYgX25nY29udGVudC1lam8tYzQzPSIiIHN0eWxlPSJ0ZXh0LWFsaWduOiBjZW50ZXI7Ij48aDEgX25nY29udGVudC1lam8tYzQzPSIiIGNsYXNzPSJhcHAtdGl0bGUiPlRPRE8gTGlzdDwvaDE+PC9kaXY+PGRpdiBfbmdjb250ZW50LWVqby1jNDM9IiIgY2xhc3M9ImNvbnRhaW5lciI+PGgxIF9uZ2NvbnRlbnQtZWpvLWM0Mz0iIj5BREQgYSBUT0RPLi4uLjwvaDE+PGJyIF9uZ2NvbnRlbnQtZWpvLWM0Mz0iIj48aW5wdXQgX25nY29udGVudC1lam8tYzQzPSIiIHR5cGU9InRleHQiIHBsYWNlaG9sZGVyPSJUeXBlIGEgVE9ETyIgY2xhc3M9ImlucHV0LXRleHQgbmctdW50b3VjaGVkIG5nLXByaXN0aW5lIG5nLXZhbGlkIiBuZy1yZWZsZWN0LW1vZGVsPSIiPjxidXR0b24gX25nY29udGVudC1lam8tYzQzPSIiIGNsYXNzPSJhZGQtYnRuIiBkaXNhYmxlZD0iIj5BREQgVE9ETzwvYnV0dG9uPjxkaXYgX25nY29udGVudC1lam8tYzQzPSIiIGNsYXNzPSJsaXN0Ij48dWwgX25nY29udGVudC1lam8tYzQzPSIiPjwhLS1iaW5kaW5ncz17CiAgIm5nLXJlZmxlY3QtbmctZm9yLW9mIjogIiIKfS0tPjxpbnB1dCBfbmdjb250ZW50LWVqby1jNDM9IiIgdHlwZT0iY2hlY2tib3giIG5hbWU9ImlzRG9uZSI+PC91bD48YnV0dG9uIF9uZ2NvbnRlbnQtZWpvLWM0Mz0iIiBkaXNhYmxlZD0iIj5FbmFibGVkPC9idXR0b24+PGJ1dHRvbiBfbmdjb250ZW50LWVqby1jNDM9IiI+IGNsaWNrIGhlcmUgdG8gY29udmVydCBodG1sIHRvIGJhc2UgNjQgc3RyaW5nIDwvYnV0dG9uPjwvZGl2PjwvZGl2PjwvaHRtbD48L2FwcC1yb290Pgo8c2NyaXB0IHNyYz0icnVudGltZS5qcyIgdHlwZT0ibW9kdWxlIj48L3NjcmlwdD48c2NyaXB0IHNyYz0icG9seWZpbGxzLmpzIiB0eXBlPSJtb2R1bGUiPjwvc2NyaXB0PjxzY3JpcHQgc3JjPSJzdHlsZXMuanMiIGRlZmVyPSIiPjwvc2NyaXB0PjxzY3JpcHQgc3JjPSJ2ZW5kb3IuanMiIHR5cGU9Im1vZHVsZSI+PC9zY3JpcHQ+PHNjcmlwdCBzcmM9Im1haW4uanMiIHR5cGU9Im1vZHVsZSI+PC9zY3JpcHQ+Cgo8L2JvZHk+";
            var base64Bytes = System.Convert.FromBase64String(base64String);
            var res = System.Text.Encoding.UTF8.GetString(base64Bytes);
            //var sb = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            sb.Append("<header class='clearfix'>");
            sb.Append("<h1>INVOICE</h1>");
            sb.Append("<div id='company' class='clearfix'>");
            sb.Append("<div>Company Name</div>");
            sb.Append("<div>455 John Tower,<br /> AZ 85004, US</div>");
            sb.Append("<div>(602) 519-0450</div>");
            sb.Append("<div><a href='mailto:company@example.com'>company@example.com</a></div>");
            sb.Append("</div>");
            StringReader sr = new StringReader(res);//sb.ToString());
            Document document = new Document();
            HTMLWorker htmlparser = new HTMLWorker(document);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                htmlparser.Parse(sr);
                
                document.Close();

                byte[] bytes = memoryStream.ToArray();

                //This is for physical local path
                System.IO.File.WriteAllBytes(@"C:\Users\MSUSERSL123\Desktop\" + "Export Sample" + DateTime.Now.ToString("ddMMyyyyHHss") + ".pdf", bytes);

                //Use this to save to server/nas drive
                //System.IO.File.WriteAllBytes(Server.MapPath(@"C:\Users\MSUSERSL123\Desktop\") + DateTime.Now.ToString("ddMMyyyyHHss") + ".pdf", bytes);
                
                memoryStream.Close();
                var resfile = File(memoryStream.ToArray(), "application/pdf", "ExportData.pdf");
                return new HttpResponseMessage(HttpStatusCode.OK);
                
            }


        }
    }
}