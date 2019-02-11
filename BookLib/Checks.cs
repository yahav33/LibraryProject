using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{//class that i use his methood all the way to check numbers and string if thay valid's
    public class Checks
    {
        public static bool IsNotEmptyNullOrWhite(string name) {
            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
                return false;
            return true;
        }
        public static bool isTextDouble(string number) {
            double num = 0;
            if (double.TryParse(number, out num) && num > 0)
                return true;
            return false;
        }
        public static bool isTextInt(string number)
        {
            int num = 0;
            if (int.TryParse(number, out num) && num > 0)
                return true;
            return false;
        }
        // make the calculation with the discount by the theme
        public static double CheckDiscount(double price, Theme theme)
            {
            switch (theme)
            {
                case Theme.Heroism:
                    price -= (price * Constants.DisHeroism) / 100;
                    break;
                case Theme.Love:
                    price -= (price * Constants.DisLove) / 100;
                    break;
                case Theme.GoodNEvil:
                    price -= (price * Constants.DisGoodNEvil) / 100;
                    break;
                case Theme.SuperHeroes:
                    price -= (price * Constants.DisSuperHeros) / 100;
                    break;
                case Theme.Survivel:
                    price -= (price * Constants.DisSurvivel) / 100;
                    break;
                default:
                    break;
            }

            return price;
            }



    }
}
