namespace AGE.Views
{
    partial class Configuracao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtEmailAdmin = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDpwEmail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblDpwEmail = new MaterialSkin.Controls.MaterialLabel();
            this.txtDpwCPNJ = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDpwURL = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.txtDpwUsuario = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtDpwSenha = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialRaisedButton2 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.chkModoDebug = new System.Windows.Forms.CheckBox();
            this.materialTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(1, 65);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(797, 39);
            this.materialTabSelector1.TabIndex = 0;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Location = new System.Drawing.Point(1, 110);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(797, 328);
            this.materialTabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Snow;
            this.tabPage2.Controls.Add(this.materialLabel6);
            this.tabPage2.Controls.Add(this.chkModoDebug);
            this.tabPage2.Controls.Add(this.txtEmailAdmin);
            this.tabPage2.Controls.Add(this.materialLabel4);
            this.tabPage2.Controls.Add(this.txtDpwEmail);
            this.tabPage2.Controls.Add(this.lblDpwEmail);
            this.tabPage2.Controls.Add(this.txtDpwCPNJ);
            this.tabPage2.Controls.Add(this.materialLabel3);
            this.tabPage2.Controls.Add(this.materialRaisedButton1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(789, 302);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Geral";
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(683, 4);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(104, 35);
            this.materialRaisedButton1.TabIndex = 14;
            this.materialRaisedButton1.Text = "Salvar";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Snow;
            this.tabPage1.Controls.Add(this.materialRaisedButton2);
            this.tabPage1.Controls.Add(this.txtDpwURL);
            this.tabPage1.Controls.Add(this.materialLabel5);
            this.tabPage1.Controls.Add(this.txtDpwUsuario);
            this.tabPage1.Controls.Add(this.txtDpwSenha);
            this.tabPage1.Controls.Add(this.materialLabel2);
            this.tabPage1.Controls.Add(this.materialLabel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(789, 302);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "DPWS";
            // 
            // txtEmailAdmin
            // 
            this.txtEmailAdmin.Depth = 0;
            this.txtEmailAdmin.Hint = "Separar por virgula";
            this.txtEmailAdmin.Location = new System.Drawing.Point(126, 123);
            this.txtEmailAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmailAdmin.Name = "txtEmailAdmin";
            this.txtEmailAdmin.PasswordChar = '\0';
            this.txtEmailAdmin.SelectedText = "";
            this.txtEmailAdmin.SelectionLength = 0;
            this.txtEmailAdmin.SelectionStart = 0;
            this.txtEmailAdmin.Size = new System.Drawing.Size(565, 23);
            this.txtEmailAdmin.TabIndex = 24;
            this.txtEmailAdmin.UseSystemPasswordChar = false;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(12, 127);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(96, 19);
            this.materialLabel4.TabIndex = 25;
            this.materialLabel4.Text = "Email admin:";
            // 
            // txtDpwEmail
            // 
            this.txtDpwEmail.Depth = 0;
            this.txtDpwEmail.Hint = "Separar por virgula";
            this.txtDpwEmail.Location = new System.Drawing.Point(126, 89);
            this.txtDpwEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDpwEmail.Name = "txtDpwEmail";
            this.txtDpwEmail.PasswordChar = '\0';
            this.txtDpwEmail.SelectedText = "";
            this.txtDpwEmail.SelectionLength = 0;
            this.txtDpwEmail.SelectionStart = 0;
            this.txtDpwEmail.Size = new System.Drawing.Size(565, 23);
            this.txtDpwEmail.TabIndex = 22;
            this.txtDpwEmail.UseSystemPasswordChar = false;
            // 
            // lblDpwEmail
            // 
            this.lblDpwEmail.AutoSize = true;
            this.lblDpwEmail.Depth = 0;
            this.lblDpwEmail.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblDpwEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblDpwEmail.Location = new System.Drawing.Point(12, 93);
            this.lblDpwEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblDpwEmail.Name = "lblDpwEmail";
            this.lblDpwEmail.Size = new System.Drawing.Size(51, 19);
            this.lblDpwEmail.TabIndex = 23;
            this.lblDpwEmail.Text = "Email:";
            // 
            // txtDpwCPNJ
            // 
            this.txtDpwCPNJ.Depth = 0;
            this.txtDpwCPNJ.Hint = "";
            this.txtDpwCPNJ.Location = new System.Drawing.Point(126, 47);
            this.txtDpwCPNJ.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDpwCPNJ.Name = "txtDpwCPNJ";
            this.txtDpwCPNJ.PasswordChar = '\0';
            this.txtDpwCPNJ.SelectedText = "";
            this.txtDpwCPNJ.SelectionLength = 0;
            this.txtDpwCPNJ.SelectionStart = 0;
            this.txtDpwCPNJ.Size = new System.Drawing.Size(325, 23);
            this.txtDpwCPNJ.TabIndex = 20;
            this.txtDpwCPNJ.UseSystemPasswordChar = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(12, 51);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(51, 19);
            this.materialLabel3.TabIndex = 21;
            this.materialLabel3.Text = "CNPJ:";
            // 
            // txtDpwURL
            // 
            this.txtDpwURL.Depth = 0;
            this.txtDpwURL.Hint = "";
            this.txtDpwURL.Location = new System.Drawing.Point(112, 45);
            this.txtDpwURL.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDpwURL.Name = "txtDpwURL";
            this.txtDpwURL.PasswordChar = '\0';
            this.txtDpwURL.SelectedText = "";
            this.txtDpwURL.SelectionLength = 0;
            this.txtDpwURL.SelectionStart = 0;
            this.txtDpwURL.Size = new System.Drawing.Size(565, 23);
            this.txtDpwURL.TabIndex = 13;
            this.txtDpwURL.UseSystemPasswordChar = false;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(10, 45);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(40, 19);
            this.materialLabel5.TabIndex = 12;
            this.materialLabel5.Text = "URL:";
            // 
            // txtDpwUsuario
            // 
            this.txtDpwUsuario.Depth = 0;
            this.txtDpwUsuario.Hint = "";
            this.txtDpwUsuario.Location = new System.Drawing.Point(112, 71);
            this.txtDpwUsuario.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDpwUsuario.Name = "txtDpwUsuario";
            this.txtDpwUsuario.PasswordChar = '\0';
            this.txtDpwUsuario.SelectedText = "";
            this.txtDpwUsuario.SelectionLength = 0;
            this.txtDpwUsuario.SelectionStart = 0;
            this.txtDpwUsuario.Size = new System.Drawing.Size(325, 23);
            this.txtDpwUsuario.TabIndex = 9;
            this.txtDpwUsuario.UseSystemPasswordChar = false;
            // 
            // txtDpwSenha
            // 
            this.txtDpwSenha.Depth = 0;
            this.txtDpwSenha.Hint = "";
            this.txtDpwSenha.Location = new System.Drawing.Point(112, 97);
            this.txtDpwSenha.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtDpwSenha.Name = "txtDpwSenha";
            this.txtDpwSenha.PasswordChar = '\0';
            this.txtDpwSenha.SelectedText = "";
            this.txtDpwSenha.SelectionLength = 0;
            this.txtDpwSenha.SelectionStart = 0;
            this.txtDpwSenha.Size = new System.Drawing.Size(325, 23);
            this.txtDpwSenha.TabIndex = 10;
            this.txtDpwSenha.UseSystemPasswordChar = true;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(10, 97);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(54, 19);
            this.materialLabel2.TabIndex = 11;
            this.materialLabel2.Text = "Senha:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(10, 71);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(65, 19);
            this.materialLabel1.TabIndex = 8;
            this.materialLabel1.Text = "Usuário:";
            // 
            // materialRaisedButton2
            // 
            this.materialRaisedButton2.Depth = 0;
            this.materialRaisedButton2.Location = new System.Drawing.Point(679, 6);
            this.materialRaisedButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton2.Name = "materialRaisedButton2";
            this.materialRaisedButton2.Primary = true;
            this.materialRaisedButton2.Size = new System.Drawing.Size(104, 35);
            this.materialRaisedButton2.TabIndex = 15;
            this.materialRaisedButton2.Text = "Salvar";
            this.materialRaisedButton2.UseVisualStyleBackColor = true;
            this.materialRaisedButton2.Click += new System.EventHandler(this.materialRaisedButton2_Click);
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(14, 163);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(94, 19);
            this.materialLabel6.TabIndex = 27;
            this.materialLabel6.Text = "Modo Debug";
            // 
            // chkModoDebug
            // 
            this.chkModoDebug.AutoSize = true;
            this.chkModoDebug.Location = new System.Drawing.Point(116, 168);
            this.chkModoDebug.Name = "chkModoDebug";
            this.chkModoDebug.Size = new System.Drawing.Size(15, 14);
            this.chkModoDebug.TabIndex = 26;
            this.chkModoDebug.UseVisualStyleBackColor = true;
            // 
            // Configuracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.materialTabControl1);
            this.Controls.Add(this.materialTabSelector1);
            this.Name = "Configuracao";
            this.Text = "Configuracao";
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private System.Windows.Forms.TabPage tabPage1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEmailAdmin;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDpwEmail;
        private MaterialSkin.Controls.MaterialLabel lblDpwEmail;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDpwCPNJ;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDpwURL;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDpwUsuario;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtDpwSenha;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.CheckBox chkModoDebug;
    }
}