using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static SuperGen.SuperForm;
using lib;
using System.Diagnostics;

namespace SuperGen
{
    public partial class ItemEditor : Form
    {
        private bool terminate = false;
        private bool msg = true;
        private BindingSource itemBinder = new BindingSource();
        private BindingSource moveBinder = new BindingSource();
        private List<Item> items = new List<Item>();
        private List<string> moves = new List<string>();
        private string thisid = null;
        //private List<Item> permItems = new List<Item>();

        public ItemEditor()
        {
            InitializeComponent();
        }

        private void sortLast(object sender, EventArgs e)
        {
            switch (Properties.Settings.Default.ItemSort)
            {
                case "ID": byIDToolStripMenuItem_Click(sender, e); break;
                case "Name": displayNameToolStripMenuItem_Click(sender, e); break;
                case "PluralName": pluralDisplayNameToolStripMenuItem_Click(sender, e); break;
                case "InternalName": internalNameToolStripMenuItem_Click(sender, e); break;
                case "Pocket": byPocketToolStripMenuItem_Click(sender, e); break;
                case "Price": byPriceToolStripMenuItem_Click(sender, e); break;
                case "UsabilityField": byFieldUsageToolStripMenuItem_Click(sender, e); break;
                case "UsabilityBattle": byBattleUsageToolStripMenuItem_Click(sender, e); break;
                case "SpecialItem": bySpecialItemsToolStripMenuItem_Click(sender, e); break;
                case "TMMoves": byTMMovesToolStripMenuItem_Click(sender, e); break;
                case "Description": byDescriptionToolStripMenuItem_Click(sender, e); break;
            }
        }

        private string pocketToString(int pocket)
        {
            switch (pocket)
            {
                case 1: return "Items";
                case 2: return "Medicine";
                case 3: return "Poké Balls";
                case 4: return "TMs & HMs";
                case 5: return "Berrires";
                case 6: return "Mail";
                case 7: return "Battle Items";
                case 8: return "Key Items";
                default: return "Items";
            }
        }
        private int pocketToInt(string pocket)
        {
            switch (pocket)
            {
                case "Items": return 1;
                case "Medicine": return 2;
                case "Poké Balls": return 3;
                case "TMs & HMs": return 4;
                case "Berrires": return 5;
                case "Mail": return 6;
                case "Battle Items": return 7;
                case "Key Items": return 8;
                default: return 1;
            }
        }
        private string specialItemToString(int specialitem)
        {
            switch (specialitem)
            {
                case 0: return "No";
                case 1: return "Mail";
                case 2: return "Mail w/ Images";
                case 3: return "Snag Ball";
                case 4: return "Poké Ball";
                case 5: return "Berry";
                case 6: return "Key Item";
                default: return "No";
            }
        }
        private int specialItemToInt(string specialitem)
        {
            switch (specialitem)
            {
                case "No": return 0;
                case "Mail": return 1;
                case "Mail w/ Images": return 2;
                case "Snag Ball": return 3;
                case "Poké Ball": return 4;
                case "Berry": return 5;
                case "Key Item": return 6;
                default: return 0;
            }

        }

        private void ItemEditor_Load(object sender, EventArgs e)
        {
            #region Setup Databindings
            itemBinder.DataSource = items;
            itemBox.DataSource = itemBinder;
            itemBox.DisplayMember = "name";

            moveBinder.DataSource = moves;
            tmMoveBox.DataSource = moveBinder;
            tmMoveBox.DisplayMember = "name";
            #endregion

            #region Loads items.txt
            var itemsInstance = PEGame.Instance.loadItemsInstance();
            if (itemsInstance.Count == 0)
            {
                Close();
            }
            else
            {
                items.Clear(); items.AddRange(itemsInstance);
            }
            #endregion
            #region Loads moves.txt
            terminate = !PEGame.Instance.loadMoves();
            if (terminate)
            {
                Close();
            }
            else
            {
                moves.Clear(); moves.AddRange(PEGame.Instance.moves);
            }
            #endregion


            //foreach (Item item in items)
            //{
            //    permItems.Add(item);
            //}

            thisid = items[0].intname;
            try
            {
                var iconPath = PEGame.Instance.root($@"Graphics\Items\{thisid}.png");
                using (var im = new Bitmap(iconPath)) { icon.Sprite = new Bitmap(im); }
                icon.Width = icon.Sprite.Height;
                icon.Height = icon.Sprite.Height;
                icon.Frame_Height = icon.Sprite.Height;
                icon.Frame_Width = icon.Sprite.Height;
                icon.FrameRate = 10;
            }
            catch (Exception) { }
            itemBinder.ResetBindings(false);
            moveBinder.ResetBindings(false);
            itemBox.SelectedIndex = 0;
            itemBox_SelectedIndexChanged(sender, e);
        }

