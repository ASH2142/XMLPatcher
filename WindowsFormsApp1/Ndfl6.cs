using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApp1
{
    class Ndfl6 : XmlDocument
    {
        private string name, inn, kpp;

        public string Name {
            get
            {
                return name;
            } 
        }

        public string Inn
        {
            get
            {
                return inn;
            }
        }

        public string Kpp
        {
            get
            {
                return kpp;
            }
        }


        public void Open(Ndfl6 xDoc)
        {
            XmlElement element = xDoc.DocumentElement;

            foreach (XmlNode xnode in element.ChildNodes)
            {
                foreach (XmlNode tagetNode in xnode.ChildNodes)
                {
                    if (tagetNode.Name == "СвНП")
                    {
                        foreach (XmlElement param in tagetNode.ChildNodes)
                        {
                            if (param.HasAttribute("ИННФЛ"))
                            {
                                inn = "Введите ИННЮЛ";
                                kpp = "Введите КПП";
                                name = "Введите название организации";
                            }
                            else
                            {
                                inn = param.GetAttribute("ИННЮЛ");
                                kpp = param.GetAttribute("КПП");
                                name = param.GetAttribute("НаимОрг");
                            }
                        }
                    }

                }

            }
        }
        public void Patch(Ndfl6 xDoc, string Inn, string Kpp, string Name)
        {
            XmlElement element = xDoc.DocumentElement;
            foreach (XmlNode xnode in element.ChildNodes)
            {
                foreach (XmlNode tagetNode in xnode.ChildNodes)
                {
                    if (tagetNode.Name == "СвНП")
                    {
                        foreach (XmlElement param in tagetNode.ChildNodes)
                        {
                            if (param.HasAttribute("ИННФЛ"))
                            {
                                tagetNode.RemoveChild(param);
                                XmlElement npul = xDoc.CreateElement("НПЮЛ");
                                npul.SetAttribute("НаимОрг", name);
                                npul.SetAttribute("КПП", kpp);
                                npul.SetAttribute("ИННЮЛ", inn);
                                tagetNode.AppendChild(npul);
                            }
                            else
                            {
                                param.SetAttribute("ИННЮЛ", Inn);
                                param.SetAttribute("КПП", Kpp);
                                param.SetAttribute("НаимОрг", Name);
                            }
                        }
                    }
                }

            }
        }
    }
}
