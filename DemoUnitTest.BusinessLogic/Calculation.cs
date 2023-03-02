namespace DemoUnitTest.BusinessLogic
{
    public class Calculation
    {
        List<int> OddNumcollection = new List<int>();

        public int Addition(int a, int b)
        {
            return a + b;
        }
        public double doubleAddition(double a, double b)
        {
            return a + b;
        }
        public bool CheckOddNumber(int a)
        {
            return a%2 != 0;
        }
        public bool CheckEventNumber(int a)
        {
            return a % 2 == 0;
        }

        public List<int> GotOddRangeValues(int minvalue, int maxvalue)
        {
            for (int i = minvalue; i < maxvalue; i++)
            {
                if (i % 2 != 0)
                {
                    OddNumcollection.Add(i);
                }
            }
            return OddNumcollection;
        }
    }
}