namespace SuperGen
{
    partial class AbilityForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbilityForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.intNameBox = new System.Windows.Forms.TextBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.descBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.NumericUpDown();
            this.addAbilityBtn = new System.Windows.Forms.Button();
            this.removeAbilityBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internalNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byDescriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.overwriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAbilitiestxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internalNameFinderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abilityBox = new System.Windows.Forms.ListBox();
            this.idTip = new System.Windows.Forms.ToolTip(this.components);
            this.nameTip = new System.Windows.Forms.ToolTip(this.components);
            this.intNameTip = new System.Windows.Forms.ToolTip(this.components);
            this.descTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.idBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(185, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(185, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Int. Name:";
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            // 
            // intNameBox
            // 
            this.intNameBox.Enabled = false;
            this.intNameBox.Location = new System.Drawing.Point(268, 96);
            this.intNameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.intNameBox.Name = "intNameBox";
            this.intNameBox.Size = new System.Drawing.Size(132, 25);
            this.intNameBox.TabIndex = 3;
            this.intNameBox.TextChanged += new System.EventHandler(this.intNameBox_TextChanged);
            // 
            // nameBox
            // 
            this.nameBox.Enabled = false;
            this.nameBox.Location = new System.Drawing.Point(268, 63);
            this.nameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(132, 25);
            this.nameBox.TabIndex = 4;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(185, 179);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description:";
            this.label3.MouseHover += new System.EventHandler(this.label3_MouseHover);
            // 
            // descBox
            // 
            this.descBox.Enabled = false;
            this.descBox.Location = new System.Drawing.Point(268, 126);
            this.descBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.descBox.Name = "descBox";
            this.descBox.Size = new System.Drawing.Size(132, 126);
            this.descBox.TabIndex = 6;
            this.descBox.Text = "";
            this.descBox.TextChanged += new System.EventHandler(this.descBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(185, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "ID:";
            this.label4.MouseHover += new System.EventHandler(this.label4_MouseHover);
            // 
            // idBox
            // 
            this.idBox.Enabled = false;
            this.idBox.Location = new System.Drawing.Point(268, 33);
            this.idBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.idBox.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(56, 25);
            this.idBox.TabIndex = 9;
            this.idBox.ValueChanged += new System.EventHandler(this.idBox_ValueChanged);
            // 
            // addAbilityBtn
            // 
            this.addAbilityBtn.Location = new System.Drawing.Point(16, 203);
            this.addAbilityBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addAbilityBtn.Name = "addAbilityBtn";
            this.addAbilityBtn.Size = new System.Drawing.Size(161, 27);
            this.addAbilityBtn.TabIndex = 10;
            this.addAbilityBtn.Text = "Add Ability";
            this.addAbilityBtn.UseVisualStyleBackColor = true;
            this.addAbilityBtn.Click += new System.EventHandler(this.addAbilityBtn_Click);
            // 
            // removeAbilityBtn
            // 
            this.removeAbilityBtn.Location = new System.Drawing.Point(16, 228);
            this.removeAbilityBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.removeAbilityBtn.Name = "removeAbilityBtn";
            this.removeAbilityBtn.Size = new System.Drawing.Size(161, 27);
            this.removeAbilityBtn.TabIndex = 11;
            this.removeAbilityBtn.Text = "Remove Ability";
            this.removeAbilityBtn.UseVisualStyleBackColor = true;
            this.removeAbilityBtn.Click += new System.EventHandler(this.removeAbilityBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.moreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(406, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byIDToolStripMenuItem,
            this.byNameToolStripMenuItem,
            this.byDescriptionToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.sortToolStripMenuItem.Text = "Sort";
            // 
            // byIDToolStripMenuItem
            // 
            this.byIDToolStripMenuItem.Name = "byIDToolStripMenuItem";
            this.byIDToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.byIDToolStripMenuItem.Text = "By ID";
            this.byIDToolStripMenuItem.Click += new System.EventHandler(this.byIDToolStripMenuItem_Click);
            // 
            // byNameToolStripMenuItem
            // 
            this.byNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayNameToolStripMenuItem,
            this.internalNameToolStripMenuItem});
            this.byNameToolStripMenuItem.Name = "byNameToolStripMenuItem";
            this.byNameToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.byNameToolStripMenuItem.Text = "By Name";
            // 
            // displayNameToolStripMenuItem
            // 
            this.displayNameToolStripMenuItem.Name = "displayNameToolStripMenuItem";
            this.displayNameToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.displayNameToolStripMenuItem.Text = "Display Name";
            this.displayNameToolStripMenuItem.Click += new System.EventHandler(this.displayNameToolStripMenuItem_Click);
            // 
            // internalNameToolStripMenuItem
            // 
            this.internalNameToolStripMenuItem.Name = "internalNameToolStripMenuItem";
            this.internalNameToolStripMenuItem.Size = new System.Drawing.Size(194, 26);
            this.internalNameToolStripMenuItem.Text = "Internal Name";
            this.internalNameToolStripMenuItem.Click += new System.EventHandler(this.internalNameToolStripMenuItem_Click);
            // 
            // byDescriptionToolStripMenuItem
            // 
            this.byDescriptionToolStripMenuItem.Name = "byDescriptionToolStripMenuItem";
            this.byDescriptionToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.byDescriptionToolStripMenuItem.Text = "By Description";
            this.byDescriptionToolStripMenuItem.Click += new System.EventHandler(this.byDescriptionToolStripMenuItem_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedToolStripMenuItem,
            this.allToolStripMenuItem});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.generateToolStripMenuItem.Text = "Generate";
            // 
            // selectedToolStripMenuItem
            // 
            this.selectedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem1,
            this.exportToolStripMenuItem});
            this.selectedToolStripMenuItem.Name = "selectedToolStripMenuItem";
            this.selectedToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.selectedToolStripMenuItem.Text = "Selected";
            // 
            // generateToolStripMenuItem1
            // 
            this.generateToolStripMenuItem1.Name = "generateToolStripMenuItem1";
            this.generateToolStripMenuItem1.Size = new System.Drawing.Size(159, 26);
            this.generateToolStripMenuItem1.Text = "Generate";
            this.generateToolStripMenuItem1.Click += new System.EventHandler(this.generateToolStripMenuItem1_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateToolStripMenuItem2,
            this.exportToolStripMenuItem1,
            this.overwriteToolStripMenuItem});
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.allToolStripMenuItem.Text = "All";
            // 
            // generateToolStripMenuItem2
            // 
            this.generateToolStripMenuItem2.Name = "generateToolStripMenuItem2";
            this.generateToolStripMenuItem2.Size = new System.Drawing.Size(164, 26);
            this.generateToolStripMenuItem2.Text = "Generate";
            this.generateToolStripMenuItem2.Click += new System.EventHandler(this.generateToolStripMenuItem2_Click);
            // 
            // exportToolStripMenuItem1
            // 
            this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
            this.exportToolStripMenuItem1.Size = new System.Drawing.Size(164, 26);
            this.exportToolStripMenuItem1.Text = "Export";
            this.exportToolStripMenuItem1.Click += new System.EventHandler(this.exportToolStripMenuItem1_Click);
            // 
            // overwriteToolStripMenuItem
            // 
            this.overwriteToolStripMenuItem.Name = "overwriteToolStripMenuItem";
            this.overwriteToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.overwriteToolStripMenuItem.Text = "Overwrite";
            this.overwriteToolStripMenuItem.Click += new System.EventHandler(this.overwriteToolStripMenuItem_Click);
            // 
            // moreToolStripMenuItem
            // 
            this.moreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openAbilitiestxtToolStripMenuItem,
            this.internalNameFinderToolStripMenuItem,
            this.reloadDataToolStripMenuItem});
            this.moreToolStripMenuItem.Name = "moreToolStripMenuItem";
            this.moreToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.moreToolStripMenuItem.Text = "More";
            // 
            // openAbilitiestxtToolStripMenuItem
            // 
            this.openAbilitiestxtToolStripMenuItem.Name = "openAbilitiestxtToolStripMenuItem";
            this.openAbilitiestxtToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.openAbilitiestxtToolStripMenuItem.Text = "Open abilities.txt";
            this.openAbilitiestxtToolStripMenuItem.Click += new System.EventHandler(this.openAbilitiestxtToolStripMenuItem_Click);
            // 
            // internalNameFinderToolStripMenuItem
            // 
            this.internalNameFinderToolStripMenuItem.Name = "internalNameFinderToolStripMenuItem";
            this.internalNameFinderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.internalNameFinderToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.internalNameFinderToolStripMenuItem.Text = "Find Internal Name";
            this.internalNameFinderToolStripMenuItem.Click += new System.EventHandler(this.internalNameFinderToolStripMenuItem_Click);
            // 
            // reloadDataToolStripMenuItem
            // 
            this.reloadDataToolStripMenuItem.Name = "reloadDataToolStripMenuItem";
            this.reloadDataToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.reloadDataToolStripMenuItem.Text = "Reload Data";
            this.reloadDataToolStripMenuItem.Click += new System.EventHandler(this.reloadDataToolStripMenuItem_Click);
            // 
            // abilityBox
            // 
            this.abilityBox.FormattingEnabled = true;
            this.abilityBox.ItemHeight = 15;
            this.abilityBox.Location = new System.Drawing.Point(17, 33);
            this.abilityBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.abilityBox.Name = "abilityBox";
            this.abilityBox.Size = new System.Drawing.Size(159, 169);
            this.abilityBox.TabIndex = 13;
            this.abilityBox.SelectedIndexChanged += new System.EventHandler(this.abilityBox_SelectedIndexChanged);
            // 
            // idTip
            // 
            this.idTip.AutomaticDelay = 50;
            this.idTip.AutoPopDelay = 0;
            this.idTip.InitialDelay = 50;
            this.idTip.ReshowDelay = 10;
            this.idTip.ToolTipTitle = "ID";
            // 
            // nameTip
            // 
            this.nameTip.AutomaticDelay = 50;
            this.nameTip.AutoPopDelay = 0;
            this.nameTip.InitialDelay = 50;
            this.nameTip.ReshowDelay = 10;
            this.nameTip.ToolTipTitle = "Display Name";
            // 
            // intNameTip
            // 
            this.intNameTip.AutomaticDelay = 50;
            this.intNameTip.AutoPopDelay = 0;
            this.intNameTip.InitialDelay = 50;
            this.intNameTip.ReshowDelay = 10;
            this.intNameTip.ToolTipTitle = "Internal Name";
            // 
            // descTip
            // 
            this.descTip.AutomaticDelay = 50;
            this.descTip.AutoPopDelay = 0;
            this.descTip.InitialDelay = 50;
            this.descTip.ReshowDelay = 10;
            this.descTip.ToolTipTitle = "Description";
            // 
            // AbilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 259);
            this.Controls.Add(this.abilityBox);
            this.Controls.Add(this.removeAbilityBtn);
            this.Controls.Add(this.addAbilityBtn);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.descBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.intNameBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(424, 306);
            this.MinimumSize = new System.Drawing.Size(424, 306);
            this.Name = "AbilityForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ability Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AbilityForm_FormClosing);
            this.Load += new System.EventHandler(this.AbilityForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.idBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox intNameBox;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox descBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown idBox;
        private System.Windows.Forms.Button addAbilityBtn;
        private System.Windows.Forms.Button removeAbilityBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem overwriteToolStripMenuItem;
        private System.Windows.Forms.ListBox abilityBox;
        private System.Windows.Forms.ToolStripMenuItem byIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internalNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byDescriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAbilitiestxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internalNameFinderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadDataToolStripMenuItem;
        private System.Windows.Forms.ToolTip idTip;
        private System.Windows.Forms.ToolTip nameTip;
        private System.Windows.Forms.ToolTip intNameTip;
        private System.Windows.Forms.ToolTip descTip;
    }
}