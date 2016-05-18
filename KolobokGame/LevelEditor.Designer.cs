namespace KolobokGame
{
    partial class LevelEditor
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_Wolf = new System.Windows.Forms.RadioButton();
            this.rb_Bear = new System.Windows.Forms.RadioButton();
            this.rb_Fox = new System.Windows.Forms.RadioButton();
            this.rb_Rabbit = new System.Windows.Forms.RadioButton();
            this.rb_Kolobok = new System.Windows.Forms.RadioButton();
            this.rb_Drug = new System.Windows.Forms.RadioButton();
            this.rb_Coin = new System.Windows.Forms.RadioButton();
            this.rb_MobStopper = new System.Windows.Forms.RadioButton();
            this.rb_Jumper = new System.Windows.Forms.RadioButton();
            this.rb_Remove = new System.Windows.Forms.RadioButton();
            this.rb_Move = new System.Windows.Forms.RadioButton();
            this.rb_Portal = new System.Windows.Forms.RadioButton();
            this.rb_movBlock = new System.Windows.Forms.RadioButton();
            this.rb_Block = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(841, 523);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_Wolf);
            this.groupBox1.Controls.Add(this.rb_Bear);
            this.groupBox1.Controls.Add(this.rb_Fox);
            this.groupBox1.Controls.Add(this.rb_Rabbit);
            this.groupBox1.Controls.Add(this.rb_Kolobok);
            this.groupBox1.Controls.Add(this.rb_Drug);
            this.groupBox1.Controls.Add(this.rb_Coin);
            this.groupBox1.Controls.Add(this.rb_MobStopper);
            this.groupBox1.Controls.Add(this.rb_Jumper);
            this.groupBox1.Controls.Add(this.rb_Remove);
            this.groupBox1.Controls.Add(this.rb_Move);
            this.groupBox1.Controls.Add(this.rb_Portal);
            this.groupBox1.Controls.Add(this.rb_movBlock);
            this.groupBox1.Controls.Add(this.rb_Block);
            this.groupBox1.Location = new System.Drawing.Point(848, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 315);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elements";
            // 
            // rb_Wolf
            // 
            this.rb_Wolf.AutoSize = true;
            this.rb_Wolf.Location = new System.Drawing.Point(6, 283);
            this.rb_Wolf.Name = "rb_Wolf";
            this.rb_Wolf.Size = new System.Drawing.Size(47, 17);
            this.rb_Wolf.TabIndex = 14;
            this.rb_Wolf.Text = "Wolf";
            this.rb_Wolf.UseVisualStyleBackColor = true;
            // 
            // rb_Bear
            // 
            this.rb_Bear.AutoSize = true;
            this.rb_Bear.Location = new System.Drawing.Point(6, 266);
            this.rb_Bear.Name = "rb_Bear";
            this.rb_Bear.Size = new System.Drawing.Size(47, 17);
            this.rb_Bear.TabIndex = 13;
            this.rb_Bear.Text = "Bear";
            this.rb_Bear.UseVisualStyleBackColor = true;
            // 
            // rb_Fox
            // 
            this.rb_Fox.AutoSize = true;
            this.rb_Fox.Location = new System.Drawing.Point(6, 249);
            this.rb_Fox.Name = "rb_Fox";
            this.rb_Fox.Size = new System.Drawing.Size(42, 17);
            this.rb_Fox.TabIndex = 12;
            this.rb_Fox.Text = "Fox";
            this.rb_Fox.UseVisualStyleBackColor = true;
            // 
            // rb_Rabbit
            // 
            this.rb_Rabbit.AutoSize = true;
            this.rb_Rabbit.Location = new System.Drawing.Point(5, 232);
            this.rb_Rabbit.Name = "rb_Rabbit";
            this.rb_Rabbit.Size = new System.Drawing.Size(56, 17);
            this.rb_Rabbit.TabIndex = 11;
            this.rb_Rabbit.Text = "Rabbit";
            this.rb_Rabbit.UseVisualStyleBackColor = true;
            // 
            // rb_Kolobok
            // 
            this.rb_Kolobok.AutoSize = true;
            this.rb_Kolobok.Location = new System.Drawing.Point(5, 215);
            this.rb_Kolobok.Name = "rb_Kolobok";
            this.rb_Kolobok.Size = new System.Drawing.Size(64, 17);
            this.rb_Kolobok.TabIndex = 10;
            this.rb_Kolobok.Text = "Kolobok";
            this.rb_Kolobok.UseVisualStyleBackColor = true;
            // 
            // rb_Drug
            // 
            this.rb_Drug.AutoSize = true;
            this.rb_Drug.Location = new System.Drawing.Point(6, 188);
            this.rb_Drug.Name = "rb_Drug";
            this.rb_Drug.Size = new System.Drawing.Size(48, 17);
            this.rb_Drug.TabIndex = 9;
            this.rb_Drug.Text = "Drug";
            this.rb_Drug.UseVisualStyleBackColor = true;
            // 
            // rb_Coin
            // 
            this.rb_Coin.AutoSize = true;
            this.rb_Coin.Location = new System.Drawing.Point(6, 171);
            this.rb_Coin.Name = "rb_Coin";
            this.rb_Coin.Size = new System.Drawing.Size(46, 17);
            this.rb_Coin.TabIndex = 8;
            this.rb_Coin.Text = "Coin";
            this.rb_Coin.UseVisualStyleBackColor = true;
            // 
            // rb_MobStopper
            // 
            this.rb_MobStopper.AutoSize = true;
            this.rb_MobStopper.Location = new System.Drawing.Point(6, 147);
            this.rb_MobStopper.Name = "rb_MobStopper";
            this.rb_MobStopper.Size = new System.Drawing.Size(83, 17);
            this.rb_MobStopper.TabIndex = 7;
            this.rb_MobStopper.Text = "MobStopper";
            this.rb_MobStopper.UseVisualStyleBackColor = true;
            // 
            // rb_Jumper
            // 
            this.rb_Jumper.AutoSize = true;
            this.rb_Jumper.Location = new System.Drawing.Point(6, 128);
            this.rb_Jumper.Name = "rb_Jumper";
            this.rb_Jumper.Size = new System.Drawing.Size(59, 17);
            this.rb_Jumper.TabIndex = 6;
            this.rb_Jumper.Text = "Jumper";
            this.rb_Jumper.UseVisualStyleBackColor = true;
            // 
            // rb_Remove
            // 
            this.rb_Remove.AutoSize = true;
            this.rb_Remove.Location = new System.Drawing.Point(5, 37);
            this.rb_Remove.Name = "rb_Remove";
            this.rb_Remove.Size = new System.Drawing.Size(71, 17);
            this.rb_Remove.TabIndex = 5;
            this.rb_Remove.Text = "REMOVE";
            this.rb_Remove.UseVisualStyleBackColor = true;
            // 
            // rb_Move
            // 
            this.rb_Move.AutoSize = true;
            this.rb_Move.Location = new System.Drawing.Point(5, 19);
            this.rb_Move.Name = "rb_Move";
            this.rb_Move.Size = new System.Drawing.Size(91, 17);
            this.rb_Move.TabIndex = 4;
            this.rb_Move.Text = "NAVIGATION";
            this.rb_Move.UseVisualStyleBackColor = true;
            // 
            // rb_Portal
            // 
            this.rb_Portal.AutoSize = true;
            this.rb_Portal.Location = new System.Drawing.Point(6, 109);
            this.rb_Portal.Name = "rb_Portal";
            this.rb_Portal.Size = new System.Drawing.Size(52, 17);
            this.rb_Portal.TabIndex = 3;
            this.rb_Portal.Text = "Portal\r\n";
            this.rb_Portal.UseVisualStyleBackColor = true;
            // 
            // rb_movBlock
            // 
            this.rb_movBlock.AutoSize = true;
            this.rb_movBlock.Location = new System.Drawing.Point(6, 91);
            this.rb_movBlock.Name = "rb_movBlock";
            this.rb_movBlock.Size = new System.Drawing.Size(90, 17);
            this.rb_movBlock.TabIndex = 2;
            this.rb_movBlock.Text = "Moving Block";
            this.rb_movBlock.UseVisualStyleBackColor = true;
            // 
            // rb_Block
            // 
            this.rb_Block.AutoSize = true;
            this.rb_Block.Location = new System.Drawing.Point(6, 73);
            this.rb_Block.Name = "rb_Block";
            this.rb_Block.Size = new System.Drawing.Size(52, 17);
            this.rb_Block.TabIndex = 0;
            this.rb_Block.Text = "Block";
            this.rb_Block.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 47);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Load Level";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "New Level";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 126);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(45, 17);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Grid";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(6, 14);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(57, 14);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown2.TabIndex = 9;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            this.numericUpDown2.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.numericUpDown2);
            this.groupBox2.Location = new System.Drawing.Point(6, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 44);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Size";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(848, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 153);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Menu";
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 525);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "LevelEditor";
            this.Text = "Kolobok Game Level Editor";
            this.Load += new System.EventHandler(this.LevelEditor_Load);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseWheel);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_Portal;
        private System.Windows.Forms.RadioButton rb_movBlock;
        private System.Windows.Forms.RadioButton rb_Block;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton rb_Move;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rb_Remove;
        private System.Windows.Forms.RadioButton rb_Wolf;
        private System.Windows.Forms.RadioButton rb_Bear;
        private System.Windows.Forms.RadioButton rb_Fox;
        private System.Windows.Forms.RadioButton rb_Rabbit;
        private System.Windows.Forms.RadioButton rb_Kolobok;
        private System.Windows.Forms.RadioButton rb_Drug;
        private System.Windows.Forms.RadioButton rb_Coin;
        private System.Windows.Forms.RadioButton rb_MobStopper;
        private System.Windows.Forms.RadioButton rb_Jumper;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}