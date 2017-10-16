using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using ScaniaDemo_restapi.Models;

namespace ScaniaDemo_restapi.Repositories
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Trucks : ITrucks
    {
        private readonly string _storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=scaniademoapi;AccountKey=yA3tlMOVuMwF78mYtzgw3h6AX7ZkY+zMOAt976YfgWKpx/R+QRbalawxUV9V/3Dw/crs717ErpzF6a4JPXYBHw==;EndpointSuffix=core.windows.net";
        private CloudStorageAccount _storageAccount;
        private CloudTableClient _tableClient;
		
        public Trucks()
        {
            _storageAccount = CloudStorageAccount.Parse(_storageConnectionString);
            _tableClient = _storageAccount.CreateCloudTableClient();
        }

        public void Add() {}
    }
}
