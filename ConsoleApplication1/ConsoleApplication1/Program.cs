using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Dep{
        public Dep()
        {
            //Children = new List<int>();
        }
        public int Id { get; set; }
        public string name { get; set; }
        public int Parent { set; get; }
        public List<int> Children { get; set; }

    }
    class pc
    {
        public int p; public int c;
    }
    class Program
    {
       static List<pc> pcs; static List<int> lint=new List<int>(); static List<int> lint1;static int co;
        static void Main(string[] args)
        {
            pcs = new List<pc>() { new pc { p=20,c=8}, new pc { p = 1, c = 16 }, new pc { p = 1, c = 17 }, new pc { p = 1, c = 2 }, new pc { p = 1, c = 3 }, new pc { p = 3, c = 4 }, new pc { p = 3, c = 5 }, new pc { p = 5, c = 7 }, new pc { p = 4, c = 6 }, new pc { p = 10, c = 11 }, new pc { p = 7, c = 10 },new pc { p=2,c=30} ,new pc { p = 16, c = 31 }, new pc { p = 17, c = 32 } };

            recursive(new List<int> { 2,3 });
        }
        static void recursive(List<int> _pcs)
        {
            List<pc> pp = new List<pc>();
            lint1 = new List<int>();
            foreach(int p in _pcs)
            {
               foreach(pc ppp in pcs.Where(x => x.p == p).ToList())
                {
                    lint1.Add(ppp.c); lint.Add(ppp.c);
                }
            }
            if (lint1.Count < 1)
            {
                output(lint);
            }
            recursive1(lint1);

        }

        static void recursive1(List<int> _pcs)
        {
            List<pc> pp = new List<pc>();
            lint1 = new List<int>();
            foreach (int p in _pcs)
            {
                foreach (pc ppp in pcs.Where(x => x.p == p).ToList())
                {
                    lint1.Add(ppp.c); lint.Add(ppp.c);
                }
            }
            if (lint1.Count < 1)
            {
                output(lint);
            }else
            {
            recursive1(lint1);
            }
           

        }
        static void output(List<int> i)
        {
            foreach(int ii in i)
            {
                Console.WriteLine(ii);
            }
            Console.Read();
        }
        //1

    }
}
