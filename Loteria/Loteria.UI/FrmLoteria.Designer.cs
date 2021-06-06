
namespace Loteria.UI
{
    partial class FrmPrincipal
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
            this.CmdCalcular = new System.Windows.Forms.Button();
            this.TxtSorteios = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CmdCalcular
            // 
            this.CmdCalcular.Location = new System.Drawing.Point(0, 0);
            this.CmdCalcular.Name = "CmdCalcular";
            this.CmdCalcular.Size = new System.Drawing.Size(75, 23);
            this.CmdCalcular.TabIndex = 0;
            this.CmdCalcular.Text = "Calcular";
            this.CmdCalcular.UseVisualStyleBackColor = true;
            this.CmdCalcular.Click += new System.EventHandler(this.CmdCalcular_Click);
            // 
            // TxtSorteios
            // 
            this.TxtSorteios.Location = new System.Drawing.Point(0, 72);
            this.TxtSorteios.Name = "TxtSorteios";
            this.TxtSorteios.Size = new System.Drawing.Size(100, 20);
            this.TxtSorteios.TabIndex = 1;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TxtSorteios);
            this.Controls.Add(this.CmdCalcular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmPrincipal";
            this.Text = "Loteria";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdCalcular;
        private System.Windows.Forms.TextBox TxtSorteios;
    }
}

