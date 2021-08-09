using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using lib;
using static SuperGen.SuperForm;

namespace SuperGen
{
    public partial class EncounterEditor : Form
    {
        private bool terminate = false;
        private bool starting = true;
        private EncounterMap map;
        private BindingSource mapBinder = new BindingSource();
        private BindingSource methodBinder = new BindingSource();
        private BindingSource encounterBinder = new BindingSource();
        private BindingSource speciesBinder = new BindingSource();
        private static List<int> def = new List<int>() { 20, 20, 10, 10, 10, 10, 5, 5, 4, 4, 1, 1 };
        private List<string> pokemon = new List<string>();
        private List<EncounterMap> maps = new List<EncounterMap>();
        private List<EncounterClass> methods = new List<EncounterClass>() { new EncounterClass("Land", 12, def), new EncounterClass("LandMorning", 12, def), new EncounterClass("LandDay", 12, def), new EncounterClass("LandNight", 12, def), new EncounterClass("Cave", 12, def), new EncounterClass("BugContest", 12, def),
                                                                            new EncounterClass("Water", 5, new List<int>() { 60, 30, 5, 4, 1 }), new EncounterClass("RockSmash", 5, new List<int>() { 60, 30, 5, 4, 1 }),
                                                                            new EncounterClass("OldRod", 2, new List<int>() { 70, 30 }),
                                                                            new EncounterClass("GoodRod", 3, new List<int>() { 60, 20, 20 }),
                                                                            new EncounterClass("SuperRod", 5, new List<int>() { 40, 40, 15, 4, 1 }),
                                                                            new EncounterClass("HeadbuttLow", 8, new List<int>() { 30, 25, 20, 10, 5, 5, 4, 1 }),
                                                                            new EncounterClass("HeadbuttHigh", 8, new List<int>() { 30, 25, 20, 10, 5, 5, 4, 1 })};

        public EncounterEditor()
        {
            InitializeComponent();
        }

