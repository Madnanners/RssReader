using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApplication3
{
    class feed
    {
        public String Title;
        public String Description;
        public String Link;
        public items Items;
        public
        feed(String Url)
        {   Items = new items();
            XmlTextReader xmlTextReader = new XmlTextReader(Url);
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(xmlTextReader);
                xmlTextReader.Close();
                XmlNode channelXmlNode = xmlDoc.GetElementsByTagName("channel")[0];
                if (channelXmlNode != null)
                {
                    foreach (XmlNode channelNode in channelXmlNode.ChildNodes)
                    {
                    switch (channelNode.Name)
                        {
                            case "title":
                                {
                                    Title = channelNode.InnerText;
                                    break;
                                }
                            case "description":
                                {
                                    Description = channelNode.InnerText;
                                    break;
                                }
                            case "link":
                                {
                                    Link = channelNode.InnerText;
                                    break;
                                }
                            case "item": 
                                {
                                    item channelItem = new item(channelNode);
                                    Items.Add(channelItem);
                                    break;
                                }
                        }
                    }
                }
                else
                    {
                        throw new Exception("Ошибка в XML.Описание канала не найдено!");
                    }
            }  
            catch (System.Net.WebException ex)
            {
                if (ex.Status == System.Net.WebExceptionStatus.NameResolutionFailure)
                    throw new Exception("Невозможно соединиться с указаным источником.\r\n" +Url);
                else
                    throw ex;
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new Exception("Файл " +Url + "не найден!");
            }          
            catch (Exception ex)
            {
                throw
            ex;
            }
            finally
            {
             xmlTextReader.Close();
            }
        }
    }
}
