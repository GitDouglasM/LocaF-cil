using System;
using System.Linq;
using System.Threading.Tasks;
using LocaFácil.App.Areas.Clientes.Models;
using LocFácil.Business.Interfaces;
using LocFácil.Business.Models;
using LocFácil.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocaFácil.App.Areas.Clientes.Controllers
{
    [Area("Clientes")]
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository; 
        //private readonly IReservaRepository _reservaRepository;

        public ClientesController(IClienteRepository clienteRepository) 
                                  //IReservaRepository reservaRepository)
        {
            _clienteRepository = clienteRepository;
            //_reservaRepository = reservaRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Novo"] = "Criar novo";

            var clientes = await _clienteRepository.ObterTodos();

            var clientesViewModel = clientes.Select(v => new ClienteViewModel
            {
                Id = v.Id,
                Nome = v.Nome,
                Cpf = v.Cpf,
                Rg = v.Rg,
                Celular = v.Celular,
                Logradouro = v.Logradouro,
                Numero = v.Numero,
                Complemento = v.Complemento,
                Cep = v.Cep,
                Bairro = v.Bairro,
                Cidade = v.Cidade,
                Estado = v.Estado
            });

            return View(clientesViewModel);

        }

        public async Task<IActionResult> Details(int id)
        {
            var clienteViewModel = await _clienteRepository.ObterPorId(id);

            var cliente = new ClienteViewModel
            {
                Id = clienteViewModel.Id,
                Nome = clienteViewModel.Nome,
                Cpf = clienteViewModel.Cpf,
                Rg = clienteViewModel.Rg,
                Celular = clienteViewModel.Celular,
                Logradouro = clienteViewModel.Logradouro,
                Numero = clienteViewModel.Numero,
                Complemento = clienteViewModel.Complemento,
                Cep = clienteViewModel.Cep,
                Bairro = clienteViewModel.Bairro,
                Cidade = clienteViewModel.Cidade,
                Estado = clienteViewModel.Estado
            };

            if (cliente == null) return NotFound();

            return View(cliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);
            
            var cliente = new Cliente
            {
                Id = clienteViewModel.Id,
                Nome = clienteViewModel.Nome,
                Cpf = clienteViewModel.Cpf,
                Rg = clienteViewModel.Rg,
                Celular = clienteViewModel.Celular,
                Logradouro = clienteViewModel.Logradouro,
                Numero = clienteViewModel.Numero,
                Complemento = clienteViewModel.Complemento,
                Cep = clienteViewModel.Cep,
                Bairro = clienteViewModel.Bairro,
                Cidade = clienteViewModel.Cidade,
                Estado = clienteViewModel.Estado
            };

            await _clienteRepository.Adicionar(cliente);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var clienteViewModel = await _clienteRepository.ObterPorId(id);

            var cliente = new Cliente
            {
                Id = clienteViewModel.Id,
                Nome = clienteViewModel.Nome,
                Cpf = clienteViewModel.Cpf,
                Rg = clienteViewModel.Rg,
                Celular = clienteViewModel.Celular,
                Logradouro = clienteViewModel.Logradouro,
                Numero = clienteViewModel.Numero,
                Complemento = clienteViewModel.Complemento,
                Cep = clienteViewModel.Cep,
                Bairro = clienteViewModel.Bairro,
                Cidade = clienteViewModel.Cidade,
                Estado = clienteViewModel.Estado
            };

            if (cliente == null) return NotFound();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (int id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                await _clienteRepository.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clienteRepository.ObterPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View();

        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var cliente = await _clienteRepository.ObterPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            await _clienteRepository.Remover(id);

            TempData["Sucesso"] = "Produto excluido com sucesso!";

            return RedirectToAction("Index");
        }


    }
}