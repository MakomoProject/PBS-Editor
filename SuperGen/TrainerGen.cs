using System;
#pragma warning disable IDE1006
#pragma warning disable IDE0017
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using lib;
using PokeGenerator;
using static SuperGen.SuperForm;

namespace SuperGen
{
    public partial class TrainerGen : Form
    {
        private bool msg = true;
        private bool startupError = false;
        private bool terminate = false;
        private bool starting = true;
        private List<string> types = new List<string>();
        private List<string> species = new List<string>();
        private List<string> items = new List<string>();
        private List<string> moves = new List<string>();
        private List<string> balls = new List<string>() { "Poke Ball", "Great Ball", "Safari Ball",  "Ultra Ball", "Master Ball", "Net Ball",
        "Dive Ball", "Nest Ball", "Repeat Ball", "Timer Ball", "Luxury Ball", "Premier Ball", "Dusk Ball", "Heal Ball", "Quick Ball",
        "Cherish Ball", "Fast Ball", "Level Ball", "Lure Ball", "Heavy Ball", "Love Ball", "Friend Ball", "Moon Ball", "Sport Ball"};
        private List<Trainer> trainers = new List<Trainer>();
        private BindingSource trainerBinder = new BindingSource();
        private BindingSource typeBinder = new BindingSource();
        private BindingSource itemBinder1 = new BindingSource();
        private BindingSource itemBinder2 = new BindingSource();
        private BindingSource speciesBinder = new BindingSource();
        private BindingSource ballBinder = new BindingSource();
        private BindingSource moveBinder1 = new BindingSource();
        private BindingSource moveBinder2 = new BindingSource();
        private BindingSource moveBinder3 = new BindingSource();
        private BindingSource moveBinder4 = new BindingSource();
        private BindingSource itemBoxBinder = new BindingSource();
        private BindingSource pokeBoxBinder = new BindingSource();
        private Trainer t;
        private TrainerPoke p;

        public TrainerGen()
        {
            InitializeComponent();
        }

        private string stripCommas(string txt)
        {
            txt += ",";
            List<char> chars = new List<char>();
            chars = txt.ToCharArray().ToList();
            Check:
            chars.RemoveAt(chars.Count - 1);
            if (chars[chars.Count - 1] == ',') { goto Check; }
            string ret = null;
            foreach (char c in chars) { ret += c; }
            return ret;
        }

