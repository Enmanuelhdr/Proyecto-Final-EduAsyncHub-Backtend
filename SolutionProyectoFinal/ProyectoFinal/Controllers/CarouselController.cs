using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Context;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarouselController : Controller
    {

        private readonly EduAsyncHubContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly string _fotosFolder;

        public CarouselController(EduAsyncHubContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
            _fotosFolder = Path.Combine(_env.WebRootPath, "fotos");

            if (!Directory.Exists(_fotosFolder))
            {
                Directory.CreateDirectory(_fotosFolder);
            }
        }

        [HttpGet("fotos-carrusel")]
        public IActionResult GetFotosCarrusel()
        {
            var fotosCarrusel = _context.Carrusels
                .Select(foto => new
                {
                    Url = foto.ImagenUrl,
                    Título = foto.Titulo,
                    Descripción = foto.Descripcion
                })
                .ToList();

            return Ok(fotosCarrusel);
        }

        public class FotoInputModel
        {
            public string Título { get; set; }
            public string Descripción { get; set; }
            public IFormFile Archivo { get; set; }
        }

        [HttpPost]
        public IActionResult SubirFoto([FromForm] FotoInputModel model)
        {
            if (model == null || model.Archivo == null)
                return BadRequest("Archivo no proporcionado");

            var extension = Path.GetExtension(model.Archivo.FileName);
            var nombreArchivo = $"{Guid.NewGuid()}{extension}";
            var rutaGuardar = Path.Combine(_fotosFolder, nombreArchivo);

            using (var stream = new FileStream(rutaGuardar, FileMode.Create))
            {
                model.Archivo.CopyTo(stream);
            }

            var nuevaFoto = new Carrusel

            {
                ImagenUrl = $"fotos/{nombreArchivo}",
                Titulo = model.Título,
                Descripcion = model.Descripción
            };

            _context.Carrusels.Add(nuevaFoto);
            _context.SaveChanges();

            return Ok("Foto subida exitosamente");
        }
    }
}
