using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartArrayTest
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnAnArrayOfZeroesWhenCreated()
        {
            //Arrange
            SmartArray arrayUnderTest;
            bool zeroes = true;
            int index = 0;

            //Act
            arrayUnderTest = new SmartArray(5);
            while (index < 5 && zeroes == true)
            {
                if (arrayUnderTest.GetAtIndex(index) != 0) zeroes = false;
                index++;
            }

            //Assert
            Assert.IsTrue(zeroes);
        }
    }

    [TestClass]
    public class SetAtIndex_Should
    {
        [TestMethod]
        public void CompleteSuccessfully_WhenIndexInRange()
        {
            //Arrange
            SmartArray arrayUnderTest = new SmartArray(5);
            int index = 4;
            int value = 99;

            //Act
            arrayUnderTest.SetAtIndex(index, value);

            //Assert
            Assert.AreEqual(value, arrayUnderTest.GetAtIndex(index));   //Dummy Assert for completeness.  Test will fail if exception thrown
        }

        [TestMethod]
        public void CompleteSuccessfullyWithAutoExpand()
        {
            //Arrange
            SmartArray arrayUnderTest = new SmartArray(5, true);
            int index = 9;
            int value = 99;

            //Act
            arrayUnderTest.SetAtIndex(index, value);

            //Assert
            Assert.AreEqual(value, arrayUnderTest.GetAtIndex(index));
        }


        [TestMethod]
        public void ThrowException_WhenIndexIsTooLarge()
        {
            //Arrange
            SmartArray arrayUnderTest = new SmartArray(5);
            int index = 5;

            //Act-Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => arrayUnderTest.SetAtIndex(index, 999));
        }

         

    }
    [TestClass]
    public class GetAtIndex_Should
    {
        [TestMethod]
        public void ReturnCorrectValue_WhenIndexInRange()
        {
            //Arrange
            SmartArray arrayUnderTest = new SmartArray(10);
            int index = 9;
            int expected = 99;
            arrayUnderTest.SetAtIndex(index, expected);

            //Act
            int actual = arrayUnderTest.GetAtIndex(index);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReturnCorrectValue_WithAutoExpand()
        {
            //Arrange
            SmartArray arrayUnderTest = new SmartArray(10, true);
            int index = 21;
            int expected = 79;
            arrayUnderTest.SetAtIndex(index, expected);

            //Act
            int actual = arrayUnderTest.GetAtIndex(index);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThrowException_WhenIndexIsTooLarge()
        {
            //Arrange
            SmartArray arrayUnderTest = new SmartArray(5);
            int index = 5;

            //Act-Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => arrayUnderTest.GetAtIndex(index));
        }

    }
    [TestClass]
    public class Find_Should
    {
        [TestMethod]
        public void ReturnTrue_WhenValueInArray()
        {
            //Arrange
            int length = 10;
            SmartArray arrayUnderTest = new SmartArray(length);
            int findValue = 105;
            bool found;
            for (int i = 0; i < length; i++)
            {
                arrayUnderTest.SetAtIndex(i, i + 100);
            }

            //Act
            found = arrayUnderTest.Find(findValue);

            //Assert
            Assert.IsTrue(found);
        }
        [TestMethod]
        public void ReturnFalse_WhenValueNotInArray()
        {
            //Arrange
            int length = 10;
            SmartArray arrayUnderTest = new SmartArray(length);
            int findValue = 9999;
            bool found;

            for (int i = 0; i < length; i++)
            {
                arrayUnderTest.SetAtIndex(i, i + 100);
            }

            //Act
            found = arrayUnderTest.Find(findValue);

            //Assert
            Assert.IsFalse(found);
        }
    }
    [TestClass]
    public class Resize_Should
    {
        [TestMethod]
        public void SetCorrectArrayValues_WhenExpansionIsComplete()
        {
            //A resized array should include the content of the original array
            //plus zeroes for all the new elements

            //Arrange
            int startLength = 10;
            int newLength = 20;
            bool asExpected = true;

            SmartArray arrayUnderTest = new SmartArray(startLength);

            for (int i = 0; i < startLength; i++)
            {
                arrayUnderTest.SetAtIndex(i, i + 100);
            }

            //Act

            arrayUnderTest.Resize(newLength);

            //Assert
            for (int i = 0; i < startLength; i++)
            {
                if (arrayUnderTest.GetAtIndex(i) != i + 100) asExpected = false;
            }

            for (int i = startLength; i < newLength; i++)
            {
                if (arrayUnderTest.GetAtIndex(i) != 0) asExpected = false;
            }

            Assert.IsTrue(asExpected);
        }
        [TestMethod]
        public void DoubleLength_WhenResizedWithNoParameter()
        {
            //A resized array should include the content of the original array
            //plus zeroes for all the new elements

            //Arrange
            int startLength = 10;

            SmartArray arrayUnderTest = new SmartArray(startLength);

            for (int i = 0; i < startLength; i++)
            {
                arrayUnderTest.SetAtIndex(i, i + 100);
            }

            //Act

            arrayUnderTest.Resize();

            //Assert

            Assert.AreEqual(startLength * 2, arrayUnderTest.Length);
        }

        [TestMethod]
        public void IncreaseLengthToAccomodateRequestedIndex_WhenResizedWithParameter()
        {
            //A resized array should include the content of the original array
            //plus zeroes for all the new elements

            //Arrange
            int startLength = 25;

            SmartArray arrayUnderTest = new SmartArray(startLength);

            for (int i = 0; i < startLength; i++)
            {
                arrayUnderTest.SetAtIndex(i, i + 100);
            }

            //Act

            arrayUnderTest.Resize(startLength);

            //Assert

            Assert.AreEqual(startLength, arrayUnderTest.Length);
        }

        [TestMethod]
        public void AllowTruncationIsTrue_WhenResizedWithParameter()
        {
            //A resized array should include the content of the original array
            //plus zeroes for all the new elements

            //Arrange
            int startLength = 15;
            int newSize = 5;

            SmartArray arrayUnderTest = new SmartArray(startLength);

            for (int i = 0; i < startLength; i++)
            {
                arrayUnderTest.SetAtIndex(i, i + 100);
            }

            //Act

            arrayUnderTest.Resize(newSize);

            //Assert

            Assert.AreEqual(newSize, arrayUnderTest.Length);
        }

        [TestMethod]
        public void AllowTruncationIsFalse_WhenResizedWithParameter()
        {
            //A resized array should include the content of the original array
            //plus zeroes for all the new elements

            //Arrange
            int startLength = 20;
            int newSize = 10;

            SmartArray arrayUnderTest = new SmartArray(startLength);

            for (int i = 0; i < startLength; i++)
            {
                arrayUnderTest.SetAtIndex(i, i + 100);
            }

            //Act

            arrayUnderTest.Resize(newSize, false);

            //Assert

            Assert.AreEqual(startLength, arrayUnderTest.Length);
        }

    }

}

