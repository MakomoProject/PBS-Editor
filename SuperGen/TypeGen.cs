using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SuperGen;
using lib;
using System.Diagnostics;
using static SuperGen.SuperForm;

namespace MiscGen
{
    public partial class TypeGen : Form
    {
        private bool msg = true;
        private bool terminate = false;
        private BindingSource wnessBinder = new BindingSource();
        private BindingSource resBinder = new BindingSource();
        private BindingSource superBinder = new BindingSource();
        private BindingSource immuneBinder = new BindingSource();
        private BindingSource typeBinder = new BindingSource();
        private List<Typing> types = new List<Typing>();

        public TypeGen()
        {
            InitializeComponent();
        }

        private void TypeGen_Load(object sender, EventArgs e)
        {
            #region Loads types.txt
            var typings = PEGame.Instance.loadTypesInstance();
            if (typings.Count == 0)
            {
                terminate = true;
                Close();
                return;
            }
            else
            {
                types.Clear(); types.AddRange(typings);
                typeBinder.ResetBindings(false);
            }
            #endregion
            typeBinder.DataSource = types;
            typeBox.DataSource = typeBinder;
            typeBox.DisplayMember = "name";

            wnessBinder.DataSource = types[typeBox.SelectedIndex].weaknesses;
            wnessBox.DataSource = wnessBinder;
            wnessBox.DisplayMember = "name";
            wnessBinder.ResetBindings(false);

            resBinder.DataSource = types[typeBox.SelectedIndex].resistances;
            resBox.DataSource = resBinder;
            resBox.DisplayMember = "name";
            resBinder.ResetBindings(false);

            superBinder.DataSource = types[typeBox.SelectedIndex].supereffectives;
            superBox.DataSource = superBinder;
            superBox.DisplayMember = "name";
            superBinder.ResetBindings(false);

            immuneBinder.DataSource = types[typeBox.SelectedIndex].immunities;
            imBox.DataSource = immuneBinder;
            imBox.DisplayMember = "name";
            immuneBinder.ResetBindings(false);

            Sort:
            switch (SuperGen.Properties.Settings.Default.TypeSortMethod)
            {
                case "ID": types.Sort(delegate (Typing t1, Typing t2) { return t1.id.CompareTo(t2.id); }); break;
                case "Weaknesses": types.Sort(delegate (Typing t1, Typing t2) { return t1.weaknesses.Count.CompareTo(t2.weaknesses.Count); }); types.Reverse(); break;
                case "Resistances": types.Sort(delegate (Typing t1, Typing t2) { return t1.resistances.Count.CompareTo(t2.resistances.Count); }); types.Reverse(); break;
                case "Supereffectivenesses": types.Sort(delegate (Typing t1, Typing t2) { return t1.supereffectives.Count.CompareTo(t2.supereffectives.Count); }); types.Reverse(); break;
                case "Immunities": types.Sort(delegate (Typing t1, Typing t2) { return t1.immunities.Count.CompareTo(t2.immunities.Count); }); types.Reverse(); break;
                case "DisplayName": types.Sort(delegate (Typing t1, Typing t2) { return t1.name.CompareTo(t2.name); }); break;
                case "InternalName": types.Sort(delegate (Typing t1, Typing t2) { return t1.intname.CompareTo(t2.intname); }); break;
                default: SuperGen.Properties.Settings.Default.TypeSortMethod = "ID"; goto Sort;
            }
            typeBinder.ResetBindings(false);
            bool found = false;
            for (int i = 0; i < types.Count; i++)
            { if (types[i].intname == SuperGen.Properties.Settings.Default.TypeIntName) { typeBox.SelectedIndex = i; found = true; } }
            if (!found && types.Count > 0) { typeBox.SelectedIndex = 0; }
        }

        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (types.Count > 0)
            {
                idBox.Value = types[typeBox.SelectedIndex].id;
                nameBox.Text = types[typeBox.SelectedIndex].name;
                intNameBox.Text = types[typeBox.SelectedIndex].intname;
                wnessBinder.DataSource = types[typeBox.SelectedIndex].weaknesses;
                resBinder.DataSource = types[typeBox.SelectedIndex].resistances;
                superBinder.DataSource = types[typeBox.SelectedIndex].supereffectives;
                immuneBinder.DataSource = types[typeBox.SelectedIndex].immunities;
                isSpecialType.Checked = types[typeBox.SelectedIndex].specialtype;
                wnessBinder.ResetBindings(false);
                resBinder.ResetBindings(false);
                superBinder.ResetBindings(false);
                immuneBinder.ResetBindings(false);
                changeVisible();
            }
            else
            {
                changeVisible(false);
            }
        }

