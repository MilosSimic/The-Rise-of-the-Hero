namespace Lavirint
{
    partial class Main
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
            
            this.btnPrviUDubinu = new System.Windows.Forms.Button();
            
            this.btnPrviUSirinu = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
           
            this.btnAStar = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // btnPrviUDubinu
            // 
            this.btnPrviUDubinu.Location = new System.Drawing.Point(163, 384);
            this.btnPrviUDubinu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrviUDubinu.Name = "btnPrviUDubinu";
            this.btnPrviUDubinu.Size = new System.Drawing.Size(112, 25);
            this.btnPrviUDubinu.TabIndex = 3;
            this.btnPrviUDubinu.Text = "Heroj";
            this.btnPrviUDubinu.UseVisualStyleBackColor = true;
            this.btnPrviUDubinu.Click += new System.EventHandler(this.btnPrviUDubinu_Click);
            
            // 
            // btnPrviUSirinu
            // 
            this.btnPrviUSirinu.Location = new System.Drawing.Point(281, 384);
            this.btnPrviUSirinu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrviUSirinu.Name = "btnPrviUSirinu";
            this.btnPrviUSirinu.Size = new System.Drawing.Size(94, 23);
            this.btnPrviUSirinu.TabIndex = 6;
            this.btnPrviUSirinu.Text = "Masina";
            this.btnPrviUSirinu.UseVisualStyleBackColor = true;
            this.btnPrviUSirinu.Click += new System.EventHandler(this.btnPrviUSirinu_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(827, 25);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(99, 20);
            this.lblStatus.Text = "---------------";
           
            // 
            // displayPanel1
            // 
            this.displayPanel1.Location = new System.Drawing.Point(3, 2);
            this.displayPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.displayPanel1.Name = "displayPanel1";
            this.displayPanel1.Size = new System.Drawing.Size(816, 378);
            this.displayPanel1.TabIndex = 0;
            
            // 
            // btnAStar
            // 
            this.btnAStar.Location = new System.Drawing.Point(602, 384);
            this.btnAStar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAStar.Name = "btnAStar";
            this.btnAStar.Size = new System.Drawing.Size(97, 23);
            this.btnAStar.TabIndex = 10;
            this.btnAStar.Text = "A*";
            this.btnAStar.UseVisualStyleBackColor = true;
            this.btnAStar.Click += new System.EventHandler(this.btnAStar_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 444);
            this.Controls.Add(this.btnAStar);
            
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnPrviUSirinu);
           
            this.Controls.Add(this.btnPrviUDubinu);
            
            this.Controls.Add(this.displayPanel1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main";
            this.Text = "PRETRAGE Lavirint - Primer za vežbe iz predmeta ORI";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DisplayPanel displayPanel1 = DisplayPanel.INSTANCE;
       
        private System.Windows.Forms.Button btnPrviUDubinu;
        private System.Windows.Forms.Button btnPrviUSirinu;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnAStar;
    }
}

