using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Common;
using System.IO;

namespace SqliteSample
{
    public class DataManager
    {
        private static DataManager instance = null;

        public static DataManager GetInstance()
        {
            if (instance == null)
            {
                instance = new DataManager();
            }
            return instance;
        }

        private SQLiteConnection connection;
        private const string dataBaseName = "Dictionary.db";
        private const string wordAndTranslationTable = "word_and_translation";
        private SQLiteCommand command;

        public DataManager()
        {
            if (File.Exists(dataBaseName) == false)
            {
                SQLiteConnection.CreateFile(dataBaseName);
            }
            connection = new SQLiteConnection(string.Format("Data Source={0};", dataBaseName));
            connection.Open();

            command = new SQLiteCommand();
            command.Connection = connection;
        }

        public bool CreateTableWaT()
        {
            try
            {
                command.CommandText = String.Format("CREATE TABLE IF NOT EXISTS {0} (id integer primary key autoincrement,russian_word text,english_word text);", wordAndTranslationTable);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool InsertIntoTableWaT(WordAndTranslation wat)
        {
            try
            {
                command.CommandText = String.Format("INSERT INTO {0} ('russian_word','english_word') VALUES('{1}','{2}');", wordAndTranslationTable, wat.RussianWord, wat.EnglishWord);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<WordAndTranslation> SelectAllFromTableWaT()
        {
            try
            {
                List<WordAndTranslation> selected = new List<WordAndTranslation>();

                command.CommandText = String.Format("SELECT * FROM {0};", wordAndTranslationTable);
                SQLiteDataReader reader = command.ExecuteReader();

                foreach (DbDataRecord currentRow in reader)
                {
                    int id = int.Parse(currentRow["id"].ToString());
                    string russianWord = currentRow["russian_word"].ToString();
                    string englishWord = currentRow["english_word"].ToString();
                    selected.Add(new WordAndTranslation(
                        id,
                        russianWord,
                        englishWord
                    ));
                }

                return selected;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
