using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonFightAI
{
    class Pokemon
    {
        public int id;           //Pokémon's unique identifier.
        public string name;      //Pokémon's name.
        public int hp;           //Pokémon's Health Points.
        public int attack;       //Pokémon's physical attack power.
        public int defense;      //Pokémon's physical defense.
        public int spatk;        //Pokémon's special attack power.
        public int spdef;        //Pokémon's special defense.
        public int speed;        //Pokémon's Speed initiative.
        public AttackPair<Attack, int> possibleAttacks; //Stores Pokémon's Attack tree, each associated with a level prerequisite.
        public PokeType type1;   //Stores Pokémon's primary type.
        public PokeType type2;   //Stores Pokémon's secondary type.
        public bool isLegendary; //Indicator of that the Pokémon is legendary or not.
        public Image frontSprite; //Pokémon front sprite, as opponent sprite.
        public Image backSprite;  //Pokémon front sprite, as player sprite.
        public int weight;       //Pokémon's weight in kg. Has effect in attacks such as Low Kick.


        public Pokemon(int id, string name, int hp, int attack, int defense, 
            int spatk, int spdef, int speed, AttackPair<Attack, int> possibleAttacks, 
            PokeType type1, PokeType type2, bool isLegendary, 
            Image frontSprite, Image backSprite, int weight)
        {
            this.id              = id;
            this.name            = name;
            this.hp              = hp;
            this.attack          = attack;
            this.defense         = defense;
            this.spatk           = spatk;
            this.spdef           = spdef;
            this.speed           = speed;
            this.possibleAttacks = possibleAttacks;
            this.type1           = type1;
            this.type2           = type2;
            this.isLegendary     = isLegendary;
            this.frontSprite     = frontSprite;
            this.backSprite      = backSprite;
            this.weight          = weight;
        }

        public Pokemon(int id, string name)
        {
            this.id   = id;
            this.name = name;
            hp        = 50;
            attack    = 50;
            defense   = 50;
            spatk     = 50;
            spdef     = 50;
            speed     = 50;
            weight    = 10;
        }

        public override string ToString()
        {
            return name;
        }

        public Pokemon() { }
    }
}
