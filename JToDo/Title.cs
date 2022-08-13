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

        public Title(DataReader dataReader)
        {
            read(dataReader);
        }

        public void read(DataReader dataReader)
        {
            title = dataReader.GetString();
        }

        public void write(DataWriter dataWriter)
        {
            dataWriter.Put(title);
        }
        public override int GetHashCode()
        {
            return title.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return title == ((Title)obj).title;
        }
    }
}
