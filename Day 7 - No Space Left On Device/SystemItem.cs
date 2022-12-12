using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    interface SystemItem
    {
        public string Name { get; }
        public int Size { get; }
        public Folder Parent { get; }
        void SetParent(Folder parent);

    }
   
    internal class File : SystemItem
    {
        string _name;
        public string Name { get => _name; }
        Folder _parent;
        public Folder Parent { get => _parent; }

        public int Size
        {
            get
            {
                if (Name.StartsWith("$ ls"))
                    return 0;
                return int.Parse(Name.Split(' ')[0]);
            }

        }

        public void SetParent(Folder parent)
        {
            _parent = parent;
        }

        public File(string name, Folder parent)
        {
            _name = name;
            _parent = parent;
        }
    }
    internal class Folder : SystemItem
    {
        string _name;
        public string Name { get => _name; }
        Folder _parent;
        public Folder Parent { get => _parent; }

        public List<SystemItem> Children = new();
        public int Size
        {
            get
            {
                var result = Children.Sum(x => x.Size);
                return result;
            }
        }


        public void SetParent(Folder parent)
        {
            _parent = parent;
        }

        public Folder(string name, Folder parent)
        {
            _name = name;
            _parent = parent;
        }
    }
}
