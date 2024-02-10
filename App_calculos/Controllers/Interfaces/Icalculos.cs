using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_calculos.Controllers.Interfaces
{

    //INTERFAZ PARA CÁCULOS DE LA MEDIANA
    public interface IMediaCalculator
    {
        double Calculate(List<double> numbers);
    }


    //INTERFAZ PARA DATOS DE LA ESCALERA

    public interface IStaircaseGenerator
    {
        string GetStaircase(int size);
    }
}