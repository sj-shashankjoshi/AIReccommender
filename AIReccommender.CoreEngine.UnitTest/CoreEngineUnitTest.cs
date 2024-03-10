using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;

namespace AIReccommender.CoreEngine.UnitTest
{
    [TestClass]
    public class CoreEngineUnitTest
    {
        PearsonReccommender Recommender = null;
        [TestInitialize]//before every testcase
        public void init()
        {
            Recommender = new PearsonReccommender();
        }

        [TestCleanup]//after every testcase
        public void Cleanup()
        {
            Recommender = null;
        }
        [TestMethod]
        public void GetCorelationTester_WithArraysOfSameLengthAndNoZeroElements_ShouldGiveCorelationCoeff()
        {
            int[] BaseData = { 20, 24, 17 };
            int[] OtherData = { 30, 20, 27 };
            double ExpectedCoeff = -0.739853246;
            double ActualCoeff = Recommender.GetCorelation(BaseData, OtherData);
            Assert.AreEqual(ExpectedCoeff, ActualCoeff);
        }
        [TestMethod]
        public void GetCorelationTester_WithArrayOfSameLengthAndBaseZeroElements_ShouldGiveCorelationCoeff()
        {
            int[] BaseData = { 10, 1, 0 };
            int[] OtherData = { 20, 10, 10 };
            double ExpectedCoeff = 0.995870595;
            double ActualCoeff = Recommender.GetCorelation(BaseData, OtherData);
            Assert.AreEqual(ExpectedCoeff, ActualCoeff);
            
        }
        
        [TestMethod]
        public void GetCorelationTester_WithArrayOfSameLengthAndOtherZeroElements_ShouldGiveCoreleationCoeff()
        {
            int[] OtherData = { 10, 1, 0 };
            int[] BaseData = { 20, 10, 10 };
            double ExpectedCoeff = 0.995870595;
            double ActualCoeff = Recommender.GetCorelation(BaseData, OtherData);
            Assert.AreEqual(ExpectedCoeff, ActualCoeff);
        }
        [TestMethod]
        public void GetCorelationTester_WithUnequalArrayLengthAndBaseIsLongerAndNonZeroElements_ShouldGiveCorelationCoeff()
        {
            int[] BaseData= { 10, 20, 5};
            int[] OtherData = { 20 };
            double ExpectedCoeff = -0.188982237;
            double ActualCoeff = Recommender.GetCorelation(BaseData, OtherData);
            Assert.AreEqual(ExpectedCoeff, ActualCoeff);
        }
        [TestMethod]
        public void GetCorelationTester_WithUnequalArrayLengthAndBaseIsLongerAndZeroElements_ShouldGiveCorelationCoeff()
        {
            int[] BaseData = { 10, 0, 5 };
            int[] OtherData = { 20 };
            double ExpectedCoeff = 0.874537724;
            double ActualCoeff = Recommender.GetCorelation(BaseData, OtherData);
            Assert.AreEqual(ExpectedCoeff, ActualCoeff);
        }
        
        [TestMethod]
        public void GetCorelationTester_WithUnequalArrayLengthAndOtherIsLongerAndNonZeroElements_ShouldGiveCorelationCoeff()
        {
            int[] BaseData = { 10, 20, 6 };
            int[] OtherData = { 20, 10, 6, 30, 15 };
            double ExpectedCoeff = 0.038461538;
            double ActualCoeff = Recommender.GetCorelation(BaseData, OtherData);
            Assert.AreEqual(ExpectedCoeff, ActualCoeff);
        }

        [TestMethod]
        public void GetCorelationTester_WithUnequalArrayLengthAndOtherIsLongerAndZeroElements_ShouldGiveCorelationCoeff()
        {
            int[] BaseData = { 10, 0, 15};
            int[] OtherData = { 15, 10, 20, 25, 30 };
            double ExpectedCoeff = 0.974222644;
            double ActualCoeff = Recommender.GetCorelation(BaseData, OtherData);
            Assert.AreEqual(ExpectedCoeff, ActualCoeff);
        }
    }
}

