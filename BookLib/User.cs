using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
   public class User
    {//this class run all the users
        public static List<User> users = new List<User>();
        public List<AbstractItem> items;
        public string username { get; set; }
        public string password { get; set; }
        private bool _staff = false;
        public static int _counter = 1;
        public int ID { get; set; }

        public User(string name,string pass,bool staff = false) {
            items = new List<AbstractItem>();
            username = name;
            password = pass;
            _staff = staff;
            ID = _counter;
            _counter++;
            users.Add(this);
        }
        public bool isEmployee()
        {
            return _staff;
        }
        public void RentItem(AbstractItem item)
        {
            items.Add(item);
        }
        //indexer
        public User this[string name]
        {
            get { return users.Find((a) => a.username.ToLower() == name.ToLower()); }
        }
        public AbstractItem GetItem(string name)
        {
            return items.Find((a) => a.Name == name);
        }
        public override string ToString()
        {
            string ans = "";
            if(this.isEmployee())
            ans = String.Format($"Subscribe name : {username}\nID :{ID}\nThis user is an employee ");
            else
            ans = String.Format($"Subscribe name : {username}\nID :{ID}");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nBook List");
            sb.AppendLine("----------");
            for (int i = 0; i < items.Count; i++)
            {
                sb.AppendLine(items[i].Name);
            }
            ans += sb.ToString();
            return ans;
        }
    }
}
