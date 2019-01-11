using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using SeasideResearch.LibCurlNet;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace IQTools
{
    public partial class frmDHISPassword : Form
    {
        public String UName = "";
        public String PWord = "";
        public String MFLCode = "";
        public String DHIS2URL = "";
        Entity theObject = new Entity();
        public frmDHISPassword()
        {
            InitializeComponent();
            //DataTable theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(BusinessLayer.clsGbl.xmlPath), ClsUtility.theParams, "SELECT DHISPortal,MFLCode from aa_Database", ClsUtility.ObjectEnum.DataTable, "mssql");
            //DataTableReader theDr = theDt.CreateDataReader();
            txtDHIS2Portal.Text = "http://test.phiresearchlab.org/";
            //while (theDr.Read())
            //{
            //    txtDHIS2Portal.Text = (theDr["DHISPortal"].ToString());
            //    txtMFLCode.Text = (theDr["MFLCode"].ToString());
            //}
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "" || txtUserName.Text.Trim() == "" || txtMFLCode.Text.Trim() == "" || txtDHIS2Portal.Text.Trim() == "")
            {
                MessageBox.Show("Some information is missing, please insert and try again.", "DHIS 2 Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //TODO Laureen pick username and password and connect to DHIS2
            UName = txtUserName.Text.Trim();
            PWord = txtPassword.Text.Trim();
            MFLCode = txtMFLCode.Text.Trim();
            DHIS2URL = txtDHIS2Portal.Text.Trim();
            string usernamePassword = UName + ":" + PWord;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\Cohort\MoH_731_ADX.xml");
            int i = (int)theObject.ReturnObject(Entity.getconnString(BusinessLayer.clsGbl.xmlPath), ClsUtility.theParams, "UPDATE aa_Database SET DHISPortal='" + txtDHIS2Portal.Text.Trim() + "',MFLCode='" + txtMFLCode.Text.Trim() + "'", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
            byte[] bytes = Encoding.UTF8.GetBytes(usernamePassword.ToCharArray());
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(txtDHIS2Portal.Text.Trim().ToString());
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://test.phiresearchlab.org/dhis/api/dataValueSets?dataElementIdScheme=code&orgUnitIdScheme=code");
            try
            {
                //    string fileUrl = @"C:\Cohort\MoH_731_adx.xml";
                //    CURLcode ret;
                //    Curl.GlobalInit((int)CURLinitFlag.CURL_GLOBAL_ALL);
                //    MultiPartForm mf = new MultiPartForm();

                //    // <input type="File" name="f1">
                //    mf.AddSection(CURLformoption.CURLFORM_COPYNAME, fileUrl,
                //     CURLformoption.CURLFORM_FILE, fileUrl,
                //     CURLformoption.CURLFORM_CONTENTTYPE, "application/binary",
                //     CURLformoption.CURLFORM_END);

                //    Easy easy = new Easy();

                //    easy.SetOpt(CURLoption.CURLOPT_SSL_VERIFYHOST, false);
                //    easy.SetOpt(CURLoption.CURLOPT_SSL_VERIFYPEER, false);
                //    easy.SetOpt(CURLoption.CURLOPT_HTTPAUTH, CURLhttpAuth.CURLAUTH_BASIC);
                //    Easy.DebugFunction df = new Easy.DebugFunction(OnDebug);
                //    easy.SetOpt(CURLoption.CURLOPT_DEBUGFUNCTION, df);
                //    easy.SetOpt(CURLoption.CURLOPT_VERBOSE, true);
                //    Easy.ProgressFunction pf = new Easy.ProgressFunction(OnProgress);
                //    easy.SetOpt(CURLoption.CURLOPT_PROGRESSFUNCTION, pf);

                //    easy.SetOpt(CURLoption.CURLOPT_HTTPPOST, mf);
                //    easy.SetOpt(CURLoption.CURLOPT_URL, DHIS2URL);
                //    easy.SetOpt(CURLoption.CURLOPT_USERPWD, UName + ":" + PWord);
                //    easy.SetOpt(CURLoption.CURLOPT_FAILONERROR, false);
                //    easy.SetOpt(CURLoption.CURLOPT_UPLOAD, true);

                //    ret = easy.Perform();
                //    easy.Cleanup();

                //    Curl.GlobalCleanup(); 
                //}
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show("Error while creating adx file and sending the file automatically" + ex.Message.ToString());
                //    }
            
                //    //TODO  test if suppied credentials will authenticate succcessfullly
                //    DialogResult = DialogResult.OK;
                //    this.Close();
                byte[] buffer = Encoding.ASCII.GetBytes(xmlDoc.InnerXml);
                request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(bytes);
                request.Method = "POST";
                request.Accept = "application/xml+adx";
                request.ContentLength = buffer.Length;
                request.ContentType = "application/xml+adx";
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Close();
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    String respString;
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        respString = sr.ReadToEnd();
                    }
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Cohort\MoH_731_ADX.xml"))
                    {
                        file.WriteLine(respString);
                    }
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Console.WriteLine("Successfully posted to DHIS ADX Ready");
                        MessageBox.Show("Successfully posted to DHIS ADX Ready"); 
                        Console.WriteLine(respString);
                        MessageBox.Show(respString);
                        
                    }
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} {1}", ex.Message, "Post to DHIS ADX");
                MessageBox.Show(ex.Message, "Post to DHIS ADX"); 
            }
            finally
            {

            }
            Console.ReadLine();
        }


        //Done added because of ADX

        public static void OnDebug(CURLINFOTYPE infoType, String msg,
           Object extraData)
        {
            Console.WriteLine(msg);
        }
        public static Int32 OnProgress(Object extraData, Double dlTotal,
            Double dlNow, Double ulTotal, Double ulNow)
        {
            Console.WriteLine("Progress: {0} {1} {2} {3}",
                dlTotal, dlNow, ulTotal, ulNow);
            return 0; // standard return from PROGRESSFUNCTION 
        } 

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
           
        }

        private void frmDHISPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
