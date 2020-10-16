using System.Drawing;

namespace PokemonFightAI
{
    public class Status
    {
        public int id;
        public string statusName;
        public Image statusIcon;
        public string statusText;

        public Status(int id, string statusName, string statusText)
        {
            this.id = id;
            this.statusName = statusName;
            this.statusText = statusText;
        }

        public Status(int id, string statusName, string statusText, Image statusIcon)
        {
            this.id = id;
            this.statusName = statusName;
            this.statusText = statusText;
            this.statusIcon = statusIcon;
        }
    }
}