using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter.Access
{
    [DataContract]
    public class Trade
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public string MarketName { get; set; }
        [DataMember]
        public bool IsBuy { get; set; }
        [DataMember]
        public decimal Amount { get; set; }
    }
    public class TradeRepository : IRepository<Trade>
    {
        HashSet<Trade> _Trades = new HashSet<Trade>();
        public TradeRepository()
        {
            Task.Factory.StartNew(() => InitTradeData());
        }
        public IEnumerable<Trade> GetModel(int id)
        {
           return _Trades.Where(t => t.ID >= id).ToList();
        }
        private void InitTradeData()
        {
            int i = 100;
            {
                Trade t = new Trade()
                {
                    ID = i++,
                    CreatedDate = DateTime.Parse("01/01/2018 14:10:10"),
                    MarketName = "Barclays",
                    IsBuy = true,
                    Amount = 10.5M
                };
                _Trades.Add(t);
            }
            {
                Trade t = new Trade()
                {
                    ID = i++,
                    CreatedDate = DateTime.Parse("01/01/2018 15:10:10"),
                    MarketName = "Barclays",
                    IsBuy = false,
                    Amount = 10.5M
                };
                _Trades.Add(t);
            }
            {
                Trade t = new Trade()
                {
                    ID = i++,
                    CreatedDate = DateTime.Parse("02/01/2018 14:10:10"),
                    MarketName = "Vodafone",
                    IsBuy = true,
                    Amount = 100.5M
                };
                _Trades.Add(t);
            }
            {
                Trade t = new Trade()
                {
                    ID = i++,
                    CreatedDate = DateTime.Parse("02/01/2018 15:10:10"),
                    MarketName = "Vodafone",
                    IsBuy = true,
                    Amount = 100.5M
                };
                _Trades.Add(t);
            }
            {
                Trade t = new Trade()
                {
                    ID = i++,
                    CreatedDate = DateTime.Parse("03/01/2018 13:10:10"),
                    MarketName = "Vodafone",
                    IsBuy = false,
                    Amount = 100.5M
                };
                _Trades.Add(t);
            }
        }
    }
}