        private void changeVisible(bool bln = true)
        {
            for (int i = 1; i < 12; i++) { ((Label)Controls[$"label{i}"]).Enabled = bln; }
            idBox.Enabled = bln;
            nameBox.Enabled = bln;
            intNameBox.Enabled = bln;
            wnessBox.Enabled = bln;
            resBox.Enabled = bln;
            superBox.Enabled = bln;
            imBox.Enabled = bln;
            addWnessBtn.Enabled = bln;
            removeWnessBtn.Enabled = bln;
            addResBtn.Enabled = bln;
            removeResBtn.Enabled = bln;
            addSuperBtn.Enabled = bln;
            removeSuperBtn.Enabled = bln;
            addImmuneBtn.Enabled = bln;
            removeImmuneBtn.Enabled = bln;
            wnessNameBox.Enabled = bln;
            resNameBox.Enabled = bln;
            superNameBox.Enabled = bln;
            immuneNameBox.Enabled = bln;
            isSpecialType.Enabled = bln;
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            WnessTooltip.SetToolTip(label5, "If a Pokémon of this type\r\nis hit by any of these types,\r\nthe move will be super effective.");
        }
        private void label7_MouseHover(object sender, EventArgs e)
        {
            ResTooltip.SetToolTip(label7, "If a Pokémon of this type\r\nis hit by any of these types,\r\nthe move will be not very effective.");
        }
        private void label8_MouseHover(object sender, EventArgs e)
        {
            SuperTooltip.SetToolTip(label8, "If a move of this type hits\r\n an opponent with any of these\r\n types, it will be super effective.");
        }
        private void label10_MouseHover(object sender, EventArgs e)
        {
            ImTooltip.SetToolTip(label10, "If a Pokémon of this type\r\nwould be hit by any of these\r\ntypes, the move will fail.");
        }

