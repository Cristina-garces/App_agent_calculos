using NUnit.Framework;
using App_calculos.Controllers.Clases;
using System.Collections.Generic;


/*Se usa Unit para el proceso de pruebas de
cada una de las clases que se acceden o se les ingresa la data por medio de las interfaces en donde 
se busca cumplir con las reglas de cada una de ellas y devolver el valor dado en la funcion,
esto con el fin de utilizar patrones de diseño que ayuden a la escalabilidad de la aplicación*/

namespace App_calculos.Tests
{

    //PRUEBAS UNITARIAS PARA LOS CÁLCULOS DE LA MEDIA

    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void ArithmeticMeanCalculator_Calculate_ReturnsCorrectMean()
        {
            // Arreglo
            var calculator = new ArithmeticMeanCalculator();
            var numbers = new List<double> { 1, 2, 3, 4, 5 };

            // Acción
            var result = calculator.Calculate(numbers);

            // Acierto
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void HarmonicMeanCalculator_Calculate_ReturnsCorrectMean()
        {
            // Arreglo
            var calculator = new HarmonicMeanCalculator();
            var numbers = new List<double> { 1, 2, 3, 4, 5 };

            // Acción
            var result = calculator.Calculate(numbers);

            // Acierto
            Assert.That(result, Is.EqualTo(2.18978102189781).Within(0.000001));
        }

        [Test]
        public void MedianCalculator_Calculate_ReturnsCorrectMedian()
        {
            // Arreglo
            var calculator = new MedianCalculator();
            var numbers = new List<double> { 1, 3, 5, 2, 4 };

            // Acción
            var result = calculator.Calculate(numbers);

            // Acierto
            Assert.That(result, Is.EqualTo(3));
        }
    }

    //PRUEBAS UNITARIAS PARA LA ESCALERA

    [TestFixture]
    public class StaircaseGeneratorTests
    {
        [Test]
        public void StaircaseGeneratorA_GetStaircase_ReturnsCorrectStaircase()
        {
            // Arreglo
            var generator = new StaircaseGeneratorA();
            int size = 5;
            string expectedStaircase = "    #\n   ##\n  ###\n ####\n#####\n";

            // Acción
            string result = generator.GetStaircase(size);

            // Acierto
            Assert.That(result, Is.EqualTo(expectedStaircase));
        }

        [Test]
        public void StaircaseGeneratorB_GetStaircase_ReturnsCorrectStaircase()
        {
            // Arreglo
            var generator = new StaircaseGeneratorB();
            int size = 5;
            string expectedStaircase = "#####\n ####\n  ###\n   ##\n    #\n";

            // Acción
            string result = generator.GetStaircase(size);

            // Acierto
            Assert.That(result, Is.EqualTo(expectedStaircase));
        }

        [Test]
        public void StaircaseGeneratorC_GetStaircase_ReturnsCorrectStaircase()
        {
            // Arreglo
            var generator = new StaircaseGeneratorC();
            int size = 5;
            string expectedStaircase = "  #\n ##\n###\n###\n ##\n  #\n";

            // Acción
            string result = generator.GetStaircase(size);

            // Acierto
            Assert.That(result, Is.EqualTo(expectedStaircase));
        }
    }
}
