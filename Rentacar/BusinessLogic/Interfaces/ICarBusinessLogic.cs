﻿using Rentacar.BusinessModels.Car;
using Rentacar.DataModels;

namespace Rentacar.BusinessLogic.Interfaces
{
    public interface ICarBusinessLogic
    {
        IEnumerable<CarListBusinessModel> GetAll();
        CarDetailsBusinessModel GetCarDetails(int id);
        CarEditBusinessModel GetCarEditModel(int id);
        CarDataModel Insert(CarCreateBusinessModel carBusiness);
        CarDataModel Update(CarEditBusinessModel carBusiness);
        bool DeleteByID(int id);
    }
}
