using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JToDo
{
    public class Data
    {
        public string content;

        public Data(string content)
        {
            this.content = content;
        }

        public void read(DataReader dataReader)
        {
            content = dataReader.GetString();
        }

        public void write(DataWriter dataWriter)
        {
            dataWriter.Put(content);
        }
    }
}
