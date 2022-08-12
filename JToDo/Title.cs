using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JToDo
{
    public class Title
    {
        public string title;

        public Title(string title)
        {
            this.title = title;
        }

        public void read(DataReader dataReader)
        {
            title = dataReader.GetString();
        }

        public void write(DataWriter dataWriter)
        {
            dataWriter.Put(title);
        }
    }
}
