using FluxoCaixa.Classes;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace FluxoCaixa.Classes
{
    [Serializable]
    public class Serializa
    {
        public static void save(Caixa caixa)
        {
            string periodo = caixa.mes.ToString("D2");
            try
            {
                FileStream fs = new FileStream("D:\\caixa" + periodo + ".dat",
                    FileMode.Create);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(fs, caixa);
                fs.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static Caixa load(String periodo)
        {
            try
            {
                if (!File.Exists("D:\\caixa" + periodo + ".dat")) return null;

                FileStream fs = new FileStream("D:\\caixa" + periodo + ".dat",
                    FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                Caixa caixa = (Caixa)formatter.Deserialize(fs);
                fs.Close();
                return caixa;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}