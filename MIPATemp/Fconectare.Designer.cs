namespace MIPATemp
{
    partial class Fconectare
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            t1Fcon = new TextBox();
            t2Fcon = new TextBox();
            t3Fcon = new TextBox();
            t4Fcon = new TextBox();
            bIesireFcon = new Button();
            bConFcon = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 43);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "server =";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 92);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 1;
            label2.Text = "id =";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 132);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 2;
            label3.Text = "parola =";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 169);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 3;
            label4.Text = "nume bd =";
            // 
            // t1Fcon
            // 
            t1Fcon.Location = new Point(150, 45);
            t1Fcon.Name = "t1Fcon";
            t1Fcon.Size = new Size(100, 23);
            t1Fcon.TabIndex = 4;
            // 
            // t2Fcon
            // 
            t2Fcon.Location = new Point(150, 84);
            t2Fcon.Name = "t2Fcon";
            t2Fcon.Size = new Size(100, 23);
            t2Fcon.TabIndex = 5;
            // 
            // t3Fcon
            // 
            t3Fcon.Location = new Point(150, 124);
            t3Fcon.Name = "t3Fcon";
            t3Fcon.Size = new Size(100, 23);
            t3Fcon.TabIndex = 6;
            // 
            // t4Fcon
            // 
            t4Fcon.Location = new Point(150, 161);
            t4Fcon.Name = "t4Fcon";
            t4Fcon.Size = new Size(100, 23);
            t4Fcon.TabIndex = 7;
            // 
            // bIesireFcon
            // 
            bIesireFcon.Location = new Point(121, 390);
            bIesireFcon.Name = "bIesireFcon";
            bIesireFcon.Size = new Size(84, 23);
            bIesireFcon.TabIndex = 8;
            bIesireFcon.Text = "Iesire";
            bIesireFcon.UseVisualStyleBackColor = true;
            bIesireFcon.Click += bIesireFcon_Click;
            // 
            // bConFcon
            // 
            bConFcon.Location = new Point(121, 347);
            bConFcon.Name = "bConFcon";
            bConFcon.Size = new Size(84, 23);
            bConFcon.TabIndex = 9;
            bConFcon.Text = "Conecteaza";
            bConFcon.UseVisualStyleBackColor = true;
            bConFcon.Click += bConFcon_Click;
            // 
            // Fconectare
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 450);
            Controls.Add(bConFcon);
            Controls.Add(bIesireFcon);
            Controls.Add(t4Fcon);
            Controls.Add(t3Fcon);
            Controls.Add(t2Fcon);
            Controls.Add(t1Fcon);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Fconectare";
            Text = "Fconectare";
            Load += Fconectare_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox t1Fcon;
        private TextBox t2Fcon;
        private TextBox t3Fcon;
        private TextBox t4Fcon;
        private Button bIesireFcon;
        private Button bConFcon;
    }
}