        private void TrainerGen_Load(object sender, EventArgs e)
        {
            #region Trainertypes.txt
            if (File.Exists(@"PBS\trainertypes.txt"))
            {
                StreamReader sr = new StreamReader(@"PBS\trainertypes.txt");
                string dat = sr.ReadToEnd();
                sr.Close();
                if (string.IsNullOrEmpty(dat))
                {
                    emptyFile("Trainer Editor", "trainertypes");
                    terminate = true;
                    Close();
                    return;
                }
                List<string> data = new List<string>();
                data = dat.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                for (int i = 0; i < data.Count; i++)
                {
                    if (!isUsable(data[i])) { continue; }
                    try
                    {
                        types.Add(data[i].Split(',')[1]);
                    }
                    catch (Exception)
                    {
                        invalidLine("trainertypes", data[i], "Trainer Editor");
                        terminate = true;
                        Close();
                        return;
                    }
                }
            }
            else
            {
                fileNotFound("trainertypes", "Trainer Editor");
                terminate = true;
                Close();
                return;
            }
            #endregion
            #region Pokemon.txt
            if (!startupError)
            {
                if (File.Exists(@"PBS\pokemon.txt"))
                {
                    StreamReader sr = new StreamReader(@"PBS\pokemon.txt");
                    string dat = sr.ReadToEnd();
                    sr.Close();
                    if (string.IsNullOrEmpty(dat))
                    {
                        emptyFile("Trainer Editor", "pokemon");
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
                            species.Add(splitter(data[i], "InternalName=", "\r\n"));
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
                    fileNotFound("pokemon", "Trainer Editor");
                    terminate = true;
                    Close();
                    return;
                }
            }
            #endregion
            #region Items.txt
            if (!startupError)
            {
                if (File.Exists(@"PBS\items.txt"))
                {
                    StreamReader sr = new StreamReader(@"PBS\items.txt");
                    string dat = sr.ReadToEnd();
                    sr.Close();
                    if (string.IsNullOrEmpty(dat))
                    {
                        emptyFile("Trainer Editor", "items");
                        terminate = true;
                        Close();
                        return;
                    }
                    List<string> data = new List<string>();
                    data = dat.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (!isUsable(data[i])) { continue; }
                        try
                        {
                            items.Add(data[i].Split(',')[1]);
                        }
                        catch (Exception)
                        {
                            invalidLine("items", data[i], "Trainer Editor");
                            terminate = true;
                            Close();
                            return;
                        }
                    }
                }
                else
                {
                    fileNotFound("items", "Trainer Editor");
                    terminate = true;
                    Close();
                    return;
                }
            }
            #endregion
            #region Moves.txt
            if (!startupError)
            {
                if (File.Exists(@"PBS\moves.txt"))
                {
                    StreamReader sr = new StreamReader(@"PBS\moves.txt");
                    string dat = sr.ReadToEnd();
                    sr.Close();
                    if (string.IsNullOrEmpty(dat))
                    {
                        emptyFile("Trainer Editor", "moves");
                        terminate = true;
                        Close();
                        return;
                    }
                    List<string> data = new List<string>();
                    data = dat.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (!isUsable(data[i])) { continue; }
                        try
                        {
                            moves.Add(data[i].Split(',')[1]);
                        }
                        catch (Exception)
                        {
                            invalidLine("moves", data[i], "Trainer Editor");
                            terminate = true;
                            Close();
                            return;
                        }
                    }
                }
                else
                {
                    fileNotFound("moves", "Trainer Editor");
                    terminate = true;
                    Close();
                    return;
                }
            }
            #endregion
            #region Trainers.txt
            if (!startupError)
            {
                if (File.Exists(@"PBS\trainers.txt"))
                {
                    StreamReader sr = new StreamReader(@"PBS\trainers.txt");
                    string Data = sr.ReadToEnd();
                    sr.Close();
                    if (string.IsNullOrEmpty(Data))
                    {
                        emptyFile("Trainer Editor", "trainers");
                        terminate = true;
                        Close();
                        return;
                    }
                    List<string> data = new List<string>();
                    data = Data.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (!isUsable(data[i])) { continue; }
                        try
                        {
                            string type = null;
                            string note = null;
                            try
                            {
                                type = data[i].Split('#')[0];
                                note = data[i].Split('#')[1];
                            }
                            catch (Exception)
                            {
                                type = data[i];
                            }
                            if (!types.Contains(type)) { continue; }
                            string name = null;
                            int? id = null;
                            try
                            {
                                name = data[i + 1].Split(',')[0];
                                id = Convert.ToInt32(data[i + 1].Split(',')[1]);
                            }
                            catch (Exception)
                            {
                                name = data[i + 1];
                            }
                            List<string> items = new List<string>();
                            items = data[i + 2].Split(',').ToList();
                            items.RemoveAt(0);
                            int amount = Convert.ToInt32(data[i + 2].Split(',')[0]);
                            List<TrainerPoke> pokes = new List<TrainerPoke>();
                            for (int j = 0; j < amount; j++)
                            {
                                int k = i + 3 + j;
                                List<string> dat = new List<string>();
                                dat = data[k].Split(',').ToList();
                                string species = dat[0];
                                string level = dat[1];
                                string item = null;
                                string move1 = null;
                                string move2 = null;
                                string move3 = null;
                                string move4 = null;
                                string ability = null;
                                string gender = null;
                                string form = null;
                                string shiny = null;
                                string nature = null;
                                string iv = null;
                                string happiness = null;
                                string nick = null;
                                string shadow = null;
                                string ball = null;
                                try
                                {
                                    item = dat[2];
                                    try
                                    {
                                        move1 = dat[3];
                                        try
                                        {
                                            move2 = dat[4];
                                            try
                                            {
                                                move3 = dat[5];
                                                try
                                                {
                                                    move4 = dat[6];
                                                    try
                                                    {
                                                        ability = dat[7];
                                                        try
                                                        {
                                                            gender = dat[8];
                                                            try
                                                            {
                                                                form = dat[9];
                                                                try
                                                                {
                                                                    shiny = dat[10];
                                                                    try
                                                                    {
                                                                        nature = dat[11];
                                                                        try
                                                                        {
                                                                            iv = dat[12];
                                                                            try
                                                                            {
                                                                                happiness = dat[13];
                                                                                try
                                                                                {
                                                                                    nick = dat[14];
                                                                                    try
                                                                                    {
                                                                                        shadow = dat[15];
                                                                                        try
                                                                                        {
                                                                                            ball = dat[16];
                                                                                        }
                                                                                        catch (Exception)
                                                                                        {
                                                                                            ball = null;
                                                                                        }
                                                                                    }
                                                                                    catch (Exception)
                                                                                    {
                                                                                        shadow = null;
                                                                                        ball = null;
                                                                                    }
                                                                                }
                                                                                catch (Exception)
                                                                                {
                                                                                    nick = null;
                                                                                    shadow = null;
                                                                                    ball = null;
                                                                                }
                                                                            }
                                                                            catch (Exception)
                                                                            {
                                                                                happiness = null;
                                                                                nick = null;
                                                                                shadow = null;
                                                                                ball = null;
                                                                            }
                                                                        }
                                                                        catch (Exception)
                                                                        {
                                                                            iv = null;
                                                                            happiness = null;
                                                                            nick = null;
                                                                            shadow = null;
                                                                            ball = null;
                                                                        }
                                                                    }
                                                                    catch (Exception)
                                                                    {
                                                                        nature = null;
                                                                        iv = null;
                                                                        happiness = null;
                                                                        nick = null;
                                                                        shadow = null;
                                                                        ball = null;
                                                                    }
                                                                }
                                                                catch (Exception)
                                                                {
                                                                    shiny = null;
                                                                    nature = null;
                                                                    iv = null;
                                                                    happiness = null;
                                                                    nick = null;
                                                                    shadow = null;
                                                                    ball = null;
                                                                }
                                                            }
                                                            catch (Exception)
                                                            {
                                                                form = null;
                                                                shiny = null;
                                                                nature = null;
                                                                iv = null;
                                                                happiness = null;
                                                                nick = null;
                                                                shadow = null;
                                                                ball = null;
                                                            }
                                                        }
                                                        catch (Exception)
                                                        {
                                                            gender = null;
                                                            form = null;
                                                            shiny = null;
                                                            nature = null;
                                                            iv = null;
                                                            happiness = null;
                                                            nick = null;
                                                            shadow = null;
                                                            ball = null;
                                                        }
                                                    }
                                                    catch (Exception)
                                                    {
                                                        ability = null;
                                                        gender = null;
                                                        form = null;
                                                        shiny = null;
                                                        nature = null;
                                                        iv = null;
                                                        happiness = null;
                                                        nick = null;
                                                        shadow = null;
                                                        ball = null;
                                                    }
                                                }
                                                catch (Exception)
                                                {
                                                    move4 = null;
                                                    ability = null;
                                                    gender = null;
                                                    form = null;
                                                    shiny = null;
                                                    nature = null;
                                                    iv = null;
                                                    happiness = null;
                                                    nick = null;
                                                    shadow = null;
                                                    ball = null;
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                move3 = null;
                                                move4 = null;
                                                ability = null;
                                                gender = null;
                                                form = null;
                                                shiny = null;
                                                nature = null;
                                                iv = null;
                                                happiness = null;
                                                nick = null;
                                                shadow = null;
                                                ball = null;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            move2 = null;
                                            move3 = null;
                                            move4 = null;
                                            ability = null;
                                            gender = null;
                                            form = null;
                                            shiny = null;
                                            nature = null;
                                            iv = null;
                                            happiness = null;
                                            nick = null;
                                            shadow = null;
                                            ball = null;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        move1 = null;
                                        move2 = null;
                                        move3 = null;
                                        move4 = null;
                                        ability = null;
                                        gender = null;
                                        form = null;
                                        shiny = null;
                                        nature = null;
                                        iv = null;
                                        happiness = null;
                                        nick = null;
                                        shadow = null;
                                        ball = null;
                                    }
                                }
                                catch (Exception)
                                {
                                    item = null;
                                    move1 = null;
                                    move2 = null;
                                    move3 = null;
                                    move4 = null;
                                    ability = null;
                                    gender = null;
                                    form = null;
                                    shiny = null;
                                    nature = null;
                                    iv = null;
                                    happiness = null;
                                    nick = null;
                                    shadow = null;
                                    ball = null;
                                }
                                if (shiny == "shiny") { shiny = "true"; }
                                else { shiny = "false"; }
                                if (shadow == null || shadow == "") { shadow = "false"; }
                                if (ability == "") { ability = null; }
                                if (form == "") { form = null; }
                                if (iv == "") { iv = null; }
                                if (happiness == "") { happiness = null; }
                                if (ball == "") { ball = null; }
                                if (gender == null || gender == "") { gender = null; }
                                int lvl = Convert.ToInt32(level);
                                int? abil = null;
                                if (ability != null) { abil = Convert.ToInt32(ability); }
                                char? gen = null;
                                if (gender != null) { gen = Convert.ToChar(gender); }
                                int? frm = null;
                                if (form != null) { frm = Convert.ToInt32(form); }
                                bool shny = Convert.ToBoolean(shiny);
                                int? _iv = null;
                                if (iv != null) { _iv = Convert.ToInt32(iv); }
                                int? happ = null;
                                if (happiness != null) { happ = Convert.ToInt32(happiness); }
                                bool shdw = Convert.ToBoolean(shadow);
                                int? bll = null;
                                if (ball != null) { bll = Convert.ToInt32(ball); }
                                pokes.Add(new TrainerPoke(species, lvl, item, move1, move2, move3, move4, abil, gen, frm, shny, nature, _iv, happ, nick, shdw, bll));
                            }
                            trainers.Add(new Trainer(type, name, Convert.ToInt32(id), items, pokes, note));
                        }
                        catch (Exception)
                        {
                            invalidLine("trainers", data[i], "Trainer Editor");
                            terminate = true;
                            Close();
                            return;
                        }
                    }
                }
                else
                {
                    fileNotFound("trainers", "Trainer Editor");
                    terminate = true;
                    Close();
                    return;
                }
            }
            #endregion
            #region DataBindings
            Trainer t = trainers[0];
            TrainerPoke p = t.pokes[0];
            List<string> temp = new List<string>() { t.type, p.item, p.species, p.ball.ToString() };
            string[] _moves = new string[4];
            p.moves.CopyTo(_moves);

            trainerBinder.DataSource = trainers;
            trainerBox.DataSource = trainerBinder;
            trainerBox.DisplayMember = "typename";

            types.Sort();
            species.Sort();
            items.Sort();
            balls.Sort();
            moves.Sort();

            trainerBox_SelectedIndexChanged(sender, e);
            typeBinder.DataSource = types;
            typeBox.DataSource = typeBinder;
            typeBox.DisplayMember = "name";

            itemBinder1.DataSource = items;
            itemNameBox.DataSource = itemBinder1;
            itemNameBox.DisplayMember = "name";
            itemBinder2.DataSource = items;
            heldItemBox.DataSource = itemBinder2;
            heldItemBox.DisplayMember = "name";

            speciesBinder.DataSource = species;
            speciesBox.DataSource = speciesBinder;
            speciesBox.DisplayMember = "name";

            ballBinder.DataSource = balls;
            ballBox.DataSource = ballBinder;
            ballBox.DisplayMember = "name";

            moveBinder1.DataSource = moves;
            moveBinder2.DataSource = moves;
            moveBinder3.DataSource = moves;
            moveBinder4.DataSource = moves;
            moveBox1.DataSource = moveBinder1;
            moveBox2.DataSource = moveBinder2;
            moveBox3.DataSource = moveBinder3;
            moveBox4.DataSource = moveBinder4;
            moveBox1.DisplayMember = "name";
            moveBox2.DisplayMember = "name";
            moveBox3.DisplayMember = "name";
            moveBox4.DisplayMember = "name";

            t.type = temp[0];
            p.moves = _moves.ToList();
            p.item = temp[1];
            p.species = temp[2];
            p.ball = string.IsNullOrEmpty(temp[3]) ? null : (int?)(Convert.ToInt32(temp[3]));

            byTypeToolStripMenuItem_Click(sender, e);
            trainerBox.SelectedIndex = 0;
            trainerBox_SelectedIndexChanged(sender, e);
            #endregion
        }

        private void trainerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            t = trainers[trainerBox.SelectedIndex];
            typeBox.Text = t.type;
            nameBox.Text = t.name;
            idBox.Value = (decimal)t.id;
            noteBox.Text = t.note;
            itemBoxBinder.DataSource = t.items;
            itemBox.DataSource = itemBoxBinder;
            itemBox.DisplayMember = "name";
            pokeBoxBinder.DataSource = t.pokes;
            pokeBox.DataSource = pokeBoxBinder;
            pokeBox.DisplayMember = "lvlspecies";
            pokeBox.SelectedIndex = 0;
            trainerBinder.ResetBindings(false);
            if (t.pokes.Count == 6) { addPokeBtn.Enabled = false; }
            else { addPokeBtn.Enabled = true; }
            if (t.pokes.Count == 1) { removePokeBtn.Enabled = false; moveUpBtn.Enabled = false; moveDownBtn.Enabled = false; }
            else { removePokeBtn.Enabled = true; moveUpBtn.Enabled = true; moveDownBtn.Enabled = true; }
            pokeBox_SelectedIndexChanged(sender, e);
        }
        private void pokeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            p = trainers[trainerBox.SelectedIndex].pokes[pokeBox.SelectedIndex];
            if (pokeBox.SelectedIndex == 0) { moveUpBtn.Enabled = false; }
            else { moveUpBtn.Enabled = true; }
            if (pokeBox.SelectedIndex == trainers[trainerBox.SelectedIndex].pokes.Count - 1) { moveDownBtn.Enabled = false; }
            else { moveDownBtn.Enabled = true; }
            speciesBox.Text = p.species;
            levelBox.Value = p.level;
            heldItemBox.Text = p.item;
            if (string.IsNullOrEmpty(heldItemBox.Text)) { defHeldItem.Checked = true; }
            else { defHeldItem.Checked = false; }
            shinyBox.Checked = p.shiny;
            shadowBox.Checked = p.shadow;
            moveBox1.Text = p.moves[0];
            moveBox2.Text = p.moves[1];
            moveBox3.Text = p.moves[2];
            moveBox4.Text = p.moves[3];
            if (string.IsNullOrEmpty(moveBox1.Text) && string.IsNullOrEmpty(moveBox2.Text) &&
                string.IsNullOrEmpty(moveBox3.Text) && string.IsNullOrEmpty(moveBox4.Text))
            { defMoveset.Checked = true; } else { defMoveset.Checked = false; }
            if (p.ability != null)
            { defAbility.Checked = false;  abilityBox.Value = (decimal)p.ability; abilityBox.Value += 1; abilityBox.Value -= 1; }
            else { defAbility.Checked = true; }
            if (p.gender == 'M') { genderBox.Text = "Male"; defGender.Checked = false; }
            else if (p.gender == 'F') { genderBox.Text = "Female"; defGender.Checked = false; }
            else { defGender.Checked = true; }
            if (p.form != null)
            { defForm.Checked = false; formBox.Value = (decimal)p.form; formBox.Value += 1; formBox.Value -= 1; }
            else { defForm.Checked = true; }
            if (p.iv != null)
            { defIV.Checked = false; ivBox.Maximum = 32; ivBox.Value = (decimal)p.iv; ivBox.Value += 1; ivBox.Value -= 1; ivBox.Maximum = 31; }
            else { defIV.Checked = true; }
            if (p.happiness != null)
            { defHappiness.Checked = false; happinessBox.Maximum = 256; happinessBox.Value = (decimal)p.happiness; happinessBox.Value += 1; happinessBox.Value -= 1; happinessBox.Maximum = 255; }
            else { defHappiness.Checked = true; }
            if (p.ball != null)
            { ballBox.Text = SuperForm.getBall((int)p.ball); defBall.Checked = false; }
            else { defBall.Checked = true; }
            nickBox.Text = p.nick;
            if (string.IsNullOrEmpty(nickBox.Text)) { defNick.Checked = true; }
            else { defNick.Checked = false; }
            if (!string.IsNullOrEmpty(p.nature))
            { natureBox.Text = p.nature; defNature.Checked = false; }
            else { defNature.Checked = true; }
        }

