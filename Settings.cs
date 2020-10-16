using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonFightAI
{
    

    public partial class MainForm : Form
    {
        string protector;
        bool onSwitch = false;

        public MainForm()
        {
            InitializeComponent();
            DataStorage.BuildType();
            DataStorage.BuildStatus();
            DataStorage.BuildAttack();
            DataStorage.BuildPokemon();
            pokeselect.Items.AddRange(DataStorage.pokemons.GetRange(1, 26).ToArray());
            pokeselectCPU.Items.AddRange(DataStorage.pokemons.GetRange(1, 26).ToArray());
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void switchPokemonDataUser()
        {
            onSwitch = true;
            detail.Visible = true;
            pokepic.Image = Initializer.pokemonUser[Initializer.userPokemonIndex].p.frontSprite;
            move1select.Enabled = true; move2select.Enabled = true; move3select.Enabled = true; move4select.Enabled = true;
            levelval.Enabled = true; levelval.Text = (Initializer.pokemonUser[Initializer.userPokemonIndex].level).ToString();
            move1select.Items.Clear();
            move2select.Items.Clear();
            move3select.Items.Clear();
            move4select.Items.Clear();
            move1select.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonUser[Initializer.userPokemonIndex]));
            move2select.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonUser[Initializer.userPokemonIndex]));
            move3select.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonUser[Initializer.userPokemonIndex]));
            move4select.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonUser[Initializer.userPokemonIndex]));
            try { move1select.Text = Initializer.pokemonUser[Initializer.userPokemonIndex].chosenAttacks[0].a.ToString(); } catch (NullReferenceException) { move1select.Text = ""; }
            try { move2select.Text = Initializer.pokemonUser[Initializer.userPokemonIndex].chosenAttacks[1].a.ToString(); } catch (NullReferenceException) { move2select.Text = ""; }
            try { move3select.Text = Initializer.pokemonUser[Initializer.userPokemonIndex].chosenAttacks[2].a.ToString(); } catch (NullReferenceException) { move3select.Text = ""; }
            try { move4select.Text = Initializer.pokemonUser[Initializer.userPokemonIndex].chosenAttacks[3].a.ToString(); } catch (NullReferenceException) { move4select.Text = ""; }
            type1.Image = Initializer.pokemonUser[Initializer.userPokemonIndex].p.type1.img;
            try { type2.Image = Initializer.pokemonUser[Initializer.userPokemonIndex].p.type2.img; } catch (NullReferenceException) { type2.Image = null; type2.Text = ""; }
            onSwitch = false;
        }

        private void switchPokemonDataOpp()
        {
            onSwitch = true;
            detailCPU.Visible = true;
            pokepicCPU.Image = Initializer.pokemonOpp[Initializer.oppPokemonIndex].p.frontSprite;
            move1selectCPU.Enabled = true; move2selectCPU.Enabled = true; move3selectCPU.Enabled = true; move4selectCPU.Enabled = true;
            levelvalCPU.Enabled = true; levelvalCPU.Text = (Initializer.pokemonOpp[Initializer.oppPokemonIndex].level).ToString();
            move1selectCPU.Items.Clear();
            move2selectCPU.Items.Clear();
            move3selectCPU.Items.Clear();
            move4selectCPU.Items.Clear();
            move1selectCPU.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonOpp[Initializer.oppPokemonIndex]));
            move2selectCPU.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonOpp[Initializer.oppPokemonIndex]));
            move3selectCPU.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonOpp[Initializer.oppPokemonIndex]));
            move4selectCPU.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonOpp[Initializer.oppPokemonIndex]));
            try { move1selectCPU.Text = Initializer.pokemonOpp[Initializer.oppPokemonIndex].chosenAttacks[0].a.ToString(); } catch (NullReferenceException) { move1selectCPU.Text = ""; }
            try { move2selectCPU.Text = Initializer.pokemonOpp[Initializer.oppPokemonIndex].chosenAttacks[1].a.ToString(); } catch (NullReferenceException) { move2selectCPU.Text = ""; }
            try { move3selectCPU.Text = Initializer.pokemonOpp[Initializer.oppPokemonIndex].chosenAttacks[2].a.ToString(); } catch (NullReferenceException) { move3selectCPU.Text = ""; }
            try { move4selectCPU.Text = Initializer.pokemonOpp[Initializer.oppPokemonIndex].chosenAttacks[3].a.ToString(); } catch (NullReferenceException) { move4selectCPU.Text = ""; }
            type1CPU.Image = Initializer.pokemonOpp[Initializer.oppPokemonIndex].p.type1.img;
            try { type2CPU.Image = Initializer.pokemonOpp[Initializer.oppPokemonIndex].p.type2.img; } catch (NullReferenceException) { type2CPU.Image = null; type2CPU.Text = ""; }
            onSwitch = false;
        }

        private void pokeselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!onSwitch) { 
                Initializer.pokemonUser[Initializer.userPokemonIndex] = new PokeInstance(DataStorage.pokemons[pokeselect.SelectedIndex + 1], 1);
                switchPokemonDataUser();
            }
        }

        internal static class Initializer
        {
            internal static bool manuality = true;
            internal static PokeInstance[] pokemonUser = new PokeInstance[6];
            internal static PokeInstance[] pokemonOpp = new PokeInstance[6];
            internal static int pokemonCount = 1;
            internal static int userPokemonIndex = 0;
            internal static int oppPokemonIndex = 0;

            internal static Attack[] DetectAvailableMoves(PokeInstance pi)
            {
                List<Attack> a = new List<Attack>();
                foreach (Tuple<Attack, int> ap in pi.p.possibleAttacks)
                {
                    if (pi.level >= ap.Item2)
                        a.Add(ap.Item1);
                }
                return a.ToArray();
            }
        }



        private void pokepicCPU_Click(object sender, EventArgs e)
        {

        }

        private void mode_Enter(object sender, EventArgs e)
        {

        }

        private void pokeselectCPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!onSwitch)
            {
                Initializer.pokemonOpp[Initializer.oppPokemonIndex] = new PokeInstance(DataStorage.pokemons[pokeselectCPU.SelectedIndex + 1], 1);
                switchPokemonDataOpp();
            }
        }

        private void randomizer_CheckedChanged(object sender, EventArgs e)
        {
            warning.Visible = true;
            Initializer.manuality = false;
        }

        private void levelval_TextChanged(object sender, EventArgs e)
        {
            if(!onSwitch) { 
                Initializer.pokemonUser[Initializer.userPokemonIndex].level = Int32.Parse(levelval.Text);
                Initializer.pokemonUser[Initializer.userPokemonIndex].initPokemon();
                move1select.Items.Clear();
                move2select.Items.Clear();
                move3select.Items.Clear();
                move4select.Items.Clear();
                move1select.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonUser[Initializer.userPokemonIndex]));
                move2select.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonUser[Initializer.userPokemonIndex]));
                move3select.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonUser[Initializer.userPokemonIndex]));
                move4select.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonUser[Initializer.userPokemonIndex]));
            }
        }

        private void levelvalCPU_TextChanged(object sender, EventArgs e)
        {
            if(!onSwitch) { 
                Initializer.pokemonOpp[Initializer.oppPokemonIndex].level = Int32.Parse(levelvalCPU.Text);
                Initializer.pokemonOpp[Initializer.oppPokemonIndex].initPokemon();
                move1selectCPU.Items.Clear();
                move2selectCPU.Items.Clear();
                move3selectCPU.Items.Clear();
                move4selectCPU.Items.Clear();
                move1selectCPU.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonOpp[Initializer.oppPokemonIndex]));
                move2selectCPU.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonOpp[Initializer.oppPokemonIndex]));
                move3selectCPU.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonOpp[Initializer.oppPokemonIndex]));
                move4selectCPU.Items.AddRange(Initializer.DetectAvailableMoves(Initializer.pokemonOpp[Initializer.oppPokemonIndex]));
            }
        }

        private void move1select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!onSwitch)
                Initializer.pokemonUser[Initializer.userPokemonIndex].chosenAttacks[0] = new PokeInstance.CAttack((Attack)move1select.SelectedItem);
        }

        private void pkmnCnt_TextChanged(object sender, EventArgs e)
        {
            try {
                Initializer.pokemonCount = Int32.Parse(pkmnCnt.Text);
                if(Initializer.pokemonCount > 1)
                {
                    rightCPU.Enabled = true;
                    right.Enabled = true;
                }
            } catch (FormatException)
            {
                MessageBox.Show("Invalid input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pkmnCnt.Text = protector;
            }
        }

        private void pkmnCnt_Click(object sender, EventArgs e)
        {
            protector = pkmnCnt.Text;
        }

        private void move2select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!onSwitch)
                Initializer.pokemonUser[Initializer.userPokemonIndex].chosenAttacks[1] = new PokeInstance.CAttack((Attack)move2select.SelectedItem);
        }

        private void move3select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!onSwitch)
                Initializer.pokemonUser[Initializer.userPokemonIndex].chosenAttacks[2] = new PokeInstance.CAttack((Attack)move3select.SelectedItem);
        }

        private void move4select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!onSwitch)
                Initializer.pokemonUser[Initializer.userPokemonIndex].chosenAttacks[3] = new PokeInstance.CAttack((Attack)move4select.SelectedItem);
        }

        private void move1selectCPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!onSwitch)
                Initializer.pokemonOpp[Initializer.oppPokemonIndex].chosenAttacks[0] = new PokeInstance.CAttack((Attack)move1selectCPU.SelectedItem);
        }

        private void move2selectCPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!onSwitch)
                Initializer.pokemonOpp[Initializer.oppPokemonIndex].chosenAttacks[1] = new PokeInstance.CAttack((Attack)move2selectCPU.SelectedItem);
        }

        private void frame_Enter(object sender, EventArgs e)
        {

        }

        private void move3selectCPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!onSwitch)
                Initializer.pokemonOpp[Initializer.oppPokemonIndex].chosenAttacks[2] = new PokeInstance.CAttack((Attack)move3selectCPU.SelectedItem);
        }

        private void move4selectCPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!onSwitch)
                Initializer.pokemonOpp[Initializer.oppPokemonIndex].chosenAttacks[3] = new PokeInstance.CAttack((Attack)move4selectCPU.SelectedItem);
        }

        private void manual_CheckedChanged(object sender, EventArgs e)
        {
            warning.Visible = false;
            Initializer.manuality = true;
        }

        private void execute_Click(object sender, EventArgs e)
        {
            if(Initializer.pokemonOpp[0] == null && Initializer.pokemonUser[0] == null && Initializer.manuality) { 
                MessageBox.Show("The POKéMON data is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                PokeInstance[] tmp1 = new PokeInstance[Initializer.pokemonCount];
                PokeInstance[] tmp2 = new PokeInstance[Initializer.pokemonCount];
                for(int i = 0; i < Initializer.pokemonCount; i++) {
                    tmp1[i] = Initializer.pokemonUser[i];
                    tmp2[i] = Initializer.pokemonOpp[i];
                    BattleMechanics.player = DataStorage.BuildTrainer(tmp1);
                    BattleMechanics.CPU    = DataStorage.BuildTrainer(tmp2);
                    BattleMechanics.player.name = "PLAYER";
                    BattleMechanics.CPU.name = "AI";
                    BattleMechanics.CPU.rival = BattleMechanics.player;
                    BattleMechanics.player.rival = BattleMechanics.CPU;
                    BattleMechanics.CPU.aicontrol = new AIControl();
                }
                BattleMechanics.pokeCount = Initializer.pokemonCount;
                BattleMechanics.form = new BattleScene();
                Hide();
                BattleMechanics.form.Show();
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            onSwitch = true;
            Initializer.userPokemonIndex++;

            if (Initializer.pokemonUser[Initializer.userPokemonIndex] != null)
            {
                pokeselect.Text = Initializer.pokemonUser[Initializer.userPokemonIndex].p.ToString();
                switchPokemonDataUser();
            }
            else
            {

                pokeselect.SelectedIndex = -1;
                pokepic.Image = null;
                move1select.Text = "";
                move2select.Text = "";
                move3select.Text = "";
                move4select.Text = "";
                move1select.Enabled = false;
                move2select.Enabled = false;
                move3select.Enabled = false;
                move4select.Enabled = false;
                levelval.Text = "";
                type1.Image = null; type2.Image = null;
                levelval.Enabled = false;
                detail.Visible = false;
            }
            index.Text = (Int32.Parse(index.Text) + 1).ToString();
            left.Enabled = true;
            if (Initializer.userPokemonIndex == Initializer.pokemonCount - 1) right.Enabled = false;
            onSwitch = false;
        }

        private void left_Click(object sender, EventArgs e)
        {
            onSwitch = true;
            Initializer.userPokemonIndex--;

            if (Initializer.pokemonUser[Initializer.userPokemonIndex] != null)
            {
                pokeselect.Text = Initializer.pokemonUser[Initializer.userPokemonIndex].p.ToString();
                switchPokemonDataUser();
            }
            else
            {
                pokeselect.SelectedIndex = -1;
                pokepic.Image = null;
                move1select.Text = "";
                move2select.Text = "";
                move3select.Text = "";
                move4select.Text = "";
                move1select.Enabled = false;
                move2select.Enabled = false;
                move3select.Enabled = false;
                move4select.Enabled = false;
                levelval.Text = "";
                type1.Image = null; type2.Image = null;
                levelval.Enabled = false;
                detail.Visible = false;
            }

            index.Text = (Int32.Parse(index.Text) - 1).ToString();
            right.Enabled = true;
            if (Initializer.userPokemonIndex == 0) left.Enabled = false;
            onSwitch = false;
        }

        private void rightCPU_Click(object sender, EventArgs e)
        {
            onSwitch = true;
            Initializer.oppPokemonIndex++;

            if (Initializer.pokemonOpp[Initializer.oppPokemonIndex] != null)
            {
                pokeselectCPU.Text = Initializer.pokemonOpp[Initializer.oppPokemonIndex].p.ToString();
                switchPokemonDataOpp();
            }
            else
            {
                pokeselectCPU.SelectedIndex = -1;
                pokepicCPU.Image = null;
                move1selectCPU.Text = "";
                move2selectCPU.Text = "";
                move3selectCPU.Text = "";
                move4selectCPU.Text = "";
                move1selectCPU.Enabled = false;
                move2selectCPU.Enabled = false;
                move3selectCPU.Enabled = false;
                move4selectCPU.Enabled = false;
                levelvalCPU.Text = "";
                type1CPU.Image = null; type2CPU.Image = null;
                levelvalCPU.Enabled = false;
                detailCPU.Visible = false;
            }

            indexCPU.Text = (Int32.Parse(indexCPU.Text) + 1).ToString();
            leftCPU.Enabled = true;
            if (Initializer.oppPokemonIndex == Initializer.pokemonCount - 1) rightCPU.Enabled = false;
            onSwitch = false;
        }

        private void leftCPU_Click(object sender, EventArgs e)
        {
            onSwitch = true;
            Initializer.oppPokemonIndex--;

            if (Initializer.pokemonOpp[Initializer.oppPokemonIndex] != null)
            {
                pokeselectCPU.Text = Initializer.pokemonOpp[Initializer.oppPokemonIndex].p.ToString();
                switchPokemonDataOpp();
            }
            else
            {
                pokeselectCPU.SelectedIndex = -1;
                pokepicCPU.Image = null;
                move1selectCPU.Text = "";
                move2selectCPU.Text = "";
                move3selectCPU.Text = "";
                move4selectCPU.Text = "";
                move1selectCPU.Enabled = false;
                move2selectCPU.Enabled = false;
                move3selectCPU.Enabled = false;
                move4selectCPU.Enabled = false;
                levelvalCPU.Text = "";
                type1CPU.Image = null; type2CPU.Image = null;
                levelvalCPU.Enabled = false;
                detailCPU.Visible = false;
            }

            indexCPU.Text = (Int32.Parse(indexCPU.Text) - 1).ToString();
            rightCPU.Enabled = true;
            if (Initializer.oppPokemonIndex == 0) leftCPU.Enabled = false;
            onSwitch = false;
        }

        private void pokepic_Click(object sender, EventArgs e)
        {

        }

        private void index_TextChanged(object sender, EventArgs e)
        {

        }

        private void detail_Click(object sender, EventArgs e)
        {
            int hp      = Initializer.pokemonUser[Initializer.userPokemonIndex].cHP;
            int atk     = Initializer.pokemonUser[Initializer.userPokemonIndex].cAttack;
            int def     = Initializer.pokemonUser[Initializer.userPokemonIndex].cDefense;
            int spatk   = Initializer.pokemonUser[Initializer.userPokemonIndex].cSpAtk;
            int spdef   = Initializer.pokemonUser[Initializer.userPokemonIndex].cSpDef;
            int speed   = Initializer.pokemonUser[Initializer.userPokemonIndex].cSpeed;
            MessageBox.Show("HP: " + hp + "\nAttack: " + atk + "\nDefense: " + def + "\nSpecial Attack: " + spatk + "\nSpecial Defense: " + spdef + "\nSpeed: " + speed, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void detailCPU_Click(object sender, EventArgs e)
        {
            int hp = Initializer.pokemonOpp[Initializer.oppPokemonIndex].cHP;
            int atk = Initializer.pokemonOpp[Initializer.oppPokemonIndex].cAttack;
            int def = Initializer.pokemonOpp[Initializer.oppPokemonIndex].cDefense;
            int spatk = Initializer.pokemonOpp[Initializer.oppPokemonIndex].cSpAtk;
            int spdef = Initializer.pokemonOpp[Initializer.oppPokemonIndex].cSpDef;
            int speed = Initializer.pokemonOpp[Initializer.oppPokemonIndex].cSpeed;
            MessageBox.Show("HP: " + hp + "\nAttack: " + atk + "\nDefense: " + def + "\nSpecial Attack: " + spatk + "\nSpecial Defense: " + spdef + "\nSpeed: " + speed, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void type2_Click(object sender, EventArgs e)
        {

        }
    }
}
