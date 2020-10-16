using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonFightAI
{

    class PokeInstance
    {
        public Pokemon p;
        public int level;
        public Status status = DataStorage.ReferStatus(StatusRef.NORMAL);
        public int cHP;
        public int remHP;
        public int cAttack;
        public int sAttack = 0;
        public int cDefense;
        public int sDefense = 0;
        public int cSpAtk;
        public int sSpAtk = 0;
        public int cSpDef;
        public int sSpDef = 0;
        public int cSpeed;
        public int sSpeed = 0;
        public CAttack[] chosenAttacks = new CAttack[4];
        public CAttack[] multiAttackContinuation = null;
        public bool flight = false;
        public bool digging = false;
        public bool minimized = false;
        public bool attackcontinues = false;
        public bool nomovesleft = false;
        public int sEvasion = 0;
        public int sAccuracy = 0;
        public int sCritRate = 0;

        //public static PokeInstance pointer;

        public int CertainValue(int cVal, int sVal)
        {
            return (int) (cVal * Math.Floor(Math.Pow(1.2F, sVal)));
        }

        public void initPokemon()
        {
            Random IV = new Random();
            cHP = ((p.hp * 2 + IV.Next() % 32 + 48) * level) / 100 + level + 10;
            remHP = cHP;
            cAttack = ((p.attack * 2 + IV.Next() % 32 + 48) * level) / 100 + 5;
            cDefense = ((p.defense * 2 + IV.Next() % 32 + 48) * level) / 100 + 5;
            cSpAtk = ((p.spatk * 2 + IV.Next() % 32 + 48) * level) / 100 + 5;
            cSpDef = ((p.spdef * 2 + IV.Next() % 32 + 48) * level) / 100 + 5;
            cSpeed = ((p.speed * 2 + IV.Next() % 32 + 48) * level) / 100 + 5;
        }

        public PokeInstance(Pokemon p, int level, Attack a0, Attack a1, Attack a2, Attack a3)
        {
            this.p = p;
            this.level = level;
            initPokemon();
            chosenAttacks[0] = new CAttack(a0);
            chosenAttacks[1] = new CAttack(a1);
            chosenAttacks[2] = new CAttack(a2);
            chosenAttacks[3] = new CAttack(a3);
        }

        public PokeInstance(Pokemon p, int level, Attack a0, Attack a1, Attack a2)
        {
            this.p = p;
            this.level = level;
            initPokemon();
            chosenAttacks[0] = new CAttack(a0);
            chosenAttacks[1] = new CAttack(a1);
            chosenAttacks[2] = new CAttack(a2);
        }

        public PokeInstance(Pokemon p, int level, Attack a0, Attack a1)
        {
            this.p = p;
            this.level = level;
            initPokemon();
            chosenAttacks[0] = new CAttack(a0);
            chosenAttacks[1] = new CAttack(a1);
        }

        public PokeInstance(Pokemon p, int level, Attack a)
        {
            this.p = p;
            this.level = level;
            initPokemon();
            chosenAttacks[0] = new CAttack(a);
        }

        public PokeInstance(Pokemon p, int level)
        {
            this.p = p;
            this.level = level;
            initPokemon();
        }

        internal class CAttack
        {
            public Attack a;
            public int curPP;
            public int multiTurnLeft = 0;
            public bool disabled = false;
            public bool mimicked = false;

            public CAttack(Attack a)
            {
                this.a = a;
                curPP = a.PP;
            }
        }

    }


}
