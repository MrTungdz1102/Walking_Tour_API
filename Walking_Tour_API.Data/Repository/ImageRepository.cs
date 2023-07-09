using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Walking_Tour_API.Core.Interface;
using Walking_Tour_API.Core.Interface.Repositories;
using Walking_Tour_API.Core.Models.Domain;
using Walking_Tour_API.Infrastructure.Context;

namespace Walking_Tour_API.Infrastructure.Repository
{
	public class ImageRepository : IImageRepository
	{
		private readonly IWebHostEnvironment _webHostEnvironment;
		private readonly TourAPIDbContext _context;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public ImageRepository(IWebHostEnvironment webHostEnvironment, TourAPIDbContext context, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) 
		{
			_webHostEnvironment = webHostEnvironment;
			_context = context;
			_httpContextAccessor = httpContextAccessor;
			_unitOfWork = unitOfWork;
		}
		public async Task<Image> Upload(Image image)
		{
			// web api khong co muc wwwroot
			var localFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "Images",
				$"{image.FileName}{image.FileExtension}");
			using var stream = new FileStream(localFilePath, FileMode.Create);
			await image.File.CopyToAsync(stream);

			// https://localhost:3000/admin/images/images.jpg

			// _httpContextAccessor.HttpContext.Request.Scheme = http or https

			// _httpContextAccessor.HttpContext.Request.PathBase = /admin or / vơi truong hop
			// https://localhost:3000/images/images.jpg

			// _httpContextAccessor.HttpContext.Request.Host = localhost:3000

			var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";
			image.FilePath = urlFilePath;


			// Add Image to the Images table
			await _context.Images.AddAsync(image);
			await _unitOfWork.SaveAsync();
			return image;
		}
	}
}
