using System;
using System.Collections.Generic;
using ScaniaDemo_restapi.Models;
using System.Threading.Tasks;

namespace ScaniaDemo_restapi.Repositories
{
	public interface ITrucks
    {
        Task Add(TruckEntity entity);

        Task<List<TruckEntity>> Get();

        Task<TruckEntity> GetById(int id);
    }
}
