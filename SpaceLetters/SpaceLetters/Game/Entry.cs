using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    class Entry : IComparable<Entry>
    {
        private String name;
        private int score;
        public String Name
        {
            get { return name; }
        }
        public int Score
        {
            get { return score; }
        }

        public Entry(String row)
        {
            String[] parts = row.Split(',');
            name = parts[0];
            Int32.TryParse(parts[1],out score);
        }
        public Entry(String name, int score)
        {
            this.name = name;
            this.score = score;
        }


        public int CompareTo(Entry other)
        {
            return -score + other.score;
        }

        public override string ToString()
        {
            return name+","+score+"\n";
        }
    }
}
