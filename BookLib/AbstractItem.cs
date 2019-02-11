using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    // class abstract that contion all the methood and data to the item's
    public abstract class AbstractItem : IComparable<AbstractItem>//implant Interface
    {
        protected string _name;
        protected DateTime _dateTime;
        protected double _edition;
        protected int _copies;
        protected Theme _theme;
        protected Categories _category;
        protected Guid _ISBN;
        protected double _price = 0;
        protected double _discount;
      

        
        public AbstractItem(string name, double edition, int copies, Theme theme, Categories category,double price)
        {
            _ISBN = Guid.NewGuid();
            _name = name;
            _dateTime = DateTime.Now;
            _edition = edition;
            _copies = copies;
            _theme = theme;
            _category = category;
            _price = price;
            getDiscountPrice();
        }
        public int getCopies()
        {
            return _copies;
        }
        public string getTheme()
        {
            return _theme.ToString();
        }
        public string getcategory()
        {
            return _category.ToString();
        }
        public string Name { get { return _name; } }
        //we have 2 methood to deal with cupies
        //2 we get amount from the user
        public  void AddCopies(int amount)
        {
            this._copies += amount;
        }
        public  void ReduceCopies(int amount)
        {
            if (_copies - amount < 0)
            {
                string ans = "You Try To Reduce Copies more then you have in your stock , you have " + _copies + " Copies and you try to Remove " + amount;
                throw new Exception(ans);
            }
            else _copies -= amount;

        }
        //2 we do automatically after the rent and return, only one each time.
        public void ReduceCopyAmount()
        {
            _copies--;
        }
        public void AddCopy()
        {
            _copies++;
        }
        public double getEdition() { return _edition; }
        public double getPrice() {
            return _price;
        }
        public Guid ISBN { get { return _ISBN; } }
        //we get discount by the theme, and we can change it at the constsnts class
        // the system make discount by the theme
        public double getDiscountPrice() {
            return _discount = Checks.CheckDiscount(_price, _theme);
        }

        public override string ToString()
        {
            var a = this.GetType();
            string ans;
            ans = string.Format($"Name of the {a.Name} is : {Name}\nThe edition is :{_edition}\nDate of addition to library :\n{_dateTime}\nPrice is : {_price}" +
                $"\nPrice after discount : {_discount}\nNumber of copies : {_copies}\nISBN is :\n{ISBN}\n the them is : {_theme}\n the category is : {_category}");
            return ans;
        }

        public int CompareTo(AbstractItem other)
        {
            int num = this.Name.CompareTo(other.Name);
            return num;
        }
    }
}
