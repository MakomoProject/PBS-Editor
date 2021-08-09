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

namespace SuperGen
{
    public partial class TMEditor : Form
    {
        private bool startup = true;
        private bool terminate = false;
        private BindingSource tmBinder = new BindingSource();
        private BindingSource pokeBinder = new BindingSource();
        private BindingSource speciesBinder = new BindingSource();
        private BindingSource moveBinder = new BindingSource();
        private List<TM> tms = new List<TM>();
        private List<string> species = new List<string>();
        private List<string> moves = new List<string>();

        public TMEditor()
        {
            InitializeComponent();
        }

        private void TMEditor_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"PBS\tm.txt"))
            {
                try
                {
                    StreamReader sr = new StreamReader(File.OpenRead(@"PBS\tm.txt"));
                    string data = sr.ReadToEnd();
                    sr.Close();
                    if (string.IsNullOrEmpty(data))
                    {
                        emptyFile("TM Editor", "tm");
                        terminate = true;
                        Close();
                        return;
                    }
                    List<string> _tms = new List<string>();
                    _tms = data.Split('[').ToList();
                    for (int i = 1; i < _tms.Count; i++)
                    {
                        try
                        {
                            string name = _tms[i].Split(']')[0];
                            List<string> species = new List<string>();
                            species = _tms[i].Split(']')[1].Split(',').ToList();
                            tms.Add(new TM(name, species));
                        }
                        catch (Exception)
                        {
                            invalidLine("tm", _tms[i], "TM Editor");
                            terminate = true;
                            Close();
                            return;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong while converting data inside \"tm.txt\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    terminate = true;
                    Close();
                    return;
                }
            }
            else
            {
                fileNotFound("tm", "TM Editor");
                terminate = true;
                Close();
                return;
            }
            if (File.Exists(@"PBS\pokemon.txt"))
            {
                try
                {
                    StreamReader sr = new StreamReader(File.OpenRead(@"PBS\pokemon.txt"));
                    string data = sr.ReadToEnd();
                    sr.Close();
                    if (string.IsNullOrEmpty(data))
                    {
                        emptyFile("TM Editor", "pokemon");
                        terminate = true;
                        Close();
                        return;
                    }
                    List<string> mons = new List<string>();
                    mons = data.Split('[').ToList();
                    for (int i = 1; i < mons.Count; i++)
                    {
                        try
                        {
                            string mon = mons[i].Split(new string[] { "InternalName=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                            species.Add(mon);
                        }
                        catch (Exception)
                        {
                            invalidLine("pokemon", mons[i], "TM Editor");
                            terminate = true;
                            Close();
                            return;
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong while converting data inside \"pokemon.txt\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    terminate = true;
                    Close();
                    return;
                }
            }
            else
            {
                fileNotFound("pokemon", "TM Editor");
                terminate = true;
                Close();
                return;
            }
            if (File.Exists(@"PBS\moves.txt"))
            {
                try
                {
                    StreamReader sr = new StreamReader(File.OpenRead(@"PBS\moves.txt"));
                    string data = sr.ReadToEnd();
                    sr.Close();
                    if (string.IsNullOrEmpty(data))
                    {
                        emptyFile("TM Editor", "moves");
                        terminate = true;
                        Close();
                        return;
                    }
                    List<string> mvs = new List<string>();
                    mvs = data.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    for (int i = 0; i < mvs.Count; i++)
                    {
                        if (isUsable(mvs[i]))
                        {
                            try
                            {
                                moves.Add(mvs[i].Split(',')[1]);
                            }
                            catch (Exception)
                            {
                                invalidLine("moves", mvs[i], "TM Editor");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong while converting data inside \"moves.txt\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    terminate = true;
                    Close();
                    return;
                }
            }
            else
            {
                fileNotFound("moves", "TM Editor");
                terminate = true;
                Close();
                return;
            }
            moves.Sort();
            species.Sort();
            tms.Sort(delegate (TM tm1, TM tm2) { return tm1.name.CompareTo(tm2.name); });
            for (int i = 0; i < tms.Count; i++)
            {
                for (int j = 0; j < tms[i].species.Count; j++)
                {
                    string ret = null;
                    foreach (char c in tms[i].species[j])
                    {
                        if (c != '\n' && c != '\r') ret += c;
                    }
                    tms[i].species[j] = ret;
                }
                tms[i].species.Sort();
            }

            tmBinder.DataSource = tms;
            tmBox.DataSource = tmBinder;
            tmBox.DisplayMember = "name";

            pokeBinder.DataSource = tms[tmBox.SelectedIndex].species;
            pokeBox.DataSource = pokeBinder;
            pokeBox.DisplayMember = "name";

            speciesBinder.DataSource = species;
            speciesBox.DataSource = speciesBinder;
            speciesBox.DisplayMember = "name";

            moveBinder.DataSource = moves;
            tmMoveBox.DataSource = moveBinder;
            tmMoveBox.DisplayMember = "name";
            startup = false;
            tmBox_SelectedIndexChanged(sender, e);
        }

        private void tmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (startup) return;
            if (tms.Count > 0)
            {
                for (int i = 0; i < Controls.Count; i++)
                {
                    Controls[i].Enabled = true;
                }
                if (tms[tmBox.SelectedIndex].species.Count > 0)
                {
                    tms[tmBox.SelectedIndex].species.Sort();
                    pokeBinder.DataSource = tms[tmBox.SelectedIndex].species;
                    removeSpeciesBtn.Enabled = true;
                }
                else
                {
                    pokeBinder.DataSource = new List<string>();
                    removeSpeciesBtn.Enabled = false;
                }
            }
            else
            {
                pokeBinder.DataSource = new List<string>();
                for (int i = 0; i < Controls.Count; i++)
                {
                    Controls[i].Enabled = false;
                }
                addTMBtn.Enabled = true;
                menuStrip1.Enabled = true;
            }
        }

        private void openTmtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"PBS\tm.txt");
        }

        private string getTM(TM tm)
        {
            string ret =
$@"[{tm.name}]
"; for (int i = 0; i < tm.species.Count; i++)
{ ret += tm.species[i]; if (i != tm.species.Count - 1) ret += ","; }
            return ret;
        }

        private void generateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PokeGenerator.GeneratePokemon pg = new PokeGenerator.GeneratePokemon();
            pg.gennedPokemon = getTM(tms[tmBox.SelectedIndex]);
            pg.Show();
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PEGame.exportFile("tm.txt", getTM(tms[tmBox.SelectedIndex]));
        }

        private void generateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string ret = null;
            for (int i = 0; i < tms.Count; i++)
            {
                ret += getTM(tms[i]);
                if (i != tms.Count - 1) ret += "\r\n";
            }
            PokeGenerator.GeneratePokemon pg = new PokeGenerator.GeneratePokemon();
            pg.gennedPokemon = ret;
            pg.Show();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ret = null;
            for (int i = 0; i < tms.Count; i++)
            {
                ret += getTM(tms[i]);
                if (i != tms.Count - 1) ret += "\r\n";
            }
            PEGame.exportFile("tm.txt", ret);
        }

        private void overwriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ret = null;
            for (int i = 0; i < tms.Count; i++)
            {
                ret += getTM(tms[i]);
                if (i != tms.Count - 1) ret += "\r\n";
            }
            PEGame.pbsFile("tm.txt", ret);
        }

        private void reloadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startup = true;
            moves.Clear();
            tms.Clear();
            species.Clear();
            TMEditor_Load(sender, e);
        }

        private void addSpeciesBtn_Click(object sender, EventArgs e)
        {
            tms[tmBox.SelectedIndex].species.Add(speciesBox.Text);
            tms[tmBox.SelectedIndex].species.Sort();
            pokeBinder.ResetBindings(false);
            pokeBinder.DataSource = tms[tmBox.SelectedIndex].species;
            pokeBox.SelectedIndex = tms[tmBox.SelectedIndex].species.IndexOf(speciesBox.Text);
            removeSpeciesBtn.Enabled = true;
        }

        private void removeSpeciesBtn_Click(object sender, EventArgs e)
        {
            tms[tmBox.SelectedIndex].species.RemoveAt(pokeBox.SelectedIndex);
            pokeBinder.ResetBindings(false);
            if (tms[tmBox.SelectedIndex].species.Count == 0) { removeSpeciesBtn.Enabled = false; }
        }

        private void addTMBtn_Click(object sender, EventArgs e)
        {
            tms.Add(new TM(tmMoveBox.Text, new List<string>()));
            tms.Sort(delegate (TM tm1, TM tm2) { return tm1.name.CompareTo(tm2.name); });
            tmBinder.ResetBindings(false);
            for (int i = 0; i < tms.Count; i++)
            {
                if (tms[i].name == tmMoveBox.Text)
                {
                    tmBox.SelectedIndex = i;
                    break;
                }
            }
            pokeBinder.DataSource = tms[tmBox.SelectedIndex].species;
            removeTMBtn.Enabled = true;
            tmBox_SelectedIndexChanged(sender, e);
        }

        private void removeTMBtn_Click(object sender, EventArgs e)
        {
            tms.RemoveAt(tmBox.SelectedIndex);
            tmBinder.ResetBindings(false);
            if (tms.Count == 1) { removeTMBtn.Enabled = false; }
            tmBox_SelectedIndexChanged(sender, e);
        }
    }
}
