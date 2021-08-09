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
using lib;
using static SuperGen.SuperForm;
using System.Diagnostics;

namespace SuperGen
{
    public partial class AbilityForm : Form
    {
        private bool msg = true;
        private bool terminate = false;
        private List<Ability> abilities = new List<Ability>();
        private BindingSource abilityBinder = new BindingSource();

        public AbilityForm()
        {
            InitializeComponent();
        }

        private void AbilityForm_Load(object sender, EventArgs e)
        {
            abilityBinder.DataSource = abilities;
            abilityBox.DataSource = abilityBinder;
            abilityBox.DisplayMember = "name";

            if (File.Exists(SuperForm.gameRoot( @"PBS\abilities.txt")))
            {
                StreamReader sr = new StreamReader(File.OpenRead(SuperForm.gameRoot(@"PBS\abilities.txt")));
                string dat = sr.ReadToEnd();
                if (string.IsNullOrEmpty(dat))
                {
                    emptyFile("Ability Editor", "abilities");
                    terminate = true;
                    Close();
                    return;
                }
                List<string> data = new List<string>();
                data = dat.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                sr.Close();
                for (int i = 0; i < data.Count; i++)
                {
                    try
                    {
                        if (isUsable(data[i]))
                        {
                            int id = Convert.ToInt32(data[i].Split(',')[0]);
                            string name = data[i].Split(',')[2];
                            string intname = data[i].Split(',')[1];
                            string desc = null;

                            List<string> temp = data[i].Split(',').ToList();
                            for (int j = 3; j < temp.Count; j++)
                            {
                                if (temp.Count == 4) { desc += temp[j]; }
                                else if (j == 3) { desc += temp[j]; }
                                else { desc += "," + temp[j]; }
                            }
                            string description = null;
                            foreach (char c in desc)
                            {
                                if (c != '"' && c != '�') { description += c; }
                                else if (c == '�') { description += 'é'; }
                            }
                            abilities.Add(new Ability(id, name, intname, description));
                        }
                    }
                    catch (Exception)
                    {
                        invalidLine("abilities", data[i], "Ability Editor");
                        terminate = true;
                        Close();
                        return;
                    }
                }
            }
            else { fileNotFound("abilities", "Ability Editor"); terminate = true; Close(); return; }
            Sort:
            switch (Properties.Settings.Default.AbilSortMethod)
            {
                case "ID": abilities.Sort(delegate (Ability a1, Ability a2) { return a1.id.CompareTo(a2.id); }); break;
                case "Name": abilities.Sort(delegate (Ability a1, Ability a2) { return a1.name.CompareTo(a2.name); }); break;
                case "IntName": abilities.Sort(delegate (Ability a1, Ability a2) { return a1.intname.CompareTo(a2.intname); }); break;
                case "Desc": abilities.Sort(delegate (Ability a1, Ability a2) { return a1.description.CompareTo(a2.description); }); break;
                default: Properties.Settings.Default.AbilSortMethod = "Name"; goto Sort;
            }
            abilityBinder.ResetBindings(false);
            if (abilities.Count == 0) { removeAbilityBtn.Enabled = false; } else { removeAbilityBtn.Enabled = true; }

            bool found = false;
            for (int i = 0; i < abilities.Count; i++)
            {
                if (abilities[i].intname == Properties.Settings.Default.AbilIntName) { abilityBox.SelectedIndex = i; found = true; }
            }
            if (!found && abilities.Count > 0) { abilityBox.SelectedIndex = 0; }
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to return? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Properties.Settings.Default.AbilIntName = abilities[abilityBox.SelectedIndex].intname;
                Properties.Settings.Default.Save();

                msg = false;
                Close();
                Dispose();
            }
        }

        private void addAbilityBtn_Click(object sender, EventArgs e)
        {
            abilities.Add(new Ability(abilities.Count, null, null, null));
            abilityBinder.ResetBindings(false);
            abilityBox.SelectedIndex = abilities.Count - 1;
            removeAbilityBtn.Enabled = true;
            abilityBox_SelectedIndexChanged(sender, e);
        }
        private void removeAbilityBtn_Click(object sender, EventArgs e)
        {
            if (abilities.Count > 0)
            {
                abilities.RemoveAt(abilityBox.SelectedIndex);
                abilityBinder.ResetBindings(false);
                if (abilities.Count == 0) { removeAbilityBtn.Enabled = false; } else { abilityBox_SelectedIndexChanged(sender, e); removeAbilityBtn.Enabled = true; }
            }
        }

