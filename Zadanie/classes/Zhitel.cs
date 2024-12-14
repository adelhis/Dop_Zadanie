

namespace Domashka
{
    internal class Zhitel
    {
        static private uint passport = 100000;
        public uint zhPass;
        public string name { get; set; }
        public string prob;
        public byte numProb { get; set; }
        public Temp temp {  get; set; }
        public void Next()
        {
            passport++;
        }

        public Zhitel(string name, Temp temp, string prob)
        {
            Next();
            this.zhPass = passport;
            this.name = name;
            this.prob = prob;
            this.temp = temp;
            this.numProb = GetNumProb(prob);
        }
        public void InfoPrint()
        {
            Console.WriteLine($"\nЖитель:\nИмя: {name}\nПаспорт: {zhPass}\nПроблема: {prob}\nТемперамент:\n  Скандальность - {temp.scan}\n  Ум - {temp.mind}");
        }
        private byte GetNumProb(string problem)
        {
            if (problem.Contains("подкл") || problem.Contains("отоп"))
            {
                return 1;
            }
            else if (problem.Contains("плат"))
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }


    }

    struct Temp
    {
        public byte scan;
        public byte mind;

        public Temp(byte scan, byte mind)
        {
            if (scan >= 0 && scan <= 10 && (mind == 1 || mind == 0))
            {
                this.scan = scan;
                this.mind = mind;
            }
            else
            {
                throw new ArgumentException("Данные введены неверно");
            }
        }
    }
}
