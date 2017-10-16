using System;
using System.Collections.Generic;
using ScaniaDemo_restapi.Models;
using System.Threading.Tasks;

namespace ScaniaDemo_restapi.Repositories
{
	public interface ITrucks
    {
        Task Add(int id, int modelId, string regNo, double km, string driver);

        Task<List<TruckEntity>> Get();
    }
}
