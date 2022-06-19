using System;
using System.Xml.Serialization;

namespace SimpleSerialize
{
    [Serializable, XmlRoot(Namespace = "http://www.MyCompany.com")]
    public class JamesBondCar : Car
    {
        public JamesBondCar(bool skyWorthy, bool seaWorthy)
        {
            canFly = skyWorthy;
            canSubmerge = seaWorthy;
        }

        // XmlSerializer требует стандартного конструктора!
        public JamesBondCar() { }

        [XmlAttribute]
        public bool canFly;

        [XmlAttribute]
        public bool canSubmerge;
    }
}