        private void openencounterstxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"PBS\encounters.txt");
        }

        private void EncounterEditor_Load(object sender, EventArgs e)
        {
            #region Load all maps
            for (int i = 0; i < methods.Count; i++)
            {
                method.Items.Add(methods[i]);
            }
            method.SelectedIndex = 0;
            List<string> files = new List<string>();
            files = Directory.GetFiles("Data").ToList();
            for (int i = 0; i < files.Count; i++)
            {
                string name = files[i].Split(new string[] { "Data\\" }, StringSplitOptions.None)[1];
                if (name.StartsWith("Map") && !name.StartsWith("MapInfos"))
                {
                    maps.Add(new EncounterMap(name.Split(new string[] { "Map" }, StringSplitOptions.None)[1].Split('.')[0], null, new List<int>() { 25, 10, 10 }, new List<EncounterMethod>()));
                }
            }
            #endregion
            #region Load encounters.txt
            if (File.Exists(@"PBS\encounters.txt"))
            {
                try
                {
                    StreamReader sr = new StreamReader(File.OpenRead(@"PBS\encounters.txt"));
                    string dat = sr.ReadToEnd();
                    sr.Close();
                    if (string.IsNullOrEmpty(dat))
                    {
                        emptyFile("Encounters Editor", "encounters");
                        terminate = true;
                        Close();
                        return;
                    }
                    List<string> data = new List<string>();
                    data = dat.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (isUsable(data[i]))
                        {
                            try
                            {
                                string id = "000";
                                string map = null;
                                try
                                {
                                    Convert.ToInt32(data[i].Split(' ')[0]);
                                    id = data[i].Split(' ')[0];
                                    map = data[i].Split(new string[] { "# " }, StringSplitOptions.None)[1];
                                }
                                catch (Exception)
                                {
                                    try
                                    {
                                        Convert.ToInt32(data[i]);
                                        id = data[i];
                                    }
                                    catch (Exception)
                                    {
                                        continue;
                                    }
                                }
                                if (id == "000") { continue; }
                                List<int> densities = new List<int>() { Convert.ToInt32(data[i + 1].Split(',')[0]), Convert.ToInt32(data[i + 1].Split(',')[1]), Convert.ToInt32(data[i + 1].Split(',')[2]) };
                                List<EncounterMethod> encounters = new List<EncounterMethod>();
                                int start = 2;
                                Label:
                                string method = data[i + start];
                                foreach (EncounterClass METHOD in methods)
                                {
                                    if (METHOD.name == method)
                                    {
                                        List<Encounter> list = new List<Encounter>();
                                        for (int j = i + start + 1; j < i + start + METHOD.entries + 1; j++)
                                        {
                                            string spcs = data[j].Split(',')[0];
                                            int level = Convert.ToInt32(data[j].Split(',')[1]);
                                            int leveltwo = level;
                                            try
                                            {
                                                leveltwo = Convert.ToInt32(data[j].Split(',')[2]);
                                            }
                                            catch (Exception) { }
                                            list.Add(new Encounter(spcs, level, leveltwo));
                                        }
                                        encounters.Add(new EncounterMethod(METHOD, list));
                                        start += METHOD.entries + 1;
                                        goto Label;
                                    }

                                }
                                for (int j = 0; j < maps.Count; j++)
                                {
                                    if (maps[j].id == id)
                                    {
                                        maps[j].densities = densities;
                                        maps[j].name = map;
                                        maps[j].encounters = encounters;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                invalidLine("encounters", data[i], "Encounter");
                                terminate = true;
                                Close();
                                return;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Encounter Editor: Something went wrong whilst convertering data inside of \"encounters.txt\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    terminate = true;
                    Close();
                    return;
                }
            }
            else
            {
                fileNotFound("encounters", "Encounter");
                terminate = true;
                Close();
                return;
            }
            #endregion
            #region Load pokemon.txt
            if (File.Exists(@"PBS\pokemon.txt"))
            {
                StreamReader sr = new StreamReader(@"PBS\pokemon.txt");
                string dat = sr.ReadToEnd();
                sr.Close();
                if (string.IsNullOrEmpty(dat))
                {
                    emptyFile("Encounter Editor", "pokemon");
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
                        pokemon.Add(splitter(data[i], "InternalName=", "\r\n"));
                    }
                    catch (Exception)
                    {
                        invalidLine("pokemon", data[i], "Trainer Editor");
                        terminate = true;
                        Close();
                        return;
                    }
                }
            }
            else
            {
                fileNotFound("pokemon", "Encounter Editor");
                terminate = true;
                Close();
                return;
            }
            #endregion
            mapBinder.DataSource = maps;
            mapBox.DataSource = mapBinder;
            mapBox.DisplayMember = "display";

            speciesBinder.DataSource = pokemon;
            species.DataSource = speciesBinder;
            species.DisplayMember = "name";
            starting = false;
        }

        private void encounterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            map = maps[mapBox.SelectedIndex];
            mapName.Text = map.name;
            densityGrass.Value = map.densities[0];
            densityCaves.Value = map.densities[1];
            densitySurfing.Value = map.densities[2];
            methodBinder.DataSource = map.encounters;
            methodsBox.DataSource = methodBinder;
            methodsBox.DisplayMember = "method";
            methodsBox_SelectedIndexChanged(sender, e);
        }

        private string singleMap(EncounterMap map)
        {
string txt = $@"#########################
{map.id}"; if (!string.IsNullOrEmpty(map.name)) { txt += $" # {map.name}"; } txt += $@"
{map.densities[0]},{map.densities[1]},{map.densities[2]}"; for (int i = 0; i < map.encounters.Count; i++) { txt += $"\r\n{map.encounters[i].method}";
for (int j = 0; j < map.encounters[i].encounters.Count; j++) {
if (map.encounters[i].encounters[j].leveltwo != map.encounters[i].encounters[j].level) { txt += $"\r\n{map.encounters[i].encounters[j].species},{map.encounters[i].encounters[j].level},{map.encounters[i].encounters[j].leveltwo}"; } else {
txt += $"\r\n{map.encounters[i].encounters[j].species},{ map.encounters[i].encounters[j].level}"; } } }
return txt;
        }

        private void generateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MiscGen.GennedTypes frm = new MiscGen.GennedTypes();
            frm.txt = singleMap(map);
            frm.Show();
        }

        private void mapName_TextChanged(object sender, EventArgs e)
        {
            map.name = mapName.Text;
            mapBinder.ResetBindings(false);
        }

        private void densityGrass_ValueChanged(object sender, EventArgs e)
        {
            map.densities[0] = (int) densityGrass.Value;
        }

        private void densityCaves_ValueChanged(object sender, EventArgs e)
        {
            map.densities[1] = (int) densityCaves.Value;
        }

        private void densitySurfing_ValueChanged(object sender, EventArgs e)
        {
            map.densities[2] = (int) densitySurfing.Value;
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PEGame.exportFile("encounters", singleMap(map));
        }

        private void generateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string txt = null;
            for (int i = 0; i < maps.Count; i++)
            {
                if (maps[i].encounters.Count > 0)
                {
                    txt += singleMap(maps[i]);
                    if (i != maps.Count - 1) { txt += "\r\n"; }
                }
            }
            MiscGen.GennedTypes frm = new MiscGen.GennedTypes();
            frm.txt = txt;
            frm.Show();
        }

        private void reloadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maps.Clear();
            EncounterEditor_Load(sender, e);
        }

        private void addEncounterBtn_Click(object sender, EventArgs e)
        {
            maps.Add(new EncounterMap("000", "Map", new List<int>() { 25, 10, 10 }, new List<EncounterMethod>()));
            mapBinder.ResetBindings(false);
            mapBox.SelectedIndex = maps.Count - 1;
        }

        private void addMethodBtn_Click(object sender, EventArgs e)
        {
            map.encounters.Add(new EncounterMethod(methods[method.SelectedIndex], new List<Encounter>()));
            methodBinder.ResetBindings(false);
            removeMethodBtn.Enabled = true;
            methodsBox.SelectedIndex = map.encounters.Count - 1;
            methodsBox_SelectedIndexChanged(sender, e);
        }

        private void removeMethodBtn_Click(object sender, EventArgs e)
        {
            map.encounters.RemoveAt(methodsBox.SelectedIndex);
            methodBinder.ResetBindings(false);
            if (map.encounters.Count == 0)
            {
                removeMethodBtn.Enabled = false;
                for (int i = 1; i < 13; i++)
                {
                    Controls[$"per{i}"].Text = null;
                }
            }
        }

        private void methodsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<int> rates = new List<int>();
                for (int i = 0; i < methods.Count; i++)
                {
                    if (map.encounters[methodsBox.SelectedIndex].method.name == methods[i].name) { rates = methods[i].rates; }
                }
                for (int i = 0; i < rates.Count; i++)
                {
                    Controls[$"per{i + 1}"].Text = rates[i].ToString() + "%";
                }
                for (int i = rates.Count + 1; i < 13; i++)
                {
                    Controls[$"per{i}"].Text = null;
                }
                encounterBinder.DataSource = map.encounters[methodsBox.SelectedIndex].encounters;
                encBox.DataSource = encounterBinder;
                encBox.DisplayMember = "display";

                for (int i = map.encounters[methodsBox.SelectedIndex].encounters.Count; i < rates.Count; i++)
                {
                    map.encounters[methodsBox.SelectedIndex].encounters.Add(new Encounter(pokemon[0], 1, 1));
                }
                encounterBinder.ResetBindings(false);
                encBox.SelectedIndex = 0;
                encBox_SelectedIndexChanged(sender, e);
                
            }
            catch (Exception)
            {
                for (int i = 1; i < 13; i++)
                {
                    Controls[$"per{i}"].Text = null;
                }
            }
        }

        private void species_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (starting) return;
            if (map.encounters[methodsBox.SelectedIndex].encounters.Count > 0) map.encounters[methodsBox.SelectedIndex].encounters[encBox.SelectedIndex].species = species.Text;
            encounterBinder.ResetBindings(false);
        }

        private void level1_ValueChanged(object sender, EventArgs e)
        {
            if (starting) return;
            if (map.encounters[methodsBox.SelectedIndex].encounters.Count > 0) map.encounters[methodsBox.SelectedIndex].encounters[encBox.SelectedIndex].level = (int) level1.Value;
            level2.Value = level1.Value;
            encounterBinder.ResetBindings(false);
        }

        private void level2_ValueChanged(object sender, EventArgs e)
        {
            if (starting) return;
            if (map.encounters[methodsBox.SelectedIndex].encounters.Count > 0) map.encounters[methodsBox.SelectedIndex].encounters[encBox.SelectedIndex].leveltwo = (int)level2.Value;
            encounterBinder.ResetBindings(false);
        }

        private void encBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            starting = true;
            if (map.encounters[methodsBox.SelectedIndex].encounters.Count > 0)
            {
                species.Text = map.encounters[methodsBox.SelectedIndex].encounters[encBox.SelectedIndex].species;
                level1.Value = map.encounters[methodsBox.SelectedIndex].encounters[encBox.SelectedIndex].level;
                level2.Value = map.encounters[methodsBox.SelectedIndex].encounters[encBox.SelectedIndex].leveltwo;
            }
            starting = false;
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!terminate)
            {
                if (MessageBox.Show("Are you sure you want to return? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    Close();
                    Dispose();
                }
            }
        }

        private void amountOfEncounterMethodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EncounterMap em = maps[mapBox.SelectedIndex];
            maps.Sort(delegate (EncounterMap em1, EncounterMap em2) { return em1.encounters.Count.CompareTo(em2.encounters.Count); });
            maps.Reverse();
            mapBinder.ResetBindings(false);
            mapBox.SelectedIndex = maps.IndexOf(em);
        }

        private void mapNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EncounterMap em = maps[mapBox.SelectedIndex];
            maps.Sort(delegate (EncounterMap em1, EncounterMap em2) { return em1.sortableName.CompareTo(em2.sortableName); });
            mapBinder.ResetBindings(false);
            mapBox.SelectedIndex = maps.IndexOf(em);
        }

        private void mapIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EncounterMap em = maps[mapBox.SelectedIndex];
            maps.Sort(delegate (EncounterMap em1, EncounterMap em2) { return em1.id.CompareTo(em2.id); });
            mapBinder.ResetBindings(false);
            mapBox.SelectedIndex = maps.IndexOf(em);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string txt = null;
            for (int i = 0; i < maps.Count; i++)
            {
                if (maps[i].encounters.Count > 0)
                {
                    txt += singleMap(maps[i]);
                    if (i != maps.Count - 1) { txt += "\r\n"; }
                }
            }
            PEGame.exportFile("encounters.txt", txt);
        }

        private void overwriteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string txt = null;
            for (int i = 0; i < maps.Count; i++)
            {
                if (maps[i].encounters.Count > 0)
                {
                    txt += singleMap(maps[i]);
                    if (i != maps.Count - 1) { txt += "\r\n"; }
                }
            }
            PEGame.pbsFile("encounters.txt", txt);
        }
    }
}
