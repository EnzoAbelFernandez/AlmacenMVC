using AlmacenMVC.Data;
using AlmacenMVC.Dtos;
using AlmacenMVC.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlmacenMVC.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly IRepositorio<Articulo> _repositorio;
        private readonly IMapper _mapper;

        public ArticulosController(IRepositorio<Articulo> repositorio, IMapper mapper)
        {
            _repositorio = repositorio;
            _mapper = mapper;
        }

        // GET: Articulos
        public async Task<IActionResult> Index()
        {
            var articulos = await _repositorio.GetAllAsync();
            var articulosDto = _mapper.Map<IEnumerable<ArticuloDto>>(articulos);
            return View(articulosDto);
        }

        // GET: Articulos/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var articulo = await _repositorio.GetByIdAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            var articuloDto = _mapper.Map<ArticuloDto>(articulo);
            return View(articuloDto);
        }

        // GET: Articulos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articulos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticuloDto articuloDto)
        {
            if (ModelState.IsValid)
            {
                var articulo = _mapper.Map<Articulo>(articuloDto);
                await _repositorio.AddAsync(articulo);
                return RedirectToAction(nameof(Index));
            }

            return View(articuloDto);
        }

        // GET: Articulos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var articulo = await _repositorio.GetByIdAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            var articuloDto = _mapper.Map<ArticuloDto>(articulo);
            return View(articuloDto);
        }

        // POST: Articulos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArticuloDto articuloDto)
        {
            if (id != articuloDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var articulo = _mapper.Map<Articulo>(articuloDto);
                await _repositorio.UpdateAsync(articulo);
                return RedirectToAction(nameof(Index));
            }

            return View(articuloDto);
        }

        // GET: Articulos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var articulo = await _repositorio.GetByIdAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            var articuloDto = _mapper.Map<ArticuloDto>(articulo);
            return View(articuloDto);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repositorio.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
