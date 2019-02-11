using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
   public class ItemCollection 
    {// that class hold for me all the collection
        public static List<AbstractItem> abstractItems = new List<AbstractItem>();
        public static Dictionary<User,List<AbstractItem>> rental = new Dictionary<User,List<AbstractItem>>();
        private static int _numberOfItems = 0;
        public static int GetNumOfItems()
        {
            return _numberOfItems;
        }
        //add the item to the list of item's
        public static bool AddToLibrary(AbstractItem Item)
        {

            if (Item != null)//change from AbstractItem to item;
            {
                abstractItems.Add(Item);
                _numberOfItems++;
                return true;
            }
            return false;
        }
       //indexer's
        public AbstractItem this[double edition]
        {
            get { return abstractItems.Find((a) => a.getEdition() == edition); }
        }
        public AbstractItem this[string name]
        {
            get { return abstractItems.Find((a) => a.Name.ToLower() == name.ToLower()); }
        }
        public AbstractItem this[Guid ISBN]
        {
            get { return abstractItems.Find((a) => a.ISBN == ISBN); }
        }
        //rent and return func
        public static void removeFromRental(User user, AbstractItem item)
        {
            rental[user].Remove(item);
        }
        public static void addToRental(User user,AbstractItem item)
        {
            if(rental.ContainsKey(user))// if there list so just push
            {
                rental[user].Add(item);
            }
            else
            {
                List<AbstractItem> items = new List<AbstractItem>();// if there isnt alise make a new list
                items.Add(item);
                rental.Add(user, items);
            }  
        }
        //print all the item's that the user contion in his values 
        public static string GetAllRental() {
            StringBuilder sb = new StringBuilder();
            int count = 1;
           foreach (var item in rental)
            {
                foreach (var bookitem in item.Value)
                {
                    sb.AppendLine($"{count} : \"{bookitem.Name}\" Was rent by {item.Key.username}");
                    count++;
                }
                
            }
           
            return sb.ToString();
        }

       
    }
}
