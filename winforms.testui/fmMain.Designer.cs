namespace TestUI
{
    partial class fmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMain));
            this.tbxOutput = new System.Windows.Forms.TextBox();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.tbxEditor = new System.Windows.Forms.TextBox();
            this.lblResults = new System.Windows.Forms.Label();
            this.lblEditor = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.btnExecute1 = new System.Windows.Forms.Button();
            this.tbxUser = new System.Windows.Forms.TextBox();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tbxServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnExecute3 = new System.Windows.Forms.Button();
            this.btnExecute2 = new System.Windows.Forms.Button();
            this.btnExecute4 = new System.Windows.Forms.Button();
            this.chbProdServer = new System.Windows.Forms.CheckBox();
            this.btnTestJWT = new System.Windows.Forms.Button();
            this.btnTests = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxOutput
            // 
            this.tbxOutput.Location = new System.Drawing.Point(12, 384);
            this.tbxOutput.Multiline = true;
            this.tbxOutput.Name = "tbxOutput";
            this.tbxOutput.ReadOnly = true;
            this.tbxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxOutput.Size = new System.Drawing.Size(1106, 142);
            this.tbxOutput.TabIndex = 0;
            // 
            // tbxResult
            // 
            this.tbxResult.Location = new System.Drawing.Point(12, 30);
            this.tbxResult.Multiline = true;
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.ReadOnly = true;
            this.tbxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxResult.Size = new System.Drawing.Size(550, 245);
            this.tbxResult.TabIndex = 1;
            // 
            // tbxEditor
            // 
            this.tbxEditor.Location = new System.Drawing.Point(568, 30);
            this.tbxEditor.Multiline = true;
            this.tbxEditor.Name = "tbxEditor";
            this.tbxEditor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxEditor.Size = new System.Drawing.Size(550, 245);
            this.tbxEditor.TabIndex = 2;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResults.Location = new System.Drawing.Point(9, 9);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(65, 18);
            this.lblResults.TabIndex = 3;
            this.lblResults.Text = "Results";
            // 
            // lblEditor
            // 
            this.lblEditor.AutoSize = true;
            this.lblEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblEditor.Location = new System.Drawing.Point(565, 9);
            this.lblEditor.Name = "lblEditor";
            this.lblEditor.Size = new System.Drawing.Size(53, 18);
            this.lblEditor.TabIndex = 4;
            this.lblEditor.Text = "Editor";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOutput.Location = new System.Drawing.Point(8, 362);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(58, 18);
            this.lblOutput.TabIndex = 5;
            this.lblOutput.Text = "Output";
            // 
            // btnExecute1
            // 
            this.btnExecute1.Location = new System.Drawing.Point(998, 283);
            this.btnExecute1.Name = "btnExecute1";
            this.btnExecute1.Size = new System.Drawing.Size(120, 23);
            this.btnExecute1.TabIndex = 6;
            this.btnExecute1.Text = "PublicKey()";
            this.btnExecute1.UseVisualStyleBackColor = true;
            this.btnExecute1.Click += new System.EventHandler(this.btnExecute1_Click);
            // 
            // tbxUser
            // 
            this.tbxUser.Location = new System.Drawing.Point(11, 338);
            this.tbxUser.Name = "tbxUser";
            this.tbxUser.Size = new System.Drawing.Size(200, 20);
            this.tbxUser.TabIndex = 7;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(217, 338);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.Size = new System.Drawing.Size(200, 20);
            this.tbxPassword.TabIndex = 8;
            // 
            // tbxServer
            // 
            this.tbxServer.Location = new System.Drawing.Point(11, 299);
            this.tbxServer.Name = "tbxServer";
            this.tbxServer.Size = new System.Drawing.Size(406, 20);
            this.tbxServer.TabIndex = 9;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblServer.Location = new System.Drawing.Point(8, 283);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(44, 13);
            this.lblServer.TabIndex = 10;
            this.lblServer.Text = "Server";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUser.Location = new System.Drawing.Point(8, 322);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(33, 13);
            this.lblUser.TabIndex = 11;
            this.lblUser.Text = "User";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPassword.Location = new System.Drawing.Point(214, 322);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Password";
            // 
            // btnExecute3
            // 
            this.btnExecute3.Location = new System.Drawing.Point(694, 283);
            this.btnExecute3.Name = "btnExecute3";
            this.btnExecute3.Size = new System.Drawing.Size(120, 23);
            this.btnExecute3.TabIndex = 13;
            this.btnExecute3.Text = "RegisterClient()";
            this.btnExecute3.UseVisualStyleBackColor = true;
            this.btnExecute3.Click += new System.EventHandler(this.btnExecute3_Click);
            // 
            // btnExecute2
            // 
            this.btnExecute2.Location = new System.Drawing.Point(568, 283);
            this.btnExecute2.Name = "btnExecute2";
            this.btnExecute2.Size = new System.Drawing.Size(120, 23);
            this.btnExecute2.TabIndex = 14;
            this.btnExecute2.Text = "IsSpammer()";
            this.btnExecute2.UseVisualStyleBackColor = true;
            this.btnExecute2.Click += new System.EventHandler(this.btnExecute2_Click);
            // 
            // btnExecute4
            // 
            this.btnExecute4.Location = new System.Drawing.Point(820, 283);
            this.btnExecute4.Name = "btnExecute4";
            this.btnExecute4.Size = new System.Drawing.Size(120, 23);
            this.btnExecute4.TabIndex = 15;
            this.btnExecute4.Text = "Complain()";
            this.btnExecute4.UseVisualStyleBackColor = true;
            this.btnExecute4.Click += new System.EventHandler(this.btnExecute4_Click);
            // 
            // chbProdServer
            // 
            this.chbProdServer.AutoSize = true;
            this.chbProdServer.Location = new System.Drawing.Point(998, 322);
            this.chbProdServer.Name = "chbProdServer";
            this.chbProdServer.Size = new System.Drawing.Size(82, 17);
            this.chbProdServer.TabIndex = 16;
            this.chbProdServer.Text = "Prod Server";
            this.chbProdServer.UseVisualStyleBackColor = true;
            // 
            // btnTestJWT
            // 
            this.btnTestJWT.Location = new System.Drawing.Point(568, 313);
            this.btnTestJWT.Name = "btnTestJWT";
            this.btnTestJWT.Size = new System.Drawing.Size(246, 23);
            this.btnTestJWT.TabIndex = 17;
            this.btnTestJWT.Text = "Test JWT (paste token in Editor)";
            this.btnTestJWT.UseVisualStyleBackColor = true;
            this.btnTestJWT.Click += new System.EventHandler(this.btnTestJWT_Click);
            // 
            // btnTests
            // 
            this.btnTests.Location = new System.Drawing.Point(820, 313);
            this.btnTests.Name = "btnTests";
            this.btnTests.Size = new System.Drawing.Size(120, 23);
            this.btnTests.TabIndex = 18;
            this.btnTests.Text = "Tests";
            this.btnTests.UseVisualStyleBackColor = true;
            this.btnTests.Click += new System.EventHandler(this.btnTests_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(863, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "TokenTest";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(568, 342);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Test log";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 539);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTests);
            this.Controls.Add(this.btnTestJWT);
            this.Controls.Add(this.chbProdServer);
            this.Controls.Add(this.btnExecute4);
            this.Controls.Add(this.btnExecute2);
            this.Controls.Add(this.btnExecute3);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblServer);
            this.Controls.Add(this.tbxServer);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.tbxUser);
            this.Controls.Add(this.btnExecute1);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lblEditor);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.tbxEditor);
            this.Controls.Add(this.tbxResult);
            this.Controls.Add(this.tbxOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test UI";
            this.Load += new System.EventHandler(this.fmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxOutput;
        private System.Windows.Forms.TextBox tbxResult;
        private System.Windows.Forms.TextBox tbxEditor;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Label lblEditor;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button btnExecute1;
        private System.Windows.Forms.TextBox tbxUser;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.TextBox tbxServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnExecute3;
        private System.Windows.Forms.Button btnExecute2;
        private System.Windows.Forms.Button btnExecute4;
        private System.Windows.Forms.CheckBox chbProdServer;
        private System.Windows.Forms.Button btnTestJWT;
        private System.Windows.Forms.Button btnTests;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}