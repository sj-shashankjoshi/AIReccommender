using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AIReccommender.CoreEngine
{
    public class PearsonReccommender : IReccommender
    {
        public double GetCorelation(int[] BaseData, int[] OtherData)
        {
            double CorelationCoeff = 0,r1=0,r2=0,n=0, sumx=0, sumy=0, sumxy=0, sumx2=0, sumy2=0;
            int[] UpdatedOtherData;
            //logic for pearson reccomender
            //for the four business conditions of the two arrays

            if (BaseData.Length == OtherData.Length)
            {
                for (int i =0; i < BaseData.Length; i++)
                {
                    if (BaseData[i] == 0 || OtherData[i] == 0)
                    {
                        BaseData[i] = BaseData[i] + 1;
                        OtherData[i] = OtherData[i] + 1;
                    }
                }
                n = BaseData.Length;
                sumx = ArraySum(BaseData);
                sumy = ArraySum(OtherData);
                sumx2 = ArraySquareSum(BaseData);
                sumy2 = ArraySquareSum(OtherData);
                sumxy = ArrayMulSum(BaseData, OtherData);

            }
            else if(BaseData.Length > OtherData.Length)
            {
                UpdatedOtherData = new int[BaseData.Length];
                for (int i = 0; i < OtherData.Length; i++)
                {
                    UpdatedOtherData[i] = OtherData[i];
                }
                for(int i = OtherData.Length; i < BaseData.Length; i++)
                {
                    UpdatedOtherData[i] = 1;
                }
                for (int i = 0; i < BaseData.Length; i++)
                {
                    if (BaseData[i] == 0 || UpdatedOtherData[i] == 0)
                    {
                        BaseData[i] = BaseData[i] + 1;
                        UpdatedOtherData[i] = UpdatedOtherData[i] + 1;
                    }
                }
                n = BaseData.Length;
                sumx = ArraySum(BaseData);
                sumy = ArraySum(UpdatedOtherData);
                sumx2 = ArraySquareSum(BaseData);
                sumy2 = ArraySquareSum(UpdatedOtherData);
                sumxy = ArrayMulSum(BaseData, UpdatedOtherData);
            }

            else if (BaseData.Length < OtherData.Length)
            {
                UpdatedOtherData = new int[BaseData.Length];
                for (int i  = 0; i< BaseData.Length; i++)
                {
                    UpdatedOtherData[i] = OtherData[i];
                }
                for (int i = 0; i < BaseData.Length; i++)
                {
                    if (BaseData[i] == 0 || UpdatedOtherData[i] == 0)
                    {
                        BaseData[i] = BaseData[i] + 1;
                        UpdatedOtherData[i] = UpdatedOtherData[i] + 1;
                    }
                }
                n = BaseData.Length;
                sumx = ArraySum(BaseData);
                sumy = ArraySum(UpdatedOtherData);
                sumx2 = ArraySquareSum(BaseData);
                sumy2 = ArraySquareSum(UpdatedOtherData);
                sumxy = ArrayMulSum(BaseData, UpdatedOtherData);
            }





            //coefficient formula
            r1 = (n * sumxy) - (sumx * sumy);
            r2 = ((n * sumx2)-(sumx * sumx)) *((n * sumy2) - (sumy * sumy));
            CorelationCoeff = r1 / Math.Sqrt(r2);
            //returning coefficient
            return double.Parse(CorelationCoeff.ToString($"F{9}")); 
            
        } 
        
        public double ArraySum(int[] arr)
        {
            double sum = 0;
            foreach (int num in arr)
            {
                sum += num; 
            }
            return sum;
        }
        
        public double ArraySquareSum(int[] arr)
        {
            double ssum = 0;
            foreach (int num in arr)
            {
                ssum += num * num; 
            }
            return ssum;
        }

        public double ArrayMulSum(int[] a, int[] b)
        {
            double msum = 0;
            for (int i=0; i<a.Length; i++)
            {
                msum = msum + (a[i] * b[i]);
            }
            return msum;
        }
    }
}
