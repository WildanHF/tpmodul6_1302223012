using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MOD6_1302223012
{
    class Program
    {
        class SayaTubeVideo
        {
            private int id;
            private String title;
            private int playCount;


            public SayaTubeVideo(String title)
            {
                if (string.IsNullOrEmpty(title) || title.Length > 100)
                {
                    throw new ArgumentException("Title tidak boleh null dan panjangnya harus kurang dari 100", title);
                }

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
                if (playCount > 10000000)
                {
                    throw new ArgumentOutOfRangeException("playCount", "value dari playCount harus kurang dari 10.000.000 dalam pemanggilan");
                }

                try
                {

                    checked
                    {
                        this.playCount += playCount;
                    }
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Overflow occurred while increasing play count.");
                    Console.WriteLine(ex.Message);

                }
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
            /*Test untuk title lebih dari 100*/
            try
            {
                SayaTubeVideo video1 = new SayaTubeVideo("wildanwildanwildanwildanwildanwildanwildanwildanwildanwildanwildanwildanwildanwildanwildanwildanwildanwildanwildanwildan");

                video1.IncreasePlayCount(1); // Increment by 1,000,000
                video1.PrintVideoDetails();


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.Read();
            }

            /*Test string title null*/
            try
            {
                SayaTubeVideo video2 = new SayaTubeVideo(null);

                video2.IncreasePlayCount(10);

                video2.PrintVideoDetails();


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.Read();
            }


            // Test  play count >= 10.000.000
            try
            {
                SayaTubeVideo video3 = new SayaTubeVideo("Tutor Design By Contract - Wildan Hadi ");

                video3.IncreasePlayCount(1000000000); // Increment by 1,000,000

                video3.PrintVideoDetails();


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.Read();
            }

            /*Test untuk yang benar*/
            try
            {
                SayaTubeVideo video4 = new SayaTubeVideo("Tutor Design By Contract - Wildan Hadi ");
                video4.IncreasePlayCount(1); // Increment by 1,000,000
                Console.WriteLine("");
                video4.PrintVideoDetails();
                Console.Read();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

            }


        }
    }
}
 

