using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnoSpinOnline.Cards
{
    class Card
    {
        private int value;
        private string color;
        private bool spin;
        private bool pickup;
        private int pickupValue;
        private bool changeColor;
        private bool changeDirection;
        private bool skipNextTurn;

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
                changeDirection = true;
            }
            else if (value == 12)
            {
                skipNextTurn = true;
            }
            else if (value == 13)
            {
                pickup = true;
                pickupValue = 4;
                changeColor = true;
            }
            else if (value == 14)
            {
                changeColor = true;
            }
        }

        public string GetColor()
        {
            return color;
        }

        public int GetValue()
        {
            return value;
        }

        public string toString()
        {
            return $"{color} {value} Card. Spin = {spin} ";

        }
    }
}