        private void addWnessBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(wnessNameBox.Text)) {
                types[typeBox.SelectedIndex].weaknesses.Add(wnessNameBox.Text);
                wnessBinder.ResetBindings(false);
                for (int i = 0; i < types.Count; i++)
                { if (types[i].intname == wnessNameBox.Text) {
                        types[i].supereffectives.Add(types[typeBox.SelectedIndex].intname);
                        superBinder.ResetBindings(false); } }
                wnessNameBox.Clear(); }
        }
        private void addResBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(resNameBox.Text)) { types[typeBox.SelectedIndex].resistances.Add(resNameBox.Text); resBinder.ResetBindings(false); resNameBox.Clear(); }
        }
        private void addSuperBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(superNameBox.Text)) {
                types[typeBox.SelectedIndex].supereffectives.Add(superNameBox.Text);
                superBinder.ResetBindings(false);
                for (int i = 0; i < types.Count; i++)
                { if (types[i].intname == superNameBox.Text) {
                        types[i].weaknesses.Add(types[typeBox.SelectedIndex].intname); } }
                superNameBox.Clear(); }
        }
        private void addImmuneBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(immuneNameBox.Text)) { types[typeBox.SelectedIndex].immunities.Add(immuneNameBox.Text); immuneBinder.ResetBindings(false); immuneNameBox.Clear(); }
        }

        private void removeWnessBtn_Click(object sender, EventArgs e)
        {
            if (types[typeBox.SelectedIndex].weaknesses.Count > 0) {
                for (int i = 0; i < types.Count; i++)
                { if (types[i].intname == wnessBox.Text) {
                        types[i].supereffectives.Remove(types[typeBox.SelectedIndex].intname); } }
                types[typeBox.SelectedIndex].weaknesses.RemoveAt(wnessBox.SelectedIndex);
                wnessBinder.ResetBindings(false); }
        }
        private void removeResBtn_Click(object sender, EventArgs e)
        {
            if (types[typeBox.SelectedIndex].resistances.Count > 0) { types[typeBox.SelectedIndex].resistances.RemoveAt(resBox.SelectedIndex); resBinder.ResetBindings(false); }
        }
        private void removeSuperBtn_Click(object sender, EventArgs e)
        {
            if (types[typeBox.SelectedIndex].supereffectives.Count > 0)
            { for (int i = 0; i < types.Count; i++)
                { if (types[i].weaknesses.Contains(types[typeBox.SelectedIndex].intname)) {
                        types[i].weaknesses.Remove(types[typeBox.SelectedIndex].intname); } }
                types[typeBox.SelectedIndex].supereffectives.RemoveAt(superBox.SelectedIndex);
                superBinder.ResetBindings(false); }
        }
        private void removeImmuneBtn_Click(object sender, EventArgs e)
        {
            if (types[typeBox.SelectedIndex].immunities.Count > 0) { types[typeBox.SelectedIndex].immunities.RemoveAt(imBox.SelectedIndex); immuneBinder.ResetBindings(false); }
        }

        private void idBox_ValueChanged(object sender, EventArgs e)
        {
            types[typeBox.SelectedIndex].id = Convert.ToInt32(idBox.Value);
        }
        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            types[typeBox.SelectedIndex].name = nameBox.Text; typeBinder.ResetBindings(false);
        }
        private void intNameBox_TextChanged(object sender, EventArgs e)
        {
            types[typeBox.SelectedIndex].intname = intNameBox.Text;
        }

        private void isSpecialType_CheckedChanged(object sender, EventArgs e)
        {
            if (isSpecialType.Checked) { types[typeBox.SelectedIndex].specialtype = true; }
            else { types[typeBox.SelectedIndex].specialtype = false; }
        }
        private void isSpecialType_MouseHover(object sender, EventArgs e)
        {
            specialTooltip.SetToolTip(isSpecialType, "In Gen 3, special and physical\r\ncategories were based on type\r\n(I'm pretty sure), and when this is\r\n checked, all moves of this\r\ntype will be special.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            types.Add(new Typing(types.Count + 1, "NewType", "NEWTYPE", new List<string>(), new List<string>(), new List<string>(), new List<string>(), true, false));
            typeBinder.ResetBindings(false);
            typeBox.SelectedIndex = types.Count - 1;
            types.Sort(delegate (Typing t1, Typing t2) { return t1.id.CompareTo(t2.id); });
            typeBox_SelectedIndexChanged(sender, e);
            button5.Enabled = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            types.RemoveAt(typeBox.SelectedIndex);
            typeBinder.ResetBindings(false);
            types.Sort(delegate (Typing t1, Typing t2) { return t1.id.CompareTo(t2.id); });
            if (types.Count == 0) { button5.Enabled = false; } else { button5.Enabled = true; typeBox_SelectedIndexChanged(sender, e); }
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (types.Count > 0)
            {
                byIDToolStripMenuItem_Click(sender, e);
                GennedTypes g = new GennedTypes();
                g.txt = null;
                for (int i = 0; i < types.Count; i++)
                { g.txt +=
$@"[{types[i].id}]
Name={types[i].name}
InternalName={types[i].intname}
"; if (types[i].specialtype) { g.txt += @"IsSpecialType=true
"; } if (types[i].pseudotype) { g.txt += @"IsPseudoType=true
"; } if (types[i].weaknesses.Count > 0) {
g.txt += "Weaknesses="; for (int j = 0; j < types[i].weaknesses.Count; j++) { if (j != 0) {
g.txt += "," + types[i].weaknesses[j]; } else {
g.txt += types[i].weaknesses[j]; } } g.txt += @"
"; } if (types[i].resistances.Count > 0)
{ g.txt += "Resistances="; for (int j = 0; j < types[i].resistances.Count; j++) { if (j != 0) {
g.txt += "," + types[i].resistances[j]; } else {
g.txt += types[i].resistances[j]; } } g.txt += @"
"; } if (types[i].immunities.Count > 0) {
g.txt += "Immunities="; for (int j = 0; j < types[i].immunities.Count; j++) {
if (j != 0) { g.txt += "," + types[i].immunities[j]; } else {
g.txt += types[i].immunities[j]; } } g.txt += @"
"; } g.txt += @"
"; } g.Show();
            }
            else
            {
                MessageBox.Show("There are no types to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (types.Count > 0)
            {
                byIDToolStripMenuItem_Click(sender, e);
                GennedTypes g = new GennedTypes();
                g.txt = null;
                for (int i = 0; i < types.Count; i++)
                { g.txt +=
$@"[{types[i].id}]
Name={types[i].name}
InternalName={types[i].intname}
"; if (types[i].specialtype) { g.txt += @"IsSpecialType=true
"; } if (types[i].pseudotype) { g.txt += @"IsPseudoType=true
"; } if (types[i].weaknesses.Count > 0) {
g.txt += "Weaknesses="; for (int j = 0; j < types[i].weaknesses.Count; j++) { if (j != 0) {
g.txt += "," + types[i].weaknesses[j]; } else {
g.txt += types[i].weaknesses[j]; } } g.txt += @"
"; } if (types[i].resistances.Count > 0)
{ g.txt += "Resistances="; for (int j = 0; j < types[i].resistances.Count; j++) { if (j != 0) {
g.txt += "," + types[i].resistances[j]; } else {
g.txt += types[i].resistances[j]; } } g.txt += @"
"; } if (types[i].immunities.Count > 0) {
g.txt += "Immunities="; for (int j = 0; j < types[i].immunities.Count; j++) {
if (j != 0) { g.txt += "," + types[i].immunities[j]; } else {
g.txt += types[i].immunities[j]; } } g.txt += @"
"; } g.txt += @"
"; }
                PEGame.exportFile("types.txt", g.txt);
            }
            else
            {
                MessageBox.Show("There are no types to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void overwriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (types.Count > 0)
            {
                if (MessageBox.Show("You are about to overwrite \"types.txt\". Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    byIDToolStripMenuItem_Click(sender, e);
                    GennedTypes g = new GennedTypes();
                    g.txt = null;
                    for (int i = 0; i < types.Count; i++)
                    { g.txt +=
$@"[{types[i].id}]
Name={types[i].name}
InternalName={types[i].intname}
"; if (types[i].specialtype) { g.txt += @"IsSpecialType=true
"; } if (types[i].pseudotype) { g.txt += @"IsPseudoType=true
"; } if (types[i].weaknesses.Count > 0) {
g.txt += "Weaknesses="; for (int j = 0; j < types[i].weaknesses.Count; j++) { if (j != 0) {
g.txt += "," + types[i].weaknesses[j]; } else {
g.txt += types[i].weaknesses[j]; } } g.txt += @"
"; } if (types[i].resistances.Count > 0)
{ g.txt += "Resistances="; for (int j = 0; j < types[i].resistances.Count; j++) { if (j != 0) {
g.txt += "," + types[i].resistances[j]; } else {
g.txt += types[i].resistances[j]; } } g.txt += @"
"; } if (types[i].immunities.Count > 0) {
g.txt += "Immunities="; for (int j = 0; j < types[i].immunities.Count; j++) {
if (j != 0) { g.txt += "," + types[i].immunities[j]; } else {
g.txt += types[i].immunities[j]; } } g.txt += @"
"; } g.txt += @"
"; }
                    PEGame.exportFile("types.txt", g.txt); }
            }
            else
            {
                MessageBox.Show("There are no types to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                SuperGen.Properties.Settings.Default.TypeIntName = types[typeBox.SelectedIndex].intname;
                SuperGen.Properties.Settings.Default.Save();

                msg = false;
                Close();
                Dispose();
            }
        }

        private void byIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Typing t = types[typeBox.SelectedIndex];
            types.Sort(delegate (Typing t1, Typing t2) { return t1.id.CompareTo(t2.id); });
            typeBinder.ResetBindings(false);
            SuperGen.Properties.Settings.Default.TypeSortMethod = "ID";
            typeBox.SelectedIndex = types.IndexOf(t);
        }
        private void byWeaknessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Typing t = types[typeBox.SelectedIndex];
            types.Sort(delegate (Typing t1, Typing t2) { return t1.weaknesses.Count.CompareTo(t2.weaknesses.Count); });
            types.Reverse();
            typeBinder.ResetBindings(false);
            SuperGen.Properties.Settings.Default.TypeSortMethod = "Weaknesses";
            typeBox.SelectedIndex = types.IndexOf(t);
        }
        private void byResistancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Typing t = types[typeBox.SelectedIndex];
            types.Sort(delegate (Typing t1, Typing t2) { return t1.resistances.Count.CompareTo(t2.resistances.Count); });
            types.Reverse();
            typeBinder.ResetBindings(false);
            SuperGen.Properties.Settings.Default.TypeSortMethod = "Resistances";
            typeBox.SelectedIndex = types.IndexOf(t);
        }
        private void bySuperEffectivenessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Typing t = types[typeBox.SelectedIndex];
            types.Sort(delegate (Typing t1, Typing t2) { return t1.supereffectives.Count.CompareTo(t2.supereffectives.Count); });
            types.Reverse();
            typeBinder.ResetBindings(false);
            SuperGen.Properties.Settings.Default.TypeSortMethod = "Supereffectivenesses";
            typeBox.SelectedIndex = types.IndexOf(t);
        }
        private void byImmunitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Typing t = types[typeBox.SelectedIndex];
            types.Sort(delegate (Typing t1, Typing t2) { return t1.immunities.Count.CompareTo(t2.immunities.Count); });
            types.Reverse();
            typeBinder.ResetBindings(false);
            SuperGen.Properties.Settings.Default.TypeSortMethod = "Immunities";
            typeBox.SelectedIndex = types.IndexOf(t);
        }
        private void displayNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Typing t = types[typeBox.SelectedIndex];
            types.Sort(delegate (Typing t1, Typing t2) { return t1.name.CompareTo(t2.name); });
            typeBinder.ResetBindings(false);
            SuperGen.Properties.Settings.Default.TypeSortMethod = "DisplayName";
            typeBox.SelectedIndex = types.IndexOf(t);
        }
        private void internalNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Typing t = types[typeBox.SelectedIndex];
            types.Sort(delegate (Typing t1, Typing t2) { return t1.intname.CompareTo(t2.intname); });
            typeBinder.ResetBindings(false);
            SuperGen.Properties.Settings.Default.TypeSortMethod = "InternalName";
            typeBox.SelectedIndex = types.IndexOf(t);
        }

        private void TypeGen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!terminate)
            {
                if (!msg) { e.Cancel = true; return; }
                if (MessageBox.Show("Are you sure you want to exit? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    SuperGen.Properties.Settings.Default.TypeIntName = types[typeBox.SelectedIndex].intname;
                    SuperGen.Properties.Settings.Default.Save();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void openTypestxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(PEGame.Instance.root( @"PBS\types.txt"));
        }

        private void findInternalNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntNameFinder inf = new IntNameFinder();
            inf.ShowDialog();
            bool found = false;
            if (!IntNameFinder.btn) { return; }
            for (int i = 0; i < types.Count; i++)
            {
                if (types[i].intname == IntNameFinder.result.ToUpper())
                {
                    typeBox.SelectedIndex = types.IndexOf(types[i]);
                    found = true;
                    break;
                }
            }
            if (!found) { MessageBox.Show("The internal name could not be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void reloadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reload all data?\r\nThis will overwrite any unsaved changes.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                types.Clear();
                TypeGen_Load(sender, e);
            }
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            idTip.SetToolTip(label1, "The internal ID of the Type.");
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            nameTip.SetToolTip(label2, "The display name of the Type.");
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            intNameTip.SetToolTip(label3, "The internal name of the Type.");
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            typeTip.SetToolTip(label4, "The type to add to the list.");
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            typeTip.SetToolTip(label6, "The type to add to the list.");
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            typeTip.SetToolTip(label9, "The type to add to the list.");
        }

        private void label11_MouseHover(object sender, EventArgs e)
        {
            typeTip.SetToolTip(label11, "The type to add to the list.");
        }
    }
}
