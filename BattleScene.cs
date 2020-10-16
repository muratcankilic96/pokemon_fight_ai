using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace PokemonFightAI
{


    public partial class BattleScene : Form
    {
        SoundPlayer battleTheme, loop, victory;

        public BattleScene()
        {
            InitializeComponent();
            console.Text = "";
            battleTheme = new SoundPlayer(Properties.Resources.BattleIntro);
            loop = new SoundPlayer(Properties.Resources.BattleLoop);
            //victory = new SoundPlayer(Properties.Resources.BattleVictory);
            actionFrame.Visible = false;
            movesFrame.Visible = false;
            BattleMechanics.differentationControl = new Thread(new ThreadStart(differentiate));
        }

        private void battleFrame_Enter(object sender, EventArgs e)
        {

        }

        public void FaintAnimation(bool player)
        {
            PictureBox p = null;
            if(player)
            {
                p = pokeicon1;
            }
            else
            {
                p = pokeicon2;
            }

            for (int i = 0; i < 8; i++)
            {
                ActiveForm.Invoke(new Action(() => p.Visible = false));
                Thread.Sleep(250);
                ActiveForm.Invoke(new Action(() => p.Visible = true));
                Thread.Sleep(250);
            }
            ActiveForm.Invoke(new Action(() => p.Image = null));
            Thread.Sleep(1000);
        }

        private void BattleScene_Load(object sender, EventArgs e)
        {
            BattleMechanics.masterControl = new Thread(new ThreadStart(MasterControl));
            BattleMechanics.masterControl.Start();
        }

        private void RefreshMovesFrame()
        {
            move0.Invoke(new Action(() => move0.Text = BattleMechanics.player.active.chosenAttacks[0].a.name));
            if(BattleMechanics.player.active.chosenAttacks[1] != null)
                ActiveForm.Invoke(new Action(() => move1.Text = BattleMechanics.player.active.chosenAttacks[1].a.name)); 
            else
                ActiveForm.Invoke(new Action(() => move1.Text = "-"));
            if (BattleMechanics.player.active.chosenAttacks[2] != null)
                ActiveForm.Invoke(new Action(() => move2.Text = BattleMechanics.player.active.chosenAttacks[2].a.name));
            else
                ActiveForm.Invoke(new Action(() => move2.Text = "-"));
            if (BattleMechanics.player.active.chosenAttacks[3] != null)
                ActiveForm.Invoke(new Action(() => move3.Text = BattleMechanics.player.active.chosenAttacks[3].a.name));
            else
                ActiveForm.Invoke(new Action(() => move3.Text = "-"));
        }

        private void GiveControlToPlayer()
        {
            console.Invoke(new Action(() => console.Visible = false));
            RefreshMovesFrame();
            actionFrame.Invoke(new Action(() => actionFrame.Visible = true));
            movesFrame.Invoke (new Action(() => movesFrame.Visible = true));
            BattleMechanics.onPlayerControl = true;
        }

        private void TakeControlFromPlayer()
        {
            console.Visible = true;
            ppFrame.Visible = false;
            actionFrame.Invoke(new Action(() => actionFrame.Visible = false));
            movesFrame.Invoke(new Action(() => movesFrame.Visible = false));
            BattleMechanics.onPlayerControl = false;
        }

        public void differentiate()
        {
            int hpdiff = Int32.Parse(hpval.Text);
            int barcalc = (int)((((float)BattleMechanics.CPU.active.remHP / BattleMechanics.CPU.active.cHP) * 100));
            int cpuhpdiff = hpbarCPU.Value;
            if (hpdiff != BattleMechanics.player.active.remHP)
            {
                while(hpdiff != BattleMechanics.player.active.remHP)
                {
                    if (hpdiff < BattleMechanics.player.active.remHP) hpdiff++; else hpdiff--;
                    ActiveForm.Invoke(new Action(() => hpbar.Value = (int)(((float)hpdiff / BattleMechanics.player.active.cHP) * 100)));
                    ActiveForm.Invoke(new Action(() => hpval.Text = hpdiff.ToString()));
                    Thread.Sleep(25);
                }
            }
            if (cpuhpdiff != (int) ((float)BattleMechanics.CPU.active.remHP / BattleMechanics.CPU.active.cHP))
            {
                while (cpuhpdiff != barcalc)
                {
                    if (cpuhpdiff < barcalc) cpuhpdiff++; else cpuhpdiff--;
                    ActiveForm.Invoke(new Action(() => hpbarCPU.Value = cpuhpdiff));
                    Thread.Sleep(25);
                }
            }
        }

        private void MasterControl()
        {

            BattleMechanics.initializationControl = new Thread(new ThreadStart(EnterBattle_Flashes));
            BattleMechanics.pokeIconControl = new Thread(new ThreadStart(EnterBattle_TrainersCome));
            BattleMechanics.initializationControl.Start();
            BattleMechanics.pokeIconControl.Start();
            BattleMechanics.initializationControl.Join();
            BattleMechanics.pokeIconControl.Join();
            Write("AN AI WANTS TO BATTLE!");
            BattleMechanics.player.active = BattleMechanics.player.owned[0];
            BattleMechanics.CPU.active = BattleMechanics.CPU.owned[0];
            WriteAuto("PLAYER SENDS " + BattleMechanics.player.active.p.name + "!");
            pokeicon1.Image = BattleMechanics.player.active.p.backSprite;
            Thread.Sleep(1000);
            WriteAuto("ENEMY SENDS " + BattleMechanics.CPU.active.p.name + "!");
            pokeicon2.Image = BattleMechanics.CPU.active.p.frontSprite;
            Thread.Sleep(1000);
            ActiveForm.Invoke(new Action(() => pokepic_placeholder.Enabled = false));
            while(true) { 
                GiveControlToPlayer();
                BattleMechanics.pokeIconControl = new Thread(new ThreadStart(ShakePokemonIcons));
                BattleMechanics.pokeIconControl.Start();
                while (BattleMechanics.onPlayerControl) { /* Wait */ }
                BattleMechanics.CPU.aicontrol.Think();
                BattleMechanics.ExecuteByInitiative();
                while (!BattleMechanics.CPU.playedTheirTurn || !BattleMechanics.player.playedTheirTurn)
                {
                    // Nothing.
                }
                BattleMechanics.CPU.playedTheirTurn = false;
                BattleMechanics.player.playedTheirTurn = false;
                BattleMechanics.onMoveMenu = false;
                ActiveForm.Invoke(new Action(() => sideArrow.Visible = false));
                ActiveForm.Invoke(new Action(() => mainArrow.Visible = true));
            }
        }

        private void ShakePokemonIcons()
        {
            while(BattleMechanics.onPlayerControl) {
                pokeicon1.Invoke(new Action(() => pokeicon1.Location = new Point(pokeicon1.Location.X, pokeicon1.Location.Y - 10)));
                pokeicon2.Invoke(new Action(() => pokeicon2.Location = new Point(pokeicon2.Location.X, pokeicon2.Location.Y - 10)));
                Thread.Sleep(250);
                pokeicon1.Invoke(new Action(() => pokeicon1.Location = new Point(pokeicon1.Location.X, pokeicon1.Location.Y + 10)));
                pokeicon2.Invoke(new Action(() => pokeicon2.Location = new Point(pokeicon2.Location.X, pokeicon2.Location.Y + 10)));
                Thread.Sleep(250);
            }
        }

        public void Write(string s)
        {
            BattleMechanics.consoleControl = new Thread(() => BattleMechanics.WriteConsole(console, s, true));
            BattleMechanics.consoleControl.Start();
            BattleMechanics.consoleControl.Join();
        }

        public void WriteAuto(string s)
        {
            BattleMechanics.consoleControl = new Thread(() => BattleMechanics.WriteConsole(console, s, false));
            BattleMechanics.consoleControl.Start();
            BattleMechanics.consoleControl.Join();
        }

        public void EnterBattle_Flashes()
        {
            battleTheme.Play();
            for(int i = 0; i < 8; i++) {
                BackColor = Color.Black;
                Thread.Sleep(33);
                BackColor = Color.DarkGray;
                Thread.Sleep(33);
                BackColor = Color.LightGray;
                Thread.Sleep(33);
                BackColor = Color.White;
                Thread.Sleep(33);
                BackColor = Color.LightGray;
                Thread.Sleep(33);
                BackColor = Color.DarkGray;
                Thread.Sleep(33);
            }
            BackColor = Color.White;
            Thread.Sleep(1555);
            loop.PlayLooping();
        }

        public void EnterBattle_TrainersCome()
        {

            pokeicon1.Invoke(new Action(() => pokeicon1.Location = new Point(pokeicon1.Location.X - 300, pokeicon1.Location.Y)));
            pokeicon2.Invoke(new Action(() => pokeicon2.Location = new Point(pokeicon2.Location.X + 300, pokeicon2.Location.Y)));
            pokeicon1.Invoke(new Action(() => pokeicon1.Image = Properties.Resources.brendan));
            pokeicon2.Invoke(new Action(() => pokeicon2.Image = Properties.Resources.teamrocket));
            pokeicon1.Invoke(new Action(() => pokeicon1.BringToFront()));
            pokeicon2.Invoke(new Action(() => pokeicon2.BringToFront()));
            for (int i = 0; i < 30; i++) {
                pokeicon1.Invoke(new Action(() => pokeicon1.Location = new Point(pokeicon1.Location.X + 10, pokeicon1.Location.Y)));
                pokeicon2.Invoke(new Action(() => pokeicon2.Location = new Point(pokeicon2.Location.X - 10, pokeicon2.Location.Y)));
                Thread.Sleep(100);
            }
            Thread t = new Thread(new ThreadStart(ShowPokemonStatusWithPokeballs));
            t.Start();
            t.Join();
        }

        private void pokepic_placeholder_Click(object sender, EventArgs e)
        {

        }

        public PictureBox CreatePokeball()
        {
            PictureBox pk = new PictureBox();
            pk.Image = pokepic_placeholder.Image;
            pk.Size = pokepic_placeholder.Size;
            pk.Visible = pokepic_placeholder.Visible;
            return pk;
        }

        public void UpdatePPUI()
        {
            ppmax.Text = BattleMechanics.player.active.chosenAttacks[BattleMechanics.moveMenuIndex].a.PP.ToString();
            ppleft.Text = BattleMechanics.player.active.chosenAttacks[BattleMechanics.moveMenuIndex].curPP.ToString();
            typeofmove.Image = BattleMechanics.player.active.chosenAttacks[BattleMechanics.moveMenuIndex].a.type.img;
        }

        private void BattleScene_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(BattleMechanics.keyPressWait)
            {
                if (e.KeyChar == 67 || e.KeyChar == 99) BattleMechanics.keyPressWait = false;
            }
            else if (BattleMechanics.onPlayerControl)
            {
                //MOVE CONTROLS
                if(BattleMechanics.onMoveMenu)
                {
                    switch (BattleMechanics.moveMenuIndex)
                    {
                        case 0:
                            {
                                if (e.KeyChar == 68 || e.KeyChar == 100) //D
                                {
                                    if (BattleMechanics.player.active.chosenAttacks[1] != null)
                                    {
                                        sideArrow.Location = new Point(sideArrow.Location.X + 250, sideArrow.Location.Y);
                                        BattleMechanics.moveMenuIndex = 1;
                                        UpdatePPUI();
                                    }
                                }
                                if (e.KeyChar == 83 || e.KeyChar == 115) //S
                                {
                                    if (BattleMechanics.player.active.chosenAttacks[2] != null)
                                    {
                                        sideArrow.Location = new Point(sideArrow.Location.X, sideArrow.Location.Y + 50);
                                        BattleMechanics.moveMenuIndex = 2;
                                        UpdatePPUI();
                                    }
                            }
                                if (e.KeyChar == 67 || e.KeyChar == 99) //C
                                {
                                    if(BattleMechanics.player.active.chosenAttacks[0].curPP != 0) { 
                                        BattleMechanics.player.activeattack = BattleMechanics.player.active.chosenAttacks[0];
                                        BattleMechanics.player.decision = 0;
                                        TakeControlFromPlayer();
                                    }
                                }
                                break;
                            }
                        case 1:
                            {
                                if (e.KeyChar == 65 || e.KeyChar == 97) //A
                                {
                                    sideArrow.Location = new Point(sideArrow.Location.X - 250, sideArrow.Location.Y);
                                    BattleMechanics.moveMenuIndex = 0;
                                    UpdatePPUI();
                                }
                                if (e.KeyChar == 83 || e.KeyChar == 115) //S
                                {
                                    if (BattleMechanics.player.active.chosenAttacks[3] != null)
                                    {
                                        sideArrow.Location = new Point(sideArrow.Location.X, sideArrow.Location.Y + 50);
                                        BattleMechanics.moveMenuIndex = 3;
                                        UpdatePPUI();
                                    }
                                }
                                if (e.KeyChar == 67 || e.KeyChar == 99) //C
                                {
                                    if (BattleMechanics.player.active.chosenAttacks[1].curPP != 0)
                                    {
                                        BattleMechanics.player.activeattack = BattleMechanics.player.active.chosenAttacks[1];
                                        BattleMechanics.player.decision = 0;
                                        TakeControlFromPlayer();
                                        UpdatePPUI();
                                    }
                                }
                                break;
                            }
                        case 2:
                            {
                                if (e.KeyChar == 87 || e.KeyChar == 119) //W
                                {
                                    sideArrow.Location = new Point(sideArrow.Location.X, sideArrow.Location.Y - 50);
                                    BattleMechanics.moveMenuIndex = 0;
                                    UpdatePPUI();
                                }
                                if (e.KeyChar == 68 || e.KeyChar == 100) //D
                                {
                                    if (BattleMechanics.player.active.chosenAttacks[3] != null)
                                    {
                                        sideArrow.Location = new Point(sideArrow.Location.X + 250, sideArrow.Location.Y);
                                        BattleMechanics.moveMenuIndex = 3;
                                        UpdatePPUI();
                                    }
                                }
                                if (e.KeyChar == 67 || e.KeyChar == 99) //C
                                {
                                    if (BattleMechanics.player.active.chosenAttacks[2].curPP != 0)
                                    {
                                        BattleMechanics.player.activeattack = BattleMechanics.player.active.chosenAttacks[2];
                                        BattleMechanics.player.decision = 0;
                                        TakeControlFromPlayer();
                                    }
                                }
                                break;
                            }
                        case 3:
                            {
                                if (e.KeyChar == 87 || e.KeyChar == 119) //W
                                {
                                    sideArrow.Location = new Point(sideArrow.Location.X, sideArrow.Location.Y - 50);
                                    BattleMechanics.moveMenuIndex = 1;
                                    UpdatePPUI();
                                }
                                if (e.KeyChar == 65 || e.KeyChar == 97) //A
                                {
                                    sideArrow.Location = new Point(sideArrow.Location.X - 250, sideArrow.Location.Y);
                                    BattleMechanics.moveMenuIndex = 2;
                                    UpdatePPUI();
                                }
                                if (e.KeyChar == 67 || e.KeyChar == 99) //C
                                {
                                    if (BattleMechanics.player.active.chosenAttacks[3].curPP != 0)
                                    {
                                        BattleMechanics.player.activeattack = BattleMechanics.player.active.chosenAttacks[3];
                                        BattleMechanics.player.decision = 0;
                                        TakeControlFromPlayer();
                                    }
                                }
                                break;
                            }
                    }
                    if (e.KeyChar == 90 || e.KeyChar == 122) //Z
                    {
                        mainArrow.Visible = true;
                        sideArrow.Visible = false;
                        BattleMechanics.onMoveMenu = false;
                        ppFrame.Visible = false;
                        
                    }
                }
                //ACTION CONTROLS
                else
                {
                    switch(BattleMechanics.menuIndex)
                    {
                        case 0:
                            { 
                                if (e.KeyChar == 68 || e.KeyChar == 100) //D
                                {
                                    mainArrow.Location = new Point(mainArrow.Location.X + 210, mainArrow.Location.Y);
                                    BattleMechanics.menuIndex = 1;
                                }
                                if (e.KeyChar == 83 || e.KeyChar == 115) //S
                                {
                                    mainArrow.Location = new Point(mainArrow.Location.X, mainArrow.Location.Y + 50);
                                    BattleMechanics.menuIndex = 2;
                                }
                                if (e.KeyChar == 67 || e.KeyChar == 99) //C
                                {
                                    if(!BattleMechanics.player.active.nomovesleft && !BattleMechanics.player.active.attackcontinues) { 
                                        mainArrow.Visible = false;
                                        sideArrow.Visible = true;
                                        BattleMechanics.onMoveMenu = true;
                                        UpdatePPUI();
                                        ppFrame.Visible = true;
                                    }
                                }
                                break;
                            }
                        case 1:
                            { 
                                if (e.KeyChar == 65 || e.KeyChar == 97) //A
                                {
                                    mainArrow.Location = new Point(mainArrow.Location.X - 210, mainArrow.Location.Y);
                                    BattleMechanics.menuIndex = 0;
                                }
                                if (e.KeyChar == 83 || e.KeyChar == 115) //S
                                {
                                    mainArrow.Location = new Point(mainArrow.Location.X, mainArrow.Location.Y + 50);
                                    BattleMechanics.menuIndex = 3;
                                }
                                if (e.KeyChar == 67 || e.KeyChar == 99) //C
                                {
                                    // Not coded yet.
                                }
                                break;
                            }
                        case 2:
                            { 
                                if (e.KeyChar == 87 || e.KeyChar == 119) //W
                                {
                                    mainArrow.Location = new Point(mainArrow.Location.X, mainArrow.Location.Y - 50);
                                    BattleMechanics.menuIndex = 0;
                                }
                                if (e.KeyChar == 68 || e.KeyChar == 100) //D
                                {
                                    mainArrow.Location = new Point(mainArrow.Location.X + 210, mainArrow.Location.Y);
                                    BattleMechanics.menuIndex = 3;
                                }
                                if (e.KeyChar == 67 || e.KeyChar == 99) //C
                                {
                                    // Not coded yet.
                                }
                                break;
                            }
                        case 3:
                            { 
                                if (e.KeyChar == 87 || e.KeyChar == 119) //W
                                {
                                    mainArrow.Location = new Point(mainArrow.Location.X, mainArrow.Location.Y - 50);
                                    BattleMechanics.menuIndex = 1;
                                }
                                if (e.KeyChar == 65 || e.KeyChar == 97) //A
                                {
                                    mainArrow.Location = new Point(mainArrow.Location.X - 210, mainArrow.Location.Y);
                                    BattleMechanics.menuIndex = 2;
                                }
                                if (e.KeyChar == 67 || e.KeyChar == 99) //C
                                {
                                    BattleMechanics.masterControl.Abort();
                                    BattleMechanics.pokeIconControl.Abort();
                                    Close();
                                }
                                break;
                            }
                    }
                }
            }
                e.Handled = true;

            
        }

        private void pokepic_placeholder_EnabledChanged(object sender, EventArgs e)
        {
            sideArrow.Visible = false;
            levelCPU.Visible = true;
            hpval.Text = BattleMechanics.player.active.remHP.ToString();
            hpvalmax.Text = BattleMechanics.player.active.cHP.ToString();
            level.Text = BattleMechanics.player.active.level.ToString();
            levelCPU.Text = BattleMechanics.CPU.active.level.ToString();
            level.Visible = true;
            levelval.Visible = true;
            levelvalCPU.Visible = true;
            levelCPU.Visible = true;
            hp.Visible = true;
            hpbar.Visible = true;
            hpCPU.Visible = true;
            hpbarCPU.Visible = true;
            hpval.Visible = true;
            hpvalmax.Visible = true;
            brack.Visible = true;
            BattleMechanics.keyPressWait = false;
        }

        private void consoleFrame_Enter(object sender, EventArgs e)
        {

        }

        private void BattleScene_KeyUp(object sender, KeyEventArgs e)
        {

        }

        public void ShowPokemonStatusWithPokeballs()
        {


            PictureBox[] p_opp = new PictureBox[6];
            PictureBox[] p_usr = new PictureBox[6];
            

            // Add POKéBALL icons.
            for (int i = 0; i < 6; i++) {
                p_opp[i] = CreatePokeball();
                p_usr[i] = CreatePokeball();
                battleFrame.Invoke(new Action(() => battleFrame.Controls.Add(p_opp[i])));
                battleFrame.Invoke(new Action(() => battleFrame.Controls.Add(p_usr[i])));
            }

            // Edit POKéBALL icons, show status.
            for(int i = 0; i < BattleMechanics.pokeCount; i++)
            {
                if (BattleMechanics.player.owned[i].status == DataStorage.ReferStatus(StatusRef.FAINTED))
                    p_usr[i].Image = Properties.Resources.poke_fainted;
                else if(BattleMechanics.player.owned[i].status == DataStorage.ReferStatus(StatusRef.PARALYZED)      ||
                        BattleMechanics.player.owned[i].status == DataStorage.ReferStatus(StatusRef.POISONED)       ||
                        BattleMechanics.player.owned[i].status == DataStorage.ReferStatus(StatusRef.POISONEDBADLY)  ||
                        BattleMechanics.player.owned[i].status == DataStorage.ReferStatus(StatusRef.SLEPT)          ||
                        BattleMechanics.player.owned[i].status == DataStorage.ReferStatus(StatusRef.BURNT)          ||
                        BattleMechanics.player.owned[i].status == DataStorage.ReferStatus(StatusRef.FROZEN))
                    p_usr[i].Image = Properties.Resources.poke_status;
                else p_usr[i].Image = Properties.Resources.poke_available;
                if (BattleMechanics.CPU.owned[i].status == DataStorage.ReferStatus(StatusRef.FAINTED))
                    p_opp[i].Image = Properties.Resources.poke_fainted;
                else if (BattleMechanics.CPU.owned[i].status == DataStorage.ReferStatus(StatusRef.PARALYZED) ||
                         BattleMechanics.CPU.owned[i].status == DataStorage.ReferStatus(StatusRef.POISONED) ||
                         BattleMechanics.CPU.owned[i].status == DataStorage.ReferStatus(StatusRef.POISONEDBADLY) ||
                         BattleMechanics.CPU.owned[i].status == DataStorage.ReferStatus(StatusRef.SLEPT) ||
                         BattleMechanics.CPU.owned[i].status == DataStorage.ReferStatus(StatusRef.BURNT) ||
                         BattleMechanics.CPU.owned[i].status == DataStorage.ReferStatus(StatusRef.FROZEN))
                    p_opp[i].Image = Properties.Resources.poke_status;
                else p_opp[i].Image = Properties.Resources.poke_available;
            }

            // Relocate the POKéBALL icons in a sequence.
            int mover = 0;
            for (int i = 0; i < 6; i++)
            {
                battleFrame.Invoke(new Action(() => p_opp[i].Location = new Point(128 + mover, 54)));
                battleFrame.Invoke(new Action(() => p_usr[i].Location = new Point(680 + mover, 432)));
                battleFrame.Invoke(new Action(() => p_opp[i].Visible = true));
                battleFrame.Invoke(new Action(() => p_usr[i].Visible = true));
                mover    += 32;
            }

            Thread.Sleep(2500);

            // Dispose of images, freeing them from memory.
            for(int i = 0; i < 6; i++)
            {
                Invoke(new Action(() => p_opp[i].Dispose()));
                Invoke(new Action(() => p_usr[i].Dispose()));
            }
        }
    }
}
