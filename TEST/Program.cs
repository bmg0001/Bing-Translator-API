using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator_API;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            Translate tr = new Translate(); //정의
           Console.WriteLine(tr.KR("Hello, My Name is ES Network.")); //tr.KR("번역내용");
            Console.ReadLine(); //명령대기
        }
    }
}
