﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coleta_Colchao.Controllers
{
    [Authorize]
    public class ColetaController : Controller
    {
        public IActionResult IndexMolas()
        {
            return View();
        }
        public IActionResult IndexEspuma()
        {
            return View();
        }
        public IActionResult EnsaioEspumaParte1()
        {
            return View("Espuma/EnsaioEspumaParte1");
        }
        public IActionResult EnsaioEspumaParte2()
        {
            return View("Espuma/EnsaioEspumaParte2");
        }
        public IActionResult EnsaioEspumaParte3()
        {
            return View("Espuma/EnsaioEspumaParte3");
        }
        public IActionResult EnsaioEspumaParte4()
        {
            return View("Espuma/EnsaioEspumaParte4");
        }
        public IActionResult EnsaioBaseCargaEstetica()
        {
            return View();
        }
        public IActionResult EnsaioBaseEstruturaDurabi()
        {
            return View();
        }

        public IActionResult EnsaioDurabilidade()
        {
            return View();
        }

        public IActionResult EnsaioImpacto()
        {
            return View();
        }

        public IActionResult EnsaioMolasParte1()
        {
            return View("Molas/EnsaioMolasParte1");
        }

        public IActionResult EnsaioMolasParte2()
        {
            return View("Molas/EnsaioMolasParte2");
        }

        public IActionResult EnsaioMolasParte3()
        {
            return View("Molas/EnsaioMolasParte3");

        }

        //INICIO DAS FUNÇÕES PARA SALVAR OS DADOS,
        [HttpPost]
        public async Task<IActionResult> SalvarColetaMolas1()
        {
           TempData["Mensagem"] = "Entrou";
            return RedirectToAction("EnsaioMolasParte1");
        }
    }
}