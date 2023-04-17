using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSpinOnline.Cards
{
    [Serializable]
    class Card
    {
        private int value;
        private string color;
        private bool spin;
        

        public Card(int v, string c, bool s)
        {
            value = v;
            color = c;
            spin = s;
        }

        public bool GetSpin()
        {
            return spin;
        }

        public string GetColor()
        {
            return color;
        }

        public int GetValue()
        {
            return value;
        }
    }
}
