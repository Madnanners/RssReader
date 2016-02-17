using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace WindowsFormsApplication3
{
    class items : List<item>
    {
        new public bool Contains(item Item)
        {
            foreach (item itemForCheck in this)
            {
                if (Item.title == itemForCheck.title)
                {
                    return true;
                }
            }
            return false;
        }

        public item GetItem(String Title)
        {
            foreach (item itemForCheck in this)
            {
                if (itemForCheck.title == Title)
                {
                    return itemForCheck;
                }
            }
            return null;
        }
    }
}
