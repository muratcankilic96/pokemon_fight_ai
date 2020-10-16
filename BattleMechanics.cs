using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonFightAI
{
    class Trainer
    {
        public string name;
        public PokeInstance[] owned;
        public PokeInstance active;
        public PokeInstance.CAttack activeattack;
        public bool playedTheirTurn;
        public AIControl aicontrol;
        public int decision = -1; // 0 = ATTACK || 1 = POKéMON SWITCH || 2 = ITEM
        public Trainer rival;

        public Trainer(PokeInstance[] owned)
        {
            this.owned = owned;
        }

        public void MakeSomeMove()
        {
            if(!playedTheirTurn) { 
                if (decision == 0)
                {
                    BattleMechanics.form.Write(name + "'S " + active.p.name + " USES \n" + activeattack.a.name + "!");
                    activeattack.curPP--;
                    activeattack.a.Use(active, rival.active);
                }
                playedTheirTurn = true;
            }
        }
    }
    static class BattleMechanics
    {
        public static BattleScene form;
        public static PokeInstance temp;
        public static Thread masterControl, initializationControl, consoleControl, pokeIconControl, differentationControl;
        public static Trainer player, CPU;
        public static Random r = new Random();
        public static int pokeCount;
        public static bool keyPressWait = false;
        public static bool onPlayerControl = false; // If FALSE, shaking Pokémon images will stop.
        public static bool onMoveMenu = false; // If TRUE, Player controls Move. If FALSE, player chooses one of four actions.
        public static int menuIndex = 0;
        public static int moveMenuIndex = 0;
        public static int turn = 1;

        static public Trainer FindTrainerByPokemon(PokeInstance pi)
        {
            if(Array.Exists(player.owned, a => a == pi))
            {
                return player;
            }
            if (Array.Exists(CPU.owned, a => a == pi))
            {
                return CPU;
            }
            return null;
        }

        static public void Faint(PokeInstance pi)
        {
            bool playerbool = false;
            Trainer t = FindTrainerByPokemon(pi);
            pi.status = DataStorage.ReferStatus(StatusRef.FAINTED);
            if (t == player) {
                playerbool = true;
                form.Invoke(new Action(() => form.status.Image = Properties.Resources.fnt));
            }
            else
            {
                form.Invoke(new Action(() => form.statusCPU.Image = Properties.Resources.fnt));
            }
            t.playedTheirTurn = true;
            Thread.Sleep(255);
            pokeIconControl = new Thread(() => form.FaintAnimation(playerbool));
            pokeIconControl.Start();
            pokeIconControl.Join();
            form.Write(t.name + "'S " + pi.p.name + " FAINTED!");
            t.active = null;
        }

        static public void StatusLog(PokeInstance p, Status s)
        {
            PictureBox pb;
            if (FindTrainerByPokemon(p).name == "PLAYER")
                pb = form.status; else pb = form.statusCPU;
            form.Invoke(new Action(() => pb.Image = s.statusIcon));
            form.Write(p.p.name + s.statusText);
        }

        static public void ExecuteByInitiative()
        {
            if (player.activeattack.a.priority < CPU.activeattack.a.priority)
            {
                CPU.MakeSomeMove();
                player.MakeSomeMove();
            } else if (player.activeattack.a.priority > CPU.activeattack.a.priority)
            {
                player.MakeSomeMove();
                CPU.MakeSomeMove();
            } else if (player.active.CertainValue(player.active.cSpeed, player.active.sSpeed) <
                         CPU.active.CertainValue(CPU.active.cSpeed, CPU.active.sSpeed))
            {
                CPU.MakeSomeMove();
                player.MakeSomeMove();
            }
            else if (player.active.CertainValue(player.active.cSpeed, player.active.sSpeed) >
                     CPU.active.CertainValue(CPU.active.cSpeed, CPU.active.sSpeed))
            {
                player.MakeSomeMove();
                CPU.MakeSomeMove();
            } else if (r.Next() % 2 == 1)
                {
                    player.MakeSomeMove();
                    CPU.MakeSomeMove();
                } else
                {
                    CPU.MakeSomeMove();
                    player.MakeSomeMove();
                }
        }

        static public void WriteConsole(Label l, string text, bool passable)
        {
            char[] textarray = text.ToCharArray();
            for(int i = 0; i < text.Length; i++)
            {
                Form.ActiveForm.Invoke(new Action(() => l.Text = l.Text + textarray[i].ToString()));
                Thread.Sleep(25);
            }
            keyPressWait = true;
            if(passable) { 
                while(keyPressWait) { /* Do nothing. */ };
            } else
            {
                Thread.Sleep(750);
            }
            
            Form.ActiveForm.Invoke(new Action(() => l.Text = ""));
        }
    }
}
