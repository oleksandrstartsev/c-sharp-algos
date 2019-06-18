using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Euler1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch dog = new Stopwatch();
            dog.Start();

            Program.LexicographicPermutations();
            dog.Stop();
            Console.WriteLine("Elapsed time = {0} ms", dog.Elapsed.TotalMilliseconds.ToString());
        }


        //Quick brute force calculation
        /// <summary>
        /// it can also be solved using just paper: nb of all multiples of 3:: 330 ... - %15==0
        /// </summary>
        #region Mutliplesof3and5
        public static void MultiplesOf3and5()
        {
            Console.WriteLine("100");
            int upperbound = 999;
            int lowerbound = 1;
            int sum = 0;

            for (int i = lowerbound; i <= upperbound; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum = sum + i;
                    Console.WriteLine("i = " + i.ToString());
                }
            }
            Console.WriteLine("Sum = " + Convert.ToString(sum));
        }
        #endregion

        #region even fibonacci
        //even fibonacci until 4M
        public static void evenFibo()
        {
            int lowerbound = 1;
            int upperbound = 4000000;
            int sum = 0;
            int i = lowerbound;
            int i1 = lowerbound;
            int i0 = lowerbound;

            while (i <= upperbound)
            {

                i1 = i + i0;
                i0 = i;
                i = i1;

                if (i1 % 2 == 0) sum = sum + i1;
                Console.WriteLine(i0.ToString() + " " + " " + i.ToString() + " " + i1.ToString() + "  :: " + sum.ToString());
            }
            Console.WriteLine("Sum = " + sum.ToString());
        }
        #endregion

        #region prime factors of some large number
        //Prime factor of some large number

        //Naive algorithm: sqrt of a number as an upper limit for a prime nb factor

        public static void PrimeFactorNaive()
        {
            //System.Int64 number = 600851475143;13195;
            const System.Int64 number0 = 600851475143; //save it to check the result later;
            System.Int64 number = number0; // this variable will be reduced every time when a prime factor is found;
            System.Int64 checknumber = 1; // alternative check for the nb;
            List<Int64> lst = new List<Int64>(); // save prime factors to the list;


            //the largest prime factor of the number should not exceed it sqrt.
            System.Int64 upperbound = (Int64)Math.Floor(Math.Sqrt(number));
            Console.Write(System.Environment.NewLine + "sq root // upper bound = " + upperbound.ToString());

            bool prime = true;
            for (Int64 i = 2; i <= upperbound; i++)
            {
                System.Int64 primefactor = 0;
                if (number % i == 0)
                {
                    prime = true;
                    for (Int64 j = 2; j < i; j++)
                    { if (i % j == 0) { prime = false; break; }
                    }
                    if (prime == true)
                    { number = number / i; primefactor = i;
                        checknumber = checknumber * primefactor;
                        lst.Add(primefactor);
                        Console.WriteLine(System.Environment.NewLine + "prime factor = " + primefactor.ToString());
                        Console.WriteLine("\n number = " + number.ToString() + " checknumber = " + checknumber.ToString());

                    }


                }
            }

            //Check if the prime factors actually correspond to the number;
            if (checknumber == number0) Console.WriteLine("\n Yes" + " " + number0.ToString() + " " + checknumber.ToString());
            else Console.WriteLine("\n No" + " " + number0.ToString() + " " + checknumber.ToString());

            //let's print all prime factors of the number with respect to their nb in a list;
            for (int i = 0; i <= lst.Count - 1; i++)
                Console.WriteLine("list id = " + i.ToString() + " , nb = " + lst[i].ToString());
        }

        #endregion

        #region Largest Prime Number
        public static void LargestPrimeNumber()
        {
            //System.Int64 number = 600851475143;13195;
            const System.Int64 number0 = 600851475143; //save it to check the result later;
            System.Int64 number = number0; // this variable will be reduced every time when a prime factor is found;
            System.Int64 checknumber = 1; // alternative check for the nb;
            List<Int64> lst = new List<Int64>(); // save prime factors to the list;
            Random rnd = new Random();

            //the largest prime factor of the number should not exceed it sqrt.
            System.Int64 upperbound = (Int64)Math.Floor(Math.Sqrt(number));
            Console.Write(System.Environment.NewLine + "sq root // upper bound = " + upperbound.ToString());

            bool prime = true;
            for (Int64 i = 2; i <= upperbound; i++)
            {
                System.Int64 primefactor = 0;
                if (number % i == 0)
                {
                    prime = true;

                    //R

                    //for (int64 j = 2; j < i; j++)
                    //{
                    //    if (i % j == 0) { prime = false; break; }
                    //}

                    //Fermat's 
                    for (int j = 0; j < 4; j++)
                    {
                        Int64 a = rnd.Next(2, (int)i - 1);
                        //    if(Math.Pow(a, ))
                    }

                    if (prime == true)
                    {
                        number = number / i; primefactor = i;
                        checknumber = checknumber * primefactor;
                        lst.Add(primefactor);
                        Console.WriteLine(System.Environment.NewLine + "prime factor = " + primefactor.ToString());
                        Console.WriteLine("\n number = " + number.ToString() + " checknumber = " + checknumber.ToString());

                    }


                }
            }

            //Check if the prime factors actually correspond to the number;
            if (checknumber == number0) Console.WriteLine("\n Yes" + " " + number0.ToString() + " " + checknumber.ToString());
            else Console.WriteLine("\n No" + " " + number0.ToString() + " " + checknumber.ToString());

            //let's print all prime factors of the number with respect to their nb in a list;
            for (int i = 0; i <= lst.Count - 1; i++)
                Console.WriteLine("list id = " + i.ToString() + " , nb = " + lst[i].ToString());

        }
        #endregion

        #region Largest palindrome product
        public static void LargestPalindromeProduct()
        {
            int limit = 1000000;
            string s = "";
            int palindrom = 0;
            for (int i = limit - 1; i >= 10000; i--)
            {
                s = i.ToString();
                bool flag = true;
                int l = (int)s.Length / 2;
                for (int j = 0; j <= l; j++)
                    if (s[j] != s[s.Length - 1 - j]) flag = false;
                if (flag)
                {
                    flag = false;
                    for (int h = 999; h >= 100; h--)
                        if (i % h == 0 && palindrom < i && (i / h).ToString().Length < 4)
                        { palindrom = i;
                            Console.WriteLine(" palindrom = " + palindrom.ToString() + " : " + h.ToString() + " x " + (i / h).ToString());
                        }



                }
            }
            Console.WriteLine("palindrom = " + palindrom.ToString());



        }
        #endregion

        #region Smallest Multiple  //very extensive - it is better to use arrays of primes for each number;
        static void SmallestMultiple()
        {
            int[] a = new int[50];

            //lets fill the array 1..20
            for (int k = 1; k <= a.Length; k++)
            {
                a[k - 1] = k;
                Console.WriteLine(a[k - 1]);
            }
            bool success = false;
            int i = a[a.Length - 1] * a[a.Length - 2];
            while (success is false)
            {
                bool divide = true;
                for (int j = 0; j <= a.Length - 1; j++)
                {
                    if (i % a[j] != 0) { divide = false; break; }

                }
                if (divide) { Console.WriteLine("Found Least Common Multiplier :: " + i.ToString());
                    success = true;
                    break; }
                if (!divide) ++i;
            }
        }
        #endregion


        #region Smallest Multiple  //prime factorization applied here;
        static void SmallestMultipleAdvanced()
        {
            int[] a = new int[20];

            //lets fill the array 1..20
            for (int k = 1; k <= a.Length; k++)
            {
                a[k - 1] = k;
                //Console.WriteLine(a[k - 1]);
            }

            int[] series = primeseries(20);
            Console.WriteLine(" prime series of {0} is: {1}", 20.ToString(), string.Join(" ", series));

            int[] factors;
            int[] coef = new int[series.Length];
            for (int k = 0; k <= a.Length - 1; k++)
            {

                factors = factorize(a[k]);
                Console.WriteLine(" nb {0} contains: {1}", a[k].ToString(), string.Join(" ", factors));

                for (int g = 0; g < series.Length; g++)
                {
                    int coefNb = 0;
                    for (int p = 0; p < factors.Length; p++)
                        if (series[g] == factors[p]) coefNb += 1;

                    if (coef[g] < coefNb) coef[g] = coefNb;
                }


            }
            Console.WriteLine("coef : " + string.Join(" ", coef));

            double lcm = 1;
            for (int g = 0; g < series.Length; g++)
            {
                lcm *= Math.Pow(series[g], coef[g]);
            }

            Console.WriteLine("LCM = " + lcm);

            //calculate primes in the range 1..b;
            int[] primeseries(int b)
            {
                int c = b;
                List<int> primes = new List<int>();

                if (b > 0)
                {
                    if (b >= 1) primes.Add(1);
                    if (b >= 2) primes.Add(2);
                    if (b >= 3)
                    {

                        for (int m = 3; m <= b; m += 2)
                        {
                            bool flag = true;
                            for (int jj = 2; jj < m; jj++)
                                if (m % jj == 0) flag = false;
                            if (flag) primes.Add(m);
                        }

                    }
                    //Console.WriteLine(" prime series of {0} is: {1}", b.ToString(), string.Join(" ",primes.ToArray())) ;
                }
                return primes.ToArray();

            }

            int[] factorize(int b)
            {
                int c = b;
                List<int> primes = new List<int>();

                if (b >= 2)
                { int h = 2;

                    primes.Add(1);
                    while (h <= b & b != 1)
                    {
                        if (b % h == 0)
                        {
                            primes.Add(h);
                            b /= h;

                        }
                        else ++h;
                    }

                }
                else { primes.Add(1); }

                //Console.WriteLine(System.Environment.NewLine + " nb =  "+ c.ToString() +" :: "+ string.Join(" ",primes.ToArray()));
                return primes.ToArray();
            }

        }
        #endregion

        #region sum difference
        public static void SumSqDiff()
        {

            int lowerbound = 1;
            int upperbound = 100;
            double sum = 0;

            for (int i = lowerbound; i <= upperbound; i++)
            {
                sum = sum + i * i;

            }
            Console.WriteLine(" 1^2 :: " + sum.ToString());
            sum = ((upperbound + lowerbound) * upperbound / 2.0) * ((upperbound + lowerbound) * upperbound / 2.0) - sum;

            Console.WriteLine(" sum diff = " + sum.ToString());

            //Or just simplify the formula (manually, or in WM), which results in
            // 0.25*(-1+1-100)^2  * (1+100)^2 + (1/6)*(-1 + 1 -100 )*(-1 +2*1^2+100+ 2 * 1 * 100 + 2 * 100^2 )
        }
        #endregion

        #region prime generator: Not optimized, very simple
        public static void primegen()
        {
            primeseries(10001);

            int[] primeseries(int b)
            {

                List<int> primes = new List<int>();

                if (b > 0)
                {
                    if (b >= 1) primes.Add(2);
                    if (b >= 3)
                    {

                        for (int m = 3; primes.Count < b; m += 2)
                        {
                            bool flag = true;
                            for (int jj = 2; jj < m; jj++)
                                if (m % jj == 0) flag = false;
                            if (flag) primes.Add(m);
                        }

                    }
                    Console.WriteLine(" prime series of {0} is: {1}", b.ToString(), string.Join(" ", primes.ToArray()));
                }
                return primes.ToArray();

            }
        }
        #endregion

        #region Largest product in a series
        static void LargestProductSeries()
        {
            string number =
                "73167176531330624919225119674426574742355349194934" +
"96983520312774506326239578318016984801869478851843" +
"85861560789112949495459501737958331952853208805511" +
"12540698747158523863050715693290963295227443043557" +
"66896648950445244523161731856403098711121722383113" +
"62229893423380308135336276614282806444486645238749" +
"30358907296290491560440772390713810515859307960866" +
"70172427121883998797908792274921901699720888093776" +
"65727333001053367881220235421809751254540594752243" +
"52584907711670556013604839586446706324415722155397" +
"53697817977846174064955149290862569321978468622482" +
"83972241375657056057490261407972968652414535100474" +
"82166370484403199890008895243450658541227588666881" +
"16427171479924442928230863465674813919123162824586" +
"17866458359124566529476545682848912883142607690042" +
"24219022671055626321111109370544217506941658960408" +
"07198403850962455444362981230987879927244284909188" +
"84580156166097919133875499200524063689912560717606" +
"05886116467109405077541002256983155200055935729725" +
"71636269561882670428252483600823257530420752963450";

            decimal product = 1;
            decimal maxproduct = 0;
            int adj = 13;
            string g = "";
            string gmax = "";

            for (int i = 0; i < number.Length - 1 - adj; i++)
            {
                product = 1; g = "";
                for (int j = i; j < i + adj; j++) {
                    product *= Convert.ToInt32(number[j].ToString());
                    g = g + number[j];
                }
                if (maxproduct < product) { maxproduct = product; gmax = g; }
            }

            Console.WriteLine("max product : " + maxproduct.ToString() + " " + gmax);
            for (int i = 0; i < gmax.Length; i++)
            {
                Console.WriteLine(" {0} :  {1} ", gmax[i], Int32.Parse(gmax[i].ToString()));
            }

        }
        #endregion

        #region Special Pythagorean triplet
        //it can be also optimized in WM 
        //Reduce[{a^2 + b^2 == c^2, a + b + c == 1000, a > 0, b > 0, c > 0}, {a, b, c }, Integers]
        //(a == 200 && b == 375 && c == 425) || (a == 375 && b == 200 && c == 425)

        static void PythagoreanTriplet()
        {
            int a, b, c;

            int product;

            for (int i = 1; i < 998; i++)
                for (int j = 1; j < 998; j++)
                {
                    if (i * i + j * j == (i + j - 1000) * (i + j - 1000))
                    {
                        a = i;
                        b = j;
                        c = 1000 - a - b;
                        product = a * b * c;
                        Console.WriteLine("{0} , {1}, {2}, {3}", a, b, c, product);
                    }
                }

        }
        #endregion

        #region Summation of primes
        public static void SumOfPrimes()
        {

            long i, j, sum = 17;
            bool flag = true;
            for (i = 2; i < 2000000; i++)
            {
                if ((i % 2) != 0 && (i % 3) != 0 && (i % 5) != 0 && (i % 7) != 0)
                {
                    flag = true;
                    for (j = 2; j <= Math.Sqrt(i); j++)
                    {
                        if (i % j == 0)
                        {
                            flag = false;
                        }
                    }
                    if (flag == true)
                    {
                        sum = sum + i;
                    }
                }

            }
            Console.WriteLine(sum);




        }
        #endregion

        #region 20x20 diagonals
        static void Sum20x20()
        {
            string number = "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08 " +
"49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00 " +
"81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65 " +
"52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91 " +
"22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80 " +
"24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50 " +
"32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70 " +
"67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21 " +
"24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72 " +
"21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95 " +
"78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92 " +
"16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57 " +
"86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58 " +
"19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40 " +
"04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66 " +
"88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69 " +
"04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36 " +
"20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16 " +
"20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54 " +
"01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48     ";


            string[] a;
            int[,] b = new int[21, 21];
            a = number.Split((char)32);
            //Parse and fill in;
            for (int i = 0; i < a.Length; i++)
            {
                int remainder;
                int flag;
                int quotient = Math.DivRem(i, 20, out remainder);
                if ((a[i].Trim().Length > 0) & Int32.TryParse(a[i].ToString(), out flag))
                {
                    b[quotient, remainder] = Convert.ToInt32(a[i].ToString());
                    //Console.WriteLine("{0},{1} : {2} ", quotient, remainder, b[quotient, remainder]);

                }

            }

            printmatrix();

            //print matrix;
            void printmatrix()
            {
                Console.WriteLine(System.Environment.NewLine);
                for (int i = 0; i < b.GetUpperBound(0); i++)
                {
                    string s = "";
                    for (int j = 0; j < b.GetUpperBound(1); j++)
                        if (b[i, j].ToString().Length == 1) s += "0" + b[i, j] + " "; else
                            s += b[i, j] + " ";
                    Console.WriteLine(s);
                }
                Console.WriteLine(System.Environment.NewLine);
            }

            int product, maxproduct;
            maxproduct = 0;
            string maxproductstr = "";

            //Let's calculate Up-Down 4 adjacent nb product;
            for (int i = 0; i < b.GetUpperBound(0); i++)
            {
                product = 1;

                for (int j = 0; j < b.GetUpperBound(1); j++)
                {

                    //horizontal
                    if (j < b.GetUpperBound(1) - 3)
                    { product = b[i, j] * b[i, j + 1] * b[i, j + 2] * b[i, j + 3];
                        if (product > maxproduct) { maxproduct = product;
                            maxproductstr = b[i, j].ToString() + " " + b[i, j + 1].ToString() + " " + b[i, j + 2].ToString() + " " + b[i, j + 3].ToString(); }
                    }

                    //vertical
                    if (i < b.GetUpperBound(0) - 3)
                    {
                        product = b[i, j] * b[i + 1, j] * b[i + 2, j] * b[i + 3, j];
                        if (product > maxproduct)
                        {
                            maxproduct = product;
                            maxproductstr = b[i, j].ToString() + " " + b[i + 1, j].ToString() + " " + b[i + 2, j].ToString() + " " + b[i + 3, j].ToString();
                        }
                    }

                    //major diagonal
                    if (j < b.GetUpperBound(1) - 3 && i < b.GetUpperBound(0) - 3)
                    {
                        product = b[i, j] * b[i + 1, j + 1] * b[i + 2, j + 2] * b[i + 3, j + 3];
                        if (product > maxproduct)
                        {
                            maxproduct = product;
                            maxproductstr = b[i, j].ToString() + " " + b[i + 1, j + 1].ToString() + " " + b[i + 2, j + 2].ToString() + " " + b[i + 3, j + 3].ToString();
                        }
                    }

                    //minor diagonal
                    if (j < b.GetUpperBound(1) - 3 && i < b.GetUpperBound(0) - 3 && i >= 3)
                    {
                        product = b[i, j] * b[i - 1, j + 1] * b[i - 2, j + 2] * b[i - 3, j + 3];
                        if (product > maxproduct)
                        {
                            maxproduct = product;
                            maxproductstr = b[i, j].ToString() + " " + b[i - 1, j + 1].ToString() + " " + b[i - 2, j + 2].ToString() + " " + b[i - 3, j + 3].ToString();
                        }
                    }

                }
            }
            Console.WriteLine("max product : {0} as {1} h,v", maxproduct, maxproductstr);


        }
        #endregion

        #region Highly divisible triangular number
        static void HighlyDivTriangularNumber()
        {
            int target = 500;
            int nbdivisors = 0;

            int seed = 1;

            int counttries = 0;

            Console.WriteLine(" seed {0}", seed);

            while (nbdivisors != target)
            {
                seed = (int)(1 + counttries) * counttries / 2;
                nbdivisors = nbdiv(seed);
                if (nbdivisors > target) break; else ++counttries;
                Console.WriteLine(" seed {0} : divs {1}", seed, nbdivisors);
            }


            Console.WriteLine("Success: {0} , {1}", seed, nbdivisors);

            int nbdiv(int a)
            {
                int divcount = 2;//iself and 1;
                if (a >= 2)
                {
                    for (int j = 2; j <= (int)Math.Sqrt(a); j++) //w/o 1066114,4835 ms :: optimized 4685,4624 ms
                    { if (a % j == 0)
                        {
                            //Console.WriteLine("{0} : {1}", a, j);
                            divcount += 2;

                        } }
                }

                return divcount; }

        }
        #endregion

        #region Work out the first ten digits of the sum of the following one-hundred 50-digit numbers.
        static void dig50()
        {
            string s = "37107287533902102798797998220837590246510135740250" +
"46376937677490009712648124896970078050417018260538" +
"74324986199524741059474233309513058123726617309629" +
"91942213363574161572522430563301811072406154908250" +
"23067588207539346171171980310421047513778063246676" +
"89261670696623633820136378418383684178734361726757" +
"28112879812849979408065481931592621691275889832738" +
"44274228917432520321923589422876796487670272189318" +
"47451445736001306439091167216856844588711603153276" +
"70386486105843025439939619828917593665686757934951" +
"62176457141856560629502157223196586755079324193331" +
"64906352462741904929101432445813822663347944758178" +
"92575867718337217661963751590579239728245598838407" +
"58203565325359399008402633568948830189458628227828" +
"80181199384826282014278194139940567587151170094390" +
"35398664372827112653829987240784473053190104293586" +
"86515506006295864861532075273371959191420517255829" +
"71693888707715466499115593487603532921714970056938" +
"54370070576826684624621495650076471787294438377604" +
"53282654108756828443191190634694037855217779295145" +
"36123272525000296071075082563815656710885258350721" +
"45876576172410976447339110607218265236877223636045" +
"17423706905851860660448207621209813287860733969412" +
"81142660418086830619328460811191061556940512689692" +
"51934325451728388641918047049293215058642563049483" +
"62467221648435076201727918039944693004732956340691" +
"15732444386908125794514089057706229429197107928209" +
"55037687525678773091862540744969844508330393682126" +
"18336384825330154686196124348767681297534375946515" +
"80386287592878490201521685554828717201219257766954" +
"78182833757993103614740356856449095527097864797581" +
"16726320100436897842553539920931837441497806860984" +
"48403098129077791799088218795327364475675590848030" +
"87086987551392711854517078544161852424320693150332" +
"59959406895756536782107074926966537676326235447210" +
"69793950679652694742597709739166693763042633987085" +
"41052684708299085211399427365734116182760315001271" +
"65378607361501080857009149939512557028198746004375" +
"35829035317434717326932123578154982629742552737307" +
"94953759765105305946966067683156574377167401875275" +
"88902802571733229619176668713819931811048770190271" +
"25267680276078003013678680992525463401061632866526" +
"36270218540497705585629946580636237993140746255962" +
"24074486908231174977792365466257246923322810917141" +
"91430288197103288597806669760892938638285025333403" +
"34413065578016127815921815005561868836468420090470" +
"23053081172816430487623791969842487255036638784583" +
"11487696932154902810424020138335124462181441773470" +
"63783299490636259666498587618221225225512486764533" +
"67720186971698544312419572409913959008952310058822" +
"95548255300263520781532296796249481641953868218774" +
"76085327132285723110424803456124867697064507995236" +
"37774242535411291684276865538926205024910326572967" +
"23701913275725675285653248258265463092207058596522" +
"29798860272258331913126375147341994889534765745501" +
"18495701454879288984856827726077713721403798879715" +
"38298203783031473527721580348144513491373226651381" +
"34829543829199918180278916522431027392251122869539" +
"40957953066405232632538044100059654939159879593635" +
"29746152185502371307642255121183693803580388584903" +
"41698116222072977186158236678424689157993532961922" +
"62467957194401269043877107275048102390895523597457" +
"23189706772547915061505504953922979530901129967519" +
"86188088225875314529584099251203829009407770775672" +
"11306739708304724483816533873502340845647058077308" +
"82959174767140363198008187129011875491310547126581" +
"97623331044818386269515456334926366572897563400500" +
"42846280183517070527831839425882145521227251250327" +
"55121603546981200581762165212827652751691296897789" +
"32238195734329339946437501907836945765883352399886" +
"75506164965184775180738168837861091527357929701337" +
"62177842752192623401942399639168044983993173312731" +
"32924185707147349566916674687634660915035914677504" +
"99518671430235219628894890102423325116913619626622" +
"73267460800591547471830798392868535206946944540724" +
"76841822524674417161514036427982273348055556214818" +
"97142617910342598647204516893989422179826088076852" +
"87783646182799346313767754307809363333018982642090" +
"10848802521674670883215120185883543223812876952786" +
"71329612474782464538636993009049310363619763878039" +
"62184073572399794223406235393808339651327408011116" +
"66627891981488087797941876876144230030984490851411" +
"60661826293682836764744779239180335110989069790714" +
"85786944089552990653640447425576083659976645795096" +
"66024396409905389607120198219976047599490197230297" +
"64913982680032973156037120041377903785566085089252" +
"16730939319872750275468906903707539413042652315011" +
"94809377245048795150954100921645863754710598436791" +
"78639167021187492431995700641917969777599028300699" +
"15368713711936614952811305876380278410754449733078" +
"40789923115535562561142322423255033685442488917353" +
"44889911501440648020369068063960672322193204149535" +
"41503128880339536053299340368006977710650566631954" +
"81234880673210146739058568557934581403627822703280" +
"82616570773948327592232845941706525094512325230608" +
"22918802058777319719839450180888072429661980811197" +
"77158542502016545090413245809786882778948721859617" +
"72107838435069186155435662884062257473692284509516" +
"20849603980134001723930671666823555245252804609722" +
"53503534226472524250874054075591789781264330331690";


            //System.Numerics.BigInteger max = 0;

            //for (int i = 0; i < 100; i++)
            //{
            //    max += System.Numerics.BigInteger.Parse(s.Substring(i * 50, 50));
            //}

            //string b = max.ToString();
            //Console.WriteLine("The answer is " + b);

            s = "97107287533902102798797998220837590246510135740250" +
"96376937677490009712648124896970078050417018260538" +
"96376937677490009712648124896970078050417018260538";


            byte[,] t = new byte[3, 50];
            for (int i = 0; i <= t.GetUpperBound(0); i++)
            {

                for (int j = 0; j <= t.GetUpperBound(1); j++)
                {
                    int index = i * 50 + j;

                    t[i, j] = Convert.ToByte(s.Substring(index, 1));

                }

            }


            printarray(t);

            //Let's calculate the sum;
            int[] number = new int[53];

            int localsum = 0;

            string localsumstring = "";
            int memory = 0;

            for (int j = t.GetUpperBound(1); j >= 0; j--)
            {
                localsum = 0; localsumstring = "";
                for (int i = 0; i <= t.GetUpperBound(0); i++)
                {
                    localsum += t[i, j];
                }
                localsum += memory; memory = 0;
                Console.WriteLine(j.ToString() + ":: " + localsum.ToString());


                //localsum = 999;
                localsumstring = localsum.ToString();
                int size = localsumstring.Length - 1;
                if (size >= 0)
                    number[j + 3] += Convert.ToByte(localsumstring.Substring(size, 1));
                if (size >= 1)
                    memory = Convert.ToInt16(localsumstring.Substring(0, size));

                Console.WriteLine("memory =" + memory);



            }

            if (memory != 0)
            {
                string memorystr = memory.ToString();
                int memorysize = memorystr.Length;
                for (int p = 0; p < memorysize; p++)
                    number[2 - p] = Convert.ToByte(memorystr.Substring(p, 1));
            }

            print1darray(number);

            void printarray(byte[,] a)
            { string str;
                Console.WriteLine(System.Environment.NewLine);
                for (int i = 0; i <= a.GetUpperBound(0); i++)
                { str = "";
                    for (int j = 0; j <= a.GetUpperBound(1); j++)
                        str += a[i, j].ToString();
                    Console.WriteLine(str);
                }
            }

            void print1darray(int[] tutti)
            {
                string str;
                Console.WriteLine(System.Environment.NewLine + " size :: " + tutti.Length);
                str = "";
                for (int i = 0; i <= tutti.GetUpperBound(0); i++)
                { str += tutti[i].ToString();
                    Console.WriteLine(" i {0} : {1}", i, tutti[i]);
                }
                Console.WriteLine(str);

            }

        }
        #endregion

        #region Longest Collatz sequence
        static void Collatz()
        {
            int maxstopping = 0;
            int maxstoppingnb = 0;
            int stopping = 0;
            //Console.WriteLine(2%2==0);

            for (int i = 999999; i > 2; i--)
            {

                stopping = 0;
                Int64 nb = i;
                if (nb != 2) stopping += 1;
                if (nb == 1) stopping = 1;

                while (nb != 1)
                {

                    if (nb % 2 == 0) { nb = Convert.ToInt64(nb / 2); ++stopping; }
                    else { nb = 3 * nb + 1; ++stopping; }

                    //Console.WriteLine(" {0}: {1}, {2}", i, nb, stopping);
                    if (nb == 1) {
                        if (maxstopping < stopping) { maxstopping = stopping;
                            maxstoppingnb = i;

                        }
                        //Console.WriteLine(" {0}: {1} ", i, stopping);
                        //Console.WriteLine(" max stopping : {0} ", maxstopping);

                        break; }
                }

            }

            Console.WriteLine("max stopping {0} at {1}", maxstopping, maxstoppingnb);

        }
        #endregion

        #region Lattice paths
        static void Lattice2020()
        {
            int n = 20;
            System.Numerics.BigInteger number = 1;
            for (int i = 2 * n; i >=1; i--)
            {
                if (i <= n) number /= i; else number *= i; 
                
            }
            //for (int i = 1; i <= n; i++)
            //    number /= (i * i);
            Console.WriteLine(number);
            
        }
        #endregion

        #region Power digit //Slightly cheating with BigInteger :)
        static void PowerDigit()
        {
            System.Numerics.BigInteger nb = 0;
            nb = (System.Numerics.BigInteger)Math.Pow(2, 1000);
            string s = nb.ToString();
            Int64 sum = 0;
            for (int i = 0; i < s.Length; i++)
                sum += Convert.ToInt32(s.Substring(i, 1));

            Console.WriteLine(nb);
            Console.WriteLine(sum);
        }
        #endregion

        #region Maximum path sum I
        static void maxpathsum1()
        {
            string s = "75" +                    //0,2
"95 64" +                                        //2,2+2+3
"17 47 82" +                                     //2+2+3,2+2+3+3
"18 35 87 10" +
"20 04 82 47 65" +
"19 01 23 75 03 34" +
"88 02 77 73 07 63 67" +
"99 65 04 28 06 16 70 92" +
"41 41 26 56 83 40 80 70 33" +
"41 48 72 33 47 32 37 16 94 29" +
"53 71 44 65 25 43 91 52 97 51 14" +
"70 11 33 28 77 73 17 78 39 68 17 57" +
"91 71 52 38 17 14 91 43 58 50 27 29 48" +
"63 66 04 68 89 53 67 30 73 16 69 87 40 31" +
"04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

            string[] ss = new string[15];
            int[][] number = new int[15][];
            int index = 0;
            // parse
            for (int i = 0; i < ss.Length; i++)
            {
                ss[i] = s.Substring(index, 2 + 3 * i);
                index += 2 + 3 * i;

                int size = (int)(ss[i].Split(" ").Length);
                //Console.WriteLine(i.ToString() + " : " + ss[i].ToString()+ "   , "+size);

                number[i] = new int[size];
                number[i] = Array.ConvertAll(ss[i].Split(" "), int.Parse);
                string printing = "";
                for (int j = 0; j < size; j++)
                {
                    printing += number[i][j] + " ";
                }
                Console.WriteLine(i + "::  " + printing);
            }

            // calculate
            int candidate = 0;
            int[][] nb = (int[][])number.Clone();
            for(int i = number.GetUpperBound(0)-1; i>=0;i-- )
            {
                candidate = 0; 
                for(int j = 0; j<=number[i].GetUpperBound(0);j++)
                {
                    //if( (j==0 || j == number[i].GetUpperBound(0))&&i< number.GetUpperBound(0))
                    candidate = Math.Max(number[i][j] + number[i + 1][j], number[i][j] + number[i + 1][j+1]);
                    //if (j > 0 && j < number[i].GetUpperBound(0) && i < number.GetUpperBound(0))
                    //{
                    //    candidate = Math.Max(number[i][j] + number[i + 1][j], number[i][j] + number[i + 1][j + 1]);
                    //    //candidate = Math.Max(number[i][j] + number[i + 1][j-1], candidate);
                    //}
                   
                    nb[i][j] = candidate;

                }
            }

            string str = "";
            for (int i = 0; i <= nb.GetUpperBound(0); i++)

            {
                str = "";
                for (int j = 0; j <= nb[i].GetUpperBound(0); j++)

                    str += number[i][j] + " ";

                Console.WriteLine(i + "::  " + str);
            }
            
        

    }
        #endregion

        #region Counting Sundays
        static void Sundays()
        {
            int sundays = 0;
            for(int i = 1901; i <=2000; i++)
                for(int j = 1; j<=12; j++)
                {
                    if (new DateTime(i, j, 1).DayOfWeek == DayOfWeek.Sunday)
                        sundays++;
                    Console.WriteLine("nb of Sundays is " + sundays);
                }

        }
        #endregion

        #region Amicable numbers :: d(a) = b & d(b) = a
        static void Amicable()
        {
            int limit = 10000;
            int sumofamicables = 0;

            for (int u = 2; u < limit; u++)
            {
                int result1 = amicable(u);
                int result2 = amicable(result1);

               if(u == result2 && result1<limit && u!=result1)
                {
                    sumofamicables += u;
                    Console.WriteLine("amicable pair {0}, {1}", u, result1);
                }
                
                
            }
            Console.WriteLine("Sum of amicables: " + sumofamicables);

            int amicable(int g)
            {
                int sumofdividers = 0;
                int sqlimit = (int)Math.Floor(Math.Sqrt(g));
                int[] series = primeseries(sqlimit);
                List<int> divisors = new List<int>();




                //Console.WriteLine("array:: "+string.Join(" ", series));
                //Console.WriteLine(" list:: " + string.Join(" ", divisors));


                divisors.AddRange(optimizedividers(series, g));
                //Console.WriteLine("divisors list of {0}  in {1}", limit, string.Join(" ", divisors));
                sumofdividers = summing(divisors.ToArray());
               // Console.WriteLine(" nb : {0}, sum {1}", g, sumofdivisors);
                return sumofdividers;
            }

            int[] optimizedividers(int[] b, int c)
            {
                List<int> dividerslist = new List<int>();
                
                foreach (int i in b)
                {
                    if (c % i == 0) dividerslist.Add(i);

                }

                List<int> divisorslistupdated = new List<int>(dividerslist);
                foreach (int i in divisorslistupdated)
                {
                   foreach(int j in divisorslistupdated)
                    {
                        if (i * j < c && c % (i * j) == 0 && !dividerslist.Contains(i*j)) dividerslist.Add(i * j);
                        
                    }

                        for(int k = 1; k <=c / i; k++)
                        {
                        if (c % (k * i) == 0 && k*i!=c &&!dividerslist.Contains(k * i)) dividerslist.Add(k * i);
                        }
                }
                
                return dividerslist.ToArray();
            }

            
            
            int summing(int[] a)
            {
                int sum = 0;
                foreach (int i in a) sum += i;
                return sum;
            }
         

            //calculate primes in the range 1..b; But 1 is not a prime!
            int[] primeseries(int b)
            {
                int c = b;
                List<int> primes = new List<int>();

                if (b > 0)
                {
                    if (b >= 1) primes.Add(1);
                    if (b >= 2) primes.Add(2);
                    if (b >= 3)
                    {

                        for (int m = 3; m <= b; m += 2)
                        {
                            bool flag = true;
                            for (int jj = 2; jj < m; jj++)
                                if (m % jj == 0) flag = false;
                            if (flag) primes.Add(m);
                        }

                    }
                    //Console.WriteLine(" prime series of {0} is: {1}", b.ToString(), string.Join(" ",primes.ToArray())) ;
                }
                return primes.ToArray();

            }

            


        }
        #endregion

        #region Names sort
        static void NamesSort()
        {
            string filepath = @"K:\SharpWorkspace\training-intro\Euler1\Euler1\p022_names.txt";
            string FileText = "";
            bool process = false;
            if (System.IO.File.Exists(filepath)) process = true; else { process = false;
                Console.WriteLine(" file {0} does not exist. ", filepath);
            }
            if (process) { FileText = System.IO.File.ReadAllText(filepath);

                Console.WriteLine(" file {0} exists. ", filepath);
                // Console.WriteLine(System.Environment.NewLine + FileText);

                string[] names = FileText.Split(",");
                if (names.Length > 0)
                {
                    for (int i = 0; i < names.Length; i++)
                    {
                        names[i] = names[i].Trim('"');

                    }
                }

                MergeSort2(names); //Perform merge sort testing faster solution by MATHBLOG

                Console.WriteLine(" now array is :{0}", string.Join(" ", names));
                Console.WriteLine(System.Environment.NewLine);

                int finalSum = 0;

                
                for(int i = 0; i<names.Length; i++)
                {
                    finalSum += (i + 1) * sum(names[i]);

                }
                Console.WriteLine("Final Sum is :: " + finalSum);

               
                             
                
                //Summing method for string: this tweaked approach of MathBlog is much better
                 int sum(string name) 
                {
                    int result = 0;
                    for (int i = 0; i < name.Length; i++)
                        //this approach is much faster - directly obtain alph. position
                        // 64 is position of A in ascii table.
                        //Be careful if interpolate for others.
                        result += Convert.ToInt32(name[i]) - 64;
                    return result;
                }

                //Can be used this method, or any alternative
                bool CompareStrings(string str1, string str2)
                {
                    int i = 0;
                    while (i <str1.Length && i < str2.Length) {
                    if (str1[i] == str2[i])
                    {
                        i++;
                    }
                    else
                    {
                        return str1[i] < str2[i];
                    }
                }
                return str1.Length <= str2.Length;
            }

            string[] MergeSort2(string[] strings)
                {
                    if (strings.Length<= 1) {
                    return strings;
                }

                int firstPart = strings.Length / 2;
                string[] strings1 = new string[firstPart];
                string[] strings2 = new string[strings.Length - firstPart];

                string[] sorted = new string[strings.Length];

                // Split the array into two;
                for (int i = 0; i < firstPart; i++) {
                    strings1[i] = strings[i];
                }

                for (int i = firstPart; i <strings.Length; i++) {
                    strings2[i - firstPart] = strings[i];
                }

                strings1 = MergeSort2(strings1);
                strings2 = MergeSort2(strings2);

                int j = 0;
                int k = 0;

                for (int i = 0; i < sorted.Length; i++) {
                    if (j == strings1.Length)
                    {
                        sorted[i] = strings2[k];
                        k++;
                    }
                    else if (k == strings2.Length)
                    {
                        sorted[i] = strings1[j];
                        j++;
                    }
                    else if (CompareStrings(strings1[j], strings2[k]))
                    {
                        sorted[i] = strings1[j];
                        j++;
                    }
                    else
                    {
                        sorted[i] = strings2[k];
                        k++;
                    }
                }

                return sorted;
            }

            //Quite probable to 
            
            }
                
        }
        #endregion

        #region some sorting algorithms to remaind
        //#region Bubble sort: N(N-1) complexity;

        //public int[] BubbleSort()
        //{
        //    for (int i = 0; i <= Arr1.Length - 1; i++)
        //        for (int j = 0; j <= Arr1.Length - 2; j++)
        //        {

        //            if (Arr1[i] < Arr1[j])
        //            {
        //                Arr1[i] = Arr1[i] + Arr1[j];
        //                Arr1[j] = Arr1[i] - Arr1[j];
        //                Arr1[i] = Arr1[i] - Arr1[j];
        //            }
        //        }
        //    return Arr1;
        //}
        //#endregion

        //#region Insertion Sort;

        //public int[] InsertionSort()
        //{
        //    int n = Arr1.Length;
        //    for (int i = 1; i < n; ++i)
        //    {
        //        int key = Arr1[i];
        //        int j = i - 1;

        //        // Move elements of arr[0..i-1], 
        //        // that are greater than key, 
        //        // to one position ahead of 
        //        // their current position 
        //        while (j >= 0 && Arr1[j] > key)
        //        {
        //            Arr1[j + 1] = Arr1[j];
        //            j = j - 1;
        //        }
        //        Arr1[j + 1] = key;
        //    }
        //    return Arr1;
        //}
        //#endregion

        //#region Selection Sort;

        //public int[] SelectionSort()
        //{
        //    int n = Arr1.Length;

        //    // One by one move boundary of unsorted subarray 
        //    for (int i = 0; i < n - 1; i++)
        //    {
        //        // Find the minimum element in unsorted array 
        //        int min_idx = i;
        //        for (int j = i + 1; j < n; j++)
        //            if (Arr1[j] < Arr1[min_idx])
        //                min_idx = j;

        //        // Swap the found minimum element with the first 
        //        // element 
        //        int temp = Arr1[min_idx];
        //        Arr1[min_idx] = Arr1[i];
        //        Arr1[i] = temp;
        //    }
        //    return Arr1;
        //}
        //#endregion

        ////Small improvisation

        //public int[] SelectionSortSpontaneous() //Find a local minimum in a subset, and consequently populate ...
        //{

        //    for (int i = 0; i <= Arr1.Length - 1; i++)
        //    {
        //        int key = Arr1[i];
        //        int minimal = Arr1[i];
        //        int index = i;
        //        for (int j = i; j <= Arr1.Length - 1; j++)
        //        {
        //            if (minimal > Arr1[j]) { minimal = Arr1[j]; index = j; }
        //        }
        //        Arr1[i] = minimal;
        //        Arr1[index] = key;

        //    }
        //    return Arr1;

        //}

        //public int[] InsertionSortTest()
        //{
        //    for (int i = 1; i < Arr1.Length; i++)
        //    {
        //        int key = Arr1[i];
        //        int index = i - 1;

        //        while (index >= 0 && Arr1[index] > key)
        //        {
        //            Arr1[index + 1] = Arr1[index];
        //            --index;
        //        }
        //        Arr1[index + 1] = key;


        //    }
        //    return Arr1;
        //}

        //public int[] MergeSortTest(int[] a)
        //{

        //    SortMerge(a, 0, a.Length - 1);

        //    void SortMerge(int[] numbers, int left, int right)
        //    {
        //        int mid;
        //        if (right > left)
        //        {
        //            mid = (right + left) / 2;
        //            SortMerge(numbers, left, mid);
        //            SortMerge(numbers, (mid + 1), right);
        //            MainMerge(numbers, left, (mid + 1), right);
        //        }
        //    }


        //    void MainMerge(int[] numbers, int left, int mid, int right)
        //    {
        //        int[] temp = new int[numbers.Length];
        //        int i, eol, num, pos;
        //        eol = (mid - 1);
        //        pos = left;
        //        num = (right - left + 1);

        //        while ((left <= eol) && (mid <= right))
        //        {
        //            if (numbers[left] <= numbers[mid])
        //                temp[pos++] = numbers[left++];
        //            else
        //                temp[pos++] = numbers[mid++];
        //        }
        //        while (left <= eol)
        //            temp[pos++] = numbers[left++];
        //        while (mid <= right)
        //            temp[pos++] = numbers[mid++];
        //        for (i = 0; i < num; i++)
        //        {
        //            numbers[right] = temp[right];
        //            right--;
        //        }
        //    }


        //    return a;
        //}

        #endregion

        #region Non-abundant sums

        public static void NonAbundantSums()

        //Perfect number is a number for which the sum of its proper divisors is exactly equal to the number.
        //28 would be 1 + 2 + 4 + 7 + 14 = 28
        //A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.
        //the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24.
        //By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers.*
        //However, this upper limit cannot be reduced any further by analysis even though 
        //it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.
        //Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
        {


            int LowerBound = 1;
            int UpperBound = 28123;
            System.Numerics.BigInteger sum = 0;



            //Let's find all abundant numbers until 28123;
            List<int> abundant = new List<int>(); //store all abundant numbers here;
            List<int> positive_integers_composed = new List<int>();
            List<int> listprimes = divisors(UpperBound);
            Console.WriteLine(" nb of primes:: " + listprimes.Count);
            //Console.WriteLine(" primes:: " +string.Join((char)32,listprimes));


          



        // GetAbundantNumbers();
        //Console.WriteLine(" nb of positive abundant:: " + abundant.Count.ToString());





        //for (int s = 1; s <= UpperBound; s++)
        //{
        //    if (!AbundantComposed(s))
        //    {
        //        sum += s;
        //         Console.WriteLine("Not Abundant : " + s);
        //    }
        //}


      

       


        Console.WriteLine(System.Environment.NewLine + "Execution finished successfully");


#pragma warning disable CS8321 // Local function is declared but never used
            void CompositeMadeOf2Abundant()
#pragma warning restore CS8321 // Local function is declared but never used
            {
                
                if(abundant.Count > 0)
                {

                    for(int k = 0; k< abundant.Count; k++)
                        for(int m = 0; m<=k; m++)
                        {
                            int nb = abundant[k] + abundant[m];
                            if (nb <= UpperBound && !positive_integers_composed.Contains(nb)) positive_integers_composed.Add(nb);
                        }
                }
                else positive_integers_composed.Add(0);

                
            }



#pragma warning disable CS8321 // Local function is declared but never used
            bool AbundantComposed(int a)
#pragma warning restore CS8321 // Local function is declared but never used
            {bool flag = false;
   
                for(int k=0; k< abundant.Count -1; k++)
                {
                    //if (a + abundant[k] > UpperBound) break;
                    //else
                    //{
                    //    remainder = a - abundant[k];
                    //    if (abundant.Contains(remainder)) { flag = true; break; }
                    //}

                for(int m = 0; m< abundant.Count; m++)
                    {
                        if(abundant[m]+abundant[k]==a)
                        { flag = true; break; }
                    }

                    if (flag) break;
                }
                
                return flag;
            }

#pragma warning disable CS8321 // Local function is declared but never used
            void GetAbundantNumbers()
#pragma warning restore CS8321 // Local function is declared but never used
            {
                List<int> listofprimes = divisors(UpperBound);

                for (int k = 12; k <= UpperBound;  k++)
                {

                    if (CalculateSum(optimizedividers(listofprimes.ToArray(), k)) > k) abundant.Add(k);

                }
                //Console.WriteLine(" abundant numbers : {0}", string.Join(" ", abundant));
                
            }


            //Populate primes into series of <n*p> divisors;
             List<int> divisors(int limit)
            {
                List<int> primes = new List<int>();
                int p = 0;
                int numeration = 0;
                primes.AddRange(System.Linq.Enumerable.Range(2,limit-1));
                
                p = primes[0];
                while(p*p<=limit)
                {
                    int x = 2;
                    int w = x * p;
                    
                    while (w<=limit)
                        {
                        primes.Remove(w);
                        ++x;
                        w = x * p;
                    }
                    p=primes[++numeration];
                  
                    
                }

                return primes; 
            }

            //Old method to generate the <n*p> series of divisors from primes;
#pragma warning disable CS8321 // Local function is declared but never used
            List<int> divisors2()
#pragma warning restore CS8321 // Local function is declared but never used
            {
                List<int> primes = new List<int>();
                for (int i = LowerBound; i*i <= UpperBound ; i++)
                {

                    //Let's optimize prime number generator taking into account the asymptotic law;
                    if (i >= 2 && i % 2 == 0 && !primes.Contains(2)) primes.Add(2);
                    if (i >= 3 && i % 3 == 0 && !primes.Contains(3)) primes.Add(3);
                    if (i >= 5 && i % 5 == 0 && !primes.Contains(5)) primes.Add(5);
                    if (i >= 7 && i % 7 == 0 && !primes.Contains(7)) primes.Add(7);


                    if ((i % 2) != 0 && (i % 3) != 0 && (i % 5) != 0 && (i % 7) != 0)
                    {
                        int j = 0;
                        if (primes.Count > 0) j = primes[primes.Count - 1]; else j = 11;
                        while (j <= i)
                        {
                            if (i % j == 0 && !primes.Contains(j)) primes.Add(j);
                            j += 2;
                        }
                    }




                }
                //Console.WriteLine("primes :: " + String.Join(" ", primes));
                return primes;
            }

            int[] optimizedividers(int[] b, int c)
            {
                List<int> dividerslist = new List<int>();

                foreach (int i in b)
                {
                    if (c % i == 0 && !(c<= i)) dividerslist.Add(i);
                    if (i >= c) break;

                }

                List<int> divisorslistupdated = new List<int>(dividerslist);
                foreach (int i in divisorslistupdated)
                {
                    foreach (int j in divisorslistupdated)
                    {
                        if (i * j < c && c % (i * j) == 0 && !dividerslist.Contains(i * j)) dividerslist.Add(i * j);

                    }

                    for (int k = 1; k < c / i; k++)
                    {
                        if (c % (k * i) == 0 && k * i != c && !dividerslist.Contains(k * i)) dividerslist.Add(k * i);
                    }
                }
               // Console.WriteLine("list of divisors for {0} is :: {1}",c, string.Join((char)32, divisorslist));
                return dividerslist.ToArray();
            }



            int CalculateSum(int[] a)
            {
                int sum0 = 0;
                foreach (int i in a) sum0 += i;
               // Console.WriteLine(" sum is {0}", sum0);
                return sum0;
            }


                                          
            
        }

        #endregion

        #region Lexicographic permutations
        //get 1Mth lexicographic permutation of 0123456789
        static void LexicographicPermutations()
        {
            int nb_permutation = 1000000;

            permute(nb_permutation);
            
            //Very naive implementation of factorization
            
            int factor(int n)
            {
                int fact = 0;
                
                if (n >= 1)
                {
                    fact = 1;
                    for(int j =n; j>=1; j--)
                    {
                        fact *= j;
                    }
                }
                return fact;
            }
            // better factor algos: http://www.luschny.de/math/factorial/FastFactorialFunctions.htm


            //nice and kinda fast implementation from MathBlog. Faster by 2x then my previous.
            //but it can be manually calculated !!
            void permute(int nb) // enter nb of permutation
            {
                List<int> numbers = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };// it can be a string;
                int N = numbers.Count;
                string permNum = "";
                int remain = nb - 1;
               
                //This algo is in a book by Edsger W. Dijsktra, p. 107
            for (int i = 1; i< N; i++) {
                int j = remain / factor(N - i);
                remain = remain % factor(N - i);
                permNum = permNum + numbers[j];
                numbers.RemoveAt(j);
                if (remain == 0)
                {
                    break;
                }
            }

            for (int i = 0; i < numbers.Count; i++) {
                permNum = permNum + numbers[i];
            }

                Console.WriteLine(" number = " + permNum);
        }

        }

        #endregion
    }

}
