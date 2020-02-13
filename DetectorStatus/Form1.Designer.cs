namespace TrainerExample
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.loolproc = new System.Windows.Forms.Label();
            this.procText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // loolproc
            // 
            this.loolproc.AutoSize = true;
            this.loolproc.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loolproc.ForeColor = System.Drawing.Color.DarkRed;
            this.loolproc.Location = new System.Drawing.Point(12, 9);
            this.loolproc.Name = "loolproc";
            this.loolproc.Size = new System.Drawing.Size(287, 17);
            this.loolproc.TabIndex = 0;
            this.loolproc.Text = "Process (TEXTBOX): Not Running ";
            // 
            // procText
            // 
            this.procText.Location = new System.Drawing.Point(15, 29);
            this.procText.Name = "procText";
            this.procText.Size = new System.Drawing.Size(284, 20);
            this.procText.TabIndex = 1;
            this.procText.TextChanged += new System.EventHandler(this.ProcText_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 78);
            this.Controls.Add(this.procText);
            this.Controls.Add(this.loolproc);
            this.Name = "Form1";
            this.Text = "DetectExample by Skofos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label loolproc;
        private System.Windows.Forms.TextBox procText;
    }
}

