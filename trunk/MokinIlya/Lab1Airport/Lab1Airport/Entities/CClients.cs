using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1Airport
{
    class CClients
    {
        public class CClientItem
        {
            public CClientItem(int numderOfClient, int numberOfReis, bool reserveOrBuy)
            {
                NumderOfClient = numderOfClient;
                NumberOfReis = numberOfReis;
                ReserveOrBuy = reserveOrBuy;
            }

            public int NumberOfReis { get; set; }
            public bool ReserveOrBuy { get; set; }
            public int NumderOfClient { get; set; }
        }

        public List<CClientItem> ClientItem;

        public CClients()
        {
            ClientItem = new List<CClientItem>();
        }

        public bool Add(int NumderOfClient, int NumberOfReis, bool ReserveOrBuy)
        {
            ClientItem.Add(new CClientItem(NumderOfClient, NumberOfReis, ReserveOrBuy));
            return true;
        }

        public bool Delete(int numberOfClient)
        {
            int index = ClientItem.FindIndex(x => x.NumderOfClient == numberOfClient);
            ClientItem.RemoveAt(index);
            return true;
        }

        public CClientItem FinishReserve(int numberOfClient)
        {
            int index = ClientItem.FindIndex(x => x.NumderOfClient == numberOfClient);
            ClientItem[index].ReserveOrBuy = true;
            return ClientItem[index];
        }
    }
}
