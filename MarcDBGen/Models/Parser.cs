using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MarcDBGen.Models
{
    public class Parser
    {
        public static String Parse(List<MARC_XML> list)
        {
            List<String> retList = new List<string>();
            foreach(MARC_XML item in list)
            {
                XElement root = XElement.Parse(item.XML);
                IEnumerable<XElement> nodes =
                    from el in root.Elements()
                    select el;
                foreach(XElement node in nodes)
                {
                    if(!node.HasAttributes && !node.HasElements)
                    {
                        if (!retList.Contains(node.Name.LocalName))
                        {
                            retList.Add(node.Name.LocalName);
                        }
                    }
                    if(node.HasAttributes && !node.HasElements)
                    {
                        if (!retList.Contains(String.Format("{0}_{1}", node.Name.LocalName, node.Attribute("tag").Value)))
                        {
                            retList.Add(String.Format("{0}_{1}", node.Name.LocalName, node.Attribute("tag").Value));
                        }
                    }
                    if(node.HasAttributes && node.HasElements)
                    {
                        IEnumerable<XElement> subnodes =
                            from el in node.Elements()
                            select el;
                        foreach(XElement subnode in subnodes)
                        {
                            if(!retList.Contains(String.Format("{0}_{1}_{2}", node.Name.LocalName, node.Attribute("tag").Value,subnode.Attribute("code").Value)))
                            {
                                retList.Add(String.Format("{0}_{1}_{2}", node.Name.LocalName, node.Attribute("tag").Value, subnode.Attribute("code").Value));
                            }
                        }
                    }
                }
            }
            String sql = "";
            retList.Sort();
            foreach(string item in retList)
            {
                sql += String.Format("{0} NVARCHAR(250) NULL,\n", item);
            }
            return sql;
        }
    }
}