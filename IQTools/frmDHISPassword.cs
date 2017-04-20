using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using BusinessLayer;
using System.IO;
using System.Net;
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
            DataTable theDt = (DataTable)theObject.ReturnObject(Entity.getconnString(BusinessLayer.clsGbl.xmlPath), ClsUtility.theParams, "SELECT DHISPortal,MFLCode from aa_Database", ClsUtility.ObjectEnum.DataTable, "mssql");
            DataTableReader theDr = theDt.CreateDataReader();
            txtDHIS2Portal.Text = "http://test.hiskenya.org";
            while (theDr.Read())
            {
                txtDHIS2Portal.Text = (theDr["DHISPortal"].ToString());
                txtMFLCode.Text = (theDr["MFLCode"].ToString());
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "" || txtUserName.Text.Trim() == "" || txtMFLCode.Text.Trim() == "" || txtDHIS2Portal.Text.Trim() == "")
            {
                MessageBox.Show("Some information is missing, please insert and try again.", "DHIS 2 Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //TODO VY. pick username and password and connect to DHIS2
            UName = txtUserName.Text.Trim();
            PWord = txtPassword.Text.Trim();
            MFLCode = txtMFLCode.Text.Trim();
            DHIS2URL = txtDHIS2Portal.Text.Trim();

            int i = (int)theObject.ReturnObject(Entity.getconnString(BusinessLayer.clsGbl.xmlPath), ClsUtility.theParams, "UPDATE aa_Database SET DHISPortal='" + txtDHIS2Portal.Text.Trim() + "',MFLCode='" + txtMFLCode.Text.Trim() + "'", ClsUtility.ObjectEnum.ExecuteNonQuery, "mssql");
            try
            {

                HttpWebRequest requestToServerEndpoint =    (HttpWebRequest)WebRequest.Create(DHIS2URL);

                string boundaryString = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                string fileUrl = @"C:\Cohort\moh_731_adx.xml";

                // Set the http request header \\
                requestToServerEndpoint.Method = WebRequestMethods.Http.Post;
                requestToServerEndpoint.ContentType = "multipart/form-data; boundary=" + boundaryString;
                requestToServerEndpoint.KeepAlive = true;
                requestToServerEndpoint.Credentials = new NetworkCredential(UName, PWord);

                // Use a MemoryStream to form the post data request,
                // so that we can get the content-length attribute.
                MemoryStream postDataStream = new MemoryStream();
                StreamWriter postDataWriter = new StreamWriter(postDataStream);

                // Include value from the myFileDescription text area in the post data
                postDataWriter.Write("\r\n--" + boundaryString + "\r\n");
                postDataWriter.Write("Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}",
                                        "myFileDescription",
                                        "A sample file description");

                // Include the file in the post data
                postDataWriter.Write("\r\n--" + boundaryString + "\r\n");
                postDataWriter.Write("Content-Disposition: form-data;"
                                        + "name=\"{0}\";"
                                        + "filename=\"{1}\""
                                        + "\r\nContent-Type: {2}\r\n\r\n",
                                        "myFile",
                                        Path.GetFileName(fileUrl),
                                        Path.GetExtension(fileUrl));
                postDataWriter.Flush();

                // Read the file
                FileStream fileStream = new FileStream(fileUrl, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    postDataStream.Write(buffer, 0, bytesRead);
                }
                fileStream.Close();

                postDataWriter.Write("\r\n--" + boundaryString + "--\r\n");
                postDataWriter.Flush();

                // Set the http request body content length
                requestToServerEndpoint.ContentLength = postDataStream.Length;

                // Dump the post data from the memory stream to the request stream
                using (Stream s = requestToServerEndpoint.GetRequestStream())
                {
                    postDataStream.WriteTo(s);
                }
                postDataStream.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while creating adx file and sending the file automatically" + ex.Message.ToString());
            }


            //TODO VY test if suppied credentials will authenticate succcessfullly
            DialogResult = DialogResult.OK;

            this.Close();
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
