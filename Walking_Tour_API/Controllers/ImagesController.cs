using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Walking_Tour_API.Core.Interface.Repositories;
using Walking_Tour_API.Core.Models.Domain;
using Walking_Tour_API.Core.Models.DTO.Image;

namespace Walking_Tour_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ImagesController : ControllerBase
	{
		private readonly IImageRepository _image;
		private IMapper _mapper; 
		public ImagesController(IImageRepository image, IMapper mapper)
		{
			_image = image;
			_mapper = mapper;
		}
		[HttpPost]
		[Route("Upload")]
		public async Task<IActionResult> Upload([FromForm] UploadImageDTO dto)
		{
			ValidateFileUpload(dto);
			if (ModelState.IsValid)
			{
				// convert dto to entity
				var image = _mapper.Map<Image>(dto);

				// upload image
				await _image.Upload(image);

				return Ok(image);
			}

			return BadRequest(ModelState);
		}

		private void ValidateFileUpload(UploadImageDTO request)
		{
			var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

			if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
			{
				ModelState.AddModelError("file", "Unsupported file extension");
			}

			if (request.File.Length > 10485760)
			{
				ModelState.AddModelError("file", "File size more than 10MB, please upload a smaller size file.");
			}
		}
	}
}
