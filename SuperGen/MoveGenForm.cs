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
using SuperGen;
using PokeGenerator;
using System.Diagnostics;
using static SuperGen.SuperForm;

namespace MoveGen
{
    public partial class MoveGenForm : Form
    {
        private bool save = true;
        private bool terminate = false;
        private bool msg = true;
        private List<string> types = new List<string>();
        private List<Move> moves = new List<Move>();
        private BindingSource typeBinder = new BindingSource();
        private BindingSource moveBinder = new BindingSource();
        public static string importLine;

        public MoveGenForm()
        {
            InitializeComponent();
        }

        private void MoveGenForm_Load(object sender, EventArgs e)
        {
            moveBinder.DataSource = moves;
            moveBox.DataSource = moveBinder;
            moveBox.DisplayMember = "name";
            typeBinder.DataSource = types;
            typeBox.DataSource = typeBinder;
            typeBox.DisplayMember = "name";

            load();

            moveBinder.ResetBindings(false);
            typeBinder.ResetBindings(false);
            checkSortMethod(SuperGen.Properties.Settings.Default.MoveSortMethod);
            bool found = false;
            if (!string.IsNullOrEmpty(SuperGen.Properties.Settings.Default.MoveIntName))
            {
                for (int i = 0; i < moves.Count; i++)
                {
                    if (moves[i].intname == SuperGen.Properties.Settings.Default.MoveIntName) { moveBox.SelectedIndex = i; found = true; }
                }
            }
            if (!found && moves.Count > 0) { moveBox.SelectedIndex = 0; }
            moveBox_SelectedIndexChanged(sender, e);
        }

        private void load()
        {
            #region Load types.txt
            terminate = !PEGame.Instance.loadTypes();
            if (!terminate)
            {

            }
            #endregion

            #region Load moves.txt
            var moveList = PEGame.Instance.loadMovesInstance();
            moves.Clear(); moves.AddRange(moveList);
            #endregion

            if (terminate)
            {
                Close();
            }
        }

