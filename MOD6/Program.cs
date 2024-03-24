
    class Program
{
    class SayaTubeVideo
    {
        private int id;
        private String title;
        private int playCount;

        public SayaTubeVideo(String title)
        {
            this.title = title;
            this.id = GenerateUniqueId();
            this.playCount = 0;

        }
        private int GenerateUniqueId()
        {
            Random rand = new Random();
            return rand.Next(10000, 99999);
        }
        public void IncreasePlayCount(int playCount)
        {
            this.playCount += playCount;
        }
        public void PrintVideoDetails()
        {
            Console.WriteLine("Id : " + id);
            Console.WriteLine("Title : " + title);
            Console.WriteLine("Jumlah Tayangan " + playCount);
        }
    }
    static void Main(string[] args)
    {

        SayaTubeVideo satu = new SayaTubeVideo("Tutorial Design By Contract - Wildan Hadi");
        Console.Write("Ditonton : ");
        int tonton = int.Parse(Console.ReadLine());
        satu.IncreasePlayCount(tonton);
        satu.PrintVideoDetails();
        Console.ReadKey();
    }
}