        private void byIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ability a = abilities[abilityBox.SelectedIndex];
            Properties.Settings.Default.AbilSortMethod = "ID";
            abilities.Sort(delegate (Ability a1, Ability a2) { return a1.id.CompareTo(a2.id); });
            abilityBinder.ResetBindings(false);
            abilityBox.SelectedIndex = abilities.IndexOf(a);
        }
        private void displayNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ability a = abilities[abilityBox.SelectedIndex];
            Properties.Settings.Default.AbilSortMethod = "ID";
            abilities.Sort(delegate (Ability a1, Ability a2) { return a1.name.CompareTo(a2.name); });
            abilityBinder.ResetBindings(false);
            abilityBox.SelectedIndex = abilities.IndexOf(a);
        }
        private void internalNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ability a = abilities[abilityBox.SelectedIndex];
            Properties.Settings.Default.AbilSortMethod = "ID";
            abilities.Sort(delegate (Ability a1, Ability a2) { return a1.intname.CompareTo(a2.intname); });
            abilityBinder.ResetBindings(false);
            abilityBox.SelectedIndex = abilities.IndexOf(a);
        }
        private void byDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ability a = abilities[abilityBox.SelectedIndex];
            Properties.Settings.Default.AbilSortMethod = "ID";
            abilities.Sort(delegate (Ability a1, Ability a2) { return a1.description.CompareTo(a2.description); });
            abilityBinder.ResetBindings(false);
            abilityBox.SelectedIndex = abilities.IndexOf(a);
        }

        private void abilityBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (abilities.Count > 0)
            {
                idBox.Value = abilities[abilityBox.SelectedIndex].id;
                nameBox.Text = abilities[abilityBox.SelectedIndex].name;
                intNameBox.Text = abilities[abilityBox.SelectedIndex].intname;
                descBox.Text = abilities[abilityBox.SelectedIndex].description;
                label1.Enabled = true;
                label2.Enabled = true;
                label3.Enabled = true;
                label4.Enabled = true;
                idBox.Enabled = true;
                nameBox.Enabled = true;
                intNameBox.Enabled = true;
                descBox.Enabled = true;
            }
            else
            {
                label1.Enabled = false;
                label2.Enabled = false;
                label3.Enabled = false;
                label4.Enabled = false;
                idBox.Enabled = false;
                nameBox.Enabled = false;
                intNameBox.Enabled = false;
                descBox.Enabled = false;
            }
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            abilities[abilityBox.SelectedIndex].name = nameBox.Text;
            abilityBinder.ResetBindings(false);
            string ret = null;
            foreach (char c in nameBox.Text)
            {
                if (c == 'é') { ret += 'E'; }
                else if (c != ' ') { ret += c.ToString().ToUpper(); }
            }
            intNameBox.Text = ret;
        }
        private void idBox_ValueChanged(object sender, EventArgs e)
        {
            abilities[abilityBox.SelectedIndex].id = (int)idBox.Value;
            abilityBinder.ResetBindings(false);
        }
        private void intNameBox_TextChanged(object sender, EventArgs e)
        {
            abilities[abilityBox.SelectedIndex].intname = intNameBox.Text;
            abilityBinder.ResetBindings(false);
        }
        private void descBox_TextChanged(object sender, EventArgs e)
        {
            abilities[abilityBox.SelectedIndex].description = descBox.Text;
            abilityBinder.ResetBindings(false);
        }

        private void generateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ability a = abilities[abilityBox.SelectedIndex];
            GenAbilityForm gaf = new GenAbilityForm();
            gaf.pbs += $@"{a.id},{a.intname},{a.name},""{a.description}""";
            gaf.Show();
        }

        private void generateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            abilities.Sort(delegate (Ability a1, Ability a2) { return a1.id.CompareTo(a2.id); });
            abilityBinder.ResetBindings(false);
            GenAbilityForm gaf = new GenAbilityForm();
            for (int i = 0; i < abilities.Count; i++)
            {
                Ability a = abilities[i];
                if (i != abilities.Count - 1) { gaf.pbs += $"{a.id},{a.intname},{a.name},\"{a.description}\"\r\n"; }
                else { gaf.pbs += $@"{a.id},{a.intname},{a.name},""{a.description}"""; }
            }
            gaf.Show();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ability a = abilities[abilityBox.SelectedIndex];
            string txt = $"{a.id},{a.intname},{a.name},\"{a.description}\"";
            PEGame.exportFile($"ability{a.id}.txt", txt);
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            abilities.Sort(delegate (Ability a1, Ability a2) { return a1.id.CompareTo(a2.id); });
            abilityBinder.ResetBindings(false);
            string ret = null;
            for (int i = 0; i < abilities.Count; i++)
            {
                Ability a = abilities[i];
                if (i != abilities.Count - 1) { ret += $"{a.id},{a.intname},{a.name},\"{a.description}\"\r\n"; }
                else { ret += $"{a.id},{a.intname},{a.name},\"{a.description}\""; }
            }
            PEGame.exportFile("abilities.txt", ret);
        }

        private void overwriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abilities.Sort(delegate (Ability a1, Ability a2) { return a1.id.CompareTo(a2.id); });
            abilityBinder.ResetBindings(false);
            string ret = null;
            for (int i = 0; i < abilities.Count; i++)
            {
                Ability a = abilities[i];
                if (i != abilities.Count - 1) { ret += $"{a.id},{a.intname},{a.name},\"{a.description}\"\r\n"; }
                else { ret += $"{a.id},{a.intname},{a.name},\"{a.description}\""; }
            }
            PEGame.pbsFile("abilitites.txt", ret);
        }

        private void AbilityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!terminate)
            {
                if (!msg) { e.Cancel = true; return; }
                if (MessageBox.Show("Are you sure you want to exit? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Properties.Settings.Default.AbilIntName = abilities[abilityBox.SelectedIndex].intname;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void openAbilitiestxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(SuperForm.gameRoot(@"PBS\abilities.txt"));
        }

        private void internalNameFinderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntNameFinder inf = new IntNameFinder();
            inf.ShowDialog();
            bool found = false;
            if (!IntNameFinder.btn) { return; }
            for (int i = 0; i < abilities.Count; i++)
            {
                if (abilities[i].intname == IntNameFinder.result.ToUpper())
                {
                    abilityBox.SelectedIndex = abilities.IndexOf(abilities[i]);
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
                abilities.Clear();
                AbilityForm_Load(sender, e);
            }
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            idTip.SetToolTip(label4, "The internal ID of the ability.");
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            nameTip.SetToolTip(label1, "The name of the ability as displayed.");
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            intNameTip.SetToolTip(label2, "The internal name of the ability.");
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            descTip.SetToolTip(label3, "The description of the ability as shown in the summary screen.");
        }
    }
}