        private void defHeldItem_CheckedChanged(object sender, EventArgs e)
        {
            if (defHeldItem.Checked)
            {
                heldItemBox.ResetText();
                heldItemBox.Enabled = false;
                p.item = null;
            }
            else
            {
                heldItemBox.Enabled = true;
            }
        }
        private void defMoveset_CheckedChanged(object sender, EventArgs e)
        {
            if (defMoveset.Checked)
            {
                moveBox1.ResetText();
                moveBox1.Enabled = false;
                moveBox2.ResetText();
                moveBox2.Enabled = false;
                moveBox3.ResetText();
                moveBox3.Enabled = false;
                moveBox4.ResetText();
                moveBox4.Enabled = false;
                for (int i = 0; i < 4; i++) { p.moves[i] = null; }
            }
            else
            {
                moveBox1.Enabled = true;
                moveBox2.Enabled = true;
                moveBox3.Enabled = true;
                moveBox4.Enabled = true;
            }
        }
        private void defAbility_CheckedChanged(object sender, EventArgs e)
        {
            if (defAbility.Checked)
            {
                abilityBox.ResetText();
                abilityBox.Enabled = false;
                p.ability = null;
            }
            else
            {
                abilityBox.Enabled = true;
            }
        }
        private void defGender_CheckedChanged(object sender, EventArgs e)
        {
            if (defGender.Checked)
            {
                genderBox.ResetText();
                genderBox.Enabled = false;
                p.gender = null;
            }
            else
            {
                genderBox.Enabled = true;
            }
        }
        private void defForm_CheckedChanged(object sender, EventArgs e)
        {
            if (defForm.Checked)
            {
                formBox.ResetText();
                formBox.Enabled = false;
                p.form = null;
            }
            else
            {
                formBox.Enabled = true;
            }
        }
        private void defNature_CheckedChanged(object sender, EventArgs e)
        {
            if (defNature.Checked)
            {
                natureBox.ResetText();
                natureBox.Enabled = false;
                p.nature = null;
            }
            else
            {
                natureBox.Enabled = true;
            }
        }
        private void defIV_CheckedChanged(object sender, EventArgs e)
        {
            if (defIV.Checked)
            {
                ivBox.ResetText();
                ivBox.Enabled = false;
                p.iv = null;
            }
            else
            {
                ivBox.Enabled = true;
            }
        }
        private void defHappiness_CheckedChanged(object sender, EventArgs e)
        {
            if (defHappiness.Checked)
            {
                happinessBox.ResetText();
                happinessBox.Enabled = false;
                p.happiness = null;
            }
            else
            {
                happinessBox.Enabled = true;
            }
        }
        private void defBall_CheckedChanged(object sender, EventArgs e)
        {
            if (defBall.Checked)
            {
                ballBox.ResetText();
                ballBox.Enabled = false;
                p.ball = null;
            }
            else
            {
                ballBox.Enabled = true;
            }
        }
        private void defNick_CheckedChanged(object sender, EventArgs e)
        {
            if (defNick.Checked)
            {
                nickBox.ResetText();
                nickBox.Enabled = false;
                p.nick = null;
            }
            else
            {
                nickBox.Enabled = true;
            }
        }
        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            t.type = typeBox.Text;
            trainerBinder.ResetBindings(false);
        }
        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            t.name = nameBox.Text;
            trainerBinder.ResetBindings(false);
        }
        private void idBox_ValueChanged(object sender, EventArgs e)
        {
            t.id = (int?)idBox.Value;
        }

        private void trainerListDisplayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayStyle ds = new DisplayStyle();
            ds.ShowDialog();
            if (ds.applied)
            {
                string order = ds.type + ds.name + ds.id;
                if      (order == "100" || order == "200" || order == "300") { trainerBox.DisplayMember = "type"; }
                else if (order == "120" || order == "130" || order == "230") { trainerBox.DisplayMember = "typename"; }
                else if (order == "102" || order == "103" || order == "203") { trainerBox.DisplayMember = "typeid"; }
                else if (order == "010" || order == "020" || order == "030") { trainerBox.DisplayMember = "name"; }
                else if (order == "210" || order == "320" || order == "310") { trainerBox.DisplayMember = "nametype"; }
                else if (order == "012" || order == "023" || order == "013") { trainerBox.DisplayMember = "nameid"; }
                else if (order == "001" || order == "002" || order == "003") { trainerBox.DisplayMember = "id"; }
                else if (order == "201" || order == "301" || order == "302") { trainerBox.DisplayMember = "idtype"; }
                else if (order == "021" || order == "032" || order == "031") { trainerBox.DisplayMember = "idname"; }
                else if (order == "123") { trainerBox.DisplayMember = "typenameid"; }
                else if (order == "132") { trainerBox.DisplayMember = "typeidname"; }
                else if (order == "231") { trainerBox.DisplayMember = "idtypename"; }
                else if (order == "213") { trainerBox.DisplayMember = "nametypeid"; }
                else if (order == "321") { trainerBox.DisplayMember = "idnametype"; }
                else if (order == "312") { trainerBox.DisplayMember = "nameidtype"; }
                trainerBinder.ResetBindings(false);
            }
        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {
            if (itemNameBox.Text.Length > 0)
            {
                t.items.Add(itemNameBox.Text);
                itemBoxBinder.ResetBindings(false);
                removeItemBtn.Enabled = true;
                itemBox.SelectedIndex = t.items.Count - 1;
                if (t.items.Count == 8) { addItemBtn.Enabled = false; }
                else { addItemBtn.Enabled = true; }
            }
        }
        private void removeItemBtn_Click(object sender, EventArgs e)
        {
            t.items.RemoveAt(itemBox.SelectedIndex);
            itemBoxBinder.ResetBindings(false);
            addItemBtn.Enabled = true;
            if (t.items.Count == 0) { removeItemBtn.Enabled = false; }
            else { removeItemBtn.Enabled = true; }
        }

        private void openTrainerstxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"PBS\trainers.txt");
        }
        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to return? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Properties.Settings.Default.TypeNameID = t.type + " " + t.name + " " + t.id;
                Properties.Settings.Default.Save();

                msg = false;
                Close();
                Dispose();
            }
        }

        private void byTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trainers.Sort(delegate (Trainer t1, Trainer t2) { return t1.type.CompareTo(t2.type); });
            trainerBinder.ResetBindings(false);
            trainerBox.SelectedIndex = trainers.IndexOf(t);
            Properties.Settings.Default.TrainerSort = "Type";
        }
        private void byNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trainers.Sort(delegate (Trainer t1, Trainer t2) { return t1.name.CompareTo(t2.name); });
            trainerBinder.ResetBindings(false);
            trainerBox.SelectedIndex = trainers.IndexOf(t);
            Properties.Settings.Default.TrainerSort = "Name";
        }
        private void byIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trainers.Sort(delegate (Trainer t1, Trainer t2) { return t1.sortableID.CompareTo(t2.sortableID); });
            trainerBinder.ResetBindings(false);
            trainerBox.SelectedIndex = trainers.IndexOf(t);
            Properties.Settings.Default.TrainerSort = "ID";
        }
        private void byItemTotalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trainers.Sort(delegate (Trainer t1, Trainer t2) { return t1.items.Count.CompareTo(t2.items.Count); });
            trainerBinder.ResetBindings(false);
            trainerBox.SelectedIndex = trainers.IndexOf(t);
            Properties.Settings.Default.TrainerSort = "Item Total";
        }
        private void byNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trainers.Sort(delegate (Trainer t1, Trainer t2) { return t1.sortableNote.CompareTo(t2.sortableNote); });
            trainerBinder.ResetBindings(false);
            trainerBox.SelectedIndex = trainers.IndexOf(t);
            Properties.Settings.Default.TrainerSort = "Notes";
        }

        private void label21_MouseHover(object sender, EventArgs e)
        {
            noteTip.SetToolTip(label21, "A note to the Developer. This does not affect the Trainer.");
        }
        private void shadowBox_CheckedChanged(object sender, EventArgs e)
        {
            p.shadow = shadowBox.Checked;
        }
        private void shinyBox_CheckedChanged(object sender, EventArgs e)
        {
            p.shiny = shinyBox.Checked;
        }
        private void noteBox_TextChanged(object sender, EventArgs e)
        {
            string ret = null;
            foreach (char c in noteBox.Text)
            { if (c != '#') { ret += c; } }
            noteBox.Text = ret;
            t.note = ret;
            noteBox.Select(noteBox.Text.Length, 0);
        }
        private void speciesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.species = speciesBox.Text;
            pokeBoxBinder.ResetBindings(false);
        }
        private void levelBox_ValueChanged(object sender, EventArgs e)
        {
            p.level = (int)levelBox.Value;
            pokeBoxBinder.ResetBindings(false);
        }
        private void heldItemBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.item = heldItemBox.Text;
        }
        private void moveBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.moves[0] = moveBox1.Text;
        }
        private void moveBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.moves[1] = moveBox2.Text;
        }
        private void moveBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.moves[2] = moveBox3.Text;
        }
        private void moveBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.moves[3] = moveBox4.Text;
        }
        private void abilityBox_ValueChanged(object sender, EventArgs e)
        {
            p.ability = (int)abilityBox.Value;
        }
        private void genderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.gender = Convert.ToChar(genderBox.Text[0]);
        }
        private void formBox_ValueChanged(object sender, EventArgs e)
        {
            p.form = (int)formBox.Value;
        }
        private void natureBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            p.nature = natureBox.Text;
        }
        private void ivBox_ValueChanged(object sender, EventArgs e)
        {
            p.iv = (int)ivBox.Value;
        }
        private void happinessBox_ValueChanged(object sender, EventArgs e)
        {
            p.happiness = (int)happinessBox.Value;
        }
        private void ballBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!starting) { p.ball = SuperForm.getBallCode(ballBox.Text); }
        }
        private void nickBox_TextChanged(object sender, EventArgs e)
        {
            p.nick = nickBox.Text;
        }

        private void generateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
