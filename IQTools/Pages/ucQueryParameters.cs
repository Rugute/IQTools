using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActiveDatabaseSoftware.ActiveQueryBuilder;
using System.Collections;


namespace IQTools.Pages
{
    public partial class ucQueryParameters : UserControl
    {
        private ParameterList parameters;
        private DbCommand command;

        public ucQueryParameters(ParameterList pl, DbCommand cmd)
        {
            parameters = pl;
            command = cmd;

            InitializeComponent();

            int j = 0;
            Hashtable myParameters = new Hashtable(); 
            myParameters.Clear();
            for (int i = 0; i < parameters.Count; i++)
            {
                Parameter p = parameters[i];
                string s = "";

                j = 0;
                foreach (DictionaryEntry de in myParameters)
                {
                    if (de.Key.ToString().Trim().ToLower() == p.FullName.Trim().ToLower())
                    {
                        j = 1;
                        break;
                    }
                }
                if (j == 0)
                {
                    if (p.ComparedObject != "")
                    { s += p.ComparedObject + "."; }

                    if (p.ComparedField != "")
                    { s += p.ComparedField + " "; }

                    s += p.CompareOperator;

                    int row = dgvQueryParameters.Rows.Add();
                    dgvQueryParameters.Rows[row].Cells[0].Value = p.FullName;

                    dgvQueryParameters.Rows[row].Cells[1].Value = s;
                    dgvQueryParameters.Rows[row].Cells[2].Value = p.DataType.ToString();

                    myParameters.Add(p.FullName, p.DataType.ToString());

                }
            }
        }
    }
}
