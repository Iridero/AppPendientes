using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace AppPendientes
{
    public class Auxiliar
    {
        public static void Guardar(Pendientes pendientes, string ruta)
        {
            FileStream fs = new FileStream(ruta, FileMode.Create);
            XmlDictionaryWriter writer =
                XmlDictionaryWriter.CreateTextWriter(fs);
            NetDataContractSerializer ser =
                new NetDataContractSerializer();
            ser.WriteObject(writer, pendientes);
            writer.Close();
        }
    }
}
