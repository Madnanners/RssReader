using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApplication3
{
    class item
    {
        public String title; 
        public
            String link; 
        public 
            String description;
        public
        item(XmlNode ItemTag)
        {            
              foreach (XmlNode xmlTag in ItemTag.ChildNodes)
                {
                switch (xmlTag.Name)
                    {
                    case "title":
                        {
                        this.title = xmlTag.InnerText;
                            break;
                        }
                    case "description":
                        {
                        this.description = xmlTag.InnerText;
                        break;
                        }
                    case "link":
                        {
                        this.link = xmlTag.InnerText;
                        break;
                        }

                }

            }

        }
    }
}
