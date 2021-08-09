using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lib;

namespace SuperGen
{
    public class PEGame
    {
        public static PEGame Instance { get; private set; }

        public static PEGame NewInstance()
        {
            Instance = new PEGame();
            return Instance;
        }

        public bool show_shape = false;

        public List<Poke> pokes = new List<Poke>();
        public List<string> moves = new List<string>();
        public List<string> abilities = new List<string>();
        public List<string> items = new List<string>();
        public List<string> types = new List<string>();
        public List<string> eggmoves = new List<string>();
        public List<string> evopoke = new List<string>();
        public List<string> evomethod = new List<string>();
        public List<string> evoparam = new List<string>();



        public string gameFolder = "K:\\game\\Pokemon Essentials v19.1 2021-05-22";

        public string root(string path)
        {
            return System.IO.Path.Combine(gameFolder, path);
        }

        public void disposeData()
        {
            //thisid = null;
            pokes.Clear();
            moves.Clear();
            abilities.Clear();
            items.Clear();
            types.Clear();
            eggmoves.Clear();
            evopoke.Clear();
            evomethod.Clear();
            evoparam.Clear();
        }

        #region Load

        public bool loadItems()
        {
            try
            {
                items.Clear();
                StreamReader read1 = new StreamReader(root(@"PBS\items.txt"));
                string dat = read1.ReadToEnd();
                read1.Close();
                if (string.IsNullOrEmpty(dat))
                {
                    emptyFile("Pokémon Editor", "items");
                    return false;
                }
                string stuff1 = dat;
                if (!string.IsNullOrEmpty(stuff1))
                {
                    List<string> allItemData = new List<string>();
                    allItemData = stuff1.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    for (int i = 0; i < allItemData.Count; i++)
                    {
                        try
                        {
                            if (isUsable(allItemData[i]))
                            {
                                items.Add(allItemData[i].Split(',')[1]);
                            }
                        }
                        catch (Exception)
                        {
                            invalidLine("items", allItemData[i], "Pokémon Editor");
                            return false;
                        }
                    }
                    items.Sort();
                }
                else
                {

                    MessageBox.Show("Something went wrong while converting data from \"items.txt\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception)
            {
                fileNotFound("items", "Pokémon Editor");
                return false;
            }
            return true;
        }

        public bool loadAbilities()
        {
            try
            {
                abilities.Clear();
                StreamReader read2 = new StreamReader(root(@"PBS\abilities.txt"));
                string dat = read2.ReadToEnd();
                read2.Close();
                if (string.IsNullOrEmpty(dat))
                {
                    emptyFile("Pokémon Editor", "abilities");
                    return false;
                }
                string stuff2 = dat;
                if (!string.IsNullOrEmpty(stuff2))
                {
                    List<string> allAbilData = new List<string>();
                    allAbilData = stuff2.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    for (int i = 0; i < allAbilData.Count; i++)
                    {
                        try
                        {
                            if (isUsable(allAbilData[i]))
                            {
                                abilities.Add(allAbilData[i].Split(',')[1]);
                            }
                        }
                        catch (Exception)
                        {
                            invalidLine("abilities", allAbilData[i], "Pokémon Editor");
                            return false;
                        }
                    }
                    abilities.Sort();
                }
                else
                {
                    MessageBox.Show("Something went wrong while converting data from \"abilities.txt\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception)
            {
                fileNotFound("abilities", "Pokémon Editor");
                return false;
            }
            return true;
        }

        public bool loadMoves()
        {
            try
            {
                moves.Clear();
                StreamReader read3 = new StreamReader(root(@"PBS\moves.txt"));
                string dat = read3.ReadToEnd();
                read3.Close();
                if (string.IsNullOrEmpty(dat))
                {
                    emptyFile("Pokémon Editor", "moves");
                    return false;
                }
                string stuff3 = dat;
                if (!string.IsNullOrEmpty(stuff3))
                {
                    List<string> allMoveData = new List<string>();
                    allMoveData = stuff3.Split(new string[] { "\n" }, StringSplitOptions.None).ToList();
                    for (int i = 0; i < allMoveData.Count; i++)
                    {
                        try
                        {
                            if (isUsable(allMoveData[i]))
                            {
                                moves.Add(allMoveData[i].Split(',')[1]);
                            }
                        }
                        catch (Exception)
                        {
                            invalidLine("moves", allMoveData[i], "Pokémon Editor");
                            return false;
                        }
                    }
                    moves.Sort();
                }
                else
                {
                    MessageBox.Show("Something went wrong while converting data from \"moves.txt\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception)
            {
                fileNotFound("moves", "Pokémon Editor");
                return false;
            }
            return true;
        }

        public bool loadTypes()
        {
            try
            {
                types.Clear();
                StreamReader read4 = new StreamReader(root(@"PBS\types.txt"));
                string dat = read4.ReadToEnd();
                read4.Close();
                if (string.IsNullOrEmpty(dat))
                {
                    emptyFile("Pokémon Editor", "types");
                    return false;
                }
                string stuff4 = dat;
                if (!string.IsNullOrEmpty(stuff4))
                {
                    List<string> allTypeData = new List<string>();
                    stuff4 = stuff4.Replace(" = ", "=");
                    allTypeData = stuff4.Split('[').ToList();
                    allTypeData.RemoveAt(0);
                    for (int i = 0; i < allTypeData.Count; i++)
                    {
                        try
                        {
                            if (allTypeData[i].Length > 0)
                            {
                                types.Add(allTypeData[i].Split(new string[] { "InternalName=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                                types.Sort();
                            }
                        }
                        catch (Exception)
                        {
                            invalidLine("types", allTypeData[i], "Pokémon Editor");
                            return false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Something went wrong while loading \"types.txt\".\r\nMake sure the app is installed correctly\r\nAnd the data inside the file is valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception)
            {
                fileNotFound("types", "Pokémon Editor");
                return false;
            }
            return true;
        }

        public bool loadPokemon()
        {
            try
            {
                pokes.Clear();
                StreamReader read5 = new StreamReader(root(@"PBS\pokemon.txt"));
                string dat = read5.ReadToEnd();
                read5.Close();
                if (string.IsNullOrEmpty(dat))
                {
                    emptyFile("Pokémon Editor", "pokemon");
                    return false;
                }
                string stuff5 = dat;
                if (!string.IsNullOrEmpty(stuff5))
                {
                    List<string> allPokeData = new List<string>();
                    stuff5 = stuff5.Replace(" = ", "=");
                    allPokeData = stuff5.Split('[').ToList();
                    for (int i = 1; i < allPokeData.Count; i++)
                    {
                        try
                        {
                            int id = 1;
                            try
                            {
                                id = Convert.ToInt32(allPokeData[i].Split(']')[0]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read ID for iteration {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }
                            string name = null;
                            try
                            {
                                foreach (char c in allPokeData[i].Split(new string[] { "Name=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0])
                                { if (c == '�') { name += "é"; } else { name += c; } }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read and process Name for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }

                            string intname = null;
                            try
                            {
                                foreach (char c in allPokeData[i].Split(new string[] { "InternalName=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0])
                                { if (c == '�') { intname += "é"; } else { intname += c; } }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read and process InternalName for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }

                            string type1 = null;
                            try
                            {
                                type1 = allPokeData[i].Split(new string[] { "Type1=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Type1 for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }
                            string type2 = null;
                            string ability1 = null;
                            string ability2 = null;
                            string hiddenabil = null;
                            string egg1 = null;
                            string egg2 = null;
                            int evhp = 0;
                            int evatk = 0;
                            int evdef = 0;
                            int evspatk = 0;
                            int evspdef = 0;
                            int evspeed = 0;
                            string habitat = null;
                            int battlerpy = 0;
                            int battlerey = 0;
                            int battleralt = 0;
                            string itemcmn = null;
                            string itemuncmn = null;
                            string itemrare = null;
                            string incense = null;
                            string dexnums = null;
                            string formnames = null;
                            List<string> t = new List<string>();
                            List<string> eggmoves = new List<string>();

                            try
                            {
                                if (allPokeData[i].Contains("Type2=")) { type2 = allPokeData[i].Split(new string[] { "Type2=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Type2 for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }
                            int hp = 0;
                            int atk = 0;
                            int def = 0;
                            int spatk = 0;
                            int spdef = 0;
                            int speed = 0;
                            try
                            {
                                hp = Convert.ToInt32(allPokeData[i].Split(new string[] { "BaseStats=" }, StringSplitOptions.None)[1].Split(',')[0]);
                                atk = Convert.ToInt32(allPokeData[i].Split(new string[] { "BaseStats=" }, StringSplitOptions.None)[1].Split(',')[1]);
                                def = Convert.ToInt32(allPokeData[i].Split(new string[] { "BaseStats=" }, StringSplitOptions.None)[1].Split(',')[2]);
                                spatk = Convert.ToInt32(allPokeData[i].Split(new string[] { "BaseStats=" }, StringSplitOptions.None)[1].Split(',')[4]);
                                spdef = Convert.ToInt32(allPokeData[i].Split(new string[] { "BaseStats=" }, StringSplitOptions.None)[1].Split(',')[5].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                                speed = Convert.ToInt32(allPokeData[i].Split(new string[] { "BaseStats=" }, StringSplitOptions.None)[1].Split(',')[3]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse BaseStats for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }

                            string genderratio = null;
                            try
                            {
                                genderratio = allPokeData[i].Split(new string[] { "GenderRate=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read GenderRate for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }
                            string growthrate = null;
                            try
                            {
                                growthrate = allPokeData[i].Split(new string[] { "GrowthRate=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read GrowthRate for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }

                            int exp = 0;
                            try
                            {
                                exp = Convert.ToInt32(allPokeData[i].Split(new string[] { "BaseEXP=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse BaseEXP for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }

                            try
                            {
                                if (allPokeData[i].Contains("EffortPoints=")) { evhp = Convert.ToInt32(allPokeData[i].Split(new string[] { "EffortPoints=" }, StringSplitOptions.None)[1].Split(',')[0]); }
                                if (allPokeData[i].Contains("EffortPoints=")) { evatk = Convert.ToInt32(allPokeData[i].Split(new string[] { "EffortPoints=" }, StringSplitOptions.None)[1].Split(',')[1]); }
                                if (allPokeData[i].Contains("EffortPoints=")) { evdef = Convert.ToInt32(allPokeData[i].Split(new string[] { "EffortPoints=" }, StringSplitOptions.None)[1].Split(',')[2]); }
                                if (allPokeData[i].Contains("EffortPoints=")) { evspatk = Convert.ToInt32(allPokeData[i].Split(new string[] { "EffortPoints=" }, StringSplitOptions.None)[1].Split(',')[4]); }
                                if (allPokeData[i].Contains("EffortPoints=")) { evspdef = Convert.ToInt32(allPokeData[i].Split(new string[] { "EffortPoints=" }, StringSplitOptions.None)[1].Split(',')[5].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]); }
                                if (allPokeData[i].Contains("EffortPoints=")) { evspeed = Convert.ToInt32(allPokeData[i].Split(new string[] { "EffortPoints=" }, StringSplitOptions.None)[1].Split(',')[3]); }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse EffortPoints for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }

                            int catchrate = 0;
                            try
                            {
                                catchrate = Convert.ToInt32(allPokeData[i].Split(new string[] { "Rareness=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse Rareness for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }

                            int happiness = Convert.ToInt32(allPokeData[i].Split(new string[] { "Happiness=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                            try
                            {
                                try
                                {
                                    ability2 = allPokeData[i].Split(new string[] { "Abilities=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',')[1];
                                    ability1 = allPokeData[i].Split(new string[] { "Abilities=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',')[0];
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    try
                                    {
                                        ability1 = allPokeData[i].Split(new string[] { "Abilities=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        ability1 = null; ability2 = null;
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read and process Abilities for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }

                            try
                            {
                                if (allPokeData[i].Contains("HiddenAbility=")) { hiddenabil = allPokeData[i].Split(new string[] { "HiddenAbility=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read HiddenAbility for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }

                            try
                            {
                                try
                                {
                                    egg2 = allPokeData[i].Split(new string[] { "Compatibility=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',')[1];
                                    egg1 = allPokeData[i].Split(new string[] { "Compatibility=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',')[0];
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    egg1 = allPokeData[i].Split(new string[] { "Compatibility=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read and process Compatibility for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }

                            int hatchtime = 0;
                            try
                            {
                                hatchtime = Convert.ToInt32(allPokeData[i].Split(new string[] { "StepsToHatch=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse StepsToHatch for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }

                            decimal height = 0;
                            try
                            {
                                height = Convert.ToDecimal(allPokeData[i].Split(new string[] { "Height=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse Height for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }

                            decimal weight = 0;
                            try
                            {
                                weight = Convert.ToDecimal(allPokeData[i].Split(new string[] { "Weight=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse Weight for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;


                            }

                            string color = null;
                            try
                            {
                                color = allPokeData[i].Split(new string[] { "Color=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Color for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("Habitat=")) { habitat = allPokeData[i].Split(new string[] { "Habitat=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Habitat for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            string kind = null;
                            try
                            {
                                kind = allPokeData[i].Split(new string[] { "Kind=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Kind for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            string dexentry = null;
                            try
                            {
                                foreach (char c in allPokeData[i].Split(new string[] { "Pokedex=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0])
                                { if (c == '�') { dexentry += "é"; } else { dexentry += c; } }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Pokedex for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("Evolutions=")) { t = allPokeData[i].Split(new string[] { "Evolutions=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',').ToList(); }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Evolutions for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("EggMoves=")) { eggmoves = allPokeData[i].Split(new string[] { "EggMoves=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',').ToList(); }
                                else if (allPokeData[i].Contains("Eggmoves=")) { eggmoves = allPokeData[i].Split(new string[] { "Eggmoves=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',').ToList(); }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read EggMoves for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }


                            try
                            {
                                if (allPokeData[i].Contains("BattlerPlayerY=")) { battlerpy = Convert.ToInt32(allPokeData[i].Split(new string[] { "BattlerPlayerY=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]); }
                                else { battlerpy = 0; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse BattlerPlayerY for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("BattlerEnemyY=")) { battlerey = Convert.ToInt32(allPokeData[i].Split(new string[] { "BattlerEnemyY=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]); }
                                else { battlerey = 0; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse BattlerEnemyY for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("BattlerAltitude=")) { battleralt = Convert.ToInt32(allPokeData[i].Split(new string[] { "BattlerAltitude=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]); }
                                else { battleralt = 0; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to parse BattlerAltitude for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("FormNames=")) { formnames = allPokeData[i].Split(new string[] { "FormNames=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read FormNames for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("RegionalNumbers=")) { dexnums = allPokeData[i].Split(new string[] { "RegionalNumbers=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read RegionalNumbers for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("WildItemCommon=")) { itemcmn = allPokeData[i].Split(new string[] { "WildItemCommon=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read WildItemCommon for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("WildItemUncommon=")) { itemuncmn = allPokeData[i].Split(new string[] { "WildItemUncommon=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read WildItemUncommon for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("WildItemRare=")) { itemrare = allPokeData[i].Split(new string[] { "WildItemRare=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read WildItemRare for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            try
                            {
                                if (allPokeData[i].Contains("Incense=")) { incense = allPokeData[i].Split(new string[] { "Incense=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]; }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Incense for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            List<string> movesetstring = new List<string>();
                            try
                            {
                                movesetstring = allPokeData[i].Split(new string[] { "Moves=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',').ToList();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Moves for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            int shape = 1;
                            try
                            {
                                if (allPokeData[i].Contains("Shape="))
                                {
                                    //shape = Convert.ToInt32(allPokeData[i].Split(new string[] { "Shape=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0]);
                                    show_shape = true;
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to read Shape for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            List<string> tmovesetmoves = new List<string>();
                            List<int> tmovesetlevels = new List<int>();
                            List<Moveset> movelist = new List<Moveset>();

                            try
                            {
                                for (int j = 0; j < movesetstring.Count; j++)
                                {
                                    if (j % 2 == 0)
                                    {
                                        tmovesetlevels.Add(Convert.ToInt32(movesetstring[j]));
                                    }
                                    else
                                    {
                                        tmovesetmoves.Add(movesetstring[j]);
                                    }
                                }

                                for (int j = 0; j < tmovesetmoves.Count; j++)
                                {
                                    movelist.Add(new Moveset(tmovesetmoves[j], tmovesetlevels[j]));
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to process Moves for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            List<Evo> evo = new List<Evo>();
                            try
                            {
                                for (int j = 0; j < t.Count - 2; j += 3) { evo.Add(new Evo(t[j], t[j + 1], t[j + 2])); }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to process Evolutions for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }

                            try
                            {
                                pokes.Add(new Poke(id, name, intname, type1, type2, hp, atk, def, spatk, spdef, speed, genderratio, growthrate, exp, evhp, evatk, evdef, evspatk, evspdef, evspeed,
                                                    catchrate, happiness, ability1, ability2, hiddenabil, movelist, eggmoves, egg1, egg2,
                                                    hatchtime, height, weight, color, habitat, kind, dexentry, evo, itemcmn, itemuncmn, itemrare,
                                                    battlerpy, battlerey, battleralt, dexnums, incense, formnames, shape));
                            }
                            catch (Exception)
                            {
                                MessageBox.Show($"Failed to create a Pokémon object for species {i}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                        catch (Exception)
                        {
                            invalidLine("pokemon", allPokeData[i], "Pokémon Editor");
                            return false;
                        }
                    }
                    pokes.Sort(delegate (Poke p1, Poke p2) { return p1.name.CompareTo(p2.name); });
                    try
                    {
                        switch (SuperGen.Properties.Settings.Default.SortMethod)
                        {
                            case "ID": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.id.CompareTo(p2.id); }); break;
                            case "Type": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.type1.CompareTo(p2.type1); }); break;
                            case "Height": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.height.CompareTo(p2.height); }); pokes.Reverse(); break;
                            case "Weight": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.weight.CompareTo(p2.weight); }); pokes.Reverse(); break;
                            case "StatTotal": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.statTotal.CompareTo(p2.statTotal); }); pokes.Reverse(); break;
                            case "StatHP": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[0].CompareTo(p2.stats[0]); }); pokes.Reverse(); break;
                            case "StatAtk": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[1].CompareTo(p2.stats[1]); }); pokes.Reverse(); break;
                            case "StatDef": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[2].CompareTo(p2.stats[2]); }); pokes.Reverse(); break;
                            case "StatSpAtk": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[3].CompareTo(p2.stats[3]); }); pokes.Reverse(); break;
                            case "StatSpDef": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[4].CompareTo(p2.stats[4]); }); pokes.Reverse(); break;
                            case "StatSpeed": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.stats[5].CompareTo(p2.stats[5]); }); pokes.Reverse(); break;
                            case "Catch Rate": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.catchrate.CompareTo(p2.catchrate); }); break;
                            case "Hatch Time": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.hatchsteps.CompareTo(p2.hatchsteps); }); pokes.Reverse(); break;
                            case "Base EXP": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.exp.CompareTo(p2.exp); }); pokes.Reverse(); break;
                            case "Desc": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.dexentry.CompareTo(p2.dexentry); }); break;
                            case "Moveset": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.moveset.Count.CompareTo(p2.moveset.Count); }); pokes.Reverse(); break;
                            case "Eggmoves": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.eggmoves.Count.CompareTo(p2.eggmoves.Count); }); pokes.Reverse(); break;
                            case "Evolutions": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.evolutions.Count.CompareTo(p2.evolutions.Count); }); pokes.Reverse(); break;
                            case "Shape": pokes.Sort(delegate (Poke p1, Poke p2) { return p1.shape.CompareTo(p2.shape); }); pokes.Reverse(); break;
                            default: pokes.Sort(delegate (Poke p1, Poke p2) { return p1.name.CompareTo(p2.name); }); break;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show($"Failed to sort Pokémon list.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("Something went wrong while loading \"pokemon.txt\".\r\nMake sure the app is installed correctly\r\nAnd the data inside the file is valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception)
            {
                fileNotFound("pokemon", "Pokémon Editor");
                return false;
            }
            return true;
        }


        public List<Move> loadMovesInstance()
        {
            List<Move> moves = new List<Move>();
            if (File.Exists(root(@"PBS\moves.txt")))
            {
                try
                {
                    StreamReader sr = new StreamReader(File.OpenRead(root(@"PBS\moves.txt")));
                    string dat = sr.ReadToEnd();
                    sr.Close();
                    if (string.IsNullOrEmpty(dat))
                    {
                        emptyFile("Move Editor", "moves");
                        return moves;
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
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong while converting data from \"moves.txt\".");
                }
            }
            else
            {
                fileNotFound("moves", "Move Editor");
            }
            return moves;
        }

        public List<Item> loadItemsInstance()
        {
            List<Item> items = new List<Item>();
            if (File.Exists(root(@"PBS\items.txt")))
            {
                try
                {
                    StreamReader sr = new StreamReader(File.OpenRead(root(@"PBS\items.txt")));
                    string dat = sr.ReadToEnd();
                    sr.Close();
                    if (string.IsNullOrEmpty(dat))
                    {
                        emptyFile("Item Editor", "items");
                        return items;
                    }
                    List<string> data = new List<string>();
                    data = dat.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    for (int i = 0; i < data.Count; i++)
                    {
                        try
                        {
                            if (!isUsable(data[i])) { continue; }
                            List<string> sort = new List<string>();
                            sort = data[i].Split(',').ToList();
                            string id = sort[0];
                            string intname = sort[1];
                            string name = sort[2];
                            string plural = sort[3];
                            string pocket = sort[4];
                            string price = sort[5];
                            string description = null;
                            string usabilityField = null;
                            string usabilityBattle = null;
                            string specialItem = null;
                            string tmMove = null;

                            try
                            {
                                Convert.ToInt32(sort[sort.Count - 1]);
                                // Set if there's not a comma
                                for (int j = 6; j < sort.Count - 3; j++)
                                {
                                    if (j != 6) { description += ","; }
                                    description += sort[j];
                                }
                                if (string.IsNullOrEmpty(description))
                                {
                                    description = null;
                                    for (int j = 6; j < sort.Count - 3; j++)
                                    {
                                        if (j != 6) { description += ","; }
                                        description += sort[j];
                                    }
                                }
                                usabilityField = sort[sort.Count - 3];
                                usabilityBattle = sort[sort.Count - 2];
                                specialItem = sort[sort.Count - 1];
                            }
                            catch (Exception)
                            {
                                // Set if there is a comma
                                for (int j = 6; j < sort.Count - 4; j++)
                                {
                                    if (j != 6) { description += ","; }
                                    description += sort[j];
                                }
                                if (string.IsNullOrEmpty(description))
                                {
                                    description = null;
                                    for (int j = 6; j < sort.Count - 3; j++)
                                    {
                                        if (j != 6) { description += ","; }
                                        description += sort[j];
                                    }
                                }
                                usabilityField = sort[sort.Count - 4];
                                usabilityBattle = sort[sort.Count - 3];
                                specialItem = sort[sort.Count - 2];
                                tmMove = sort[sort.Count - 1];
                            }

                            List<char> desc = new List<char>();
                            desc = description.ToCharArray().ToList();
                            string ret = null;
                            for (int j = 0; j < desc.Count; j++)
                            {
                                if (j == 0 && desc[j] == '"') { continue; }
                                if (j == desc.Count - 1 && desc[j] == '"' && desc[j - 1] != '\\') { continue; }
                                if (desc[j] == '�') { ret += "é"; }
                                else { ret += desc[j]; }
                            }
                            items.Add(new Item(Convert.ToInt32(id), intname, name, plural, Convert.ToInt32(pocket), Convert.ToInt32(price), ret, Convert.ToInt32(usabilityField), Convert.ToInt32(usabilityBattle), Convert.ToInt32(specialItem), tmMove));
                        }
                        catch (Exception)
                        {
                            invalidLine("items", data[i], "Item Editor");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Item Editor: Something went wrong whilst convertering data inside of \"items.txt\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                fileNotFound("items", "Item Editor");
            }
            return items;
        }

        public List<Typing> loadTypesInstance()
        {
            List<Typing> types = new List<Typing>();
            try
            {
                StreamReader read = new StreamReader(root(@"PBS\types.txt"));
                string dat = read.ReadToEnd();
                read.Close();
                if (string.IsNullOrEmpty(dat))
                {
                    emptyFile("Types Editor", "types");
                    return types;
                }
                string data = dat;
                if (!string.IsNullOrEmpty(data))
                {
                    List<string> allTypeData = new List<string>();
                    data = data.Replace(" = ", "=");
                    allTypeData = data.Split('[').ToList();
                    allTypeData.RemoveAt(0);
                    for (int i = 0; i < allTypeData.Count; i++)
                    {
                        try
                        {
                            if (!allTypeData[i].StartsWith("#"))
                            {
                                int id = Convert.ToInt32(allTypeData[i].Split(']')[0]);
                                string name = allTypeData[i].Split(new string[] { "Name=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                                string intname = allTypeData[i].Split(new string[] { "InternalName=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0];
                                bool special = false;
                                bool pseudo = false;
                                List<string> weaknesses = new List<string>();
                                List<string> resistances = new List<string>();
                                List<string> immunities = new List<string>();
                                List<string> supereffectives = new List<string>();
                                if (allTypeData[i].Contains("Weaknesses=")) { weaknesses = allTypeData[i].Split(new string[] { "Weaknesses=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',').ToList(); }
                                if (allTypeData[i].Contains("Resistances=")) { resistances = allTypeData[i].Split(new string[] { "Resistances=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',').ToList(); }
                                if (allTypeData[i].Contains("Immunities=")) { immunities = allTypeData[i].Split(new string[] { "Immunities=" }, StringSplitOptions.None)[1].Split(new string[] { "\r\n" }, StringSplitOptions.None)[0].Split(',').ToList(); }
                                if (allTypeData[i].Contains("IsSpecialType=")) { special = true; }
                                if (allTypeData[i].Contains("IsPseudoType=")) { pseudo = true; }
                                types.Add(new Typing(id, name, intname, weaknesses, resistances, immunities, supereffectives, special, pseudo));
                            }
                        }
                        catch (Exception)
                        {
                            invalidLine("types", allTypeData[i], "Type Editor");
                            return types;
                        }
                    }

                    for (int i = 0; i < types.Count; i++)
                    {
                        for (int j = 0; j < types.Count; j++)
                        {
                            if (types[j].weaknesses.Contains(types[i].intname))
                            {
                                types[i].supereffectives.Add(types[j].intname);
                            }
                        }
                    }
                    types.Sort(delegate (Typing t1, Typing t2) { return t1.id.CompareTo(t2.id); });
                }
                else
                {
                    MessageBox.Show("\"types.txt\" cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                fileNotFound("types", "Type Editor");
            }
            return types;
        }

        public List<lib.Class> loadTrainertypesInstance()
        {
            List<lib.Class> classes = new List<Class>();
            if (File.Exists(root(@"PBS\trainertypes.txt")))
            {
                try
                {
                    StreamReader sr = new StreamReader(File.OpenRead(root(@"PBS\trainertypes.txt")));
                    string dat = sr.ReadToEnd();
                    sr.Close();
                    if (string.IsNullOrEmpty(dat))
                    {
                        emptyFile("Trainer Class Editor", "trainertypes");
                        return classes;
                    }
                    List<string> entries = dat.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                    for (int i = 0; i < entries.Count; i++)
                    {
                        try
                        {
                            if (!entries[i].StartsWith("#") && !entries[i].StartsWith(" ") && !entries[i].StartsWith("\r\n") && entries[i].Length > 0)
                            {
                                bool cont = true;
                                List<string> line = entries[i].Split(',').ToList();
                                int id = Convert.ToInt32(line[0]);
                                string name = line[2];
                                string intname = line[1];
                                int? money = null;
                                string bgmusic = null;
                                string victorymusic = null;
                                string intromusic = null;
                                string gender = null;
                                int? skill = null;
                                try { money = Convert.ToInt32(line[3]); }
                                catch (Exception)
                                {
                                    money = null;
                                    bgmusic = null;
                                    victorymusic = null;
                                    intromusic = null;
                                    gender = null;
                                    skill = null;
                                    cont = false;
                                }
                                if (cont)
                                {
                                    try { bgmusic = line[4]; }
                                    catch (Exception)
                                    {
                                        bgmusic = null;
                                        victorymusic = null;
                                        intromusic = null;
                                        gender = null;
                                        skill = null;
                                        cont = false;
                                    }
                                }
                                if (cont)
                                {
                                    try { victorymusic = line[5]; }
                                    catch (Exception)
                                    {
                                        victorymusic = null;
                                        intromusic = null;
                                        gender = null;
                                        skill = null;
                                        cont = false;
                                    }
                                }
                                if (cont)
                                {
                                    try { intromusic = line[6]; }
                                    catch (Exception)
                                    {
                                        intromusic = null;
                                        gender = null;
                                        skill = null;
                                        cont = false;
                                    }
                                }
                                if (cont)
                                {
                                    try { gender = line[7]; }
                                    catch (Exception)
                                    {
                                        gender = null;
                                        skill = null;
                                        cont = false;
                                    }
                                }
                                if (cont)
                                {
                                    try { skill = Convert.ToInt32(line[8]); }
                                    catch (Exception)
                                    {
                                        skill = null;
                                        cont = false;
                                    }
                                }
                                classes.Add(new Class(id, name, intname, money, bgmusic, victorymusic, intromusic, gender, skill));
                            }
                        }
                        catch (Exception)
                        {
                            invalidLine("trainertypes", entries[i], "Trainer Class Editor");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong while converting data inside \"trainertypes.txt\".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                fileNotFound("trainertypes", "Trainer Class Editor");
            }
            return classes;
        }

        #endregion

        #region Graphics
        public Image loadPokemonFootprintImage(Poke poke)
        {
            var path = $@"Graphics\Pokemon\Footprints\{poke.name}.png";
            if (File.Exists(path))
            {
                Image im;
                using (var img = new Bitmap(path)) { im = new Bitmap(img); }
                return im;
            }
            return null;
        }
        #endregion

        #region Function
        public static void exportFile(string file, string txt)
        {
            var Exported = PEGame.Instance.root("Exported");
            var ExportedFile = PEGame.Instance.root($@"Exported\{file}");
            if (!Directory.Exists(Exported)) { Directory.CreateDirectory(Exported); }
            if (File.Exists(ExportedFile)) { File.Delete(ExportedFile); }
            StreamWriter sw = new StreamWriter(ExportedFile);
            sw.Write(txt);
            sw.Close();
        }
        public static void pbsFile(string file, string txt)
        {
            var backups = PEGame.Instance.root("Backups");
            var pbsFile = PEGame.Instance.root($@"PBS\{file}");
            var backupsFile = PEGame.Instance.root($@"Backups\{file}");

            if (!Directory.Exists(backups)) { Directory.CreateDirectory(backups); }
            if (File.Exists(backupsFile)) { File.Delete(backupsFile); }
            File.Move(pbsFile, backupsFile);
            StreamWriter sw = new StreamWriter(pbsFile);
            sw.Write(txt);
            sw.Close();
        }

        public static bool isUsable(string data)
        {
            return (!data.StartsWith("#") && !data.StartsWith("\r\n") && !data.StartsWith(" ") && data.Length > 0);
        }
        public static void emptyFile(string editor, string file)
        {
            MessageBox.Show($"{editor}: \"{file}.txt\" is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void invalidLine(string file, string invalidLine, string editor)
        {
            MessageBox.Show($"{editor}: Something went wrong whilst loading \"{file}.txt\". This line appears to be invalid:\r\n{invalidLine}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void fileNotFound(string file, string editor)
        {
            MessageBox.Show($"{editor}: \"{file}.txt\" couldn't be found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

    }
}
