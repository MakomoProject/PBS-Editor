using System;
using System.Drawing;
using System.Windows.Forms;
using MoveGen;
using MiscGen;
using System.IO;
using System.Net;
using System.Collections.Generic;

// TO-DO LIST:
// * Add Party icons and footprints in Pokégen and let the user set the sprite


/*
ilmerge C:\Users\Eigenaar\Desktop\SuperGen.exe C:\Users\Eigenaar\Desktop\lib.dll C:\Users\Eigenaar\Desktop\Courtneys_SpriteStrip.dll /out:C:\Users\Eigenaar\Desktop\PBS+.exe /target:winexe /targetplatform:"v4,C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0"

ilmerge C:\Users\Eigenaar\Desktop\Application_Updater.exe C:\Users\Eigenaar\Desktop\Ionic.Zip.Reduced.dll /out:C:\Users\Eigenaar\Desktop\PBS+_Updater.exe /target:winexe /targetplatform:"v4,C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0"
*/

namespace SuperGen
{
    public partial class SuperForm : Form
    {
        private string version;
        private const string LENNEH = "WHY ARE YOU LOOKING IN MY CODE ( ͡° ͜ʖ ͡°)";
        private string html;
        private string masterUrl = "http://pastebin.com/raw/31d54Rb0";
        public static string changelogUrl = "https://pastebin.com/raw/12As4Qvz";
        public static PEGame peGame = PEGame.NewInstance();


        public SuperForm()
        {
            InitializeComponent();
        }

        public static string gameRoot(string path)
        {
            return peGame.root(path);
        }

