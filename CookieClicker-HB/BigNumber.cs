using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.TextFormatting;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CookieClicker_HB
{
    public class BigNumber
    {
        private int[] _number;
        private const int _base = 1000;
        private string _beautifuly;
        public int _arrayLen;

        public BigNumber(string number)
        {
            _number = SplitString(number);
            _arrayLen = _number.Length;
        }

        public int[] GetNum()
        {
            return _number;
        }

        public string Beautiful
        {
            get { return _beautifuly; }
            private set { _beautifuly = value; }
        }

        public string DoABeauti()
        {
            string result = "";
            string numstr = this.ToString();
            string shorty = $"{numstr[0]},{numstr[1]}";

            result = $"{shorty} e+{numstr.Length - 1}";
            Beautiful = result;
            return result;
        }

        public BigNumber Clone()
        {
            return new BigNumber(_number.ToString());
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = _number.Length - 1; i >= 0; i--)
            {
                if (i == _number.Length - 1)
                    sb.Append(_number[i].ToString());
                else
                    sb.Append(_number[i].ToString("D3"));
            }
            
            string resultStr = sb.ToString().TrimStart('0');
            return resultStr;
        }

        private int[] SplitString(string numberStr)
        {
            
            string numst = numberStr;
            int str_len = numberStr.Length;
            int length = Convert.ToInt32(Math.Ceiling((double)str_len / 3));

            int currentStrIndex = 0; // Индекс в исходной строке numberStr
            int currentResultIndex = 0; // Индекс в массиве result

            int lastThreeLength = str_len % 3;
            if (lastThreeLength == 0)
            {
                lastThreeLength = 3;
            }

            int[] result = new int[length];
            
            result[currentResultIndex] = int.Parse(numberStr.Substring(currentStrIndex, lastThreeLength));
            currentStrIndex += lastThreeLength;
            currentResultIndex++;

            while (currentStrIndex < numberStr.Length)
            {
                result[currentResultIndex] = int.Parse(numberStr.Substring(currentStrIndex, 3));
                currentStrIndex += 3;
                currentResultIndex++;
            }

            Array.Reverse(result);

            return result;
        }


        private BigNumber Add(BigNumber secNum)
        { 
            int[] a_num = this.GetNum();
            int[] b_num = secNum.GetNum();

            int tmp_num;
            int i_num;
            int next_num = 0;

            bool is_A_bigger;

            string tmp_sum = "";
            int minLen;
            if (a_num.Length > b_num.Length)
            {
                minLen = b_num.Length;
                is_A_bigger = true;
            }
            else
            {
                minLen = a_num.Length;
                is_A_bigger = false;
            }

            for (int i = 0; i < minLen;i++)
            {
                tmp_num = a_num[i] + b_num[i] + next_num;
                i_num = tmp_num % _base;
                next_num = tmp_num / _base;

                tmp_sum = i_num.ToString("D3") + tmp_sum;
            }

            if (is_A_bigger)
            {
                for (int i = minLen; i < a_num.Length; i++)
                {
                    tmp_num = a_num[i] + next_num;
                    i_num = tmp_num % _base;
                    next_num = tmp_num / _base;

                    tmp_sum = i_num.ToString("D3") + tmp_sum;
                }
            }
            else
            {
                for (int i = minLen; i < b_num.Length; i++)
                {
                    tmp_num = b_num[i] + next_num;
                    i_num = tmp_num % _base;
                    next_num = tmp_num / _base;

                    tmp_sum = i_num.ToString("D3") + tmp_sum;
                }
            }

            return new BigNumber(tmp_sum);
                
        }
        private BigNumber Substruct(BigNumber secNum) //отрицательные числа пока не робят! (отрицательные итоги) (а надо ли нам это? помоему нет)
        {                                             //теперь работают, даже правильно, но чтоб их юзать надо много чё менять
            int[] a_num;                              //они нам по итогу не нужны. Ну лан, не буду менять
            int[] b_num;
            bool isPositive;
            int tmp_num;
            int i_num;
            int next_num = 0;
            string tmp_sub = "";
            int minLen;

            if (this > secNum)
            {
                a_num = this.GetNum();
                b_num = secNum.GetNum();
                isPositive = true;
                minLen = b_num.Length;
            }
            else
            {
                b_num = this.GetNum();
                a_num = secNum.GetNum();
                isPositive = false;
                minLen = b_num.Length;
            }

            for (int i = 0; i < minLen; i++)
            {
                if (a_num[i] - next_num - b_num[i] >=0 )
                {
                    tmp_num = a_num[i] - next_num - b_num[i];
                    next_num = 0;
                    tmp_sub = tmp_num.ToString("D3") + tmp_sub;
                }
                else // a - (b+n) <0
                {
                    tmp_num = a_num[i] + _base   - next_num - b_num[i];
                    next_num = 1;
                    tmp_sub = tmp_num.ToString("D3") + tmp_sub;
                }
            }

            for (int i = minLen; i < a_num.Length; i++)
            {
                if (a_num[i] - next_num >= 0)
                {
                    tmp_num = a_num[i] - next_num;
                    next_num = 0;
                    tmp_sub = tmp_num.ToString("D3") + tmp_sub;
                }
                else
                {
                    tmp_num = a_num[i] + _base - next_num;
                    next_num = 1;
                    tmp_sub = tmp_num.ToString("D3") + tmp_sub;
                }
            }

            if (!isPositive)
            {
                //tmp_sub = "-" + tmp_sub;
                MessageBox.Show("Ошибка вычисления, резуоттат не модет быть отрицательным");
                return null; // можно ещё 0 вернуть (или 000)
            }

            return new BigNumber(tmp_sub);
        }
        private BigNumber Multiply(double multyplier) // размер может стать больше!!!
        {
            int[] a_num = this.GetNum();

            int tmp_num;
            int i_num;
            int next_num = 0;
            string tmp_sum = "";
            
            for (int i = 0; i < a_num.Length; i++)
            {
                tmp_num = (int)((a_num[i] * multyplier ) + next_num);

                i_num = tmp_num % _base;
                next_num = tmp_num / _base;

                tmp_sum = i_num.ToString("D3") + tmp_sum;
            }

            return new BigNumber(tmp_sum);
        }
        private BigNumber Divide(double devidor)
        {
            int[] a_num = this.GetNum();

            int tmp_num;
            int i_num;
            int next_num = 0;
            string tmp_sum = "";

            for (int i = a_num.Length - 1; i >= 0; i--)
            {
                tmp_num = (a_num[i] + next_num);

                i_num = (int)(tmp_num / devidor);
                next_num = (int)((double)tmp_num % devidor) * _base;

                tmp_sum += i_num.ToString("D3");
            }
            
            return new BigNumber(tmp_sum);
        }


        private int[] Delete_zero_elems(int[] numb)
        {
            int[] resultArray = numb;

            int firstNonZeroIndex = -1;
            for (int i = resultArray.Length - 1; i >= 0; i--) // ищем где не 0
            {
                if (resultArray[i] != 0)
                {
                    firstNonZeroIndex = i;
                    break;
                }
            }
            int[] finalResultArray;

            if (firstNonZeroIndex == -1)
            {
                // Все элементы были нулями, значит это 0 (так не должно быть но мало ли)
                finalResultArray = new int[] { 0 };
            }
            else
            {
                finalResultArray = new int[resultArray.Length - firstNonZeroIndex];
                for (int i = 0; i < finalResultArray.Length; i++)
                {
                    finalResultArray[i] = resultArray[i];
                }
            }
            return finalResultArray;
        }

        // treamLeadingZeroes - убирание "назначащих нулей"

        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            return(a.Add(b));
        }
        public static BigNumber operator -(BigNumber a, BigNumber b)
        {
            return (a.Substruct(b));
        }
        public static BigNumber operator *(BigNumber a, double b)
        {
            return (a.Multiply(b));
        }
        public static BigNumber operator /(BigNumber a, double b)
        {
            return (a.Divide(b));
        }

        public static bool operator >(BigNumber a, BigNumber b)
        {

            if (a._arrayLen > b._arrayLen)
            {
                return true;
            }
            else if (a._arrayLen < b._arrayLen)
            {
                return false;
            }
            else // если числа одинаковой длины
            {
                for (int i = 0; i < a._arrayLen; i++)
                {
                    if (a.ToString()[i] > b.ToString()[i])
                    {
                        return true;
                    }
                    else if (a.ToString()[i] < b.ToString()[i])
                    {
                        return false;
                    }
                }
            } // если мы прошлись по условиям и циклм и ничего не вернули, остаётся только одно - они равны
            return false;
        }

        public static bool operator <(BigNumber a, BigNumber b)
        {

            if (a._arrayLen > b._arrayLen)
            {
                return false;
            }
            else if (a._arrayLen < b._arrayLen)
            {
                return true;
            }
            else // если числа одинаковой длины
            {
                for (int i = 0; i < a._arrayLen; i++)
                {
                    if (a.ToString()[i] > b.ToString()[i])
                    {
                        return false;
                    }
                    else if (a.ToString()[i] < b.ToString()[i])
                    {
                        return true;
                    }
                }
            } // если мы прошлись по условиям и циклм и ничего не вернули, остаётся только одно - они равны
            return false;
        }

        public static bool operator ==(BigNumber a, BigNumber b)
        {
            if (a.ToString() == b.ToString())
            {
                return true;
            }
            else { return false; }
        }
        public static bool operator !=(BigNumber a, BigNumber b)
        {
            if (a.ToString() != b.ToString())
            {
                return true;
            }
            else { return false; }
        }

        public static bool operator >=(BigNumber a, BigNumber b)
        {
            if (a > b || a == b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <=(BigNumber a, BigNumber b)
        {
            if (a < b || a == b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
