using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker_HB
{
    internal class BigNumber
    {
        private int _number;
        private const int _base = 1000;
        public int _arrayLen;

        public BigNumber(int number)
        {
            _number = number;
        }

        public BigNumber Clone()
        {
            return new BigNumber(_number);
        }
        public override string ToString()
        { 
            return _number.ToString();
        }

        private BigNumber Add(BigNumber secNum)
        {
            return this;
        }
        private BigNumber Substruct(BigNumber secNum)
        {
            return this;
        }
        private BigNumber Multiply(BigNumber secNum)
        {
            return this;
        }
        private BigNumber Divide(BigNumber secNum)
        {
            return this;
        }

        // treamLeadingZeroes - убирание "назначащих нулей"

    }
}
