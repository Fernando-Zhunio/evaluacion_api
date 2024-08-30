using evaluacion_api.Models;
using evaluacion_api.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace evaluacion_api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EvaluacionController : Controller
	{
        // GET: EvaluacionController
		EvaluacionContext context;
        public EvaluacionController(EvaluacionContext evaluacionContext)
        {
			context = evaluacionContext;
        }
        [HttpGet("Buttons")]
		public async Task<ActionResult<List<ButtonHtml>>>  GetButtons()
		{
			return Ok(await context.ButtonHtmls.ToListAsync());
		}

		[HttpGet("Inputs")]
		public async Task<ActionResult<List<InputHtml>>> GetInputs()
		{
			return await context.InputHtmls.ToListAsync();
		}

		[HttpGet("InputsByForm/{formId}")]
		public async Task<ActionResult<List<InputHtml>>> GetButtonsByForm(int formId)
		{
			return await context.InputHtmls.AsQueryable().Where( x => x.formHtmlId == formId).ToListAsync();
		}

		[HttpPost("Inputs")]
		public async Task<ActionResult<InputHtml>> InputStore(InputStoreRequest request)
		{
			InputHtml inputHtml = new InputHtml
			{
				formHtmlId = request.formHtmlId,
				label = request.label,
				name = request.name,
				placeholder = request.placeholder,
				type = request.type,
				value = request.value,
			};
			await context.InputHtmls.AddAsync(inputHtml);
			await context.SaveChangesAsync();
			return inputHtml;
		}



		// GET: EvaluacionController/Details/5
		//public ActionResult Details(int id)
		//{
		//	return View();
		//}  

		//// GET: EvaluacionController/Create
		//public ActionResult Create()
		//{
		//	return View();
		//}

		//// POST: EvaluacionController/Create
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Create(IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}

		//// GET: EvaluacionController/Edit/5
		//public ActionResult Edit(int id)
		//{
		//	return View();
		//}

		//// POST: EvaluacionController/Edit/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Edit(int id, IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}

		//// GET: EvaluacionController/Delete/5
		//public ActionResult Delete(int id)
		//{
		//	return View();
		//}

		//// POST: EvaluacionController/Delete/5
		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public ActionResult Delete(int id, IFormCollection collection)
		//{
		//	try
		//	{
		//		return RedirectToAction(nameof(Index));
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}
	}
}
