using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AGE.Views
{
    public partial class Configuracao : MaterialSkin.Controls.MaterialForm
    {
        private XmlDocument aXmlDoc = new XmlDocument();
        public Configuracao()
        {
            InitializeComponent();
            aXmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            txtDpwUsuario.Text = aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='usuarioDPW']").Attributes["value"].Value;
            txtDpwSenha.Text = aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='senhaDPW']").Attributes["value"].Value;
            txtDpwURL.Text = aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='urlDPW']").Attributes["value"].Value;
            txtDpwEmail.Text = aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='bussinessExceptionEmail']").Attributes["value"].Value;
            var lCNPJ = aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='cnpjTransportadora']").Attributes["value"].Value;
            txtDpwCPNJ.Text = Convert.ToUInt64(lCNPJ).ToString(@"00\.000\.000\/0000\-00");
            txtEmailAdmin.Text = aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='AdminEmail']").Attributes["value"].Value;
            chkModoDebug.Checked = bool.Parse(aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='modeDebug']").Attributes["value"].Value);
        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {

        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='bussinessExceptionEmail']").Attributes["value"].Value = txtDpwEmail.Text;
                var lCNPJ = txtDpwCPNJ.Text;
                lCNPJ = String.Join("", System.Text.RegularExpressions.Regex.Split(lCNPJ, @"[^\d]"));
                aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='cnpjTransportadora']").Attributes["value"].Value = lCNPJ;
                aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='AdminEmail']").Attributes["value"].Value = txtEmailAdmin.Text;
                aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='modeDebug']").Attributes["value"].Value = chkModoDebug.Checked ? "true" : "false";
                
                aXmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                MessageBox.Show("Configuração salva", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch { }
        }

        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='usuarioDPW']").Attributes["value"].Value = txtDpwUsuario.Text;
            aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='senhaDPW']").Attributes["value"].Value = txtDpwSenha.Text;
            aXmlDoc.SelectSingleNode("//configuration/appSettings/add[@key='urlDPW']").Attributes["value"].Value = txtDpwURL.Text;

            aXmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            MessageBox.Show("Configuração salva", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();

        }
    }
}
