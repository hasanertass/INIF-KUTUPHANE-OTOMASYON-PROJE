using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INIF_KUTUPHANE_OTOMASYON.Formlar.Personel
{

    class SilmeSorgu
    {
        public static bool Kontrol(string sorgu,string deger)
        {
            MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
            try
            {
                string data;
                connection.Open();
                MySqlCommand command = new MySqlCommand(sorgu, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    data = reader[0].ToString();
                    if (data == deger)
                    {
                        connection.Close();
                        return true;
                    }
                    //else
                    //{
                    //    connection.Close();
                    //    return false;
                    //}
                }
            }
            catch (Exception)
            {
                connection.Close();
            }
            return false;
        }

    }
}
