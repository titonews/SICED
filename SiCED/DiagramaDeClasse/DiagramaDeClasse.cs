using SiCED.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace SiCED.DiagramaDeClasse
{
    public static class DiagramaDeClasse
    {
        public static void GerarDiagrama()
        {
            using(var ctx = new ContextoEF())
            {
                using (var writer = new XmlTextWriter(@"C:\Users\Alexsandro Moreira\Documents\Visual Studio 2015\Projects\SiCED\SiCED\DiagramaDeClasse\Model.edmx", Encoding.Default))
                {
                    EdmxWriter.WriteEdmx(ctx, writer);
                }


            }
        }
    }
}