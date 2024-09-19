using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace FluxoCaixa.Classes
{
    public class SerializaUser
    {
        public static void save(List<Usuario> listaUser)
        {
            try
            {
                FileStream fs = new FileStream("D:\\User.dat",
                    FileMode.Create);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(fs, listaUser);
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<Usuario> load()
        {
            try
            {
                if (!File.Exists("D:\\User.dat")) return null;

                FileStream fs = new FileStream("D:\\User.dat",
                    FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                List<Usuario> lista =
                    (List<Usuario>)formatter.Deserialize(fs);
                fs.Close();

                if (lista.Count() == 1)
                {
                    lista.Add(new Usuario("Rangel", "@1234".GetHashCode()));
                }

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}