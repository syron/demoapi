using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace ScaniaDemo_restapi.Models
{
    public class TruckEntity : TableEntity
    {
        public TruckEntity(int modelId, int id)
        {
            this.PartitionKey = modelId.ToString();
            this.RowKey = id.ToString();
        }

        public TruckEntity()
        {
        }

        public int Id
        {
            get;
            set;
        }

        public int ModelId
        {
            get;
            set;
        }

        public string RegistrationNumber
        {
            get;
            set;
        }

        public double Km
        {
            get;
            set;
        }

        public string Driver
        {
            get;
            set;
        }
    }
}
