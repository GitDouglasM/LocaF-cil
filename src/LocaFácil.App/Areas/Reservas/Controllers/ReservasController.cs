using System;
using System.Linq;
using System.Threading.Tasks;
using LocaFácil.App.Areas.Clientes.Models;
using LocaFácil.App.Areas.Reservas.Models;
using LocFácil.Business.Interfaces;
using LocFácil.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocaFácil.App.Areas.Reservas.Controllers
{
    [Area("Reservas")]
    public class ReservasController : Controller
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservasController(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var reservas = await _reservaRepository.ObterTodos();

            var reservasViewModel = reservas.Select(v => new ReservaViewModel
            {
                Id = v.Id,
                DataInicio = v.DataInicio,
                DataFinal = v.DataFinal,
                Dinheiro = v.Dinheiro,
                Cartao = v.Cartao,
                Comentario = v.Comentario,
                Seguro = v.Seguro
            });

            return View(reservasViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var reservaViewModel = await _reservaRepository.ObterPorId(id);

            var reserva = new ReservaViewModel
            {
                DataInicio = reservaViewModel.DataInicio,
                DataFinal = reservaViewModel.DataFinal,
                Dinheiro = reservaViewModel.Dinheiro,
                Cartao = reservaViewModel.Cartao,
                Comentario = reservaViewModel.Comentario,
                Seguro = reservaViewModel.Seguro,
            };

            if (reserva == null) return NotFound();

            return View(reserva);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservaViewModel reservaViewModel)
        {
            if (!ModelState.IsValid) return View(reservaViewModel);

            var reserva = new Reserva
            {
                DataInicio = reservaViewModel.DataInicio,
                DataFinal = reservaViewModel.DataFinal,
                Dinheiro = reservaViewModel.Dinheiro,
                Cartao = reservaViewModel.Cartao,
                Comentario = reservaViewModel.Comentario,
                Seguro = reservaViewModel.Seguro,
            };

            await _reservaRepository.Adicionar(reserva);

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var reservaViewModel = await _reservaRepository.ObterPorId(id);

            var reserva = new Reserva
            {
                DataInicio = reservaViewModel.DataInicio,
                DataFinal = reservaViewModel.DataFinal,
                Dinheiro = reservaViewModel.Dinheiro,
                Cartao = reservaViewModel.Cartao,
                Comentario = reservaViewModel.Comentario,
            };


            if (reserva == null) return NotFound();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ReservaViewModel reservaViewModel)
        {
            if (id != reservaViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                await _reservaRepository.SaveChanges();

            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var reserva = await _reservaRepository.ObterPorId(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return View();

        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var reserva = await _reservaRepository.ObterPorId(id);

            if (reserva == null)
            {
                return NotFound();
            }

            await _reservaRepository.Remover(id);

            TempData["Sucesso"] = "Produto excluido com sucesso!";

            return RedirectToAction("Index");
        }
    }
}