        private void ItemEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!terminate)
            {
                if (!msg) { e.Cancel = true; return; }
                if (MessageBox.Show("Are you sure you want to exit? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Properties.Settings.Default.Save();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void itemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                thisid = items[itemBox.SelectedIndex].intname;
                foreach (Control c in Controls)
                {
                    c.Enabled = true;
                }
                Item item = items[itemBox.SelectedIndex];
                idBox.Value = item.id;
                intNameBox.Text = item.intname;
                nameBox.Text = item.name;
                pluralBox.Text = item.plural;
                pocketBox.Text = pocketToString(item.pocket);
                priceBox.Value = item.price;
                usabilityBattleBox.Value = item.usabilityBattle;
                usabilityFieldBox.Value = item.usabilityField;
                specialItemBox.Text = specialItemToString(item.specialItem);
                descBox.Text = item.description;
                if (!string.IsNullOrEmpty(item.tmMove))
                {
                    noTMItemBox.Checked = false;
                    tmMoveBox.Text = item.tmMove;
                }
                else
                {
                    noTMItemBox.Checked = false;
                    noTMItemBox.Checked = true;
                }
                try
                {
                    var p = PEGame.Instance.root($@"Graphics\Items\{thisid}.png");
                    using (var im = new Bitmap(p)) { icon.Sprite = new Bitmap(im); }
                    icon.Width = icon.Sprite.Height;
                    icon.Height = icon.Sprite.Height;
                    icon.Frame_Height = icon.Sprite.Height;
                    icon.Frame_Width = icon.Sprite.Height;
                }
                catch (Exception) { }
            }
            catch (Exception)
            {
                foreach (Control c in Controls)
                {
                    c.Enabled = false;
                }
                menuStrip1.Enabled = true;
            }
        }

        private void noTMItemBox_CheckedChanged(object sender, EventArgs e)
        {
            if (noTMItemBox.Checked)
            {
                tmMoveBox.Enabled = false;
                tmMoveBox.ResetText();
                items[itemBox.SelectedIndex].tmMove = null;
            }
            else
            {
                tmMoveBox.Enabled = true;
            }
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            idTip.SetToolTip(label1, "The internal ID of the item. This\r\nShould increment without missing numbers.");
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            nameTip.SetToolTip(label2, "The name of the item as displayed when singular.");
        }

        private void label48_MouseHover(object sender, EventArgs e)
        {
            intNameTip.SetToolTip(label48, "The internal name of the item. This can\r\n be referred to with a symbol (e.g. :REPEL)");
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            pluralTip.SetToolTip(label3, "The name of the item as displayed when plural.");
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            pocketTip.SetToolTip(label4, "The pocket this item will be stored in.");
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            priceTip.SetToolTip(label5, "How much the item will cost in a mart.\r\nBy default, it sells for half the price.\r\nSet to 0 to make it unsellable.");
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            useFieldTip.SetToolTip(label6, "How the item can be used in the field.\r\n0: The item cannot be used outside of battle/in the field.\r\n1: The item can be used on a Pokémon and disappears after use.\r\n2: The item can be used outside of battle, but not on a Pokémon.\r\n3: The item is a TM.\r\n4: The item is an HM.\r\n5: The item can be used on a Pokémon but doesn't disappear after use.");
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            useBattleTip.SetToolTip(label7, "How the item can be used in battle.\r\n0: The item cannot be used in battle.\r\n1: The item can be used on a Pokémon and disappears after use.\r\n2: The item is a Poké Ball, or is used on the active Pokémon you\r\n    are choosing a command for, or is used directly. (Great Ball, X Accuracy, Poké Doll, etc.)\r\n3: The item can be used on a Pokémon but doesn't disappear after use.\r\n4: The item can be used directly but doesn't disappear after use.");
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            specialItemTip.SetToolTip(label9, "What type of item the item is.");
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            tmMoveTip.SetToolTip(label10, "If the item is a TM, this is the move it teaches.");
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            descTip.SetToolTip(label8, "The description of the item as seen in the bag.");
        }

        private string generateAll()
        {
            string ret = null;
            for (int i = 0; i < items.Count; i++)
            {
                Item item = items[i];
                if (i != 0) { ret += "\r\n"; }
                ret += $"{item.id},{item.intname},{item.name},{item.plural},{item.pocket},{item.price},\"{item.description}\",{item.usabilityField},{item.usabilityBattle},{item.specialItem},{item.tmMove}";
            }
            return ret;
        }

        private string generateSelected()
        {
            Item item = items[itemBox.SelectedIndex];
            return $"{item.id},{item.intname},{item.name},{item.plural},{item.pocket},{item.price},\"{item.description}\",{item.usabilityField},{item.usabilityBattle},{item.specialItem},{item.tmMove}";
        }

        private void generateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) { MessageBox.Show("There are no items to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            Item item = items[itemBox.SelectedIndex];
            GenAbilityForm gaf = new GenAbilityForm();
            gaf.pbs = generateSelected();
            gaf.Show();
        }

        private void generateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) { MessageBox.Show("There are no items to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            GenAbilityForm gaf = new GenAbilityForm();
            gaf.pbs = generateAll();
            gaf.Show();
        }

        private void byIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) { return; }
            Item item = items[itemBox.SelectedIndex];
            items.Sort(delegate (Item i1, Item i2) { return i1.id.CompareTo(i2.id); });
            itemBinder.ResetBindings(false);
            itemBox.SelectedIndex = items.IndexOf(item);
            Properties.Settings.Default.ItemSort = "ID";
        }

        private void byPocketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) { return; }
            Item item = items[itemBox.SelectedIndex];
            items.Sort(delegate (Item i1, Item i2) { return i1.pocket.CompareTo(i2.pocket); });
            itemBinder.ResetBindings(false);
            itemBox.SelectedIndex = items.IndexOf(item);
            Properties.Settings.Default.ItemSort = "Pocket";
        }

        private void byPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) { return; }
            Item item = items[itemBox.SelectedIndex];
            items.Sort(delegate (Item i1, Item i2) { return i1.price.CompareTo(i2.price); });
            items.Reverse();
            itemBinder.ResetBindings(false);
            itemBox.SelectedIndex = items.IndexOf(item);
            Properties.Settings.Default.ItemSort = "Price";
        }

        private void byFieldUsageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) { return; }
            Item item = items[itemBox.SelectedIndex];
            items.Sort(delegate (Item i1, Item i2) { return i1.usabilityField.CompareTo(i2.usabilityField); });
            itemBinder.ResetBindings(false);
            itemBox.SelectedIndex = items.IndexOf(item);
            Properties.Settings.Default.ItemSort = "UsabilityField";
        }

        private void byBattleUsageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) { return; }
            Item item = items[itemBox.SelectedIndex];
            items.Sort(delegate (Item i1, Item i2) { return i1.usabilityBattle.CompareTo(i2.usabilityBattle); });
            itemBinder.ResetBindings(false);
            itemBox.SelectedIndex = items.IndexOf(item);
            Properties.Settings.Default.ItemSort = "UsabilityBattle";
        }

        private void bySpecialItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) { return; }
            Item item = items[itemBox.SelectedIndex];
            items.Sort(delegate (Item i1, Item i2) { return i1.specialItem.CompareTo(i2.specialItem); });
            itemBinder.ResetBindings(false);
            itemBox.SelectedIndex = items.IndexOf(item);
            Properties.Settings.Default.ItemSort = "SpecialItem";
        }

        private void byTMMovesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) { return; }
            Item item = items[itemBox.SelectedIndex];
            items.Sort(delegate (Item i1, Item i2) { return i1.sortableTMMove.CompareTo(i2.sortableTMMove); });
            itemBinder.ResetBindings(false);
            itemBox.SelectedIndex = items.IndexOf(item);
            Properties.Settings.Default.ItemSort = "TMMoves";
        }

        private void byDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) { return; }
            Item item = items[itemBox.SelectedIndex];
            items.Sort(delegate (Item i1, Item i2) { return i1.sortableDesc.CompareTo(i2.sortableDesc); });
            itemBinder.ResetBindings(false);
            itemBox.SelectedIndex = items.IndexOf(item);
            Properties.Settings.Default.ItemSort = "Description";
        }

        private void idBox_ValueChanged(object sender, EventArgs e)
        {
            items[itemBox.SelectedIndex].id = (int)idBox.Value;
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            items[itemBox.SelectedIndex].name = nameBox.Text;
            itemBinder.ResetBindings(false);
        }

        private void pluralBox_TextChanged(object sender, EventArgs e)
        {
            items[itemBox.SelectedIndex].plural = pluralBox.Text;
        }

        private void pocketBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            items[itemBox.SelectedIndex].pocket = pocketToInt(pocketBox.Text);
        }

        private void priceBox_ValueChanged(object sender, EventArgs e)
        {
            items[itemBox.SelectedIndex].price = (int)priceBox.Value;
        }

        private void usabilityFieldBox_ValueChanged(object sender, EventArgs e)
        {
            items[itemBox.SelectedIndex].usabilityField = (int)usabilityFieldBox.Value;
        }

        private void usabilityBattleBox_ValueChanged(object sender, EventArgs e)
        {
            items[itemBox.SelectedIndex].usabilityBattle = (int)usabilityBattleBox.Value;
        }

        private void specialItemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            items[itemBox.SelectedIndex].specialItem = specialItemToInt(specialItemBox.Text);
        }

        private void tmMoveBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            items[itemBox.SelectedIndex].tmMove = tmMoveBox.Text;
        }

        private void intNameBox_TextChanged(object sender, EventArgs e)
        {
            items[itemBox.SelectedIndex].intname = intNameBox.Text;
        }

        private void descBox_TextChanged(object sender, EventArgs e)
        {
            items[itemBox.SelectedIndex].description = descBox.Text;
        }

        private void displayNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) { return; }
            Item item = items[itemBox.SelectedIndex];
            items.Sort(delegate (Item i1, Item i2) { return i1.sortableName.CompareTo(i2.sortableName); });
            itemBinder.ResetBindings(false);
            itemBox.SelectedIndex = items.IndexOf(item);
            Properties.Settings.Default.ItemSort = "Name";
        }

        private void pluralDisplayNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) { return; }
            Item item = items[itemBox.SelectedIndex];
            items.Sort(delegate (Item i1, Item i2) { return i1.sortablePlural.CompareTo(i2.sortablePlural); });
            itemBinder.ResetBindings(false);
            itemBox.SelectedIndex = items.IndexOf(item);
            Properties.Settings.Default.ItemSort = "PluralName";
        }

        private void internalNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (items.Count == 0) { return; }
            Item item = items[itemBox.SelectedIndex];
            items.Sort(delegate (Item i1, Item i2) { return i1.sortableIntName.CompareTo(i2.sortableIntName); });
            itemBinder.ResetBindings(false);
            itemBox.SelectedIndex = items.IndexOf(item);
            Properties.Settings.Default.ItemSort = "InternalName";
        }

        /*private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.Clear();
            foreach (Item item in permItems) { if (item.pocket == 1) { items.Add(item); } }
            itemBinder.ResetBindings(false);
            if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);
        }

        private void medicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.Clear();
            foreach (Item item in permItems) { if (item.pocket == 2) { items.Add(item); } }
            itemBinder.ResetBindings(false);
            if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);
        }

        private void pokéBallsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.Clear();
            foreach (Item item in permItems) { if (item.pocket == 3) { items.Add(item); } }
            itemBinder.ResetBindings(false);
            if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);
        }

        private void tMsHMsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.Clear();
            foreach (Item item in permItems) { if (item.pocket == 4) { items.Add(item); } }
            itemBinder.ResetBindings(false);
            if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);
        }

        private void berriewsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.Clear();
            foreach (Item item in permItems) { if (item.pocket == 5) { items.Add(item); } }
            itemBinder.ResetBindings(false);
            if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);
        }

        private void mailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.Clear();
            foreach (Item item in permItems) { if (item.pocket == 6) { items.Add(item); } }
            itemBinder.ResetBindings(false);
            if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);
        }

        private void battleItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.Clear();
            foreach (Item item in permItems) { if (item.pocket == 7) { items.Add(item); } }
            itemBinder.ResetBindings(false);
            if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);
        }

        private void keyItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.Clear();
            foreach (Item item in permItems) { if (item.pocket == 8) { items.Add(item); } }
            itemBinder.ResetBindings(false);
            if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);
        }

        private void resetFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.Clear();
            foreach(Item item in permItems) { items.Add(item); }
            itemBinder.ResetBindings(false);
            if (items.Count > 0) { sortLast(sender, e); }
        }

        private void greaterThanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberInput ni = new NumberInput();
            ni.ShowDialog();
            if (ni.btn)
            {
                items.Clear();
                foreach (Item item in permItems) { if (item.price >= ni.value) { items.Add(item); } }
                itemBinder.ResetBindings(false);
                if (items.Count > 0) byPriceToolStripMenuItem_Click(sender, e);
            }
        }

        private void lessThanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberInput ni = new NumberInput();
            ni.ShowDialog();
            if (ni.btn)
            {
                items.Clear();
                foreach (Item item in permItems) { if (item.price <= ni.value) { items.Add(item); } }
                itemBinder.ResetBindings(false);
                if (items.Count > 0) byPriceToolStripMenuItem_Click(sender, e);
            }
        }

        private void rangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberBetween nb = new NumberBetween();
            nb.ShowDialog();
            if (nb.btn)
            {
                items.Clear();
                foreach (Item item in permItems) { if (item.price >= nb.value1 && item.price <= nb.value2) { items.Add(item); } }
                itemBinder.ResetBindings(false);
                if (items.Count > 0) byPriceToolStripMenuItem_Click(sender, e);
            }
        }

        private void mailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            items.Clear();
            foreach (Item item in permItems) { if (item.specialItem == 1 || item.specialItem == 2) { items.Add(item); } }
            itemBinder.ResetBindings(false);
            if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);
        }

        private void pokéBallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.Clear();
            foreach (Item item in permItems) { if (item.specialItem == 4) { items.Add(item); } }
            itemBinder.ResetBindings(false);
            if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);

        }

        private void berryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.Clear();
            foreach (Item item in permItems) { if (item.specialItem == 5) { items.Add(item); } }
            itemBinder.ResetBindings(false);
            if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);
        }

        private void keyItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.Clear();
            foreach (Item item in permItems) { if (item.specialItem == 6) { items.Add(item); } }
            itemBinder.ResetBindings(false);
            if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);
        }

        private void basedOnTMItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            items.Clear();
            foreach (Item item in permItems) { if (item.usabilityField == 3 || item.usabilityField == 4) { items.Add(item); } }
            itemBinder.ResetBindings(false);
            if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);
        }

        private void basedOnFieldUsabilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberInput ni = new NumberInput();
            ni.ShowDialog();
            if (ni.btn)
            {
                items.Clear();
                foreach (Item item in permItems) { if (item.usabilityField == ni.value) { items.Add(item); } }
                itemBinder.ResetBindings(false);
                if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);
            }
        }

        private void basedOnBattleUsabilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberInput ni = new NumberInput();
            ni.ShowDialog();
            if (ni.btn)
            {
                items.Clear();
                foreach (Item item in permItems) { if (item.usabilityBattle == ni.value) { items.Add(item); } }
                itemBinder.ResetBindings(false);
                if (items.Count > 0) displayNameToolStripMenuItem_Click(sender, e);
            }
        }*/

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to return? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Properties.Settings.Default.Save();

                msg = false;
                Close();
                Dispose();
            }
        }

        private void openItemstxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(PEGame.Instance.root(@"PBS\items.txt"));
        }

        private void findInternalNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntNameFinder inf = new IntNameFinder();
            inf.ShowDialog();
            //resetFilterToolStripMenuItem_Click(sender, e);
            bool found = false;
            if (!IntNameFinder.btn) { return; }
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].intname == IntNameFinder.result.ToUpper())
                {
                    itemBox.SelectedIndex = items.IndexOf(items[i]);
                    found = true;
                    break;
                }
            }
            if (!found) { MessageBox.Show("The internal name could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            //resetFilterToolStripMenuItem_Click(sender, e);
            items.Add(new Item(items.Count + 1, null, null, null, 1, 0, null, 0, 0, 0, null));
            itemBinder.ResetBindings(false);
            itemBox.SelectedIndex = items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            items.RemoveAt(itemBox.SelectedIndex);
            itemBinder.ResetBindings(false);
        }

        private void reloadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reload all data?\r\nThis will overwrite any unsaved changes.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                items.Clear();
                moves.Clear();
                ItemEditor_Load(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose an icon for " + items[itemBox.SelectedIndex].name;
            ofd.Filter = "PNG Files (*.png)|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var p = PEGame.Instance.root($@"Graphics\Items\{thisid}.png");
                if (Path.GetFullPath(p) != ofd.FileName)
                {
                    if (File.Exists(p))
                    {
                        var backupP = PEGame.Instance.root($@"Backups\Items\{thisid}.png");
                        if (File.Exists(backupP))
                        {
                            File.Delete(PEGame.Instance.root($@"Backups\Items\{thisid}.png"));
                        }
                        File.Move(p, PEGame.Instance.root($@"Backups\Items\{thisid}.png"));
                    }
                    File.Copy(ofd.FileName, p);
                    itemBox_SelectedIndexChanged(sender, e);
                }
            }
        }
    }
}