        private void load_old()
        {
            if (File.Exists(@"PBS\types.txt"))
            {
                try
                {
                    StreamReader sr = new StreamReader(File.OpenRead(@"PBS\types.txt"));
                    string dat = sr.ReadToEnd();
                    sr.Close();
                    if (string.IsNullOrEmpty(dat))
                    {
                        emptyFile("Move Editor", "types");
                        terminate = true;
                        Close();
                        return;
                    }
                    List<string> data = new List<string>();
                    data = dat.Split('[').ToList();
                    for (int i = 1; i < data.Count; i++)
                    {
                        try
                        {
                            types.Add(data[i].Split(new string[] { "InternalName=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                        }
                        catch (Exception)
                        {
                            SuperForm.invalidLine("types", data[i], "Move Editor");
                            terminate = true;
                            Close();
                            return;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong while converting data from \"types.txt\".");
                    terminate = true;
                    Close();
                    return;
                }
            }
            else
            {
                SuperForm.fileNotFound("types", "Move Editor");
                terminate = true;
                Close();
                return;
            }
            if (File.Exists(@"PBS\moves.txt"))
            {
                try
                {
                    StreamReader sr = new StreamReader(File.OpenRead(@"PBS\moves.txt"));
                    string dat = sr.ReadToEnd();
                    sr.Close();
                    if (string.IsNullOrEmpty(dat))
                    {
                        emptyFile("Move Editor", "moves");
                        terminate = true;
                        Close();
                        return;
                    }
                    List<string> data = dat.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    moves.Clear();
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (!data[i].StartsWith("#") && !data[i].StartsWith(" ") && !data[i].StartsWith("\r\n") && data[i].Length > 0)
                        {
                            try
                            {
                                List<string> move = data[i].Split(',').ToList();
                                int id = Convert.ToInt32(move[0]);
                                string name = move[2];
                                string intname = move[1];
                                string effect = move[3];
                                int basepower = Convert.ToInt32(move[4]);
                                string type = move[5];
                                string category = move[6];
                                string target = null;
                                switch (move[10])
                                {
                                    case "00": target = "Single Non-User"; break;
                                    case "01": target = "No Target"; break;
                                    case "02": target = "Random Opposing"; break;
                                    case "04": target = "All Opposing"; break;
                                    case "08": target = "All Non-Users"; break;
                                    case "10": target = "User"; break;
                                    case "20": target = "User's Side"; break;
                                    case "40": target = "Both Sides"; break;
                                    case "80": target = "Opposing Side"; break;
                                    case "100": target = "Partner"; break;
                                    case "200": target = "User Or Partner"; break;
                                    case "400": target = "Single Opposing"; break;
                                    case "800": target = "Opposite Opposing"; break;
                                    default: target = "Single Non-User"; break;
                                }
                                int priority = Convert.ToInt32(move[11]);
                                int addeff = Convert.ToInt32(move[9]);
                                int accuracy = Convert.ToInt32(move[7]);
                                int pp = Convert.ToInt32(move[8]);
                                string flags = move[12];
                                string description = null;
                                for (int j = 13; j < move.Count; j++)
                                {
                                    string temp = null;
                                    foreach (char c in move[j])
                                    {
                                        if (c == '�')
                                        {
                                            temp += "é";
                                        }
                                        else if (c != '"')
                                        {
                                            temp += c;
                                        }
                                    }
                                    move[j] = temp;
                                    if (j == 13)
                                    {
                                        description += move[j];
                                    }
                                    else
                                    {
                                        description += $",{move[j]}";
                                    }
                                }
                                moves.Add(new Move(id, name, intname, effect, type, category, target, priority, addeff, basepower, accuracy, pp, flags, description));
                            }
                            catch (Exception)
                            {
                                invalidLine("moves", data[i], "Move Editor");
                                terminate = true;
                                Close();
                                return;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong while converting data from \"moves.txt\".");
                    terminate = true;
                    Close();
                    return;
                }
            }
            else
            {
                fileNotFound("moves", "Move Editor");
                terminate = true;
                Close();
                return;
            }
        }

        private void checkSortMethod(string SortMethod)
        {
            switch (SortMethod)
            {
                case "ID": moves.Sort(delegate (Move m1, Move m2) { return m1.id.CompareTo(m2.id); }); break;
                case "DisplayName": moves.Sort(delegate (Move m1, Move m2) { return m1.name.CompareTo(m2.name); }); break;
                case "InternalName": moves.Sort(delegate (Move m1, Move m2) { return m1.intname.CompareTo(m2.intname); }); break;
                case "Type": moves.Sort(delegate (Move m1, Move m2) { return m1.type.CompareTo(m2.type); }); break;
                case "Category": moves.Sort(delegate (Move m1, Move m2) { return m1.category.CompareTo(m2.category); }); break;
                case "BasePower": moves.Sort(delegate (Move m1, Move m2) { return m1.basepower.CompareTo(m2.basepower); }); moves.Reverse(); break;
                case "Accuracy": for (int i = 0; i < moves.Count; i++) { if (moves[i].accuracy == 0) { moves[i].accuracy = 137; } } moves.Sort(delegate (Move m1, Move m2) { return m1.accuracy.CompareTo(m2.accuracy); }); for (int i = 0; i < moves.Count; i++) { if (moves[i].accuracy == 137) { moves[i].accuracy = 0; } } break;
                case "Target": moves.Sort(delegate (Move m1, Move m2) { return m1.target.CompareTo(m2.target); }); break;
                case "PP": moves.Sort(delegate (Move m1, Move m2) { return m1.pp.CompareTo(m2.pp); }); break;
                case "Priority": moves.Sort(delegate (Move m1, Move m2) { return m1.priority.CompareTo(m2.priority); }); moves.Reverse(); break;
                case "Effect": moves.Sort(delegate (Move m1, Move m2) { return m1.effect.CompareTo(m2.effect); }); break;
                case "AdditionalEffect": moves.Sort(delegate (Move m1, Move m2) { return m1.addeff.CompareTo(m2.addeff); }); break;
                case "Description": moves.Sort(delegate (Move m1, Move m2) { return m1.description.CompareTo(m2.description); }); break;
            }
            moveBinder.ResetBindings(false);
        }

        private void moveBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (moves.Count > 0)
            {
                idBox.Value = moves[moveBox.SelectedIndex].id;
                nameBox.Text = moves[moveBox.SelectedIndex].name;
                intnameBox.Text = moves[moveBox.SelectedIndex].intname;
                typeBox.Text = moves[moveBox.SelectedIndex].type;
                categoryBox.Text = moves[moveBox.SelectedIndex].category;
                powerBox.Value = moves[moveBox.SelectedIndex].basepower;
                accuracyBox.Value = moves[moveBox.SelectedIndex].accuracy;
                ppBox.Value = moves[moveBox.SelectedIndex].pp;
                targetBox.Text = moves[moveBox.SelectedIndex].target;
                priorityBox.Value = moves[moveBox.SelectedIndex].priority;
                effectBox.Text = moves[moveBox.SelectedIndex].effect;
                effectExtraBox.Value = moves[moveBox.SelectedIndex].addeff;
                descBox.Text = moves[moveBox.SelectedIndex].description;
                for (int i = 0; i < 14; i++) { flagBox.SetItemChecked(i, false); }
                checkFlags(moves[moveBox.SelectedIndex].flags, true);
                for (int i = 1; i < 15; i++) { ((Label)Controls[$"label{i}"]).Enabled = true; }
                enableButtons(true);
            }
            else
            {
                for (int i = 1; i < 15; i++) { ((Label)Controls[$"label{i}"]).Enabled = false; }
                enableButtons(false);
            }
        }

        private void checkFlags(string flags, bool set)
        {
            if (flags.Contains("a")) { flagBox.SetItemChecked(0, set); }
            if (flags.Contains("b")) { flagBox.SetItemChecked(1, set); }
            if (flags.Contains("c")) { flagBox.SetItemChecked(2, set); }
            if (flags.Contains("d")) { flagBox.SetItemChecked(3, set); }
            if (flags.Contains("e")) { flagBox.SetItemChecked(4, set); }
            if (flags.Contains("f")) { flagBox.SetItemChecked(5, set); }
            if (flags.Contains("g")) { flagBox.SetItemChecked(6, set); }
            if (flags.Contains("h")) { flagBox.SetItemChecked(7, set); }
            if (flags.Contains("i")) { flagBox.SetItemChecked(8, set); }
            if (flags.Contains("j")) { flagBox.SetItemChecked(9, set); }
            if (flags.Contains("k")) { flagBox.SetItemChecked(10, set); }
            if (flags.Contains("l")) { flagBox.SetItemChecked(11, set); }
            if (flags.Contains("m")) { flagBox.SetItemChecked(12, set); }
            if (flags.Contains("n")) { flagBox.SetItemChecked(13, set); }
        }

        private void enableButtons(bool bln)
        {
            removeMoveBtn.Enabled = bln;
            idBox.Enabled = bln;
            nameBox.Enabled = bln;
            intnameBox.Enabled = bln;
            typeBox.Enabled = bln;
            categoryBox.Enabled = bln;
            powerBox.Enabled = bln;
            accuracyBox.Enabled = bln;
            ppBox.Enabled = bln;
            targetBox.Enabled = bln;
            priorityBox.Enabled = bln;
            effectBox.Enabled = bln;
            effectExtraBox.Enabled = bln;
            flagBox.Enabled = bln;
            descBox.Enabled = bln;
        }

        private void idBox_ValueChanged(object sender, EventArgs e)
        {
            moves[moveBox.SelectedIndex].id = (int)idBox.Value;
        }
        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            moves[moveBox.SelectedIndex].name = nameBox.Text;
            moveBinder.ResetBindings(false);
            if (nameBox.Text.Length > 0)
            {
                char[] c = nameBox.Text.ToCharArray();
                string res = null;
                foreach (char x in c) { if (x != '-' && x != ':' && x != ' ') { res += x; } }
                intnameBox.Text = res.ToUpper();
            }
            else { intnameBox.Text = null; }
        }
        private void intnameBox_TextChanged(object sender, EventArgs e)
        {
            moves[moveBox.SelectedIndex].intname = intnameBox.Text;
        }
        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            moves[moveBox.SelectedIndex].type = typeBox.Text;
        }
        private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            moves[moveBox.SelectedIndex].category = categoryBox.Text;
        }
        private void powerBox_ValueChanged(object sender, EventArgs e)
        {
            moves[moveBox.SelectedIndex].basepower = (int)powerBox.Value;
        }
        private void accuracyBox_ValueChanged(object sender, EventArgs e)
        {
            moves[moveBox.SelectedIndex].accuracy = (int)accuracyBox.Value;
        }
        private void ppBox_ValueChanged(object sender, EventArgs e)
        {
            moves[moveBox.SelectedIndex].pp = (int)ppBox.Value;
        }
        private void targetBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            moves[moveBox.SelectedIndex].target = targetBox.Text;
        }
        private void priorityBox_ValueChanged(object sender, EventArgs e)
        {
            moves[moveBox.SelectedIndex].priority = (int)priorityBox.Value;
        }
        private void effectBox_TextChanged(object sender, EventArgs e)
        {
            moves[moveBox.SelectedIndex].effect = effectBox.Text;
        }
        private void effectExtraBox_ValueChanged(object sender, EventArgs e)
        {
            moves[moveBox.SelectedIndex].addeff = (int)effectExtraBox.Value;
        }
        private void descBox_TextChanged(object sender, EventArgs e)
        {
            moves[moveBox.SelectedIndex].description = descBox.Text;
        }
        private void flagBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<char> letters = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n' };
            moves[moveBox.SelectedIndex].flags = "";
            for (int i = 0; i < 14; i++)
            {
                if (flagBox.GetItemChecked(i)) { moves[moveBox.SelectedIndex].flags += letters[i]; }
            }
        }

