using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_1_CoinChangerApplication
{
    public class CoinChanger
    {
        private readonly List<decimal> _coinTypes;

        public CoinChanger(List<decimal> coinTypes)
        {
            _coinTypes = coinTypes.OrderByDescending(x => x).ToList();
        }

        public Dictionary<decimal, int> MakeChange(decimal input)
        {
            var dict = new Dictionary<decimal, int>();
            var sum = 0;
            foreach (var coinType in _coinTypes)
            {
                sum = 0;
                while (coinType <= input)
                {
                    input -= coinType;
                    sum++;
                }
                dict.Add(coinType, sum);

            }
            return dict;
        }
    }
}
