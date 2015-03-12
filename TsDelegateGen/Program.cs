using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsDelegateGen
{
    class Program
    {
        private static string moduleName = "TypeSharp.Delegates";

        private static int actionCount = 10;

        private static int funcCount = 10;

        private static string outputFileName = "TypeSharp.Delegates.ts";

        static void Main(string[] args)
        {
            using (FileStream fs=File.OpenWrite(outputFileName))
            using(StreamWriter writer=new StreamWriter(fs))
            {
                writer.WriteLine(string.Format("module {0}{{",moduleName));
                for (int i = 0; i < actionCount; i++)
                {
                    WriteAction(i,writer);
                }
                for (int i = 0; i < funcCount; i++)
                {
                    WriteFunc(i,writer);
                }
                writer.WriteLine("}");
            }
        }

        private static void WriteAction(int argcount,StreamWriter writer)
        {
            writer.Write("\texport interface Action{0}{1}", argcount, argcount!=0?"<":"");
            for (int i = 1; i < argcount+1; i++)
            {
                writer.Write("T"+i);
                if(i!=argcount)writer.Write(",");
            }
            writer.Write("{0}\r\n\t{{\r\n", argcount!=0?">":"");
            writer.Write("\t\t(");
            for (int i = 1; i < argcount+1; i++)
            {
                writer.Write("arg" + i + ":T" + i); 
                if (i != argcount) writer.Write(",");
            }
            writer.Write("):void;");
            writer.Write("\r\n\t}\r\n\r\n\r\n");
        }

        private static void WriteFunc(int argcount, StreamWriter writer)
        {
            writer.Write("\texport interface Func{0}<", argcount);
            for (int i = 1; i < argcount + 1; i++)
            {
                writer.Write("T" + i);
                writer.Write(",");
            }
            writer.Write("R");
            writer.Write(">\r\n\t{\r\n");
            writer.Write("\t\t(");
            for (int i = 1; i < argcount + 1; i++)
            {
                writer.Write("arg" + i + ":T" + i);
                if (i != argcount) writer.Write(",");
            }
            writer.Write("):R;");
            writer.Write("\r\n\t}\r\n\r\n\r\n");
        }

    }
}
