using System;
using System.IO;
using System.Text;
using OlimpoAPI.Enums;

namespace OlimpoAPI.Middleware
{
    public class BaseLogs {
        public string DefaultLocal {get;set;} = "../../../../logs/olimpo";
        public int Status {get;set;}
        public string Mensagem{get;set;}
        public EnumTipoTrace TypeRule {get;set;}
        public void GravarTrace(){
            if (!Directory.Exists(DefaultLocal)) Directory.CreateDirectory(DefaultLocal);

            var stream = new FileStream($"{DefaultLocal}Olimpo-Gateway{DateTime.Now.ToString("yyyyMMdd")}.log",FileMode.Append);

            using (StreamWriter outputFile = new StreamWriter(stream, Encoding.UTF8)){
                outputFile.WriteLine($"[{DateTime.Now}] [{TypeRule}] [{Status}] {Mensagem}");
            }
        }
    }
}