        public static string getBall(int ball)
        {
            switch (ball)
            {
                case 0: return "Poke Ball";
                case 1: return "Great Ball";
                case 2: return "Safari Ball";
                case 3: return "Ultra Ball";
                case 4: return "Master Ball";
                case 5: return "Net Ball";
                case 6: return "Dive Ball";
                case 7: return "Nest Ball";
                case 8: return "Repeat Ball";
                case 9: return "Timer Ball";
                case 10: return "Luxury Ball";
                case 11: return "Premier Ball";
                case 12: return "Dusk Ball";
                case 13: return "Heal Ball";
                case 14: return "Quick Ball";
                case 15: return "Cherish Ball";
                case 16: return "Fast Ball";
                case 17: return "Level Ball";
                case 18: return "Lure Ball";
                case 19: return "Heavy Ball";
                case 20: return "Love Ball";
                case 21: return "Friend Ball";
                case 22: return "Moon Ball";
                case 23: return "Sport Ball";
                default: return "Poke Ball";
            }
        }
        public static int getBallCode(string ball)
        {
            switch (ball)
            {
                case "Poke Ball": return 0;
                case "Great Ball": return 1;
                case "Safari Ball": return 2;
                case "Ultra Ball": return 3;
                case "Master Ball": return 4;
                case "Net Ball": return 5;
                case "Dive Ball": return 6;
                case "Nest Ball": return 7;
                case "Repeat Ball": return 8;
                case "Timer Ball": return 9;
                case "Luxury Ball": return 10;
                case "Premier Ball": return 11;
                case "Dusk Ball": return 12;
                case "Heal Ball": return 13;
                case "Quick Ball": return 14;
                case "Cherish Ball": return 15;
                case "Fast Ball": return 16;
                case "Level Ball": return 17;
                case "Lure Ball": return 18;
                case "Heavy Ball": return 19;
                case "Love Ball": return 20;
                case "Friend Ball": return 21;
                case "Moon Ball": return 22;
                case "Sport Ball": return 23;
                default: return 0;
            }
        }
        public static string lister(List<string> dat)
        {
            string ret = null;
            foreach (string o in dat)
            {
                ret += o + ", ";
            }
            return ret;
        }
        public static string splitter(string splitThis, string fromHere, string toHere)
        {
            return splitThis.Split(new string[] { fromHere }, StringSplitOptions.None)[1].Split(new string[] { toHere }, StringSplitOptions.None)[0];
        }
        public static void fileNotFound(string file, string editor)
        {
            MessageBox.Show($"{editor}: \"{file}.txt\" couldn't be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void invalidLine(string file, string invalidLine, string editor)
        {
            MessageBox.Show($"{editor}: Something went wrong whilst loading \"{file}.txt\". This line appears to be invalid:\r\n{invalidLine}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void emptyFile(string editor, string file)
        {
            MessageBox.Show($"{editor}: \"{file}.txt\" is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static string combine<T>(List<T> entries)
        {
            string ret = null;
            for (int i = 0; i < entries.Count; i++) { ret += entries[i].ToString(); if (i != entries.Count - 1) { ret += ","; } }
            return ret;
        }
        public static void exportFile(string file, string txt)
        {
            if (!Directory.Exists("Exported")) { Directory.CreateDirectory("Exported"); }
            if (File.Exists($@"Exported\{file}")) { File.Delete($@"Exported\{file}"); }
            StreamWriter sw = new StreamWriter($@"Exported\{file}");
            sw.Write(txt);
            sw.Close();
        }
        public static void pbsFile(string file, string txt)
        {
            if (!Directory.Exists("Backups")) { Directory.CreateDirectory("Backups"); }
            if (File.Exists($@"Backups\{file}")) { File.Delete($@"Backups\{file}"); }
            File.Move($@"PBS\{file}", $@"Backups\{file}");
            StreamWriter sw = new StreamWriter($@"PBS\{file}");
            sw.Write(txt);
            sw.Close();
        }
        public static string iterate<T>(List<T> entries)
        {
            string ret = null;
            for (int i = 0; i < entries.Count; i++)
            {
                ret += i + " : " + entries[i].ToString();
                if (i != entries.Count - 1) { ret += "\r\n"; }
            }
            return ret;
        }
        public static bool confirmOverwrite(string file)
        {
            DialogResult dr = MessageBox.Show($"You are about to overwrite \"{file}\". Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes) { return true; }
            return false;
        }
        public static bool isUsable(string data)
        {
            return (!data.StartsWith("#") && !data.StartsWith("\r\n") && !data.StartsWith(" ") && data.Length > 0);
        }

        private void chooseGameFolder(string path)
        {
            peGame = PEGame.NewInstance();
            peGame.gameFolder = path;
            gameFolderToolStripStatusLabel.Text = peGame.gameFolder;

            loadVersion();
        }

        private void loadVersion()
        {
            if (File.Exists(gameRoot("Version.txt")))
            {
                StreamReader sr = new StreamReader(File.OpenRead(gameRoot("Version.txt")));
                version = System.Text.Encoding.ASCII.GetString(Convert.FromBase64String(sr.ReadToEnd()));
                sr.Close();
            }
            else if (File.Exists(gameRoot("game.ini")))
            {
                StreamReader sr = new StreamReader(gameRoot("game.ini"));
                version = sr.ReadToEnd();
                version = version.Split(new string[] { "Title=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                version = "(" + version + ")";
                sr.Close();
            }
            else
            {
                version = "v0.0.0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PokeGenerator.PokeGenerator pg = new PokeGenerator.PokeGenerator();
            pg.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MoveGenForm mg = new MoveGenForm();
            mg.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            TrainerGen tg = new TrainerGen();
            tg.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            TypeGen tg = new TypeGen();
            tg.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            AbilityForm af = new AbilityForm();
            af.Show();
        }
        private void SuperForm_Load(object sender, EventArgs e)
        {
            gameFolderToolStripStatusLabel.Text = peGame.gameFolder;

            if (File.Exists(gameRoot(@"PBS\editorinfo.txt")))
            {
                StreamWriter sw = new StreamWriter(File.OpenWrite(gameRoot(@"PBS\editorinfo.txt")));
                sw.Write(
@"[POKEDEXES]
pokedex1=Kanto
pokedex2=Johto
pokedex3=National
");
                sw.Close();
            }

            chooseGameFolder(peGame.gameFolder);

            WebClient client = new WebClient();
            Stream stream = client.OpenRead(masterUrl);
            client.Dispose();
            StreamReader wr = new StreamReader(stream);
            html = wr.ReadToEnd();
            wr.Dispose();
            if (version != html.Split('|')[0])
            {
                Label l = new Label();
                l.Size = new Size(404, 13);
                l.Location = new Point(81, 199);
                l.Text = $"You're not running the latest version. Current version: {version} - Latest Version: v{html.Split('|')[0]}";
                Controls.Add(l);
                MaximumSize = new Size(MaximumSize.Width, MaximumSize.Height + 10);
                Height += 10;
            }
            Text = $"Pokémon PBS+ {version}";
        }

        private void updateBtn(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            TrainerClassForm tcf = new TrainerClassForm();
            tcf.Show();
        }

        private void openPBSFolderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var pbs = gameRoot("PBS");
            if (Directory.Exists(pbs))
                System.Diagnostics.Process.Start(pbs);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("                   Pokémon PBS+ by M3rein\r\nAnimated PNG support by Pinkcatdragon (FluffyDragon)\r\n      Version Updater by Pinkcatdragon (FluffyDragon)", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ItemEditor ie = new ItemEditor();
            ie.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 9; i++) { Controls["button" + i].Visible = false; }
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SpriteViewer sv = new SpriteViewer();
            sv.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < 9; i++) { Controls["button" + i].Visible = true; }
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Changelog df = new Changelog();
            df.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            EncounterEditor ee = new EncounterEditor();
            ee.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            TMEditor tme = new TMEditor();
            tme.Show();
        }

        private void selectGameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Please select the game path";
            dialog.SelectedPath = peGame.gameFolder;
            //dialog.RootFolder = Environment.SpecialFolder.Programs;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                chooseGameFolder(dialog.SelectedPath);
            }
        }


    }
}
