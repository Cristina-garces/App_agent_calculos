using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App_calculos.Controllers.Interfaces;
using App_calculos.Controllers.Clases;


namespace App_calculos.Controllers
{
    public class HomeController : Controller
    {

        private readonly MediaCalculatorFactory _calculatorFactory; //SE INICIALIZA EL ELEMENTO CON LA CLASE A UTILIZAR PARA SABER EL TIPO DE AGENTE

        public HomeController()
        {
            _calculatorFactory = new MediaCalculatorFactory();  // SE ASIGNA EL OBJETO PARA UTILIZAR SUS MÉTODOS
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //SE RECIBEN LOS PARÁMETROS QUE VIENEN DE LA VISTA Y SE PROCESAN CON LAS CLASES PARA RETORNAR EL VALOR SEGÚN EL AGENTE SELECCIONADO
        public ActionResult CalculateMedia(string type, string numbers)
        {
            var numbersList = numbers.Split(',').Select(double.Parse).ToList();
            try
            {
                var calculator = _calculatorFactory.CreateCalculator(type);
                var result = calculator.Calculate(numbersList);
                ViewBag.Result = result;
            }
            catch (ArgumentException ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View("Index");
        }


        //SE VALIDA QUE LA LONGITUD SI COINCIDA CON LO REQUERIDO SI ES ASI SE ENVIA A VALIDAR EL TIPO DE ESCALERA QUE VA A EJECUTAR Y DIBUJAR

        public ActionResult GenerateStaircase(int size, char agentType)
        {
            if (size <= 0 || size >= 100)
            {
                ViewBag.Error = "El tamaño de la escalera debe estar entre 1 y 99.";
                return View("Index");
            }

            string staircase = GetStaircase(size, agentType);

            ViewBag.Staircase = staircase;

            return View("Index");
        }

        //SE CREA LA INSTANCIA DEL OBJETO PARA CONSUMIR SU FUNCIÓN SEGÚN EL TIPO DE ESCALERA QUE SE SELECCIONE Y SE LE ENVIA EL PARAMETRO PARA DEVOLVER LA DIBUJO DE LA ESCALERA

        private string GetStaircase(int size, char agentType)
        {
            IStaircaseGenerator staircaseGenerator;

            switch (agentType)
            {
                case 'A':
                    staircaseGenerator = new StaircaseGeneratorA();
                    break;
                case 'B':
                    staircaseGenerator = new StaircaseGeneratorB();
                    break;
                case 'C':
                    staircaseGenerator = new StaircaseGeneratorC();
                    break;
                default:
                    throw new ArgumentException("Tipo de agente de escalera inválido.");
            }

            return staircaseGenerator.GetStaircase(size);
        }
    }
}