        private void addMoveBtn_Click(object sender, EventArgs e)
        {
            moves.Add(new Move(moves.Count, null, null, "000", "NORMAL", "Physical", "Single Non-User", 0, 0, 50, 100, 20, "", null));
            moveBinder.ResetBindings(false);
            moveBox.SelectedIndex = moves.Count - 1;
            removeMoveBtn.Enabled = true;
            moveBox_SelectedIndexChanged(sender, e);
        }

        private void removeMoveBtn_Click(object sender, EventArgs e)
        {
            moves.RemoveAt(moveBox.SelectedIndex);
            moveBinder.ResetBindings(false);
            if (moves.Count == 0) { removeMoveBtn.Enabled = false; }
            else { removeMoveBtn.Enabled = true; moveBox_SelectedIndexChanged(sender, e); }
        }

        private void byIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move m = moves[moveBox.SelectedIndex];
            moves.Sort(delegate (Move m1, Move m2) { return m1.id.CompareTo(m2.id); });
            moveBinder.ResetBindings(false);
            moveBox.SelectedIndex = moves.IndexOf(m);
            SuperGen.Properties.Settings.Default.MoveSortMethod = "ID";
        }
        private void displayNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move m = moves[moveBox.SelectedIndex];
            moves.Sort(delegate (Move m1, Move m2) { return m1.name.CompareTo(m2.name); });
            moveBinder.ResetBindings(false);
            moveBox.SelectedIndex = moves.IndexOf(m);
            SuperGen.Properties.Settings.Default.MoveSortMethod = "DisplayName";
        }
        private void internalNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move m = moves[moveBox.SelectedIndex];
            moves.Sort(delegate (Move m1, Move m2) { return m1.intname.CompareTo(m2.intname); });
            moveBinder.ResetBindings(false);
            moveBox.SelectedIndex = moves.IndexOf(m);
            SuperGen.Properties.Settings.Default.MoveSortMethod = "InternalName";
        }
        private void byTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move m = moves[moveBox.SelectedIndex];
            moves.Sort(delegate (Move m1, Move m2) { return m1.type.CompareTo(m2.type); });
            moveBinder.ResetBindings(false);
            moveBox.SelectedIndex = moves.IndexOf(m);
            SuperGen.Properties.Settings.Default.MoveSortMethod = "Type";
        }
        private void byCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move m = moves[moveBox.SelectedIndex];
            moves.Sort(delegate (Move m1, Move m2) { return m1.category.CompareTo(m2.category); });
            moveBinder.ResetBindings(false);
            moveBox.SelectedIndex = moves.IndexOf(m);
            SuperGen.Properties.Settings.Default.MoveSortMethod = "Category";
        }
        private void byBasePowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move m = moves[moveBox.SelectedIndex];
            moves.Sort(delegate (Move m1, Move m2) { return m1.basepower.CompareTo(m2.basepower); });
            moves.Reverse();
            moveBinder.ResetBindings(false);
            moveBox.SelectedIndex = moves.IndexOf(m);
            SuperGen.Properties.Settings.Default.MoveSortMethod = "BasePower";
        }
        private void byAccuracyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move m = moves[moveBox.SelectedIndex];
            for (int i = 0; i < moves.Count; i++) { if (moves[i].accuracy == 0) { moves[i].accuracy = 137; } }
            moves.Sort(delegate (Move m1, Move m2) { return m1.accuracy.CompareTo(m2.accuracy); });
            moveBinder.ResetBindings(false);
            for (int i = 0; i < moves.Count; i++) { if (moves[i].accuracy == 137) { moves[i].accuracy = 0; } }
            moveBox.SelectedIndex = moves.IndexOf(m);
            SuperGen.Properties.Settings.Default.MoveSortMethod = "Accuracy";
        }
        private void byPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move m = moves[moveBox.SelectedIndex];
            moves.Sort(delegate (Move m1, Move m2) { return m1.pp.CompareTo(m2.pp); });
            moveBinder.ResetBindings(false);
            moveBox.SelectedIndex = moves.IndexOf(m);
            SuperGen.Properties.Settings.Default.MoveSortMethod = "PP";
        }
        private void byTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move m = moves[moveBox.SelectedIndex];
            moves.Sort(delegate (Move m1, Move m2) { return m1.target.CompareTo(m2.target); });
            moveBinder.ResetBindings(false);
            moveBox.SelectedIndex = moves.IndexOf(m);
            SuperGen.Properties.Settings.Default.MoveSortMethod = "Target";
        }
        private void byPriorityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move m = moves[moveBox.SelectedIndex];
            moves.Sort(delegate (Move m1, Move m2) { return m1.priority.CompareTo(m2.priority); });
            moves.Reverse();
            moveBinder.ResetBindings(false);
            moveBox.SelectedIndex = moves.IndexOf(m);
            SuperGen.Properties.Settings.Default.MoveSortMethod = "Priority";
        }
        private void byMoveEffectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move m = moves[moveBox.SelectedIndex];
            moves.Sort(delegate (Move m1, Move m2) { return m1.effect.CompareTo(m2.effect); });
            moveBinder.ResetBindings(false);
            moveBox.SelectedIndex = moves.IndexOf(m);
            SuperGen.Properties.Settings.Default.MoveSortMethod = "Effect";
        }
        private void byAdditionalEffectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move m = moves[moveBox.SelectedIndex];
            moves.Sort(delegate (Move m1, Move m2) { return m1.addeff.CompareTo(m2.addeff); });
            moveBinder.ResetBindings(false);
            moveBox.SelectedIndex = moves.IndexOf(m);
            SuperGen.Properties.Settings.Default.MoveSortMethod = "AdditionalEffect";
        }
        private void byDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Move m = moves[moveBox.SelectedIndex];
            moves.Sort(delegate (Move m1, Move m2) { return m1.description.CompareTo(m2.description); });
            moveBinder.ResetBindings(false);
            moveBox.SelectedIndex = moves.IndexOf(m);
            SuperGen.Properties.Settings.Default.MoveSortMethod = "Description";
        }

        private string convertTarget(string target)
        {
            switch (target)
            {
                case "Single Non-User": target = "00"; break;
                case "No Target": target = "01"; break;
                case "Random Opposing": target = "02"; break;
                case "All Opposing": target = "04"; break;
                case "All Non-Users": target = "08"; break;
                case "User": target = "10"; break;
                case "User's Side": target = "20"; break;
                case "Both Sides": target = "40"; break;
                case "Opposing Side": target = "80"; break;
                case "Partner": target = "100"; break;
                case "User Or Partner": target = "200"; break;
                case "Single Opposing": target = "400"; break;
                case "Opposite Opposing": target = "800"; break;
                default: target = "00"; break;
            }
            return target;
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to return? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (moves.Count > 0) { SuperGen.Properties.Settings.Default.MoveIntName = moves[moveBox.SelectedIndex].intname; } else { SuperGen.Properties.Settings.Default.MoveIntName = null; }
                SuperGen.Properties.Settings.Default.Save();

                msg = false;
                Close();
                Dispose();
            }
        }

        private void MoveGenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!terminate)
            {
                if (!msg) { e.Cancel = true; return; }
                if (save)
                {
                    if (MessageBox.Show("Are you sure you want to exit? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (moves.Count > 0) { SuperGen.Properties.Settings.Default.MoveIntName = moves[moveBox.SelectedIndex].intname; } else { SuperGen.Properties.Settings.Default.MoveIntName = null; }
                        SuperGen.Properties.Settings.Default.Save();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void generateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (moves.Count > 0)
            {
                Move m = moves[moveBox.SelectedIndex];
                GeneratePokemon gp = new GeneratePokemon();
                gp.gennedPokemon = $"{m.id},{m.intname},{m.name},{m.effect},{m.basepower},{m.type},{m.category},{m.accuracy},{m.pp},{m.addeff},{convertTarget(m.target)},{m.priority},{m.flags},\"{m.description}\"";
                gp.Show();
            }
            else
            {
                MessageBox.Show("There are no moves to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (moves.Count > 0)
            {
                Move m = moves[moveBox.SelectedIndex];
                string txt = $"{m.id},{m.intname},{m.name},{m.effect},{m.basepower},{m.type},{m.category},{m.accuracy},{m.pp},{m.addeff},{convertTarget(m.target)},{m.priority},{m.flags},\"{m.description}\"";
                PEGame.exportFile($"move{m.id}.txt", txt);
            }
            else
            {
                MessageBox.Show("There are no moves to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void generateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (moves.Count > 0)
            {
                string ret = null;
                for (int i = 0; i < moves.Count; i++)
                {
                    Move m = moves[i];
                    ret += $"{m.id},{m.intname},{m.name},{m.effect},{m.basepower},{m.type},{m.category},{m.accuracy},{m.pp},{m.addeff},{convertTarget(m.target)},{m.priority},{m.flags},\"{m.description}\"";
                    if (i != moves.Count - 1) { ret += "\r\n"; }
                }
                GeneratePokemon gp = new GeneratePokemon();
                gp.gennedPokemon = ret;
                gp.Show();
            }
            else
            {
                MessageBox.Show("There are no moves to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (moves.Count > 0)
            {
                string ret = null;
                for (int i = 0; i < moves.Count; i++)
                {
                    Move m = moves[i];
                    ret += $"{m.id},{m.intname},{m.name},{m.effect},{m.basepower},{m.type},{m.category},{m.accuracy},{m.pp},{m.addeff},{convertTarget(m.target)},{m.priority},{m.flags},\"{m.description}\"";
                    if (i != moves.Count - 1) { ret += "\r\n"; }
                }
                PEGame.exportFile("moves.txt", ret);
            }
            else
            {
                MessageBox.Show("There are no moves to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void overwriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (moves.Count > 0)
            {
                if (MessageBox.Show("You are about to overwrite \"moves.txt\". Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string ret = null;
                    for (int i = 0; i < moves.Count; i++)
                    {
                        Move m = moves[i];
                        ret += $"{m.id},{m.intname},{m.name},{m.effect},{m.basepower},{m.type},{m.category},{m.accuracy},{m.pp},{m.addeff},{convertTarget(m.target)},{m.priority},{m.flags},\"{m.description}\"";
                        if (i != moves.Count - 1) { ret += "\r\n"; }
                    }
                    PEGame.pbsFile("moves.txt", ret);
                }
            }
            else
            {
                MessageBox.Show("There are no moves to generate!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openMovestxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(PEGame.Instance.root($@"PBS\moves.txt"));
        }

        private void findInternalNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntNameFinder inf = new IntNameFinder();
            inf.ShowDialog();
            bool found = false;
            if (!IntNameFinder.btn) { return; }
            for (int i = 0; i < moves.Count; i++)
            {
                if (moves[i].intname == IntNameFinder.result.ToUpper())
                {
                    moveBox.SelectedIndex = moves.IndexOf(moves[i]);
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
                moves.Clear();
                MoveGenForm_Load(sender, e);
            }
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            idTip.SetToolTip(label1, "The internal ID of the move.");
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            nameTip.SetToolTip(label2, "The name of the move as displayed in-game.");
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            intNameTip.SetToolTip(label3, "The internal name as referenced in-game.");
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            typeTip.SetToolTip(label4, "The type of the move.");
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            categoryTip.SetToolTip(label5, "Category: Category of the move.\r\nPhysical: The move makes physical contact to deal damage.\r\nSpecial: The move inflicts indirect damage.\r\nStatus: The move is a stat boosting / hindering / etc.move.");
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            powerTip.SetToolTip(label6, "Base power of the move.\r\nSet to 0 if it does not apply damage.");
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            accuracyTip.SetToolTip(label7, "The chance of the move to land.\r\nSet to 0 to ignore this check.");
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            ppTip.SetToolTip(label8, "How often the move can be used by default.");
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            targetTip.SetToolTip(label9, "How this move affects the field.");
        }

        private void label11_MouseHover(object sender, EventArgs e)
        {
            priorityTip.SetToolTip(label11, "Where this move should move earlier or later.");
        }

        private void label13_MouseHover(object sender, EventArgs e)
        {
            effectTip.SetToolTip(label13, "References the code that is\r\nExecuted when the move is used.");
        }

        private void label14_MouseHover(object sender, EventArgs e)
        {
            addEffTip.SetToolTip(label14, "The chance for a specified side-effect to occur.");
        }

        private void label12_MouseHover(object sender, EventArgs e)
        {
            flagsTip.SetToolTip(label12, "Special data for this move.");
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            descTip.SetToolTip(label10, "The description of this move as seen in the Summary screen.");
        }
    }
}