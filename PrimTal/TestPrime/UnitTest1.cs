using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using PrimTal;

namespace TestPrime
{
    public class TestPrime
    {
        Prime primeNumber;

        [Test]
        public void test_check_if_Prime_Adds()
        {
            primeNumber = new Prime();
            primeNumber.AddNumber(11);
            if (primeNumber.returnPrimes().Count == 1)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void test_check_If_Higest_Prime_Is_Right()
        {
            primeNumber = new Prime();

            primeNumber.AddNumber(7);
            primeNumber.AddNumber(11);

            if (primeNumber.PrimeNumber == 11)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        
        [Test]
        public void test_add_number_adds_Highest_Prime_first_Time()
        {
            primeNumber = new Prime();

            primeNumber.AddNumber(11);

            if (primeNumber.PrimeNumber == 11)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
     
       
        [Test]
        public void test_if_I_Get_list_Back_with_more_then_one_Prime()
        {
            primeNumber = new Prime();
            primeNumber.AddNumber(7);
            primeNumber.AddNumber(13);
            primeNumber.AddNumber(11);


            if (primeNumber.returnPrimes().Count == 3 )
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
       
        [Test]
        public void test_if_get_number_returns_right_value()
        {
            primeNumber = new Prime();

            primeNumber.AddNumber(11);

            if (primeNumber.GetNumber(7) == 11)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void test_if_get_number_returns_right_value_with_swoop()
        {
            primeNumber = new Prime();
            primeNumber.AddNumber(7);

            if (primeNumber.GetNumber(11) == 11)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void test_if_add_Number_work()
        {
            primeNumber = new Prime();
            primeNumber.AddNumber(7);

            if (primeNumber.PrimeNumber == 7 && primeNumber.returnPrimes().Count == 1)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
      
    }
    public class TestPrimeHandler
    {
        Prime primeNumber = new Prime();
        PrimeHandler testHandler;

        [Test]
        public void test_if_right_string_is_returned()
        {
            testHandler = new PrimeHandler(primeNumber);

            Assert.AreEqual(testHandler.chooseNumberToCheckIfPrime("10"), "Number is not Prime.");
        }
        [Test]
        public void test_if_right_string_is_returned_second()
        {
            testHandler = new PrimeHandler(primeNumber);

            Assert.AreEqual(testHandler.chooseNumberToCheckIfPrime("7"),"Number is Prime.");
        }
        [Test]
        public void test_if_right_string_is_returned_wrong_Input()
        {
            testHandler = new PrimeHandler(primeNumber);

            Assert.AreEqual("You have entered something invalid", testHandler.chooseNumberToCheckIfPrime("7a"));
        }
        [Test]
        public void test_check_If_prime_IsPrime()
        {
            testHandler = new PrimeHandler(primeNumber);

            Assert.IsFalse(testHandler.checkIfPrime(7));
        }
        [Test]
        public void test_check_If_prime_IsnotPrime()
        {
            testHandler = new PrimeHandler(primeNumber);

            Assert.IsTrue(testHandler.checkIfPrime(10));
        }
        [Test]
        public void test_next_prime_adds()
        {
            primeNumber = new Prime();
            testHandler = new PrimeHandler(primeNumber);

            primeNumber.AddNumber(7);
            testHandler.createNewPrime();
            if (primeNumber.PrimeNumber == 11)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
        [Test]
        public void test_next_prime_adds_second_Try()
        {
            primeNumber = new Prime();
            testHandler = new PrimeHandler(primeNumber);
            primeNumber.AddNumber(11);
            testHandler.createNewPrime();
            if (primeNumber.PrimeNumber == 13)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

    }
}