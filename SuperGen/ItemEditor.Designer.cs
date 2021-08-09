namespace SuperGen
{
    partial class ItemEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemEditor));
            this.itemBox = new System.Windows.Forms.ListBox();
            this.addItemBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.NumericUpDown();
            this.intNameBox = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pluralBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pocketBox = new System.Windows.Forms.ComboBox();
            this.priceBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.usabilityFieldBox = new System.Windows.Forms.NumericUpDown();
            this.usabilityBattleBox = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.descBox = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.specialItemBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tmMoveBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.noTMItemBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluralDisplayNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internalNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byPocketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byFieldUsageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byBattleUsageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bySpecialItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byTMMovesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.openItemstxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findInternalNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idTip = new System.Windows.Forms.ToolTip(this.components);
            this.intNameTip = new System.Windows.Forms.ToolTip(this.components);
            this.nameTip = new System.Windows.Forms.ToolTip(this.components);
            this.pluralTip = new System.Windows.Forms.ToolTip(this.components);
            this.pocketTip = new System.Windows.Forms.ToolTip(this.components);
            this.priceTip = new System.Windows.Forms.ToolTip(this.components);
            this.useFieldTip = new System.Windows.Forms.ToolTip(this.components);
            this.useBattleTip = new System.Windows.Forms.ToolTip(this.components);
            this.specialItemTip = new System.Windows.Forms.ToolTip(this.components);
            this.tmMoveTip = new System.Windows.Forms.ToolTip(this.components);
            this.descTip = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.icon = new SpriteStrip_Render.AnimatedSprite();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.idBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usabilityFieldBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usabilityBattleBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // itemBox
            // 
            this.itemBox.FormattingEnabled = true;
            this.itemBox.ItemHeight = 15;
            this.itemBox.Location = new System.Drawing.Point(16, 31);
            this.itemBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.itemBox.Name = "itemBox";
            this.itemBox.Size = new System.Drawing.Size(159, 259);
            this.itemBox.TabIndex = 0;
            this.itemBox.SelectedIndexChanged += new System.EventHandler(this.itemBox_SelectedIndexChanged);
            // 
            // addItemBtn
            // 
            this.addItemBtn.Location = new System.Drawing.Point(16, 306);
            this.addItemBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addItemBtn.Name = "addItemBtn";
            this.addItemBtn.Size = new System.Drawing.Size(159, 27);
            this.addItemBtn.TabIndex = 1;
            this.addItemBtn.Text = "Add Item";
            this.addItemBtn.UseVisualStyleBackColor = true;
            this.addItemBtn.Click += new System.EventHandler(this.addItemBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID:";
            this.label1.MouseHover += new System.EventHandler(this.label1_MouseHover);
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(276, 31);
            this.idBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.idBox.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.idBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(63, 25);
            this.idBox.TabIndex = 4;
            this.idBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.idBox.ValueChanged += new System.EventHandler(this.idBox_ValueChanged);
            // 
            // intNameBox
            // 
            this.intNameBox.Location = new System.Drawing.Point(276, 61);
            this.intNameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.intNameBox.Name = "intNameBox";
            this.intNameBox.Size = new System.Drawing.Size(133, 25);
            this.intNameBox.TabIndex = 86;
            this.intNameBox.TextChanged += new System.EventHandler(this.intNameBox_TextChanged);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(184, 66);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(87, 15);
            this.label48.TabIndex = 88;
            this.label48.Text = "Int. Name:";
            this.label48.MouseHover += new System.EventHandler(this.label48_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 87;
            this.label2.Text = "Name:";
            this.label2.MouseHover += new System.EventHandler(this.label2_MouseHover);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(276, 91);
            this.nameBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(132, 25);
            this.nameBox.TabIndex = 85;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 90;
            this.label3.Text = "Plural:";
            this.label3.MouseHover += new System.EventHandler(this.label3_MouseHover);
            // 
            // pluralBox
            // 
            this.pluralBox.Location = new System.Drawing.Point(276, 121);
            this.pluralBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pluralBox.Name = "pluralBox";
            this.pluralBox.Size = new System.Drawing.Size(132, 25);
            this.pluralBox.TabIndex = 89;
            this.pluralBox.TextChanged += new System.EventHandler(this.pluralBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 153);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 92;
            this.label4.Text = "Pocket:";
            this.label4.MouseHover += new System.EventHandler(this.label4_MouseHover);
            // 
            // pocketBox
            // 
            this.pocketBox.FormattingEnabled = true;
            this.pocketBox.Items.AddRange(new object[] {
            "Items",
            "Medicine",
            "Poké Balls",
            "TMs & HMs",
            "Berries",
            "Mail",
            "Battle Items",
            "Key Items"});
            this.pocketBox.Location = new System.Drawing.Point(276, 151);
            this.pocketBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pocketBox.Name = "pocketBox";
            this.pocketBox.Size = new System.Drawing.Size(132, 23);
            this.pocketBox.TabIndex = 93;
            this.pocketBox.SelectedIndexChanged += new System.EventHandler(this.pocketBox_SelectedIndexChanged);
            // 
            // priceBox
            // 
            this.priceBox.Location = new System.Drawing.Point(276, 179);
            this.priceBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.priceBox.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.priceBox.Name = "priceBox";
            this.priceBox.Size = new System.Drawing.Size(133, 25);
            this.priceBox.TabIndex = 95;
            this.priceBox.ValueChanged += new System.EventHandler(this.priceBox_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 182);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 94;
            this.label5.Text = "Price:";
            this.label5.MouseHover += new System.EventHandler(this.label5_MouseHover);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 211);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 15);
            this.label6.TabIndex = 96;
            this.label6.Text = "Use outside battle*:";
            this.label6.MouseHover += new System.EventHandler(this.label6_MouseHover);
            // 
            // usabilityFieldBox
            // 
            this.usabilityFieldBox.Location = new System.Drawing.Point(359, 209);
            this.usabilityFieldBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.usabilityFieldBox.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.usabilityFieldBox.Name = "usabilityFieldBox";
            this.usabilityFieldBox.Size = new System.Drawing.Size(50, 25);
            this.usabilityFieldBox.TabIndex = 97;
            this.usabilityFieldBox.ValueChanged += new System.EventHandler(this.usabilityFieldBox_ValueChanged);
            // 
            // usabilityBattleBox
            // 
            this.usabilityBattleBox.Location = new System.Drawing.Point(359, 239);
            this.usabilityBattleBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.usabilityBattleBox.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.usabilityBattleBox.Name = "usabilityBattleBox";
            this.usabilityBattleBox.Size = new System.Drawing.Size(50, 25);
            this.usabilityBattleBox.TabIndex = 99;
            this.usabilityBattleBox.ValueChanged += new System.EventHandler(this.usabilityBattleBox_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 240);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 15);
            this.label7.TabIndex = 98;
            this.label7.Text = "Use in battle*:";
            this.label7.MouseHover += new System.EventHandler(this.label7_MouseHover);
            // 
            // descBox
            // 
            this.descBox.Location = new System.Drawing.Point(430, 182);
            this.descBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.descBox.Name = "descBox";
            this.descBox.Size = new System.Drawing.Size(200, 165);
            this.descBox.TabIndex = 100;
            this.descBox.Text = "";
            this.descBox.TextChanged += new System.EventHandler(this.descBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(427, 159);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 15);
            this.label8.TabIndex = 101;
            this.label8.Text = "Description:";
            this.label8.MouseHover += new System.EventHandler(this.label8_MouseHover);
            // 
            // specialItemBox
            // 
            this.specialItemBox.FormattingEnabled = true;
            this.specialItemBox.Items.AddRange(new object[] {
            "No",
            "Mail",
            "Mail w/ Images",
            "Snag Ball",
            "Poké Ball",
            "Berry",
            "Key Item"});
            this.specialItemBox.Location = new System.Drawing.Point(312, 269);
            this.specialItemBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.specialItemBox.Name = "specialItemBox";
            this.specialItemBox.Size = new System.Drawing.Size(96, 23);
            this.specialItemBox.TabIndex = 103;
            this.specialItemBox.SelectedIndexChanged += new System.EventHandler(this.specialItemBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(184, 269);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 15);
            this.label9.TabIndex = 102;
            this.label9.Text = "Special Item:";
            this.label9.MouseHover += new System.EventHandler(this.label9_MouseHover);
            // 
            // tmMoveBox
            // 
            this.tmMoveBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tmMoveBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tmMoveBox.FormattingEnabled = true;
            this.tmMoveBox.Items.AddRange(new object[] {
            "Items",
            "Medicine",
            "Poké Balls",
            "TMs & HMs",
            "Berries",
            "Mail",
            "Battle Items",
            "Key Items"});
            this.tmMoveBox.Location = new System.Drawing.Point(187, 324);
            this.tmMoveBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tmMoveBox.Name = "tmMoveBox";
            this.tmMoveBox.Size = new System.Drawing.Size(221, 23);
            this.tmMoveBox.TabIndex = 105;
            this.tmMoveBox.SelectedIndexChanged += new System.EventHandler(this.tmMoveBox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(184, 298);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 15);
            this.label10.TabIndex = 104;
            this.label10.Text = "TM Move:";
            this.label10.MouseHover += new System.EventHandler(this.label10_MouseHover);
            // 
            // noTMItemBox
            // 
            this.noTMItemBox.AutoSize = true;
            this.noTMItemBox.Location = new System.Drawing.Point(187, 353);
            this.noTMItemBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.noTMItemBox.Name = "noTMItemBox";
            this.noTMItemBox.Size = new System.Drawing.Size(133, 19);
            this.noTMItemBox.TabIndex = 106;
            this.noTMItemBox.Text = "Not a TM Item";
            this.noTMItemBox.UseVisualStyleBackColor = true;
            this.noTMItemBox.CheckedChanged += new System.EventHandler(this.noTMItemBox_CheckedChanged);
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(643, 28);
            this.menuStrip1.TabIndex = 107;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byIDToolStripMenuItem,
            this.nameToolStripMenuItem,
            this.byPocketToolStripMenuItem,
            this.byPriceToolStripMenuItem,
            this.byFieldUsageToolStripMenuItem,
            this.byBattleUsageToolStripMenuItem,
            this.bySpecialItemsToolStripMenuItem,
            this.byTMMovesToolStripMenuItem,
            this.byDescriptionToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.sortToolStripMenuItem.Text = "Sort";
            // 
            // byIDToolStripMenuItem
            // 
            this.byIDToolStripMenuItem.Name = "byIDToolStripMenuItem";
            this.byIDToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.byIDToolStripMenuItem.Text = "By ID";
            this.byIDToolStripMenuItem.Click += new System.EventHandler(this.byIDToolStripMenuItem_Click);
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayNameToolStripMenuItem,
            this.pluralDisplayNameToolStripMenuItem,
            this.internalNameToolStripMenuItem});
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.nameToolStripMenuItem.Text = "By Name";
            // 
            // displayNameToolStripMenuItem
            // 
            this.displayNameToolStripMenuItem.Name = "displayNameToolStripMenuItem";
            this.displayNameToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.displayNameToolStripMenuItem.Text = "Display Name";
            this.displayNameToolStripMenuItem.Click += new System.EventHandler(this.displayNameToolStripMenuItem_Click);
            // 
            // pluralDisplayNameToolStripMenuItem
            // 
            this.pluralDisplayNameToolStripMenuItem.Name = "pluralDisplayNameToolStripMenuItem";
            this.pluralDisplayNameToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.pluralDisplayNameToolStripMenuItem.Text = "Plural Display Name";
            this.pluralDisplayNameToolStripMenuItem.Click += new System.EventHandler(this.pluralDisplayNameToolStripMenuItem_Click);
            // 
            // internalNameToolStripMenuItem
            // 
            this.internalNameToolStripMenuItem.Name = "internalNameToolStripMenuItem";
            this.internalNameToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.internalNameToolStripMenuItem.Text = "Internal Name";
            this.internalNameToolStripMenuItem.Click += new System.EventHandler(this.internalNameToolStripMenuItem_Click);
            // 
            // byPocketToolStripMenuItem
            // 
            this.byPocketToolStripMenuItem.Name = "byPocketToolStripMenuItem";
            this.byPocketToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.byPocketToolStripMenuItem.Text = "By Pocket";
            this.byPocketToolStripMenuItem.Click += new System.EventHandler(this.byPocketToolStripMenuItem_Click);
            // 
            // byPriceToolStripMenuItem
            // 
            this.byPriceToolStripMenuItem.Name = "byPriceToolStripMenuItem";
            this.byPriceToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.byPriceToolStripMenuItem.Text = "By Price";
            this.byPriceToolStripMenuItem.Click += new System.EventHandler(this.byPriceToolStripMenuItem_Click);
            // 
            // byFieldUsageToolStripMenuItem
            // 
            this.byFieldUsageToolStripMenuItem.Name = "byFieldUsageToolStripMenuItem";
            this.byFieldUsageToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.byFieldUsageToolStripMenuItem.Text = "By Field Usage";
            this.byFieldUsageToolStripMenuItem.Click += new System.EventHandler(this.byFieldUsageToolStripMenuItem_Click);
            // 
            // byBattleUsageToolStripMenuItem
            // 
            this.byBattleUsageToolStripMenuItem.Name = "byBattleUsageToolStripMenuItem";
            this.byBattleUsageToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.byBattleUsageToolStripMenuItem.Text = "By Battle Usage";
            this.byBattleUsageToolStripMenuItem.Click += new System.EventHandler(this.byBattleUsageToolStripMenuItem_Click);
            // 
            // bySpecialItemsToolStripMenuItem
            // 
            this.bySpecialItemsToolStripMenuItem.Name = "bySpecialItemsToolStripMenuItem";
            this.bySpecialItemsToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.bySpecialItemsToolStripMenuItem.Text = "By Special Items";
            this.bySpecialItemsToolStripMenuItem.Click += new System.EventHandler(this.bySpecialItemsToolStripMenuItem_Click);
            // 
            // byTMMovesToolStripMenuItem
            // 
            this.byTMMovesToolStripMenuItem.Name = "byTMMovesToolStripMenuItem";
            this.byTMMovesToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.byTMMovesToolStripMenuItem.Text = "By TM Moves";
            this.byTMMovesToolStripMenuItem.Click += new System.EventHandler(this.byTMMovesToolStripMenuItem_Click);
            // 
            // byDescriptionToolStripMenuItem
            // 
            this.byDescriptionToolStripMenuItem.Name = "byDescriptionToolStripMenuItem";
            this.byDescriptionToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
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
            // 
            // overwriteToolStripMenuItem
            // 
            this.overwriteToolStripMenuItem.Name = "overwriteToolStripMenuItem";
            this.overwriteToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.overwriteToolStripMenuItem.Text = "Overwrite";
            // 
            // moreToolStripMenuItem
            // 
            this.moreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openItemstxtToolStripMenuItem,
            this.findInternalNameToolStripMenuItem,
            this.reloadDataToolStripMenuItem});
            this.moreToolStripMenuItem.Name = "moreToolStripMenuItem";
            this.moreToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.moreToolStripMenuItem.Text = "More";
            // 
            // openItemstxtToolStripMenuItem
            // 
            this.openItemstxtToolStripMenuItem.Name = "openItemstxtToolStripMenuItem";
            this.openItemstxtToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.openItemstxtToolStripMenuItem.Text = "Open items.txt";
            this.openItemstxtToolStripMenuItem.Click += new System.EventHandler(this.openItemstxtToolStripMenuItem_Click);
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
            // idTip
            // 
            this.idTip.AutomaticDelay = 50;
            this.idTip.AutoPopDelay = 0;
            this.idTip.InitialDelay = 50;
            this.idTip.ReshowDelay = 10;
            this.idTip.ToolTipTitle = "ID";
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
            this.nameTip.ToolTipTitle = "Name";
            // 
            // pluralTip
            // 
            this.pluralTip.AutomaticDelay = 50;
            this.pluralTip.AutoPopDelay = 0;
            this.pluralTip.InitialDelay = 50;
            this.pluralTip.ReshowDelay = 10;
            this.pluralTip.ToolTipTitle = "Plural Name";
            // 
            // pocketTip
            // 
            this.pocketTip.AutomaticDelay = 50;
            this.pocketTip.AutoPopDelay = 0;
            this.pocketTip.InitialDelay = 50;
            this.pocketTip.ReshowDelay = 10;
            this.pocketTip.ToolTipTitle = "Pocket";
            // 
            // priceTip
            // 
            this.priceTip.AutomaticDelay = 50;
            this.priceTip.AutoPopDelay = 0;
            this.priceTip.InitialDelay = 50;
            this.priceTip.ReshowDelay = 10;
            this.priceTip.ToolTipTitle = "Price";
            // 
            // useFieldTip
            // 
            this.useFieldTip.AutomaticDelay = 50;
            this.useFieldTip.AutoPopDelay = 0;
            this.useFieldTip.InitialDelay = 50;
            this.useFieldTip.ReshowDelay = 10;
            this.useFieldTip.ToolTipTitle = "Usability outside of battle";
            // 
            // useBattleTip
            // 
            this.useBattleTip.AutomaticDelay = 50;
            this.useBattleTip.AutoPopDelay = 0;
            this.useBattleTip.InitialDelay = 50;
            this.useBattleTip.ReshowDelay = 10;
            this.useBattleTip.ToolTipTitle = "Usability in of battle";
            // 
            // specialItemTip
            // 
            this.specialItemTip.AutomaticDelay = 50;
            this.specialItemTip.AutoPopDelay = 0;
            this.specialItemTip.InitialDelay = 50;
            this.specialItemTip.ReshowDelay = 10;
            this.specialItemTip.ToolTipTitle = "Special Item";
            // 
            // tmMoveTip
            // 
            this.tmMoveTip.AutomaticDelay = 50;
            this.tmMoveTip.AutoPopDelay = 0;
            this.tmMoveTip.InitialDelay = 50;
            this.tmMoveTip.ReshowDelay = 10;
            this.tmMoveTip.ToolTipTitle = "TM Move";
            // 
            // descTip
            // 
            this.descTip.AutomaticDelay = 50;
            this.descTip.AutoPopDelay = 0;
            this.descTip.InitialDelay = 50;
            this.descTip.ReshowDelay = 10;
            this.descTip.ToolTipTitle = "Description";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 339);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 27);
            this.button1.TabIndex = 108;
            this.button1.Text = "Remove Item";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // icon
            // 
            this.icon.BackColor = System.Drawing.Color.Transparent;
            this.icon.FrameRate = 10;
            this.icon.Location = new System.Drawing.Point(498, 31);
            this.icon.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(55, 44);
            this.icon.Sprite = ((System.Drawing.Image)(resources.GetObject("icon.Sprite")));
            this.icon.TabIndex = 109;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(469, 95);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 110;
            this.button2.Text = "Set Icon";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 378);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.icon);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.noTMItemBox);
            this.Controls.Add(this.tmMoveBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.specialItemBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.descBox);
            this.Controls.Add(this.usabilityBattleBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.usabilityFieldBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.priceBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pocketBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pluralBox);
            this.Controls.Add(this.intNameBox);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addItemBtn);
            this.Controls.Add(this.itemBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximumSize = new System.Drawing.Size(661, 425);
            this.MinimumSize = new System.Drawing.Size(661, 425);
            this.Name = "ItemEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Item Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemEditor_FormClosing);
            this.Load += new System.EventHandler(this.ItemEditor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.idBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usabilityFieldBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usabilityBattleBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox itemBox;
        private System.Windows.Forms.Button addItemBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown idBox;
        private System.Windows.Forms.TextBox intNameBox;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pluralBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox pocketBox;
        private System.Windows.Forms.NumericUpDown priceBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown usabilityFieldBox;
        private System.Windows.Forms.NumericUpDown usabilityBattleBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox descBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox specialItemBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox tmMoveBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox noTMItemBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byPocketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byFieldUsageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byBattleUsageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bySpecialItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byTMMovesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byDescriptionToolStripMenuItem;
        private System.Windows.Forms.ToolTip idTip;
        private System.Windows.Forms.ToolTip intNameTip;
        private System.Windows.Forms.ToolTip nameTip;
        private System.Windows.Forms.ToolTip pluralTip;
        private System.Windows.Forms.ToolTip pocketTip;
        private System.Windows.Forms.ToolTip priceTip;
        private System.Windows.Forms.ToolTip useFieldTip;
        private System.Windows.Forms.ToolTip useBattleTip;
        private System.Windows.Forms.ToolTip specialItemTip;
        private System.Windows.Forms.ToolTip tmMoveTip;
        private System.Windows.Forms.ToolTip descTip;
        private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem overwriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluralDisplayNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internalNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openItemstxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findInternalNameToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem reloadDataToolStripMenuItem;
        private SpriteStrip_Render.AnimatedSprite icon;
        private System.Windows.Forms.Button button2;
    }
}