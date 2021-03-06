﻿using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Blog.Michaeldeongreen.CLI.Core.Domain
{
    [XmlRoot("urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class Sitemap
    {
        private ArrayList map;

        public Sitemap()
        {
            map = new ArrayList();
        }

        [XmlElement("url")]
        public SitemapLocation[] Locations
        {
            get
            {
                SitemapLocation[] items = new SitemapLocation[map.Count];
                map.CopyTo(items);
                return items;
            }
            set
            {
                if (value == null)
                    return;
                SitemapLocation[] items = (SitemapLocation[])value;
                map.Clear();
                foreach (SitemapLocation item in items)
                    map.Add(item);
            }
        }

        public string GetSitemapXml()
        {
            return string.Empty;
        }

        public int Add(SitemapLocation item)
        {
            return map.Add(item);
        }


        public void WriteSitemapToFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (XmlWriter w = new XmlTextWriter(fs, Encoding.UTF8))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("image", "http://www.google.com/schemas/sitemap-image/1.1");

                    XmlSerializer xs = new XmlSerializer(typeof(Sitemap));
                    xs.Serialize(w, this, ns);
                }
            }
        }
    }
}
