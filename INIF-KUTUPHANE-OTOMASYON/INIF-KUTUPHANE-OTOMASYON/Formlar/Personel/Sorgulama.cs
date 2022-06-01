using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INIF_KUTUPHANE_OTOMASYON.Formlar.Personel
{
    public class Sorgulama
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sütun"></param>
        /// <param name="table"></param>
        /// <param name="where"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool KontrolEt(string sütun, string table, string where, string text)
        { 
            MySqlConnection connection = new MySqlConnection(@"Server=172.21.54.3; uid=yazilim16; pwd=Yazılım.16;database=yazilim16");
            string ad;
            connection.Open();
            MySqlCommand command = new MySqlCommand("select " + sütun + " from " + table + " where " + where + "=1", connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ad = reader[0].ToString();
                if (ad==text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            connection.Close(); 
            return false;
        }
    }
}