Trainer t = trainers[trainerBox.SelectedIndex];
string id = t.id > 0 ? "," + t.id : null;
string note = !string.IsNullOrEmpty(t.note) ? "#" + t.note : null;
string items = t.items.Count > 0 ? "," + SuperForm.combine(t.items) : null;
string txt = $@"#==============================
{t.type}{note}
{t.name}{id}
{t.pokes.Count}{items}
"; for (int i = 0; i < t.pokes.Count; i++)
{
TrainerPoke p = t.pokes[i];
string shadow = p.shadow ? "true" : null;
string shiny = p.shiny ? "shiny" : null;
txt += stripCommas($"{p.species},{p.level},{p.item},{p.moves[0]},{p.moves[1]},{p.moves[2]},{p.moves[3]},{p.ability},{p.gender},{p.form},"
+ $"{shiny},{p.nature},{p.iv},{p.happiness},{p.nick},{shadow},{p.ball}");
if (i != t.pokes.Count - 1) { txt += "\r\n"; } }
            GeneratePokemon gp = new GeneratePokemon();
            gp.gennedPokemon = txt;
            gp.Show();
        }
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
Trainer t = trainers[trainerBox.SelectedIndex];
string id = t.id > 0 ? "," + t.id : null;
string note = !string.IsNullOrEmpty(t.note) ? "#" + t.note : null;
string items = t.items.Count > 0 ? "," + SuperForm.combine(t.items) : null;
string txt = $@"#==============================
{t.type}{note}
{t.name}{id}
{t.pokes.Count}{items}
"; for (int i = 0; i < t.pokes.Count; i++) {
TrainerPoke p = t.pokes[i];
string shadow = p.shadow ? "true" : null;
string shiny = p.shiny ? "shiny" : null;
txt += stripCommas($"{p.species},{p.level},{p.item},{p.moves[0]},{p.moves[1]},{p.moves[2]},{p.moves[3]},{p.ability},{p.gender},{p.form},"
+ $"{shiny},{p.nature},{p.iv},{p.happiness},{p.nick},{shadow},{p.ball}");
if (i != t.pokes.Count - 1) { txt += "\r\n"; } }
            PEGame.exportFile($"trainers{t.type} {t.name}.txt", txt);
        }
        private void generateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string txt = null;
