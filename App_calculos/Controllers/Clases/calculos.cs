using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App_calculos.Controllers.Interfaces;

namespace App_calculos.Controllers.Clases

    //FUNCIÓN PARA CALCULAR LA MEDIA ARITMETICA
{
    public class ArithmeticMeanCalculator : IMediaCalculator  //SE USA INTERFAZ PARA CAPTURAR LOS DATOS QUE VIENEN DE LA VISTA
    {
        public double Calculate(List<double> numbers)
        {
            if (numbers.Count == 0)
                return 0;

            return numbers.Sum() / numbers.Count;
        }
    }

    //FUNCIÓN PARA HALLAR LA MEDIA ARMONICA

    public class HarmonicMeanCalculator : IMediaCalculator
    {
        public double Calculate(List<double> numbers)
        {
            if (numbers.Count == 0)
                return 0;

            return numbers.Count / numbers.Sum(num => 1 / num);
        }
    }


    //FUNCIÓN PARA HALLAR LA MEDIA (COMO CONSIDERACIÓN SE TIENE QUE SI EL NÚMERO INGRESADO ES IMPAR LA MEDIA ES EL NÚMERO DEL CENTRO, PERO SI ES PAR ES EL PROMEDIO DE LOS DOS DEL CENTRO)

    public class MedianCalculator : IMediaCalculator //SE USA LA INTERFAZ COMO CONTRATO PARA QUE SE ACEPTE UNA LISTA DE NÚMEROS Y DEVUELVA UN VALOR DOUBLE
    {
        public double Calculate(List<double> numbers)
        {
            var sorted = numbers.OrderBy(num => num).ToList();
            var count = sorted.Count;
            if (count == 0)
                return 0;

            if (count % 2 == 0)
                return (sorted[count / 2 - 1] + sorted[count / 2]) / 2.0;
            else
                return sorted[count / 2];
        }
    }


    //FUNCIÓN PARA DIRECCIÓN A LA FUNCIÓN QUE SE REQUIERE SEGÚN LA PETICIÓN DEL USUARIO


    public class MediaCalculatorFactory
    {
        public IMediaCalculator CreateCalculator(string type)
        {
            switch (type.ToUpper())
            {
                case "ARITHMETIC":
                    return new ArithmeticMeanCalculator();
                case "HARMONIC":
                    return new HarmonicMeanCalculator();
                case "MEDIAN":
                    return new MedianCalculator();
                default:
                    throw new ArgumentException("Tipo de calculadora no válido.");
            }
        }
    }

    //FUNCIONES PARA ESCALERA

    //FUNCIÓN QUE CUMPLE LA CONDICIONES DEL GENERADOR A EN DONDE LA ALINEACIÓN ES ASCENDENTE Y A LA DERECHA

    public class StaircaseGeneratorA : IStaircaseGenerator
    {
        public string GetStaircase(int size)
        {
            string staircase = "";
            for (int i = 1; i <= size; i++)
            {
                staircase += new string(' ', size - i) + new string('#', i) + "\n";
            }
            return staircase;
        }
    }

    //FUNCIÓN QUE CUMPLE LA CONDICIONES DEL GENERADOR B EN DONDE LA ALINEACIÓN ES DESCENDENTE Y A LA DERECHA

    public class StaircaseGeneratorB : IStaircaseGenerator
    {
        public string GetStaircase(int size)
        {
            string staircase = "";
            for (int i = size; i >= 1; i--)
            {
                string spaces = new string(' ', size - i); // Espacios antes de los símbolos #
                string symbols = new string('#', i); // Símbolos #
                staircase += spaces + symbols + "\n";
            }
            return staircase;
        }
    }

    //FUNCIÓN QUE CUMPLE LA CONDICIONES DEL GENERADOR C EN DONDE LA PRIMERA FILA DEBE SER EL NÚMERO INGRESADO, EMPIEZA A AVANCAR DE A 2 HASTA EL CENTRO Y LUEGO DESCIENDE HASTA LLEGAR AL NÚMERO INICIAL INGRESADO


    public class StaircaseGeneratorC : IStaircaseGenerator
    {

        public string GetStaircase(int n)
        {
            if (n <= 0 || n >= 100)
                throw new ArgumentException("El tamaño de la escalera debe estar en el rango de 1 a 99.");

            string staircase = "";

            // Calcular la longitud de la línea central
            int centralLength = n + n * 2;

            
            for (int i = 0; i < n - 1; i++)
            {
               
                int numSymbols = n + (i + 1) * 2;

              
                int numSpacesBefore = (centralLength - numSymbols) / 2;

                // Añadir un espacio adicional en la mitad superior de la escalera
                if (i == (n - 1) / 2 - 1 && n % 2 == 0)
                {
                    numSpacesBefore++;
                }

               
                for (int j = 0; j < numSpacesBefore; j++)
                {
                    staircase += " ";
                }

                // Imprimir los símbolos #
                for (int j = 0; j < numSymbols; j++)
                {
                    staircase += "#";
                }

                // Nueva línea, excepto para la última iteración
                if (i < n - 1)
                {
                    staircase += "\n";
                }
            }

            // Imprimir la fila central
            for (int j = 0; j < centralLength; j++)
            {
                staircase += "#";
            }

            // Nueva línea después de la fila central
            staircase += "\n";

            // Imprimir la mitad inferior de la escalera
            for (int i = n - 2; i >= 0; i -= 2)
            {
                // Calcular el número de símbolos # en esta línea
                int numSymbols = n + i * 2;

                // Calcular el número de espacios antes de los símbolos #
                int numSpacesBefore = (centralLength - numSymbols) / 2;

                // Añadir un espacio adicional al principio de la línea
                staircase += " ";

                // Imprimir los espacios antes del símbolo #
                for (int j = 0; j < numSpacesBefore; j++)
                {
                    staircase += " ";
                }

                // Imprimir los símbolos #
                for (int j = 0; j < numSymbols; j++)
                {
                    staircase += "#";
                }

                // Nueva línea, excepto para la última iteración
                if (i > 0)
                {
                    staircase += "\n";
                }
            }

            return staircase;
        }




    }
}