using System;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;


namespace IQTools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
        //static void adxpost()
        //{

        //    XmlDocument xmlDoc = new XmlDocument();
        //    xmlDoc.Load(@"C:\Cohort\MoH_731_ADX.xml");
        //    string username = "BWakhutu";
        //    string password = "IQC@re11";
        //    string usernamePassword = username + ":" + password;
        //    byte[] bytes = Encoding.UTF8.GetBytes(usernamePassword.ToCharArray());
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://test.phiresearchlab.org/dhis/api/dataValueSets?dataElementIdScheme=code&orgUnitIdScheme=code");
        //    try
        //    {

        //        byte[] buffer = Encoding.ASCII.GetBytes(xmlDoc.InnerXml);
        //        request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(bytes);
        //        request.Method = "POST";
        //        request.Accept = "application/xml+adx";
        //        request.ContentLength = buffer.Length;
        //        request.ContentType = "application/xml+adx";
        //        using (Stream requestStream = request.GetRequestStream())
        //        {
        //            requestStream.Write(buffer, 0, buffer.Length);
        //            requestStream.Close();
        //        }
        //        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        //        {
        //            String respString;
        //            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
        //            {
        //                respString = sr.ReadToEnd();
        //            }
        //            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Cohort\adx_response.txt"))
        //            {
        //                file.WriteLine(respString);
        //            }
        //            if (response.StatusCode == HttpStatusCode.OK)
        //            {
        //                Console.WriteLine("Successfully posted to DHIS ADX already");
        //                Console.WriteLine(respString);
        //            }
        //            response.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("{0} {1}", ex.Message, "Post to DHIS ADX");
        //    }
        //    finally
        //    {

        //    }
        //    Console.ReadLine();
        //}
    }
}