for (int i = 0; i < trainers.Count; i++)
{
Trainer t = trainers[i];
string id = t.id > 0 ? "," + t.id : null;
string note = !string.IsNullOrEmpty(t.note) ? "#" + t.note : null;
string items = t.items.Count > 0 ? "," + SuperForm.combine(t.items) : null;
txt += $@"#==============================
{t.type}{note}
{t.name}{id}
{t.pokes.Count}{items}
"; for (int j = 0; j < t.pokes.Count; j++) {
TrainerPoke p = t.pokes[j];
string shadow = p.shadow ? "true" : null;
string shiny = p.shiny ? "shiny" : null;
txt += stripCommas($"{p.species},{p.level},{p.item},{p.moves[0]},{p.moves[1]},{p.moves[2]},{p.moves[3]},{p.ability},{p.gender},{p.form},"
+ $"{shiny},{p.nature},{p.iv},{p.happiness},{p.nick},{shadow},{p.ball}");
if (j != t.pokes.Count - 1) { txt += "\r\n"; } }
if (i != trainers.Count -1) { txt += "\r\n"; } }
            GeneratePokemon gp = new GeneratePokemon();
            gp.gennedPokemon = txt;
            gp.Show();
        }
        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
string txt = null;
for (int i = 0; i < trainers.Count; i++) {
Trainer t = trainers[i];
string id = t.id > 0 ? "," + t.id : null;
string note = !string.IsNullOrEmpty(t.note) ? "#" + t.note : null;
string items = t.items.Count > 0 ? "," + SuperForm.combine(t.items) : null;
txt += $@"#==============================
{t.type}{note}
{t.name}{id}
{t.pokes.Count}{items}
"; for (int j = 0; j < t.pokes.Count; j++) {
TrainerPoke p = t.pokes[j];
string shadow = p.shadow ? "true" : null;
string shiny = p.shiny ? "shiny" : null;
txt += stripCommas($"{p.species},{p.level},{p.item},{p.moves[0]},{p.moves[1]},{p.moves[2]},{p.moves[3]},{p.ability},{p.gender},{p.form},"
+ $"{shiny},{p.nature},{p.iv},{p.happiness},{p.nick},{shadow},{p.ball}");
if (j != t.pokes.Count - 1) { txt += "\r\n"; } }
if (i != trainers.Count -1) { txt += "\r\n"; } }
            PEGame.exportFile("trainers.txt", txt);
        }
        private void overwriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SuperForm.confirmOverwrite("trainers.txt"))
            {
string txt = null;
for (int i = 0; i < trainers.Count; i++) {
Trainer t = trainers[i];
string id = t.id > 0 ? "," + t.id : null;
string note = !string.IsNullOrEmpty(t.note) ? "#" + t.note : null;
string items = t.items.Count > 0 ? "," + SuperForm.combine(t.items) : null;
txt += $@"#==============================
{t.type}{note}
{t.name}{id}
{t.pokes.Count}{items}
"; for (int j = 0; j < t.pokes.Count; j++) {
TrainerPoke p = t.pokes[j];
string shadow = p.shadow ? "true" : null;
string shiny = p.shiny ? "shiny" : null;
txt += stripCommas($"{p.species},{p.level},{p.item},{p.moves[0]},{p.moves[1]},{p.moves[2]},{p.moves[3]},{p.ability},{p.gender},{p.form},"
+ $"{shiny},{p.nature},{p.iv},{p.happiness},{p.nick},{shadow},{p.ball}");
if (j != t.pokes.Count - 1) { txt += "\r\n"; } }
if (i != trainers.Count -1) { txt += "\r\n"; } }
                PEGame.pbsFile("trainers.txt", txt); }
        }

        private void defaultBtn_Click(object sender, EventArgs e)
        {

            defHeldItem.Checked = true;
            defMoveset.Checked = true;
            defAbility.Checked = true;
            defGender.Checked = true;
            defForm.Checked = true;
            defNature.Checked = true;
            defIV.Checked = true;
            defHappiness.Checked = true;
            defBall.Checked = true;
            defNick.Checked = true;
            shinyBox.Checked = false;
            shadowBox.Checked = false;
        }
        private void addTrainerBtn_Click(object sender, EventArgs e)
        {
            trainers.Add(new Trainer(types[0], "Temp", 0, new List<string>(), new List<TrainerPoke>() { new TrainerPoke(species[0], 5, null, null, null, null, null, null, null, null, false, null, null, null, null, false, null) }, null));
            trainerBinder.ResetBindings(false);
            trainerBox.SelectedIndex = trainers.Count - 1;
            removeTrainerBtn.Enabled = true;
        }
        private void removeTrainerBtn_Click(object sender, EventArgs e)
        {
            trainers.RemoveAt(trainerBox.SelectedIndex);
            trainerBinder.ResetBindings(false);
            if (trainers.Count == 0) { removeTrainerBtn.Enabled = false; }
            else { trainerBox_SelectedIndexChanged(sender, e); }
        }
        private void moveUpBtn_Click(object sender, EventArgs e)
        {
            TrainerPoke poke = t.pokes[pokeBox.SelectedIndex];
            t.pokes[pokeBox.SelectedIndex] = t.pokes[pokeBox.SelectedIndex - 1];
            t.pokes[pokeBox.SelectedIndex - 1] = poke;
            pokeBox.SelectedIndex -= 1;
            pokeBoxBinder.ResetBindings(false);
        }
        private void moveDownBtn_Click(object sender, EventArgs e)
        {
            TrainerPoke poke = t.pokes[pokeBox.SelectedIndex];
            t.pokes[pokeBox.SelectedIndex] = t.pokes[pokeBox.SelectedIndex + 1];
            t.pokes[pokeBox.SelectedIndex + 1] = poke;
            pokeBox.SelectedIndex += 1;
            pokeBoxBinder.ResetBindings(false);
        }

        private void addPokeBtn_Click(object sender, EventArgs e)
        {
            t.pokes.Add(new TrainerPoke(species[0], 5, null, null, null, null, null, null, null, null, false, null, null, null, null, false, null));
            pokeBoxBinder.ResetBindings(false);
            pokeBox.SelectedIndex += 1;
            removePokeBtn.Enabled = true;
            if (t.pokes.Count == 6) { addPokeBtn.Enabled = false; }
        }
        private void removePokeBtn_Click(object sender, EventArgs e)
        {
            t.pokes.RemoveAt(pokeBox.SelectedIndex);
            pokeBoxBinder.ResetBindings(false);
            pokeBox_SelectedIndexChanged(sender, e);
            if (t.pokes.Count == 1) { removePokeBtn.Enabled = false; }
        }

        private void TrainerGen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!terminate)
            {
                if (!msg) { e.Cancel = true; return; }
                if (MessageBox.Show("Are you sure you want to exit? Changes may be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {

                    Properties.Settings.Default.TypeNameID = t.type + " " + t.name + " " + t.id;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void reloadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to reload all data?\r\nThis will overwrite any unsaved changes.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                types.Clear();
                species.Clear();
                items.Clear();
                moves.Clear();
                balls.Clear();
                trainers.Clear();
                TrainerGen_Load(sender, e);
            }
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            typeTip.SetToolTip(label1, "The trainer class of the Trainer.");
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            nameTip.SetToolTip(label2, "The individual name of the Trainer.");
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            idTip.SetToolTip(label3, "The individual ID of the Trainer.");
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            itemsTip.SetToolTip(label4, "Bag Items for the Trainer to use on their Pokemon.");
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            itemTip.SetToolTip(label5, "The Bag Item to add to the Trainer's items available for usage.");
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            pokemonTip.SetToolTip(label6, "The Pokémon species to add to the Trainer's party.");
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            levelTip.SetToolTip(label7, "The level of the Pokémon.");
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            heldItemTip.SetToolTip(label8, "The Bag Item the Pokémon will hold in battle.");
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            move1Tip.SetToolTip(label9, "The first Move of the Pokémon.");
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            move1Tip.SetToolTip(label10, "The second Move of the Pokémon.");
        }

        private void label11_MouseHover(object sender, EventArgs e)
        {
            move1Tip.SetToolTip(label11, "The third Move of the Pokémon.");
        }

        private void label12_MouseHover(object sender, EventArgs e)
        {
            move1Tip.SetToolTip(label12, "The fourth Move of the Pokémon.");
        }

        private void label13_MouseHover(object sender, EventArgs e)
        {
            abilityTip.SetToolTip(label13, "Which of its natural Abilities the Pokémon should have.");
        }

        private void label14_MouseHover(object sender, EventArgs e)
        {
            genderTip.SetToolTip(label14, "The gender of the Pokémon.");
        }

        private void label15_MouseHover(object sender, EventArgs e)
        {
            formTip.SetToolTip(label15, "Which form the Pokémon will be.");
        }

        private void label16_MouseHover(object sender, EventArgs e)
        {
            natureTip.SetToolTip(label16, "The Nature of the Pokémon.");
        }

        private void label17_MouseHover(object sender, EventArgs e)
        {
            ivTip.SetToolTip(label17, "What all of the Pokémon's IVs will be set to.");
        }

        private void label18_MouseHover(object sender, EventArgs e)
        {
            happinessTip.SetToolTip(label18, "How happy the Pokémon will be towards the Trainer.");
        }

        private void label19_MouseHover(object sender, EventArgs e)
        {
            ballTip.SetToolTip(label19, "What ball the Pokémon will be in.");
        }

        private void label20_MouseHover(object sender, EventArgs e)
        {
            nickTip.SetToolTip(label20, "The nickname of the Pokémon.");
        }
    }
}
