namespace SuperGen
{
    partial class TrainerClassForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainerClassForm));
            this.classBox = new System.Windows.Forms.ListBox();
            this.addClassBtn = new System.Windows.Forms.Button();
            this.removeClassBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internalNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byMoneyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byBGMusicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byVictoryMusicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byIntroMusicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byGenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bySkillToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.overwriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTrainertypestxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findInternalNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.intnameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.moneyBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.defaultMoney = new System.Windows.Forms.CheckBox();
            this.requiredFields = new System.Windows.Forms.GroupBox();
            this.optionalFields = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.skillBox = new System.Windows.Forms.NumericUpDown();
            this.defaultSkill = new System.Windows.Forms.CheckBox();
            this.defaultGender = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.genderBox = new System.Windows.Forms.ComboBox();
            this.defaultIntroMusic = new System.Windows.Forms.CheckBox();
            this.browseIntroMusic = new System.Windows.Forms.Button();
            this.introMusic = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.defaultVictoryMusic = new System.Windows.Forms.CheckBox();
            this.browseVictoryMusic = new System.Windows.Forms.Button();
            this.victoryMusic = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.defaultBGMusic = new System.Windows.Forms.CheckBox();
            this.browseBGMusic = new System.Windows.Forms.Button();
            this.bgMusic = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.volumeBox = new System.Windows.Forms.NumericUpDown();
            this.intNameTip = new System.Windows.Forms.ToolTip(this.components);
            this.nameTip = new System.Windows.Forms.ToolTip(this.components);
            this.idTip = new System.Windows.Forms.ToolTip(this.components);
            this.baseMoneyTip = new System.Windows.Forms.ToolTip(this.components);
            this.bgMusicTip = new System.Windows.Forms.ToolTip(this.components);
            this.victoryMusicTip = new System.Windows.Forms.ToolTip(this.components);
            this.introMusicTip = new System.Windows.Forms.ToolTip(this.components);
            this.genderTip = new System.Windows.Forms.ToolTip(this.components);
            this.skillLevelTip = new System.Windows.Forms.ToolTip(this.components);
            this.volumeTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.musicToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyBox)).BeginInit();
            this.requiredFields.SuspendLayout();
            this.optionalFields.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skillBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // classBox
            // 
            this.classBox.FormattingEnabled = true;
            this.classBox.ItemHeight = 15;
            this.classBox.Location = new System.Drawing.Point(16, 29);
            this.classBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.classBox.Name = "classBox";
            this.classBox.Size = new System.Drawing.Size(239, 274);
            this.classBox.TabIndex = 0;
            this.classBox.SelectedIndexChanged += new System.EventHandler(this.classBox_SelectedIndexChanged);
            // 
            // addClassBtn
            // 
            this.addClassBtn.Location = new System.Drawing.Point(16, 309);
            this.addClassBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addClassBtn.Name = "addClassBtn";
            this.addClassBtn.Size = new System.Drawing.Size(240, 27);
            this.addClassBtn.TabIndex = 1;
            this.addClassBtn.Text = "Add Trainer Class";
            this.addClassBtn.UseVisualStyleBackColor = true;
            this.addClassBtn.Click += new System.EventHandler(this.addClassBtn_Click);
            // 
            // removeClassBtn
            // 
            this.removeClassBtn.Location = new System.Drawing.Point(15, 337);
            this.removeClassBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.removeClassBtn.Name = "removeClassBtn";
            this.removeClassBtn.Size = new System.Drawing.Size(240, 27);
            this.removeClassBtn.TabIndex = 2;
            this.removeClassBtn.Text = "Remove Trainer Class";
            this.removeClassBtn.UseVisualStyleBackColor = true;
            this.removeClassBtn.Click += new System.EventHandler(this.removeClassBtn_Click);
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
            this.menuStrip1.Size = new System.Drawing.Size(704, 30);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byIDToolStripMenuItem,
            this.byNameToolStripMenuItem,
            this.byMoneyToolStripMenuItem,
            this.byBGMusicToolStripMenuItem,
            this.byVictoryMusicToolStripMenuItem,
            this.byIntroMusicToolStripMenuItem,
            this.byGenderToolStripMenuItem,
            this.bySkillToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(54, 26);
            this.sortToolStripMenuItem.Text = "Sort";
            // 
            // byIDToolStripMenuItem
            // 
            this.byIDToolStripMenuItem.Name = "byIDToolStripMenuItem";
            this.byIDToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.byIDToolStripMenuItem.Text = "By ID";
            this.byIDToolStripMenuItem.Click += new System.EventHandler(this.byIDToolStripMenuItem_Click);
            // 
            // byNameToolStripMenuItem
            // 
            this.byNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayNameToolStripMenuItem,
            this.internalNameToolStripMenuItem});
            this.byNameToolStripMenuItem.Name = "byNameToolStripMenuItem";
            this.byNameToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
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
            // byMoneyToolStripMenuItem
            // 
            this.byMoneyToolStripMenuItem.Name = "byMoneyToolStripMenuItem";
            this.byMoneyToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.byMoneyToolStripMenuItem.Text = "By Money";
            this.byMoneyToolStripMenuItem.Click += new System.EventHandler(this.byMoneyToolStripMenuItem_Click);
            // 
            // byBGMusicToolStripMenuItem
            // 
            this.byBGMusicToolStripMenuItem.Name = "byBGMusicToolStripMenuItem";
            this.byBGMusicToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.byBGMusicToolStripMenuItem.Text = "By BG Music";
            this.byBGMusicToolStripMenuItem.Click += new System.EventHandler(this.byBGMusicToolStripMenuItem_Click);
            // 
            // byVictoryMusicToolStripMenuItem
            // 
            this.byVictoryMusicToolStripMenuItem.Name = "byVictoryMusicToolStripMenuItem";
            this.byVictoryMusicToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.byVictoryMusicToolStripMenuItem.Text = "By Victory Music";
            this.byVictoryMusicToolStripMenuItem.Click += new System.EventHandler(this.byVictoryMusicToolStripMenuItem_Click);
            // 
            // byIntroMusicToolStripMenuItem
            // 
            this.byIntroMusicToolStripMenuItem.Name = "byIntroMusicToolStripMenuItem";
            this.byIntroMusicToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.byIntroMusicToolStripMenuItem.Text = "By Intro Music";
            this.byIntroMusicToolStripMenuItem.Click += new System.EventHandler(this.byIntroMusicToolStripMenuItem_Click);
            // 
            // byGenderToolStripMenuItem
            // 
            this.byGenderToolStripMenuItem.Name = "byGenderToolStripMenuItem";
            this.byGenderToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.byGenderToolStripMenuItem.Text = "By Gender";
            this.byGenderToolStripMenuItem.Click += new System.EventHandler(this.byGenderToolStripMenuItem_Click);
            // 
            // bySkillToolStripMenuItem
            // 
            this.bySkillToolStripMenuItem.Name = "bySkillToolStripMenuItem";
            this.bySkillToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.bySkillToolStripMenuItem.Text = "By Skill";
            this.bySkillToolStripMenuItem.Click += new System.EventHandler(this.bySkillToolStripMenuItem_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectedToolStripMenuItem,
            this.allToolStripMenuItem});
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(90, 26);
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
            this.openTrainertypestxtToolStripMenuItem,
            this.findInternalNameToolStripMenuItem,
            this.reloadDataToolStripMenuItem});
            this.moreToolStripMenuItem.Name = "moreToolStripMenuItem";
            this.moreToolStripMenuItem.Size = new System.Drawing.Size(63, 26);
            this.moreToolStripMenuItem.Text = "More";
            // 
            // openTrainertypestxtToolStripMenuItem
            // 
            this.openTrainertypestxtToolStripMenuItem.Name = "openTrainertypestxtToolStripMenuItem";
            this.openTrainertypestxtToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.openTrainertypestxtToolStripMenuItem.Text = "Open trainertypes.txt";
            this.openTrainertypestxtToolStripMenuItem.Click += new System.EventHandler(this.openTrainertypestxtToolStripMenuItem_Click);
            // 
            // findInternalNameToolStripMenuItem
            // 
            this.findInternalNameToolStripMenuItem.Name = "findInternalNameToolStripMenuItem";
            this.findInternalNameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findInternalNameToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.findInternalNameToolStripMenuItem.Text = "Find Internal Name";
            this.findInternalNameToolStripMenuItem.Click += new System.EventHandler(this.findInternalNameToolStripMenuItem_Click);
            // 
            // reloadDataToolStripMenuItem
            // 
            this.reloadDataToolStripMenuItem.Name = "reloadDataToolStripMenuItem";
            this.reloadDataToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.reloadDataToolStripMenuItem.Text = "Reload Data";
            this.reloadDataToolStripMenuItem.Click += new System.EventHandler(this.reloadDataToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID:";
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(51, 22);
            this.idBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.idBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(75, 25);
            this.idBox.TabIndex = 5;
            this.idBox.ValueChanged += new System.EventHandler(this.idBox_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name:";
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(99, 52);
            this.nameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(196, 25);
            this.nameBox.TabIndex = 7;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // intnameBox
            // 
            this.intnameBox.Location = new System.Drawing.Point(99, 82);
            this.intnameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.intnameBox.Name = "intnameBox";
            this.intnameBox.Size = new System.Drawing.Size(196, 25);
            this.intnameBox.TabIndex = 9;
            this.intnameBox.TextChanged += new System.EventHandler(this.intnameBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Int. Name:";
            this.label3.MouseHover += new System.EventHandler(this.label3_MouseHover);
            // 
            // moneyBox
            // 
            this.moneyBox.Location = new System.Drawing.Point(129, 17);
            this.moneyBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.moneyBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.moneyBox.Name = "moneyBox";
            this.moneyBox.Size = new System.Drawing.Size(75, 25);
            this.moneyBox.TabIndex = 11;
            this.moneyBox.ValueChanged += new System.EventHandler(this.moneyBox_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Base Money:";
            this.label4.MouseHover += new System.EventHandler(this.label4_MouseHover);
            // 
            // defaultMoney
            // 
            this.defaultMoney.AutoSize = true;
            this.defaultMoney.Location = new System.Drawing.Point(213, 19);
            this.defaultMoney.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.defaultMoney.Name = "defaultMoney";
            this.defaultMoney.Size = new System.Drawing.Size(125, 19);
            this.defaultMoney.TabIndex = 12;
            this.defaultMoney.Text = "Default (30)";
            this.defaultMoney.UseVisualStyleBackColor = true;
            this.defaultMoney.CheckedChanged += new System.EventHandler(this.defaultMoney_CheckedChanged);
            // 
            // requiredFields
            // 
            this.requiredFields.Controls.Add(this.idBox);
            this.requiredFields.Controls.Add(this.label1);
            this.requiredFields.Controls.Add(this.label2);
            this.requiredFields.Controls.Add(this.nameBox);
            this.requiredFields.Controls.Add(this.intnameBox);
            this.requiredFields.Controls.Add(this.label3);
            this.requiredFields.Enabled = false;
            this.requiredFields.Location = new System.Drawing.Point(264, 25);
            this.requiredFields.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.requiredFields.Name = "requiredFields";
            this.requiredFields.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.requiredFields.Size = new System.Drawing.Size(303, 115);
            this.requiredFields.TabIndex = 13;
            this.requiredFields.TabStop = false;
            this.requiredFields.Text = "Required Fields";
            // 
            // optionalFields
            // 
            this.optionalFields.Controls.Add(this.button6);
            this.optionalFields.Controls.Add(this.button4);
            this.optionalFields.Controls.Add(this.button2);
            this.optionalFields.Controls.Add(this.button1);
            this.optionalFields.Controls.Add(this.label9);
            this.optionalFields.Controls.Add(this.skillBox);
            this.optionalFields.Controls.Add(this.defaultSkill);
            this.optionalFields.Controls.Add(this.defaultGender);
            this.optionalFields.Controls.Add(this.label8);
            this.optionalFields.Controls.Add(this.genderBox);
            this.optionalFields.Controls.Add(this.defaultIntroMusic);
            this.optionalFields.Controls.Add(this.browseIntroMusic);
            this.optionalFields.Controls.Add(this.introMusic);
            this.optionalFields.Controls.Add(this.label7);
            this.optionalFields.Controls.Add(this.defaultVictoryMusic);
            this.optionalFields.Controls.Add(this.browseVictoryMusic);
            this.optionalFields.Controls.Add(this.victoryMusic);
            this.optionalFields.Controls.Add(this.label6);
            this.optionalFields.Controls.Add(this.defaultBGMusic);
            this.optionalFields.Controls.Add(this.browseBGMusic);
            this.optionalFields.Controls.Add(this.bgMusic);
            this.optionalFields.Controls.Add(this.label5);
            this.optionalFields.Controls.Add(this.label4);
            this.optionalFields.Controls.Add(this.moneyBox);
            this.optionalFields.Controls.Add(this.defaultMoney);
            this.optionalFields.Enabled = false;
            this.optionalFields.Location = new System.Drawing.Point(264, 148);
            this.optionalFields.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optionalFields.MaximumSize = new System.Drawing.Size(435, 216);
            this.optionalFields.MinimumSize = new System.Drawing.Size(435, 216);
            this.optionalFields.Name = "optionalFields";
            this.optionalFields.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optionalFields.Size = new System.Drawing.Size(435, 216);
            this.optionalFields.TabIndex = 14;
            this.optionalFields.TabStop = false;
            this.optionalFields.Text = "Optional Fields";
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(399, 106);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(28, 27);
            this.button6.TabIndex = 34;
            this.button6.Text = "▶";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(399, 76);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(28, 27);
            this.button4.TabIndex = 32;
            this.button4.Text = "▶";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(399, 16);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 27);
            this.button2.TabIndex = 31;
            this.button2.Text = "■";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(399, 46);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 27);
            this.button1.TabIndex = 30;
            this.button1.Text = "▶";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 173);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "Skill Level:";
            this.label9.MouseHover += new System.EventHandler(this.label9_MouseHover);
            // 
            // skillBox
            // 
            this.skillBox.Location = new System.Drawing.Point(131, 169);
            this.skillBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.skillBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.skillBox.Name = "skillBox";
            this.skillBox.Size = new System.Drawing.Size(75, 25);
            this.skillBox.TabIndex = 28;
            this.skillBox.ValueChanged += new System.EventHandler(this.skillBox_ValueChanged);
            // 
            // defaultSkill
            // 
            this.defaultSkill.AutoSize = true;
            this.defaultSkill.Location = new System.Drawing.Point(213, 170);
            this.defaultSkill.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.defaultSkill.Name = "defaultSkill";
            this.defaultSkill.Size = new System.Drawing.Size(197, 19);
            this.defaultSkill.TabIndex = 29;
            this.defaultSkill.Text = "Default (=Base Money)";
            this.defaultSkill.UseVisualStyleBackColor = true;
            this.defaultSkill.CheckedChanged += new System.EventHandler(this.defaultSkill_CheckedChanged);
            // 
            // defaultGender
            // 
            this.defaultGender.AutoSize = true;
            this.defaultGender.Location = new System.Drawing.Point(257, 141);
            this.defaultGender.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.defaultGender.Name = "defaultGender";
            this.defaultGender.Size = new System.Drawing.Size(149, 19);
            this.defaultGender.TabIndex = 26;
            this.defaultGender.Text = "Default (Mixed)";
            this.defaultGender.UseVisualStyleBackColor = true;
            this.defaultGender.CheckedChanged += new System.EventHandler(this.defaultGender_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 143);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Gender:";
            this.label8.MouseHover += new System.EventHandler(this.label8_MouseHover);
            // 
            // genderBox
            // 
            this.genderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genderBox.FormattingEnabled = true;
            this.genderBox.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Mixed"});
            this.genderBox.Location = new System.Drawing.Point(129, 137);
            this.genderBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.genderBox.Name = "genderBox";
            this.genderBox.Size = new System.Drawing.Size(119, 23);
            this.genderBox.TabIndex = 24;
            this.genderBox.SelectedIndexChanged += new System.EventHandler(this.genderBox_SelectedIndexChanged);
            // 
            // defaultIntroMusic
            // 
            this.defaultIntroMusic.AutoSize = true;
            this.defaultIntroMusic.Location = new System.Drawing.Point(301, 109);
            this.defaultIntroMusic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.defaultIntroMusic.Name = "defaultIntroMusic";
            this.defaultIntroMusic.Size = new System.Drawing.Size(85, 19);
            this.defaultIntroMusic.TabIndex = 23;
            this.defaultIntroMusic.Text = "Default";
            this.defaultIntroMusic.UseVisualStyleBackColor = true;
            this.defaultIntroMusic.CheckedChanged += new System.EventHandler(this.defaultIntroMusic_CheckedChanged);
            // 
            // browseIntroMusic
            // 
            this.browseIntroMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseIntroMusic.Location = new System.Drawing.Point(252, 106);
            this.browseIntroMusic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.browseIntroMusic.Name = "browseIntroMusic";
            this.browseIntroMusic.Size = new System.Drawing.Size(43, 23);
            this.browseIntroMusic.TabIndex = 22;
            this.browseIntroMusic.Text = "...";
            this.browseIntroMusic.UseVisualStyleBackColor = true;
            this.browseIntroMusic.Click += new System.EventHandler(this.browseIntroMusic_Click);
            // 
            // introMusic
            // 
            this.introMusic.Location = new System.Drawing.Point(129, 106);
            this.introMusic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.introMusic.Name = "introMusic";
            this.introMusic.Size = new System.Drawing.Size(119, 25);
            this.introMusic.TabIndex = 20;
            this.introMusic.TextChanged += new System.EventHandler(this.introMusic_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 112);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Intro Music:";
            this.label7.MouseHover += new System.EventHandler(this.label7_MouseHover);
            // 
            // defaultVictoryMusic
            // 
            this.defaultVictoryMusic.AutoSize = true;
            this.defaultVictoryMusic.Location = new System.Drawing.Point(301, 80);
            this.defaultVictoryMusic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.defaultVictoryMusic.Name = "defaultVictoryMusic";
            this.defaultVictoryMusic.Size = new System.Drawing.Size(85, 19);
            this.defaultVictoryMusic.TabIndex = 19;
            this.defaultVictoryMusic.Text = "Default";
            this.defaultVictoryMusic.UseVisualStyleBackColor = true;
            this.defaultVictoryMusic.CheckedChanged += new System.EventHandler(this.defaultVictoryMusic_CheckedChanged);
            // 
            // browseVictoryMusic
            // 
            this.browseVictoryMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseVictoryMusic.Location = new System.Drawing.Point(252, 77);
            this.browseVictoryMusic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.browseVictoryMusic.Name = "browseVictoryMusic";
            this.browseVictoryMusic.Size = new System.Drawing.Size(43, 23);
            this.browseVictoryMusic.TabIndex = 18;
            this.browseVictoryMusic.Text = "...";
            this.browseVictoryMusic.UseVisualStyleBackColor = true;
            this.browseVictoryMusic.Click += new System.EventHandler(this.browseVictoryMusic_Click);
            // 
            // victoryMusic
            // 
            this.victoryMusic.Location = new System.Drawing.Point(129, 77);
            this.victoryMusic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.victoryMusic.Name = "victoryMusic";
            this.victoryMusic.Size = new System.Drawing.Size(119, 25);
            this.victoryMusic.TabIndex = 16;
            this.victoryMusic.TextChanged += new System.EventHandler(this.victoryMusic_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 82);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Victory Music:";
            this.label6.MouseHover += new System.EventHandler(this.label6_MouseHover);
            // 
            // defaultBGMusic
            // 
            this.defaultBGMusic.AutoSize = true;
            this.defaultBGMusic.Location = new System.Drawing.Point(301, 50);
            this.defaultBGMusic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.defaultBGMusic.Name = "defaultBGMusic";
            this.defaultBGMusic.Size = new System.Drawing.Size(85, 19);
            this.defaultBGMusic.TabIndex = 15;
            this.defaultBGMusic.Text = "Default";
            this.defaultBGMusic.UseVisualStyleBackColor = true;
            this.defaultBGMusic.CheckedChanged += new System.EventHandler(this.defaultBGMusic_CheckedChanged);
            // 
            // browseBGMusic
            // 
            this.browseBGMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseBGMusic.Location = new System.Drawing.Point(252, 47);
            this.browseBGMusic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.browseBGMusic.Name = "browseBGMusic";
            this.browseBGMusic.Size = new System.Drawing.Size(43, 23);
            this.browseBGMusic.TabIndex = 14;
            this.browseBGMusic.Text = "...";
            this.browseBGMusic.UseVisualStyleBackColor = true;
            this.browseBGMusic.Click += new System.EventHandler(this.browseBGMusic_Click);
            // 
            // bgMusic
            // 
            this.bgMusic.Location = new System.Drawing.Point(129, 47);
            this.bgMusic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bgMusic.Name = "bgMusic";
            this.bgMusic.Size = new System.Drawing.Size(119, 25);
            this.bgMusic.TabIndex = 10;
            this.bgMusic.TextChanged += new System.EventHandler(this.bgMusic_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "BG Music:";
            this.label5.MouseHover += new System.EventHandler(this.label5_MouseHover);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(575, 110);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "Volume:";
            this.label10.MouseHover += new System.EventHandler(this.label10_MouseHover);
            // 
            // volumeBox
            // 
            this.volumeBox.Location = new System.Drawing.Point(601, 128);
            this.volumeBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.volumeBox.Name = "volumeBox";
            this.volumeBox.Size = new System.Drawing.Size(57, 25);
            this.volumeBox.TabIndex = 16;
            this.volumeBox.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.volumeBox.ValueChanged += new System.EventHandler(this.volumeBox_ValueChanged);
            // 
            // intNameTip
            // 
            this.intNameTip.AutomaticDelay = 50;
            this.intNameTip.AutoPopDelay = 0;
            this.intNameTip.InitialDelay = 50;
            this.intNameTip.ReshowDelay = 10;
            this.intNameTip.ToolTipTitle = "Internal Name";
            // 
            // nameTip
            // 
            this.nameTip.AutomaticDelay = 50;
            this.nameTip.AutoPopDelay = 0;
            this.nameTip.InitialDelay = 50;
            this.nameTip.ReshowDelay = 10;
            this.nameTip.ToolTipTitle = "Display Name";
            // 
            // idTip
            // 
            this.idTip.AutomaticDelay = 50;
            this.idTip.AutoPopDelay = 0;
            this.idTip.InitialDelay = 50;
            this.idTip.ReshowDelay = 10;
            this.idTip.ToolTipTitle = "ID";
            // 
            // baseMoneyTip
            // 
            this.baseMoneyTip.AutomaticDelay = 50;
            this.baseMoneyTip.AutoPopDelay = 0;
            this.baseMoneyTip.InitialDelay = 50;
            this.baseMoneyTip.ReshowDelay = 10;
            this.baseMoneyTip.ToolTipTitle = "Base Money";
            // 
            // bgMusicTip
            // 
            this.bgMusicTip.AutomaticDelay = 50;
            this.bgMusicTip.AutoPopDelay = 0;
            this.bgMusicTip.InitialDelay = 50;
            this.bgMusicTip.ReshowDelay = 10;
            this.bgMusicTip.ToolTipTitle = "Background Music";
            // 
            // victoryMusicTip
            // 
            this.victoryMusicTip.AutomaticDelay = 50;
            this.victoryMusicTip.AutoPopDelay = 0;
            this.victoryMusicTip.InitialDelay = 50;
            this.victoryMusicTip.ReshowDelay = 10;
            this.victoryMusicTip.ToolTipTitle = "Victory Music";
            // 
            // introMusicTip
            // 
            this.introMusicTip.AutomaticDelay = 50;
            this.introMusicTip.AutoPopDelay = 0;
            this.introMusicTip.InitialDelay = 50;
            this.introMusicTip.ReshowDelay = 10;
            this.introMusicTip.ToolTipTitle = "Intro Music";
            // 
            // genderTip
            // 
            this.genderTip.AutomaticDelay = 50;
            this.genderTip.AutoPopDelay = 0;
            this.genderTip.InitialDelay = 50;
            this.genderTip.ReshowDelay = 10;
            this.genderTip.ToolTipTitle = "Gender";
            // 
            // skillLevelTip
            // 
            this.skillLevelTip.AutomaticDelay = 50;
            this.skillLevelTip.AutoPopDelay = 0;
            this.skillLevelTip.InitialDelay = 50;
            this.skillLevelTip.ReshowDelay = 10;
            this.skillLevelTip.ToolTipTitle = "Skill Level";
            // 
            // volumeTip
            // 
            this.volumeTip.AutomaticDelay = 50;
            this.volumeTip.AutoPopDelay = 0;
            this.volumeTip.InitialDelay = 50;
            this.volumeTip.ReshowDelay = 10;
            this.volumeTip.ToolTipTitle = "Volume";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.musicToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 363);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(704, 26);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // musicToolStripStatusLabel
            // 
            this.musicToolStripStatusLabel.Name = "musicToolStripStatusLabel";
            this.musicToolStripStatusLabel.Size = new System.Drawing.Size(52, 20);
            this.musicToolStripStatusLabel.Text = "Music";
            // 
            // TrainerClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 389);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.volumeBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.optionalFields);
            this.Controls.Add(this.requiredFields);
            this.Controls.Add(this.removeClassBtn);
            this.Controls.Add(this.addClassBtn);
            this.Controls.Add(this.classBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "TrainerClassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trainer Class Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrainerClassForm_FormClosing);
            this.Load += new System.EventHandler(this.TrainerClassForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyBox)).EndInit();
            this.requiredFields.ResumeLayout(false);
            this.requiredFields.PerformLayout();
            this.optionalFields.ResumeLayout(false);
            this.optionalFields.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skillBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox classBox;
        private System.Windows.Forms.Button addClassBtn;
        private System.Windows.Forms.Button removeClassBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown idBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox intnameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown moneyBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox defaultMoney;
        private System.Windows.Forms.GroupBox requiredFields;
        private System.Windows.Forms.GroupBox optionalFields;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown skillBox;
        private System.Windows.Forms.CheckBox defaultSkill;
        private System.Windows.Forms.CheckBox defaultGender;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox genderBox;
        private System.Windows.Forms.CheckBox defaultIntroMusic;
        private System.Windows.Forms.Button browseIntroMusic;
        private System.Windows.Forms.TextBox introMusic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox defaultVictoryMusic;
        private System.Windows.Forms.Button browseVictoryMusic;
        private System.Windows.Forms.TextBox victoryMusic;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox defaultBGMusic;
        private System.Windows.Forms.Button browseBGMusic;
        private System.Windows.Forms.TextBox bgMusic;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem moreToolStripMenuItem;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown volumeBox;
        private System.Windows.Forms.ToolStripMenuItem byIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internalNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byMoneyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byBGMusicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byVictoryMusicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byIntroMusicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byGenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bySkillToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem overwriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTrainertypestxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findInternalNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadDataToolStripMenuItem;
        private System.Windows.Forms.ToolTip intNameTip;
        private System.Windows.Forms.ToolTip nameTip;
        private System.Windows.Forms.ToolTip idTip;
        private System.Windows.Forms.ToolTip baseMoneyTip;
        private System.Windows.Forms.ToolTip bgMusicTip;
        private System.Windows.Forms.ToolTip victoryMusicTip;
        private System.Windows.Forms.ToolTip introMusicTip;
        private System.Windows.Forms.ToolTip genderTip;
        private System.Windows.Forms.ToolTip skillLevelTip;
        private System.Windows.Forms.ToolTip volumeTip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel musicToolStripStatusLabel;
    }
}