namespace MIPATemp
{
    partial class Meniu_principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bIesire = new Button();
            bGE = new Button();
            bSE = new Button();
            bNou = new Button();
            bConectare = new Button();
            SuspendLayout();
            // 
            // bIesire
            // 
            bIesire.Location = new Point(50, 475);
            bIesire.Name = "bIesire";
            bIesire.Size = new Size(157, 66);
            bIesire.TabIndex = 0;
            bIesire.Text = "Iesire";
            bIesire.UseVisualStyleBackColor = true;
            bIesire.Click += bIesire_Click;
            // 
            // bGE
            // 
            bGE.Location = new Point(50, 300);
            bGE.Name = "bGE";
            bGE.Size = new Size(157, 110);
            bGE.TabIndex = 1;
            bGE.Text = "Existent";
            bGE.UseVisualStyleBackColor = true;
            // 
            // bSE
            // 
            bSE.Location = new Point(50, 175);
            bSE.Name = "bSE";
            bSE.Size = new Size(157, 110);
            bSE.TabIndex = 2;
            bSE.Text = "Sterge Existent";
            bSE.UseVisualStyleBackColor = true;
            // 
            // bNou
            // 
            bNou.Location = new Point(50, 50);
            bNou.Name = "bNou";
            bNou.Size = new Size(157, 110);
            bNou.TabIndex = 3;
            bNou.Text = "Nou";
            bNou.UseVisualStyleBackColor = true;
            bNou.Click += bNou_Click;
            // 
            // bConectare
            // 
            bConectare.Location = new Point(781, 475);
            bConectare.Name = "bConectare";
            bConectare.Size = new Size(157, 66);
            bConectare.TabIndex = 4;
            bConectare.Text = "Conectare";
            bConectare.UseVisualStyleBackColor = true;
            bConectare.Click += bConectare_Click;
            // 
            // Meniu_principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 611);
            Controls.Add(bConectare);
            Controls.Add(bNou);
            Controls.Add(bSE);
            Controls.Add(bGE);
            Controls.Add(bIesire);
            Name = "Meniu_principal";
            Text = "Meniu principal";
            ResumeLayout(false);
        }

        #endregion

        private Button bIesire;
        private Button bGE;
        private Button bSE;
        private Button bNou;
        private Button bConectare;
    }
}
