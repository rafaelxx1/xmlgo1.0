using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MasterMultiplo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            xml.Xml xml = new xml.Xml();

            String xmlWay = @"C:\Users\fraca\Documents\tcc2022\Estudando wf c#\MasterMultiplo\MasterMultiplo\xml\multiplo.xml";

          

             try
             {
                 // Console.WriteLine(xml.getXmlData(xmlWay));
                 List<models.Dgi> dgi = xml.dgiDados(xmlWay);
                 foreach (var elemento in dgi)
                 {
                     Console.WriteLine("APP: [" + elemento.idApp + "]" + " DGI: [" + elemento.dgi + "] Name: [" + elemento.name + "]" + " Value: [" + elemento.value + "]" );
                 }
             }
             catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
