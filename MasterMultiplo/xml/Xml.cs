using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace MasterMultiplo.xml
{
    internal class Xml
    {
        public String lerXML(String xml)
        {
            return System.IO.File.ReadAllText(xml);

        }

        public List<models.DadosXml> getXmlData(string xml)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(xml);
          
            MemoryStream ms = new MemoryStream(byteArray);

            XmlTextReader xtr = new XmlTextReader(ms);

            List<models.DadosXml> fci = new List<models.DadosXml>();
            models.DadosXml f;

            f = new models.DadosXml();
            //string idApp;

            while (xtr.Read())
            {
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "application" && xtr.HasAttributes == true)
                {
                    string valor1 = xtr.GetAttribute(1);
                    if(valor1 == "maestro (secondary)") 
                    {
                        valor1 = "maestro";
                      while (xtr.Read())
                    {
                        if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "application" && xtr.HasAttributes == true)
                        {
                            string atributte = xtr.GetAttribute(1);
                            if(atributte != "maestro (secondary)")
                            {
                                    valor1 = "mastercard";
                            }
                        }
                            if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "dataElement" && xtr.HasAttributes == true)
                        {
                            string valor = xtr.GetAttribute(0);
                            f.id = valor;
                        }
                        if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "name")
                        {
                            f.name = xtr.ReadElementContentAsString();

                        }
                        if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "tag")
                        {
                            f.tag = xtr.ReadElementContentAsString();
                        }
                        if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "value")
                        {
                            f.value = xtr.ReadElementContentAsString();
                            f.idApp = valor1;
                            fci.Add(f);
                            f = new models.DadosXml();
                        }
                    }
                    }
                    

                }

            }

            return fci;
        }

        public List<models.Dgi> dgiDados(String xml)
        {

            List<models.DadosXml> listaXml = getXmlData(lerXML(xml));


            List<models.Dgi> dgi = new List<models.Dgi>();
            models.Dgi d;

            d = new models.Dgi();

            foreach (var elemento in listaXml)
            {
                if (elemento.id == "mcact.internal.acc1control" || elemento.id == "mcact.internal.acc1cvrdependencydata"
                    || elemento.id == "mcact.internal.acc2control" || elemento.id == "mcact.internal.acc2cvrdependencydata"
                    || elemento.id == "mcact.internal.counter1control" || elemento.id == "mcact.internal.counter1cvrdependencydata"
                    || elemento.id == "mcact.internal.counter2control" || elemento.id == "mcact.internal.counter2cvrdependencydata"
                    || elemento.id == "mcact.internal.cvrissuerdiscretionarydata" || elemento.id == "mcact.internal.interfaceidentifier"
                    || elemento.id == "mcact.internal.mtacmv" || elemento.id == "mcact.internal.mtanocmv")
                {
                    d.dgi = "A012";
                    d.name = elemento.name;
                    d.value = elemento.value;
                    d.idApp = elemento.idApp;
                    dgi.Add(d);
                    d = new models.Dgi();
                }
                if (elemento.id == "mcacl.internal.acc1control" || elemento.id == "mcacl.internal.acc1cvrdependencydata"
                    || elemento.id == "mcacl.internal.acc2control" || elemento.id == "mcacl.internal.acc2cvrdependencydata"
                    || elemento.id == "mcacl.internal.counter1control" || elemento.id == "mcacl.internal.counter1cvrdependencydata"
                    || elemento.id == "mcacl.internal.counter2control" || elemento.id == "mcacl.internal.counter2cvrdependencydata"
                    || elemento.id == "mcacl.internal.cvrissuerdiscretionarydata" || elemento.id == "mcacl.internal.interfaceidentifier"
                    || elemento.id == "mcacl.internal.mtacmv" || elemento.id == "mcacl.internal.mtanocmv")
                {

                    d.dgi = "A022";
                    d.name = elemento.name;
                    d.value = elemento.value;
                    d.idApp = elemento.idApp;
                    dgi.Add(d);
                    d = new models.Dgi();
                }
                if (elemento.id == "mcash.internal.acc1currcode" || elemento.id == "mcash.internal.acc1currconvtable"
                   || elemento.id == "mcash.internal.acc1lowerlimit" || elemento.id == "mcash.internal.acc1upperlimit"
                   || elemento.id == "mcash.internal.acc2currcode" || elemento.id == "mcash.internal.acc2currconvtable"
                   || elemento.id == "mcash.internal.acc2lowerlimit" || elemento.id == "mcash.internal.acc2upperlimit"
                   || elemento.id == "mcash.internal.additionalchecktable" || elemento.id == "emvnonmobilesh.internal.cdol1relateddatalength"
                   || elemento.id == "mcash.internal.counter1lowerlimit" || elemento.id == "mcash.internal.counter1upperlimit")
                {
                    d.dgi = "A002";
                    d.name = elemento.name;
                    d.value = elemento.value;
                    d.idApp = elemento.idApp;
                    dgi.Add(d);
                    d = new models.Dgi();
                }
                if (elemento.id == "emvnonmobilecl.internal.aip" || elemento.id == "emvnonmobilecl.internal.afl")
                {
                    d.dgi = "B005";
                    d.name = elemento.name;
                    d.value = elemento.value;
                    d.idApp = elemento.idApp;
                    dgi.Add(d);
                    d = new models.Dgi();
                }
                if (elemento.name == "Last Online Transaction Date")
                {
                    d.dgi = "A00A";
                    d.name = elemento.name;
                    d.value = elemento.value;
                    d.idApp = elemento.idApp;
                    dgi.Add(d);
                    d = new models.Dgi();
                }
                if (elemento.id == "mcash.internal.atclimit" || elemento.id == "emvnonmobilesh.internal.previoustxnhistory")
                {
                    d.dgi = "A007";
                    d.name = elemento.name;
                    d.value = elemento.value;
                    d.idApp = elemento.idApp;
                    dgi.Add(d);
                    d = new models.Dgi();
                }
                if (elemento.id == "emvnonmobilesh.internal.alcd")
                {
                    d.dgi = "A009";
                    d.name = elemento.name;
                    d.value = "0000000000000000000000000000000000000000"; // de acordo com a DOC, o valor para esse elemento é 20bytes de 00
                    d.idApp = elemento.idApp;
                    dgi.Add(d);
                    d = new models.Dgi();
                }
                if (elemento.id == "mcact.internal.appcontrol")
                {
                    d.dgi = "A013";
                    d.name = elemento.name;
                    d.value = elemento.value;
                    d.idApp = elemento.idApp;
                    dgi.Add(d);
                    d = new models.Dgi();
                }
                if (elemento.id == "mcact.internal.readrecordfilter")
                {
                    d.dgi = "A014";
                    d.name = elemento.name;
                    d.value = elemento.value;
                    d.idApp = elemento.idApp;
                    dgi.Add(d);
                    d = new models.Dgi();
                }
                if (elemento.id == "mcact.internal.ciacdecline" || elemento.id == "mcact.internal.ciacdefault" ||
                    elemento.id == "mcact.internal.ciaconline")
                {
                    d.dgi = "A015";
                    d.name = elemento.name;
                    d.value = elemento.value;
                    d.idApp = elemento.idApp;
                    dgi.Add(d);
                    d = new models.Dgi();
                }
                if (elemento.id == "mcacl.internal.appcontrol")
                {
                    d.dgi = "A023";
                    d.name = elemento.name;
                    d.value = elemento.value;
                    d.idApp = elemento.idApp;
                    dgi.Add(d);
                    d = new models.Dgi();
                }
                if (elemento.id == "mcacl.internal.readrecordfilter")
                {
                    d.dgi = "A024";
                    d.name = elemento.name;
                    d.value = elemento.value;
                    d.idApp = elemento.idApp;
                    dgi.Add(d);
                    d = new models.Dgi();
                }
                if (elemento.id == "mcacl.internal.ciacdecline" || elemento.id == "mcacl.internal.ciacdefault" ||
                    elemento.id == "mcacl.internal.ciaconline")
                {
                    d.dgi = "A025";
                    d.name = elemento.name;
                    d.value = elemento.value;
                    d.idApp = elemento.idApp;
                    dgi.Add(d);
                    d = new models.Dgi();
                }
            }

            return dgi;
         }


    }
}
