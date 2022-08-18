using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LocaFácil.App.Areas.Veiculos.Models;
using LocFácil.Business.Interfaces;
using LocFácil.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocaFácil.App.Areas.Veiculos.Controllers
{
    [Area("Veiculos")]
    public class VeiculosController : Controller
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculosController(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var veiculos = await _veiculoRepository.ObterTodos();

            var veiculosViewModel = veiculos.Select(v => new VeiculoViewModel
            {
                Id = v.Id,
                Nome = v.Nome,
                Cor = v.Cor,
                Marca = v.Marca,
                AnoFabricacao = v.AnoFabricacao,
                NumPortas = v.NumPortas,
                TipoCombustivel = v.TipoCombustivel,
                ArCondicionado = v.ArCondicionado,
                Direcao = v.Direcao,
                FreioAbs = v.FreioAbs,
                Trava = v.Trava,
                Airbag = v.Airbag,
                QtdLugar = v.QtdLugar,
                Vidro = v.Vidro,
                FarolNeblina = v.FarolNeblina,
                Descricao = v.Descricao,
                Valor = v.Valor,
                Situacao = v.Situacao
            });

            return View(veiculosViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var veiculoViewModel = await _veiculoRepository.ObterPorId(id);
            
            var veiculo = new VeiculoViewModel
            {

                Id = veiculoViewModel.Id,
                Nome = veiculoViewModel.Nome,
                Cor = veiculoViewModel.Cor,
                Marca = veiculoViewModel.Marca,
                AnoFabricacao = veiculoViewModel.AnoFabricacao,
                NumPortas = veiculoViewModel.NumPortas,
                TipoCombustivel = veiculoViewModel.TipoCombustivel,
                ArCondicionado = veiculoViewModel.ArCondicionado,
                Direcao = veiculoViewModel.Direcao,
                FreioAbs = veiculoViewModel.FreioAbs,
                Trava = veiculoViewModel.Trava,
                Airbag = veiculoViewModel.Airbag,
                QtdLugar = veiculoViewModel.QtdLugar,
                Vidro = veiculoViewModel.Vidro,
                FarolNeblina = veiculoViewModel.FarolNeblina,
                Descricao = veiculoViewModel.Descricao,
                Valor = veiculoViewModel.Valor,
                Situacao = veiculoViewModel.Situacao
            };

            if (veiculo == null) return NotFound();
            
            return View(veiculo);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VeiculoViewModel veiculoViewModel)
        {
            if (!ModelState.IsValid) return View("Create");

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(veiculoViewModel.ImagemUpload, imgPrefixo))
            {
                return View("Index");
            }

            var veiculo = new Veiculo
            {

                Id = veiculoViewModel.Id,
                Nome = veiculoViewModel.Nome,
                Cor = veiculoViewModel.Cor,
                Marca = veiculoViewModel.Marca,
                AnoFabricacao = veiculoViewModel.AnoFabricacao,
                NumPortas = veiculoViewModel.NumPortas,
                TipoCombustivel = veiculoViewModel.TipoCombustivel,
                ArCondicionado = veiculoViewModel.ArCondicionado,
                Direcao = veiculoViewModel.Direcao,
                FreioAbs = veiculoViewModel.FreioAbs,
                Trava = veiculoViewModel.Trava,
                Airbag = veiculoViewModel.Airbag,
                QtdLugar = veiculoViewModel.QtdLugar,
                Vidro = veiculoViewModel.Vidro,
                FarolNeblina = veiculoViewModel.FarolNeblina,
                Descricao = veiculoViewModel.Descricao,
                Valor = veiculoViewModel.Valor,
                Situacao = veiculoViewModel.Situacao,
                Imagem = imgPrefixo + veiculoViewModel.ImagemUpload.FileName
            };

            await _veiculoRepository.Adicionar(veiculo);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var veiculo = await _veiculoRepository.ObterPorId(id);

            var veiculoViewModel = new VeiculoViewModel
            {
                Id = veiculo.Id,
                Nome = veiculo.Nome,
                Cor = veiculo.Cor,
                Marca = veiculo.Marca,
                AnoFabricacao = veiculo.AnoFabricacao,
                NumPortas = veiculo.NumPortas,
                TipoCombustivel = veiculo.TipoCombustivel,
                ArCondicionado = veiculo.ArCondicionado,
                Direcao = veiculo.Direcao,
                FreioAbs = veiculo.FreioAbs,
                Trava = veiculo.Trava,
                Airbag = veiculo.Airbag,
                QtdLugar = veiculo.QtdLugar,
                Vidro = veiculo.Vidro,
                FarolNeblina = veiculo.FarolNeblina,
                Descricao = veiculo.Descricao,
                Valor = veiculo.Valor,
                Situacao = veiculo.Situacao
            };

            return View(veiculoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VeiculoViewModel veiculoViewModel)
        {
            if (id != veiculoViewModel.Id) return NotFound();

            var veiculoAtualizacao = await _veiculoRepository.ObterPorId(id);
            //veiculoViewModel.Cliente = produtoAtualizacao.Cliente;
            veiculoViewModel.Imagem = veiculoAtualizacao.Imagem;
            if (!ModelState.IsValid) return View(veiculoViewModel);

            if (veiculoViewModel.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadArquivo(veiculoViewModel.ImagemUpload, imgPrefixo))
                {
                    return View(veiculoViewModel);
                }

                veiculoAtualizacao.Imagem = imgPrefixo + veiculoViewModel.ImagemUpload.FileName;
            }

            veiculoAtualizacao.Nome = veiculoViewModel.Nome;
            veiculoAtualizacao.Cor = veiculoViewModel.Cor;
            veiculoAtualizacao.Marca = veiculoViewModel.Marca;
            veiculoAtualizacao.AnoFabricacao = veiculoViewModel.AnoFabricacao;
            veiculoAtualizacao.NumPortas = veiculoViewModel.NumPortas;
            veiculoAtualizacao.TipoCombustivel = veiculoViewModel.TipoCombustivel;
            veiculoAtualizacao.ArCondicionado = veiculoViewModel.ArCondicionado;
            veiculoAtualizacao.Direcao = veiculoViewModel.Direcao;
            veiculoAtualizacao.FreioAbs = veiculoViewModel.FreioAbs;
            veiculoAtualizacao.Trava = veiculoViewModel.Trava;
            veiculoAtualizacao.Airbag = veiculoViewModel.Airbag;
            veiculoAtualizacao.QtdLugar = veiculoViewModel.QtdLugar;
            veiculoAtualizacao.Vidro = veiculoViewModel.Vidro;
            veiculoAtualizacao.FarolNeblina = veiculoViewModel.FarolNeblina;
            veiculoAtualizacao.Descricao = veiculoViewModel.Descricao;
            veiculoAtualizacao.Valor = veiculoViewModel.Valor;
            veiculoAtualizacao.Situacao = veiculoViewModel.Situacao;
            veiculoAtualizacao.Imagem = veiculoViewModel.Imagem;

            await _veiculoRepository.Atualizar(new Veiculo
            {
                Id = veiculoViewModel.Id,
                Nome = veiculoViewModel.Nome,
                Cor = veiculoViewModel.Cor,
                Marca = veiculoViewModel.Marca,
                AnoFabricacao = veiculoViewModel.AnoFabricacao,
                NumPortas = veiculoViewModel.NumPortas,
                TipoCombustivel = veiculoViewModel.TipoCombustivel,
                ArCondicionado = veiculoViewModel.ArCondicionado,
                Direcao = veiculoViewModel.Direcao,
                FreioAbs = veiculoViewModel.FreioAbs,
                Trava = veiculoViewModel.Trava,
                Airbag = veiculoViewModel.Airbag,
                QtdLugar = veiculoViewModel.QtdLugar,
                Vidro = veiculoViewModel.Vidro,
                FarolNeblina = veiculoViewModel.FarolNeblina,
                Descricao = veiculoViewModel.Descricao,
                Valor = veiculoViewModel.Valor,
                Situacao = veiculoViewModel.Situacao,
            });

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var veiculo = await _veiculoRepository.ObterPorId(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return View(veiculo);

        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var veiculo = await _veiculoRepository.ObterPorId(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            await _veiculoRepository.Remover(id);

            TempData["Sucesso"] = "Produto excluido com sucesso!";

            return RedirectToAction("Index");
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgPrefixo + Path.GetFileName(arquivo.FileName));
            
            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }
    }
}