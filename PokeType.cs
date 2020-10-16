using System.Collections.Generic;
using System.Drawing;

namespace PokemonFightAI
{
    public class PokeType
    {
        int id;
        string typeName;
        public Image img;
        public PokeType[] strongTo;
        public PokeType[] strongAgainst;
        public PokeType[] weakTo;
        public PokeType[] weakAgainst;
        public PokeType[] notEffectiveTo;
        public PokeType[] notEffectiveAgainst;

        public PokeType(int id, string typeName, Image img)
        {
            this.id       = id;
            this.typeName = typeName;
            this.img      = img;
        }
    }
}