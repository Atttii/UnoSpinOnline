using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSpinN_Unit.Cards
{
    class Card
    {
        public int value;
        public string color;
        public bool spin;
        public bool pickup;
        public int pickupValue;
        public bool changeColor;
        public bool changeDirection;
        public bool skipNextTurn;

        public Card(int v, string c, bool s)
        {
            value = v;
            color = c;
            spin = s;
            pickup = false;
            pickupValue = 0;
            changeColor = false;
            changeDirection = false;
            skipNextTurn = false;

            if (value == 10)
            {
                pickup = true;
                pickupValue = 2;
            }
            else if (value == 11)
            {
                pickup = true;
                pickupValue = 4;
                changeColor = true;
            }
            else if (value == 12)
            {
                changeColor = true;
            }
            else if (value == 13)
            {
                changeDirection = true;
            }
            else if (value == 14)
            {
                skipNextTurn = true;
            }
        }

        public string toString()
        {
            return $"{color} {value} Card. Spin = {spin} ";

        }
    }
}
